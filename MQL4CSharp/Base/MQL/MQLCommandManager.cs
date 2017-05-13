/*
Copyright 2016 Jason Separovic

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

    http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
*/

using System;
using RGiesecke.DllExport;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using log4net;
using mqlsharp.Util;
using MQL4CSharp.Base.Enums;
using MQL4CSharp.Base.Exceptions;
using System.Globalization;
using System.Threading.Tasks;

namespace MQL4CSharp.Base.MQL
{
    public class MQLCommandManager
    {
        private static readonly ILog LOG = LogManager.GetLogger(typeof(MQLCommandManager));

        private Int64 ix;

        private Dictionary<int, MQLCommandRequest> commandRequests;

        private static long UNLOCKED = -1;

        private readonly object syncLock;
        private long commandLock;

        static char DELIMITER = (char)29;

        private int counter;

        public MQLCommandManager(Int64 ix)
        {
            LOG.Debug(String.Format("Initializing MQLCommandManager: {0}", ix));
            this.commandRequests = new Dictionary<int, MQLCommandRequest>();
            this.ix = ix;
            counter = 0;
            syncLock = new object();
            commandLock = UNLOCKED;
        }

        
        public int ExecCommand(MQLCommand command, List<Object> parameters, TaskCompletionSource<Object> taskCompletionSource = null)
        {
            LOG.DebugFormat("ExecCommand: {0}", command.ToString());
            int id;
            lock (syncLock)
            {
                id = counter++;
                commandRequests[id] = new MQLCommandRequest(id, command, parameters, taskCompletionSource);
            }
            return id;
        }

        public Object GetCommandResult(int id)
        {
            lock (syncLock)
            {
                LOG.DebugFormat("GetCommandResult: {0}", id);
                var req = commandRequests[id];
                Object response = req.Response;
                if (req.TaskCompletionSource != null && req.TaskCompletionSource.Task.IsCompleted)
                {
                    response = req.TaskCompletionSource.Task.Result;
                }
                commandRequests.Remove(id);
                LOG.DebugFormat("Response: {0}", response);
                return response;
            }
        }

        public static MQLCommandManager getInstance(Int64 ix)
        {
            return DLLObjectWrapper.getInstance().getMQLCommandManager(ix);
        }

        public String getCommandParams(int id)
        {
            StringBuilder commandParams = new StringBuilder();

            foreach (Object p in commandRequests[id].Parameters)
            {
                Object param = p;
                if (param is DateTime)
                {
                    // Convert DateTime to MT4 String
                    param = DateUtil.ToMT4TimeString((DateTime)p);
                }
                else if (param is double)
                {
                    // Make sure we use a dot as decimal character
                    param = ((double)p).ToString(CultureInfo.InvariantCulture);
                }

                if (!commandParams.ToString().Equals(""))
                {
                    commandParams.Append(DELIMITER);
                }
                commandParams.Append(param);
            }
            return commandParams.ToString();
        }


        private void setCommandResponse(int id, object response, int errorCode)
        {
            lock (syncLock)
            {
                LOG.DebugFormat("SetCommandResponse({0},{1},{2})", id, response, errorCode);
                commandRequests[id].Done(response, errorCode);
            }
        }

        public void throwExceptionIfErrorResponse(int id)
        {
            lock (syncLock)
            {
                LOG.DebugFormat("throwExceptionIfErrorResponse({0})", id, commandRequests[id].Error);
                if (commandRequests[id].Error > 0)
                {
                    int error = commandRequests[id].Error;
                    String command = commandRequests[id].Command.ToString();
                    String parameters = getCommandParams(id);
                    commandRequests.Remove(id);
                    MQLExceptions.throwMQLException(error, String.Format("{0}({1})", command, parameters));
                }
            }
        }

        public bool IsCommandRunning(int id)
        {
            lock (syncLock)
            {
                //LOG.DebugFormat("IsCommandRunning: {0}={1}", id, commandRequests[id].CommandWaiting);
                return commandRequests[id].CommandWaiting;
            }
        }

        [DllExport("IsCommandWaiting", CallingConvention = CallingConvention.StdCall)]
        public static int IsCommandWaiting(Int64 ix)
        {
            //LOG.DebugFormat("IsCommandWaiting: {0}", ix);
            try
            {
                lock (getInstance(ix).syncLock)
                {
                    foreach (KeyValuePair<int, MQLCommandRequest> pair in getInstance(ix).commandRequests)
                    {
                        //LOG.DebugFormat("IsCommandWaiting: commandRequest: {0}", pair.Value.ToString());
                        if (pair.Value.CommandWaiting)
                        {
                            //LOG.DebugFormat("IsCommandWaiting: commandRequest: returning: {0}", pair.Key);
                            return pair.Key;
                        }
                    }
                }
                //LOG.DebugFormat("IsCommandWaiting: returning -1");
                return -1;
            }
            catch (Exception e)
            {
                LOG.Error(e);
                return -1;
            }
        }


        [DllExport("GetCommandId", CallingConvention = CallingConvention.StdCall)]
        public static int GetCommandId(Int64 ix, int id)
        {
            try
            {
                lock (getInstance(ix).syncLock)
                {
                    if (getInstance(ix).commandRequests[id].CommandWaiting)
                    {
                        return (int) getInstance(ix).commandRequests[id].Command;
                    }
                    else
                    {
                        LOG.Error(Error.ERROR_NO_COMMAND.ToString());
                        return -1;
                    }
                }
            }
            catch (Exception e)
            {
                LOG.Error(e);
                return -1;
            }
        }


        [DllExport("GetCommandName", CallingConvention = CallingConvention.StdCall)]
        public static void GetCommandName(Int64 ix, int id, [In, Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder commandName)
        {
            try
            {
                lock (getInstance(ix).syncLock)
                {
                    if (getInstance(ix).commandRequests[id].CommandWaiting)
                    {
                        commandName.Append(getInstance(ix).commandRequests[id].Command.ToString());
                    }
                    else
                    {
                        LOG.Error(Error.ERROR_NO_COMMAND.ToString());
                        commandName.Append(Error.ERROR_NO_COMMAND.ToString());
                    }
                }
            }
            catch (Exception e)
            {
                LOG.Error(e);
            }
        }

        [DllExport("GetCommandParams", CallingConvention = CallingConvention.StdCall)]
        public static void GetCommandParams(Int64 ix, int id, [In, Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder commandParams)
        {
            try
            {
                lock (getInstance(ix).syncLock)
                {
                    if (getInstance(ix).commandRequests[id].CommandWaiting)
                    {
                        commandParams.Append(getInstance(ix).getCommandParams(id));
                    }
                    else
                    {
                        LOG.Error(Error.ERROR_NO_COMMAND.ToString());
                        commandParams.Append(Error.ERROR_NO_COMMAND.ToString());
                    }
                }
            }
            catch (Exception e)
            {
                LOG.Error(e);
            }

        }

        [DllExport("SetBoolCommandResponse", CallingConvention = CallingConvention.StdCall)]
        public static void SetBoolCommandResponse(Int64 ix, int id, bool response, int error)
        {
            getInstance(ix).setCommandResponse(id, response, error);
        }

        [DllExport("SetDoubleCommandResponse", CallingConvention = CallingConvention.StdCall)]
        public static void SetDoubleCommandResponse(Int64 ix, int id, double response, int error)
        {
            getInstance(ix).setCommandResponse(id, response, error);
        }

        [DllExport("SetIntCommandResponse", CallingConvention = CallingConvention.StdCall)]
        public static void SetIntCommandResponse(Int64 ix, int id, int response, int error)
        {
            getInstance(ix).setCommandResponse(id, response, error);
        }

        [DllExport("SetStringCommandResponse", CallingConvention = CallingConvention.StdCall)]
        public static void SetStringCommandResponse(Int64 ix, int id, [MarshalAs(UnmanagedType.LPWStr)] string response, int error)
        {
            getInstance(ix).setCommandResponse(id, response, error);
        }

        [DllExport("SetVoidCommandResponse", CallingConvention = CallingConvention.StdCall)]
        public static void SetVoidCommandResponse(Int64 ix, int id, int error)
        {
            getInstance(ix).setCommandResponse(id, null, error);
        }

        [DllExport("SetLongCommandResponse", CallingConvention = CallingConvention.StdCall)]
        public static void SetLongCommandResponse(Int64 ix, int id, long response, int error)
        {
            getInstance(ix).setCommandResponse(id, response, error);
        }

        [DllExport("SetDateTimeCommandResponse", CallingConvention = CallingConvention.StdCall)]
        public static void SetDateTimeCommandResponse(Int64 ix, int id, Int64 response, int error)
        {
            getInstance(ix).setCommandResponse(id, DateUtil.FromUnixTime(response), error);
        }

        [DllExport("SetEnumCommandResponse", CallingConvention = CallingConvention.StdCall)]
        public static void SetEnumCommandResponse(Int64 ix, int id, int response, int error)
        {
            getInstance(ix).setCommandResponse(id, response, error);
        }

        [DllExport("CommandLock", CallingConvention = CallingConvention.StdCall)]
        public static bool CommandLock(Int64 ix)
        {
            try
            {
                lock (getInstance(ix).syncLock)
                {
                    if (getInstance(ix).commandLock == UNLOCKED)
                    {
                        //LOG.Info("lock succeeded: " + ix);
                        getInstance(ix).commandLock = ix;
                        return true;
                    }
                    else
                    {
                        //LOG.Info("lock failed: " + ix);
                        return false;
                    }
                }
            }
            catch (Exception e)
            {
                LOG.Error(e);
                return false;
            }
        }


        [DllExport("CommandUnlock", CallingConvention = CallingConvention.StdCall)]
        public static bool CommandUnLock(Int64 ix)
        {
            try
            {
                lock (getInstance(ix).syncLock)
                {
                    if (getInstance(ix).commandLock == ix)
                    {
                        getInstance(ix).commandLock = UNLOCKED;
                        //LOG.Info("unlock succeeded: " + ix);
                        return true;
                    }
                    else
                    {
                        //LOG.Info("unlock failed: " + ix);
                        return false;
                    }
                }
            }
            catch (Exception e)
            {
                LOG.Error(e);
                return false;
            }
        }

    }
}



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
using System.Text;
using log4net;
using mqlsharp.Util;
using MQL4CSharp.Base.Enums;
using MQL4CSharp.Base.Exceptions;

namespace MQL4CSharp.Base.MQL
{
    public class MQLCommandManager
    {
        private static readonly ILog LOG = LogManager.GetLogger(typeof(MQLCommandManager));

        private MQLCommand command;
        private List<Object> parameters;
        private Boolean commandWaiting;
        private Object response;
        private int error;
        private Int64 ix;

        static char DELIMITER = (char)29;

        public MQLCommandManager(Int64 ix)
        {
            LOG.Debug(String.Format("Initializing MQLCommandManager: {0}", ix));

            this.commandWaiting = false;
            this.error = 0;
            this.ix = ix;
        }

        public void ExecCommand(MQLCommand command, List<Object> parameters)
        {
            this.command = command;
            this.parameters = parameters;
            this.commandWaiting = true;
            this.error = 0;
        }

        public bool IsCommandRunning()
        {
            return commandWaiting;
        }

        public Object GetCommandResult()
        {
            return response;
        }


        public static MQLCommandManager getInstance(Int64 ix)
        {
            return DLLObjectWrapper.getInstance().getMQLCommandManager(ix);
        }

        public String getCommandParams()
        {
            StringBuilder commandParams = new StringBuilder();

            string returnCommand = "";
            foreach (Object p in parameters)
            {
                Object param = p;
                if (param is DateTime)
                {
                    // Convert DateTime to MT4 String
                    param = DateUtil.ToMT4TimeString((DateTime)p);
                }

                if (!commandParams.ToString().Equals(""))
                {
                    commandParams.Append(DELIMITER);
                }
                commandParams.Append(param);
            }
            return commandParams.ToString();
        }


        private void setCommandResponse(object response, int errorCode)
        {
            try
            {
                //LOG.Debug(String.Format("SetCommandResponse({0},{1})", response, errorCode));
                this.response = response;
                this.error = errorCode;
                this.commandWaiting = false;
            }
            catch (Exception e)
            {
                LOG.Error(e);
            }
        }

        public void throwExceptionIfErrorResponse()
        {
            if (this.error > 0)
            {
                MQLExceptions.throwMQLException(error, command.ToString() + "(" + getCommandParams() + ")");
            }
        }


        [DllExport("IsCommandWaiting", CallingConvention = CallingConvention.StdCall)]
        public static bool IsCommandWaiting(Int64 ix)
        {
            try
            {
                return getInstance(ix).commandWaiting;
            }
            catch (Exception e)
            {
                LOG.Error(e);
                return false;
            }
        }


        [DllExport("GetCommandId", CallingConvention = CallingConvention.StdCall)]
        public static int GetCommandId(Int64 ix)
        {
            try
            {
                if (getInstance(ix).commandWaiting)
                {
                    return (int)getInstance(ix).command;
                }
                else
                {
                    LOG.Error(Error.ERROR_NO_COMMAND.ToString());
                    return -1;
                }
            }
            catch (Exception e)
            {
                LOG.Error(e);
                return -1;
            }
        }


        [DllExport("GetCommandName", CallingConvention = CallingConvention.StdCall)]
        public static void GetCommandName(Int64 ix, [In, Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder commandName)
        {
            try
            {
                if (getInstance(ix).commandWaiting)
                {
                    commandName.Append(getInstance(ix).command.ToString());
                }
                else
                {
                    LOG.Error(Error.ERROR_NO_COMMAND.ToString());
                    commandName.Append(Error.ERROR_NO_COMMAND.ToString());
                }
            }
            catch (Exception e)
            {
                LOG.Error(e);
            }
        }

        [DllExport("GetCommandParams", CallingConvention = CallingConvention.StdCall)]
        public static void GetCommandParams(Int64 ix, [In, Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder commandParams)
        {
            try
            {
                if (getInstance(ix).commandWaiting)
                {
                    commandParams.Append(getInstance(ix).getCommandParams());
                }
                else
                {
                    LOG.Error(Error.ERROR_NO_COMMAND.ToString());
                    commandParams.Append(Error.ERROR_NO_COMMAND.ToString());
                }
            }
            catch (Exception e)
            {
                LOG.Error(e);
            }

        }

        [DllExport("SetBoolCommandResponse", CallingConvention = CallingConvention.StdCall)]
        public static void SetBoolCommandResponse(Int64 ix, bool response, int error)
        {
            getInstance(ix).setCommandResponse(response, error);
        }

        [DllExport("SetDoubleCommandResponse", CallingConvention = CallingConvention.StdCall)]
        public static void SetDoubleCommandResponse(Int64 ix, double response, int error)
        {
            getInstance(ix).setCommandResponse(response, error);
        }

        [DllExport("SetIntCommandResponse", CallingConvention = CallingConvention.StdCall)]
        public static void SetIntCommandResponse(Int64 ix, int response, int error)
        {
            getInstance(ix).setCommandResponse(response, error);
        }

        [DllExport("SetStringCommandResponse", CallingConvention = CallingConvention.StdCall)]
        public static void SetStringCommandResponse(Int64 ix, [MarshalAs(UnmanagedType.LPWStr)] string response, int error)
        {
            getInstance(ix).setCommandResponse(response, error);
        }

        [DllExport("SetVoidCommandResponse", CallingConvention = CallingConvention.StdCall)]
        public static void SetVoidCommandResponse(Int64 ix, int error)
        {
            getInstance(ix).setCommandResponse(null, error);
        }

        [DllExport("SetLongCommandResponse", CallingConvention = CallingConvention.StdCall)]
        public static void SetLongCommandResponse(Int64 ix, long response, int error)
        {
            getInstance(ix).setCommandResponse(response, error);
        }

        [DllExport("SetDateTimeCommandResponse", CallingConvention = CallingConvention.StdCall)]
        public static void SetDateTimeCommandResponse(Int64 ix, Int64 response, int error)
        {
            getInstance(ix).setCommandResponse(DateUtil.FromUnixTime(response), error);
        }

        [DllExport("SetEnumCommandResponse", CallingConvention = CallingConvention.StdCall)]
        public static void SetEnumCommandResponse(Int64 ix, int response, int error)
        {
            getInstance(ix).setCommandResponse(response, error);
        }
    }
}



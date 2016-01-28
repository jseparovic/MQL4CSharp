using System;
using RGiesecke.DllExport;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using log4net;
using mqlsharp.Util;
using MQL4CSharp.Base.Enums;

namespace MQL4CSharp.Base.MQL
{
    public class MQLCommandManager
    {
        private static readonly ILog LOG = LogManager.GetLogger(typeof(MQLCommandManager));

        private static MQLCommandManager commandManager;

        public static MQLCommandManager getInstance()
        {
            if (commandManager == null)
            {
                commandManager = new MQLCommandManager();
            }
            return commandManager;
        }

        MQLCommand command;
        List<Object> parameters;
        Boolean commandWaiting;
        Object response;

        private readonly object syncLock = new object();

        static char DELIMITER = (char)29;


        private MQLCommandManager()
        {
            commandWaiting = false;
        }


        public void ExecCommand(MQLCommand command, List<Object> parameters)
        {
            this.command = command;
            this.parameters = parameters;
            this.commandWaiting = true;
        }

        public bool IsCommandRunning()
        {
            return MQLCommandManager.getInstance().commandWaiting;
        }

        public Object GetCommandResult()
        {
            return response;
        }


        [DllExport("IsCommandWaiting", CallingConvention = CallingConvention.StdCall)]
        public static bool IsCommandWaiting()
        {
            try
            {
                return MQLCommandManager.getInstance().commandWaiting;
            }
            catch (Exception e)
            {
                LOG.Error(e);
                return false;
            }
        }


        [DllExport("GetCommandId", CallingConvention = CallingConvention.StdCall)]
        public static int GetCommandId()
        {
            try
            {
                MQLCommandManager commandManager = MQLCommandManager.getInstance();

                if (commandManager.commandWaiting)
                {
                    return (int)commandManager.command;
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
        [return: MarshalAs(UnmanagedType.LPWStr)]
        public static string GetCommandName()
        {
            try
            {
                MQLCommandManager commandManager = MQLCommandManager.getInstance();

                if (commandManager.commandWaiting)
                {
                    return commandManager.command.ToString();
                }
                else
                {
                    LOG.Error(Error.ERROR_NO_COMMAND.ToString());
                    return Error.ERROR_NO_COMMAND.ToString();
                }
            }
            catch (Exception e)
            {
                LOG.Error(e);
                return Error.ERROR_UNHANDLED.ToString();
            }
        }

        [DllExport("GetCommandParams", CallingConvention = CallingConvention.StdCall)]
        [return: MarshalAs(UnmanagedType.LPWStr)]
        public static string GetCommandParams()
        {
            try
            {
                MQLCommandManager commandManager = MQLCommandManager.getInstance();

                if (commandManager.commandWaiting)
                {
                    List<Object> parameters = commandManager.parameters;

                    String returnCommand = "";
                    foreach (Object p in parameters)
                    {
                        Object param = p;
                        if (param is DateTime)
                        {
                            // Convert DateTime to MT4 String
                            param = DateUtil.ToMT4TimeString((DateTime) p);
                        }

                        if(returnCommand.Equals(""))
                        {
                            returnCommand = returnCommand + param;
                        }
                        else
                        {
                            returnCommand = returnCommand + DELIMITER + param;
                        }
                    }
                    return returnCommand;
                }
                else
                {
                    LOG.Error(Error.ERROR_NO_COMMAND.ToString());
                    return Error.ERROR_NO_COMMAND.ToString();
                }
            }
            catch(Exception e)
            {
                LOG.Error(e);
                return Error.ERROR_UNHANDLED.ToString();
            }
        }

        private void setCommandResponse(Object response, int error)
        {
            try
            {
                //LOG.Debug(String.Format("SetCommandResponse({0},{1})", response, error));
                this.response = response;
                this.commandWaiting = false;
            }
            catch (Exception e)
            {
                LOG.Error(e);
            }
        }

        [DllExport("SetBoolCommandResponse", CallingConvention = CallingConvention.StdCall)]
        public static void SetBoolCommandResponse(bool response, int error)
        {
            commandManager.setCommandResponse(response, error);
        }

        [DllExport("SetDoubleCommandResponse", CallingConvention = CallingConvention.StdCall)]
        public static void SetDoubleCommandResponse(double response, int error)
        {
            commandManager.setCommandResponse(response, error);
        }

        [DllExport("SetIntCommandResponse", CallingConvention = CallingConvention.StdCall)]
        public static void SetIntCommandResponse(int response, int error)
        {
            commandManager.setCommandResponse(response, error);
        }

        [DllExport("SetStringCommandResponse", CallingConvention = CallingConvention.StdCall)]
        public static void SetStringCommandResponse([In, Out, MarshalAs(UnmanagedType.LPWStr)] string response, int error)
        {
            commandManager.setCommandResponse(response, error);
        }

        [DllExport("SetVoidCommandResponse", CallingConvention = CallingConvention.StdCall)]
        public static void SetVoidCommandResponse(int error)
        {
            commandManager.setCommandResponse(null, error);
        }

        [DllExport("SetLongCommandResponse", CallingConvention = CallingConvention.StdCall)]
        public static void SetLongCommandResponse(long response, int error)
        {
            commandManager.setCommandResponse(response, error);
        }

        [DllExport("SetDateTimeCommandResponse", CallingConvention = CallingConvention.StdCall)]
        public static void SetDateTimeCommandResponse(Int64 response, int error)
        {
            commandManager.setCommandResponse(DateUtil.FromUnixTime(response), error);
        }

        [DllExport("SetEnumCommandResponse", CallingConvention = CallingConvention.StdCall)]
        public static void SetEnumCommandResponse(int response, int error)
        {
            commandManager.setCommandResponse(response, error);
        }
    }
}



using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using log4net;
using MQL4CSharp.Base.Enums;

namespace MQL4CSharp.Base.MQL
{
    public class MQLCommandRequest
    {
        private static readonly ILog LOG = LogManager.GetLogger(typeof(MQLCommandRequest));

        public MQLCommandRequest(int id, MQLCommand command, List<object> parameters, TaskCompletionSource<Object> taskCompletionSource = null)
        {
            LOG.DebugFormat("MQLCommandRequest: {0} {1}", id, command.ToString());
            ID = id;
            Command = command;
            Parameters = parameters;
            Error = 0;
            CommandWaiting = true;
            TaskCompletionSource = taskCompletionSource;
        }

        public int ID { get; private set; }
        public TaskCompletionSource<Object> TaskCompletionSource { get; private set; }
        public MQLCommand Command { get; private set; }
        public List<object> Parameters { get; private set; }
        public bool CommandWaiting { get; private set; }
        public object Response { get; private set; }
        public int Error { get; private set; }

        public override string ToString()
        {
            return $"Command: {Command}, Parameters: {Parameters}, CommandWaiting: {CommandWaiting}, Response: {Response}, Error: {Error}";
        }

        internal void Done(object response, int errorCode)
        {
            Response = response;
            Error = errorCode;
            CommandWaiting = false;
            TaskCompletionSource?.SetResult(response);
        }
    }

}

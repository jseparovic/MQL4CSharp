using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using MQL4CSharp.Base.Enums;

namespace MQL4CSharp.Base.MQL
{
    public class MQLCommandRequest
    {
        private static readonly ILog LOG = LogManager.GetLogger(typeof(MQLCommandRequest));

        private int id;
        private MQLCommand command;
        private List<Object> parameters;
        private Boolean commandWaiting;
        private Object response;
        private int error;

        public MQLCommandRequest(int id, MQLCommand command, List<object> parameters)
        {
            LOG.DebugFormat("MQLCommandRequest: {0} {1}", id, command.ToString());
            this.id = id;
            this.command = command;
            this.parameters = parameters;
            this.error = 0;
            this.commandWaiting = true;
        }

        public MQLCommand Command
        {
            get { return command; }
            set { command = value; }
        }

        public List<object> Parameters
        {
            get { return parameters; }
            set { parameters = value; }
        }

        public bool CommandWaiting
        {
            get { return commandWaiting; }
            set { commandWaiting = value; }
        }

        public object Response
        {
            get { return response; }
            set { response = value; }
        }

        public int Error
        {
            get { return error; }
            set { error = value; }
        }

        public override string ToString()
        {
            return $"Command: {Command}, Parameters: {Parameters}, CommandWaiting: {CommandWaiting}, Response: {Response}, Error: {Error}";
        }
    }

}

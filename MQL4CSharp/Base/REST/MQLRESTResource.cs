using System;
using System.Collections.Generic;
using System.Net;
using Grapevine;
using Grapevine.Server;
using log4net;
using MQL4CSharp.Base.Enums;
using MQL4CSharp.Base.MQL;
using Newtonsoft.Json.Linq;

namespace MQL4CSharp.Base.REST
{
    public sealed class MQLRESTResource : RESTResource
    {
        private static readonly ILog LOG = LogManager.GetLogger(typeof(MQLRESTResource));

        int DEFAULT_CHART_ID = 0;

        /// <summary>
        /// Function: Alert
        /// Description: Displays a message in a separate window.
        /// URL: http://mm.l/mql4/docs.mql4.com/common/alert.html
        /// </summary>
        /// <param name="argument"></param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/alert")]
        public void Handle_Alert_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, Alert_1(context, chartid));
        }

        /// <summary>
        /// Function: Alert
        /// Description: Displays a message in a separate window.
        /// URL: http://mm.l/mql4/docs.mql4.com/common/alert.html
        /// </summary>
        /// <param name="argument"></param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/alert")]
        public void Handle_Alert_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, Alert_1(context, DEFAULT_CHART_ID));
        }

        private JObject Alert_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            parameters.Add(payload["argument"]);
            int id = mqlCommandManager.ExecCommand(MQLCommand.Alert_1, parameters); // MQLCommand ENUM = 1
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = "";
            return result;
        }
        /// <summary>
        /// Function: Comment
        /// Description: This function outputs a comment defined by a user in the top left corner of a chart.
        /// URL: http://mm.l/mql4/docs.mql4.com/common/comment.html
        /// </summary>
        /// <param name="argument">[in] Any values, separated by commas. To delimit output information into several lines, a line break symbol "\n" or "\r\n" is used. Number of parameters cannot exceed 64. Total length of the input comment (including invisible symbols) cannot exceed 2045 characters (excess symbols will be cut out during output).</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/comment")]
        public void Handle_Comment_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, Comment_1(context, chartid));
        }

        /// <summary>
        /// Function: Comment
        /// Description: This function outputs a comment defined by a user in the top left corner of a chart.
        /// URL: http://mm.l/mql4/docs.mql4.com/common/comment.html
        /// </summary>
        /// <param name="argument">[in] Any values, separated by commas. To delimit output information into several lines, a line break symbol "\n" or "\r\n" is used. Number of parameters cannot exceed 64. Total length of the input comment (including invisible symbols) cannot exceed 2045 characters (excess symbols will be cut out during output).</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/comment")]
        public void Handle_Comment_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, Comment_1(context, DEFAULT_CHART_ID));
        }

        private JObject Comment_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            parameters.Add(payload["argument"]);
            int id = mqlCommandManager.ExecCommand(MQLCommand.Comment_1, parameters); // MQLCommand ENUM = 2
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = "";
            return result;
        }
        /// <summary>
        /// Function: SendFTP
        /// Description: Sends a file at the address, specified in the setting window of the "FTP" tab.
        /// URL: http://mm.l/mql4/docs.mql4.com/common/sendftp.html
        /// </summary>
        /// <param name="filename">[in] Name of sent file.</param>
        /// <param name="ftp_path">[in] FTP catalog. If a directory is not specified, directory described in settings is used.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/sendftp")]
        public void Handle_SendFTP_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, SendFTP_1(context, chartid));
        }

        /// <summary>
        /// Function: SendFTP
        /// Description: Sends a file at the address, specified in the setting window of the "FTP" tab.
        /// URL: http://mm.l/mql4/docs.mql4.com/common/sendftp.html
        /// </summary>
        /// <param name="filename">[in] Name of sent file.</param>
        /// <param name="ftp_path">[in] FTP catalog. If a directory is not specified, directory described in settings is used.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/sendftp")]
        public void Handle_SendFTP_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, SendFTP_1(context, DEFAULT_CHART_ID));
        }

        private JObject SendFTP_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            parameters.Add(payload["filename"]);
            parameters.Add(payload["ftp_path"]);
            int id = mqlCommandManager.ExecCommand(MQLCommand.SendFTP_1, parameters); // MQLCommand ENUM = 3
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = (bool)mqlCommandManager.GetCommandResult(id);
            return result;
        }
        /// <summary>
        /// Function: SendNotification
        /// Description: Sends push notifications to the mobile terminals, whose MetaQuotes IDs are specified in the "Notifications" tab.
        /// URL: http://mm.l/mql4/docs.mql4.com/common/sendnotification.html
        /// </summary>
        /// <param name="text">[in] The text of the notification. The message length should not exceed 255 characters.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/sendnotification")]
        public void Handle_SendNotification_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, SendNotification_1(context, chartid));
        }

        /// <summary>
        /// Function: SendNotification
        /// Description: Sends push notifications to the mobile terminals, whose MetaQuotes IDs are specified in the "Notifications" tab.
        /// URL: http://mm.l/mql4/docs.mql4.com/common/sendnotification.html
        /// </summary>
        /// <param name="text">[in] The text of the notification. The message length should not exceed 255 characters.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/sendnotification")]
        public void Handle_SendNotification_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, SendNotification_1(context, DEFAULT_CHART_ID));
        }

        private JObject SendNotification_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            parameters.Add(payload["text"]);
            int id = mqlCommandManager.ExecCommand(MQLCommand.SendNotification_1, parameters); // MQLCommand ENUM = 4
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = (bool)mqlCommandManager.GetCommandResult(id);
            return result;
        }
        /// <summary>
        /// Function: SendMail
        /// Description: Sends an email at the address specified in the settings window of the "Email" tab.
        /// URL: http://mm.l/mql4/docs.mql4.com/common/sendmail.html
        /// </summary>
        /// <param name="subject">[in] Email header.</param>
        /// <param name="some_text">[in] Email body.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/sendmail")]
        public void Handle_SendMail_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, SendMail_1(context, chartid));
        }

        /// <summary>
        /// Function: SendMail
        /// Description: Sends an email at the address specified in the settings window of the "Email" tab.
        /// URL: http://mm.l/mql4/docs.mql4.com/common/sendmail.html
        /// </summary>
        /// <param name="subject">[in] Email header.</param>
        /// <param name="some_text">[in] Email body.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/sendmail")]
        public void Handle_SendMail_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, SendMail_1(context, DEFAULT_CHART_ID));
        }

        private JObject SendMail_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            parameters.Add(payload["subject"]);
            parameters.Add(payload["some_text"]);
            int id = mqlCommandManager.ExecCommand(MQLCommand.SendMail_1, parameters); // MQLCommand ENUM = 5
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = (bool)mqlCommandManager.GetCommandResult(id);
            return result;
        }
        /// <summary>
        /// Function: AccountInfoDouble
        /// Description: Returns the value of the corresponding account property.
        /// URL: http://mm.l/mql4/docs.mql4.com/account/accountinfodouble.html
        /// </summary>
        /// <param name="property_id">[in] Identifier of the property. The value can be one of the values of .</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/accountinfodouble")]
        public void Handle_AccountInfoDouble_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, AccountInfoDouble_1(context, chartid));
        }

        /// <summary>
        /// Function: AccountInfoDouble
        /// Description: Returns the value of the corresponding account property.
        /// URL: http://mm.l/mql4/docs.mql4.com/account/accountinfodouble.html
        /// </summary>
        /// <param name="property_id">[in] Identifier of the property. The value can be one of the values of .</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/accountinfodouble")]
        public void Handle_AccountInfoDouble_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, AccountInfoDouble_1(context, DEFAULT_CHART_ID));
        }

        private JObject AccountInfoDouble_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            parameters.Add(payload["property_id"]);
            int id = mqlCommandManager.ExecCommand(MQLCommand.AccountInfoDouble_1, parameters); // MQLCommand ENUM = 6
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = Convert.ToDecimal(mqlCommandManager.GetCommandResult(id));
            return result;
        }
        /// <summary>
        /// Function: AccountInfoInteger
        /// Description: Returns the value of the properties of the account.
        /// URL: http://mm.l/mql4/docs.mql4.com/account/accountinfointeger.html
        /// </summary>
        /// <param name="property_id">[in] Identifier of the property. The value can be one of the values of .</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/accountinfointeger")]
        public void Handle_AccountInfoInteger_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, AccountInfoInteger_1(context, chartid));
        }

        /// <summary>
        /// Function: AccountInfoInteger
        /// Description: Returns the value of the properties of the account.
        /// URL: http://mm.l/mql4/docs.mql4.com/account/accountinfointeger.html
        /// </summary>
        /// <param name="property_id">[in] Identifier of the property. The value can be one of the values of .</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/accountinfointeger")]
        public void Handle_AccountInfoInteger_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, AccountInfoInteger_1(context, DEFAULT_CHART_ID));
        }

        private JObject AccountInfoInteger_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            parameters.Add(payload["property_id"]);
            int id = mqlCommandManager.ExecCommand(MQLCommand.AccountInfoInteger_1, parameters); // MQLCommand ENUM = 7
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = Convert.ToInt64(mqlCommandManager.GetCommandResult(id));
            return result;
        }
        /// <summary>
        /// Function: AccountInfoString
        /// Description: Returns the value of the corresponding account property.
        /// URL: http://mm.l/mql4/docs.mql4.com/account/accountinfostring.html
        /// </summary>
        /// <param name="property_id">[in] Identifier of the property. The value can be one of the values of .</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/accountinfostring")]
        public void Handle_AccountInfoString_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, AccountInfoString_1(context, chartid));
        }

        /// <summary>
        /// Function: AccountInfoString
        /// Description: Returns the value of the corresponding account property.
        /// URL: http://mm.l/mql4/docs.mql4.com/account/accountinfostring.html
        /// </summary>
        /// <param name="property_id">[in] Identifier of the property. The value can be one of the values of .</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/accountinfostring")]
        public void Handle_AccountInfoString_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, AccountInfoString_1(context, DEFAULT_CHART_ID));
        }

        private JObject AccountInfoString_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            parameters.Add(payload["property_id"]);
            int id = mqlCommandManager.ExecCommand(MQLCommand.AccountInfoString_1, parameters); // MQLCommand ENUM = 8
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = (string)mqlCommandManager.GetCommandResult(id);
            return result;
        }
        /// <summary>
        /// Function: AccountBalance
        /// Description: Returns balance value of the current account.
        /// URL: http://mm.l/mql4/docs.mql4.com/account/accountbalance.html
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/accountbalance")]
        public void Handle_AccountBalance_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, AccountBalance_1(context, chartid));
        }

        /// <summary>
        /// Function: AccountBalance
        /// Description: Returns balance value of the current account.
        /// URL: http://mm.l/mql4/docs.mql4.com/account/accountbalance.html
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/accountbalance")]
        public void Handle_AccountBalance_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, AccountBalance_1(context, DEFAULT_CHART_ID));
        }

        private JObject AccountBalance_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            int id = mqlCommandManager.ExecCommand(MQLCommand.AccountBalance_1, parameters); // MQLCommand ENUM = 9
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = Convert.ToDecimal(mqlCommandManager.GetCommandResult(id));
            return result;
        }
        /// <summary>
        /// Function: AccountCredit
        /// Description: Returns credit value of the current account.
        /// URL: http://mm.l/mql4/docs.mql4.com/account/accountcredit.html
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/accountcredit")]
        public void Handle_AccountCredit_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, AccountCredit_1(context, chartid));
        }

        /// <summary>
        /// Function: AccountCredit
        /// Description: Returns credit value of the current account.
        /// URL: http://mm.l/mql4/docs.mql4.com/account/accountcredit.html
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/accountcredit")]
        public void Handle_AccountCredit_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, AccountCredit_1(context, DEFAULT_CHART_ID));
        }

        private JObject AccountCredit_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            int id = mqlCommandManager.ExecCommand(MQLCommand.AccountCredit_1, parameters); // MQLCommand ENUM = 10
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = Convert.ToDecimal(mqlCommandManager.GetCommandResult(id));
            return result;
        }
        /// <summary>
        /// Function: AccountCompany
        /// Description: Returns the brokerage company name where the current account was registered.
        /// URL: http://mm.l/mql4/docs.mql4.com/account/accountcompany.html
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/accountcompany")]
        public void Handle_AccountCompany_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, AccountCompany_1(context, chartid));
        }

        /// <summary>
        /// Function: AccountCompany
        /// Description: Returns the brokerage company name where the current account was registered.
        /// URL: http://mm.l/mql4/docs.mql4.com/account/accountcompany.html
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/accountcompany")]
        public void Handle_AccountCompany_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, AccountCompany_1(context, DEFAULT_CHART_ID));
        }

        private JObject AccountCompany_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            int id = mqlCommandManager.ExecCommand(MQLCommand.AccountCompany_1, parameters); // MQLCommand ENUM = 11
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = (string)mqlCommandManager.GetCommandResult(id);
            return result;
        }
        /// <summary>
        /// Function: AccountCurrency
        /// Description: Returns currency name of the current account.
        /// URL: http://mm.l/mql4/docs.mql4.com/account/accountcurrency.html
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/accountcurrency")]
        public void Handle_AccountCurrency_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, AccountCurrency_1(context, chartid));
        }

        /// <summary>
        /// Function: AccountCurrency
        /// Description: Returns currency name of the current account.
        /// URL: http://mm.l/mql4/docs.mql4.com/account/accountcurrency.html
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/accountcurrency")]
        public void Handle_AccountCurrency_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, AccountCurrency_1(context, DEFAULT_CHART_ID));
        }

        private JObject AccountCurrency_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            int id = mqlCommandManager.ExecCommand(MQLCommand.AccountCurrency_1, parameters); // MQLCommand ENUM = 12
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = (string)mqlCommandManager.GetCommandResult(id);
            return result;
        }
        /// <summary>
        /// Function: AccountEquity
        /// Description: Returns equity value of the current account.
        /// URL: http://mm.l/mql4/docs.mql4.com/account/accountequity.html
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/accountequity")]
        public void Handle_AccountEquity_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, AccountEquity_1(context, chartid));
        }

        /// <summary>
        /// Function: AccountEquity
        /// Description: Returns equity value of the current account.
        /// URL: http://mm.l/mql4/docs.mql4.com/account/accountequity.html
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/accountequity")]
        public void Handle_AccountEquity_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, AccountEquity_1(context, DEFAULT_CHART_ID));
        }

        private JObject AccountEquity_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            int id = mqlCommandManager.ExecCommand(MQLCommand.AccountEquity_1, parameters); // MQLCommand ENUM = 13
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = Convert.ToDecimal(mqlCommandManager.GetCommandResult(id));
            return result;
        }
        /// <summary>
        /// Function: AccountFreeMargin
        /// Description: Returns free margin value of the current account.
        /// URL: http://mm.l/mql4/docs.mql4.com/account/accountfreemargin.html
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/accountfreemargin")]
        public void Handle_AccountFreeMargin_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, AccountFreeMargin_1(context, chartid));
        }

        /// <summary>
        /// Function: AccountFreeMargin
        /// Description: Returns free margin value of the current account.
        /// URL: http://mm.l/mql4/docs.mql4.com/account/accountfreemargin.html
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/accountfreemargin")]
        public void Handle_AccountFreeMargin_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, AccountFreeMargin_1(context, DEFAULT_CHART_ID));
        }

        private JObject AccountFreeMargin_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            int id = mqlCommandManager.ExecCommand(MQLCommand.AccountFreeMargin_1, parameters); // MQLCommand ENUM = 14
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = Convert.ToDecimal(mqlCommandManager.GetCommandResult(id));
            return result;
        }
        /// <summary>
        /// Function: AccountFreeMarginCheck
        /// Description: Returns free margin that remains after the specified order has been opened at the current price on the current account.
        /// URL: http://mm.l/mql4/docs.mql4.com/account/accountfreemargincheck.html
        /// </summary>
        /// <param name="symbol">[in] Symbol for trading operation.</param>
        /// <param name="cmd">[in] Operation type. It can be either OP_BUY or OP_SELL.</param>
        /// <param name="volume">[in] Number of lots.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/accountfreemargincheck")]
        public void Handle_AccountFreeMarginCheck_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, AccountFreeMarginCheck_1(context, chartid));
        }

        /// <summary>
        /// Function: AccountFreeMarginCheck
        /// Description: Returns free margin that remains after the specified order has been opened at the current price on the current account.
        /// URL: http://mm.l/mql4/docs.mql4.com/account/accountfreemargincheck.html
        /// </summary>
        /// <param name="symbol">[in] Symbol for trading operation.</param>
        /// <param name="cmd">[in] Operation type. It can be either OP_BUY or OP_SELL.</param>
        /// <param name="volume">[in] Number of lots.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/accountfreemargincheck")]
        public void Handle_AccountFreeMarginCheck_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, AccountFreeMarginCheck_1(context, DEFAULT_CHART_ID));
        }

        private JObject AccountFreeMarginCheck_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            parameters.Add(payload["symbol"]);
            parameters.Add(payload["cmd"]);
            parameters.Add(payload["volume"]);
            int id = mqlCommandManager.ExecCommand(MQLCommand.AccountFreeMarginCheck_1, parameters); // MQLCommand ENUM = 15
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = Convert.ToDecimal(mqlCommandManager.GetCommandResult(id));
            return result;
        }
        /// <summary>
        /// Function: AccountFreeMarginMode
        /// Description: Returns the calculation mode of free margin allowed to open orders on the current account.
        /// URL: http://mm.l/mql4/docs.mql4.com/account/accountfreemarginmode.html
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/accountfreemarginmode")]
        public void Handle_AccountFreeMarginMode_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, AccountFreeMarginMode_1(context, chartid));
        }

        /// <summary>
        /// Function: AccountFreeMarginMode
        /// Description: Returns the calculation mode of free margin allowed to open orders on the current account.
        /// URL: http://mm.l/mql4/docs.mql4.com/account/accountfreemarginmode.html
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/accountfreemarginmode")]
        public void Handle_AccountFreeMarginMode_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, AccountFreeMarginMode_1(context, DEFAULT_CHART_ID));
        }

        private JObject AccountFreeMarginMode_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            int id = mqlCommandManager.ExecCommand(MQLCommand.AccountFreeMarginMode_1, parameters); // MQLCommand ENUM = 16
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = Convert.ToDecimal(mqlCommandManager.GetCommandResult(id));
            return result;
        }
        /// <summary>
        /// Function: AccountLeverage
        /// Description: Returns leverage of the current account.
        /// URL: http://mm.l/mql4/docs.mql4.com/account/accountleverage.html
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/accountleverage")]
        public void Handle_AccountLeverage_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, AccountLeverage_1(context, chartid));
        }

        /// <summary>
        /// Function: AccountLeverage
        /// Description: Returns leverage of the current account.
        /// URL: http://mm.l/mql4/docs.mql4.com/account/accountleverage.html
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/accountleverage")]
        public void Handle_AccountLeverage_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, AccountLeverage_1(context, DEFAULT_CHART_ID));
        }

        private JObject AccountLeverage_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            int id = mqlCommandManager.ExecCommand(MQLCommand.AccountLeverage_1, parameters); // MQLCommand ENUM = 17
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = Convert.ToInt32(mqlCommandManager.GetCommandResult(id));
            return result;
        }
        /// <summary>
        /// Function: AccountMargin
        /// Description: Returns margin value of the current account.
        /// URL: http://mm.l/mql4/docs.mql4.com/account/accountmargin.html
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/accountmargin")]
        public void Handle_AccountMargin_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, AccountMargin_1(context, chartid));
        }

        /// <summary>
        /// Function: AccountMargin
        /// Description: Returns margin value of the current account.
        /// URL: http://mm.l/mql4/docs.mql4.com/account/accountmargin.html
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/accountmargin")]
        public void Handle_AccountMargin_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, AccountMargin_1(context, DEFAULT_CHART_ID));
        }

        private JObject AccountMargin_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            int id = mqlCommandManager.ExecCommand(MQLCommand.AccountMargin_1, parameters); // MQLCommand ENUM = 18
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = Convert.ToDecimal(mqlCommandManager.GetCommandResult(id));
            return result;
        }
        /// <summary>
        /// Function: AccountName
        /// Description: Returns the current account name.
        /// URL: http://mm.l/mql4/docs.mql4.com/account/accountname.html
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/accountname")]
        public void Handle_AccountName_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, AccountName_1(context, chartid));
        }

        /// <summary>
        /// Function: AccountName
        /// Description: Returns the current account name.
        /// URL: http://mm.l/mql4/docs.mql4.com/account/accountname.html
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/accountname")]
        public void Handle_AccountName_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, AccountName_1(context, DEFAULT_CHART_ID));
        }

        private JObject AccountName_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            int id = mqlCommandManager.ExecCommand(MQLCommand.AccountName_1, parameters); // MQLCommand ENUM = 19
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = (string)mqlCommandManager.GetCommandResult(id);
            return result;
        }
        /// <summary>
        /// Function: AccountNumber
        /// Description: Returns the current account number.
        /// URL: http://mm.l/mql4/docs.mql4.com/account/accountnumber.html
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/accountnumber")]
        public void Handle_AccountNumber_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, AccountNumber_1(context, chartid));
        }

        /// <summary>
        /// Function: AccountNumber
        /// Description: Returns the current account number.
        /// URL: http://mm.l/mql4/docs.mql4.com/account/accountnumber.html
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/accountnumber")]
        public void Handle_AccountNumber_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, AccountNumber_1(context, DEFAULT_CHART_ID));
        }

        private JObject AccountNumber_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            int id = mqlCommandManager.ExecCommand(MQLCommand.AccountNumber_1, parameters); // MQLCommand ENUM = 20
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = Convert.ToInt32(mqlCommandManager.GetCommandResult(id));
            return result;
        }
        /// <summary>
        /// Function: AccountProfit
        /// Description: Returns profit value of the current account.
        /// URL: http://mm.l/mql4/docs.mql4.com/account/accountprofit.html
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/accountprofit")]
        public void Handle_AccountProfit_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, AccountProfit_1(context, chartid));
        }

        /// <summary>
        /// Function: AccountProfit
        /// Description: Returns profit value of the current account.
        /// URL: http://mm.l/mql4/docs.mql4.com/account/accountprofit.html
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/accountprofit")]
        public void Handle_AccountProfit_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, AccountProfit_1(context, DEFAULT_CHART_ID));
        }

        private JObject AccountProfit_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            int id = mqlCommandManager.ExecCommand(MQLCommand.AccountProfit_1, parameters); // MQLCommand ENUM = 21
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = Convert.ToDecimal(mqlCommandManager.GetCommandResult(id));
            return result;
        }
        /// <summary>
        /// Function: AccountServer
        /// Description: Returns the connected server name.
        /// URL: http://mm.l/mql4/docs.mql4.com/account/accountserver.html
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/accountserver")]
        public void Handle_AccountServer_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, AccountServer_1(context, chartid));
        }

        /// <summary>
        /// Function: AccountServer
        /// Description: Returns the connected server name.
        /// URL: http://mm.l/mql4/docs.mql4.com/account/accountserver.html
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/accountserver")]
        public void Handle_AccountServer_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, AccountServer_1(context, DEFAULT_CHART_ID));
        }

        private JObject AccountServer_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            int id = mqlCommandManager.ExecCommand(MQLCommand.AccountServer_1, parameters); // MQLCommand ENUM = 22
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = (string)mqlCommandManager.GetCommandResult(id);
            return result;
        }
        /// <summary>
        /// Function: AccountStopoutLevel
        /// Description: Returns the value of the Stop Out level.
        /// URL: http://mm.l/mql4/docs.mql4.com/account/accountstopoutlevel.html
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/accountstopoutlevel")]
        public void Handle_AccountStopoutLevel_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, AccountStopoutLevel_1(context, chartid));
        }

        /// <summary>
        /// Function: AccountStopoutLevel
        /// Description: Returns the value of the Stop Out level.
        /// URL: http://mm.l/mql4/docs.mql4.com/account/accountstopoutlevel.html
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/accountstopoutlevel")]
        public void Handle_AccountStopoutLevel_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, AccountStopoutLevel_1(context, DEFAULT_CHART_ID));
        }

        private JObject AccountStopoutLevel_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            int id = mqlCommandManager.ExecCommand(MQLCommand.AccountStopoutLevel_1, parameters); // MQLCommand ENUM = 23
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = Convert.ToInt32(mqlCommandManager.GetCommandResult(id));
            return result;
        }
        /// <summary>
        /// Function: AccountStopoutMode
        /// Description: Returns the calculation mode for the Stop Out level.
        /// URL: http://mm.l/mql4/docs.mql4.com/account/accountstopoutmode.html
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/accountstopoutmode")]
        public void Handle_AccountStopoutMode_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, AccountStopoutMode_1(context, chartid));
        }

        /// <summary>
        /// Function: AccountStopoutMode
        /// Description: Returns the calculation mode for the Stop Out level.
        /// URL: http://mm.l/mql4/docs.mql4.com/account/accountstopoutmode.html
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/accountstopoutmode")]
        public void Handle_AccountStopoutMode_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, AccountStopoutMode_1(context, DEFAULT_CHART_ID));
        }

        private JObject AccountStopoutMode_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            int id = mqlCommandManager.ExecCommand(MQLCommand.AccountStopoutMode_1, parameters); // MQLCommand ENUM = 24
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = Convert.ToInt32(mqlCommandManager.GetCommandResult(id));
            return result;
        }
        /// <summary>
        /// Function: GetLastError
        /// Description: Returns the contents of the
        /// URL: http://mm.l/mql4/docs.mql4.com/check/getlasterror.html
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/getlasterror")]
        public void Handle_GetLastError_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, GetLastError_1(context, chartid));
        }

        /// <summary>
        /// Function: GetLastError
        /// Description: Returns the contents of the
        /// URL: http://mm.l/mql4/docs.mql4.com/check/getlasterror.html
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/getlasterror")]
        public void Handle_GetLastError_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, GetLastError_1(context, DEFAULT_CHART_ID));
        }

        private JObject GetLastError_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            int id = mqlCommandManager.ExecCommand(MQLCommand.GetLastError_1, parameters); // MQLCommand ENUM = 25
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = Convert.ToInt32(mqlCommandManager.GetCommandResult(id));
            return result;
        }
        /// <summary>
        /// Function: IsStopped
        /// Description: Checks the forced shutdown of an mql4 program.
        /// URL: http://mm.l/mql4/docs.mql4.com/check/isstopped.html
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/isstopped")]
        public void Handle_IsStopped_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, IsStopped_1(context, chartid));
        }

        /// <summary>
        /// Function: IsStopped
        /// Description: Checks the forced shutdown of an mql4 program.
        /// URL: http://mm.l/mql4/docs.mql4.com/check/isstopped.html
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/isstopped")]
        public void Handle_IsStopped_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, IsStopped_1(context, DEFAULT_CHART_ID));
        }

        private JObject IsStopped_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            int id = mqlCommandManager.ExecCommand(MQLCommand.IsStopped_1, parameters); // MQLCommand ENUM = 26
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = (bool)mqlCommandManager.GetCommandResult(id);
            return result;
        }
        /// <summary>
        /// Function: UninitializeReason
        /// Description: Returns the code of a
        /// URL: http://mm.l/mql4/docs.mql4.com/check/uninitializereason.html
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/uninitializereason")]
        public void Handle_UninitializeReason_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, UninitializeReason_1(context, chartid));
        }

        /// <summary>
        /// Function: UninitializeReason
        /// Description: Returns the code of a
        /// URL: http://mm.l/mql4/docs.mql4.com/check/uninitializereason.html
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/uninitializereason")]
        public void Handle_UninitializeReason_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, UninitializeReason_1(context, DEFAULT_CHART_ID));
        }

        private JObject UninitializeReason_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            int id = mqlCommandManager.ExecCommand(MQLCommand.UninitializeReason_1, parameters); // MQLCommand ENUM = 27
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = Convert.ToInt32(mqlCommandManager.GetCommandResult(id));
            return result;
        }
        /// <summary>
        /// Function: MQLInfoInteger
        /// Description: Returns the value of a corresponding property of a running mql4 program.
        /// URL: http://mm.l/mql4/docs.mql4.com/check/mqlinfointeger.html
        /// </summary>
        /// <param name="property_id">[in] Identifier of a property. Can be one of values of the enumeration.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/mqlinfointeger")]
        public void Handle_MQLInfoInteger_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, MQLInfoInteger_1(context, chartid));
        }

        /// <summary>
        /// Function: MQLInfoInteger
        /// Description: Returns the value of a corresponding property of a running mql4 program.
        /// URL: http://mm.l/mql4/docs.mql4.com/check/mqlinfointeger.html
        /// </summary>
        /// <param name="property_id">[in] Identifier of a property. Can be one of values of the enumeration.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/mqlinfointeger")]
        public void Handle_MQLInfoInteger_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, MQLInfoInteger_1(context, DEFAULT_CHART_ID));
        }

        private JObject MQLInfoInteger_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            parameters.Add(payload["property_id"]);
            int id = mqlCommandManager.ExecCommand(MQLCommand.MQLInfoInteger_1, parameters); // MQLCommand ENUM = 28
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = Convert.ToInt32(mqlCommandManager.GetCommandResult(id));
            return result;
        }
        /// <summary>
        /// Function: MQLInfoString
        /// Description: Returns the value of a corresponding property of a running MQL4 program.
        /// URL: http://mm.l/mql4/docs.mql4.com/check/mqlinfostring.html
        /// </summary>
        /// <param name="property_id">[in] Identifier of a property. Can be one of the enumeration.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/mqlinfostring")]
        public void Handle_MQLInfoString_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, MQLInfoString_1(context, chartid));
        }

        /// <summary>
        /// Function: MQLInfoString
        /// Description: Returns the value of a corresponding property of a running MQL4 program.
        /// URL: http://mm.l/mql4/docs.mql4.com/check/mqlinfostring.html
        /// </summary>
        /// <param name="property_id">[in] Identifier of a property. Can be one of the enumeration.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/mqlinfostring")]
        public void Handle_MQLInfoString_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, MQLInfoString_1(context, DEFAULT_CHART_ID));
        }

        private JObject MQLInfoString_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            parameters.Add(payload["property_id"]);
            int id = mqlCommandManager.ExecCommand(MQLCommand.MQLInfoString_1, parameters); // MQLCommand ENUM = 29
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = (string)mqlCommandManager.GetCommandResult(id);
            return result;
        }
        /// <summary>
        /// Function: MQLSetInteger
        /// Description: Sets the value of the
        /// URL: http://mm.l/mql4/docs.mql4.com/check/mqlsetinteger.html
        /// </summary>
        /// <param name="property_id">[in] Identifier of a property. Only is supported, as other properties cannot be changed.</param>
        /// <param name="property_value">[in] Value of property. Can be one of the .</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/mqlsetinteger")]
        public void Handle_MQLSetInteger_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, MQLSetInteger_1(context, chartid));
        }

        /// <summary>
        /// Function: MQLSetInteger
        /// Description: Sets the value of the
        /// URL: http://mm.l/mql4/docs.mql4.com/check/mqlsetinteger.html
        /// </summary>
        /// <param name="property_id">[in] Identifier of a property. Only is supported, as other properties cannot be changed.</param>
        /// <param name="property_value">[in] Value of property. Can be one of the .</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/mqlsetinteger")]
        public void Handle_MQLSetInteger_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, MQLSetInteger_1(context, DEFAULT_CHART_ID));
        }

        private JObject MQLSetInteger_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            parameters.Add(payload["property_id"]);
            parameters.Add(payload["property_value"]);
            int id = mqlCommandManager.ExecCommand(MQLCommand.MQLSetInteger_1, parameters); // MQLCommand ENUM = 30
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = "";
            return result;
        }
        /// <summary>
        /// Function: TerminalInfoInteger
        /// Description: Returns the value of a corresponding property of the mql4 program environment.
        /// URL: http://mm.l/mql4/docs.mql4.com/check/terminalinfointeger.html
        /// </summary>
        /// <param name="property_id">[in] Identifier of a property. Can be one of the values of the enumeration.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/terminalinfointeger")]
        public void Handle_TerminalInfoInteger_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, TerminalInfoInteger_1(context, chartid));
        }

        /// <summary>
        /// Function: TerminalInfoInteger
        /// Description: Returns the value of a corresponding property of the mql4 program environment.
        /// URL: http://mm.l/mql4/docs.mql4.com/check/terminalinfointeger.html
        /// </summary>
        /// <param name="property_id">[in] Identifier of a property. Can be one of the values of the enumeration.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/terminalinfointeger")]
        public void Handle_TerminalInfoInteger_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, TerminalInfoInteger_1(context, DEFAULT_CHART_ID));
        }

        private JObject TerminalInfoInteger_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            parameters.Add(payload["property_id"]);
            int id = mqlCommandManager.ExecCommand(MQLCommand.TerminalInfoInteger_1, parameters); // MQLCommand ENUM = 31
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = Convert.ToInt32(mqlCommandManager.GetCommandResult(id));
            return result;
        }
        /// <summary>
        /// Function: TerminalInfoDouble
        /// Description: Returns the value of a corresponding property of the mql4 program environment.
        /// URL: http://mm.l/mql4/docs.mql4.com/check/terminalinfodouble.html
        /// </summary>
        /// <param name="property_id">[in] Identifier of a property. Can be one of the values of the enumeration.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/terminalinfodouble")]
        public void Handle_TerminalInfoDouble_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, TerminalInfoDouble_1(context, chartid));
        }

        /// <summary>
        /// Function: TerminalInfoDouble
        /// Description: Returns the value of a corresponding property of the mql4 program environment.
        /// URL: http://mm.l/mql4/docs.mql4.com/check/terminalinfodouble.html
        /// </summary>
        /// <param name="property_id">[in] Identifier of a property. Can be one of the values of the enumeration.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/terminalinfodouble")]
        public void Handle_TerminalInfoDouble_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, TerminalInfoDouble_1(context, DEFAULT_CHART_ID));
        }

        private JObject TerminalInfoDouble_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            parameters.Add(payload["property_id"]);
            int id = mqlCommandManager.ExecCommand(MQLCommand.TerminalInfoDouble_1, parameters); // MQLCommand ENUM = 32
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = Convert.ToDecimal(mqlCommandManager.GetCommandResult(id));
            return result;
        }
        /// <summary>
        /// Function: TerminalInfoString
        /// Description: Returns the value of a corresponding property of the mql4 program environment. The property must be of string type.
        /// URL: http://mm.l/mql4/docs.mql4.com/check/terminalinfostring.html
        /// </summary>
        /// <param name="property_id">[in] Identifier of a property. Can be one of the values of the enumeration.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/terminalinfostring")]
        public void Handle_TerminalInfoString_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, TerminalInfoString_1(context, chartid));
        }

        /// <summary>
        /// Function: TerminalInfoString
        /// Description: Returns the value of a corresponding property of the mql4 program environment. The property must be of string type.
        /// URL: http://mm.l/mql4/docs.mql4.com/check/terminalinfostring.html
        /// </summary>
        /// <param name="property_id">[in] Identifier of a property. Can be one of the values of the enumeration.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/terminalinfostring")]
        public void Handle_TerminalInfoString_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, TerminalInfoString_1(context, DEFAULT_CHART_ID));
        }

        private JObject TerminalInfoString_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            parameters.Add(payload["property_id"]);
            int id = mqlCommandManager.ExecCommand(MQLCommand.TerminalInfoString_1, parameters); // MQLCommand ENUM = 33
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = (string)mqlCommandManager.GetCommandResult(id);
            return result;
        }
        /// <summary>
        /// Function: Symbol
        /// Description: Returns the name of a symbol of the current chart.
        /// URL: http://mm.l/mql4/docs.mql4.com/check/symbol.html
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/symbol")]
        public void Handle_Symbol_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, Symbol_1(context, chartid));
        }

        /// <summary>
        /// Function: Symbol
        /// Description: Returns the name of a symbol of the current chart.
        /// URL: http://mm.l/mql4/docs.mql4.com/check/symbol.html
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/symbol")]
        public void Handle_Symbol_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, Symbol_1(context, DEFAULT_CHART_ID));
        }

        private JObject Symbol_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            int id = mqlCommandManager.ExecCommand(MQLCommand.Symbol_1, parameters); // MQLCommand ENUM = 34
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = (string)mqlCommandManager.GetCommandResult(id);
            return result;
        }
        /// <summary>
        /// Function: Period
        /// Description: Returns the current chart timeframe.
        /// URL: http://mm.l/mql4/docs.mql4.com/check/period.html
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/period")]
        public void Handle_Period_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, Period_1(context, chartid));
        }

        /// <summary>
        /// Function: Period
        /// Description: Returns the current chart timeframe.
        /// URL: http://mm.l/mql4/docs.mql4.com/check/period.html
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/period")]
        public void Handle_Period_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, Period_1(context, DEFAULT_CHART_ID));
        }

        private JObject Period_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            int id = mqlCommandManager.ExecCommand(MQLCommand.Period_1, parameters); // MQLCommand ENUM = 35
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = Convert.ToInt32(mqlCommandManager.GetCommandResult(id));
            return result;
        }
        /// <summary>
        /// Function: Digits
        /// Description: Returns the number of decimal digits determining the accuracy of price of the current chart symbol.
        /// URL: http://mm.l/mql4/docs.mql4.com/check/digits.html
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/digits")]
        public void Handle_Digits_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, Digits_1(context, chartid));
        }

        /// <summary>
        /// Function: Digits
        /// Description: Returns the number of decimal digits determining the accuracy of price of the current chart symbol.
        /// URL: http://mm.l/mql4/docs.mql4.com/check/digits.html
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/digits")]
        public void Handle_Digits_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, Digits_1(context, DEFAULT_CHART_ID));
        }

        private JObject Digits_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            int id = mqlCommandManager.ExecCommand(MQLCommand.Digits_1, parameters); // MQLCommand ENUM = 36
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = Convert.ToInt32(mqlCommandManager.GetCommandResult(id));
            return result;
        }
        /// <summary>
        /// Function: Point
        /// Description: Returns the point size of the current symbol in the quote currency.
        /// URL: http://mm.l/mql4/docs.mql4.com/check/point.html
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/point")]
        public void Handle_Point_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, Point_1(context, chartid));
        }

        /// <summary>
        /// Function: Point
        /// Description: Returns the point size of the current symbol in the quote currency.
        /// URL: http://mm.l/mql4/docs.mql4.com/check/point.html
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/point")]
        public void Handle_Point_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, Point_1(context, DEFAULT_CHART_ID));
        }

        private JObject Point_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            int id = mqlCommandManager.ExecCommand(MQLCommand.Point_1, parameters); // MQLCommand ENUM = 37
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = Convert.ToDecimal(mqlCommandManager.GetCommandResult(id));
            return result;
        }
        /// <summary>
        /// Function: IsConnected
        /// Description: Checks connection between client terminal and server.
        /// URL: http://mm.l/mql4/docs.mql4.com/check/isconnected.html
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/isconnected")]
        public void Handle_IsConnected_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, IsConnected_1(context, chartid));
        }

        /// <summary>
        /// Function: IsConnected
        /// Description: Checks connection between client terminal and server.
        /// URL: http://mm.l/mql4/docs.mql4.com/check/isconnected.html
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/isconnected")]
        public void Handle_IsConnected_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, IsConnected_1(context, DEFAULT_CHART_ID));
        }

        private JObject IsConnected_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            int id = mqlCommandManager.ExecCommand(MQLCommand.IsConnected_1, parameters); // MQLCommand ENUM = 38
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = (bool)mqlCommandManager.GetCommandResult(id);
            return result;
        }
        /// <summary>
        /// Function: IsDemo
        /// Description: Checks if the Expert Advisor runs on a demo account.
        /// URL: http://mm.l/mql4/docs.mql4.com/check/isdemo.html
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/isdemo")]
        public void Handle_IsDemo_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, IsDemo_1(context, chartid));
        }

        /// <summary>
        /// Function: IsDemo
        /// Description: Checks if the Expert Advisor runs on a demo account.
        /// URL: http://mm.l/mql4/docs.mql4.com/check/isdemo.html
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/isdemo")]
        public void Handle_IsDemo_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, IsDemo_1(context, DEFAULT_CHART_ID));
        }

        private JObject IsDemo_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            int id = mqlCommandManager.ExecCommand(MQLCommand.IsDemo_1, parameters); // MQLCommand ENUM = 39
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = (bool)mqlCommandManager.GetCommandResult(id);
            return result;
        }
        /// <summary>
        /// Function: IsDllsAllowed
        /// Description: Checks if the DLL function call is allowed for the Expert Advisor.
        /// URL: http://mm.l/mql4/docs.mql4.com/check/isdllsallowed.html
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/isdllsallowed")]
        public void Handle_IsDllsAllowed_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, IsDllsAllowed_1(context, chartid));
        }

        /// <summary>
        /// Function: IsDllsAllowed
        /// Description: Checks if the DLL function call is allowed for the Expert Advisor.
        /// URL: http://mm.l/mql4/docs.mql4.com/check/isdllsallowed.html
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/isdllsallowed")]
        public void Handle_IsDllsAllowed_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, IsDllsAllowed_1(context, DEFAULT_CHART_ID));
        }

        private JObject IsDllsAllowed_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            int id = mqlCommandManager.ExecCommand(MQLCommand.IsDllsAllowed_1, parameters); // MQLCommand ENUM = 40
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = (bool)mqlCommandManager.GetCommandResult(id);
            return result;
        }
        /// <summary>
        /// Function: IsExpertEnabled
        /// Description: Checks if Expert Advisors are enabled for running.
        /// URL: http://mm.l/mql4/docs.mql4.com/check/isexpertenabled.html
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/isexpertenabled")]
        public void Handle_IsExpertEnabled_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, IsExpertEnabled_1(context, chartid));
        }

        /// <summary>
        /// Function: IsExpertEnabled
        /// Description: Checks if Expert Advisors are enabled for running.
        /// URL: http://mm.l/mql4/docs.mql4.com/check/isexpertenabled.html
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/isexpertenabled")]
        public void Handle_IsExpertEnabled_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, IsExpertEnabled_1(context, DEFAULT_CHART_ID));
        }

        private JObject IsExpertEnabled_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            int id = mqlCommandManager.ExecCommand(MQLCommand.IsExpertEnabled_1, parameters); // MQLCommand ENUM = 41
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = (bool)mqlCommandManager.GetCommandResult(id);
            return result;
        }
        /// <summary>
        /// Function: IsLibrariesAllowed
        /// Description: Checks if the Expert Advisor can call library function.
        /// URL: http://mm.l/mql4/docs.mql4.com/check/islibrariesallowed.html
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/islibrariesallowed")]
        public void Handle_IsLibrariesAllowed_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, IsLibrariesAllowed_1(context, chartid));
        }

        /// <summary>
        /// Function: IsLibrariesAllowed
        /// Description: Checks if the Expert Advisor can call library function.
        /// URL: http://mm.l/mql4/docs.mql4.com/check/islibrariesallowed.html
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/islibrariesallowed")]
        public void Handle_IsLibrariesAllowed_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, IsLibrariesAllowed_1(context, DEFAULT_CHART_ID));
        }

        private JObject IsLibrariesAllowed_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            int id = mqlCommandManager.ExecCommand(MQLCommand.IsLibrariesAllowed_1, parameters); // MQLCommand ENUM = 42
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = (bool)mqlCommandManager.GetCommandResult(id);
            return result;
        }
        /// <summary>
        /// Function: IsOptimization
        /// Description: Checks if Expert Advisor runs in the Strategy Tester optimization mode.
        /// URL: http://mm.l/mql4/docs.mql4.com/check/isoptimization.html
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/isoptimization")]
        public void Handle_IsOptimization_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, IsOptimization_1(context, chartid));
        }

        /// <summary>
        /// Function: IsOptimization
        /// Description: Checks if Expert Advisor runs in the Strategy Tester optimization mode.
        /// URL: http://mm.l/mql4/docs.mql4.com/check/isoptimization.html
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/isoptimization")]
        public void Handle_IsOptimization_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, IsOptimization_1(context, DEFAULT_CHART_ID));
        }

        private JObject IsOptimization_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            int id = mqlCommandManager.ExecCommand(MQLCommand.IsOptimization_1, parameters); // MQLCommand ENUM = 43
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = (bool)mqlCommandManager.GetCommandResult(id);
            return result;
        }
        /// <summary>
        /// Function: IsTesting
        /// Description: Checks
        /// URL: http://mm.l/mql4/docs.mql4.com/check/istesting.html
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/istesting")]
        public void Handle_IsTesting_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, IsTesting_1(context, chartid));
        }

        /// <summary>
        /// Function: IsTesting
        /// Description: Checks
        /// URL: http://mm.l/mql4/docs.mql4.com/check/istesting.html
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/istesting")]
        public void Handle_IsTesting_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, IsTesting_1(context, DEFAULT_CHART_ID));
        }

        private JObject IsTesting_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            int id = mqlCommandManager.ExecCommand(MQLCommand.IsTesting_1, parameters); // MQLCommand ENUM = 44
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = (bool)mqlCommandManager.GetCommandResult(id);
            return result;
        }
        /// <summary>
        /// Function: IsTradeAllowed
        /// Description: Checks
        /// URL: http://mm.l/mql4/docs.mql4.com/check/istradeallowed.html
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/istradeallowed")]
        public void Handle_IsTradeAllowed_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, IsTradeAllowed_1(context, chartid));
        }

        /// <summary>
        /// Function: IsTradeAllowed
        /// Description: Checks
        /// URL: http://mm.l/mql4/docs.mql4.com/check/istradeallowed.html
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/istradeallowed")]
        public void Handle_IsTradeAllowed_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, IsTradeAllowed_1(context, DEFAULT_CHART_ID));
        }

        private JObject IsTradeAllowed_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            int id = mqlCommandManager.ExecCommand(MQLCommand.IsTradeAllowed_1, parameters); // MQLCommand ENUM = 45
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = (bool)mqlCommandManager.GetCommandResult(id);
            return result;
        }
        /// <summary>
        /// Function: IsTradeAllowed
        /// Description: Checks
        /// URL: http://mm.l/mql4/docs.mql4.com/check/istradeallowed.html
        /// </summary>
        /// <param name="symbol">[in] Symbol.</param>
        /// <param name="tested_time">[in] Time to check status.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/istradeallowed")]
        public void Handle_IsTradeAllowed_2(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, IsTradeAllowed_2(context, chartid));
        }

        /// <summary>
        /// Function: IsTradeAllowed
        /// Description: Checks
        /// URL: http://mm.l/mql4/docs.mql4.com/check/istradeallowed.html
        /// </summary>
        /// <param name="symbol">[in] Symbol.</param>
        /// <param name="tested_time">[in] Time to check status.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/istradeallowed")]
        public void Handle_IsTradeAllowed_2_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, IsTradeAllowed_2(context, DEFAULT_CHART_ID));
        }

        private JObject IsTradeAllowed_2(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            parameters.Add(payload["symbol"]);
            parameters.Add(payload["tested_time"]);
            int id = mqlCommandManager.ExecCommand(MQLCommand.IsTradeAllowed_2, parameters); // MQLCommand ENUM = 45
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = (bool)mqlCommandManager.GetCommandResult(id);
            return result;
        }
        /// <summary>
        /// Function: IsTradeContextBusy
        /// Description: Returns the information about trade context.
        /// URL: http://mm.l/mql4/docs.mql4.com/check/istradecontextbusy.html
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/istradecontextbusy")]
        public void Handle_IsTradeContextBusy_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, IsTradeContextBusy_1(context, chartid));
        }

        /// <summary>
        /// Function: IsTradeContextBusy
        /// Description: Returns the information about trade context.
        /// URL: http://mm.l/mql4/docs.mql4.com/check/istradecontextbusy.html
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/istradecontextbusy")]
        public void Handle_IsTradeContextBusy_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, IsTradeContextBusy_1(context, DEFAULT_CHART_ID));
        }

        private JObject IsTradeContextBusy_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            int id = mqlCommandManager.ExecCommand(MQLCommand.IsTradeContextBusy_1, parameters); // MQLCommand ENUM = 46
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = (bool)mqlCommandManager.GetCommandResult(id);
            return result;
        }
        /// <summary>
        /// Function: IsVisualMode
        /// Description: Checks
        /// URL: http://mm.l/mql4/docs.mql4.com/check/isvisualmode.html
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/isvisualmode")]
        public void Handle_IsVisualMode_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, IsVisualMode_1(context, chartid));
        }

        /// <summary>
        /// Function: IsVisualMode
        /// Description: Checks
        /// URL: http://mm.l/mql4/docs.mql4.com/check/isvisualmode.html
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/isvisualmode")]
        public void Handle_IsVisualMode_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, IsVisualMode_1(context, DEFAULT_CHART_ID));
        }

        private JObject IsVisualMode_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            int id = mqlCommandManager.ExecCommand(MQLCommand.IsVisualMode_1, parameters); // MQLCommand ENUM = 47
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = (bool)mqlCommandManager.GetCommandResult(id);
            return result;
        }
        /// <summary>
        /// Function: TerminalCompany
        /// Description: Returns the name of company owning the client terminal.
        /// URL: http://mm.l/mql4/docs.mql4.com/check/terminalcompany.html
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/terminalcompany")]
        public void Handle_TerminalCompany_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, TerminalCompany_1(context, chartid));
        }

        /// <summary>
        /// Function: TerminalCompany
        /// Description: Returns the name of company owning the client terminal.
        /// URL: http://mm.l/mql4/docs.mql4.com/check/terminalcompany.html
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/terminalcompany")]
        public void Handle_TerminalCompany_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, TerminalCompany_1(context, DEFAULT_CHART_ID));
        }

        private JObject TerminalCompany_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            int id = mqlCommandManager.ExecCommand(MQLCommand.TerminalCompany_1, parameters); // MQLCommand ENUM = 48
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = (string)mqlCommandManager.GetCommandResult(id);
            return result;
        }
        /// <summary>
        /// Function: TerminalName
        /// Description: Returns client terminal name.
        /// URL: http://mm.l/mql4/docs.mql4.com/check/terminalname.html
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/terminalname")]
        public void Handle_TerminalName_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, TerminalName_1(context, chartid));
        }

        /// <summary>
        /// Function: TerminalName
        /// Description: Returns client terminal name.
        /// URL: http://mm.l/mql4/docs.mql4.com/check/terminalname.html
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/terminalname")]
        public void Handle_TerminalName_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, TerminalName_1(context, DEFAULT_CHART_ID));
        }

        private JObject TerminalName_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            int id = mqlCommandManager.ExecCommand(MQLCommand.TerminalName_1, parameters); // MQLCommand ENUM = 49
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = (string)mqlCommandManager.GetCommandResult(id);
            return result;
        }
        /// <summary>
        /// Function: TerminalPath
        /// Description: Returns the directory, from which the client terminal was launched.
        /// URL: http://mm.l/mql4/docs.mql4.com/check/terminalpath.html
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/terminalpath")]
        public void Handle_TerminalPath_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, TerminalPath_1(context, chartid));
        }

        /// <summary>
        /// Function: TerminalPath
        /// Description: Returns the directory, from which the client terminal was launched.
        /// URL: http://mm.l/mql4/docs.mql4.com/check/terminalpath.html
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/terminalpath")]
        public void Handle_TerminalPath_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, TerminalPath_1(context, DEFAULT_CHART_ID));
        }

        private JObject TerminalPath_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            int id = mqlCommandManager.ExecCommand(MQLCommand.TerminalPath_1, parameters); // MQLCommand ENUM = 50
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = (string)mqlCommandManager.GetCommandResult(id);
            return result;
        }
        /// <summary>
        /// Function: MarketInfo
        /// Description: Returns various data about securities listed in the "Market Watch" window.
        /// URL: http://mm.l/mql4/docs.mql4.com/marketinformation/marketinfo.html
        /// </summary>
        /// <param name="symbol">[in] Symbol name.</param>
        /// <param name="type">[in] Request of information to be returned. Can be any of values of request identifiers.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/marketinfo")]
        public void Handle_MarketInfo_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, MarketInfo_1(context, chartid));
        }

        /// <summary>
        /// Function: MarketInfo
        /// Description: Returns various data about securities listed in the "Market Watch" window.
        /// URL: http://mm.l/mql4/docs.mql4.com/marketinformation/marketinfo.html
        /// </summary>
        /// <param name="symbol">[in] Symbol name.</param>
        /// <param name="type">[in] Request of information to be returned. Can be any of values of request identifiers.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/marketinfo")]
        public void Handle_MarketInfo_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, MarketInfo_1(context, DEFAULT_CHART_ID));
        }

        private JObject MarketInfo_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            parameters.Add(payload["symbol"]);
            parameters.Add(payload["type"]);
            int id = mqlCommandManager.ExecCommand(MQLCommand.MarketInfo_1, parameters); // MQLCommand ENUM = 51
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = Convert.ToDecimal(mqlCommandManager.GetCommandResult(id));
            return result;
        }
        /// <summary>
        /// Function: SymbolsTotal
        /// Description: Returns the number of available (selected in Market Watch or all) symbols.
        /// URL: http://mm.l/mql4/docs.mql4.com/marketinformation/symbolstotal.html
        /// </summary>
        /// <param name="selected">[in] Request mode. Can be true or false.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/symbolstotal")]
        public void Handle_SymbolsTotal_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, SymbolsTotal_1(context, chartid));
        }

        /// <summary>
        /// Function: SymbolsTotal
        /// Description: Returns the number of available (selected in Market Watch or all) symbols.
        /// URL: http://mm.l/mql4/docs.mql4.com/marketinformation/symbolstotal.html
        /// </summary>
        /// <param name="selected">[in] Request mode. Can be true or false.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/symbolstotal")]
        public void Handle_SymbolsTotal_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, SymbolsTotal_1(context, DEFAULT_CHART_ID));
        }

        private JObject SymbolsTotal_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            parameters.Add(payload["selected"]);
            int id = mqlCommandManager.ExecCommand(MQLCommand.SymbolsTotal_1, parameters); // MQLCommand ENUM = 52
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = Convert.ToInt32(mqlCommandManager.GetCommandResult(id));
            return result;
        }
        /// <summary>
        /// Function: SymbolName
        /// Description: Returns the name of a symbol.
        /// URL: http://mm.l/mql4/docs.mql4.com/marketinformation/symbolname.html
        /// </summary>
        /// <param name="pos">[in] Order number of a symbol.</param>
        /// <param name="selected">[in] Request mode. If the value is true, the symbol is taken from the list of symbols selected in MarketWatch. If the value is false, the symbol is taken from the general list.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/symbolname")]
        public void Handle_SymbolName_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, SymbolName_1(context, chartid));
        }

        /// <summary>
        /// Function: SymbolName
        /// Description: Returns the name of a symbol.
        /// URL: http://mm.l/mql4/docs.mql4.com/marketinformation/symbolname.html
        /// </summary>
        /// <param name="pos">[in] Order number of a symbol.</param>
        /// <param name="selected">[in] Request mode. If the value is true, the symbol is taken from the list of symbols selected in MarketWatch. If the value is false, the symbol is taken from the general list.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/symbolname")]
        public void Handle_SymbolName_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, SymbolName_1(context, DEFAULT_CHART_ID));
        }

        private JObject SymbolName_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            parameters.Add(payload["pos"]);
            parameters.Add(payload["selected"]);
            int id = mqlCommandManager.ExecCommand(MQLCommand.SymbolName_1, parameters); // MQLCommand ENUM = 53
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = (string)mqlCommandManager.GetCommandResult(id);
            return result;
        }
        /// <summary>
        /// Function: SymbolSelect
        /// Description: Selects a symbol in the Market Watch window or removes a symbol from the window.
        /// URL: http://mm.l/mql4/docs.mql4.com/marketinformation/symbolselect.html
        /// </summary>
        /// <param name="name">[in] Symbol name.</param>
        /// <param name="select">[in] Switch. If the value is false, a symbol should be removed from MarketWatch, otherwise a symbol should be selected in this window. A symbol can't be removed if the symbol chart is open, or there are open orders for this symbol.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/symbolselect")]
        public void Handle_SymbolSelect_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, SymbolSelect_1(context, chartid));
        }

        /// <summary>
        /// Function: SymbolSelect
        /// Description: Selects a symbol in the Market Watch window or removes a symbol from the window.
        /// URL: http://mm.l/mql4/docs.mql4.com/marketinformation/symbolselect.html
        /// </summary>
        /// <param name="name">[in] Symbol name.</param>
        /// <param name="select">[in] Switch. If the value is false, a symbol should be removed from MarketWatch, otherwise a symbol should be selected in this window. A symbol can't be removed if the symbol chart is open, or there are open orders for this symbol.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/symbolselect")]
        public void Handle_SymbolSelect_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, SymbolSelect_1(context, DEFAULT_CHART_ID));
        }

        private JObject SymbolSelect_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            parameters.Add(payload["name"]);
            parameters.Add(payload["select"]);
            int id = mqlCommandManager.ExecCommand(MQLCommand.SymbolSelect_1, parameters); // MQLCommand ENUM = 54
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = (bool)mqlCommandManager.GetCommandResult(id);
            return result;
        }
        /// <summary>
        /// Function: RefreshRates
        /// Description: Refreshing of data in pre-defined variables and series arrays.
        /// URL: http://mm.l/mql4/docs.mql4.com/series/refreshrates.html
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/refreshrates")]
        public void Handle_RefreshRates_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, RefreshRates_1(context, chartid));
        }

        /// <summary>
        /// Function: RefreshRates
        /// Description: Refreshing of data in pre-defined variables and series arrays.
        /// URL: http://mm.l/mql4/docs.mql4.com/series/refreshrates.html
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/refreshrates")]
        public void Handle_RefreshRates_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, RefreshRates_1(context, DEFAULT_CHART_ID));
        }

        private JObject RefreshRates_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            int id = mqlCommandManager.ExecCommand(MQLCommand.RefreshRates_1, parameters); // MQLCommand ENUM = 55
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = (bool)mqlCommandManager.GetCommandResult(id);
            return result;
        }
        /// <summary>
        /// Function: Bars
        /// Description: Returns the number of bars count in the history for a specified symbol and period. There are 2 variants of functions calls.
        /// URL: http://mm.l/mql4/docs.mql4.com/series/barsfunction.html
        /// </summary>
        /// <param name="symbol_name">[in] Symbol name.</param>
        /// <param name="timeframe">[in] Period.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/bars")]
        public void Handle_Bars_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, Bars_1(context, chartid));
        }

        /// <summary>
        /// Function: Bars
        /// Description: Returns the number of bars count in the history for a specified symbol and period. There are 2 variants of functions calls.
        /// URL: http://mm.l/mql4/docs.mql4.com/series/barsfunction.html
        /// </summary>
        /// <param name="symbol_name">[in] Symbol name.</param>
        /// <param name="timeframe">[in] Period.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/bars")]
        public void Handle_Bars_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, Bars_1(context, DEFAULT_CHART_ID));
        }

        private JObject Bars_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            parameters.Add(payload["symbol_name"]);
            parameters.Add(payload["timeframe"]);
            int id = mqlCommandManager.ExecCommand(MQLCommand.Bars_1, parameters); // MQLCommand ENUM = 56
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = Convert.ToInt32(mqlCommandManager.GetCommandResult(id));
            return result;
        }
        /// <summary>
        /// Function: Bars
        /// Description: Returns the number of bars count in the history for a specified symbol and period. There are 2 variants of functions calls.
        /// URL: http://mm.l/mql4/docs.mql4.com/series/barsfunction.html
        /// </summary>
        /// <param name="symbol_name">[in] Symbol name.</param>
        /// <param name="timeframe">[in] Period.</param>
        /// <param name="start_time">[in] Bar time corresponding to the first element.</param>
        /// <param name="stop_time">[in] Bar time corresponding to the last element.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/bars")]
        public void Handle_Bars_2(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, Bars_2(context, chartid));
        }

        /// <summary>
        /// Function: Bars
        /// Description: Returns the number of bars count in the history for a specified symbol and period. There are 2 variants of functions calls.
        /// URL: http://mm.l/mql4/docs.mql4.com/series/barsfunction.html
        /// </summary>
        /// <param name="symbol_name">[in] Symbol name.</param>
        /// <param name="timeframe">[in] Period.</param>
        /// <param name="start_time">[in] Bar time corresponding to the first element.</param>
        /// <param name="stop_time">[in] Bar time corresponding to the last element.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/bars")]
        public void Handle_Bars_2_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, Bars_2(context, DEFAULT_CHART_ID));
        }

        private JObject Bars_2(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            parameters.Add(payload["symbol_name"]);
            parameters.Add(payload["timeframe"]);
            parameters.Add(payload["start_time"]);
            parameters.Add(payload["stop_time"]);
            int id = mqlCommandManager.ExecCommand(MQLCommand.Bars_2, parameters); // MQLCommand ENUM = 56
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = Convert.ToInt32(mqlCommandManager.GetCommandResult(id));
            return result;
        }
        /// <summary>
        /// Function: iBars
        /// Description: Returns the number of bars on the specified chart.
        /// URL: http://mm.l/mql4/docs.mql4.com/series/ibars.html
        /// </summary>
        /// <param name="symbol">[in] Symbol the data of which should be used to calculate indicator. means the current symbol.</param>
        /// <param name="timeframe">[in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/ibars")]
        public void Handle_iBars_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, iBars_1(context, chartid));
        }

        /// <summary>
        /// Function: iBars
        /// Description: Returns the number of bars on the specified chart.
        /// URL: http://mm.l/mql4/docs.mql4.com/series/ibars.html
        /// </summary>
        /// <param name="symbol">[in] Symbol the data of which should be used to calculate indicator. means the current symbol.</param>
        /// <param name="timeframe">[in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/ibars")]
        public void Handle_iBars_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, iBars_1(context, DEFAULT_CHART_ID));
        }

        private JObject iBars_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            parameters.Add(payload["symbol"]);
            parameters.Add(payload["timeframe"]);
            int id = mqlCommandManager.ExecCommand(MQLCommand.iBars_1, parameters); // MQLCommand ENUM = 57
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = Convert.ToInt32(mqlCommandManager.GetCommandResult(id));
            return result;
        }
        /// <summary>
        /// Function: iBarShift
        /// Description: Search for a bar by its time. The function returns the index of the bar which covers the specified time.
        /// URL: http://mm.l/mql4/docs.mql4.com/series/ibarshift.html
        /// </summary>
        /// <param name="symbol">[in] Symbol name. means the current symbol.</param>
        /// <param name="timeframe">[in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</param>
        /// <param name="time">[in] Time value for searching.</param>
        /// <param name="exact">[in] Return mode when the bar is not found (false - iBarShift returns the nearest, true - iBarShift returns -1).</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/ibarshift")]
        public void Handle_iBarShift_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, iBarShift_1(context, chartid));
        }

        /// <summary>
        /// Function: iBarShift
        /// Description: Search for a bar by its time. The function returns the index of the bar which covers the specified time.
        /// URL: http://mm.l/mql4/docs.mql4.com/series/ibarshift.html
        /// </summary>
        /// <param name="symbol">[in] Symbol name. means the current symbol.</param>
        /// <param name="timeframe">[in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</param>
        /// <param name="time">[in] Time value for searching.</param>
        /// <param name="exact">[in] Return mode when the bar is not found (false - iBarShift returns the nearest, true - iBarShift returns -1).</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/ibarshift")]
        public void Handle_iBarShift_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, iBarShift_1(context, DEFAULT_CHART_ID));
        }

        private JObject iBarShift_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            parameters.Add(payload["symbol"]);
            parameters.Add(payload["timeframe"]);
            parameters.Add(payload["time"]);
            parameters.Add(payload["exact"]);
            int id = mqlCommandManager.ExecCommand(MQLCommand.iBarShift_1, parameters); // MQLCommand ENUM = 58
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = Convert.ToInt32(mqlCommandManager.GetCommandResult(id));
            return result;
        }
        /// <summary>
        /// Function: iClose
        /// Description: Returns Close price value for the bar of specified symbol with timeframe and shift.
        /// URL: http://mm.l/mql4/docs.mql4.com/series/iclose.html
        /// </summary>
        /// <param name="symbol">[in] Symbol name. means the current symbol.</param>
        /// <param name="timeframe">[in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</param>
        /// <param name="shift">[in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/iclose")]
        public void Handle_iClose_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, iClose_1(context, chartid));
        }

        /// <summary>
        /// Function: iClose
        /// Description: Returns Close price value for the bar of specified symbol with timeframe and shift.
        /// URL: http://mm.l/mql4/docs.mql4.com/series/iclose.html
        /// </summary>
        /// <param name="symbol">[in] Symbol name. means the current symbol.</param>
        /// <param name="timeframe">[in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</param>
        /// <param name="shift">[in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/iclose")]
        public void Handle_iClose_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, iClose_1(context, DEFAULT_CHART_ID));
        }

        private JObject iClose_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            parameters.Add(payload["symbol"]);
            parameters.Add(payload["timeframe"]);
            parameters.Add(payload["shift"]);
            int id = mqlCommandManager.ExecCommand(MQLCommand.iClose_1, parameters); // MQLCommand ENUM = 59
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = Convert.ToDecimal(mqlCommandManager.GetCommandResult(id));
            return result;
        }
        /// <summary>
        /// Function: iHigh
        /// Description: Returns High price value for the bar of specified symbol with timeframe and shift.
        /// URL: http://mm.l/mql4/docs.mql4.com/series/ihigh.html
        /// </summary>
        /// <param name="symbol">[in] Symbol name. means the current symbol.</param>
        /// <param name="timeframe">[in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</param>
        /// <param name="shift">[in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/ihigh")]
        public void Handle_iHigh_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, iHigh_1(context, chartid));
        }

        /// <summary>
        /// Function: iHigh
        /// Description: Returns High price value for the bar of specified symbol with timeframe and shift.
        /// URL: http://mm.l/mql4/docs.mql4.com/series/ihigh.html
        /// </summary>
        /// <param name="symbol">[in] Symbol name. means the current symbol.</param>
        /// <param name="timeframe">[in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</param>
        /// <param name="shift">[in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/ihigh")]
        public void Handle_iHigh_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, iHigh_1(context, DEFAULT_CHART_ID));
        }

        private JObject iHigh_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            parameters.Add(payload["symbol"]);
            parameters.Add(payload["timeframe"]);
            parameters.Add(payload["shift"]);
            int id = mqlCommandManager.ExecCommand(MQLCommand.iHigh_1, parameters); // MQLCommand ENUM = 60
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = Convert.ToDecimal(mqlCommandManager.GetCommandResult(id));
            return result;
        }
        /// <summary>
        /// Function: iHighest
        /// Description: Returns the shift of the maximum value over a specific number of bars depending on type.
        /// URL: http://mm.l/mql4/docs.mql4.com/series/ihighest.html
        /// </summary>
        /// <param name="symbol">[in] Symbol the data of which should be used for search. means the current symbol.</param>
        /// <param name="timeframe">[in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</param>
        /// <param name="type">[in] Series array identifier. It can be any of the enumeration values.</param>
        /// <param name="count">[in] Number of bars (in direction from the start bar to the back one) on which the search is carried out.</param>
        /// <param name="start">[in] Shift showing the bar, relative to the current bar, that the data should be taken from.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/ihighest")]
        public void Handle_iHighest_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, iHighest_1(context, chartid));
        }

        /// <summary>
        /// Function: iHighest
        /// Description: Returns the shift of the maximum value over a specific number of bars depending on type.
        /// URL: http://mm.l/mql4/docs.mql4.com/series/ihighest.html
        /// </summary>
        /// <param name="symbol">[in] Symbol the data of which should be used for search. means the current symbol.</param>
        /// <param name="timeframe">[in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</param>
        /// <param name="type">[in] Series array identifier. It can be any of the enumeration values.</param>
        /// <param name="count">[in] Number of bars (in direction from the start bar to the back one) on which the search is carried out.</param>
        /// <param name="start">[in] Shift showing the bar, relative to the current bar, that the data should be taken from.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/ihighest")]
        public void Handle_iHighest_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, iHighest_1(context, DEFAULT_CHART_ID));
        }

        private JObject iHighest_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            parameters.Add(payload["symbol"]);
            parameters.Add(payload["timeframe"]);
            parameters.Add(payload["type"]);
            parameters.Add(payload["count"]);
            parameters.Add(payload["start"]);
            int id = mqlCommandManager.ExecCommand(MQLCommand.iHighest_1, parameters); // MQLCommand ENUM = 61
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = Convert.ToInt32(mqlCommandManager.GetCommandResult(id));
            return result;
        }
        /// <summary>
        /// Function: iLow
        /// Description: Returns Low price value for the bar of indicated symbol with timeframe and shift.
        /// URL: http://mm.l/mql4/docs.mql4.com/series/ilow.html
        /// </summary>
        /// <param name="symbol">[in] Symbol name. means the current symbol.</param>
        /// <param name="timeframe">[in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</param>
        /// <param name="shift">[in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/ilow")]
        public void Handle_iLow_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, iLow_1(context, chartid));
        }

        /// <summary>
        /// Function: iLow
        /// Description: Returns Low price value for the bar of indicated symbol with timeframe and shift.
        /// URL: http://mm.l/mql4/docs.mql4.com/series/ilow.html
        /// </summary>
        /// <param name="symbol">[in] Symbol name. means the current symbol.</param>
        /// <param name="timeframe">[in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</param>
        /// <param name="shift">[in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/ilow")]
        public void Handle_iLow_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, iLow_1(context, DEFAULT_CHART_ID));
        }

        private JObject iLow_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            parameters.Add(payload["symbol"]);
            parameters.Add(payload["timeframe"]);
            parameters.Add(payload["shift"]);
            int id = mqlCommandManager.ExecCommand(MQLCommand.iLow_1, parameters); // MQLCommand ENUM = 62
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = Convert.ToDecimal(mqlCommandManager.GetCommandResult(id));
            return result;
        }
        /// <summary>
        /// Function: iLowest
        /// Description: Returns the shift of the lowest value over a specific number of bars depending on type.
        /// URL: http://mm.l/mql4/docs.mql4.com/series/ilowest.html
        /// </summary>
        /// <param name="symbol">[in] Symbol name. means the current symbol.</param>
        /// <param name="timeframe">[in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</param>
        /// <param name="type">[in] Series array identifier. It can be any of the enumeration values.</param>
        /// <param name="count">[in] Number of bars (in direction from the start bar to the back one) on which the search is carried out.</param>
        /// <param name="start">[in] Shift showing the bar, relative to the current bar, that the data should be taken from.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/ilowest")]
        public void Handle_iLowest_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, iLowest_1(context, chartid));
        }

        /// <summary>
        /// Function: iLowest
        /// Description: Returns the shift of the lowest value over a specific number of bars depending on type.
        /// URL: http://mm.l/mql4/docs.mql4.com/series/ilowest.html
        /// </summary>
        /// <param name="symbol">[in] Symbol name. means the current symbol.</param>
        /// <param name="timeframe">[in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</param>
        /// <param name="type">[in] Series array identifier. It can be any of the enumeration values.</param>
        /// <param name="count">[in] Number of bars (in direction from the start bar to the back one) on which the search is carried out.</param>
        /// <param name="start">[in] Shift showing the bar, relative to the current bar, that the data should be taken from.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/ilowest")]
        public void Handle_iLowest_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, iLowest_1(context, DEFAULT_CHART_ID));
        }

        private JObject iLowest_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            parameters.Add(payload["symbol"]);
            parameters.Add(payload["timeframe"]);
            parameters.Add(payload["type"]);
            parameters.Add(payload["count"]);
            parameters.Add(payload["start"]);
            int id = mqlCommandManager.ExecCommand(MQLCommand.iLowest_1, parameters); // MQLCommand ENUM = 63
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = Convert.ToInt32(mqlCommandManager.GetCommandResult(id));
            return result;
        }
        /// <summary>
        /// Function: iOpen
        /// Description: Returns Open price value for the bar of specified symbol with timeframe and shift.
        /// URL: http://mm.l/mql4/docs.mql4.com/series/iopen.html
        /// </summary>
        /// <param name="symbol">[in] Symbol name. means the current symbol.</param>
        /// <param name="timeframe">[in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</param>
        /// <param name="shift">[in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/iopen")]
        public void Handle_iOpen_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, iOpen_1(context, chartid));
        }

        /// <summary>
        /// Function: iOpen
        /// Description: Returns Open price value for the bar of specified symbol with timeframe and shift.
        /// URL: http://mm.l/mql4/docs.mql4.com/series/iopen.html
        /// </summary>
        /// <param name="symbol">[in] Symbol name. means the current symbol.</param>
        /// <param name="timeframe">[in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</param>
        /// <param name="shift">[in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/iopen")]
        public void Handle_iOpen_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, iOpen_1(context, DEFAULT_CHART_ID));
        }

        private JObject iOpen_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            parameters.Add(payload["symbol"]);
            parameters.Add(payload["timeframe"]);
            parameters.Add(payload["shift"]);
            int id = mqlCommandManager.ExecCommand(MQLCommand.iOpen_1, parameters); // MQLCommand ENUM = 64
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = Convert.ToDecimal(mqlCommandManager.GetCommandResult(id));
            return result;
        }
        /// <summary>
        /// Function: iTime
        /// Description: Returns Time value for the bar of specified symbol with timeframe and shift.
        /// URL: http://mm.l/mql4/docs.mql4.com/series/itime.html
        /// </summary>
        /// <param name="symbol">[in] Symbol name. means the current symbol.</param>
        /// <param name="timeframe">[in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</param>
        /// <param name="shift">[in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/itime")]
        public void Handle_iTime_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, iTime_1(context, chartid));
        }

        /// <summary>
        /// Function: iTime
        /// Description: Returns Time value for the bar of specified symbol with timeframe and shift.
        /// URL: http://mm.l/mql4/docs.mql4.com/series/itime.html
        /// </summary>
        /// <param name="symbol">[in] Symbol name. means the current symbol.</param>
        /// <param name="timeframe">[in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</param>
        /// <param name="shift">[in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/itime")]
        public void Handle_iTime_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, iTime_1(context, DEFAULT_CHART_ID));
        }

        private JObject iTime_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            parameters.Add(payload["symbol"]);
            parameters.Add(payload["timeframe"]);
            parameters.Add(payload["shift"]);
            int id = mqlCommandManager.ExecCommand(MQLCommand.iTime_1, parameters); // MQLCommand ENUM = 65
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = (DateTime)mqlCommandManager.GetCommandResult(id);
            return result;
        }
        /// <summary>
        /// Function: iVolume
        /// Description: Returns Tick Volume value for the bar of specified symbol with timeframe and shift.
        /// URL: http://mm.l/mql4/docs.mql4.com/series/ivolume.html
        /// </summary>
        /// <param name="symbol">[in] Symbol name. means the current symbol.</param>
        /// <param name="timeframe">[in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</param>
        /// <param name="shift">[in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/ivolume")]
        public void Handle_iVolume_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, iVolume_1(context, chartid));
        }

        /// <summary>
        /// Function: iVolume
        /// Description: Returns Tick Volume value for the bar of specified symbol with timeframe and shift.
        /// URL: http://mm.l/mql4/docs.mql4.com/series/ivolume.html
        /// </summary>
        /// <param name="symbol">[in] Symbol name. means the current symbol.</param>
        /// <param name="timeframe">[in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</param>
        /// <param name="shift">[in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/ivolume")]
        public void Handle_iVolume_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, iVolume_1(context, DEFAULT_CHART_ID));
        }

        private JObject iVolume_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            parameters.Add(payload["symbol"]);
            parameters.Add(payload["timeframe"]);
            parameters.Add(payload["shift"]);
            int id = mqlCommandManager.ExecCommand(MQLCommand.iVolume_1, parameters); // MQLCommand ENUM = 66
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = Convert.ToInt64(mqlCommandManager.GetCommandResult(id));
            return result;
        }
        /// <summary>
        /// Function: ChartApplyTemplate
        /// Description: Applies a specific template from a specified file to the chart. The command is added to chart message queue and executed only after all previous commands have been processed.
        /// URL: http://mm.l/mql4/docs.mql4.com/chart_operations/chartapplytemplate.html
        /// </summary>
        /// <param name="chart_id">[in] Chart ID. 0 means the current chart.</param>
        /// <param name="filename">[in] The name of the file containing the template.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/chartapplytemplate")]
        public void Handle_ChartApplyTemplate_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, ChartApplyTemplate_1(context, chartid));
        }

        /// <summary>
        /// Function: ChartApplyTemplate
        /// Description: Applies a specific template from a specified file to the chart. The command is added to chart message queue and executed only after all previous commands have been processed.
        /// URL: http://mm.l/mql4/docs.mql4.com/chart_operations/chartapplytemplate.html
        /// </summary>
        /// <param name="chart_id">[in] Chart ID. 0 means the current chart.</param>
        /// <param name="filename">[in] The name of the file containing the template.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/chartapplytemplate")]
        public void Handle_ChartApplyTemplate_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, ChartApplyTemplate_1(context, DEFAULT_CHART_ID));
        }

        private JObject ChartApplyTemplate_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            parameters.Add(payload["chart_id"]);
            parameters.Add(payload["filename"]);
            int id = mqlCommandManager.ExecCommand(MQLCommand.ChartApplyTemplate_1, parameters); // MQLCommand ENUM = 67
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = (bool)mqlCommandManager.GetCommandResult(id);
            return result;
        }
        /// <summary>
        /// Function: ChartSaveTemplate
        /// Description: Saves current chart settings in a template with a specified name. The command is added to chart message queue and executed only after all previous commands have been processed.
        /// URL: http://mm.l/mql4/docs.mql4.com/chart_operations/chartsavetemplate.html
        /// </summary>
        /// <param name="chart_id">[in] Chart ID. 0 means the current chart.</param>
        /// <param name="filename">[in] The filename to save the template. The ".tpl" extension will be added to the filename automatically; there is no need to specify it. The template is saved in terminal_directory\Profiles\Templates\ and can be used for manual application in the terminal. If a template with the same filename already exists, the contents of this file will be overwritten.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/chartsavetemplate")]
        public void Handle_ChartSaveTemplate_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, ChartSaveTemplate_1(context, chartid));
        }

        /// <summary>
        /// Function: ChartSaveTemplate
        /// Description: Saves current chart settings in a template with a specified name. The command is added to chart message queue and executed only after all previous commands have been processed.
        /// URL: http://mm.l/mql4/docs.mql4.com/chart_operations/chartsavetemplate.html
        /// </summary>
        /// <param name="chart_id">[in] Chart ID. 0 means the current chart.</param>
        /// <param name="filename">[in] The filename to save the template. The ".tpl" extension will be added to the filename automatically; there is no need to specify it. The template is saved in terminal_directory\Profiles\Templates\ and can be used for manual application in the terminal. If a template with the same filename already exists, the contents of this file will be overwritten.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/chartsavetemplate")]
        public void Handle_ChartSaveTemplate_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, ChartSaveTemplate_1(context, DEFAULT_CHART_ID));
        }

        private JObject ChartSaveTemplate_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            parameters.Add(payload["chart_id"]);
            parameters.Add(payload["filename"]);
            int id = mqlCommandManager.ExecCommand(MQLCommand.ChartSaveTemplate_1, parameters); // MQLCommand ENUM = 68
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = (bool)mqlCommandManager.GetCommandResult(id);
            return result;
        }
        /// <summary>
        /// Function: ChartWindowFind
        /// Description: The function returns the number of a subwindow where an indicator is drawn. There are 2 variants of the function.
        /// URL: http://mm.l/mql4/docs.mql4.com/chart_operations/chartwindowfind.html
        /// </summary>
        /// <param name="chart_id">[in] Chart ID. 0 denotes the current chart.</param>
        /// <param name="indicator_shortname">[in] Short name of the indicator.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/chartwindowfind")]
        public void Handle_ChartWindowFind_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, ChartWindowFind_1(context, chartid));
        }

        /// <summary>
        /// Function: ChartWindowFind
        /// Description: The function returns the number of a subwindow where an indicator is drawn. There are 2 variants of the function.
        /// URL: http://mm.l/mql4/docs.mql4.com/chart_operations/chartwindowfind.html
        /// </summary>
        /// <param name="chart_id">[in] Chart ID. 0 denotes the current chart.</param>
        /// <param name="indicator_shortname">[in] Short name of the indicator.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/chartwindowfind")]
        public void Handle_ChartWindowFind_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, ChartWindowFind_1(context, DEFAULT_CHART_ID));
        }

        private JObject ChartWindowFind_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            parameters.Add(payload["chart_id"]);
            parameters.Add(payload["indicator_shortname"]);
            int id = mqlCommandManager.ExecCommand(MQLCommand.ChartWindowFind_1, parameters); // MQLCommand ENUM = 69
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = Convert.ToInt32(mqlCommandManager.GetCommandResult(id));
            return result;
        }
        /// <summary>
        /// Function: ChartWindowFind
        /// Description: The function returns the number of a subwindow where an indicator is drawn. There are 2 variants of the function.
        /// URL: http://mm.l/mql4/docs.mql4.com/chart_operations/chartwindowfind.html
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/chartwindowfind")]
        public void Handle_ChartWindowFind_2(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, ChartWindowFind_2(context, chartid));
        }

        /// <summary>
        /// Function: ChartWindowFind
        /// Description: The function returns the number of a subwindow where an indicator is drawn. There are 2 variants of the function.
        /// URL: http://mm.l/mql4/docs.mql4.com/chart_operations/chartwindowfind.html
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/chartwindowfind")]
        public void Handle_ChartWindowFind_2_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, ChartWindowFind_2(context, DEFAULT_CHART_ID));
        }

        private JObject ChartWindowFind_2(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            int id = mqlCommandManager.ExecCommand(MQLCommand.ChartWindowFind_2, parameters); // MQLCommand ENUM = 69
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = Convert.ToInt32(mqlCommandManager.GetCommandResult(id));
            return result;
        }
        /// <summary>
        /// Function: ChartOpen
        /// Description: Opens a new chart with the specified symbol and period. The command is added to chart message queue and executed only after all previous commands have been processed.
        /// URL: http://mm.l/mql4/docs.mql4.com/chart_operations/chartopen.html
        /// </summary>
        /// <param name="symbol">[in] Chart symbol. means the symbol of the current chart (the Expert Advisor is attached to).</param>
        /// <param name="period">[in] Chart period (timeframe). Can be one of the values. 0 means the current chart period.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/chartopen")]
        public void Handle_ChartOpen_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, ChartOpen_1(context, chartid));
        }

        /// <summary>
        /// Function: ChartOpen
        /// Description: Opens a new chart with the specified symbol and period. The command is added to chart message queue and executed only after all previous commands have been processed.
        /// URL: http://mm.l/mql4/docs.mql4.com/chart_operations/chartopen.html
        /// </summary>
        /// <param name="symbol">[in] Chart symbol. means the symbol of the current chart (the Expert Advisor is attached to).</param>
        /// <param name="period">[in] Chart period (timeframe). Can be one of the values. 0 means the current chart period.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/chartopen")]
        public void Handle_ChartOpen_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, ChartOpen_1(context, DEFAULT_CHART_ID));
        }

        private JObject ChartOpen_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            parameters.Add(payload["symbol"]);
            parameters.Add(payload["period"]);
            int id = mqlCommandManager.ExecCommand(MQLCommand.ChartOpen_1, parameters); // MQLCommand ENUM = 70
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = Convert.ToInt64(mqlCommandManager.GetCommandResult(id));
            return result;
        }
        /// <summary>
        /// Function: ChartFirst
        /// Description: Returns the ID of the first chart of the client terminal.
        /// URL: http://mm.l/mql4/docs.mql4.com/chart_operations/chartfirst.html
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/chartfirst")]
        public void Handle_ChartFirst_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, ChartFirst_1(context, chartid));
        }

        /// <summary>
        /// Function: ChartFirst
        /// Description: Returns the ID of the first chart of the client terminal.
        /// URL: http://mm.l/mql4/docs.mql4.com/chart_operations/chartfirst.html
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/chartfirst")]
        public void Handle_ChartFirst_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, ChartFirst_1(context, DEFAULT_CHART_ID));
        }

        private JObject ChartFirst_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            int id = mqlCommandManager.ExecCommand(MQLCommand.ChartFirst_1, parameters); // MQLCommand ENUM = 71
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = Convert.ToInt64(mqlCommandManager.GetCommandResult(id));
            return result;
        }
        /// <summary>
        /// Function: ChartNext
        /// Description: Returns the chart ID of the chart next to the specified one.
        /// URL: http://mm.l/mql4/docs.mql4.com/chart_operations/chartnext.html
        /// </summary>
        /// <param name="chart_id">[in] Chart ID. 0 does not mean the current chart. 0 means "return the first chart ID".</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/chartnext")]
        public void Handle_ChartNext_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, ChartNext_1(context, chartid));
        }

        /// <summary>
        /// Function: ChartNext
        /// Description: Returns the chart ID of the chart next to the specified one.
        /// URL: http://mm.l/mql4/docs.mql4.com/chart_operations/chartnext.html
        /// </summary>
        /// <param name="chart_id">[in] Chart ID. 0 does not mean the current chart. 0 means "return the first chart ID".</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/chartnext")]
        public void Handle_ChartNext_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, ChartNext_1(context, DEFAULT_CHART_ID));
        }

        private JObject ChartNext_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            parameters.Add(payload["chart_id"]);
            int id = mqlCommandManager.ExecCommand(MQLCommand.ChartNext_1, parameters); // MQLCommand ENUM = 72
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = Convert.ToInt64(mqlCommandManager.GetCommandResult(id));
            return result;
        }
        /// <summary>
        /// Function: ChartClose
        /// Description: Closes the specified chart.
        /// URL: http://mm.l/mql4/docs.mql4.com/chart_operations/chartclose.html
        /// </summary>
        /// <param name="chart_id">[in] Chart ID. 0 means the current chart.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/chartclose")]
        public void Handle_ChartClose_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, ChartClose_1(context, chartid));
        }

        /// <summary>
        /// Function: ChartClose
        /// Description: Closes the specified chart.
        /// URL: http://mm.l/mql4/docs.mql4.com/chart_operations/chartclose.html
        /// </summary>
        /// <param name="chart_id">[in] Chart ID. 0 means the current chart.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/chartclose")]
        public void Handle_ChartClose_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, ChartClose_1(context, DEFAULT_CHART_ID));
        }

        private JObject ChartClose_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            parameters.Add(payload["chart_id"]);
            int id = mqlCommandManager.ExecCommand(MQLCommand.ChartClose_1, parameters); // MQLCommand ENUM = 73
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = (bool)mqlCommandManager.GetCommandResult(id);
            return result;
        }
        /// <summary>
        /// Function: ChartSymbol
        /// Description: Returns the symbol name for the specified chart.
        /// URL: http://mm.l/mql4/docs.mql4.com/chart_operations/chartsymbol.html
        /// </summary>
        /// <param name="chart_id">[in] Chart ID. 0 means the current chart.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/chartsymbol")]
        public void Handle_ChartSymbol_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, ChartSymbol_1(context, chartid));
        }

        /// <summary>
        /// Function: ChartSymbol
        /// Description: Returns the symbol name for the specified chart.
        /// URL: http://mm.l/mql4/docs.mql4.com/chart_operations/chartsymbol.html
        /// </summary>
        /// <param name="chart_id">[in] Chart ID. 0 means the current chart.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/chartsymbol")]
        public void Handle_ChartSymbol_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, ChartSymbol_1(context, DEFAULT_CHART_ID));
        }

        private JObject ChartSymbol_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            parameters.Add(payload["chart_id"]);
            int id = mqlCommandManager.ExecCommand(MQLCommand.ChartSymbol_1, parameters); // MQLCommand ENUM = 74
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = (string)mqlCommandManager.GetCommandResult(id);
            return result;
        }
        /// <summary>
        /// Function: ChartRedraw
        /// Description: This function calls a forced redrawing of a specified chart.
        /// URL: http://mm.l/mql4/docs.mql4.com/chart_operations/chartredraw.html
        /// </summary>
        /// <param name="chart_id">[in] Chart ID. 0 means the current chart.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/chartredraw")]
        public void Handle_ChartRedraw_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, ChartRedraw_1(context, chartid));
        }

        /// <summary>
        /// Function: ChartRedraw
        /// Description: This function calls a forced redrawing of a specified chart.
        /// URL: http://mm.l/mql4/docs.mql4.com/chart_operations/chartredraw.html
        /// </summary>
        /// <param name="chart_id">[in] Chart ID. 0 means the current chart.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/chartredraw")]
        public void Handle_ChartRedraw_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, ChartRedraw_1(context, DEFAULT_CHART_ID));
        }

        private JObject ChartRedraw_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            parameters.Add(payload["chart_id"]);
            int id = mqlCommandManager.ExecCommand(MQLCommand.ChartRedraw_1, parameters); // MQLCommand ENUM = 75
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = "";
            return result;
        }
        /// <summary>
        /// Function: ChartSetDouble
        /// Description: Sets a value for a corresponding property of the specified chart. Chart property should be of a
        /// URL: http://mm.l/mql4/docs.mql4.com/chart_operations/chartsetdouble.html
        /// </summary>
        /// <param name="chart_id">[in] Chart ID. 0 means the current chart.</param>
        /// <param name="prop_id">[in] Chart property ID. Can be one of the values (except the read-only properties).</param>
        /// <param name="value">[in] Property value.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/chartsetdouble")]
        public void Handle_ChartSetDouble_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, ChartSetDouble_1(context, chartid));
        }

        /// <summary>
        /// Function: ChartSetDouble
        /// Description: Sets a value for a corresponding property of the specified chart. Chart property should be of a
        /// URL: http://mm.l/mql4/docs.mql4.com/chart_operations/chartsetdouble.html
        /// </summary>
        /// <param name="chart_id">[in] Chart ID. 0 means the current chart.</param>
        /// <param name="prop_id">[in] Chart property ID. Can be one of the values (except the read-only properties).</param>
        /// <param name="value">[in] Property value.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/chartsetdouble")]
        public void Handle_ChartSetDouble_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, ChartSetDouble_1(context, DEFAULT_CHART_ID));
        }

        private JObject ChartSetDouble_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            parameters.Add(payload["chart_id"]);
            parameters.Add(payload["prop_id"]);
            parameters.Add(payload["value"]);
            int id = mqlCommandManager.ExecCommand(MQLCommand.ChartSetDouble_1, parameters); // MQLCommand ENUM = 76
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = (bool)mqlCommandManager.GetCommandResult(id);
            return result;
        }
        /// <summary>
        /// Function: ChartSetInteger
        /// Description: Sets a value for a corresponding property of the specified chart. Chart property must be
        /// URL: http://mm.l/mql4/docs.mql4.com/chart_operations/chartsetinteger.html
        /// </summary>
        /// <param name="chart_id">[in] Chart ID. 0 means the current chart.</param>
        /// <param name="prop_id">[in] Chart property ID. It can be one of the value (except the read-only properties).</param>
        /// <param name="value">[in] Property value.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/chartsetinteger")]
        public void Handle_ChartSetInteger_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, ChartSetInteger_1(context, chartid));
        }

        /// <summary>
        /// Function: ChartSetInteger
        /// Description: Sets a value for a corresponding property of the specified chart. Chart property must be
        /// URL: http://mm.l/mql4/docs.mql4.com/chart_operations/chartsetinteger.html
        /// </summary>
        /// <param name="chart_id">[in] Chart ID. 0 means the current chart.</param>
        /// <param name="prop_id">[in] Chart property ID. It can be one of the value (except the read-only properties).</param>
        /// <param name="value">[in] Property value.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/chartsetinteger")]
        public void Handle_ChartSetInteger_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, ChartSetInteger_1(context, DEFAULT_CHART_ID));
        }

        private JObject ChartSetInteger_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            parameters.Add(payload["chart_id"]);
            parameters.Add(payload["prop_id"]);
            parameters.Add(payload["value"]);
            int id = mqlCommandManager.ExecCommand(MQLCommand.ChartSetInteger_1, parameters); // MQLCommand ENUM = 77
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = (bool)mqlCommandManager.GetCommandResult(id);
            return result;
        }
        /// <summary>
        /// Function: ChartSetInteger
        /// Description: Sets a value for a corresponding property of the specified chart. Chart property must be
        /// URL: http://mm.l/mql4/docs.mql4.com/chart_operations/chartsetinteger.html
        /// </summary>
        /// <param name="chart_id">[in] Chart ID. 0 means the current chart.</param>
        /// <param name="property_id"></param>
        /// <param name="sub_window">[in] Chart subwindow.</param>
        /// <param name="value">[in] Property value.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/chartsetinteger")]
        public void Handle_ChartSetInteger_2(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, ChartSetInteger_2(context, chartid));
        }

        /// <summary>
        /// Function: ChartSetInteger
        /// Description: Sets a value for a corresponding property of the specified chart. Chart property must be
        /// URL: http://mm.l/mql4/docs.mql4.com/chart_operations/chartsetinteger.html
        /// </summary>
        /// <param name="chart_id">[in] Chart ID. 0 means the current chart.</param>
        /// <param name="property_id"></param>
        /// <param name="sub_window">[in] Chart subwindow.</param>
        /// <param name="value">[in] Property value.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/chartsetinteger")]
        public void Handle_ChartSetInteger_2_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, ChartSetInteger_2(context, DEFAULT_CHART_ID));
        }

        private JObject ChartSetInteger_2(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            parameters.Add(payload["chart_id"]);
            parameters.Add(payload["property_id"]);
            parameters.Add(payload["sub_window"]);
            parameters.Add(payload["value"]);
            int id = mqlCommandManager.ExecCommand(MQLCommand.ChartSetInteger_2, parameters); // MQLCommand ENUM = 77
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = (bool)mqlCommandManager.GetCommandResult(id);
            return result;
        }
        /// <summary>
        /// Function: ChartSetString
        /// Description: Sets a value for a corresponding property of the specified chart. Chart property must be of the string type. The command is added to chart message queue and executed only after all previous commands have been processed.
        /// URL: http://mm.l/mql4/docs.mql4.com/chart_operations/chartsetstring.html
        /// </summary>
        /// <param name="chart_id">[in] Chart ID. 0 means the current chart.</param>
        /// <param name="prop_id">[in] Chart property ID. Its value can be one of the values (except the read-only properties).</param>
        /// <param name="str_value">[in] Property value string. String length cannot exceed 2045 characters (extra characters will be truncated).</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/chartsetstring")]
        public void Handle_ChartSetString_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, ChartSetString_1(context, chartid));
        }

        /// <summary>
        /// Function: ChartSetString
        /// Description: Sets a value for a corresponding property of the specified chart. Chart property must be of the string type. The command is added to chart message queue and executed only after all previous commands have been processed.
        /// URL: http://mm.l/mql4/docs.mql4.com/chart_operations/chartsetstring.html
        /// </summary>
        /// <param name="chart_id">[in] Chart ID. 0 means the current chart.</param>
        /// <param name="prop_id">[in] Chart property ID. Its value can be one of the values (except the read-only properties).</param>
        /// <param name="str_value">[in] Property value string. String length cannot exceed 2045 characters (extra characters will be truncated).</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/chartsetstring")]
        public void Handle_ChartSetString_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, ChartSetString_1(context, DEFAULT_CHART_ID));
        }

        private JObject ChartSetString_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            parameters.Add(payload["chart_id"]);
            parameters.Add(payload["prop_id"]);
            parameters.Add(payload["str_value"]);
            int id = mqlCommandManager.ExecCommand(MQLCommand.ChartSetString_1, parameters); // MQLCommand ENUM = 78
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = (bool)mqlCommandManager.GetCommandResult(id);
            return result;
        }
        /// <summary>
        /// Function: ChartNavigate
        /// Description: Performs shift of the specified chart by the specified number of bars relative to the specified position in the chart. The command is added to chart message queue and executed only after all previous commands have been processed.
        /// URL: http://mm.l/mql4/docs.mql4.com/chart_operations/chartnavigate.html
        /// </summary>
        /// <param name="chart_id">[in] Chart ID. 0 means the current chart.</param>
        /// <param name="position">[in] Chart position to perform a shift. Can be one of the values.</param>
        /// <param name="shift">[in] Number of bars to shift the chart. Positive value means the right shift (to the end of chart), negative value means the left shift (to the beginning of chart). The zero shift can be used to navigate to the beginning or end of chart.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/chartnavigate")]
        public void Handle_ChartNavigate_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, ChartNavigate_1(context, chartid));
        }

        /// <summary>
        /// Function: ChartNavigate
        /// Description: Performs shift of the specified chart by the specified number of bars relative to the specified position in the chart. The command is added to chart message queue and executed only after all previous commands have been processed.
        /// URL: http://mm.l/mql4/docs.mql4.com/chart_operations/chartnavigate.html
        /// </summary>
        /// <param name="chart_id">[in] Chart ID. 0 means the current chart.</param>
        /// <param name="position">[in] Chart position to perform a shift. Can be one of the values.</param>
        /// <param name="shift">[in] Number of bars to shift the chart. Positive value means the right shift (to the end of chart), negative value means the left shift (to the beginning of chart). The zero shift can be used to navigate to the beginning or end of chart.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/chartnavigate")]
        public void Handle_ChartNavigate_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, ChartNavigate_1(context, DEFAULT_CHART_ID));
        }

        private JObject ChartNavigate_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            parameters.Add(payload["chart_id"]);
            parameters.Add(payload["position"]);
            parameters.Add(payload["shift"]);
            int id = mqlCommandManager.ExecCommand(MQLCommand.ChartNavigate_1, parameters); // MQLCommand ENUM = 79
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = (bool)mqlCommandManager.GetCommandResult(id);
            return result;
        }
        /// <summary>
        /// Function: ChartID
        /// Description: Returns the ID of the current chart.
        /// URL: http://mm.l/mql4/docs.mql4.com/chart_operations/chartid.html
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/chartid")]
        public void Handle_ChartID_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, ChartID_1(context, chartid));
        }

        /// <summary>
        /// Function: ChartID
        /// Description: Returns the ID of the current chart.
        /// URL: http://mm.l/mql4/docs.mql4.com/chart_operations/chartid.html
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/chartid")]
        public void Handle_ChartID_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, ChartID_1(context, DEFAULT_CHART_ID));
        }

        private JObject ChartID_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            int id = mqlCommandManager.ExecCommand(MQLCommand.ChartID_1, parameters); // MQLCommand ENUM = 80
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = Convert.ToInt64(mqlCommandManager.GetCommandResult(id));
            return result;
        }
        /// <summary>
        /// Function: ChartIndicatorDelete
        /// Description: Removes an indicator with a specified name from the specified chart window. The command is added to chart message queue and executed only after all previous commands have been processed.
        /// URL: http://mm.l/mql4/docs.mql4.com/chart_operations/chartindicatordelete.html
        /// </summary>
        /// <param name="chart_id">[in] Chart ID. 0 denotes the current chart.</param>
        /// <param name="sub_window">[in] Number of the chart subwindow. 0 denotes the main chart subwindow.</param>
        /// <param name="indicator_shortname"></param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/chartindicatordelete")]
        public void Handle_ChartIndicatorDelete_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, ChartIndicatorDelete_1(context, chartid));
        }

        /// <summary>
        /// Function: ChartIndicatorDelete
        /// Description: Removes an indicator with a specified name from the specified chart window. The command is added to chart message queue and executed only after all previous commands have been processed.
        /// URL: http://mm.l/mql4/docs.mql4.com/chart_operations/chartindicatordelete.html
        /// </summary>
        /// <param name="chart_id">[in] Chart ID. 0 denotes the current chart.</param>
        /// <param name="sub_window">[in] Number of the chart subwindow. 0 denotes the main chart subwindow.</param>
        /// <param name="indicator_shortname"></param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/chartindicatordelete")]
        public void Handle_ChartIndicatorDelete_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, ChartIndicatorDelete_1(context, DEFAULT_CHART_ID));
        }

        private JObject ChartIndicatorDelete_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            parameters.Add(payload["chart_id"]);
            parameters.Add(payload["sub_window"]);
            parameters.Add(payload["indicator_shortname"]);
            int id = mqlCommandManager.ExecCommand(MQLCommand.ChartIndicatorDelete_1, parameters); // MQLCommand ENUM = 81
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = (bool)mqlCommandManager.GetCommandResult(id);
            return result;
        }
        /// <summary>
        /// Function: ChartIndicatorName
        /// Description: Returns the short name of the indicator by the number in the indicators list on the specified chart window.
        /// URL: http://mm.l/mql4/docs.mql4.com/chart_operations/chartindicatorname.html
        /// </summary>
        /// <param name="chart_id">[in] Chart ID. 0 denotes the current chart.</param>
        /// <param name="sub_window">[in] Number of the chart subwindow. 0 denotes the main chart subwindow.</param>
        /// <param name="index">[in] the index of the indicator in the list of indicators. The numeration of indicators start with zero, i.e. the first indicator in the list has the 0 index. To obtain the number of indicators in the list use the function.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/chartindicatorname")]
        public void Handle_ChartIndicatorName_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, ChartIndicatorName_1(context, chartid));
        }

        /// <summary>
        /// Function: ChartIndicatorName
        /// Description: Returns the short name of the indicator by the number in the indicators list on the specified chart window.
        /// URL: http://mm.l/mql4/docs.mql4.com/chart_operations/chartindicatorname.html
        /// </summary>
        /// <param name="chart_id">[in] Chart ID. 0 denotes the current chart.</param>
        /// <param name="sub_window">[in] Number of the chart subwindow. 0 denotes the main chart subwindow.</param>
        /// <param name="index">[in] the index of the indicator in the list of indicators. The numeration of indicators start with zero, i.e. the first indicator in the list has the 0 index. To obtain the number of indicators in the list use the function.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/chartindicatorname")]
        public void Handle_ChartIndicatorName_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, ChartIndicatorName_1(context, DEFAULT_CHART_ID));
        }

        private JObject ChartIndicatorName_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            parameters.Add(payload["chart_id"]);
            parameters.Add(payload["sub_window"]);
            parameters.Add(payload["index"]);
            int id = mqlCommandManager.ExecCommand(MQLCommand.ChartIndicatorName_1, parameters); // MQLCommand ENUM = 82
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = (string)mqlCommandManager.GetCommandResult(id);
            return result;
        }
        /// <summary>
        /// Function: ChartIndicatorsTotal
        /// Description: Returns the number of all indicators applied to the specified chart window.
        /// URL: http://mm.l/mql4/docs.mql4.com/chart_operations/chartindicatorstotal.html
        /// </summary>
        /// <param name="chart_id">[in] Chart ID. 0 denotes the current chart.</param>
        /// <param name="sub_window">[in] Number of the chart subwindow. 0 denotes the main chart subwindow.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/chartindicatorstotal")]
        public void Handle_ChartIndicatorsTotal_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, ChartIndicatorsTotal_1(context, chartid));
        }

        /// <summary>
        /// Function: ChartIndicatorsTotal
        /// Description: Returns the number of all indicators applied to the specified chart window.
        /// URL: http://mm.l/mql4/docs.mql4.com/chart_operations/chartindicatorstotal.html
        /// </summary>
        /// <param name="chart_id">[in] Chart ID. 0 denotes the current chart.</param>
        /// <param name="sub_window">[in] Number of the chart subwindow. 0 denotes the main chart subwindow.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/chartindicatorstotal")]
        public void Handle_ChartIndicatorsTotal_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, ChartIndicatorsTotal_1(context, DEFAULT_CHART_ID));
        }

        private JObject ChartIndicatorsTotal_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            parameters.Add(payload["chart_id"]);
            parameters.Add(payload["sub_window"]);
            int id = mqlCommandManager.ExecCommand(MQLCommand.ChartIndicatorsTotal_1, parameters); // MQLCommand ENUM = 83
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = Convert.ToInt32(mqlCommandManager.GetCommandResult(id));
            return result;
        }
        /// <summary>
        /// Function: ChartWindowOnDropped
        /// Description: Returns the number (index) of the chart subwindow the Expert Advisor or script has been dropped to. 0 means the main chart window.
        /// URL: http://mm.l/mql4/docs.mql4.com/chart_operations/chartwindowondropped.html
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/chartwindowondropped")]
        public void Handle_ChartWindowOnDropped_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, ChartWindowOnDropped_1(context, chartid));
        }

        /// <summary>
        /// Function: ChartWindowOnDropped
        /// Description: Returns the number (index) of the chart subwindow the Expert Advisor or script has been dropped to. 0 means the main chart window.
        /// URL: http://mm.l/mql4/docs.mql4.com/chart_operations/chartwindowondropped.html
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/chartwindowondropped")]
        public void Handle_ChartWindowOnDropped_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, ChartWindowOnDropped_1(context, DEFAULT_CHART_ID));
        }

        private JObject ChartWindowOnDropped_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            int id = mqlCommandManager.ExecCommand(MQLCommand.ChartWindowOnDropped_1, parameters); // MQLCommand ENUM = 84
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = Convert.ToInt32(mqlCommandManager.GetCommandResult(id));
            return result;
        }
        /// <summary>
        /// Function: ChartPriceOnDropped
        /// Description: Returns the price coordinate corresponding to the chart point the Expert Advisor or script has been dropped to.
        /// URL: http://mm.l/mql4/docs.mql4.com/chart_operations/chartpriceondropped.html
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/chartpriceondropped")]
        public void Handle_ChartPriceOnDropped_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, ChartPriceOnDropped_1(context, chartid));
        }

        /// <summary>
        /// Function: ChartPriceOnDropped
        /// Description: Returns the price coordinate corresponding to the chart point the Expert Advisor or script has been dropped to.
        /// URL: http://mm.l/mql4/docs.mql4.com/chart_operations/chartpriceondropped.html
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/chartpriceondropped")]
        public void Handle_ChartPriceOnDropped_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, ChartPriceOnDropped_1(context, DEFAULT_CHART_ID));
        }

        private JObject ChartPriceOnDropped_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            int id = mqlCommandManager.ExecCommand(MQLCommand.ChartPriceOnDropped_1, parameters); // MQLCommand ENUM = 85
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = Convert.ToDecimal(mqlCommandManager.GetCommandResult(id));
            return result;
        }
        /// <summary>
        /// Function: ChartTimeOnDropped
        /// Description: Returns the time coordinate corresponding to the chart point the Expert Advisor or script has been dropped to.
        /// URL: http://mm.l/mql4/docs.mql4.com/chart_operations/charttimeondropped.html
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/charttimeondropped")]
        public void Handle_ChartTimeOnDropped_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, ChartTimeOnDropped_1(context, chartid));
        }

        /// <summary>
        /// Function: ChartTimeOnDropped
        /// Description: Returns the time coordinate corresponding to the chart point the Expert Advisor or script has been dropped to.
        /// URL: http://mm.l/mql4/docs.mql4.com/chart_operations/charttimeondropped.html
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/charttimeondropped")]
        public void Handle_ChartTimeOnDropped_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, ChartTimeOnDropped_1(context, DEFAULT_CHART_ID));
        }

        private JObject ChartTimeOnDropped_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            int id = mqlCommandManager.ExecCommand(MQLCommand.ChartTimeOnDropped_1, parameters); // MQLCommand ENUM = 86
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = (DateTime)mqlCommandManager.GetCommandResult(id);
            return result;
        }
        /// <summary>
        /// Function: ChartXOnDropped
        /// Description: Returns the X coordinate of the chart point the Expert Advisor or script has been dropped to.
        /// URL: http://mm.l/mql4/docs.mql4.com/chart_operations/chartxondropped.html
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/chartxondropped")]
        public void Handle_ChartXOnDropped_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, ChartXOnDropped_1(context, chartid));
        }

        /// <summary>
        /// Function: ChartXOnDropped
        /// Description: Returns the X coordinate of the chart point the Expert Advisor or script has been dropped to.
        /// URL: http://mm.l/mql4/docs.mql4.com/chart_operations/chartxondropped.html
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/chartxondropped")]
        public void Handle_ChartXOnDropped_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, ChartXOnDropped_1(context, DEFAULT_CHART_ID));
        }

        private JObject ChartXOnDropped_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            int id = mqlCommandManager.ExecCommand(MQLCommand.ChartXOnDropped_1, parameters); // MQLCommand ENUM = 87
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = Convert.ToInt32(mqlCommandManager.GetCommandResult(id));
            return result;
        }
        /// <summary>
        /// Function: ChartYOnDropped
        /// Description: Returns the Y coordinateof the chart point the Expert Advisor or script has been dropped to.
        /// URL: http://mm.l/mql4/docs.mql4.com/chart_operations/chartyondropped.html
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/chartyondropped")]
        public void Handle_ChartYOnDropped_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, ChartYOnDropped_1(context, chartid));
        }

        /// <summary>
        /// Function: ChartYOnDropped
        /// Description: Returns the Y coordinateof the chart point the Expert Advisor or script has been dropped to.
        /// URL: http://mm.l/mql4/docs.mql4.com/chart_operations/chartyondropped.html
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/chartyondropped")]
        public void Handle_ChartYOnDropped_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, ChartYOnDropped_1(context, DEFAULT_CHART_ID));
        }

        private JObject ChartYOnDropped_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            int id = mqlCommandManager.ExecCommand(MQLCommand.ChartYOnDropped_1, parameters); // MQLCommand ENUM = 88
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = Convert.ToInt32(mqlCommandManager.GetCommandResult(id));
            return result;
        }
        /// <summary>
        /// Function: ChartSetSymbolPeriod
        /// Description: Changes the symbol and period of the specified chart. The function is asynchronous, i.e. it sends the command and does not wait for its execution completion. The command is added to chart message queue and executed only after all previous commands have been processed.
        /// URL: http://mm.l/mql4/docs.mql4.com/chart_operations/chartsetsymbolperiod.html
        /// </summary>
        /// <param name="chart_id">[in] Chart ID. 0 means the current chart.</param>
        /// <param name="symbol">[in] Chart symbol. value means the current chart symbol (Expert Advisor is attached to)</param>
        /// <param name="period">[in] Chart period (timeframe). Can be one of the values. 0 means the current chart period.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/chartsetsymbolperiod")]
        public void Handle_ChartSetSymbolPeriod_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, ChartSetSymbolPeriod_1(context, chartid));
        }

        /// <summary>
        /// Function: ChartSetSymbolPeriod
        /// Description: Changes the symbol and period of the specified chart. The function is asynchronous, i.e. it sends the command and does not wait for its execution completion. The command is added to chart message queue and executed only after all previous commands have been processed.
        /// URL: http://mm.l/mql4/docs.mql4.com/chart_operations/chartsetsymbolperiod.html
        /// </summary>
        /// <param name="chart_id">[in] Chart ID. 0 means the current chart.</param>
        /// <param name="symbol">[in] Chart symbol. value means the current chart symbol (Expert Advisor is attached to)</param>
        /// <param name="period">[in] Chart period (timeframe). Can be one of the values. 0 means the current chart period.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/chartsetsymbolperiod")]
        public void Handle_ChartSetSymbolPeriod_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, ChartSetSymbolPeriod_1(context, DEFAULT_CHART_ID));
        }

        private JObject ChartSetSymbolPeriod_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            parameters.Add(payload["chart_id"]);
            parameters.Add(payload["symbol"]);
            parameters.Add(payload["period"]);
            int id = mqlCommandManager.ExecCommand(MQLCommand.ChartSetSymbolPeriod_1, parameters); // MQLCommand ENUM = 89
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = (bool)mqlCommandManager.GetCommandResult(id);
            return result;
        }
        /// <summary>
        /// Function: ChartScreenShot
        /// Description: Saves current chart screen shot as a GIF, PNG or BMP file depending on specified extension. The command is added to chart message queue and executed only after all previous commands have been processed.
        /// URL: http://mm.l/mql4/docs.mql4.com/chart_operations/chartscreenshot.html
        /// </summary>
        /// <param name="chart_id">[in] Chart ID. 0 means the current chart.</param>
        /// <param name="filename">[in] Screenshot file name. Cannot exceed 63 characters. Screenshot files are placed in the \Files directory.</param>
        /// <param name="width">[in] Screenshot width in pixels.</param>
        /// <param name="height">[in] Screenshot height in pixels.</param>
        /// <param name="align_mode">[in] Output mode of a narrow screenshot. A value of the enumeration. ALIGN_RIGHT means align to the right margin (the output from the end). ALIGN_LEFT means Left justify.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/chartscreenshot")]
        public void Handle_ChartScreenShot_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, ChartScreenShot_1(context, chartid));
        }

        /// <summary>
        /// Function: ChartScreenShot
        /// Description: Saves current chart screen shot as a GIF, PNG or BMP file depending on specified extension. The command is added to chart message queue and executed only after all previous commands have been processed.
        /// URL: http://mm.l/mql4/docs.mql4.com/chart_operations/chartscreenshot.html
        /// </summary>
        /// <param name="chart_id">[in] Chart ID. 0 means the current chart.</param>
        /// <param name="filename">[in] Screenshot file name. Cannot exceed 63 characters. Screenshot files are placed in the \Files directory.</param>
        /// <param name="width">[in] Screenshot width in pixels.</param>
        /// <param name="height">[in] Screenshot height in pixels.</param>
        /// <param name="align_mode">[in] Output mode of a narrow screenshot. A value of the enumeration. ALIGN_RIGHT means align to the right margin (the output from the end). ALIGN_LEFT means Left justify.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/chartscreenshot")]
        public void Handle_ChartScreenShot_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, ChartScreenShot_1(context, DEFAULT_CHART_ID));
        }

        private JObject ChartScreenShot_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            parameters.Add(payload["chart_id"]);
            parameters.Add(payload["filename"]);
            parameters.Add(payload["width"]);
            parameters.Add(payload["height"]);
            parameters.Add(payload["align_mode"]);
            int id = mqlCommandManager.ExecCommand(MQLCommand.ChartScreenShot_1, parameters); // MQLCommand ENUM = 90
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = (bool)mqlCommandManager.GetCommandResult(id);
            return result;
        }
        /// <summary>
        /// Function: WindowBarsPerChart
        /// Description: Returns the amount of bars visible on the chart.
        /// URL: http://mm.l/mql4/docs.mql4.com/chart_operations/windowbarsperchart.html
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/windowbarsperchart")]
        public void Handle_WindowBarsPerChart_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, WindowBarsPerChart_1(context, chartid));
        }

        /// <summary>
        /// Function: WindowBarsPerChart
        /// Description: Returns the amount of bars visible on the chart.
        /// URL: http://mm.l/mql4/docs.mql4.com/chart_operations/windowbarsperchart.html
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/windowbarsperchart")]
        public void Handle_WindowBarsPerChart_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, WindowBarsPerChart_1(context, DEFAULT_CHART_ID));
        }

        private JObject WindowBarsPerChart_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            int id = mqlCommandManager.ExecCommand(MQLCommand.WindowBarsPerChart_1, parameters); // MQLCommand ENUM = 91
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = Convert.ToInt32(mqlCommandManager.GetCommandResult(id));
            return result;
        }
        /// <summary>
        /// Function: WindowExpertName
        /// Description: Returns the name of the executed Expert Advisor, script, custom indicator, or library.
        /// URL: http://mm.l/mql4/docs.mql4.com/chart_operations/windowexpertname.html
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/windowexpertname")]
        public void Handle_WindowExpertName_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, WindowExpertName_1(context, chartid));
        }

        /// <summary>
        /// Function: WindowExpertName
        /// Description: Returns the name of the executed Expert Advisor, script, custom indicator, or library.
        /// URL: http://mm.l/mql4/docs.mql4.com/chart_operations/windowexpertname.html
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/windowexpertname")]
        public void Handle_WindowExpertName_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, WindowExpertName_1(context, DEFAULT_CHART_ID));
        }

        private JObject WindowExpertName_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            int id = mqlCommandManager.ExecCommand(MQLCommand.WindowExpertName_1, parameters); // MQLCommand ENUM = 92
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = (string)mqlCommandManager.GetCommandResult(id);
            return result;
        }
        /// <summary>
        /// Function: WindowFind
        /// Description: Returns the window index containing this specified indicator.
        /// URL: http://mm.l/mql4/docs.mql4.com/chart_operations/windowfind.html
        /// </summary>
        /// <param name="name">[in] Indicator short name.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/windowfind")]
        public void Handle_WindowFind_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, WindowFind_1(context, chartid));
        }

        /// <summary>
        /// Function: WindowFind
        /// Description: Returns the window index containing this specified indicator.
        /// URL: http://mm.l/mql4/docs.mql4.com/chart_operations/windowfind.html
        /// </summary>
        /// <param name="name">[in] Indicator short name.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/windowfind")]
        public void Handle_WindowFind_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, WindowFind_1(context, DEFAULT_CHART_ID));
        }

        private JObject WindowFind_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            parameters.Add(payload["name"]);
            int id = mqlCommandManager.ExecCommand(MQLCommand.WindowFind_1, parameters); // MQLCommand ENUM = 93
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = Convert.ToInt32(mqlCommandManager.GetCommandResult(id));
            return result;
        }
        /// <summary>
        /// Function: WindowFirstVisibleBar
        /// Description: Returns index of the first visible bar in the current chart window.
        /// URL: http://mm.l/mql4/docs.mql4.com/chart_operations/windowfirstvisiblebar.html
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/windowfirstvisiblebar")]
        public void Handle_WindowFirstVisibleBar_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, WindowFirstVisibleBar_1(context, chartid));
        }

        /// <summary>
        /// Function: WindowFirstVisibleBar
        /// Description: Returns index of the first visible bar in the current chart window.
        /// URL: http://mm.l/mql4/docs.mql4.com/chart_operations/windowfirstvisiblebar.html
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/windowfirstvisiblebar")]
        public void Handle_WindowFirstVisibleBar_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, WindowFirstVisibleBar_1(context, DEFAULT_CHART_ID));
        }

        private JObject WindowFirstVisibleBar_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            int id = mqlCommandManager.ExecCommand(MQLCommand.WindowFirstVisibleBar_1, parameters); // MQLCommand ENUM = 94
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = Convert.ToInt32(mqlCommandManager.GetCommandResult(id));
            return result;
        }
        /// <summary>
        /// Function: WindowHandle
        /// Description: Returns the system handle of the chart window.
        /// URL: http://mm.l/mql4/docs.mql4.com/chart_operations/windowhandle.html
        /// </summary>
        /// <param name="symbol">[in] Symbol.</param>
        /// <param name="timeframe">[in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/windowhandle")]
        public void Handle_WindowHandle_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, WindowHandle_1(context, chartid));
        }

        /// <summary>
        /// Function: WindowHandle
        /// Description: Returns the system handle of the chart window.
        /// URL: http://mm.l/mql4/docs.mql4.com/chart_operations/windowhandle.html
        /// </summary>
        /// <param name="symbol">[in] Symbol.</param>
        /// <param name="timeframe">[in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/windowhandle")]
        public void Handle_WindowHandle_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, WindowHandle_1(context, DEFAULT_CHART_ID));
        }

        private JObject WindowHandle_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            parameters.Add(payload["symbol"]);
            parameters.Add(payload["timeframe"]);
            int id = mqlCommandManager.ExecCommand(MQLCommand.WindowHandle_1, parameters); // MQLCommand ENUM = 95
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = Convert.ToInt32(mqlCommandManager.GetCommandResult(id));
            return result;
        }
        /// <summary>
        /// Function: WindowIsVisible
        /// Description: Returns the visibility flag of the chart subwindow.
        /// URL: http://mm.l/mql4/docs.mql4.com/chart_operations/windowisvisible.html
        /// </summary>
        /// <param name="index">[in] Subwindow index.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/windowisvisible")]
        public void Handle_WindowIsVisible_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, WindowIsVisible_1(context, chartid));
        }

        /// <summary>
        /// Function: WindowIsVisible
        /// Description: Returns the visibility flag of the chart subwindow.
        /// URL: http://mm.l/mql4/docs.mql4.com/chart_operations/windowisvisible.html
        /// </summary>
        /// <param name="index">[in] Subwindow index.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/windowisvisible")]
        public void Handle_WindowIsVisible_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, WindowIsVisible_1(context, DEFAULT_CHART_ID));
        }

        private JObject WindowIsVisible_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            parameters.Add(payload["index"]);
            int id = mqlCommandManager.ExecCommand(MQLCommand.WindowIsVisible_1, parameters); // MQLCommand ENUM = 96
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = Convert.ToInt32(mqlCommandManager.GetCommandResult(id));
            return result;
        }
        /// <summary>
        /// Function: WindowOnDropped
        /// Description: Returns the window index where Expert Advisor, custom indicator or script was dropped.
        /// URL: http://mm.l/mql4/docs.mql4.com/chart_operations/windowondropped.html
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/windowondropped")]
        public void Handle_WindowOnDropped_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, WindowOnDropped_1(context, chartid));
        }

        /// <summary>
        /// Function: WindowOnDropped
        /// Description: Returns the window index where Expert Advisor, custom indicator or script was dropped.
        /// URL: http://mm.l/mql4/docs.mql4.com/chart_operations/windowondropped.html
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/windowondropped")]
        public void Handle_WindowOnDropped_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, WindowOnDropped_1(context, DEFAULT_CHART_ID));
        }

        private JObject WindowOnDropped_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            int id = mqlCommandManager.ExecCommand(MQLCommand.WindowOnDropped_1, parameters); // MQLCommand ENUM = 97
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = Convert.ToInt32(mqlCommandManager.GetCommandResult(id));
            return result;
        }
        /// <summary>
        /// Function: WindowPriceMax
        /// Description: Returns the maximal value of the vertical scale of the specified subwindow of the current chart.
        /// URL: http://mm.l/mql4/docs.mql4.com/chart_operations/windowpricemax.html
        /// </summary>
        /// <param name="index">[in] Chart subwindow index (0 - main chart window).</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/windowpricemax")]
        public void Handle_WindowPriceMax_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, WindowPriceMax_1(context, chartid));
        }

        /// <summary>
        /// Function: WindowPriceMax
        /// Description: Returns the maximal value of the vertical scale of the specified subwindow of the current chart.
        /// URL: http://mm.l/mql4/docs.mql4.com/chart_operations/windowpricemax.html
        /// </summary>
        /// <param name="index">[in] Chart subwindow index (0 - main chart window).</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/windowpricemax")]
        public void Handle_WindowPriceMax_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, WindowPriceMax_1(context, DEFAULT_CHART_ID));
        }

        private JObject WindowPriceMax_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            parameters.Add(payload["index"]);
            int id = mqlCommandManager.ExecCommand(MQLCommand.WindowPriceMax_1, parameters); // MQLCommand ENUM = 98
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = Convert.ToInt32(mqlCommandManager.GetCommandResult(id));
            return result;
        }
        /// <summary>
        /// Function: WindowPriceMin
        /// Description: Returns the minimal value of the vertical scale of the specified subwindow of the current chart.
        /// URL: http://mm.l/mql4/docs.mql4.com/chart_operations/windowpricemin.html
        /// </summary>
        /// <param name="index">[in] Chart subwindow index (0 - main chart window).</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/windowpricemin")]
        public void Handle_WindowPriceMin_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, WindowPriceMin_1(context, chartid));
        }

        /// <summary>
        /// Function: WindowPriceMin
        /// Description: Returns the minimal value of the vertical scale of the specified subwindow of the current chart.
        /// URL: http://mm.l/mql4/docs.mql4.com/chart_operations/windowpricemin.html
        /// </summary>
        /// <param name="index">[in] Chart subwindow index (0 - main chart window).</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/windowpricemin")]
        public void Handle_WindowPriceMin_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, WindowPriceMin_1(context, DEFAULT_CHART_ID));
        }

        private JObject WindowPriceMin_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            parameters.Add(payload["index"]);
            int id = mqlCommandManager.ExecCommand(MQLCommand.WindowPriceMin_1, parameters); // MQLCommand ENUM = 99
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = Convert.ToInt32(mqlCommandManager.GetCommandResult(id));
            return result;
        }
        /// <summary>
        /// Function: WindowPriceOnDropped
        /// Description: Returns the price of the chart point where Expert Advisor or script was dropped.
        /// URL: http://mm.l/mql4/docs.mql4.com/chart_operations/windowpriceondropped.html
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/windowpriceondropped")]
        public void Handle_WindowPriceOnDropped_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, WindowPriceOnDropped_1(context, chartid));
        }

        /// <summary>
        /// Function: WindowPriceOnDropped
        /// Description: Returns the price of the chart point where Expert Advisor or script was dropped.
        /// URL: http://mm.l/mql4/docs.mql4.com/chart_operations/windowpriceondropped.html
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/windowpriceondropped")]
        public void Handle_WindowPriceOnDropped_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, WindowPriceOnDropped_1(context, DEFAULT_CHART_ID));
        }

        private JObject WindowPriceOnDropped_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            int id = mqlCommandManager.ExecCommand(MQLCommand.WindowPriceOnDropped_1, parameters); // MQLCommand ENUM = 100
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = Convert.ToDecimal(mqlCommandManager.GetCommandResult(id));
            return result;
        }
        /// <summary>
        /// Function: WindowRedraw
        /// Description: Redraws the current chart forcedly.
        /// URL: http://mm.l/mql4/docs.mql4.com/chart_operations/windowredraw.html
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/windowredraw")]
        public void Handle_WindowRedraw_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, WindowRedraw_1(context, chartid));
        }

        /// <summary>
        /// Function: WindowRedraw
        /// Description: Redraws the current chart forcedly.
        /// URL: http://mm.l/mql4/docs.mql4.com/chart_operations/windowredraw.html
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/windowredraw")]
        public void Handle_WindowRedraw_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, WindowRedraw_1(context, DEFAULT_CHART_ID));
        }

        private JObject WindowRedraw_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            int id = mqlCommandManager.ExecCommand(MQLCommand.WindowRedraw_1, parameters); // MQLCommand ENUM = 101
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = "";
            return result;
        }
        /// <summary>
        /// Function: WindowScreenShot
        /// Description: Saves current chart screen shot as a GIF file.
        /// URL: http://mm.l/mql4/docs.mql4.com/chart_operations/windowscreenshot.html
        /// </summary>
        /// <param name="filename">[in] Screen shot file name. Screenshot is saved to \Files folder.</param>
        /// <param name="size_x">[in] Screen shot width in pixels.</param>
        /// <param name="size_y">[in] Screen shot height in pixels.</param>
        /// <param name="start_bar">[in] Index of the first visible bar in the screen shot. If 0 value is set, the current first visible bar will be shot. If no value or negative value has been set, the end-of-chart screen shot will be produced, indent being taken into consideration.</param>
        /// <param name="chart_scale">[in] Horizontal chart scale for screen shot. Can be in the range from 0 to 5. If no value or negative value has been set, the current chart scale will be used.</param>
        /// <param name="chart_mode">[in] Chart displaying mode. It can take the following values: CHART_BAR (0 is a sequence of bars), CHART_CANDLE (1 is a sequence of candlesticks), CHART_LINE (2 is a close prices line). If no value or negative value has been set, the chart will be shown in its current mode.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/windowscreenshot")]
        public void Handle_WindowScreenShot_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, WindowScreenShot_1(context, chartid));
        }

        /// <summary>
        /// Function: WindowScreenShot
        /// Description: Saves current chart screen shot as a GIF file.
        /// URL: http://mm.l/mql4/docs.mql4.com/chart_operations/windowscreenshot.html
        /// </summary>
        /// <param name="filename">[in] Screen shot file name. Screenshot is saved to \Files folder.</param>
        /// <param name="size_x">[in] Screen shot width in pixels.</param>
        /// <param name="size_y">[in] Screen shot height in pixels.</param>
        /// <param name="start_bar">[in] Index of the first visible bar in the screen shot. If 0 value is set, the current first visible bar will be shot. If no value or negative value has been set, the end-of-chart screen shot will be produced, indent being taken into consideration.</param>
        /// <param name="chart_scale">[in] Horizontal chart scale for screen shot. Can be in the range from 0 to 5. If no value or negative value has been set, the current chart scale will be used.</param>
        /// <param name="chart_mode">[in] Chart displaying mode. It can take the following values: CHART_BAR (0 is a sequence of bars), CHART_CANDLE (1 is a sequence of candlesticks), CHART_LINE (2 is a close prices line). If no value or negative value has been set, the chart will be shown in its current mode.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/windowscreenshot")]
        public void Handle_WindowScreenShot_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, WindowScreenShot_1(context, DEFAULT_CHART_ID));
        }

        private JObject WindowScreenShot_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            parameters.Add(payload["filename"]);
            parameters.Add(payload["size_x"]);
            parameters.Add(payload["size_y"]);
            parameters.Add(payload["start_bar"]);
            parameters.Add(payload["chart_scale"]);
            parameters.Add(payload["chart_mode"]);
            int id = mqlCommandManager.ExecCommand(MQLCommand.WindowScreenShot_1, parameters); // MQLCommand ENUM = 102
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = (bool)mqlCommandManager.GetCommandResult(id);
            return result;
        }
        /// <summary>
        /// Function: WindowTimeOnDropped
        /// Description: Returns the time of the chart point where Expert Advisor or script was dropped.
        /// URL: http://mm.l/mql4/docs.mql4.com/chart_operations/windowtimeondropped.html
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/windowtimeondropped")]
        public void Handle_WindowTimeOnDropped_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, WindowTimeOnDropped_1(context, chartid));
        }

        /// <summary>
        /// Function: WindowTimeOnDropped
        /// Description: Returns the time of the chart point where Expert Advisor or script was dropped.
        /// URL: http://mm.l/mql4/docs.mql4.com/chart_operations/windowtimeondropped.html
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/windowtimeondropped")]
        public void Handle_WindowTimeOnDropped_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, WindowTimeOnDropped_1(context, DEFAULT_CHART_ID));
        }

        private JObject WindowTimeOnDropped_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            int id = mqlCommandManager.ExecCommand(MQLCommand.WindowTimeOnDropped_1, parameters); // MQLCommand ENUM = 103
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = (DateTime)mqlCommandManager.GetCommandResult(id);
            return result;
        }
        /// <summary>
        /// Function: WindowsTotal
        /// Description: Returns total number of indicator windows on the chart.
        /// URL: http://mm.l/mql4/docs.mql4.com/chart_operations/windowstotal.html
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/windowstotal")]
        public void Handle_WindowsTotal_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, WindowsTotal_1(context, chartid));
        }

        /// <summary>
        /// Function: WindowsTotal
        /// Description: Returns total number of indicator windows on the chart.
        /// URL: http://mm.l/mql4/docs.mql4.com/chart_operations/windowstotal.html
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/windowstotal")]
        public void Handle_WindowsTotal_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, WindowsTotal_1(context, DEFAULT_CHART_ID));
        }

        private JObject WindowsTotal_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            int id = mqlCommandManager.ExecCommand(MQLCommand.WindowsTotal_1, parameters); // MQLCommand ENUM = 104
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = Convert.ToInt32(mqlCommandManager.GetCommandResult(id));
            return result;
        }
        /// <summary>
        /// Function: WindowXOnDropped
        /// Description: Returns the value at X axis in pixels for the chart window client area point at which the Expert Advisor or script was dropped.
        /// URL: http://mm.l/mql4/docs.mql4.com/chart_operations/windowxondropped.html
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/windowxondropped")]
        public void Handle_WindowXOnDropped_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, WindowXOnDropped_1(context, chartid));
        }

        /// <summary>
        /// Function: WindowXOnDropped
        /// Description: Returns the value at X axis in pixels for the chart window client area point at which the Expert Advisor or script was dropped.
        /// URL: http://mm.l/mql4/docs.mql4.com/chart_operations/windowxondropped.html
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/windowxondropped")]
        public void Handle_WindowXOnDropped_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, WindowXOnDropped_1(context, DEFAULT_CHART_ID));
        }

        private JObject WindowXOnDropped_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            int id = mqlCommandManager.ExecCommand(MQLCommand.WindowXOnDropped_1, parameters); // MQLCommand ENUM = 105
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = Convert.ToInt32(mqlCommandManager.GetCommandResult(id));
            return result;
        }
        /// <summary>
        /// Function: WindowYOnDropped
        /// Description: Returns the value at Y axis in pixels for the chart window client area point at which the Expert Advisor or script was dropped.
        /// URL: http://mm.l/mql4/docs.mql4.com/chart_operations/windowyondropped.html
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/windowyondropped")]
        public void Handle_WindowYOnDropped_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, WindowYOnDropped_1(context, chartid));
        }

        /// <summary>
        /// Function: WindowYOnDropped
        /// Description: Returns the value at Y axis in pixels for the chart window client area point at which the Expert Advisor or script was dropped.
        /// URL: http://mm.l/mql4/docs.mql4.com/chart_operations/windowyondropped.html
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/windowyondropped")]
        public void Handle_WindowYOnDropped_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, WindowYOnDropped_1(context, DEFAULT_CHART_ID));
        }

        private JObject WindowYOnDropped_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            int id = mqlCommandManager.ExecCommand(MQLCommand.WindowYOnDropped_1, parameters); // MQLCommand ENUM = 106
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = Convert.ToInt32(mqlCommandManager.GetCommandResult(id));
            return result;
        }
        /// <summary>
        /// Function: OrderClose
        /// Description: Closes opened order.
        /// URL: http://mm.l/mql4/docs.mql4.com/trading/orderclose.html
        /// </summary>
        /// <param name="ticket">[in] Unique number of the order ticket.</param>
        /// <param name="lots">[in] Number of lots.</param>
        /// <param name="price">[in] Closing price.</param>
        /// <param name="slippage">[in] Value of the maximum price slippage in points.</param>
        /// <param name="arrow_color">[in] Color of the closing arrow on the chart. If the parameter is missing or has CLR_NONE value closing arrow will not be drawn on the chart.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/orderclose")]
        public void Handle_OrderClose_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, OrderClose_1(context, chartid));
        }

        /// <summary>
        /// Function: OrderClose
        /// Description: Closes opened order.
        /// URL: http://mm.l/mql4/docs.mql4.com/trading/orderclose.html
        /// </summary>
        /// <param name="ticket">[in] Unique number of the order ticket.</param>
        /// <param name="lots">[in] Number of lots.</param>
        /// <param name="price">[in] Closing price.</param>
        /// <param name="slippage">[in] Value of the maximum price slippage in points.</param>
        /// <param name="arrow_color">[in] Color of the closing arrow on the chart. If the parameter is missing or has CLR_NONE value closing arrow will not be drawn on the chart.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/orderclose")]
        public void Handle_OrderClose_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, OrderClose_1(context, DEFAULT_CHART_ID));
        }

        private JObject OrderClose_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            parameters.Add(payload["ticket"]);
            parameters.Add(payload["lots"]);
            parameters.Add(payload["price"]);
            parameters.Add(payload["slippage"]);
            parameters.Add(payload["arrow_color"]);
            int id = mqlCommandManager.ExecCommand(MQLCommand.OrderClose_1, parameters); // MQLCommand ENUM = 107
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = (bool)mqlCommandManager.GetCommandResult(id);
            return result;
        }
        /// <summary>
        /// Function: OrderCloseBy
        /// Description: Closes an opened order by another opposite opened order.
        /// URL: http://mm.l/mql4/docs.mql4.com/trading/ordercloseby.html
        /// </summary>
        /// <param name="ticket">[in] Unique number of the order ticket.</param>
        /// <param name="opposite">[in] Unique number of the opposite order ticket.</param>
        /// <param name="arrow_color">[in] Color of the closing arrow on the chart. If the parameter is missing or has CLR_NONE value closing arrow will not be drawn on the chart.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/ordercloseby")]
        public void Handle_OrderCloseBy_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, OrderCloseBy_1(context, chartid));
        }

        /// <summary>
        /// Function: OrderCloseBy
        /// Description: Closes an opened order by another opposite opened order.
        /// URL: http://mm.l/mql4/docs.mql4.com/trading/ordercloseby.html
        /// </summary>
        /// <param name="ticket">[in] Unique number of the order ticket.</param>
        /// <param name="opposite">[in] Unique number of the opposite order ticket.</param>
        /// <param name="arrow_color">[in] Color of the closing arrow on the chart. If the parameter is missing or has CLR_NONE value closing arrow will not be drawn on the chart.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/ordercloseby")]
        public void Handle_OrderCloseBy_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, OrderCloseBy_1(context, DEFAULT_CHART_ID));
        }

        private JObject OrderCloseBy_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            parameters.Add(payload["ticket"]);
            parameters.Add(payload["opposite"]);
            parameters.Add(payload["arrow_color"]);
            int id = mqlCommandManager.ExecCommand(MQLCommand.OrderCloseBy_1, parameters); // MQLCommand ENUM = 108
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = (bool)mqlCommandManager.GetCommandResult(id);
            return result;
        }
        /// <summary>
        /// Function: OrderClosePrice
        /// Description: Returns close price of the currently selected order.
        /// URL: http://mm.l/mql4/docs.mql4.com/trading/ordercloseprice.html
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/ordercloseprice")]
        public void Handle_OrderClosePrice_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, OrderClosePrice_1(context, chartid));
        }

        /// <summary>
        /// Function: OrderClosePrice
        /// Description: Returns close price of the currently selected order.
        /// URL: http://mm.l/mql4/docs.mql4.com/trading/ordercloseprice.html
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/ordercloseprice")]
        public void Handle_OrderClosePrice_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, OrderClosePrice_1(context, DEFAULT_CHART_ID));
        }

        private JObject OrderClosePrice_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            int id = mqlCommandManager.ExecCommand(MQLCommand.OrderClosePrice_1, parameters); // MQLCommand ENUM = 109
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = Convert.ToDecimal(mqlCommandManager.GetCommandResult(id));
            return result;
        }
        /// <summary>
        /// Function: OrderCloseTime
        /// Description: Returns close time of the currently selected order.
        /// URL: http://mm.l/mql4/docs.mql4.com/trading/orderclosetime.html
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/orderclosetime")]
        public void Handle_OrderCloseTime_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, OrderCloseTime_1(context, chartid));
        }

        /// <summary>
        /// Function: OrderCloseTime
        /// Description: Returns close time of the currently selected order.
        /// URL: http://mm.l/mql4/docs.mql4.com/trading/orderclosetime.html
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/orderclosetime")]
        public void Handle_OrderCloseTime_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, OrderCloseTime_1(context, DEFAULT_CHART_ID));
        }

        private JObject OrderCloseTime_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            int id = mqlCommandManager.ExecCommand(MQLCommand.OrderCloseTime_1, parameters); // MQLCommand ENUM = 110
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = (DateTime)mqlCommandManager.GetCommandResult(id);
            return result;
        }
        /// <summary>
        /// Function: OrderComment
        /// Description: Returns comment of the currently selected order.
        /// URL: http://mm.l/mql4/docs.mql4.com/trading/ordercomment.html
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/ordercomment")]
        public void Handle_OrderComment_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, OrderComment_1(context, chartid));
        }

        /// <summary>
        /// Function: OrderComment
        /// Description: Returns comment of the currently selected order.
        /// URL: http://mm.l/mql4/docs.mql4.com/trading/ordercomment.html
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/ordercomment")]
        public void Handle_OrderComment_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, OrderComment_1(context, DEFAULT_CHART_ID));
        }

        private JObject OrderComment_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            int id = mqlCommandManager.ExecCommand(MQLCommand.OrderComment_1, parameters); // MQLCommand ENUM = 111
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = (string)mqlCommandManager.GetCommandResult(id);
            return result;
        }
        /// <summary>
        /// Function: OrderCommission
        /// Description: Returns calculated commission of the currently selected order.
        /// URL: http://mm.l/mql4/docs.mql4.com/trading/ordercommission.html
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/ordercommission")]
        public void Handle_OrderCommission_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, OrderCommission_1(context, chartid));
        }

        /// <summary>
        /// Function: OrderCommission
        /// Description: Returns calculated commission of the currently selected order.
        /// URL: http://mm.l/mql4/docs.mql4.com/trading/ordercommission.html
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/ordercommission")]
        public void Handle_OrderCommission_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, OrderCommission_1(context, DEFAULT_CHART_ID));
        }

        private JObject OrderCommission_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            int id = mqlCommandManager.ExecCommand(MQLCommand.OrderCommission_1, parameters); // MQLCommand ENUM = 112
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = Convert.ToDecimal(mqlCommandManager.GetCommandResult(id));
            return result;
        }
        /// <summary>
        /// Function: OrderDelete
        /// Description: Deletes previously opened pending order.
        /// URL: http://mm.l/mql4/docs.mql4.com/trading/orderdelete.html
        /// </summary>
        /// <param name="ticket">[in] Unique number of the order ticket.</param>
        /// <param name="arrow_color">[in] Color of the arrow on the chart. If the parameter is missing or has CLR_NONE value arrow will not be drawn on the chart.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/orderdelete")]
        public void Handle_OrderDelete_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, OrderDelete_1(context, chartid));
        }

        /// <summary>
        /// Function: OrderDelete
        /// Description: Deletes previously opened pending order.
        /// URL: http://mm.l/mql4/docs.mql4.com/trading/orderdelete.html
        /// </summary>
        /// <param name="ticket">[in] Unique number of the order ticket.</param>
        /// <param name="arrow_color">[in] Color of the arrow on the chart. If the parameter is missing or has CLR_NONE value arrow will not be drawn on the chart.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/orderdelete")]
        public void Handle_OrderDelete_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, OrderDelete_1(context, DEFAULT_CHART_ID));
        }

        private JObject OrderDelete_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            parameters.Add(payload["ticket"]);
            parameters.Add(payload["arrow_color"]);
            int id = mqlCommandManager.ExecCommand(MQLCommand.OrderDelete_1, parameters); // MQLCommand ENUM = 113
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = (bool)mqlCommandManager.GetCommandResult(id);
            return result;
        }
        /// <summary>
        /// Function: OrderExpiration
        /// Description: Returns expiration date of the selected pending order.
        /// URL: http://mm.l/mql4/docs.mql4.com/trading/orderexpiration.html
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/orderexpiration")]
        public void Handle_OrderExpiration_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, OrderExpiration_1(context, chartid));
        }

        /// <summary>
        /// Function: OrderExpiration
        /// Description: Returns expiration date of the selected pending order.
        /// URL: http://mm.l/mql4/docs.mql4.com/trading/orderexpiration.html
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/orderexpiration")]
        public void Handle_OrderExpiration_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, OrderExpiration_1(context, DEFAULT_CHART_ID));
        }

        private JObject OrderExpiration_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            int id = mqlCommandManager.ExecCommand(MQLCommand.OrderExpiration_1, parameters); // MQLCommand ENUM = 114
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = (DateTime)mqlCommandManager.GetCommandResult(id);
            return result;
        }
        /// <summary>
        /// Function: OrderLots
        /// Description: Returns amount of lots of the selected order.
        /// URL: http://mm.l/mql4/docs.mql4.com/trading/orderlots.html
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/orderlots")]
        public void Handle_OrderLots_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, OrderLots_1(context, chartid));
        }

        /// <summary>
        /// Function: OrderLots
        /// Description: Returns amount of lots of the selected order.
        /// URL: http://mm.l/mql4/docs.mql4.com/trading/orderlots.html
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/orderlots")]
        public void Handle_OrderLots_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, OrderLots_1(context, DEFAULT_CHART_ID));
        }

        private JObject OrderLots_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            int id = mqlCommandManager.ExecCommand(MQLCommand.OrderLots_1, parameters); // MQLCommand ENUM = 115
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = Convert.ToDecimal(mqlCommandManager.GetCommandResult(id));
            return result;
        }
        /// <summary>
        /// Function: OrderMagicNumber
        /// Description: Returns an identifying (magic) number of the currently selected order.
        /// URL: http://mm.l/mql4/docs.mql4.com/trading/ordermagicnumber.html
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/ordermagicnumber")]
        public void Handle_OrderMagicNumber_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, OrderMagicNumber_1(context, chartid));
        }

        /// <summary>
        /// Function: OrderMagicNumber
        /// Description: Returns an identifying (magic) number of the currently selected order.
        /// URL: http://mm.l/mql4/docs.mql4.com/trading/ordermagicnumber.html
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/ordermagicnumber")]
        public void Handle_OrderMagicNumber_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, OrderMagicNumber_1(context, DEFAULT_CHART_ID));
        }

        private JObject OrderMagicNumber_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            int id = mqlCommandManager.ExecCommand(MQLCommand.OrderMagicNumber_1, parameters); // MQLCommand ENUM = 116
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = Convert.ToInt32(mqlCommandManager.GetCommandResult(id));
            return result;
        }
        /// <summary>
        /// Function: OrderModify
        /// Description: Modification of characteristics of the previously opened or pending orders.
        /// URL: http://mm.l/mql4/docs.mql4.com/trading/ordermodify.html
        /// </summary>
        /// <param name="ticket">[in] Unique number of the order ticket.</param>
        /// <param name="price">[in] New open price of the pending order.</param>
        /// <param name="stoploss">[in] New StopLoss level.</param>
        /// <param name="takeprofit">[in] New TakeProfit level.</param>
        /// <param name="expiration">[in] Pending order expiration time.</param>
        /// <param name="arrow_color">[in] Arrow color for StopLoss/TakeProfit modifications in the chart. If the parameter is missing or has CLR_NONE value, the arrows will not be shown in the chart.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/ordermodify")]
        public void Handle_OrderModify_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, OrderModify_1(context, chartid));
        }

        /// <summary>
        /// Function: OrderModify
        /// Description: Modification of characteristics of the previously opened or pending orders.
        /// URL: http://mm.l/mql4/docs.mql4.com/trading/ordermodify.html
        /// </summary>
        /// <param name="ticket">[in] Unique number of the order ticket.</param>
        /// <param name="price">[in] New open price of the pending order.</param>
        /// <param name="stoploss">[in] New StopLoss level.</param>
        /// <param name="takeprofit">[in] New TakeProfit level.</param>
        /// <param name="expiration">[in] Pending order expiration time.</param>
        /// <param name="arrow_color">[in] Arrow color for StopLoss/TakeProfit modifications in the chart. If the parameter is missing or has CLR_NONE value, the arrows will not be shown in the chart.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/ordermodify")]
        public void Handle_OrderModify_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, OrderModify_1(context, DEFAULT_CHART_ID));
        }

        private JObject OrderModify_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            parameters.Add(payload["ticket"]);
            parameters.Add(payload["price"]);
            parameters.Add(payload["stoploss"]);
            parameters.Add(payload["takeprofit"]);
            parameters.Add(payload["expiration"]);
            parameters.Add(payload["arrow_color"]);
            int id = mqlCommandManager.ExecCommand(MQLCommand.OrderModify_1, parameters); // MQLCommand ENUM = 117
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = (bool)mqlCommandManager.GetCommandResult(id);
            return result;
        }
        /// <summary>
        /// Function: OrderOpenPrice
        /// Description: Returns open price of the currently selected order.
        /// URL: http://mm.l/mql4/docs.mql4.com/trading/orderopenprice.html
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/orderopenprice")]
        public void Handle_OrderOpenPrice_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, OrderOpenPrice_1(context, chartid));
        }

        /// <summary>
        /// Function: OrderOpenPrice
        /// Description: Returns open price of the currently selected order.
        /// URL: http://mm.l/mql4/docs.mql4.com/trading/orderopenprice.html
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/orderopenprice")]
        public void Handle_OrderOpenPrice_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, OrderOpenPrice_1(context, DEFAULT_CHART_ID));
        }

        private JObject OrderOpenPrice_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            int id = mqlCommandManager.ExecCommand(MQLCommand.OrderOpenPrice_1, parameters); // MQLCommand ENUM = 118
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = Convert.ToDecimal(mqlCommandManager.GetCommandResult(id));
            return result;
        }
        /// <summary>
        /// Function: OrderOpenTime
        /// Description: Returns open time of the currently selected order.
        /// URL: http://mm.l/mql4/docs.mql4.com/trading/orderopentime.html
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/orderopentime")]
        public void Handle_OrderOpenTime_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, OrderOpenTime_1(context, chartid));
        }

        /// <summary>
        /// Function: OrderOpenTime
        /// Description: Returns open time of the currently selected order.
        /// URL: http://mm.l/mql4/docs.mql4.com/trading/orderopentime.html
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/orderopentime")]
        public void Handle_OrderOpenTime_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, OrderOpenTime_1(context, DEFAULT_CHART_ID));
        }

        private JObject OrderOpenTime_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            int id = mqlCommandManager.ExecCommand(MQLCommand.OrderOpenTime_1, parameters); // MQLCommand ENUM = 119
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = (DateTime)mqlCommandManager.GetCommandResult(id);
            return result;
        }
        /// <summary>
        /// Function: OrderPrint
        /// Description: Prints information about the selected order in the log.
        /// URL: http://mm.l/mql4/docs.mql4.com/trading/orderprint.html
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/orderprint")]
        public void Handle_OrderPrint_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, OrderPrint_1(context, chartid));
        }

        /// <summary>
        /// Function: OrderPrint
        /// Description: Prints information about the selected order in the log.
        /// URL: http://mm.l/mql4/docs.mql4.com/trading/orderprint.html
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/orderprint")]
        public void Handle_OrderPrint_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, OrderPrint_1(context, DEFAULT_CHART_ID));
        }

        private JObject OrderPrint_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            int id = mqlCommandManager.ExecCommand(MQLCommand.OrderPrint_1, parameters); // MQLCommand ENUM = 120
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = "";
            return result;
        }
        /// <summary>
        /// Function: OrderProfit
        /// Description: Returns profit of the currently selected order.
        /// URL: http://mm.l/mql4/docs.mql4.com/trading/orderprofit.html
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/orderprofit")]
        public void Handle_OrderProfit_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, OrderProfit_1(context, chartid));
        }

        /// <summary>
        /// Function: OrderProfit
        /// Description: Returns profit of the currently selected order.
        /// URL: http://mm.l/mql4/docs.mql4.com/trading/orderprofit.html
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/orderprofit")]
        public void Handle_OrderProfit_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, OrderProfit_1(context, DEFAULT_CHART_ID));
        }

        private JObject OrderProfit_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            int id = mqlCommandManager.ExecCommand(MQLCommand.OrderProfit_1, parameters); // MQLCommand ENUM = 121
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = Convert.ToDecimal(mqlCommandManager.GetCommandResult(id));
            return result;
        }
        /// <summary>
        /// Function: OrderSelect
        /// Description: The function selects an order for further processing.
        /// URL: http://mm.l/mql4/docs.mql4.com/trading/orderselect.html
        /// </summary>
        /// <param name="index"></param>
        /// <param name="select">[in] Selecting flags. It can be any of the following values:</param>
        /// <param name="pool">SELECT_BY_POS - index in the order pool, SELECT_BY_TICKET - index is order ticket.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/orderselect")]
        public void Handle_OrderSelect_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, OrderSelect_1(context, chartid));
        }

        /// <summary>
        /// Function: OrderSelect
        /// Description: The function selects an order for further processing.
        /// URL: http://mm.l/mql4/docs.mql4.com/trading/orderselect.html
        /// </summary>
        /// <param name="index"></param>
        /// <param name="select">[in] Selecting flags. It can be any of the following values:</param>
        /// <param name="pool">SELECT_BY_POS - index in the order pool, SELECT_BY_TICKET - index is order ticket.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/orderselect")]
        public void Handle_OrderSelect_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, OrderSelect_1(context, DEFAULT_CHART_ID));
        }

        private JObject OrderSelect_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            parameters.Add(payload["index"]);
            parameters.Add(payload["select"]);
            parameters.Add(payload["pool"]);
            int id = mqlCommandManager.ExecCommand(MQLCommand.OrderSelect_1, parameters); // MQLCommand ENUM = 122
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = (bool)mqlCommandManager.GetCommandResult(id);
            return result;
        }
        /// <summary>
        /// Function: OrderSend
        /// Description: The main function used to open market or place a pending order.
        /// URL: http://mm.l/mql4/docs.mql4.com/trading/ordersend.html
        /// </summary>
        /// <param name="symbol">[in] Symbol for trading.</param>
        /// <param name="cmd">[in] Operation type. It can be any of the enumeration.</param>
        /// <param name="volume">[in] Number of lots.</param>
        /// <param name="price">[in] Order price.</param>
        /// <param name="slippage">[in] Maximum price slippage for buy or sell orders.</param>
        /// <param name="stoploss">[in] Stop loss level.</param>
        /// <param name="takeprofit">[in] Take profit level.</param>
        /// <param name="comment">[in] Order comment text. Last part of the comment may be changed by server.</param>
        /// <param name="magic">[in] Order magic number. May be used as user defined identifier.</param>
        /// <param name="expiration">[in] Order expiration time (for pending orders only).</param>
        /// <param name="arrow_color">[in] Color of the opening arrow on the chart. If parameter is missing or has CLR_NONE value opening arrow is not drawn on the chart.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/ordersend")]
        public void Handle_OrderSend_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, OrderSend_1(context, chartid));
        }

        /// <summary>
        /// Function: OrderSend
        /// Description: The main function used to open market or place a pending order.
        /// URL: http://mm.l/mql4/docs.mql4.com/trading/ordersend.html
        /// </summary>
        /// <param name="symbol">[in] Symbol for trading.</param>
        /// <param name="cmd">[in] Operation type. It can be any of the enumeration.</param>
        /// <param name="volume">[in] Number of lots.</param>
        /// <param name="price">[in] Order price.</param>
        /// <param name="slippage">[in] Maximum price slippage for buy or sell orders.</param>
        /// <param name="stoploss">[in] Stop loss level.</param>
        /// <param name="takeprofit">[in] Take profit level.</param>
        /// <param name="comment">[in] Order comment text. Last part of the comment may be changed by server.</param>
        /// <param name="magic">[in] Order magic number. May be used as user defined identifier.</param>
        /// <param name="expiration">[in] Order expiration time (for pending orders only).</param>
        /// <param name="arrow_color">[in] Color of the opening arrow on the chart. If parameter is missing or has CLR_NONE value opening arrow is not drawn on the chart.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/ordersend")]
        public void Handle_OrderSend_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, OrderSend_1(context, DEFAULT_CHART_ID));
        }

        private JObject OrderSend_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            parameters.Add(payload["symbol"]);
            parameters.Add(payload["cmd"]);
            parameters.Add(payload["volume"]);
            parameters.Add(payload["price"]);
            parameters.Add(payload["slippage"]);
            parameters.Add(payload["stoploss"]);
            parameters.Add(payload["takeprofit"]);
            parameters.Add(payload["comment"]);
            parameters.Add(payload["magic"]);
            parameters.Add(payload["expiration"]);
            parameters.Add(payload["arrow_color"]);
            int id = mqlCommandManager.ExecCommand(MQLCommand.OrderSend_1, parameters); // MQLCommand ENUM = 123
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = Convert.ToInt32(mqlCommandManager.GetCommandResult(id));
            return result;
        }
        /// <summary>
        /// Function: OrdersHistoryTotal
        /// Description: Returns the number of closed orders in the account history loaded into the terminal.
        /// URL: http://mm.l/mql4/docs.mql4.com/trading/ordershistorytotal.html
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/ordershistorytotal")]
        public void Handle_OrdersHistoryTotal_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, OrdersHistoryTotal_1(context, chartid));
        }

        /// <summary>
        /// Function: OrdersHistoryTotal
        /// Description: Returns the number of closed orders in the account history loaded into the terminal.
        /// URL: http://mm.l/mql4/docs.mql4.com/trading/ordershistorytotal.html
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/ordershistorytotal")]
        public void Handle_OrdersHistoryTotal_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, OrdersHistoryTotal_1(context, DEFAULT_CHART_ID));
        }

        private JObject OrdersHistoryTotal_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            int id = mqlCommandManager.ExecCommand(MQLCommand.OrdersHistoryTotal_1, parameters); // MQLCommand ENUM = 124
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = Convert.ToInt32(mqlCommandManager.GetCommandResult(id));
            return result;
        }
        /// <summary>
        /// Function: OrderStopLoss
        /// Description: Returns stop loss value of the currently selected order.
        /// URL: http://mm.l/mql4/docs.mql4.com/trading/orderstoploss.html
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/orderstoploss")]
        public void Handle_OrderStopLoss_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, OrderStopLoss_1(context, chartid));
        }

        /// <summary>
        /// Function: OrderStopLoss
        /// Description: Returns stop loss value of the currently selected order.
        /// URL: http://mm.l/mql4/docs.mql4.com/trading/orderstoploss.html
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/orderstoploss")]
        public void Handle_OrderStopLoss_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, OrderStopLoss_1(context, DEFAULT_CHART_ID));
        }

        private JObject OrderStopLoss_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            int id = mqlCommandManager.ExecCommand(MQLCommand.OrderStopLoss_1, parameters); // MQLCommand ENUM = 125
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = Convert.ToDecimal(mqlCommandManager.GetCommandResult(id));
            return result;
        }
        /// <summary>
        /// Function: OrdersTotal
        /// Description: Returns the number of market and pending orders.
        /// URL: http://mm.l/mql4/docs.mql4.com/trading/orderstotal.html
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/orderstotal")]
        public void Handle_OrdersTotal_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, OrdersTotal_1(context, chartid));
        }

        /// <summary>
        /// Function: OrdersTotal
        /// Description: Returns the number of market and pending orders.
        /// URL: http://mm.l/mql4/docs.mql4.com/trading/orderstotal.html
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/orderstotal")]
        public void Handle_OrdersTotal_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, OrdersTotal_1(context, DEFAULT_CHART_ID));
        }

        private JObject OrdersTotal_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            int id = mqlCommandManager.ExecCommand(MQLCommand.OrdersTotal_1, parameters); // MQLCommand ENUM = 126
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = Convert.ToInt32(mqlCommandManager.GetCommandResult(id));
            return result;
        }
        /// <summary>
        /// Function: OrderSwap
        /// Description: Returns swap value of the currently selected order.
        /// URL: http://mm.l/mql4/docs.mql4.com/trading/orderswap.html
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/orderswap")]
        public void Handle_OrderSwap_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, OrderSwap_1(context, chartid));
        }

        /// <summary>
        /// Function: OrderSwap
        /// Description: Returns swap value of the currently selected order.
        /// URL: http://mm.l/mql4/docs.mql4.com/trading/orderswap.html
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/orderswap")]
        public void Handle_OrderSwap_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, OrderSwap_1(context, DEFAULT_CHART_ID));
        }

        private JObject OrderSwap_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            int id = mqlCommandManager.ExecCommand(MQLCommand.OrderSwap_1, parameters); // MQLCommand ENUM = 127
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = Convert.ToDecimal(mqlCommandManager.GetCommandResult(id));
            return result;
        }
        /// <summary>
        /// Function: OrderSymbol
        /// Description: Returns symbol name of the currently selected order.
        /// URL: http://mm.l/mql4/docs.mql4.com/trading/ordersymbol.html
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/ordersymbol")]
        public void Handle_OrderSymbol_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, OrderSymbol_1(context, chartid));
        }

        /// <summary>
        /// Function: OrderSymbol
        /// Description: Returns symbol name of the currently selected order.
        /// URL: http://mm.l/mql4/docs.mql4.com/trading/ordersymbol.html
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/ordersymbol")]
        public void Handle_OrderSymbol_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, OrderSymbol_1(context, DEFAULT_CHART_ID));
        }

        private JObject OrderSymbol_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            int id = mqlCommandManager.ExecCommand(MQLCommand.OrderSymbol_1, parameters); // MQLCommand ENUM = 128
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = (string)mqlCommandManager.GetCommandResult(id);
            return result;
        }
        /// <summary>
        /// Function: OrderTakeProfit
        /// Description: Returns take profit value of the currently selected order.
        /// URL: http://mm.l/mql4/docs.mql4.com/trading/ordertakeprofit.html
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/ordertakeprofit")]
        public void Handle_OrderTakeProfit_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, OrderTakeProfit_1(context, chartid));
        }

        /// <summary>
        /// Function: OrderTakeProfit
        /// Description: Returns take profit value of the currently selected order.
        /// URL: http://mm.l/mql4/docs.mql4.com/trading/ordertakeprofit.html
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/ordertakeprofit")]
        public void Handle_OrderTakeProfit_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, OrderTakeProfit_1(context, DEFAULT_CHART_ID));
        }

        private JObject OrderTakeProfit_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            int id = mqlCommandManager.ExecCommand(MQLCommand.OrderTakeProfit_1, parameters); // MQLCommand ENUM = 129
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = Convert.ToDecimal(mqlCommandManager.GetCommandResult(id));
            return result;
        }
        /// <summary>
        /// Function: OrderTicket
        /// Description: Returns ticket number of the currently selected order.
        /// URL: http://mm.l/mql4/docs.mql4.com/trading/orderticket.html
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/orderticket")]
        public void Handle_OrderTicket_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, OrderTicket_1(context, chartid));
        }

        /// <summary>
        /// Function: OrderTicket
        /// Description: Returns ticket number of the currently selected order.
        /// URL: http://mm.l/mql4/docs.mql4.com/trading/orderticket.html
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/orderticket")]
        public void Handle_OrderTicket_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, OrderTicket_1(context, DEFAULT_CHART_ID));
        }

        private JObject OrderTicket_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            int id = mqlCommandManager.ExecCommand(MQLCommand.OrderTicket_1, parameters); // MQLCommand ENUM = 130
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = Convert.ToInt32(mqlCommandManager.GetCommandResult(id));
            return result;
        }
        /// <summary>
        /// Function: OrderType
        /// Description: Returns order operation type of the currently selected order.
        /// URL: http://mm.l/mql4/docs.mql4.com/trading/ordertype.html
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/ordertype")]
        public void Handle_OrderType_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, OrderType_1(context, chartid));
        }

        /// <summary>
        /// Function: OrderType
        /// Description: Returns order operation type of the currently selected order.
        /// URL: http://mm.l/mql4/docs.mql4.com/trading/ordertype.html
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/ordertype")]
        public void Handle_OrderType_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, OrderType_1(context, DEFAULT_CHART_ID));
        }

        private JObject OrderType_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            int id = mqlCommandManager.ExecCommand(MQLCommand.OrderType_1, parameters); // MQLCommand ENUM = 131
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = Convert.ToInt32(mqlCommandManager.GetCommandResult(id));
            return result;
        }
        /// <summary>
        /// Function: SignalBaseGetDouble
        /// Description: Returns the value of
        /// URL: http://mm.l/mql4/docs.mql4.com/signals/signalbasegetdouble.html
        /// </summary>
        /// <param name="property_id">[in] Signal property identifier. The value can be one of the values of the enumeration.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/signalbasegetdouble")]
        public void Handle_SignalBaseGetDouble_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, SignalBaseGetDouble_1(context, chartid));
        }

        /// <summary>
        /// Function: SignalBaseGetDouble
        /// Description: Returns the value of
        /// URL: http://mm.l/mql4/docs.mql4.com/signals/signalbasegetdouble.html
        /// </summary>
        /// <param name="property_id">[in] Signal property identifier. The value can be one of the values of the enumeration.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/signalbasegetdouble")]
        public void Handle_SignalBaseGetDouble_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, SignalBaseGetDouble_1(context, DEFAULT_CHART_ID));
        }

        private JObject SignalBaseGetDouble_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            parameters.Add(payload["property_id"]);
            int id = mqlCommandManager.ExecCommand(MQLCommand.SignalBaseGetDouble_1, parameters); // MQLCommand ENUM = 132
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = Convert.ToDecimal(mqlCommandManager.GetCommandResult(id));
            return result;
        }
        /// <summary>
        /// Function: SignalBaseGetInteger
        /// Description: Returns the value of
        /// URL: http://mm.l/mql4/docs.mql4.com/signals/signalbasegetinteger.html
        /// </summary>
        /// <param name="property_id">[in] Signal property identifier. The value can be one of the values of the enumeration.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/signalbasegetinteger")]
        public void Handle_SignalBaseGetInteger_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, SignalBaseGetInteger_1(context, chartid));
        }

        /// <summary>
        /// Function: SignalBaseGetInteger
        /// Description: Returns the value of
        /// URL: http://mm.l/mql4/docs.mql4.com/signals/signalbasegetinteger.html
        /// </summary>
        /// <param name="property_id">[in] Signal property identifier. The value can be one of the values of the enumeration.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/signalbasegetinteger")]
        public void Handle_SignalBaseGetInteger_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, SignalBaseGetInteger_1(context, DEFAULT_CHART_ID));
        }

        private JObject SignalBaseGetInteger_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            parameters.Add(payload["property_id"]);
            int id = mqlCommandManager.ExecCommand(MQLCommand.SignalBaseGetInteger_1, parameters); // MQLCommand ENUM = 133
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = Convert.ToInt64(mqlCommandManager.GetCommandResult(id));
            return result;
        }
        /// <summary>
        /// Function: SignalBaseGetString
        /// Description: Returns the value of
        /// URL: http://mm.l/mql4/docs.mql4.com/signals/signalbasegetstring.html
        /// </summary>
        /// <param name="property_id">[in] Signal property identifier. The value can be one of the values of the enumeration.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/signalbasegetstring")]
        public void Handle_SignalBaseGetString_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, SignalBaseGetString_1(context, chartid));
        }

        /// <summary>
        /// Function: SignalBaseGetString
        /// Description: Returns the value of
        /// URL: http://mm.l/mql4/docs.mql4.com/signals/signalbasegetstring.html
        /// </summary>
        /// <param name="property_id">[in] Signal property identifier. The value can be one of the values of the enumeration.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/signalbasegetstring")]
        public void Handle_SignalBaseGetString_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, SignalBaseGetString_1(context, DEFAULT_CHART_ID));
        }

        private JObject SignalBaseGetString_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            parameters.Add(payload["property_id"]);
            int id = mqlCommandManager.ExecCommand(MQLCommand.SignalBaseGetString_1, parameters); // MQLCommand ENUM = 134
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = (string)mqlCommandManager.GetCommandResult(id);
            return result;
        }
        /// <summary>
        /// Function: SignalBaseSelect
        /// Description: Selects a signal from signals, available in terminal for further working with it.
        /// URL: http://mm.l/mql4/docs.mql4.com/signals/signalbaseselect.html
        /// </summary>
        /// <param name="index">[in] Signal index in base of trading signals.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/signalbaseselect")]
        public void Handle_SignalBaseSelect_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, SignalBaseSelect_1(context, chartid));
        }

        /// <summary>
        /// Function: SignalBaseSelect
        /// Description: Selects a signal from signals, available in terminal for further working with it.
        /// URL: http://mm.l/mql4/docs.mql4.com/signals/signalbaseselect.html
        /// </summary>
        /// <param name="index">[in] Signal index in base of trading signals.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/signalbaseselect")]
        public void Handle_SignalBaseSelect_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, SignalBaseSelect_1(context, DEFAULT_CHART_ID));
        }

        private JObject SignalBaseSelect_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            parameters.Add(payload["index"]);
            int id = mqlCommandManager.ExecCommand(MQLCommand.SignalBaseSelect_1, parameters); // MQLCommand ENUM = 135
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = (bool)mqlCommandManager.GetCommandResult(id);
            return result;
        }
        /// <summary>
        /// Function: SignalBaseTotal
        /// Description: Returns the total amount of signals, available in terminal.
        /// URL: http://mm.l/mql4/docs.mql4.com/signals/signalbasetotal.html
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/signalbasetotal")]
        public void Handle_SignalBaseTotal_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, SignalBaseTotal_1(context, chartid));
        }

        /// <summary>
        /// Function: SignalBaseTotal
        /// Description: Returns the total amount of signals, available in terminal.
        /// URL: http://mm.l/mql4/docs.mql4.com/signals/signalbasetotal.html
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/signalbasetotal")]
        public void Handle_SignalBaseTotal_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, SignalBaseTotal_1(context, DEFAULT_CHART_ID));
        }

        private JObject SignalBaseTotal_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            int id = mqlCommandManager.ExecCommand(MQLCommand.SignalBaseTotal_1, parameters); // MQLCommand ENUM = 136
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = Convert.ToInt32(mqlCommandManager.GetCommandResult(id));
            return result;
        }
        /// <summary>
        /// Function: SignalInfoGetDouble
        /// Description: Returns the value of
        /// URL: http://mm.l/mql4/docs.mql4.com/signals/signalinfogetdouble.html
        /// </summary>
        /// <param name="property_id">[in] Signal copy settings property identifier. The value can be one of the values of the enumeration.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/signalinfogetdouble")]
        public void Handle_SignalInfoGetDouble_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, SignalInfoGetDouble_1(context, chartid));
        }

        /// <summary>
        /// Function: SignalInfoGetDouble
        /// Description: Returns the value of
        /// URL: http://mm.l/mql4/docs.mql4.com/signals/signalinfogetdouble.html
        /// </summary>
        /// <param name="property_id">[in] Signal copy settings property identifier. The value can be one of the values of the enumeration.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/signalinfogetdouble")]
        public void Handle_SignalInfoGetDouble_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, SignalInfoGetDouble_1(context, DEFAULT_CHART_ID));
        }

        private JObject SignalInfoGetDouble_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            parameters.Add(payload["property_id"]);
            int id = mqlCommandManager.ExecCommand(MQLCommand.SignalInfoGetDouble_1, parameters); // MQLCommand ENUM = 137
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = Convert.ToDecimal(mqlCommandManager.GetCommandResult(id));
            return result;
        }
        /// <summary>
        /// Function: SignalInfoGetInteger
        /// Description: Returns the value of
        /// URL: http://mm.l/mql4/docs.mql4.com/signals/signalinfogetinteger.html
        /// </summary>
        /// <param name="property_id">[in] Signal copy settings property identifier. The value can be one of the values of the enumeration.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/signalinfogetinteger")]
        public void Handle_SignalInfoGetInteger_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, SignalInfoGetInteger_1(context, chartid));
        }

        /// <summary>
        /// Function: SignalInfoGetInteger
        /// Description: Returns the value of
        /// URL: http://mm.l/mql4/docs.mql4.com/signals/signalinfogetinteger.html
        /// </summary>
        /// <param name="property_id">[in] Signal copy settings property identifier. The value can be one of the values of the enumeration.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/signalinfogetinteger")]
        public void Handle_SignalInfoGetInteger_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, SignalInfoGetInteger_1(context, DEFAULT_CHART_ID));
        }

        private JObject SignalInfoGetInteger_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            parameters.Add(payload["property_id"]);
            int id = mqlCommandManager.ExecCommand(MQLCommand.SignalInfoGetInteger_1, parameters); // MQLCommand ENUM = 138
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = Convert.ToInt64(mqlCommandManager.GetCommandResult(id));
            return result;
        }
        /// <summary>
        /// Function: SignalInfoGetString
        /// Description: Returns the value of
        /// URL: http://mm.l/mql4/docs.mql4.com/signals/signalinfogetstring.html
        /// </summary>
        /// <param name="property_id">[in] Signal copy settings property identifier. The value can be one of the values of the enumeration.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/signalinfogetstring")]
        public void Handle_SignalInfoGetString_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, SignalInfoGetString_1(context, chartid));
        }

        /// <summary>
        /// Function: SignalInfoGetString
        /// Description: Returns the value of
        /// URL: http://mm.l/mql4/docs.mql4.com/signals/signalinfogetstring.html
        /// </summary>
        /// <param name="property_id">[in] Signal copy settings property identifier. The value can be one of the values of the enumeration.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/signalinfogetstring")]
        public void Handle_SignalInfoGetString_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, SignalInfoGetString_1(context, DEFAULT_CHART_ID));
        }

        private JObject SignalInfoGetString_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            parameters.Add(payload["property_id"]);
            int id = mqlCommandManager.ExecCommand(MQLCommand.SignalInfoGetString_1, parameters); // MQLCommand ENUM = 139
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = (string)mqlCommandManager.GetCommandResult(id);
            return result;
        }
        /// <summary>
        /// Function: SignalInfoSetDouble
        /// Description: Sets the value of
        /// URL: http://mm.l/mql4/docs.mql4.com/signals/signalinfosetdouble.html
        /// </summary>
        /// <param name="property_id">[in] Signal copy settings property identifier. The value can be one of the values of the enumeration.</param>
        /// <param name="value">[in] The value of signal copy settings property.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/signalinfosetdouble")]
        public void Handle_SignalInfoSetDouble_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, SignalInfoSetDouble_1(context, chartid));
        }

        /// <summary>
        /// Function: SignalInfoSetDouble
        /// Description: Sets the value of
        /// URL: http://mm.l/mql4/docs.mql4.com/signals/signalinfosetdouble.html
        /// </summary>
        /// <param name="property_id">[in] Signal copy settings property identifier. The value can be one of the values of the enumeration.</param>
        /// <param name="value">[in] The value of signal copy settings property.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/signalinfosetdouble")]
        public void Handle_SignalInfoSetDouble_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, SignalInfoSetDouble_1(context, DEFAULT_CHART_ID));
        }

        private JObject SignalInfoSetDouble_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            parameters.Add(payload["property_id"]);
            parameters.Add(payload["value"]);
            int id = mqlCommandManager.ExecCommand(MQLCommand.SignalInfoSetDouble_1, parameters); // MQLCommand ENUM = 140
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = (bool)mqlCommandManager.GetCommandResult(id);
            return result;
        }
        /// <summary>
        /// Function: SignalInfoSetInteger
        /// Description: Sets the value of
        /// URL: http://mm.l/mql4/docs.mql4.com/signals/signalinfosetinteger.html
        /// </summary>
        /// <param name="property_id">[in] Signal copy settings property identifier. The value can be one of the values of the enumeration.</param>
        /// <param name="value">[in] The value of signal copy settings property.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/signalinfosetinteger")]
        public void Handle_SignalInfoSetInteger_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, SignalInfoSetInteger_1(context, chartid));
        }

        /// <summary>
        /// Function: SignalInfoSetInteger
        /// Description: Sets the value of
        /// URL: http://mm.l/mql4/docs.mql4.com/signals/signalinfosetinteger.html
        /// </summary>
        /// <param name="property_id">[in] Signal copy settings property identifier. The value can be one of the values of the enumeration.</param>
        /// <param name="value">[in] The value of signal copy settings property.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/signalinfosetinteger")]
        public void Handle_SignalInfoSetInteger_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, SignalInfoSetInteger_1(context, DEFAULT_CHART_ID));
        }

        private JObject SignalInfoSetInteger_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            parameters.Add(payload["property_id"]);
            parameters.Add(payload["value"]);
            int id = mqlCommandManager.ExecCommand(MQLCommand.SignalInfoSetInteger_1, parameters); // MQLCommand ENUM = 141
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = (bool)mqlCommandManager.GetCommandResult(id);
            return result;
        }
        /// <summary>
        /// Function: SignalSubscribe
        /// Description: Subscribes to the trading signal.
        /// URL: http://mm.l/mql4/docs.mql4.com/signals/signalsubscribe.html
        /// </summary>
        /// <param name="signal_id">[in] Signal identifier.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/signalsubscribe")]
        public void Handle_SignalSubscribe_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, SignalSubscribe_1(context, chartid));
        }

        /// <summary>
        /// Function: SignalSubscribe
        /// Description: Subscribes to the trading signal.
        /// URL: http://mm.l/mql4/docs.mql4.com/signals/signalsubscribe.html
        /// </summary>
        /// <param name="signal_id">[in] Signal identifier.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/signalsubscribe")]
        public void Handle_SignalSubscribe_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, SignalSubscribe_1(context, DEFAULT_CHART_ID));
        }

        private JObject SignalSubscribe_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            parameters.Add(payload["signal_id"]);
            int id = mqlCommandManager.ExecCommand(MQLCommand.SignalSubscribe_1, parameters); // MQLCommand ENUM = 142
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = (bool)mqlCommandManager.GetCommandResult(id);
            return result;
        }
        /// <summary>
        /// Function: SignalUnsubscribe
        /// Description: Cancels subscription.
        /// URL: http://mm.l/mql4/docs.mql4.com/signals/signalunsubscribe.html
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/signalunsubscribe")]
        public void Handle_SignalUnsubscribe_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, SignalUnsubscribe_1(context, chartid));
        }

        /// <summary>
        /// Function: SignalUnsubscribe
        /// Description: Cancels subscription.
        /// URL: http://mm.l/mql4/docs.mql4.com/signals/signalunsubscribe.html
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/signalunsubscribe")]
        public void Handle_SignalUnsubscribe_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, SignalUnsubscribe_1(context, DEFAULT_CHART_ID));
        }

        private JObject SignalUnsubscribe_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            int id = mqlCommandManager.ExecCommand(MQLCommand.SignalUnsubscribe_1, parameters); // MQLCommand ENUM = 143
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = (bool)mqlCommandManager.GetCommandResult(id);
            return result;
        }
        /// <summary>
        /// Function: GlobalVariableCheck
        /// Description: Checks the existence of a global variable with the specified name
        /// URL: http://mm.l/mql4/docs.mql4.com/globals/globalvariablecheck.html
        /// </summary>
        /// <param name="name">[in] Global variable name.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/globalvariablecheck")]
        public void Handle_GlobalVariableCheck_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, GlobalVariableCheck_1(context, chartid));
        }

        /// <summary>
        /// Function: GlobalVariableCheck
        /// Description: Checks the existence of a global variable with the specified name
        /// URL: http://mm.l/mql4/docs.mql4.com/globals/globalvariablecheck.html
        /// </summary>
        /// <param name="name">[in] Global variable name.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/globalvariablecheck")]
        public void Handle_GlobalVariableCheck_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, GlobalVariableCheck_1(context, DEFAULT_CHART_ID));
        }

        private JObject GlobalVariableCheck_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            parameters.Add(payload["name"]);
            int id = mqlCommandManager.ExecCommand(MQLCommand.GlobalVariableCheck_1, parameters); // MQLCommand ENUM = 144
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = (bool)mqlCommandManager.GetCommandResult(id);
            return result;
        }
        /// <summary>
        /// Function: GlobalVariableTime
        /// Description: Returns the time when the global variable was last accessed.
        /// URL: http://mm.l/mql4/docs.mql4.com/globals/globalvariabletime.html
        /// </summary>
        /// <param name="name">[in] Name of the global variable.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/globalvariabletime")]
        public void Handle_GlobalVariableTime_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, GlobalVariableTime_1(context, chartid));
        }

        /// <summary>
        /// Function: GlobalVariableTime
        /// Description: Returns the time when the global variable was last accessed.
        /// URL: http://mm.l/mql4/docs.mql4.com/globals/globalvariabletime.html
        /// </summary>
        /// <param name="name">[in] Name of the global variable.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/globalvariabletime")]
        public void Handle_GlobalVariableTime_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, GlobalVariableTime_1(context, DEFAULT_CHART_ID));
        }

        private JObject GlobalVariableTime_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            parameters.Add(payload["name"]);
            int id = mqlCommandManager.ExecCommand(MQLCommand.GlobalVariableTime_1, parameters); // MQLCommand ENUM = 145
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = (DateTime)mqlCommandManager.GetCommandResult(id);
            return result;
        }
        /// <summary>
        /// Function: GlobalVariableDel
        /// Description: Deletes a global variable from the client terminal
        /// URL: http://mm.l/mql4/docs.mql4.com/globals/globalvariabledel.html
        /// </summary>
        /// <param name="name">[in] Global variable name.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/globalvariabledel")]
        public void Handle_GlobalVariableDel_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, GlobalVariableDel_1(context, chartid));
        }

        /// <summary>
        /// Function: GlobalVariableDel
        /// Description: Deletes a global variable from the client terminal
        /// URL: http://mm.l/mql4/docs.mql4.com/globals/globalvariabledel.html
        /// </summary>
        /// <param name="name">[in] Global variable name.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/globalvariabledel")]
        public void Handle_GlobalVariableDel_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, GlobalVariableDel_1(context, DEFAULT_CHART_ID));
        }

        private JObject GlobalVariableDel_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            parameters.Add(payload["name"]);
            int id = mqlCommandManager.ExecCommand(MQLCommand.GlobalVariableDel_1, parameters); // MQLCommand ENUM = 146
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = (bool)mqlCommandManager.GetCommandResult(id);
            return result;
        }
        /// <summary>
        /// Function: GlobalVariableGet
        /// Description: Returns the value of an existing global variable of the client terminal. There are 2 variants of the function.
        /// URL: http://mm.l/mql4/docs.mql4.com/globals/globalvariableget.html
        /// </summary>
        /// <param name="name">[in] Global variable name.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/globalvariableget")]
        public void Handle_GlobalVariableGet_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, GlobalVariableGet_1(context, chartid));
        }

        /// <summary>
        /// Function: GlobalVariableGet
        /// Description: Returns the value of an existing global variable of the client terminal. There are 2 variants of the function.
        /// URL: http://mm.l/mql4/docs.mql4.com/globals/globalvariableget.html
        /// </summary>
        /// <param name="name">[in] Global variable name.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/globalvariableget")]
        public void Handle_GlobalVariableGet_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, GlobalVariableGet_1(context, DEFAULT_CHART_ID));
        }

        private JObject GlobalVariableGet_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            parameters.Add(payload["name"]);
            int id = mqlCommandManager.ExecCommand(MQLCommand.GlobalVariableGet_1, parameters); // MQLCommand ENUM = 147
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = Convert.ToDecimal(mqlCommandManager.GetCommandResult(id));
            return result;
        }
        /// <summary>
        /// Function: GlobalVariableName
        /// Description: Returns the name of a global variable by its ordinal number.
        /// URL: http://mm.l/mql4/docs.mql4.com/globals/globalvariablename.html
        /// </summary>
        /// <param name="index">[in] Sequence number in the list of global variables. It should be greater than or equal to 0 and less than .</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/globalvariablename")]
        public void Handle_GlobalVariableName_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, GlobalVariableName_1(context, chartid));
        }

        /// <summary>
        /// Function: GlobalVariableName
        /// Description: Returns the name of a global variable by its ordinal number.
        /// URL: http://mm.l/mql4/docs.mql4.com/globals/globalvariablename.html
        /// </summary>
        /// <param name="index">[in] Sequence number in the list of global variables. It should be greater than or equal to 0 and less than .</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/globalvariablename")]
        public void Handle_GlobalVariableName_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, GlobalVariableName_1(context, DEFAULT_CHART_ID));
        }

        private JObject GlobalVariableName_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            parameters.Add(payload["index"]);
            int id = mqlCommandManager.ExecCommand(MQLCommand.GlobalVariableName_1, parameters); // MQLCommand ENUM = 148
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = (string)mqlCommandManager.GetCommandResult(id);
            return result;
        }
        /// <summary>
        /// Function: GlobalVariableSet
        /// Description: Sets a new value for a global variable. If the variable does not exist, the system creates a new global variable.
        /// URL: http://mm.l/mql4/docs.mql4.com/globals/globalvariableset.html
        /// </summary>
        /// <param name="name">[in] Global variable name.</param>
        /// <param name="value">[in] The new numerical value.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/globalvariableset")]
        public void Handle_GlobalVariableSet_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, GlobalVariableSet_1(context, chartid));
        }

        /// <summary>
        /// Function: GlobalVariableSet
        /// Description: Sets a new value for a global variable. If the variable does not exist, the system creates a new global variable.
        /// URL: http://mm.l/mql4/docs.mql4.com/globals/globalvariableset.html
        /// </summary>
        /// <param name="name">[in] Global variable name.</param>
        /// <param name="value">[in] The new numerical value.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/globalvariableset")]
        public void Handle_GlobalVariableSet_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, GlobalVariableSet_1(context, DEFAULT_CHART_ID));
        }

        private JObject GlobalVariableSet_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            parameters.Add(payload["name"]);
            parameters.Add(payload["value"]);
            int id = mqlCommandManager.ExecCommand(MQLCommand.GlobalVariableSet_1, parameters); // MQLCommand ENUM = 149
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = (DateTime)mqlCommandManager.GetCommandResult(id);
            return result;
        }
        /// <summary>
        /// Function: GlobalVariablesFlush
        /// Description: Forcibly saves contents of all global variables to a disk.
        /// URL: http://mm.l/mql4/docs.mql4.com/globals/globalvariablesflush.html
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/globalvariablesflush")]
        public void Handle_GlobalVariablesFlush_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, GlobalVariablesFlush_1(context, chartid));
        }

        /// <summary>
        /// Function: GlobalVariablesFlush
        /// Description: Forcibly saves contents of all global variables to a disk.
        /// URL: http://mm.l/mql4/docs.mql4.com/globals/globalvariablesflush.html
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/globalvariablesflush")]
        public void Handle_GlobalVariablesFlush_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, GlobalVariablesFlush_1(context, DEFAULT_CHART_ID));
        }

        private JObject GlobalVariablesFlush_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            int id = mqlCommandManager.ExecCommand(MQLCommand.GlobalVariablesFlush_1, parameters); // MQLCommand ENUM = 150
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = "";
            return result;
        }
        /// <summary>
        /// Function: GlobalVariableTemp
        /// Description: The function attempts to create a temporary global variable. If the variable doesn't exist, the system creates a new temporary global variable.
        /// URL: http://mm.l/mql4/docs.mql4.com/globals/globalvariabletemp.html
        /// </summary>
        /// <param name="name">[in] The name of a temporary global variable.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/globalvariabletemp")]
        public void Handle_GlobalVariableTemp_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, GlobalVariableTemp_1(context, chartid));
        }

        /// <summary>
        /// Function: GlobalVariableTemp
        /// Description: The function attempts to create a temporary global variable. If the variable doesn't exist, the system creates a new temporary global variable.
        /// URL: http://mm.l/mql4/docs.mql4.com/globals/globalvariabletemp.html
        /// </summary>
        /// <param name="name">[in] The name of a temporary global variable.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/globalvariabletemp")]
        public void Handle_GlobalVariableTemp_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, GlobalVariableTemp_1(context, DEFAULT_CHART_ID));
        }

        private JObject GlobalVariableTemp_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            parameters.Add(payload["name"]);
            int id = mqlCommandManager.ExecCommand(MQLCommand.GlobalVariableTemp_1, parameters); // MQLCommand ENUM = 151
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = (bool)mqlCommandManager.GetCommandResult(id);
            return result;
        }
        /// <summary>
        /// Function: GlobalVariableSetOnCondition
        /// Description: Sets the new value of the existing global variable if the current value equals to the third parameter check_value. If there is no global variable, the function will generate an error ERR_GLOBALVARIABLE_NOT_FOUND (4501) and return false.
        /// URL: http://mm.l/mql4/docs.mql4.com/globals/globalvariablesetoncondition.html
        /// </summary>
        /// <param name="name">[in] The name of a global variable.</param>
        /// <param name="value">[in] New value.</param>
        /// <param name="check_value">[in] The value to check the current value of the global variable.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/globalvariablesetoncondition")]
        public void Handle_GlobalVariableSetOnCondition_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, GlobalVariableSetOnCondition_1(context, chartid));
        }

        /// <summary>
        /// Function: GlobalVariableSetOnCondition
        /// Description: Sets the new value of the existing global variable if the current value equals to the third parameter check_value. If there is no global variable, the function will generate an error ERR_GLOBALVARIABLE_NOT_FOUND (4501) and return false.
        /// URL: http://mm.l/mql4/docs.mql4.com/globals/globalvariablesetoncondition.html
        /// </summary>
        /// <param name="name">[in] The name of a global variable.</param>
        /// <param name="value">[in] New value.</param>
        /// <param name="check_value">[in] The value to check the current value of the global variable.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/globalvariablesetoncondition")]
        public void Handle_GlobalVariableSetOnCondition_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, GlobalVariableSetOnCondition_1(context, DEFAULT_CHART_ID));
        }

        private JObject GlobalVariableSetOnCondition_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            parameters.Add(payload["name"]);
            parameters.Add(payload["value"]);
            parameters.Add(payload["check_value"]);
            int id = mqlCommandManager.ExecCommand(MQLCommand.GlobalVariableSetOnCondition_1, parameters); // MQLCommand ENUM = 152
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = (bool)mqlCommandManager.GetCommandResult(id);
            return result;
        }
        /// <summary>
        /// Function: GlobalVariablesDeleteAll
        /// Description: Deletes global variables of the client terminal.
        /// URL: http://mm.l/mql4/docs.mql4.com/globals/globalvariablesdeleteall.html
        /// </summary>
        /// <param name="prefix_name">[in] Name prefix global variables to remove. If you specify a prefix NULL or empty string, then all variables that meet the data criterion will be deleted.</param>
        /// <param name="limit_data">[in] Optional parameter. Date to select global variables by the time of their last modification. The function removes global variables, which were changed before this date. If the parameter is zero, then all variables that meet the first criterion (prefix) are deleted.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/globalvariablesdeleteall")]
        public void Handle_GlobalVariablesDeleteAll_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, GlobalVariablesDeleteAll_1(context, chartid));
        }

        /// <summary>
        /// Function: GlobalVariablesDeleteAll
        /// Description: Deletes global variables of the client terminal.
        /// URL: http://mm.l/mql4/docs.mql4.com/globals/globalvariablesdeleteall.html
        /// </summary>
        /// <param name="prefix_name">[in] Name prefix global variables to remove. If you specify a prefix NULL or empty string, then all variables that meet the data criterion will be deleted.</param>
        /// <param name="limit_data">[in] Optional parameter. Date to select global variables by the time of their last modification. The function removes global variables, which were changed before this date. If the parameter is zero, then all variables that meet the first criterion (prefix) are deleted.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/globalvariablesdeleteall")]
        public void Handle_GlobalVariablesDeleteAll_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, GlobalVariablesDeleteAll_1(context, DEFAULT_CHART_ID));
        }

        private JObject GlobalVariablesDeleteAll_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            parameters.Add(payload["prefix_name"]);
            parameters.Add(payload["limit_data"]);
            int id = mqlCommandManager.ExecCommand(MQLCommand.GlobalVariablesDeleteAll_1, parameters); // MQLCommand ENUM = 153
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = Convert.ToInt32(mqlCommandManager.GetCommandResult(id));
            return result;
        }
        /// <summary>
        /// Function: GlobalVariablesTotal
        /// Description: Returns the total number of global variables of the client terminal.
        /// URL: http://mm.l/mql4/docs.mql4.com/globals/globalvariablestotal.html
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/globalvariablestotal")]
        public void Handle_GlobalVariablesTotal_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, GlobalVariablesTotal_1(context, chartid));
        }

        /// <summary>
        /// Function: GlobalVariablesTotal
        /// Description: Returns the total number of global variables of the client terminal.
        /// URL: http://mm.l/mql4/docs.mql4.com/globals/globalvariablestotal.html
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/globalvariablestotal")]
        public void Handle_GlobalVariablesTotal_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, GlobalVariablesTotal_1(context, DEFAULT_CHART_ID));
        }

        private JObject GlobalVariablesTotal_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            int id = mqlCommandManager.ExecCommand(MQLCommand.GlobalVariablesTotal_1, parameters); // MQLCommand ENUM = 154
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = Convert.ToInt32(mqlCommandManager.GetCommandResult(id));
            return result;
        }
        /// <summary>
        /// Function: HideTestIndicators
        /// Description: The function sets a flag hiding indicators called by the Expert Advisor.
        /// URL: http://mm.l/mql4/docs.mql4.com/customind/hidetestindicators.html
        /// </summary>
        /// <param name="hide">[in] Hiding flag.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/hidetestindicators")]
        public void Handle_HideTestIndicators_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, HideTestIndicators_1(context, chartid));
        }

        /// <summary>
        /// Function: HideTestIndicators
        /// Description: The function sets a flag hiding indicators called by the Expert Advisor.
        /// URL: http://mm.l/mql4/docs.mql4.com/customind/hidetestindicators.html
        /// </summary>
        /// <param name="hide">[in] Hiding flag.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/hidetestindicators")]
        public void Handle_HideTestIndicators_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, HideTestIndicators_1(context, DEFAULT_CHART_ID));
        }

        private JObject HideTestIndicators_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            parameters.Add(payload["hide"]);
            int id = mqlCommandManager.ExecCommand(MQLCommand.HideTestIndicators_1, parameters); // MQLCommand ENUM = 155
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = "";
            return result;
        }
        /// <summary>
        /// Function: IndicatorSetDouble
        /// Description: The function sets the value of the corresponding indicator property. Indicator property must be of the double type. There are two variants of the function.
        /// URL: http://mm.l/mql4/docs.mql4.com/customind/indicatorsetdouble.html
        /// </summary>
        /// <param name="prop_id">[in] Identifier of the indicator property. The value can be one of the values of the enumeration.</param>
        /// <param name="prop_value">[in] Value of property.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/indicatorsetdouble")]
        public void Handle_IndicatorSetDouble_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, IndicatorSetDouble_1(context, chartid));
        }

        /// <summary>
        /// Function: IndicatorSetDouble
        /// Description: The function sets the value of the corresponding indicator property. Indicator property must be of the double type. There are two variants of the function.
        /// URL: http://mm.l/mql4/docs.mql4.com/customind/indicatorsetdouble.html
        /// </summary>
        /// <param name="prop_id">[in] Identifier of the indicator property. The value can be one of the values of the enumeration.</param>
        /// <param name="prop_value">[in] Value of property.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/indicatorsetdouble")]
        public void Handle_IndicatorSetDouble_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, IndicatorSetDouble_1(context, DEFAULT_CHART_ID));
        }

        private JObject IndicatorSetDouble_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            parameters.Add(payload["prop_id"]);
            parameters.Add(payload["prop_value"]);
            int id = mqlCommandManager.ExecCommand(MQLCommand.IndicatorSetDouble_1, parameters); // MQLCommand ENUM = 156
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = (bool)mqlCommandManager.GetCommandResult(id);
            return result;
        }
        /// <summary>
        /// Function: IndicatorSetDouble
        /// Description: The function sets the value of the corresponding indicator property. Indicator property must be of the double type. There are two variants of the function.
        /// URL: http://mm.l/mql4/docs.mql4.com/customind/indicatorsetdouble.html
        /// </summary>
        /// <param name="prop_id">[in] Identifier of the indicator property. The value can be one of the values of the enumeration.</param>
        /// <param name="prop_modifier">[in] Modifier of the specified property. Only level properties require a modifier. Numbering of levels starts from 0. It means that in order to set property for the second level you need to specify 1 (1 less than when using ).</param>
        /// <param name="prop_value">[in] Value of property.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/indicatorsetdouble")]
        public void Handle_IndicatorSetDouble_2(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, IndicatorSetDouble_2(context, chartid));
        }

        /// <summary>
        /// Function: IndicatorSetDouble
        /// Description: The function sets the value of the corresponding indicator property. Indicator property must be of the double type. There are two variants of the function.
        /// URL: http://mm.l/mql4/docs.mql4.com/customind/indicatorsetdouble.html
        /// </summary>
        /// <param name="prop_id">[in] Identifier of the indicator property. The value can be one of the values of the enumeration.</param>
        /// <param name="prop_modifier">[in] Modifier of the specified property. Only level properties require a modifier. Numbering of levels starts from 0. It means that in order to set property for the second level you need to specify 1 (1 less than when using ).</param>
        /// <param name="prop_value">[in] Value of property.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/indicatorsetdouble")]
        public void Handle_IndicatorSetDouble_2_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, IndicatorSetDouble_2(context, DEFAULT_CHART_ID));
        }

        private JObject IndicatorSetDouble_2(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            parameters.Add(payload["prop_id"]);
            parameters.Add(payload["prop_modifier"]);
            parameters.Add(payload["prop_value"]);
            int id = mqlCommandManager.ExecCommand(MQLCommand.IndicatorSetDouble_2, parameters); // MQLCommand ENUM = 156
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = (bool)mqlCommandManager.GetCommandResult(id);
            return result;
        }
        /// <summary>
        /// Function: IndicatorSetInteger
        /// Description: The function sets the value of the corresponding indicator property. Indicator property must be of the int or color type. There are two variants of the function.
        /// URL: http://mm.l/mql4/docs.mql4.com/customind/indicatorsetinteger.html
        /// </summary>
        /// <param name="prop_id">[in] Identifier of the indicator property. The value can be one of the values of the enumeration.</param>
        /// <param name="prop_value">[in] Value of property.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/indicatorsetinteger")]
        public void Handle_IndicatorSetInteger_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, IndicatorSetInteger_1(context, chartid));
        }

        /// <summary>
        /// Function: IndicatorSetInteger
        /// Description: The function sets the value of the corresponding indicator property. Indicator property must be of the int or color type. There are two variants of the function.
        /// URL: http://mm.l/mql4/docs.mql4.com/customind/indicatorsetinteger.html
        /// </summary>
        /// <param name="prop_id">[in] Identifier of the indicator property. The value can be one of the values of the enumeration.</param>
        /// <param name="prop_value">[in] Value of property.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/indicatorsetinteger")]
        public void Handle_IndicatorSetInteger_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, IndicatorSetInteger_1(context, DEFAULT_CHART_ID));
        }

        private JObject IndicatorSetInteger_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            parameters.Add(payload["prop_id"]);
            parameters.Add(payload["prop_value"]);
            int id = mqlCommandManager.ExecCommand(MQLCommand.IndicatorSetInteger_1, parameters); // MQLCommand ENUM = 157
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = (bool)mqlCommandManager.GetCommandResult(id);
            return result;
        }
        /// <summary>
        /// Function: IndicatorSetInteger
        /// Description: The function sets the value of the corresponding indicator property. Indicator property must be of the int or color type. There are two variants of the function.
        /// URL: http://mm.l/mql4/docs.mql4.com/customind/indicatorsetinteger.html
        /// </summary>
        /// <param name="prop_id">[in] Identifier of the indicator property. The value can be one of the values of the enumeration.</param>
        /// <param name="prop_modifier">[in] Modifier of the specified property. Only level properties require a modifier.</param>
        /// <param name="prop_value">[in] Value of property.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/indicatorsetinteger")]
        public void Handle_IndicatorSetInteger_2(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, IndicatorSetInteger_2(context, chartid));
        }

        /// <summary>
        /// Function: IndicatorSetInteger
        /// Description: The function sets the value of the corresponding indicator property. Indicator property must be of the int or color type. There are two variants of the function.
        /// URL: http://mm.l/mql4/docs.mql4.com/customind/indicatorsetinteger.html
        /// </summary>
        /// <param name="prop_id">[in] Identifier of the indicator property. The value can be one of the values of the enumeration.</param>
        /// <param name="prop_modifier">[in] Modifier of the specified property. Only level properties require a modifier.</param>
        /// <param name="prop_value">[in] Value of property.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/indicatorsetinteger")]
        public void Handle_IndicatorSetInteger_2_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, IndicatorSetInteger_2(context, DEFAULT_CHART_ID));
        }

        private JObject IndicatorSetInteger_2(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            parameters.Add(payload["prop_id"]);
            parameters.Add(payload["prop_modifier"]);
            parameters.Add(payload["prop_value"]);
            int id = mqlCommandManager.ExecCommand(MQLCommand.IndicatorSetInteger_2, parameters); // MQLCommand ENUM = 157
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = (bool)mqlCommandManager.GetCommandResult(id);
            return result;
        }
        /// <summary>
        /// Function: IndicatorSetString
        /// Description: The function sets the value of the corresponding indicator property. Indicator property must be of the string type. There are two variants of the function.
        /// URL: http://mm.l/mql4/docs.mql4.com/customind/indicatorsetstring.html
        /// </summary>
        /// <param name="prop_id">[in] Identifier of the indicator property. The value can be one of the values of the enumeration.</param>
        /// <param name="prop_value">[in] Value of property.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/indicatorsetstring")]
        public void Handle_IndicatorSetString_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, IndicatorSetString_1(context, chartid));
        }

        /// <summary>
        /// Function: IndicatorSetString
        /// Description: The function sets the value of the corresponding indicator property. Indicator property must be of the string type. There are two variants of the function.
        /// URL: http://mm.l/mql4/docs.mql4.com/customind/indicatorsetstring.html
        /// </summary>
        /// <param name="prop_id">[in] Identifier of the indicator property. The value can be one of the values of the enumeration.</param>
        /// <param name="prop_value">[in] Value of property.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/indicatorsetstring")]
        public void Handle_IndicatorSetString_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, IndicatorSetString_1(context, DEFAULT_CHART_ID));
        }

        private JObject IndicatorSetString_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            parameters.Add(payload["prop_id"]);
            parameters.Add(payload["prop_value"]);
            int id = mqlCommandManager.ExecCommand(MQLCommand.IndicatorSetString_1, parameters); // MQLCommand ENUM = 158
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = (bool)mqlCommandManager.GetCommandResult(id);
            return result;
        }
        /// <summary>
        /// Function: IndicatorSetString
        /// Description: The function sets the value of the corresponding indicator property. Indicator property must be of the string type. There are two variants of the function.
        /// URL: http://mm.l/mql4/docs.mql4.com/customind/indicatorsetstring.html
        /// </summary>
        /// <param name="prop_id">[in] Identifier of the indicator property. The value can be one of the values of the enumeration.</param>
        /// <param name="prop_modifier">[in] Modifier of the specified property. Only level properties require a modifier.</param>
        /// <param name="prop_value">[in] Value of property.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/indicatorsetstring")]
        public void Handle_IndicatorSetString_2(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, IndicatorSetString_2(context, chartid));
        }

        /// <summary>
        /// Function: IndicatorSetString
        /// Description: The function sets the value of the corresponding indicator property. Indicator property must be of the string type. There are two variants of the function.
        /// URL: http://mm.l/mql4/docs.mql4.com/customind/indicatorsetstring.html
        /// </summary>
        /// <param name="prop_id">[in] Identifier of the indicator property. The value can be one of the values of the enumeration.</param>
        /// <param name="prop_modifier">[in] Modifier of the specified property. Only level properties require a modifier.</param>
        /// <param name="prop_value">[in] Value of property.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/indicatorsetstring")]
        public void Handle_IndicatorSetString_2_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, IndicatorSetString_2(context, DEFAULT_CHART_ID));
        }

        private JObject IndicatorSetString_2(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            parameters.Add(payload["prop_id"]);
            parameters.Add(payload["prop_modifier"]);
            parameters.Add(payload["prop_value"]);
            int id = mqlCommandManager.ExecCommand(MQLCommand.IndicatorSetString_2, parameters); // MQLCommand ENUM = 158
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = (bool)mqlCommandManager.GetCommandResult(id);
            return result;
        }
        /// <summary>
        /// Function: IndicatorBuffers
        /// Description: Allocates memory for buffers used for custom indicator calculations.
        /// URL: http://mm.l/mql4/docs.mql4.com/customind/indicatorbuffers.html
        /// </summary>
        /// <param name="count">[in] Amount of buffers to be allocated. Should be within the range between indicator_buffers and 512 buffers.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/indicatorbuffers")]
        public void Handle_IndicatorBuffers_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, IndicatorBuffers_1(context, chartid));
        }

        /// <summary>
        /// Function: IndicatorBuffers
        /// Description: Allocates memory for buffers used for custom indicator calculations.
        /// URL: http://mm.l/mql4/docs.mql4.com/customind/indicatorbuffers.html
        /// </summary>
        /// <param name="count">[in] Amount of buffers to be allocated. Should be within the range between indicator_buffers and 512 buffers.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/indicatorbuffers")]
        public void Handle_IndicatorBuffers_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, IndicatorBuffers_1(context, DEFAULT_CHART_ID));
        }

        private JObject IndicatorBuffers_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            parameters.Add(payload["count"]);
            int id = mqlCommandManager.ExecCommand(MQLCommand.IndicatorBuffers_1, parameters); // MQLCommand ENUM = 159
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = (bool)mqlCommandManager.GetCommandResult(id);
            return result;
        }
        /// <summary>
        /// Function: IndicatorCounted
        /// Description: The function returns the amount of bars not changed after the indicator had been launched last.
        /// URL: http://mm.l/mql4/docs.mql4.com/customind/indicatorcounted.html
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/indicatorcounted")]
        public void Handle_IndicatorCounted_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, IndicatorCounted_1(context, chartid));
        }

        /// <summary>
        /// Function: IndicatorCounted
        /// Description: The function returns the amount of bars not changed after the indicator had been launched last.
        /// URL: http://mm.l/mql4/docs.mql4.com/customind/indicatorcounted.html
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/indicatorcounted")]
        public void Handle_IndicatorCounted_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, IndicatorCounted_1(context, DEFAULT_CHART_ID));
        }

        private JObject IndicatorCounted_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            int id = mqlCommandManager.ExecCommand(MQLCommand.IndicatorCounted_1, parameters); // MQLCommand ENUM = 160
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = Convert.ToInt32(mqlCommandManager.GetCommandResult(id));
            return result;
        }
        /// <summary>
        /// Function: IndicatorDigits
        /// Description: Sets precision format (the count of digits after decimal point) to visualize indicator values.
        /// URL: http://mm.l/mql4/docs.mql4.com/customind/indicatordigits.html
        /// </summary>
        /// <param name="digits">[in] Precision format, the count of digits after decimal point.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/indicatordigits")]
        public void Handle_IndicatorDigits_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, IndicatorDigits_1(context, chartid));
        }

        /// <summary>
        /// Function: IndicatorDigits
        /// Description: Sets precision format (the count of digits after decimal point) to visualize indicator values.
        /// URL: http://mm.l/mql4/docs.mql4.com/customind/indicatordigits.html
        /// </summary>
        /// <param name="digits">[in] Precision format, the count of digits after decimal point.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/indicatordigits")]
        public void Handle_IndicatorDigits_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, IndicatorDigits_1(context, DEFAULT_CHART_ID));
        }

        private JObject IndicatorDigits_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            parameters.Add(payload["digits"]);
            int id = mqlCommandManager.ExecCommand(MQLCommand.IndicatorDigits_1, parameters); // MQLCommand ENUM = 161
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = "";
            return result;
        }
        /// <summary>
        /// Function: IndicatorShortName
        /// Description: Sets the "short" name of a custom indicator to be shown in the DataWindow and in the chart subwindow.
        /// URL: http://mm.l/mql4/docs.mql4.com/customind/indicatorshortname.html
        /// </summary>
        /// <param name="name">[in] New short name.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/indicatorshortname")]
        public void Handle_IndicatorShortName_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, IndicatorShortName_1(context, chartid));
        }

        /// <summary>
        /// Function: IndicatorShortName
        /// Description: Sets the "short" name of a custom indicator to be shown in the DataWindow and in the chart subwindow.
        /// URL: http://mm.l/mql4/docs.mql4.com/customind/indicatorshortname.html
        /// </summary>
        /// <param name="name">[in] New short name.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/indicatorshortname")]
        public void Handle_IndicatorShortName_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, IndicatorShortName_1(context, DEFAULT_CHART_ID));
        }

        private JObject IndicatorShortName_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            parameters.Add(payload["name"]);
            int id = mqlCommandManager.ExecCommand(MQLCommand.IndicatorShortName_1, parameters); // MQLCommand ENUM = 162
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = "";
            return result;
        }
        /// <summary>
        /// Function: SetIndexArrow
        /// Description: Sets an arrow symbol for indicators line of the DRAW_ARROW type.
        /// URL: http://mm.l/mql4/docs.mql4.com/customind/setindexarrow.html
        /// </summary>
        /// <param name="index">[in] Line index. Must lie between 0 and 7.</param>
        /// <param name="code">[in] Symbol code from or predefined .</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/setindexarrow")]
        public void Handle_SetIndexArrow_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, SetIndexArrow_1(context, chartid));
        }

        /// <summary>
        /// Function: SetIndexArrow
        /// Description: Sets an arrow symbol for indicators line of the DRAW_ARROW type.
        /// URL: http://mm.l/mql4/docs.mql4.com/customind/setindexarrow.html
        /// </summary>
        /// <param name="index">[in] Line index. Must lie between 0 and 7.</param>
        /// <param name="code">[in] Symbol code from or predefined .</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/setindexarrow")]
        public void Handle_SetIndexArrow_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, SetIndexArrow_1(context, DEFAULT_CHART_ID));
        }

        private JObject SetIndexArrow_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            parameters.Add(payload["index"]);
            parameters.Add(payload["code"]);
            int id = mqlCommandManager.ExecCommand(MQLCommand.SetIndexArrow_1, parameters); // MQLCommand ENUM = 163
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = "";
            return result;
        }
        /// <summary>
        /// Function: SetIndexDrawBegin
        /// Description: Sets the bar number (from the data beginning) from which the drawing of the given indicator line must start.
        /// URL: http://mm.l/mql4/docs.mql4.com/customind/setindexdrawbegin.html
        /// </summary>
        /// <param name="index">[in] Line index. Must lie between 0 and 7.</param>
        /// <param name="begin">[in] First drawing bar position number.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/setindexdrawbegin")]
        public void Handle_SetIndexDrawBegin_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, SetIndexDrawBegin_1(context, chartid));
        }

        /// <summary>
        /// Function: SetIndexDrawBegin
        /// Description: Sets the bar number (from the data beginning) from which the drawing of the given indicator line must start.
        /// URL: http://mm.l/mql4/docs.mql4.com/customind/setindexdrawbegin.html
        /// </summary>
        /// <param name="index">[in] Line index. Must lie between 0 and 7.</param>
        /// <param name="begin">[in] First drawing bar position number.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/setindexdrawbegin")]
        public void Handle_SetIndexDrawBegin_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, SetIndexDrawBegin_1(context, DEFAULT_CHART_ID));
        }

        private JObject SetIndexDrawBegin_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            parameters.Add(payload["index"]);
            parameters.Add(payload["begin"]);
            int id = mqlCommandManager.ExecCommand(MQLCommand.SetIndexDrawBegin_1, parameters); // MQLCommand ENUM = 164
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = "";
            return result;
        }
        /// <summary>
        /// Function: SetIndexEmptyValue
        /// Description: Sets drawing line empty value.
        /// URL: http://mm.l/mql4/docs.mql4.com/customind/setindexemptyvalue.html
        /// </summary>
        /// <param name="index">[in] Line index. Must lie between 0 and 7.</param>
        /// <param name="value">[in] New "empty" value.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/setindexemptyvalue")]
        public void Handle_SetIndexEmptyValue_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, SetIndexEmptyValue_1(context, chartid));
        }

        /// <summary>
        /// Function: SetIndexEmptyValue
        /// Description: Sets drawing line empty value.
        /// URL: http://mm.l/mql4/docs.mql4.com/customind/setindexemptyvalue.html
        /// </summary>
        /// <param name="index">[in] Line index. Must lie between 0 and 7.</param>
        /// <param name="value">[in] New "empty" value.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/setindexemptyvalue")]
        public void Handle_SetIndexEmptyValue_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, SetIndexEmptyValue_1(context, DEFAULT_CHART_ID));
        }

        private JObject SetIndexEmptyValue_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            parameters.Add(payload["index"]);
            parameters.Add(payload["value"]);
            int id = mqlCommandManager.ExecCommand(MQLCommand.SetIndexEmptyValue_1, parameters); // MQLCommand ENUM = 165
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = "";
            return result;
        }
        /// <summary>
        /// Function: SetIndexLabel
        /// Description: Sets drawing line description for showing in the DataWindow and in the tooltip.
        /// URL: http://mm.l/mql4/docs.mql4.com/customind/setindexlabel.html
        /// </summary>
        /// <param name="index">[in] Line index. Must lie between 0 and 7.</param>
        /// <param name="text">[in] Label text. NULL means that index value is not shown in the DataWindow.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/setindexlabel")]
        public void Handle_SetIndexLabel_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, SetIndexLabel_1(context, chartid));
        }

        /// <summary>
        /// Function: SetIndexLabel
        /// Description: Sets drawing line description for showing in the DataWindow and in the tooltip.
        /// URL: http://mm.l/mql4/docs.mql4.com/customind/setindexlabel.html
        /// </summary>
        /// <param name="index">[in] Line index. Must lie between 0 and 7.</param>
        /// <param name="text">[in] Label text. NULL means that index value is not shown in the DataWindow.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/setindexlabel")]
        public void Handle_SetIndexLabel_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, SetIndexLabel_1(context, DEFAULT_CHART_ID));
        }

        private JObject SetIndexLabel_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            parameters.Add(payload["index"]);
            parameters.Add(payload["text"]);
            int id = mqlCommandManager.ExecCommand(MQLCommand.SetIndexLabel_1, parameters); // MQLCommand ENUM = 166
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = "";
            return result;
        }
        /// <summary>
        /// Function: SetIndexShift
        /// Description: Sets offset for the drawing line.
        /// URL: http://mm.l/mql4/docs.mql4.com/customind/setindexshift.html
        /// </summary>
        /// <param name="index">[in] Line index. Must lie between 0 and 7.</param>
        /// <param name="shift">[in] Shift value in bars.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/setindexshift")]
        public void Handle_SetIndexShift_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, SetIndexShift_1(context, chartid));
        }

        /// <summary>
        /// Function: SetIndexShift
        /// Description: Sets offset for the drawing line.
        /// URL: http://mm.l/mql4/docs.mql4.com/customind/setindexshift.html
        /// </summary>
        /// <param name="index">[in] Line index. Must lie between 0 and 7.</param>
        /// <param name="shift">[in] Shift value in bars.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/setindexshift")]
        public void Handle_SetIndexShift_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, SetIndexShift_1(context, DEFAULT_CHART_ID));
        }

        private JObject SetIndexShift_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            parameters.Add(payload["index"]);
            parameters.Add(payload["shift"]);
            int id = mqlCommandManager.ExecCommand(MQLCommand.SetIndexShift_1, parameters); // MQLCommand ENUM = 167
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = "";
            return result;
        }
        /// <summary>
        /// Function: SetIndexStyle
        /// Description: Sets the new type, style, width and color for a given indicator line.
        /// URL: http://mm.l/mql4/docs.mql4.com/customind/setindexstyle.html
        /// </summary>
        /// <param name="index">[in] Line index. Must lie between 0 and 7.</param>
        /// <param name="type">[in] Shape style. Can be one of listed.</param>
        /// <param name="style">[in] Drawing style. It is used for one-pixel thick lines. It can be one of the listed. EMPTY value means that the style will not be changed.</param>
        /// <param name="width">[in] Line width. Valid values are: 1,2,3,4,5. EMPTY value means that width will not be changed.</param>
        /// <param name="clr">[in] Line color. Absence of this parameter means that the color will not be changed.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/setindexstyle")]
        public void Handle_SetIndexStyle_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, SetIndexStyle_1(context, chartid));
        }

        /// <summary>
        /// Function: SetIndexStyle
        /// Description: Sets the new type, style, width and color for a given indicator line.
        /// URL: http://mm.l/mql4/docs.mql4.com/customind/setindexstyle.html
        /// </summary>
        /// <param name="index">[in] Line index. Must lie between 0 and 7.</param>
        /// <param name="type">[in] Shape style. Can be one of listed.</param>
        /// <param name="style">[in] Drawing style. It is used for one-pixel thick lines. It can be one of the listed. EMPTY value means that the style will not be changed.</param>
        /// <param name="width">[in] Line width. Valid values are: 1,2,3,4,5. EMPTY value means that width will not be changed.</param>
        /// <param name="clr">[in] Line color. Absence of this parameter means that the color will not be changed.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/setindexstyle")]
        public void Handle_SetIndexStyle_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, SetIndexStyle_1(context, DEFAULT_CHART_ID));
        }

        private JObject SetIndexStyle_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            parameters.Add(payload["index"]);
            parameters.Add(payload["type"]);
            parameters.Add(payload["style"]);
            parameters.Add(payload["width"]);
            parameters.Add(payload["clr"]);
            int id = mqlCommandManager.ExecCommand(MQLCommand.SetIndexStyle_1, parameters); // MQLCommand ENUM = 168
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = "";
            return result;
        }
        /// <summary>
        /// Function: SetLevelStyle
        /// Description: The function sets a new style, width and color of horizontal levels of indicator to be output in a separate window.
        /// URL: http://mm.l/mql4/docs.mql4.com/customind/setlevelstyle.html
        /// </summary>
        /// <param name="draw_style">[in] Drawing style. Can be one of the listed. EMPTY value means that the style will not be changed.</param>
        /// <param name="line_width">[in] Line width. Valid values are 1,2,3,4,5. EMPTY value indicates that the width will not be changed.</param>
        /// <param name="clr">[in] Line color. Empty value CLR_NONE means that the color will not be changed.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/setlevelstyle")]
        public void Handle_SetLevelStyle_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, SetLevelStyle_1(context, chartid));
        }

        /// <summary>
        /// Function: SetLevelStyle
        /// Description: The function sets a new style, width and color of horizontal levels of indicator to be output in a separate window.
        /// URL: http://mm.l/mql4/docs.mql4.com/customind/setlevelstyle.html
        /// </summary>
        /// <param name="draw_style">[in] Drawing style. Can be one of the listed. EMPTY value means that the style will not be changed.</param>
        /// <param name="line_width">[in] Line width. Valid values are 1,2,3,4,5. EMPTY value indicates that the width will not be changed.</param>
        /// <param name="clr">[in] Line color. Empty value CLR_NONE means that the color will not be changed.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/setlevelstyle")]
        public void Handle_SetLevelStyle_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, SetLevelStyle_1(context, DEFAULT_CHART_ID));
        }

        private JObject SetLevelStyle_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            parameters.Add(payload["draw_style"]);
            parameters.Add(payload["line_width"]);
            parameters.Add(payload["clr"]);
            int id = mqlCommandManager.ExecCommand(MQLCommand.SetLevelStyle_1, parameters); // MQLCommand ENUM = 169
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = "";
            return result;
        }
        /// <summary>
        /// Function: SetLevelValue
        /// Description: The function sets a value for a given horizontal level of the indicator to be output in a separate window.
        /// URL: http://mm.l/mql4/docs.mql4.com/customind/setlevelvalue.html
        /// </summary>
        /// <param name="level">[in] Level index (0-31).</param>
        /// <param name="value">[in] Value for the given indicator level.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/setlevelvalue")]
        public void Handle_SetLevelValue_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, SetLevelValue_1(context, chartid));
        }

        /// <summary>
        /// Function: SetLevelValue
        /// Description: The function sets a value for a given horizontal level of the indicator to be output in a separate window.
        /// URL: http://mm.l/mql4/docs.mql4.com/customind/setlevelvalue.html
        /// </summary>
        /// <param name="level">[in] Level index (0-31).</param>
        /// <param name="value">[in] Value for the given indicator level.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/setlevelvalue")]
        public void Handle_SetLevelValue_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, SetLevelValue_1(context, DEFAULT_CHART_ID));
        }

        private JObject SetLevelValue_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            parameters.Add(payload["level"]);
            parameters.Add(payload["value"]);
            int id = mqlCommandManager.ExecCommand(MQLCommand.SetLevelValue_1, parameters); // MQLCommand ENUM = 170
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = "";
            return result;
        }
        /// <summary>
        /// Function: ObjectCreate
        /// Description: The function creates an object with the specified name, type, and the initial coordinates in the specified chart subwindow of the specified chart. There are two variants of the function:
        /// URL: http://mm.l/mql4/docs.mql4.com/objects/objectcreate.html
        /// </summary>
        /// <param name="chart_id">[in] Chart identifier.</param>
        /// <param name="object_name">[in] Name of the object. The name must be unique within a chart, including its subwindows.</param>
        /// <param name="object_type">[in] Object type. The value can be one of the values of the enumeration.</param>
        /// <param name="sub_window">[in] Number of the chart subwindow. 0 means the main chart window. The specified subwindow must exist (window index must be greater or equal to 0 and less than ), otherwise the function returns false.</param>
        /// <param name="time1">[in] The time coordinate of the first anchor point.</param>
        /// <param name="price1">[in] The price coordinate of the first anchor point.</param>
        /// <param name="timeN">[in] The time coordinate of the N-th anchor point.</param>
        /// <param name="priceN">[in] The price coordinate of the N-th anchor point.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/objectcreate")]
        public void Handle_ObjectCreate_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, ObjectCreate_1(context, chartid));
        }

        /// <summary>
        /// Function: ObjectCreate
        /// Description: The function creates an object with the specified name, type, and the initial coordinates in the specified chart subwindow of the specified chart. There are two variants of the function:
        /// URL: http://mm.l/mql4/docs.mql4.com/objects/objectcreate.html
        /// </summary>
        /// <param name="chart_id">[in] Chart identifier.</param>
        /// <param name="object_name">[in] Name of the object. The name must be unique within a chart, including its subwindows.</param>
        /// <param name="object_type">[in] Object type. The value can be one of the values of the enumeration.</param>
        /// <param name="sub_window">[in] Number of the chart subwindow. 0 means the main chart window. The specified subwindow must exist (window index must be greater or equal to 0 and less than ), otherwise the function returns false.</param>
        /// <param name="time1">[in] The time coordinate of the first anchor point.</param>
        /// <param name="price1">[in] The price coordinate of the first anchor point.</param>
        /// <param name="timeN">[in] The time coordinate of the N-th anchor point.</param>
        /// <param name="priceN">[in] The price coordinate of the N-th anchor point.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/objectcreate")]
        public void Handle_ObjectCreate_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, ObjectCreate_1(context, DEFAULT_CHART_ID));
        }

        private JObject ObjectCreate_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            parameters.Add(payload["chart_id"]);
            parameters.Add(payload["object_name"]);
            parameters.Add(payload["object_type"]);
            parameters.Add(payload["sub_window"]);
            parameters.Add(payload["time1"]);
            parameters.Add(payload["price1"]);
            parameters.Add(payload["timeN"]);
            parameters.Add(payload["priceN"]);
            int id = mqlCommandManager.ExecCommand(MQLCommand.ObjectCreate_1, parameters); // MQLCommand ENUM = 171
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = (bool)mqlCommandManager.GetCommandResult(id);
            return result;
        }
        /// <summary>
        /// Function: ObjectCreate
        /// Description: The function creates an object with the specified name, type, and the initial coordinates in the specified chart subwindow of the specified chart. There are two variants of the function:
        /// URL: http://mm.l/mql4/docs.mql4.com/objects/objectcreate.html
        /// </summary>
        /// <param name="object_name">[in] Name of the object. The name must be unique within a chart, including its subwindows.</param>
        /// <param name="object_type">[in] Object type. The value can be one of the values of the enumeration.</param>
        /// <param name="sub_window">[in] Number of the chart subwindow. 0 means the main chart window. The specified subwindow must exist (window index must be greater or equal to 0 and less than ), otherwise the function returns false.</param>
        /// <param name="time1">[in] The time coordinate of the first anchor point.</param>
        /// <param name="price1">[in] The price coordinate of the first anchor point.</param>
        /// <param name="time2">[in] The time coordinate of the second anchor point.</param>
        /// <param name="price2">[in] The price coordinate of the second anchor point.</param>
        /// <param name="time3">[in] The time coordinate of the third anchor point.</param>
        /// <param name="price3">[in] The price coordinate of the third anchor point.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/objectcreate")]
        public void Handle_ObjectCreate_2(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, ObjectCreate_2(context, chartid));
        }

        /// <summary>
        /// Function: ObjectCreate
        /// Description: The function creates an object with the specified name, type, and the initial coordinates in the specified chart subwindow of the specified chart. There are two variants of the function:
        /// URL: http://mm.l/mql4/docs.mql4.com/objects/objectcreate.html
        /// </summary>
        /// <param name="object_name">[in] Name of the object. The name must be unique within a chart, including its subwindows.</param>
        /// <param name="object_type">[in] Object type. The value can be one of the values of the enumeration.</param>
        /// <param name="sub_window">[in] Number of the chart subwindow. 0 means the main chart window. The specified subwindow must exist (window index must be greater or equal to 0 and less than ), otherwise the function returns false.</param>
        /// <param name="time1">[in] The time coordinate of the first anchor point.</param>
        /// <param name="price1">[in] The price coordinate of the first anchor point.</param>
        /// <param name="time2">[in] The time coordinate of the second anchor point.</param>
        /// <param name="price2">[in] The price coordinate of the second anchor point.</param>
        /// <param name="time3">[in] The time coordinate of the third anchor point.</param>
        /// <param name="price3">[in] The price coordinate of the third anchor point.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/objectcreate")]
        public void Handle_ObjectCreate_2_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, ObjectCreate_2(context, DEFAULT_CHART_ID));
        }

        private JObject ObjectCreate_2(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            parameters.Add(payload["object_name"]);
            parameters.Add(payload["object_type"]);
            parameters.Add(payload["sub_window"]);
            parameters.Add(payload["time1"]);
            parameters.Add(payload["price1"]);
            parameters.Add(payload["time2"]);
            parameters.Add(payload["price2"]);
            parameters.Add(payload["time3"]);
            parameters.Add(payload["price3"]);
            int id = mqlCommandManager.ExecCommand(MQLCommand.ObjectCreate_2, parameters); // MQLCommand ENUM = 171
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = (bool)mqlCommandManager.GetCommandResult(id);
            return result;
        }
        /// <summary>
        /// Function: ObjectName
        /// Description: The function returns the name of the corresponding object by its index in the objects list.
        /// URL: http://mm.l/mql4/docs.mql4.com/objects/objectname.html
        /// </summary>
        /// <param name="object_index">[in] Object index. This value must be greater or equal to 0 and less than .</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/objectname")]
        public void Handle_ObjectName_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, ObjectName_1(context, chartid));
        }

        /// <summary>
        /// Function: ObjectName
        /// Description: The function returns the name of the corresponding object by its index in the objects list.
        /// URL: http://mm.l/mql4/docs.mql4.com/objects/objectname.html
        /// </summary>
        /// <param name="object_index">[in] Object index. This value must be greater or equal to 0 and less than .</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/objectname")]
        public void Handle_ObjectName_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, ObjectName_1(context, DEFAULT_CHART_ID));
        }

        private JObject ObjectName_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            parameters.Add(payload["object_index"]);
            int id = mqlCommandManager.ExecCommand(MQLCommand.ObjectName_1, parameters); // MQLCommand ENUM = 172
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = (string)mqlCommandManager.GetCommandResult(id);
            return result;
        }
        /// <summary>
        /// Function: ObjectDelete
        /// Description: The function removes the object with the specified name at the specified chart. There are two variants of the function:
        /// URL: http://mm.l/mql4/docs.mql4.com/objects/objectdelete.html
        /// </summary>
        /// <param name="chart_id">[in] Chart identifier.</param>
        /// <param name="object_name">[in] Name of object to be deleted.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/objectdelete")]
        public void Handle_ObjectDelete_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, ObjectDelete_1(context, chartid));
        }

        /// <summary>
        /// Function: ObjectDelete
        /// Description: The function removes the object with the specified name at the specified chart. There are two variants of the function:
        /// URL: http://mm.l/mql4/docs.mql4.com/objects/objectdelete.html
        /// </summary>
        /// <param name="chart_id">[in] Chart identifier.</param>
        /// <param name="object_name">[in] Name of object to be deleted.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/objectdelete")]
        public void Handle_ObjectDelete_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, ObjectDelete_1(context, DEFAULT_CHART_ID));
        }

        private JObject ObjectDelete_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            parameters.Add(payload["chart_id"]);
            parameters.Add(payload["object_name"]);
            int id = mqlCommandManager.ExecCommand(MQLCommand.ObjectDelete_1, parameters); // MQLCommand ENUM = 173
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = (bool)mqlCommandManager.GetCommandResult(id);
            return result;
        }
        /// <summary>
        /// Function: ObjectDelete
        /// Description: The function removes the object with the specified name at the specified chart. There are two variants of the function:
        /// URL: http://mm.l/mql4/docs.mql4.com/objects/objectdelete.html
        /// </summary>
        /// <param name="object_name">[in] Name of object to be deleted.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/objectdelete")]
        public void Handle_ObjectDelete_2(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, ObjectDelete_2(context, chartid));
        }

        /// <summary>
        /// Function: ObjectDelete
        /// Description: The function removes the object with the specified name at the specified chart. There are two variants of the function:
        /// URL: http://mm.l/mql4/docs.mql4.com/objects/objectdelete.html
        /// </summary>
        /// <param name="object_name">[in] Name of object to be deleted.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/objectdelete")]
        public void Handle_ObjectDelete_2_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, ObjectDelete_2(context, DEFAULT_CHART_ID));
        }

        private JObject ObjectDelete_2(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            parameters.Add(payload["object_name"]);
            int id = mqlCommandManager.ExecCommand(MQLCommand.ObjectDelete_2, parameters); // MQLCommand ENUM = 173
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = (bool)mqlCommandManager.GetCommandResult(id);
            return result;
        }
        /// <summary>
        /// Function: ObjectsDeleteAll
        /// Description: Removes all objects from the specified chart, specified chart subwindow, of the specified type.
        /// URL: http://mm.l/mql4/docs.mql4.com/objects/objectsdeleteall.html
        /// </summary>
        /// <param name="chart_id">[in] Chart identifier.</param>
        /// <param name="sub_window">[in] Number of the chart window. Must be greater or equal to -1 (-1 mean all subwindows, 0 means the main chart window) and less than .</param>
        /// <param name="object_type">[in] Type of the object. The value can be one of the values of the enumeration. EMPTY (-1) means all types.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/objectsdeleteall")]
        public void Handle_ObjectsDeleteAll_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, ObjectsDeleteAll_1(context, chartid));
        }

        /// <summary>
        /// Function: ObjectsDeleteAll
        /// Description: Removes all objects from the specified chart, specified chart subwindow, of the specified type.
        /// URL: http://mm.l/mql4/docs.mql4.com/objects/objectsdeleteall.html
        /// </summary>
        /// <param name="chart_id">[in] Chart identifier.</param>
        /// <param name="sub_window">[in] Number of the chart window. Must be greater or equal to -1 (-1 mean all subwindows, 0 means the main chart window) and less than .</param>
        /// <param name="object_type">[in] Type of the object. The value can be one of the values of the enumeration. EMPTY (-1) means all types.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/objectsdeleteall")]
        public void Handle_ObjectsDeleteAll_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, ObjectsDeleteAll_1(context, DEFAULT_CHART_ID));
        }

        private JObject ObjectsDeleteAll_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            parameters.Add(payload["chart_id"]);
            parameters.Add(payload["sub_window"]);
            parameters.Add(payload["object_type"]);
            int id = mqlCommandManager.ExecCommand(MQLCommand.ObjectsDeleteAll_1, parameters); // MQLCommand ENUM = 174
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = Convert.ToInt32(mqlCommandManager.GetCommandResult(id));
            return result;
        }
        /// <summary>
        /// Function: ObjectsDeleteAll
        /// Description: Removes all objects from the specified chart, specified chart subwindow, of the specified type.
        /// URL: http://mm.l/mql4/docs.mql4.com/objects/objectsdeleteall.html
        /// </summary>
        /// <param name="sub_window">[in] Number of the chart window. Must be greater or equal to -1 (-1 mean all subwindows, 0 means the main chart window) and less than .</param>
        /// <param name="object_type">[in] Type of the object. The value can be one of the values of the enumeration. EMPTY (-1) means all types.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/objectsdeleteall")]
        public void Handle_ObjectsDeleteAll_2(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, ObjectsDeleteAll_2(context, chartid));
        }

        /// <summary>
        /// Function: ObjectsDeleteAll
        /// Description: Removes all objects from the specified chart, specified chart subwindow, of the specified type.
        /// URL: http://mm.l/mql4/docs.mql4.com/objects/objectsdeleteall.html
        /// </summary>
        /// <param name="sub_window">[in] Number of the chart window. Must be greater or equal to -1 (-1 mean all subwindows, 0 means the main chart window) and less than .</param>
        /// <param name="object_type">[in] Type of the object. The value can be one of the values of the enumeration. EMPTY (-1) means all types.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/objectsdeleteall")]
        public void Handle_ObjectsDeleteAll_2_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, ObjectsDeleteAll_2(context, DEFAULT_CHART_ID));
        }

        private JObject ObjectsDeleteAll_2(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            parameters.Add(payload["sub_window"]);
            parameters.Add(payload["object_type"]);
            int id = mqlCommandManager.ExecCommand(MQLCommand.ObjectsDeleteAll_2, parameters); // MQLCommand ENUM = 174
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = Convert.ToInt32(mqlCommandManager.GetCommandResult(id));
            return result;
        }
        /// <summary>
        /// Function: ObjectsDeleteAll
        /// Description: Removes all objects from the specified chart, specified chart subwindow, of the specified type.
        /// URL: http://mm.l/mql4/docs.mql4.com/objects/objectsdeleteall.html
        /// </summary>
        /// <param name="chart_id">[in] Chart identifier.</param>
        /// <param name="prefix">[in] Prefix in object names. All objects whose names start with this set of characters will be removed from chart. You can specify prefix as 'name' or 'name*' both variants will work the same. If an empty string is specified as the prefix, objects with all possible names will be removed.</param>
        /// <param name="sub_window">[in] Number of the chart window. Must be greater or equal to -1 (-1 mean all subwindows, 0 means the main chart window) and less than .</param>
        /// <param name="object_type">[in] Type of the object. The value can be one of the values of the enumeration. EMPTY (-1) means all types.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/objectsdeleteall")]
        public void Handle_ObjectsDeleteAll_3(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, ObjectsDeleteAll_3(context, chartid));
        }

        /// <summary>
        /// Function: ObjectsDeleteAll
        /// Description: Removes all objects from the specified chart, specified chart subwindow, of the specified type.
        /// URL: http://mm.l/mql4/docs.mql4.com/objects/objectsdeleteall.html
        /// </summary>
        /// <param name="chart_id">[in] Chart identifier.</param>
        /// <param name="prefix">[in] Prefix in object names. All objects whose names start with this set of characters will be removed from chart. You can specify prefix as 'name' or 'name*' both variants will work the same. If an empty string is specified as the prefix, objects with all possible names will be removed.</param>
        /// <param name="sub_window">[in] Number of the chart window. Must be greater or equal to -1 (-1 mean all subwindows, 0 means the main chart window) and less than .</param>
        /// <param name="object_type">[in] Type of the object. The value can be one of the values of the enumeration. EMPTY (-1) means all types.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/objectsdeleteall")]
        public void Handle_ObjectsDeleteAll_3_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, ObjectsDeleteAll_3(context, DEFAULT_CHART_ID));
        }

        private JObject ObjectsDeleteAll_3(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            parameters.Add(payload["chart_id"]);
            parameters.Add(payload["prefix"]);
            parameters.Add(payload["sub_window"]);
            parameters.Add(payload["object_type"]);
            int id = mqlCommandManager.ExecCommand(MQLCommand.ObjectsDeleteAll_3, parameters); // MQLCommand ENUM = 174
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = Convert.ToInt32(mqlCommandManager.GetCommandResult(id));
            return result;
        }
        /// <summary>
        /// Function: ObjectFind
        /// Description: The function searches for an object having the specified name. There are two variants of the function:
        /// URL: http://mm.l/mql4/docs.mql4.com/objects/objectfind.html
        /// </summary>
        /// <param name="chart_id">[in] Chart identifier.</param>
        /// <param name="object_name">[in] The name of the object to find.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/objectfind")]
        public void Handle_ObjectFind_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, ObjectFind_1(context, chartid));
        }

        /// <summary>
        /// Function: ObjectFind
        /// Description: The function searches for an object having the specified name. There are two variants of the function:
        /// URL: http://mm.l/mql4/docs.mql4.com/objects/objectfind.html
        /// </summary>
        /// <param name="chart_id">[in] Chart identifier.</param>
        /// <param name="object_name">[in] The name of the object to find.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/objectfind")]
        public void Handle_ObjectFind_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, ObjectFind_1(context, DEFAULT_CHART_ID));
        }

        private JObject ObjectFind_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            parameters.Add(payload["chart_id"]);
            parameters.Add(payload["object_name"]);
            int id = mqlCommandManager.ExecCommand(MQLCommand.ObjectFind_1, parameters); // MQLCommand ENUM = 175
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = Convert.ToInt32(mqlCommandManager.GetCommandResult(id));
            return result;
        }
        /// <summary>
        /// Function: ObjectFind
        /// Description: The function searches for an object having the specified name. There are two variants of the function:
        /// URL: http://mm.l/mql4/docs.mql4.com/objects/objectfind.html
        /// </summary>
        /// <param name="object_name">[in] The name of the object to find.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/objectfind")]
        public void Handle_ObjectFind_2(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, ObjectFind_2(context, chartid));
        }

        /// <summary>
        /// Function: ObjectFind
        /// Description: The function searches for an object having the specified name. There are two variants of the function:
        /// URL: http://mm.l/mql4/docs.mql4.com/objects/objectfind.html
        /// </summary>
        /// <param name="object_name">[in] The name of the object to find.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/objectfind")]
        public void Handle_ObjectFind_2_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, ObjectFind_2(context, DEFAULT_CHART_ID));
        }

        private JObject ObjectFind_2(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            parameters.Add(payload["object_name"]);
            int id = mqlCommandManager.ExecCommand(MQLCommand.ObjectFind_2, parameters); // MQLCommand ENUM = 175
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = Convert.ToInt32(mqlCommandManager.GetCommandResult(id));
            return result;
        }
        /// <summary>
        /// Function: ObjectGetTimeByValue
        /// Description: The function returns the time value for the specified price value of the specified object.
        /// URL: http://mm.l/mql4/docs.mql4.com/objects/objectgettimebyvalue.html
        /// </summary>
        /// <param name="object_name">[in] Name of the object.</param>
        /// <param name="value">[in] Price value.</param>
        /// <param name="line_id">[in] Line identifier.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/objectgettimebyvalue")]
        public void Handle_ObjectGetTimeByValue_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, ObjectGetTimeByValue_1(context, chartid));
        }

        /// <summary>
        /// Function: ObjectGetTimeByValue
        /// Description: The function returns the time value for the specified price value of the specified object.
        /// URL: http://mm.l/mql4/docs.mql4.com/objects/objectgettimebyvalue.html
        /// </summary>
        /// <param name="object_name">[in] Name of the object.</param>
        /// <param name="value">[in] Price value.</param>
        /// <param name="line_id">[in] Line identifier.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/objectgettimebyvalue")]
        public void Handle_ObjectGetTimeByValue_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, ObjectGetTimeByValue_1(context, DEFAULT_CHART_ID));
        }

        private JObject ObjectGetTimeByValue_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            parameters.Add(payload["object_name"]);
            parameters.Add(payload["value"]);
            parameters.Add(payload["line_id"]);
            int id = mqlCommandManager.ExecCommand(MQLCommand.ObjectGetTimeByValue_1, parameters); // MQLCommand ENUM = 176
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = (DateTime)mqlCommandManager.GetCommandResult(id);
            return result;
        }
        /// <summary>
        /// Function: ObjectGetValueByTime
        /// Description: The function returns the price value for the specified time value of the specified object.
        /// URL: http://mm.l/mql4/docs.mql4.com/objects/objectgetvaluebytime.html
        /// </summary>
        /// <param name="chart_id">[in] Chart identifier.</param>
        /// <param name="object_name">[in] Name of the object.</param>
        /// <param name="time">[in] Time value.</param>
        /// <param name="line_id">[in] Line identifier.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/objectgetvaluebytime")]
        public void Handle_ObjectGetValueByTime_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, ObjectGetValueByTime_1(context, chartid));
        }

        /// <summary>
        /// Function: ObjectGetValueByTime
        /// Description: The function returns the price value for the specified time value of the specified object.
        /// URL: http://mm.l/mql4/docs.mql4.com/objects/objectgetvaluebytime.html
        /// </summary>
        /// <param name="chart_id">[in] Chart identifier.</param>
        /// <param name="object_name">[in] Name of the object.</param>
        /// <param name="time">[in] Time value.</param>
        /// <param name="line_id">[in] Line identifier.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/objectgetvaluebytime")]
        public void Handle_ObjectGetValueByTime_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, ObjectGetValueByTime_1(context, DEFAULT_CHART_ID));
        }

        private JObject ObjectGetValueByTime_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            parameters.Add(payload["chart_id"]);
            parameters.Add(payload["object_name"]);
            parameters.Add(payload["time"]);
            parameters.Add(payload["line_id"]);
            int id = mqlCommandManager.ExecCommand(MQLCommand.ObjectGetValueByTime_1, parameters); // MQLCommand ENUM = 177
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = Convert.ToDecimal(mqlCommandManager.GetCommandResult(id));
            return result;
        }
        /// <summary>
        /// Function: ObjectMove
        /// Description: The function changes coordinates of the specified anchor point of the object at the specified chart. There are two variants of the function:
        /// URL: http://mm.l/mql4/docs.mql4.com/objects/objectmove.html
        /// </summary>
        /// <param name="object_name">[in] Name of the object.</param>
        /// <param name="point_index">[in] Index of the anchor point. The number of anchor points depends on the .</param>
        /// <param name="time">[in] Time coordinate of the selected anchor point.</param>
        /// <param name="price">[in] Price coordinate of the selected anchor point.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/objectmove")]
        public void Handle_ObjectMove_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, ObjectMove_1(context, chartid));
        }

        /// <summary>
        /// Function: ObjectMove
        /// Description: The function changes coordinates of the specified anchor point of the object at the specified chart. There are two variants of the function:
        /// URL: http://mm.l/mql4/docs.mql4.com/objects/objectmove.html
        /// </summary>
        /// <param name="object_name">[in] Name of the object.</param>
        /// <param name="point_index">[in] Index of the anchor point. The number of anchor points depends on the .</param>
        /// <param name="time">[in] Time coordinate of the selected anchor point.</param>
        /// <param name="price">[in] Price coordinate of the selected anchor point.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/objectmove")]
        public void Handle_ObjectMove_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, ObjectMove_1(context, DEFAULT_CHART_ID));
        }

        private JObject ObjectMove_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            parameters.Add(payload["object_name"]);
            parameters.Add(payload["point_index"]);
            parameters.Add(payload["time"]);
            parameters.Add(payload["price"]);
            int id = mqlCommandManager.ExecCommand(MQLCommand.ObjectMove_1, parameters); // MQLCommand ENUM = 178
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = (bool)mqlCommandManager.GetCommandResult(id);
            return result;
        }
        /// <summary>
        /// Function: ObjectsTotal
        /// Description: The function returns the number of objects of the specified type in the specified chart. There are two variants of the function:
        /// URL: http://mm.l/mql4/docs.mql4.com/objects/objectstotal.html
        /// </summary>
        /// <param name="chart_id">[in] Chart identifier.</param>
        /// <param name="sub_window">[in] Number of the chart subwindow. 0 means the main chart window, -1 means all the subwindows of the chart, including the main window.</param>
        /// <param name="type">[in] Type of the object. The value can be one of the values of the enumeration. EMPTY(-1) means all types.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/objectstotal")]
        public void Handle_ObjectsTotal_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, ObjectsTotal_1(context, chartid));
        }

        /// <summary>
        /// Function: ObjectsTotal
        /// Description: The function returns the number of objects of the specified type in the specified chart. There are two variants of the function:
        /// URL: http://mm.l/mql4/docs.mql4.com/objects/objectstotal.html
        /// </summary>
        /// <param name="chart_id">[in] Chart identifier.</param>
        /// <param name="sub_window">[in] Number of the chart subwindow. 0 means the main chart window, -1 means all the subwindows of the chart, including the main window.</param>
        /// <param name="type">[in] Type of the object. The value can be one of the values of the enumeration. EMPTY(-1) means all types.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/objectstotal")]
        public void Handle_ObjectsTotal_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, ObjectsTotal_1(context, DEFAULT_CHART_ID));
        }

        private JObject ObjectsTotal_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            parameters.Add(payload["chart_id"]);
            parameters.Add(payload["sub_window"]);
            parameters.Add(payload["type"]);
            int id = mqlCommandManager.ExecCommand(MQLCommand.ObjectsTotal_1, parameters); // MQLCommand ENUM = 179
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = Convert.ToInt32(mqlCommandManager.GetCommandResult(id));
            return result;
        }
        /// <summary>
        /// Function: ObjectsTotal
        /// Description: The function returns the number of objects of the specified type in the specified chart. There are two variants of the function:
        /// URL: http://mm.l/mql4/docs.mql4.com/objects/objectstotal.html
        /// </summary>
        /// <param name="type">[in] Type of the object. The value can be one of the values of the enumeration. EMPTY(-1) means all types.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/objectstotal")]
        public void Handle_ObjectsTotal_2(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, ObjectsTotal_2(context, chartid));
        }

        /// <summary>
        /// Function: ObjectsTotal
        /// Description: The function returns the number of objects of the specified type in the specified chart. There are two variants of the function:
        /// URL: http://mm.l/mql4/docs.mql4.com/objects/objectstotal.html
        /// </summary>
        /// <param name="type">[in] Type of the object. The value can be one of the values of the enumeration. EMPTY(-1) means all types.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/objectstotal")]
        public void Handle_ObjectsTotal_2_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, ObjectsTotal_2(context, DEFAULT_CHART_ID));
        }

        private JObject ObjectsTotal_2(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            parameters.Add(payload["type"]);
            int id = mqlCommandManager.ExecCommand(MQLCommand.ObjectsTotal_2, parameters); // MQLCommand ENUM = 179
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = Convert.ToInt32(mqlCommandManager.GetCommandResult(id));
            return result;
        }
        /// <summary>
        /// Function: ObjectGetDouble
        /// Description: The function returns the value of the corresponding object property. The object property must be of the
        /// URL: http://mm.l/mql4/docs.mql4.com/objects/objectgetdouble.html
        /// </summary>
        /// <param name="chart_id">[in] Chart identifier. 0 means the current chart.</param>
        /// <param name="object_name">[in] Name of the object.</param>
        /// <param name="prop_id">[in] ID of the object property. The value can be one of the values of the enumeration.</param>
        /// <param name="prop_modifier">[in] Modifier of the specified property. For the first variant, the default modifier value is equal to 0. Most properties do not require a modifier. It denotes the number of the level in and in the graphical object Andrew's pitchfork. The numeration of levels starts from zero.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/objectgetdouble")]
        public void Handle_ObjectGetDouble_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, ObjectGetDouble_1(context, chartid));
        }

        /// <summary>
        /// Function: ObjectGetDouble
        /// Description: The function returns the value of the corresponding object property. The object property must be of the
        /// URL: http://mm.l/mql4/docs.mql4.com/objects/objectgetdouble.html
        /// </summary>
        /// <param name="chart_id">[in] Chart identifier. 0 means the current chart.</param>
        /// <param name="object_name">[in] Name of the object.</param>
        /// <param name="prop_id">[in] ID of the object property. The value can be one of the values of the enumeration.</param>
        /// <param name="prop_modifier">[in] Modifier of the specified property. For the first variant, the default modifier value is equal to 0. Most properties do not require a modifier. It denotes the number of the level in and in the graphical object Andrew's pitchfork. The numeration of levels starts from zero.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/objectgetdouble")]
        public void Handle_ObjectGetDouble_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, ObjectGetDouble_1(context, DEFAULT_CHART_ID));
        }

        private JObject ObjectGetDouble_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            parameters.Add(payload["chart_id"]);
            parameters.Add(payload["object_name"]);
            parameters.Add(payload["prop_id"]);
            parameters.Add(payload["prop_modifier"]);
            int id = mqlCommandManager.ExecCommand(MQLCommand.ObjectGetDouble_1, parameters); // MQLCommand ENUM = 180
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = Convert.ToDecimal(mqlCommandManager.GetCommandResult(id));
            return result;
        }
        /// <summary>
        /// Function: ObjectGetInteger
        /// Description: The function returns the value of the corresponding object property. The object property must be of the
        /// URL: http://mm.l/mql4/docs.mql4.com/objects/objectgetinteger.html
        /// </summary>
        /// <param name="chart_id">[in] Chart identifier. 0 means the current chart.</param>
        /// <param name="object_name">[in] Name of the object.</param>
        /// <param name="prop_id">[in] ID of the object property. The value can be one of the values of the enumeration.</param>
        /// <param name="prop_modifier">[in] Modifier of the specified property. For the first variant, the default modifier value is equal to 0. Most properties do not require a modifier. It denotes the number of the level in and in the graphical object Andrew's pitchfork. The numeration of levels starts from zero.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/objectgetinteger")]
        public void Handle_ObjectGetInteger_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, ObjectGetInteger_1(context, chartid));
        }

        /// <summary>
        /// Function: ObjectGetInteger
        /// Description: The function returns the value of the corresponding object property. The object property must be of the
        /// URL: http://mm.l/mql4/docs.mql4.com/objects/objectgetinteger.html
        /// </summary>
        /// <param name="chart_id">[in] Chart identifier. 0 means the current chart.</param>
        /// <param name="object_name">[in] Name of the object.</param>
        /// <param name="prop_id">[in] ID of the object property. The value can be one of the values of the enumeration.</param>
        /// <param name="prop_modifier">[in] Modifier of the specified property. For the first variant, the default modifier value is equal to 0. Most properties do not require a modifier. It denotes the number of the level in and in the graphical object Andrew's pitchfork. The numeration of levels starts from zero.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/objectgetinteger")]
        public void Handle_ObjectGetInteger_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, ObjectGetInteger_1(context, DEFAULT_CHART_ID));
        }

        private JObject ObjectGetInteger_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            parameters.Add(payload["chart_id"]);
            parameters.Add(payload["object_name"]);
            parameters.Add(payload["prop_id"]);
            parameters.Add(payload["prop_modifier"]);
            int id = mqlCommandManager.ExecCommand(MQLCommand.ObjectGetInteger_1, parameters); // MQLCommand ENUM = 181
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = Convert.ToInt64(mqlCommandManager.GetCommandResult(id));
            return result;
        }
        /// <summary>
        /// Function: ObjectGetString
        /// Description: The function returns the value of the corresponding object property. The object property must be of the
        /// URL: http://mm.l/mql4/docs.mql4.com/objects/objectgetstring.html
        /// </summary>
        /// <param name="chart_id">[in] Chart identifier. 0 means the current chart.</param>
        /// <param name="object_name">[in] Name of the object.</param>
        /// <param name="prop_id">[in] ID of the object property. The value can be one of the values of the enumeration.</param>
        /// <param name="prop_modifier">[in] Modifier of the specified property. For the first variant, the default modifier value is equal to 0. Most properties do not require a modifier. It denotes the number of the level in and in the graphical object Andrew's pitchfork. The numeration of levels starts from zero.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/objectgetstring")]
        public void Handle_ObjectGetString_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, ObjectGetString_1(context, chartid));
        }

        /// <summary>
        /// Function: ObjectGetString
        /// Description: The function returns the value of the corresponding object property. The object property must be of the
        /// URL: http://mm.l/mql4/docs.mql4.com/objects/objectgetstring.html
        /// </summary>
        /// <param name="chart_id">[in] Chart identifier. 0 means the current chart.</param>
        /// <param name="object_name">[in] Name of the object.</param>
        /// <param name="prop_id">[in] ID of the object property. The value can be one of the values of the enumeration.</param>
        /// <param name="prop_modifier">[in] Modifier of the specified property. For the first variant, the default modifier value is equal to 0. Most properties do not require a modifier. It denotes the number of the level in and in the graphical object Andrew's pitchfork. The numeration of levels starts from zero.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/objectgetstring")]
        public void Handle_ObjectGetString_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, ObjectGetString_1(context, DEFAULT_CHART_ID));
        }

        private JObject ObjectGetString_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            parameters.Add(payload["chart_id"]);
            parameters.Add(payload["object_name"]);
            parameters.Add(payload["prop_id"]);
            parameters.Add(payload["prop_modifier"]);
            int id = mqlCommandManager.ExecCommand(MQLCommand.ObjectGetString_1, parameters); // MQLCommand ENUM = 182
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = (string)mqlCommandManager.GetCommandResult(id);
            return result;
        }
        /// <summary>
        /// Function: ObjectSetDouble
        /// Description: The function sets the value of the corresponding object property. The object property must be of the
        /// URL: http://mm.l/mql4/docs.mql4.com/objects/objectsetdouble.html
        /// </summary>
        /// <param name="chart_id">[in] Chart identifier. 0 means the current chart.</param>
        /// <param name="object_name">[in] Name of the object.</param>
        /// <param name="prop_id">[in] ID of the object property. The value can be one of the values of the enumeration.</param>
        /// <param name="prop_value">[in] The value of the property.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/objectsetdouble")]
        public void Handle_ObjectSetDouble_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, ObjectSetDouble_1(context, chartid));
        }

        /// <summary>
        /// Function: ObjectSetDouble
        /// Description: The function sets the value of the corresponding object property. The object property must be of the
        /// URL: http://mm.l/mql4/docs.mql4.com/objects/objectsetdouble.html
        /// </summary>
        /// <param name="chart_id">[in] Chart identifier. 0 means the current chart.</param>
        /// <param name="object_name">[in] Name of the object.</param>
        /// <param name="prop_id">[in] ID of the object property. The value can be one of the values of the enumeration.</param>
        /// <param name="prop_value">[in] The value of the property.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/objectsetdouble")]
        public void Handle_ObjectSetDouble_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, ObjectSetDouble_1(context, DEFAULT_CHART_ID));
        }

        private JObject ObjectSetDouble_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            parameters.Add(payload["chart_id"]);
            parameters.Add(payload["object_name"]);
            parameters.Add(payload["prop_id"]);
            parameters.Add(payload["prop_value"]);
            int id = mqlCommandManager.ExecCommand(MQLCommand.ObjectSetDouble_1, parameters); // MQLCommand ENUM = 183
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = (bool)mqlCommandManager.GetCommandResult(id);
            return result;
        }
        /// <summary>
        /// Function: ObjectSetDouble
        /// Description: The function sets the value of the corresponding object property. The object property must be of the
        /// URL: http://mm.l/mql4/docs.mql4.com/objects/objectsetdouble.html
        /// </summary>
        /// <param name="chart_id">[in] Chart identifier. 0 means the current chart.</param>
        /// <param name="object_name">[in] Name of the object.</param>
        /// <param name="prop_id">[in] ID of the object property. The value can be one of the values of the enumeration.</param>
        /// <param name="prop_modifier">[in] Modifier of the specified property. It denotes the number of the level in and in the graphical object Andrew's pitchfork. The numeration of levels starts from zero.</param>
        /// <param name="prop_value">[in] The value of the property.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/objectsetdouble")]
        public void Handle_ObjectSetDouble_2(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, ObjectSetDouble_2(context, chartid));
        }

        /// <summary>
        /// Function: ObjectSetDouble
        /// Description: The function sets the value of the corresponding object property. The object property must be of the
        /// URL: http://mm.l/mql4/docs.mql4.com/objects/objectsetdouble.html
        /// </summary>
        /// <param name="chart_id">[in] Chart identifier. 0 means the current chart.</param>
        /// <param name="object_name">[in] Name of the object.</param>
        /// <param name="prop_id">[in] ID of the object property. The value can be one of the values of the enumeration.</param>
        /// <param name="prop_modifier">[in] Modifier of the specified property. It denotes the number of the level in and in the graphical object Andrew's pitchfork. The numeration of levels starts from zero.</param>
        /// <param name="prop_value">[in] The value of the property.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/objectsetdouble")]
        public void Handle_ObjectSetDouble_2_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, ObjectSetDouble_2(context, DEFAULT_CHART_ID));
        }

        private JObject ObjectSetDouble_2(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            parameters.Add(payload["chart_id"]);
            parameters.Add(payload["object_name"]);
            parameters.Add(payload["prop_id"]);
            parameters.Add(payload["prop_modifier"]);
            parameters.Add(payload["prop_value"]);
            int id = mqlCommandManager.ExecCommand(MQLCommand.ObjectSetDouble_2, parameters); // MQLCommand ENUM = 183
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = (bool)mqlCommandManager.GetCommandResult(id);
            return result;
        }
        /// <summary>
        /// Function: ObjectSetInteger
        /// Description: The function sets the value of the corresponding object property. The object property must be of the
        /// URL: http://mm.l/mql4/docs.mql4.com/objects/objectsetinteger.html
        /// </summary>
        /// <param name="chart_id">[in] Chart identifier. 0 means the current chart.</param>
        /// <param name="object_name">[in] Name of the object.</param>
        /// <param name="prop_id">[in] ID of the object property. The value can be one of the values of the enumeration.</param>
        /// <param name="prop_value">[in] The value of the property.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/objectsetinteger")]
        public void Handle_ObjectSetInteger_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, ObjectSetInteger_1(context, chartid));
        }

        /// <summary>
        /// Function: ObjectSetInteger
        /// Description: The function sets the value of the corresponding object property. The object property must be of the
        /// URL: http://mm.l/mql4/docs.mql4.com/objects/objectsetinteger.html
        /// </summary>
        /// <param name="chart_id">[in] Chart identifier. 0 means the current chart.</param>
        /// <param name="object_name">[in] Name of the object.</param>
        /// <param name="prop_id">[in] ID of the object property. The value can be one of the values of the enumeration.</param>
        /// <param name="prop_value">[in] The value of the property.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/objectsetinteger")]
        public void Handle_ObjectSetInteger_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, ObjectSetInteger_1(context, DEFAULT_CHART_ID));
        }

        private JObject ObjectSetInteger_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            parameters.Add(payload["chart_id"]);
            parameters.Add(payload["object_name"]);
            parameters.Add(payload["prop_id"]);
            parameters.Add(payload["prop_value"]);
            int id = mqlCommandManager.ExecCommand(MQLCommand.ObjectSetInteger_1, parameters); // MQLCommand ENUM = 184
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = (bool)mqlCommandManager.GetCommandResult(id);
            return result;
        }
        /// <summary>
        /// Function: ObjectSetInteger
        /// Description: The function sets the value of the corresponding object property. The object property must be of the
        /// URL: http://mm.l/mql4/docs.mql4.com/objects/objectsetinteger.html
        /// </summary>
        /// <param name="chart_id">[in] Chart identifier. 0 means the current chart.</param>
        /// <param name="object_name">[in] Name of the object.</param>
        /// <param name="prop_id">[in] ID of the object property. The value can be one of the values of the enumeration.</param>
        /// <param name="prop_modifier">[in] Modifier of the specified property. It denotes the number of the level in and in the graphical object Andrew's pitchfork. The numeration of levels starts from zero.</param>
        /// <param name="prop_value">[in] The value of the property.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/objectsetinteger")]
        public void Handle_ObjectSetInteger_2(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, ObjectSetInteger_2(context, chartid));
        }

        /// <summary>
        /// Function: ObjectSetInteger
        /// Description: The function sets the value of the corresponding object property. The object property must be of the
        /// URL: http://mm.l/mql4/docs.mql4.com/objects/objectsetinteger.html
        /// </summary>
        /// <param name="chart_id">[in] Chart identifier. 0 means the current chart.</param>
        /// <param name="object_name">[in] Name of the object.</param>
        /// <param name="prop_id">[in] ID of the object property. The value can be one of the values of the enumeration.</param>
        /// <param name="prop_modifier">[in] Modifier of the specified property. It denotes the number of the level in and in the graphical object Andrew's pitchfork. The numeration of levels starts from zero.</param>
        /// <param name="prop_value">[in] The value of the property.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/objectsetinteger")]
        public void Handle_ObjectSetInteger_2_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, ObjectSetInteger_2(context, DEFAULT_CHART_ID));
        }

        private JObject ObjectSetInteger_2(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            parameters.Add(payload["chart_id"]);
            parameters.Add(payload["object_name"]);
            parameters.Add(payload["prop_id"]);
            parameters.Add(payload["prop_modifier"]);
            parameters.Add(payload["prop_value"]);
            int id = mqlCommandManager.ExecCommand(MQLCommand.ObjectSetInteger_2, parameters); // MQLCommand ENUM = 184
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = (bool)mqlCommandManager.GetCommandResult(id);
            return result;
        }
        /// <summary>
        /// Function: ObjectSetString
        /// Description: The function sets the value of the corresponding object property. The object property must be of the
        /// URL: http://mm.l/mql4/docs.mql4.com/objects/objectsetstring.html
        /// </summary>
        /// <param name="chart_id">[in] Chart identifier. 0 means the current chart.</param>
        /// <param name="object_name">[in] Name of the object.</param>
        /// <param name="prop_id">[in] ID of the object property. The value can be one of the values of the enumeration.</param>
        /// <param name="prop_value">[in] The value of the property.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/objectsetstring")]
        public void Handle_ObjectSetString_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, ObjectSetString_1(context, chartid));
        }

        /// <summary>
        /// Function: ObjectSetString
        /// Description: The function sets the value of the corresponding object property. The object property must be of the
        /// URL: http://mm.l/mql4/docs.mql4.com/objects/objectsetstring.html
        /// </summary>
        /// <param name="chart_id">[in] Chart identifier. 0 means the current chart.</param>
        /// <param name="object_name">[in] Name of the object.</param>
        /// <param name="prop_id">[in] ID of the object property. The value can be one of the values of the enumeration.</param>
        /// <param name="prop_value">[in] The value of the property.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/objectsetstring")]
        public void Handle_ObjectSetString_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, ObjectSetString_1(context, DEFAULT_CHART_ID));
        }

        private JObject ObjectSetString_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            parameters.Add(payload["chart_id"]);
            parameters.Add(payload["object_name"]);
            parameters.Add(payload["prop_id"]);
            parameters.Add(payload["prop_value"]);
            int id = mqlCommandManager.ExecCommand(MQLCommand.ObjectSetString_1, parameters); // MQLCommand ENUM = 185
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = (bool)mqlCommandManager.GetCommandResult(id);
            return result;
        }
        /// <summary>
        /// Function: ObjectSetString
        /// Description: The function sets the value of the corresponding object property. The object property must be of the
        /// URL: http://mm.l/mql4/docs.mql4.com/objects/objectsetstring.html
        /// </summary>
        /// <param name="chart_id">[in] Chart identifier. 0 means the current chart.</param>
        /// <param name="object_name">[in] Name of the object.</param>
        /// <param name="prop_id">[in] ID of the object property. The value can be one of the values of the enumeration.</param>
        /// <param name="prop_modifier">[in] Modifier of the specified property. It denotes the number of the level in and in the graphical object Andrew's pitchfork. The numeration of levels starts from zero.</param>
        /// <param name="prop_value">[in] The value of the property.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/objectsetstring")]
        public void Handle_ObjectSetString_2(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, ObjectSetString_2(context, chartid));
        }

        /// <summary>
        /// Function: ObjectSetString
        /// Description: The function sets the value of the corresponding object property. The object property must be of the
        /// URL: http://mm.l/mql4/docs.mql4.com/objects/objectsetstring.html
        /// </summary>
        /// <param name="chart_id">[in] Chart identifier. 0 means the current chart.</param>
        /// <param name="object_name">[in] Name of the object.</param>
        /// <param name="prop_id">[in] ID of the object property. The value can be one of the values of the enumeration.</param>
        /// <param name="prop_modifier">[in] Modifier of the specified property. It denotes the number of the level in and in the graphical object Andrew's pitchfork. The numeration of levels starts from zero.</param>
        /// <param name="prop_value">[in] The value of the property.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/objectsetstring")]
        public void Handle_ObjectSetString_2_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, ObjectSetString_2(context, DEFAULT_CHART_ID));
        }

        private JObject ObjectSetString_2(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            parameters.Add(payload["chart_id"]);
            parameters.Add(payload["object_name"]);
            parameters.Add(payload["prop_id"]);
            parameters.Add(payload["prop_modifier"]);
            parameters.Add(payload["prop_value"]);
            int id = mqlCommandManager.ExecCommand(MQLCommand.ObjectSetString_2, parameters); // MQLCommand ENUM = 185
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = (bool)mqlCommandManager.GetCommandResult(id);
            return result;
        }
        /// <summary>
        /// Function: TextSetFont
        /// Description: The function sets the font for displaying the text using drawing methods and returns the result of that operation. Arial font with the size -120 (12 pt) is used by default.
        /// URL: http://mm.l/mql4/docs.mql4.com/objects/textsetfont.html
        /// </summary>
        /// <param name="name">[in] Font name in the system or the name of the resource containing the font or the path to font file on the disk.</param>
        /// <param name="size">[in] The font size that can be set using positive and negative values. In case of positive values, the size of a displayed text does not depend on the operating system's font size settings. In case of negative values, the value is set in tenths of a point and the text size depends on the operating system settings ("standard scale" or "large scale"). See the Note below for more information about the differences between the modes.</param>
        /// <param name="flags">[in] Combination of describing font style.</param>
        /// <param name="orientation">[in] Text's horizontal inclination to X axis, the unit of measurement is 0.1 degrees. It means that orientation=450 stands for inclination equal to 45 degrees.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/textsetfont")]
        public void Handle_TextSetFont_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, TextSetFont_1(context, chartid));
        }

        /// <summary>
        /// Function: TextSetFont
        /// Description: The function sets the font for displaying the text using drawing methods and returns the result of that operation. Arial font with the size -120 (12 pt) is used by default.
        /// URL: http://mm.l/mql4/docs.mql4.com/objects/textsetfont.html
        /// </summary>
        /// <param name="name">[in] Font name in the system or the name of the resource containing the font or the path to font file on the disk.</param>
        /// <param name="size">[in] The font size that can be set using positive and negative values. In case of positive values, the size of a displayed text does not depend on the operating system's font size settings. In case of negative values, the value is set in tenths of a point and the text size depends on the operating system settings ("standard scale" or "large scale"). See the Note below for more information about the differences between the modes.</param>
        /// <param name="flags">[in] Combination of describing font style.</param>
        /// <param name="orientation">[in] Text's horizontal inclination to X axis, the unit of measurement is 0.1 degrees. It means that orientation=450 stands for inclination equal to 45 degrees.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/textsetfont")]
        public void Handle_TextSetFont_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, TextSetFont_1(context, DEFAULT_CHART_ID));
        }

        private JObject TextSetFont_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            parameters.Add(payload["name"]);
            parameters.Add(payload["size"]);
            parameters.Add(payload["flags"]);
            parameters.Add(payload["orientation"]);
            int id = mqlCommandManager.ExecCommand(MQLCommand.TextSetFont_1, parameters); // MQLCommand ENUM = 186
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = (bool)mqlCommandManager.GetCommandResult(id);
            return result;
        }
        /// <summary>
        /// Function: ObjectDescription
        /// Description: Returns the object description.
        /// URL: http://mm.l/mql4/docs.mql4.com/objects/objectdescription.html
        /// </summary>
        /// <param name="object_name">[in] Object name.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/objectdescription")]
        public void Handle_ObjectDescription_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, ObjectDescription_1(context, chartid));
        }

        /// <summary>
        /// Function: ObjectDescription
        /// Description: Returns the object description.
        /// URL: http://mm.l/mql4/docs.mql4.com/objects/objectdescription.html
        /// </summary>
        /// <param name="object_name">[in] Object name.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/objectdescription")]
        public void Handle_ObjectDescription_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, ObjectDescription_1(context, DEFAULT_CHART_ID));
        }

        private JObject ObjectDescription_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            parameters.Add(payload["object_name"]);
            int id = mqlCommandManager.ExecCommand(MQLCommand.ObjectDescription_1, parameters); // MQLCommand ENUM = 187
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = (string)mqlCommandManager.GetCommandResult(id);
            return result;
        }
        /// <summary>
        /// Function: ObjectGet
        /// Description: Returns the value of the specified object property.
        /// URL: http://mm.l/mql4/docs.mql4.com/objects/objectget.html
        /// </summary>
        /// <param name="object_name">[in] Object name.</param>
        /// <param name="index">[in] Object property index. It can be any of the enumeration values.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/objectget")]
        public void Handle_ObjectGet_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, ObjectGet_1(context, chartid));
        }

        /// <summary>
        /// Function: ObjectGet
        /// Description: Returns the value of the specified object property.
        /// URL: http://mm.l/mql4/docs.mql4.com/objects/objectget.html
        /// </summary>
        /// <param name="object_name">[in] Object name.</param>
        /// <param name="index">[in] Object property index. It can be any of the enumeration values.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/objectget")]
        public void Handle_ObjectGet_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, ObjectGet_1(context, DEFAULT_CHART_ID));
        }

        private JObject ObjectGet_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            parameters.Add(payload["object_name"]);
            parameters.Add(payload["index"]);
            int id = mqlCommandManager.ExecCommand(MQLCommand.ObjectGet_1, parameters); // MQLCommand ENUM = 188
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = Convert.ToDecimal(mqlCommandManager.GetCommandResult(id));
            return result;
        }
        /// <summary>
        /// Function: ObjectGetFiboDescription
        /// Description: Returns the level description of a Fibonacci object.
        /// URL: http://mm.l/mql4/docs.mql4.com/objects/objectgetfibodescription.html
        /// </summary>
        /// <param name="object_name">[in] Fibonacci object name.</param>
        /// <param name="index">[in] Index of the Fibonacci level (0-31).</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/objectgetfibodescription")]
        public void Handle_ObjectGetFiboDescription_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, ObjectGetFiboDescription_1(context, chartid));
        }

        /// <summary>
        /// Function: ObjectGetFiboDescription
        /// Description: Returns the level description of a Fibonacci object.
        /// URL: http://mm.l/mql4/docs.mql4.com/objects/objectgetfibodescription.html
        /// </summary>
        /// <param name="object_name">[in] Fibonacci object name.</param>
        /// <param name="index">[in] Index of the Fibonacci level (0-31).</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/objectgetfibodescription")]
        public void Handle_ObjectGetFiboDescription_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, ObjectGetFiboDescription_1(context, DEFAULT_CHART_ID));
        }

        private JObject ObjectGetFiboDescription_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            parameters.Add(payload["object_name"]);
            parameters.Add(payload["index"]);
            int id = mqlCommandManager.ExecCommand(MQLCommand.ObjectGetFiboDescription_1, parameters); // MQLCommand ENUM = 189
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = (string)mqlCommandManager.GetCommandResult(id);
            return result;
        }
        /// <summary>
        /// Function: ObjectGetShiftByValue
        /// Description: The function calculates and returns bar index (shift related to the current bar) for the given price.
        /// URL: http://mm.l/mql4/docs.mql4.com/objects/objectgetshiftbyvalue.html
        /// </summary>
        /// <param name="object_name">[in] Object name.</param>
        /// <param name="value">[in] Price value.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/objectgetshiftbyvalue")]
        public void Handle_ObjectGetShiftByValue_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, ObjectGetShiftByValue_1(context, chartid));
        }

        /// <summary>
        /// Function: ObjectGetShiftByValue
        /// Description: The function calculates and returns bar index (shift related to the current bar) for the given price.
        /// URL: http://mm.l/mql4/docs.mql4.com/objects/objectgetshiftbyvalue.html
        /// </summary>
        /// <param name="object_name">[in] Object name.</param>
        /// <param name="value">[in] Price value.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/objectgetshiftbyvalue")]
        public void Handle_ObjectGetShiftByValue_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, ObjectGetShiftByValue_1(context, DEFAULT_CHART_ID));
        }

        private JObject ObjectGetShiftByValue_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            parameters.Add(payload["object_name"]);
            parameters.Add(payload["value"]);
            int id = mqlCommandManager.ExecCommand(MQLCommand.ObjectGetShiftByValue_1, parameters); // MQLCommand ENUM = 190
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = Convert.ToInt32(mqlCommandManager.GetCommandResult(id));
            return result;
        }
        /// <summary>
        /// Function: ObjectGetValueByShift
        /// Description: The function calculates and returns the price value for the specified bar (shift related to the current bar).
        /// URL: http://mm.l/mql4/docs.mql4.com/objects/objectgetvaluebyshift.html
        /// </summary>
        /// <param name="object_name">[in] Object name.</param>
        /// <param name="shift">[in] Bar index.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/objectgetvaluebyshift")]
        public void Handle_ObjectGetValueByShift_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, ObjectGetValueByShift_1(context, chartid));
        }

        /// <summary>
        /// Function: ObjectGetValueByShift
        /// Description: The function calculates and returns the price value for the specified bar (shift related to the current bar).
        /// URL: http://mm.l/mql4/docs.mql4.com/objects/objectgetvaluebyshift.html
        /// </summary>
        /// <param name="object_name">[in] Object name.</param>
        /// <param name="shift">[in] Bar index.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/objectgetvaluebyshift")]
        public void Handle_ObjectGetValueByShift_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, ObjectGetValueByShift_1(context, DEFAULT_CHART_ID));
        }

        private JObject ObjectGetValueByShift_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            parameters.Add(payload["object_name"]);
            parameters.Add(payload["shift"]);
            int id = mqlCommandManager.ExecCommand(MQLCommand.ObjectGetValueByShift_1, parameters); // MQLCommand ENUM = 191
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = Convert.ToDecimal(mqlCommandManager.GetCommandResult(id));
            return result;
        }
        /// <summary>
        /// Function: ObjectSet
        /// Description: Changes the value of the specified object property.
        /// URL: http://mm.l/mql4/docs.mql4.com/objects/objectset.html
        /// </summary>
        /// <param name="object_name">[in] Object name.</param>
        /// <param name="index">[in] Object property index. It can be any of enumeration values.</param>
        /// <param name="value">[in] New value of the given property.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/objectset")]
        public void Handle_ObjectSet_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, ObjectSet_1(context, chartid));
        }

        /// <summary>
        /// Function: ObjectSet
        /// Description: Changes the value of the specified object property.
        /// URL: http://mm.l/mql4/docs.mql4.com/objects/objectset.html
        /// </summary>
        /// <param name="object_name">[in] Object name.</param>
        /// <param name="index">[in] Object property index. It can be any of enumeration values.</param>
        /// <param name="value">[in] New value of the given property.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/objectset")]
        public void Handle_ObjectSet_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, ObjectSet_1(context, DEFAULT_CHART_ID));
        }

        private JObject ObjectSet_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            parameters.Add(payload["object_name"]);
            parameters.Add(payload["index"]);
            parameters.Add(payload["value"]);
            int id = mqlCommandManager.ExecCommand(MQLCommand.ObjectSet_1, parameters); // MQLCommand ENUM = 192
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = (bool)mqlCommandManager.GetCommandResult(id);
            return result;
        }
        /// <summary>
        /// Function: ObjectSetFiboDescription
        /// Description: The function sets a new description to a level of a Fibonacci object.
        /// URL: http://mm.l/mql4/docs.mql4.com/objects/objectsetfibodescription.html
        /// </summary>
        /// <param name="object_name">[in] Object name.</param>
        /// <param name="index">[in] Index of the Fibonacci level (0-31).</param>
        /// <param name="text">[in] New description of the level.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/objectsetfibodescription")]
        public void Handle_ObjectSetFiboDescription_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, ObjectSetFiboDescription_1(context, chartid));
        }

        /// <summary>
        /// Function: ObjectSetFiboDescription
        /// Description: The function sets a new description to a level of a Fibonacci object.
        /// URL: http://mm.l/mql4/docs.mql4.com/objects/objectsetfibodescription.html
        /// </summary>
        /// <param name="object_name">[in] Object name.</param>
        /// <param name="index">[in] Index of the Fibonacci level (0-31).</param>
        /// <param name="text">[in] New description of the level.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/objectsetfibodescription")]
        public void Handle_ObjectSetFiboDescription_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, ObjectSetFiboDescription_1(context, DEFAULT_CHART_ID));
        }

        private JObject ObjectSetFiboDescription_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            parameters.Add(payload["object_name"]);
            parameters.Add(payload["index"]);
            parameters.Add(payload["text"]);
            int id = mqlCommandManager.ExecCommand(MQLCommand.ObjectSetFiboDescription_1, parameters); // MQLCommand ENUM = 193
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = (bool)mqlCommandManager.GetCommandResult(id);
            return result;
        }
        /// <summary>
        /// Function: ObjectSetText
        /// Description: The function c
        /// URL: http://mm.l/mql4/docs.mql4.com/objects/objectsettext.html
        /// </summary>
        /// <param name="object_name">[in] Object name.</param>
        /// <param name="text">[in] A text describing the object.</param>
        /// <param name="font_size">[in] Font size in points.</param>
        /// <param name="font_name">[in] Font name.</param>
        /// <param name="text_color">[in] Font color.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/objectsettext")]
        public void Handle_ObjectSetText_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, ObjectSetText_1(context, chartid));
        }

        /// <summary>
        /// Function: ObjectSetText
        /// Description: The function c
        /// URL: http://mm.l/mql4/docs.mql4.com/objects/objectsettext.html
        /// </summary>
        /// <param name="object_name">[in] Object name.</param>
        /// <param name="text">[in] A text describing the object.</param>
        /// <param name="font_size">[in] Font size in points.</param>
        /// <param name="font_name">[in] Font name.</param>
        /// <param name="text_color">[in] Font color.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/objectsettext")]
        public void Handle_ObjectSetText_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, ObjectSetText_1(context, DEFAULT_CHART_ID));
        }

        private JObject ObjectSetText_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            parameters.Add(payload["object_name"]);
            parameters.Add(payload["text"]);
            parameters.Add(payload["font_size"]);
            parameters.Add(payload["font_name"]);
            parameters.Add(payload["text_color"]);
            int id = mqlCommandManager.ExecCommand(MQLCommand.ObjectSetText_1, parameters); // MQLCommand ENUM = 194
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = (bool)mqlCommandManager.GetCommandResult(id);
            return result;
        }
        /// <summary>
        /// Function: ObjectType
        /// Description: The function returns the object type value.
        /// URL: http://mm.l/mql4/docs.mql4.com/objects/objecttype.html
        /// </summary>
        /// <param name="object_name">[in] Object name.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/objecttype")]
        public void Handle_ObjectType_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, ObjectType_1(context, chartid));
        }

        /// <summary>
        /// Function: ObjectType
        /// Description: The function returns the object type value.
        /// URL: http://mm.l/mql4/docs.mql4.com/objects/objecttype.html
        /// </summary>
        /// <param name="object_name">[in] Object name.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/objecttype")]
        public void Handle_ObjectType_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, ObjectType_1(context, DEFAULT_CHART_ID));
        }

        private JObject ObjectType_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            parameters.Add(payload["object_name"]);
            int id = mqlCommandManager.ExecCommand(MQLCommand.ObjectType_1, parameters); // MQLCommand ENUM = 195
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = Convert.ToInt32(mqlCommandManager.GetCommandResult(id));
            return result;
        }
        /// <summary>
        /// Function: iAC
        /// Description: Calculates the Bill Williams' Accelerator/Decelerator oscillator and returns its value.
        /// URL: http://mm.l/mql4/docs.mql4.com/indicators/iac.html
        /// </summary>
        /// <param name="symbol">[in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</param>
        /// <param name="timeframe">[in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</param>
        /// <param name="shift">[in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/iac")]
        public void Handle_iAC_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, iAC_1(context, chartid));
        }

        /// <summary>
        /// Function: iAC
        /// Description: Calculates the Bill Williams' Accelerator/Decelerator oscillator and returns its value.
        /// URL: http://mm.l/mql4/docs.mql4.com/indicators/iac.html
        /// </summary>
        /// <param name="symbol">[in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</param>
        /// <param name="timeframe">[in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</param>
        /// <param name="shift">[in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/iac")]
        public void Handle_iAC_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, iAC_1(context, DEFAULT_CHART_ID));
        }

        private JObject iAC_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            parameters.Add(payload["symbol"]);
            parameters.Add(payload["timeframe"]);
            parameters.Add(payload["shift"]);
            int id = mqlCommandManager.ExecCommand(MQLCommand.iAC_1, parameters); // MQLCommand ENUM = 196
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = Convert.ToDecimal(mqlCommandManager.GetCommandResult(id));
            return result;
        }
        /// <summary>
        /// Function: iAD
        /// Description: Calculates the Accumulation/Distribution indicator and returns its value.
        /// URL: http://mm.l/mql4/docs.mql4.com/indicators/iad.html
        /// </summary>
        /// <param name="symbol">[in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</param>
        /// <param name="timeframe">[in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</param>
        /// <param name="shift">[in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/iad")]
        public void Handle_iAD_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, iAD_1(context, chartid));
        }

        /// <summary>
        /// Function: iAD
        /// Description: Calculates the Accumulation/Distribution indicator and returns its value.
        /// URL: http://mm.l/mql4/docs.mql4.com/indicators/iad.html
        /// </summary>
        /// <param name="symbol">[in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</param>
        /// <param name="timeframe">[in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</param>
        /// <param name="shift">[in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/iad")]
        public void Handle_iAD_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, iAD_1(context, DEFAULT_CHART_ID));
        }

        private JObject iAD_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            parameters.Add(payload["symbol"]);
            parameters.Add(payload["timeframe"]);
            parameters.Add(payload["shift"]);
            int id = mqlCommandManager.ExecCommand(MQLCommand.iAD_1, parameters); // MQLCommand ENUM = 197
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = Convert.ToDecimal(mqlCommandManager.GetCommandResult(id));
            return result;
        }
        /// <summary>
        /// Function: iADX
        /// Description: Calculates the Average Directional Movement Index indicator and returns its value.
        /// URL: http://mm.l/mql4/docs.mql4.com/indicators/iadx.html
        /// </summary>
        /// <param name="symbol">[in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</param>
        /// <param name="timeframe">[in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</param>
        /// <param name="period">[in] Averaging period for calculation.</param>
        /// <param name="applied_price">[in] Applied price. It can be any of enumeration values.</param>
        /// <param name="mode">[in] Indicator line index. It can be any of the enumeration value. (0 - MODE_MAIN, 1 - MODE_PLUSDI, 2 - MODE_MINUSDI).</param>
        /// <param name="shift">[in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/iadx")]
        public void Handle_iADX_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, iADX_1(context, chartid));
        }

        /// <summary>
        /// Function: iADX
        /// Description: Calculates the Average Directional Movement Index indicator and returns its value.
        /// URL: http://mm.l/mql4/docs.mql4.com/indicators/iadx.html
        /// </summary>
        /// <param name="symbol">[in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</param>
        /// <param name="timeframe">[in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</param>
        /// <param name="period">[in] Averaging period for calculation.</param>
        /// <param name="applied_price">[in] Applied price. It can be any of enumeration values.</param>
        /// <param name="mode">[in] Indicator line index. It can be any of the enumeration value. (0 - MODE_MAIN, 1 - MODE_PLUSDI, 2 - MODE_MINUSDI).</param>
        /// <param name="shift">[in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/iadx")]
        public void Handle_iADX_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, iADX_1(context, DEFAULT_CHART_ID));
        }

        private JObject iADX_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            parameters.Add(payload["symbol"]);
            parameters.Add(payload["timeframe"]);
            parameters.Add(payload["period"]);
            parameters.Add(payload["applied_price"]);
            parameters.Add(payload["mode"]);
            parameters.Add(payload["shift"]);
            int id = mqlCommandManager.ExecCommand(MQLCommand.iADX_1, parameters); // MQLCommand ENUM = 198
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = Convert.ToDecimal(mqlCommandManager.GetCommandResult(id));
            return result;
        }
        /// <summary>
        /// Function: iAlligator
        /// Description: Calculates the Alligator indicator and returns its value.
        /// URL: http://mm.l/mql4/docs.mql4.com/indicators/ialligator.html
        /// </summary>
        /// <param name="symbol">[in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</param>
        /// <param name="timeframe">[in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</param>
        /// <param name="jaw_period">[in] Blue line averaging period (Alligator's Jaw).</param>
        /// <param name="jaw_shift">[in] Blue line shift relative to the chart.</param>
        /// <param name="teeth_period">[in] Red line averaging period (Alligator's Teeth).</param>
        /// <param name="teeth_shift">[in] Red line shift relative to the chart.</param>
        /// <param name="lips_period">[in] Green line averaging period (Alligator's Lips).</param>
        /// <param name="lips_shift">[in] Green line shift relative to the chart.</param>
        /// <param name="ma_method">[in] MA method. It can be any of Moving Average methods. It can be any of enumeration values.</param>
        /// <param name="applied_price">[in] Applied price. It can be any of enumeration values.</param>
        /// <param name="mode">[in] Data source, identifier of the . It can be any of the following values:</param>
        /// <param name="shift">MODE_GATORJAW - Gator Jaw (blue) balance line,MODE_GATORTEETH - Gator Teeth (red) balance line,MODE_GATORLIPS - Gator Lips (green) balance line.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/ialligator")]
        public void Handle_iAlligator_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, iAlligator_1(context, chartid));
        }

        /// <summary>
        /// Function: iAlligator
        /// Description: Calculates the Alligator indicator and returns its value.
        /// URL: http://mm.l/mql4/docs.mql4.com/indicators/ialligator.html
        /// </summary>
        /// <param name="symbol">[in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</param>
        /// <param name="timeframe">[in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</param>
        /// <param name="jaw_period">[in] Blue line averaging period (Alligator's Jaw).</param>
        /// <param name="jaw_shift">[in] Blue line shift relative to the chart.</param>
        /// <param name="teeth_period">[in] Red line averaging period (Alligator's Teeth).</param>
        /// <param name="teeth_shift">[in] Red line shift relative to the chart.</param>
        /// <param name="lips_period">[in] Green line averaging period (Alligator's Lips).</param>
        /// <param name="lips_shift">[in] Green line shift relative to the chart.</param>
        /// <param name="ma_method">[in] MA method. It can be any of Moving Average methods. It can be any of enumeration values.</param>
        /// <param name="applied_price">[in] Applied price. It can be any of enumeration values.</param>
        /// <param name="mode">[in] Data source, identifier of the . It can be any of the following values:</param>
        /// <param name="shift">MODE_GATORJAW - Gator Jaw (blue) balance line,MODE_GATORTEETH - Gator Teeth (red) balance line,MODE_GATORLIPS - Gator Lips (green) balance line.</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/ialligator")]
        public void Handle_iAlligator_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, iAlligator_1(context, DEFAULT_CHART_ID));
        }

        private JObject iAlligator_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            parameters.Add(payload["symbol"]);
            parameters.Add(payload["timeframe"]);
            parameters.Add(payload["jaw_period"]);
            parameters.Add(payload["jaw_shift"]);
            parameters.Add(payload["teeth_period"]);
            parameters.Add(payload["teeth_shift"]);
            parameters.Add(payload["lips_period"]);
            parameters.Add(payload["lips_shift"]);
            parameters.Add(payload["ma_method"]);
            parameters.Add(payload["applied_price"]);
            parameters.Add(payload["mode"]);
            parameters.Add(payload["shift"]);
            int id = mqlCommandManager.ExecCommand(MQLCommand.iAlligator_1, parameters); // MQLCommand ENUM = 199
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = Convert.ToDecimal(mqlCommandManager.GetCommandResult(id));
            return result;
        }
        /// <summary>
        /// Function: iAO
        /// Description: Calculates the Awesome oscillator and returns its value.
        /// URL: http://mm.l/mql4/docs.mql4.com/indicators/iao.html
        /// </summary>
        /// <param name="symbol">[in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</param>
        /// <param name="timeframe">[in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</param>
        /// <param name="shift">[in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/iao")]
        public void Handle_iAO_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, iAO_1(context, chartid));
        }

        /// <summary>
        /// Function: iAO
        /// Description: Calculates the Awesome oscillator and returns its value.
        /// URL: http://mm.l/mql4/docs.mql4.com/indicators/iao.html
        /// </summary>
        /// <param name="symbol">[in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</param>
        /// <param name="timeframe">[in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</param>
        /// <param name="shift">[in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/iao")]
        public void Handle_iAO_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, iAO_1(context, DEFAULT_CHART_ID));
        }

        private JObject iAO_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            parameters.Add(payload["symbol"]);
            parameters.Add(payload["timeframe"]);
            parameters.Add(payload["shift"]);
            int id = mqlCommandManager.ExecCommand(MQLCommand.iAO_1, parameters); // MQLCommand ENUM = 200
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = Convert.ToDecimal(mqlCommandManager.GetCommandResult(id));
            return result;
        }
        /// <summary>
        /// Function: iATR
        /// Description: Calculates the Average True Range indicator and returns its value.
        /// URL: http://mm.l/mql4/docs.mql4.com/indicators/iatr.html
        /// </summary>
        /// <param name="symbol">[in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</param>
        /// <param name="timeframe">[in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</param>
        /// <param name="period">[in] Averaging period.</param>
        /// <param name="shift">[in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/iatr")]
        public void Handle_iATR_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, iATR_1(context, chartid));
        }

        /// <summary>
        /// Function: iATR
        /// Description: Calculates the Average True Range indicator and returns its value.
        /// URL: http://mm.l/mql4/docs.mql4.com/indicators/iatr.html
        /// </summary>
        /// <param name="symbol">[in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</param>
        /// <param name="timeframe">[in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</param>
        /// <param name="period">[in] Averaging period.</param>
        /// <param name="shift">[in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/iatr")]
        public void Handle_iATR_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, iATR_1(context, DEFAULT_CHART_ID));
        }

        private JObject iATR_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            parameters.Add(payload["symbol"]);
            parameters.Add(payload["timeframe"]);
            parameters.Add(payload["period"]);
            parameters.Add(payload["shift"]);
            int id = mqlCommandManager.ExecCommand(MQLCommand.iATR_1, parameters); // MQLCommand ENUM = 201
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = Convert.ToDecimal(mqlCommandManager.GetCommandResult(id));
            return result;
        }
        /// <summary>
        /// Function: iBearsPower
        /// Description: Calculates the Bears Power indicator and returns its value.
        /// URL: http://mm.l/mql4/docs.mql4.com/indicators/ibearspower.html
        /// </summary>
        /// <param name="symbol">[in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</param>
        /// <param name="timeframe">[in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</param>
        /// <param name="period">[in] Averaging period.</param>
        /// <param name="applied_price">[in] Applied price. It can be any of enumeration values.</param>
        /// <param name="shift">[in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/ibearspower")]
        public void Handle_iBearsPower_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, iBearsPower_1(context, chartid));
        }

        /// <summary>
        /// Function: iBearsPower
        /// Description: Calculates the Bears Power indicator and returns its value.
        /// URL: http://mm.l/mql4/docs.mql4.com/indicators/ibearspower.html
        /// </summary>
        /// <param name="symbol">[in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</param>
        /// <param name="timeframe">[in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</param>
        /// <param name="period">[in] Averaging period.</param>
        /// <param name="applied_price">[in] Applied price. It can be any of enumeration values.</param>
        /// <param name="shift">[in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/ibearspower")]
        public void Handle_iBearsPower_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, iBearsPower_1(context, DEFAULT_CHART_ID));
        }

        private JObject iBearsPower_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            parameters.Add(payload["symbol"]);
            parameters.Add(payload["timeframe"]);
            parameters.Add(payload["period"]);
            parameters.Add(payload["applied_price"]);
            parameters.Add(payload["shift"]);
            int id = mqlCommandManager.ExecCommand(MQLCommand.iBearsPower_1, parameters); // MQLCommand ENUM = 202
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = Convert.ToDecimal(mqlCommandManager.GetCommandResult(id));
            return result;
        }
        /// <summary>
        /// Function: iBands
        /// Description: Calculates the Bollinger Bands indicator and returns its value.
        /// URL: http://mm.l/mql4/docs.mql4.com/indicators/ibands.html
        /// </summary>
        /// <param name="symbol">[in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</param>
        /// <param name="timeframe">[in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</param>
        /// <param name="period">[in] Averaging period to calculate the main line.</param>
        /// <param name="deviation">[in] Number of standard deviations from the main line.</param>
        /// <param name="bands_shift">[in] The indicator shift relative to the chart.</param>
        /// <param name="applied_price">[in] Applied price. It can be any of enumeration values.</param>
        /// <param name="mode">[in] Indicator line index. It can be any of the enumeration value (0 - MODE_MAIN, 1 - MODE_UPPER, 2 - MODE_LOWER).</param>
        /// <param name="shift">[in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/ibands")]
        public void Handle_iBands_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, iBands_1(context, chartid));
        }

        /// <summary>
        /// Function: iBands
        /// Description: Calculates the Bollinger Bands indicator and returns its value.
        /// URL: http://mm.l/mql4/docs.mql4.com/indicators/ibands.html
        /// </summary>
        /// <param name="symbol">[in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</param>
        /// <param name="timeframe">[in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</param>
        /// <param name="period">[in] Averaging period to calculate the main line.</param>
        /// <param name="deviation">[in] Number of standard deviations from the main line.</param>
        /// <param name="bands_shift">[in] The indicator shift relative to the chart.</param>
        /// <param name="applied_price">[in] Applied price. It can be any of enumeration values.</param>
        /// <param name="mode">[in] Indicator line index. It can be any of the enumeration value (0 - MODE_MAIN, 1 - MODE_UPPER, 2 - MODE_LOWER).</param>
        /// <param name="shift">[in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/ibands")]
        public void Handle_iBands_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, iBands_1(context, DEFAULT_CHART_ID));
        }

        private JObject iBands_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            parameters.Add(payload["symbol"]);
            parameters.Add(payload["timeframe"]);
            parameters.Add(payload["period"]);
            parameters.Add(payload["deviation"]);
            parameters.Add(payload["bands_shift"]);
            parameters.Add(payload["applied_price"]);
            parameters.Add(payload["mode"]);
            parameters.Add(payload["shift"]);
            int id = mqlCommandManager.ExecCommand(MQLCommand.iBands_1, parameters); // MQLCommand ENUM = 203
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = Convert.ToDecimal(mqlCommandManager.GetCommandResult(id));
            return result;
        }
        /// <summary>
        /// Function: iBullsPower
        /// Description: Calculates the Bulls Power indicator and returns its value.
        /// URL: http://mm.l/mql4/docs.mql4.com/indicators/ibullspower.html
        /// </summary>
        /// <param name="symbol">[in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</param>
        /// <param name="timeframe">[in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</param>
        /// <param name="period">[in] Averaging period for calculation.</param>
        /// <param name="applied_price">[in] Applied price. It can be any of enumeration values.</param>
        /// <param name="shift">[in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/ibullspower")]
        public void Handle_iBullsPower_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, iBullsPower_1(context, chartid));
        }

        /// <summary>
        /// Function: iBullsPower
        /// Description: Calculates the Bulls Power indicator and returns its value.
        /// URL: http://mm.l/mql4/docs.mql4.com/indicators/ibullspower.html
        /// </summary>
        /// <param name="symbol">[in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</param>
        /// <param name="timeframe">[in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</param>
        /// <param name="period">[in] Averaging period for calculation.</param>
        /// <param name="applied_price">[in] Applied price. It can be any of enumeration values.</param>
        /// <param name="shift">[in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/ibullspower")]
        public void Handle_iBullsPower_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, iBullsPower_1(context, DEFAULT_CHART_ID));
        }

        private JObject iBullsPower_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            parameters.Add(payload["symbol"]);
            parameters.Add(payload["timeframe"]);
            parameters.Add(payload["period"]);
            parameters.Add(payload["applied_price"]);
            parameters.Add(payload["shift"]);
            int id = mqlCommandManager.ExecCommand(MQLCommand.iBullsPower_1, parameters); // MQLCommand ENUM = 204
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = Convert.ToDecimal(mqlCommandManager.GetCommandResult(id));
            return result;
        }
        /// <summary>
        /// Function: iCCI
        /// Description: Calculates the Commodity Channel Index indicator and returns its value.
        /// URL: http://mm.l/mql4/docs.mql4.com/indicators/icci.html
        /// </summary>
        /// <param name="symbol">[in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</param>
        /// <param name="timeframe">[in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</param>
        /// <param name="period">[in] Averaging period for calculation.</param>
        /// <param name="applied_price">[in] Applied price. It can be any of enumeration values.</param>
        /// <param name="shift">[in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/icci")]
        public void Handle_iCCI_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, iCCI_1(context, chartid));
        }

        /// <summary>
        /// Function: iCCI
        /// Description: Calculates the Commodity Channel Index indicator and returns its value.
        /// URL: http://mm.l/mql4/docs.mql4.com/indicators/icci.html
        /// </summary>
        /// <param name="symbol">[in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</param>
        /// <param name="timeframe">[in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</param>
        /// <param name="period">[in] Averaging period for calculation.</param>
        /// <param name="applied_price">[in] Applied price. It can be any of enumeration values.</param>
        /// <param name="shift">[in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/icci")]
        public void Handle_iCCI_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, iCCI_1(context, DEFAULT_CHART_ID));
        }

        private JObject iCCI_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            parameters.Add(payload["symbol"]);
            parameters.Add(payload["timeframe"]);
            parameters.Add(payload["period"]);
            parameters.Add(payload["applied_price"]);
            parameters.Add(payload["shift"]);
            int id = mqlCommandManager.ExecCommand(MQLCommand.iCCI_1, parameters); // MQLCommand ENUM = 205
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = Convert.ToDecimal(mqlCommandManager.GetCommandResult(id));
            return result;
        }
        /// <summary>
        /// Function: iDeMarker
        /// Description: Calculates the DeMarker indicator and returns its value.
        /// URL: http://mm.l/mql4/docs.mql4.com/indicators/idemarker.html
        /// </summary>
        /// <param name="symbol">[in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</param>
        /// <param name="timeframe">[in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</param>
        /// <param name="period">[in] Averaging period for calculation.</param>
        /// <param name="shift">[in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/idemarker")]
        public void Handle_iDeMarker_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, iDeMarker_1(context, chartid));
        }

        /// <summary>
        /// Function: iDeMarker
        /// Description: Calculates the DeMarker indicator and returns its value.
        /// URL: http://mm.l/mql4/docs.mql4.com/indicators/idemarker.html
        /// </summary>
        /// <param name="symbol">[in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</param>
        /// <param name="timeframe">[in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</param>
        /// <param name="period">[in] Averaging period for calculation.</param>
        /// <param name="shift">[in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/idemarker")]
        public void Handle_iDeMarker_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, iDeMarker_1(context, DEFAULT_CHART_ID));
        }

        private JObject iDeMarker_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            parameters.Add(payload["symbol"]);
            parameters.Add(payload["timeframe"]);
            parameters.Add(payload["period"]);
            parameters.Add(payload["shift"]);
            int id = mqlCommandManager.ExecCommand(MQLCommand.iDeMarker_1, parameters); // MQLCommand ENUM = 206
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = Convert.ToDecimal(mqlCommandManager.GetCommandResult(id));
            return result;
        }
        /// <summary>
        /// Function: iEnvelopes
        /// Description: Calculates the Envelopes indicator and returns its value.
        /// URL: http://mm.l/mql4/docs.mql4.com/indicators/ienvelopes.html
        /// </summary>
        /// <param name="symbol">[in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</param>
        /// <param name="timeframe">[in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</param>
        /// <param name="ma_period">[in] Averaging period for calculation of the main line.</param>
        /// <param name="ma_method">[in] Moving Average method. It can be any of enumeration values.</param>
        /// <param name="ma_shift">[in] MA shift. Indicator line offset relate to the chart by timeframe.</param>
        /// <param name="applied_price">[in] Applied price. It can be any of enumeration values.</param>
        /// <param name="deviation">[in] Percent deviation from the main line.</param>
        /// <param name="mode">[in] Indicator line index. It can be any of enumeration value (0 - MODE_MAIN, 1 - MODE_UPPER, 2 - MODE_LOWER).</param>
        /// <param name="shift">[in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/ienvelopes")]
        public void Handle_iEnvelopes_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, iEnvelopes_1(context, chartid));
        }

        /// <summary>
        /// Function: iEnvelopes
        /// Description: Calculates the Envelopes indicator and returns its value.
        /// URL: http://mm.l/mql4/docs.mql4.com/indicators/ienvelopes.html
        /// </summary>
        /// <param name="symbol">[in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</param>
        /// <param name="timeframe">[in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</param>
        /// <param name="ma_period">[in] Averaging period for calculation of the main line.</param>
        /// <param name="ma_method">[in] Moving Average method. It can be any of enumeration values.</param>
        /// <param name="ma_shift">[in] MA shift. Indicator line offset relate to the chart by timeframe.</param>
        /// <param name="applied_price">[in] Applied price. It can be any of enumeration values.</param>
        /// <param name="deviation">[in] Percent deviation from the main line.</param>
        /// <param name="mode">[in] Indicator line index. It can be any of enumeration value (0 - MODE_MAIN, 1 - MODE_UPPER, 2 - MODE_LOWER).</param>
        /// <param name="shift">[in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/ienvelopes")]
        public void Handle_iEnvelopes_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, iEnvelopes_1(context, DEFAULT_CHART_ID));
        }

        private JObject iEnvelopes_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            parameters.Add(payload["symbol"]);
            parameters.Add(payload["timeframe"]);
            parameters.Add(payload["ma_period"]);
            parameters.Add(payload["ma_method"]);
            parameters.Add(payload["ma_shift"]);
            parameters.Add(payload["applied_price"]);
            parameters.Add(payload["deviation"]);
            parameters.Add(payload["mode"]);
            parameters.Add(payload["shift"]);
            int id = mqlCommandManager.ExecCommand(MQLCommand.iEnvelopes_1, parameters); // MQLCommand ENUM = 207
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = Convert.ToDecimal(mqlCommandManager.GetCommandResult(id));
            return result;
        }
        /// <summary>
        /// Function: iForce
        /// Description: Calculates the Force Index indicator and returns its value.
        /// URL: http://mm.l/mql4/docs.mql4.com/indicators/iforce.html
        /// </summary>
        /// <param name="symbol">[in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</param>
        /// <param name="timeframe">[in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</param>
        /// <param name="period">[in] Averaging period for calculation.</param>
        /// <param name="ma_method">[in] Moving Average method. It can be any of enumeration values.</param>
        /// <param name="applied_price">[in] Applied price. It can be any of enumeration values.</param>
        /// <param name="shift">[in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/iforce")]
        public void Handle_iForce_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, iForce_1(context, chartid));
        }

        /// <summary>
        /// Function: iForce
        /// Description: Calculates the Force Index indicator and returns its value.
        /// URL: http://mm.l/mql4/docs.mql4.com/indicators/iforce.html
        /// </summary>
        /// <param name="symbol">[in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</param>
        /// <param name="timeframe">[in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</param>
        /// <param name="period">[in] Averaging period for calculation.</param>
        /// <param name="ma_method">[in] Moving Average method. It can be any of enumeration values.</param>
        /// <param name="applied_price">[in] Applied price. It can be any of enumeration values.</param>
        /// <param name="shift">[in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/iforce")]
        public void Handle_iForce_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, iForce_1(context, DEFAULT_CHART_ID));
        }

        private JObject iForce_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            parameters.Add(payload["symbol"]);
            parameters.Add(payload["timeframe"]);
            parameters.Add(payload["period"]);
            parameters.Add(payload["ma_method"]);
            parameters.Add(payload["applied_price"]);
            parameters.Add(payload["shift"]);
            int id = mqlCommandManager.ExecCommand(MQLCommand.iForce_1, parameters); // MQLCommand ENUM = 208
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = Convert.ToDecimal(mqlCommandManager.GetCommandResult(id));
            return result;
        }
        /// <summary>
        /// Function: iFractals
        /// Description: Calculates the Fractals indicator and returns its value.
        /// URL: http://mm.l/mql4/docs.mql4.com/indicators/ifractals.html
        /// </summary>
        /// <param name="symbol">[in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</param>
        /// <param name="timeframe">[in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</param>
        /// <param name="mode">[in] Indicator line index. It can be any of the enumeration value.</param>
        /// <param name="shift">[in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/ifractals")]
        public void Handle_iFractals_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, iFractals_1(context, chartid));
        }

        /// <summary>
        /// Function: iFractals
        /// Description: Calculates the Fractals indicator and returns its value.
        /// URL: http://mm.l/mql4/docs.mql4.com/indicators/ifractals.html
        /// </summary>
        /// <param name="symbol">[in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</param>
        /// <param name="timeframe">[in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</param>
        /// <param name="mode">[in] Indicator line index. It can be any of the enumeration value.</param>
        /// <param name="shift">[in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/ifractals")]
        public void Handle_iFractals_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, iFractals_1(context, DEFAULT_CHART_ID));
        }

        private JObject iFractals_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            parameters.Add(payload["symbol"]);
            parameters.Add(payload["timeframe"]);
            parameters.Add(payload["mode"]);
            parameters.Add(payload["shift"]);
            int id = mqlCommandManager.ExecCommand(MQLCommand.iFractals_1, parameters); // MQLCommand ENUM = 209
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = Convert.ToDecimal(mqlCommandManager.GetCommandResult(id));
            return result;
        }
        /// <summary>
        /// Function: iGator
        /// Description: Calculates the Gator oscillator and returns its value.
        /// URL: http://mm.l/mql4/docs.mql4.com/indicators/igator.html
        /// </summary>
        /// <param name="symbol">[in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</param>
        /// <param name="timeframe">[in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</param>
        /// <param name="jaw_period">[in] Blue line averaging period (Alligator's Jaw).</param>
        /// <param name="jaw_shift">[in] Blue line shift relative to the chart.</param>
        /// <param name="teeth_period">[in] Red line averaging period (Alligator's Teeth).</param>
        /// <param name="teeth_shift">[in] Red line shift relative to the chart.</param>
        /// <param name="lips_period">[in] Green line averaging period (Alligator's Lips).</param>
        /// <param name="lips_shift">[in] Green line shift relative to the chart.</param>
        /// <param name="ma_method">[in] MA method. It can be any of enumeration value.</param>
        /// <param name="applied_price">[in] Applied price. It can be any of enumeration values.</param>
        /// <param name="mode">[in] Indicator line index. It can be any of enumeration value.</param>
        /// <param name="shift">MODE_GATORJAW - blue line (Jaw line),MODE_GATORTEETH - red line (Teeth line),MODE_GATORLIPS - green line (Lips line).</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/igator")]
        public void Handle_iGator_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, iGator_1(context, chartid));
        }

        /// <summary>
        /// Function: iGator
        /// Description: Calculates the Gator oscillator and returns its value.
        /// URL: http://mm.l/mql4/docs.mql4.com/indicators/igator.html
        /// </summary>
        /// <param name="symbol">[in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</param>
        /// <param name="timeframe">[in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</param>
        /// <param name="jaw_period">[in] Blue line averaging period (Alligator's Jaw).</param>
        /// <param name="jaw_shift">[in] Blue line shift relative to the chart.</param>
        /// <param name="teeth_period">[in] Red line averaging period (Alligator's Teeth).</param>
        /// <param name="teeth_shift">[in] Red line shift relative to the chart.</param>
        /// <param name="lips_period">[in] Green line averaging period (Alligator's Lips).</param>
        /// <param name="lips_shift">[in] Green line shift relative to the chart.</param>
        /// <param name="ma_method">[in] MA method. It can be any of enumeration value.</param>
        /// <param name="applied_price">[in] Applied price. It can be any of enumeration values.</param>
        /// <param name="mode">[in] Indicator line index. It can be any of enumeration value.</param>
        /// <param name="shift">MODE_GATORJAW - blue line (Jaw line),MODE_GATORTEETH - red line (Teeth line),MODE_GATORLIPS - green line (Lips line).</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/igator")]
        public void Handle_iGator_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, iGator_1(context, DEFAULT_CHART_ID));
        }

        private JObject iGator_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            parameters.Add(payload["symbol"]);
            parameters.Add(payload["timeframe"]);
            parameters.Add(payload["jaw_period"]);
            parameters.Add(payload["jaw_shift"]);
            parameters.Add(payload["teeth_period"]);
            parameters.Add(payload["teeth_shift"]);
            parameters.Add(payload["lips_period"]);
            parameters.Add(payload["lips_shift"]);
            parameters.Add(payload["ma_method"]);
            parameters.Add(payload["applied_price"]);
            parameters.Add(payload["mode"]);
            parameters.Add(payload["shift"]);
            int id = mqlCommandManager.ExecCommand(MQLCommand.iGator_1, parameters); // MQLCommand ENUM = 210
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = Convert.ToDecimal(mqlCommandManager.GetCommandResult(id));
            return result;
        }
        /// <summary>
        /// Function: iIchimoku
        /// Description: Calculates the Ichimoku Kinko Hyo indicator and returns its value.
        /// URL: http://mm.l/mql4/docs.mql4.com/indicators/iichimoku.html
        /// </summary>
        /// <param name="symbol">[in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</param>
        /// <param name="timeframe">[in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</param>
        /// <param name="tenkan_sen">[in] Tenkan Sen averaging period.</param>
        /// <param name="kijun_sen">[in] Kijun Sen averaging period.</param>
        /// <param name="senkou_span_b">[in] Senkou SpanB averaging period.</param>
        /// <param name="mode">[in] Source of data. It can be one of the enumeration (1 - MODE_TENKANSEN, 2 - MODE_KIJUNSEN, 3 - MODE_SENKOUSPANA, 4 - MODE_SENKOUSPANB, 5 - MODE_CHIKOUSPAN).</param>
        /// <param name="shift">[in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/iichimoku")]
        public void Handle_iIchimoku_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, iIchimoku_1(context, chartid));
        }

        /// <summary>
        /// Function: iIchimoku
        /// Description: Calculates the Ichimoku Kinko Hyo indicator and returns its value.
        /// URL: http://mm.l/mql4/docs.mql4.com/indicators/iichimoku.html
        /// </summary>
        /// <param name="symbol">[in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</param>
        /// <param name="timeframe">[in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</param>
        /// <param name="tenkan_sen">[in] Tenkan Sen averaging period.</param>
        /// <param name="kijun_sen">[in] Kijun Sen averaging period.</param>
        /// <param name="senkou_span_b">[in] Senkou SpanB averaging period.</param>
        /// <param name="mode">[in] Source of data. It can be one of the enumeration (1 - MODE_TENKANSEN, 2 - MODE_KIJUNSEN, 3 - MODE_SENKOUSPANA, 4 - MODE_SENKOUSPANB, 5 - MODE_CHIKOUSPAN).</param>
        /// <param name="shift">[in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/iichimoku")]
        public void Handle_iIchimoku_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, iIchimoku_1(context, DEFAULT_CHART_ID));
        }

        private JObject iIchimoku_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            parameters.Add(payload["symbol"]);
            parameters.Add(payload["timeframe"]);
            parameters.Add(payload["tenkan_sen"]);
            parameters.Add(payload["kijun_sen"]);
            parameters.Add(payload["senkou_span_b"]);
            parameters.Add(payload["mode"]);
            parameters.Add(payload["shift"]);
            int id = mqlCommandManager.ExecCommand(MQLCommand.iIchimoku_1, parameters); // MQLCommand ENUM = 211
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = Convert.ToDecimal(mqlCommandManager.GetCommandResult(id));
            return result;
        }
        /// <summary>
        /// Function: iBWMFI
        /// Description: Calculates the Market Facilitation Index indicator and returns its value.
        /// URL: http://mm.l/mql4/docs.mql4.com/indicators/ibwmfi.html
        /// </summary>
        /// <param name="symbol">[in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</param>
        /// <param name="timeframe">[in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</param>
        /// <param name="shift">[in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/ibwmfi")]
        public void Handle_iBWMFI_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, iBWMFI_1(context, chartid));
        }

        /// <summary>
        /// Function: iBWMFI
        /// Description: Calculates the Market Facilitation Index indicator and returns its value.
        /// URL: http://mm.l/mql4/docs.mql4.com/indicators/ibwmfi.html
        /// </summary>
        /// <param name="symbol">[in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</param>
        /// <param name="timeframe">[in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</param>
        /// <param name="shift">[in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/ibwmfi")]
        public void Handle_iBWMFI_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, iBWMFI_1(context, DEFAULT_CHART_ID));
        }

        private JObject iBWMFI_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            parameters.Add(payload["symbol"]);
            parameters.Add(payload["timeframe"]);
            parameters.Add(payload["shift"]);
            int id = mqlCommandManager.ExecCommand(MQLCommand.iBWMFI_1, parameters); // MQLCommand ENUM = 212
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = Convert.ToDecimal(mqlCommandManager.GetCommandResult(id));
            return result;
        }
        /// <summary>
        /// Function: iMomentum
        /// Description: Calculates the Momentum indicator and returns its value.
        /// URL: http://mm.l/mql4/docs.mql4.com/indicators/imomentum.html
        /// </summary>
        /// <param name="symbol">[in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</param>
        /// <param name="timeframe">[in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</param>
        /// <param name="period">[in] Averaging period (amount of bars) for calculation of price changes.</param>
        /// <param name="applied_price">[in] Applied price. It can be any of enumeration values.</param>
        /// <param name="shift">[in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/imomentum")]
        public void Handle_iMomentum_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, iMomentum_1(context, chartid));
        }

        /// <summary>
        /// Function: iMomentum
        /// Description: Calculates the Momentum indicator and returns its value.
        /// URL: http://mm.l/mql4/docs.mql4.com/indicators/imomentum.html
        /// </summary>
        /// <param name="symbol">[in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</param>
        /// <param name="timeframe">[in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</param>
        /// <param name="period">[in] Averaging period (amount of bars) for calculation of price changes.</param>
        /// <param name="applied_price">[in] Applied price. It can be any of enumeration values.</param>
        /// <param name="shift">[in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/imomentum")]
        public void Handle_iMomentum_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, iMomentum_1(context, DEFAULT_CHART_ID));
        }

        private JObject iMomentum_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            parameters.Add(payload["symbol"]);
            parameters.Add(payload["timeframe"]);
            parameters.Add(payload["period"]);
            parameters.Add(payload["applied_price"]);
            parameters.Add(payload["shift"]);
            int id = mqlCommandManager.ExecCommand(MQLCommand.iMomentum_1, parameters); // MQLCommand ENUM = 213
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = Convert.ToDecimal(mqlCommandManager.GetCommandResult(id));
            return result;
        }
        /// <summary>
        /// Function: iMFI
        /// Description: Calculates the Money Flow Index indicator and returns its value.
        /// URL: http://mm.l/mql4/docs.mql4.com/indicators/imfi.html
        /// </summary>
        /// <param name="symbol">[in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</param>
        /// <param name="timeframe">[in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</param>
        /// <param name="period">[in] Period (amount of bars) for calculation of the indicator.</param>
        /// <param name="shift">[in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/imfi")]
        public void Handle_iMFI_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, iMFI_1(context, chartid));
        }

        /// <summary>
        /// Function: iMFI
        /// Description: Calculates the Money Flow Index indicator and returns its value.
        /// URL: http://mm.l/mql4/docs.mql4.com/indicators/imfi.html
        /// </summary>
        /// <param name="symbol">[in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</param>
        /// <param name="timeframe">[in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</param>
        /// <param name="period">[in] Period (amount of bars) for calculation of the indicator.</param>
        /// <param name="shift">[in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/imfi")]
        public void Handle_iMFI_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, iMFI_1(context, DEFAULT_CHART_ID));
        }

        private JObject iMFI_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            parameters.Add(payload["symbol"]);
            parameters.Add(payload["timeframe"]);
            parameters.Add(payload["period"]);
            parameters.Add(payload["shift"]);
            int id = mqlCommandManager.ExecCommand(MQLCommand.iMFI_1, parameters); // MQLCommand ENUM = 214
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = Convert.ToDecimal(mqlCommandManager.GetCommandResult(id));
            return result;
        }
        /// <summary>
        /// Function: iMA
        /// Description: Calculates the Moving Average indicator and returns its value.
        /// URL: http://mm.l/mql4/docs.mql4.com/indicators/ima.html
        /// </summary>
        /// <param name="symbol">[in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</param>
        /// <param name="timeframe">[in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</param>
        /// <param name="ma_period">[in] Averaging period for calculation.</param>
        /// <param name="ma_shift">[in] MA shift. Indicators line offset relate to the chart by timeframe.</param>
        /// <param name="ma_method">[in] Moving Average method. It can be any of enumeration values.</param>
        /// <param name="applied_price">[in] Applied price. It can be any of enumeration values.</param>
        /// <param name="shift">[in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/ima")]
        public void Handle_iMA_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, iMA_1(context, chartid));
        }

        /// <summary>
        /// Function: iMA
        /// Description: Calculates the Moving Average indicator and returns its value.
        /// URL: http://mm.l/mql4/docs.mql4.com/indicators/ima.html
        /// </summary>
        /// <param name="symbol">[in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</param>
        /// <param name="timeframe">[in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</param>
        /// <param name="ma_period">[in] Averaging period for calculation.</param>
        /// <param name="ma_shift">[in] MA shift. Indicators line offset relate to the chart by timeframe.</param>
        /// <param name="ma_method">[in] Moving Average method. It can be any of enumeration values.</param>
        /// <param name="applied_price">[in] Applied price. It can be any of enumeration values.</param>
        /// <param name="shift">[in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/ima")]
        public void Handle_iMA_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, iMA_1(context, DEFAULT_CHART_ID));
        }

        private JObject iMA_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            parameters.Add(payload["symbol"]);
            parameters.Add(payload["timeframe"]);
            parameters.Add(payload["ma_period"]);
            parameters.Add(payload["ma_shift"]);
            parameters.Add(payload["ma_method"]);
            parameters.Add(payload["applied_price"]);
            parameters.Add(payload["shift"]);
            int id = mqlCommandManager.ExecCommand(MQLCommand.iMA_1, parameters); // MQLCommand ENUM = 215
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = Convert.ToDecimal(mqlCommandManager.GetCommandResult(id));
            return result;
        }
        /// <summary>
        /// Function: iOsMA
        /// Description: iOsMA
        /// URL: http://mm.l/mql4/docs.mql4.com/indicators/iosma.html
        /// </summary>
        /// <param name="symbol">[in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</param>
        /// <param name="timeframe">[in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</param>
        /// <param name="fast_ema_period">[in] Fast EMA averaging period.</param>
        /// <param name="slow_ema_period">[in] Slow EMA averaging period.</param>
        /// <param name="signal_period">[in] Signal line averaging period.</param>
        /// <param name="applied_price">[in] Applied price. It can be any of enumeration values.</param>
        /// <param name="shift">[in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/iosma")]
        public void Handle_iOsMA_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, iOsMA_1(context, chartid));
        }

        /// <summary>
        /// Function: iOsMA
        /// Description: iOsMA
        /// URL: http://mm.l/mql4/docs.mql4.com/indicators/iosma.html
        /// </summary>
        /// <param name="symbol">[in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</param>
        /// <param name="timeframe">[in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</param>
        /// <param name="fast_ema_period">[in] Fast EMA averaging period.</param>
        /// <param name="slow_ema_period">[in] Slow EMA averaging period.</param>
        /// <param name="signal_period">[in] Signal line averaging period.</param>
        /// <param name="applied_price">[in] Applied price. It can be any of enumeration values.</param>
        /// <param name="shift">[in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/iosma")]
        public void Handle_iOsMA_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, iOsMA_1(context, DEFAULT_CHART_ID));
        }

        private JObject iOsMA_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            parameters.Add(payload["symbol"]);
            parameters.Add(payload["timeframe"]);
            parameters.Add(payload["fast_ema_period"]);
            parameters.Add(payload["slow_ema_period"]);
            parameters.Add(payload["signal_period"]);
            parameters.Add(payload["applied_price"]);
            parameters.Add(payload["shift"]);
            int id = mqlCommandManager.ExecCommand(MQLCommand.iOsMA_1, parameters); // MQLCommand ENUM = 216
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = Convert.ToDecimal(mqlCommandManager.GetCommandResult(id));
            return result;
        }
        /// <summary>
        /// Function: iMACD
        /// Description: Calculates the Moving Averages Convergence/Divergence indicator and returns its value.
        /// URL: http://mm.l/mql4/docs.mql4.com/indicators/imacd.html
        /// </summary>
        /// <param name="symbol">[in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</param>
        /// <param name="timeframe">[in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</param>
        /// <param name="fast_ema_period">[in] Fast EMA averaging period.</param>
        /// <param name="slow_ema_period">[in] Slow EMA averaging period.</param>
        /// <param name="signal_period">[in] Signal line averaging period.</param>
        /// <param name="applied_price">[in] Applied price. It can be any of enumeration values.</param>
        /// <param name="mode">[in] Indicator line index. It can be one of the enumeration values (0-MODE_MAIN, 1-MODE_SIGNAL).</param>
        /// <param name="shift">[in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/imacd")]
        public void Handle_iMACD_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, iMACD_1(context, chartid));
        }

        /// <summary>
        /// Function: iMACD
        /// Description: Calculates the Moving Averages Convergence/Divergence indicator and returns its value.
        /// URL: http://mm.l/mql4/docs.mql4.com/indicators/imacd.html
        /// </summary>
        /// <param name="symbol">[in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</param>
        /// <param name="timeframe">[in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</param>
        /// <param name="fast_ema_period">[in] Fast EMA averaging period.</param>
        /// <param name="slow_ema_period">[in] Slow EMA averaging period.</param>
        /// <param name="signal_period">[in] Signal line averaging period.</param>
        /// <param name="applied_price">[in] Applied price. It can be any of enumeration values.</param>
        /// <param name="mode">[in] Indicator line index. It can be one of the enumeration values (0-MODE_MAIN, 1-MODE_SIGNAL).</param>
        /// <param name="shift">[in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/imacd")]
        public void Handle_iMACD_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, iMACD_1(context, DEFAULT_CHART_ID));
        }

        private JObject iMACD_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            parameters.Add(payload["symbol"]);
            parameters.Add(payload["timeframe"]);
            parameters.Add(payload["fast_ema_period"]);
            parameters.Add(payload["slow_ema_period"]);
            parameters.Add(payload["signal_period"]);
            parameters.Add(payload["applied_price"]);
            parameters.Add(payload["mode"]);
            parameters.Add(payload["shift"]);
            int id = mqlCommandManager.ExecCommand(MQLCommand.iMACD_1, parameters); // MQLCommand ENUM = 217
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = Convert.ToDecimal(mqlCommandManager.GetCommandResult(id));
            return result;
        }
        /// <summary>
        /// Function: iOBV
        /// Description: Calculates the On Balance Volume indicator and returns its value.
        /// URL: http://mm.l/mql4/docs.mql4.com/indicators/iobv.html
        /// </summary>
        /// <param name="symbol">[in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</param>
        /// <param name="timeframe">[in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</param>
        /// <param name="applied_price">[in] Applied price. It can be any of enumeration values.</param>
        /// <param name="shift">[in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/iobv")]
        public void Handle_iOBV_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, iOBV_1(context, chartid));
        }

        /// <summary>
        /// Function: iOBV
        /// Description: Calculates the On Balance Volume indicator and returns its value.
        /// URL: http://mm.l/mql4/docs.mql4.com/indicators/iobv.html
        /// </summary>
        /// <param name="symbol">[in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</param>
        /// <param name="timeframe">[in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</param>
        /// <param name="applied_price">[in] Applied price. It can be any of enumeration values.</param>
        /// <param name="shift">[in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/iobv")]
        public void Handle_iOBV_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, iOBV_1(context, DEFAULT_CHART_ID));
        }

        private JObject iOBV_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            parameters.Add(payload["symbol"]);
            parameters.Add(payload["timeframe"]);
            parameters.Add(payload["applied_price"]);
            parameters.Add(payload["shift"]);
            int id = mqlCommandManager.ExecCommand(MQLCommand.iOBV_1, parameters); // MQLCommand ENUM = 218
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = Convert.ToDecimal(mqlCommandManager.GetCommandResult(id));
            return result;
        }
        /// <summary>
        /// Function: iSAR
        /// Description: Calculates the Parabolic Stop and Reverse system indicator and returns its value.
        /// URL: http://mm.l/mql4/docs.mql4.com/indicators/isar.html
        /// </summary>
        /// <param name="symbol">[in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</param>
        /// <param name="timeframe">[in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</param>
        /// <param name="step">[in] The step of price increment, usually 0.02.</param>
        /// <param name="maximum">[in] The maximum step, usually 0.2.</param>
        /// <param name="shift">[in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/isar")]
        public void Handle_iSAR_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, iSAR_1(context, chartid));
        }

        /// <summary>
        /// Function: iSAR
        /// Description: Calculates the Parabolic Stop and Reverse system indicator and returns its value.
        /// URL: http://mm.l/mql4/docs.mql4.com/indicators/isar.html
        /// </summary>
        /// <param name="symbol">[in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</param>
        /// <param name="timeframe">[in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</param>
        /// <param name="step">[in] The step of price increment, usually 0.02.</param>
        /// <param name="maximum">[in] The maximum step, usually 0.2.</param>
        /// <param name="shift">[in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/isar")]
        public void Handle_iSAR_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, iSAR_1(context, DEFAULT_CHART_ID));
        }

        private JObject iSAR_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            parameters.Add(payload["symbol"]);
            parameters.Add(payload["timeframe"]);
            parameters.Add(payload["step"]);
            parameters.Add(payload["maximum"]);
            parameters.Add(payload["shift"]);
            int id = mqlCommandManager.ExecCommand(MQLCommand.iSAR_1, parameters); // MQLCommand ENUM = 219
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = Convert.ToDecimal(mqlCommandManager.GetCommandResult(id));
            return result;
        }
        /// <summary>
        /// Function: iRSI
        /// Description: Calculates the Relative Strength Index indicator and returns its value.
        /// URL: http://mm.l/mql4/docs.mql4.com/indicators/irsi.html
        /// </summary>
        /// <param name="symbol">[in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</param>
        /// <param name="timeframe">[in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</param>
        /// <param name="period">[in] Averaging period for calculation.</param>
        /// <param name="applied_price">[in] Applied price. It can be any of enumeration values.</param>
        /// <param name="shift">[in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/irsi")]
        public void Handle_iRSI_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, iRSI_1(context, chartid));
        }

        /// <summary>
        /// Function: iRSI
        /// Description: Calculates the Relative Strength Index indicator and returns its value.
        /// URL: http://mm.l/mql4/docs.mql4.com/indicators/irsi.html
        /// </summary>
        /// <param name="symbol">[in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</param>
        /// <param name="timeframe">[in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</param>
        /// <param name="period">[in] Averaging period for calculation.</param>
        /// <param name="applied_price">[in] Applied price. It can be any of enumeration values.</param>
        /// <param name="shift">[in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/irsi")]
        public void Handle_iRSI_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, iRSI_1(context, DEFAULT_CHART_ID));
        }

        private JObject iRSI_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            parameters.Add(payload["symbol"]);
            parameters.Add(payload["timeframe"]);
            parameters.Add(payload["period"]);
            parameters.Add(payload["applied_price"]);
            parameters.Add(payload["shift"]);
            int id = mqlCommandManager.ExecCommand(MQLCommand.iRSI_1, parameters); // MQLCommand ENUM = 220
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = Convert.ToDecimal(mqlCommandManager.GetCommandResult(id));
            return result;
        }
        /// <summary>
        /// Function: iRVI
        /// Description: Calculates the Relative Vigor Index indicator and returns its value.
        /// URL: http://mm.l/mql4/docs.mql4.com/indicators/irvi.html
        /// </summary>
        /// <param name="symbol">[in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</param>
        /// <param name="timeframe">[in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</param>
        /// <param name="period">[in] Averaging period for calculation.</param>
        /// <param name="mode">[in] Indicator line index. It can be any of enumeration value.</param>
        /// <param name="shift">[in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/irvi")]
        public void Handle_iRVI_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, iRVI_1(context, chartid));
        }

        /// <summary>
        /// Function: iRVI
        /// Description: Calculates the Relative Vigor Index indicator and returns its value.
        /// URL: http://mm.l/mql4/docs.mql4.com/indicators/irvi.html
        /// </summary>
        /// <param name="symbol">[in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</param>
        /// <param name="timeframe">[in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</param>
        /// <param name="period">[in] Averaging period for calculation.</param>
        /// <param name="mode">[in] Indicator line index. It can be any of enumeration value.</param>
        /// <param name="shift">[in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/irvi")]
        public void Handle_iRVI_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, iRVI_1(context, DEFAULT_CHART_ID));
        }

        private JObject iRVI_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            parameters.Add(payload["symbol"]);
            parameters.Add(payload["timeframe"]);
            parameters.Add(payload["period"]);
            parameters.Add(payload["mode"]);
            parameters.Add(payload["shift"]);
            int id = mqlCommandManager.ExecCommand(MQLCommand.iRVI_1, parameters); // MQLCommand ENUM = 221
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = Convert.ToDecimal(mqlCommandManager.GetCommandResult(id));
            return result;
        }
        /// <summary>
        /// Function: iStdDev
        /// Description: Calculates the Standard Deviation indicator and returns its value.
        /// URL: http://mm.l/mql4/docs.mql4.com/indicators/istddev.html
        /// </summary>
        /// <param name="symbol">[in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</param>
        /// <param name="timeframe">[in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</param>
        /// <param name="ma_period">[in] Moving Average period.</param>
        /// <param name="ma_shift">[in] Moving Average shift.</param>
        /// <param name="ma_method">[in] Moving Average method. It can be any of enumeration values.</param>
        /// <param name="applied_price">[in] Applied price. It can be any of enumeration values.</param>
        /// <param name="shift">[in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/istddev")]
        public void Handle_iStdDev_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, iStdDev_1(context, chartid));
        }

        /// <summary>
        /// Function: iStdDev
        /// Description: Calculates the Standard Deviation indicator and returns its value.
        /// URL: http://mm.l/mql4/docs.mql4.com/indicators/istddev.html
        /// </summary>
        /// <param name="symbol">[in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</param>
        /// <param name="timeframe">[in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</param>
        /// <param name="ma_period">[in] Moving Average period.</param>
        /// <param name="ma_shift">[in] Moving Average shift.</param>
        /// <param name="ma_method">[in] Moving Average method. It can be any of enumeration values.</param>
        /// <param name="applied_price">[in] Applied price. It can be any of enumeration values.</param>
        /// <param name="shift">[in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/istddev")]
        public void Handle_iStdDev_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, iStdDev_1(context, DEFAULT_CHART_ID));
        }

        private JObject iStdDev_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            parameters.Add(payload["symbol"]);
            parameters.Add(payload["timeframe"]);
            parameters.Add(payload["ma_period"]);
            parameters.Add(payload["ma_shift"]);
            parameters.Add(payload["ma_method"]);
            parameters.Add(payload["applied_price"]);
            parameters.Add(payload["shift"]);
            int id = mqlCommandManager.ExecCommand(MQLCommand.iStdDev_1, parameters); // MQLCommand ENUM = 222
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = Convert.ToDecimal(mqlCommandManager.GetCommandResult(id));
            return result;
        }
        /// <summary>
        /// Function: iStochastic
        /// Description: Calculates the Stochastic Oscillator and returns its value.
        /// URL: http://mm.l/mql4/docs.mql4.com/indicators/istochastic.html
        /// </summary>
        /// <param name="symbol">[in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</param>
        /// <param name="timeframe">[in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</param>
        /// <param name="Kperiod">[in] Period of the %K line.</param>
        /// <param name="Dperiod">[in] Period of the %D line.</param>
        /// <param name="slowing">[in] Slowing value.</param>
        /// <param name="method">[in] Moving Average method. It can be any of enumeration values.</param>
        /// <param name="price_field">[in] Price field parameter. Can be one of this values: 0 - Low/High or 1 - Close/Close.</param>
        /// <param name="mode">[in] Indicator line index. It can be any of the enumeration value (0 - MODE_MAIN, 1 - MODE_SIGNAL).</param>
        /// <param name="shift">[in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/istochastic")]
        public void Handle_iStochastic_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, iStochastic_1(context, chartid));
        }

        /// <summary>
        /// Function: iStochastic
        /// Description: Calculates the Stochastic Oscillator and returns its value.
        /// URL: http://mm.l/mql4/docs.mql4.com/indicators/istochastic.html
        /// </summary>
        /// <param name="symbol">[in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</param>
        /// <param name="timeframe">[in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</param>
        /// <param name="Kperiod">[in] Period of the %K line.</param>
        /// <param name="Dperiod">[in] Period of the %D line.</param>
        /// <param name="slowing">[in] Slowing value.</param>
        /// <param name="method">[in] Moving Average method. It can be any of enumeration values.</param>
        /// <param name="price_field">[in] Price field parameter. Can be one of this values: 0 - Low/High or 1 - Close/Close.</param>
        /// <param name="mode">[in] Indicator line index. It can be any of the enumeration value (0 - MODE_MAIN, 1 - MODE_SIGNAL).</param>
        /// <param name="shift">[in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/istochastic")]
        public void Handle_iStochastic_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, iStochastic_1(context, DEFAULT_CHART_ID));
        }

        private JObject iStochastic_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            parameters.Add(payload["symbol"]);
            parameters.Add(payload["timeframe"]);
            parameters.Add(payload["Kperiod"]);
            parameters.Add(payload["Dperiod"]);
            parameters.Add(payload["slowing"]);
            parameters.Add(payload["method"]);
            parameters.Add(payload["price_field"]);
            parameters.Add(payload["mode"]);
            parameters.Add(payload["shift"]);
            int id = mqlCommandManager.ExecCommand(MQLCommand.iStochastic_1, parameters); // MQLCommand ENUM = 223
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = Convert.ToDecimal(mqlCommandManager.GetCommandResult(id));
            return result;
        }
        /// <summary>
        /// Function: iWPR
        /// Description: Calculates the Larry Williams' Percent Range and returns its value.
        /// URL: http://mm.l/mql4/docs.mql4.com/indicators/iwpr.html
        /// </summary>
        /// <param name="symbol">[in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</param>
        /// <param name="timeframe">[in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</param>
        /// <param name="period">[in] Averaging period for calculation.</param>
        /// <param name="shift">[in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/iwpr")]
        public void Handle_iWPR_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, iWPR_1(context, chartid));
        }

        /// <summary>
        /// Function: iWPR
        /// Description: Calculates the Larry Williams' Percent Range and returns its value.
        /// URL: http://mm.l/mql4/docs.mql4.com/indicators/iwpr.html
        /// </summary>
        /// <param name="symbol">[in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</param>
        /// <param name="timeframe">[in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</param>
        /// <param name="period">[in] Averaging period for calculation.</param>
        /// <param name="shift">[in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</param>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/iwpr")]
        public void Handle_iWPR_1_Default(HttpListenerContext context)
        {
            this.SendJsonResponse(context, iWPR_1(context, DEFAULT_CHART_ID));
        }

        private JObject iWPR_1(HttpListenerContext context, long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            JObject payload = this.GetJsonPayload(context.Request);
            List<Object> parameters = new List<Object>();
            parameters.Add(payload["symbol"]);
            parameters.Add(payload["timeframe"]);
            parameters.Add(payload["period"]);
            parameters.Add(payload["shift"]);
            int id = mqlCommandManager.ExecCommand(MQLCommand.iWPR_1, parameters); // MQLCommand ENUM = 224
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running
            JObject result = new JObject();
            try
            {
                mqlCommandManager.throwExceptionIfErrorResponse(id);
            }
            catch (Exception e)
            {
                result["error"] = e.ToString();
            }
            result["result"] = Convert.ToDecimal(mqlCommandManager.GetCommandResult(id));
            return result;
        }
    }
}
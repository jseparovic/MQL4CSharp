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
        /// <b>Function:</b> Alert<br>
        /// <b>Description:</b> Displays a message in a separate window.<br>
        /// <b>URL:</b> http://docs.mql4.com/common/alert.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>argument</b> :  </li>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/alert")]
        public void Handle_Alert_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, Alert_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> Alert<br>
        /// <b>Description:</b> Displays a message in a separate window.<br>
        /// <b>URL:</b> http://docs.mql4.com/common/alert.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>argument</b> :  </li>
        /// </ul>
        /// </summary>
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
        /// <b>Function:</b> Comment<br>
        /// <b>Description:</b> This function outputs a comment defined by a user in the top left corner of a chart.<br>
        /// <b>URL:</b> http://docs.mql4.com/common/comment.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>argument</b> :  [in] Any values, separated by commas. To delimit output information into several lines, a line break symbol "\n" or "\r\n" is used. Number of parameters cannot exceed 64. Total length of the input comment (including invisible symbols) cannot exceed 2045 characters (excess symbols will be cut out during output).</li>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/comment")]
        public void Handle_Comment_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, Comment_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> Comment<br>
        /// <b>Description:</b> This function outputs a comment defined by a user in the top left corner of a chart.<br>
        /// <b>URL:</b> http://docs.mql4.com/common/comment.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>argument</b> :  [in] Any values, separated by commas. To delimit output information into several lines, a line break symbol "\n" or "\r\n" is used. Number of parameters cannot exceed 64. Total length of the input comment (including invisible symbols) cannot exceed 2045 characters (excess symbols will be cut out during output).</li>
        /// </ul>
        /// </summary>
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
        /// <b>Function:</b> SendFTP<br>
        /// <b>Description:</b> Sends a file at the address, specified in the setting window of the "FTP" tab.<br>
        /// <b>URL:</b> http://docs.mql4.com/common/sendftp.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>filename</b> :  [in] Name of sent file.</li>
        /// <li><b>ftp_path</b> :  [in] FTP catalog. If a directory is not specified, directory described in settings is used.</li>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/sendftp")]
        public void Handle_SendFTP_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, SendFTP_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> SendFTP<br>
        /// <b>Description:</b> Sends a file at the address, specified in the setting window of the "FTP" tab.<br>
        /// <b>URL:</b> http://docs.mql4.com/common/sendftp.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>filename</b> :  [in] Name of sent file.</li>
        /// <li><b>ftp_path</b> :  [in] FTP catalog. If a directory is not specified, directory described in settings is used.</li>
        /// </ul>
        /// </summary>
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
        /// <b>Function:</b> SendNotification<br>
        /// <b>Description:</b> Sends push notifications to the mobile terminals, whose MetaQuotes IDs are specified in the "Notifications" tab.<br>
        /// <b>URL:</b> http://docs.mql4.com/common/sendnotification.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>text</b> :  [in] The text of the notification. The message length should not exceed 255 characters.</li>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/sendnotification")]
        public void Handle_SendNotification_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, SendNotification_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> SendNotification<br>
        /// <b>Description:</b> Sends push notifications to the mobile terminals, whose MetaQuotes IDs are specified in the "Notifications" tab.<br>
        /// <b>URL:</b> http://docs.mql4.com/common/sendnotification.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>text</b> :  [in] The text of the notification. The message length should not exceed 255 characters.</li>
        /// </ul>
        /// </summary>
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
        /// <b>Function:</b> SendMail<br>
        /// <b>Description:</b> Sends an email at the address specified in the settings window of the "Email" tab.<br>
        /// <b>URL:</b> http://docs.mql4.com/common/sendmail.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>subject</b> :  [in] Email header.</li>
        /// <li><b>some_text</b> :  [in] Email body.</li>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/sendmail")]
        public void Handle_SendMail_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, SendMail_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> SendMail<br>
        /// <b>Description:</b> Sends an email at the address specified in the settings window of the "Email" tab.<br>
        /// <b>URL:</b> http://docs.mql4.com/common/sendmail.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>subject</b> :  [in] Email header.</li>
        /// <li><b>some_text</b> :  [in] Email body.</li>
        /// </ul>
        /// </summary>
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
        /// <b>Function:</b> AccountInfoDouble<br>
        /// <b>Description:</b> Returns the value of the corresponding account property.<br>
        /// <b>URL:</b> http://docs.mql4.com/account/accountinfodouble.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>property_id</b> :  [in] Identifier of the property. The value can be one of the values of .</li>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/accountinfodouble")]
        public void Handle_AccountInfoDouble_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, AccountInfoDouble_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> AccountInfoDouble<br>
        /// <b>Description:</b> Returns the value of the corresponding account property.<br>
        /// <b>URL:</b> http://docs.mql4.com/account/accountinfodouble.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>property_id</b> :  [in] Identifier of the property. The value can be one of the values of .</li>
        /// </ul>
        /// </summary>
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
        /// <b>Function:</b> AccountInfoInteger<br>
        /// <b>Description:</b> Returns the value of the properties of the account.<br>
        /// <b>URL:</b> http://docs.mql4.com/account/accountinfointeger.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>property_id</b> :  [in] Identifier of the property. The value can be one of the values of .</li>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/accountinfointeger")]
        public void Handle_AccountInfoInteger_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, AccountInfoInteger_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> AccountInfoInteger<br>
        /// <b>Description:</b> Returns the value of the properties of the account.<br>
        /// <b>URL:</b> http://docs.mql4.com/account/accountinfointeger.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>property_id</b> :  [in] Identifier of the property. The value can be one of the values of .</li>
        /// </ul>
        /// </summary>
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
        /// <b>Function:</b> AccountInfoString<br>
        /// <b>Description:</b> Returns the value of the corresponding account property.<br>
        /// <b>URL:</b> http://docs.mql4.com/account/accountinfostring.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>property_id</b> :  [in] Identifier of the property. The value can be one of the values of .</li>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/accountinfostring")]
        public void Handle_AccountInfoString_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, AccountInfoString_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> AccountInfoString<br>
        /// <b>Description:</b> Returns the value of the corresponding account property.<br>
        /// <b>URL:</b> http://docs.mql4.com/account/accountinfostring.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>property_id</b> :  [in] Identifier of the property. The value can be one of the values of .</li>
        /// </ul>
        /// </summary>
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
        /// <b>Function:</b> AccountBalance<br>
        /// <b>Description:</b> Returns balance value of the current account.<br>
        /// <b>URL:</b> http://docs.mql4.com/account/accountbalance.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/accountbalance")]
        public void Handle_AccountBalance_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, AccountBalance_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> AccountBalance<br>
        /// <b>Description:</b> Returns balance value of the current account.<br>
        /// <b>URL:</b> http://docs.mql4.com/account/accountbalance.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
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
        /// <b>Function:</b> AccountCredit<br>
        /// <b>Description:</b> Returns credit value of the current account.<br>
        /// <b>URL:</b> http://docs.mql4.com/account/accountcredit.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/accountcredit")]
        public void Handle_AccountCredit_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, AccountCredit_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> AccountCredit<br>
        /// <b>Description:</b> Returns credit value of the current account.<br>
        /// <b>URL:</b> http://docs.mql4.com/account/accountcredit.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
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
        /// <b>Function:</b> AccountCompany<br>
        /// <b>Description:</b> Returns the brokerage company name where the current account was registered.<br>
        /// <b>URL:</b> http://docs.mql4.com/account/accountcompany.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/accountcompany")]
        public void Handle_AccountCompany_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, AccountCompany_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> AccountCompany<br>
        /// <b>Description:</b> Returns the brokerage company name where the current account was registered.<br>
        /// <b>URL:</b> http://docs.mql4.com/account/accountcompany.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
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
        /// <b>Function:</b> AccountCurrency<br>
        /// <b>Description:</b> Returns currency name of the current account.<br>
        /// <b>URL:</b> http://docs.mql4.com/account/accountcurrency.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/accountcurrency")]
        public void Handle_AccountCurrency_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, AccountCurrency_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> AccountCurrency<br>
        /// <b>Description:</b> Returns currency name of the current account.<br>
        /// <b>URL:</b> http://docs.mql4.com/account/accountcurrency.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
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
        /// <b>Function:</b> AccountEquity<br>
        /// <b>Description:</b> Returns equity value of the current account.<br>
        /// <b>URL:</b> http://docs.mql4.com/account/accountequity.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/accountequity")]
        public void Handle_AccountEquity_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, AccountEquity_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> AccountEquity<br>
        /// <b>Description:</b> Returns equity value of the current account.<br>
        /// <b>URL:</b> http://docs.mql4.com/account/accountequity.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
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
        /// <b>Function:</b> AccountFreeMargin<br>
        /// <b>Description:</b> Returns free margin value of the current account.<br>
        /// <b>URL:</b> http://docs.mql4.com/account/accountfreemargin.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/accountfreemargin")]
        public void Handle_AccountFreeMargin_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, AccountFreeMargin_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> AccountFreeMargin<br>
        /// <b>Description:</b> Returns free margin value of the current account.<br>
        /// <b>URL:</b> http://docs.mql4.com/account/accountfreemargin.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
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
        /// <b>Function:</b> AccountFreeMarginCheck<br>
        /// <b>Description:</b> Returns free margin that remains after the specified order has been opened at the current price on the current account.<br>
        /// <b>URL:</b> http://docs.mql4.com/account/accountfreemargincheck.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol for trading operation.</li>
        /// <li><b>cmd</b> :  [in] Operation type. It can be either OP_BUY or OP_SELL.</li>
        /// <li><b>volume</b> :  [in] Number of lots.</li>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/accountfreemargincheck")]
        public void Handle_AccountFreeMarginCheck_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, AccountFreeMarginCheck_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> AccountFreeMarginCheck<br>
        /// <b>Description:</b> Returns free margin that remains after the specified order has been opened at the current price on the current account.<br>
        /// <b>URL:</b> http://docs.mql4.com/account/accountfreemargincheck.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol for trading operation.</li>
        /// <li><b>cmd</b> :  [in] Operation type. It can be either OP_BUY or OP_SELL.</li>
        /// <li><b>volume</b> :  [in] Number of lots.</li>
        /// </ul>
        /// </summary>
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
        /// <b>Function:</b> AccountFreeMarginMode<br>
        /// <b>Description:</b> Returns the calculation mode of free margin allowed to open orders on the current account.<br>
        /// <b>URL:</b> http://docs.mql4.com/account/accountfreemarginmode.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/accountfreemarginmode")]
        public void Handle_AccountFreeMarginMode_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, AccountFreeMarginMode_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> AccountFreeMarginMode<br>
        /// <b>Description:</b> Returns the calculation mode of free margin allowed to open orders on the current account.<br>
        /// <b>URL:</b> http://docs.mql4.com/account/accountfreemarginmode.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
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
        /// <b>Function:</b> AccountLeverage<br>
        /// <b>Description:</b> Returns leverage of the current account.<br>
        /// <b>URL:</b> http://docs.mql4.com/account/accountleverage.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/accountleverage")]
        public void Handle_AccountLeverage_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, AccountLeverage_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> AccountLeverage<br>
        /// <b>Description:</b> Returns leverage of the current account.<br>
        /// <b>URL:</b> http://docs.mql4.com/account/accountleverage.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
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
        /// <b>Function:</b> AccountMargin<br>
        /// <b>Description:</b> Returns margin value of the current account.<br>
        /// <b>URL:</b> http://docs.mql4.com/account/accountmargin.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/accountmargin")]
        public void Handle_AccountMargin_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, AccountMargin_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> AccountMargin<br>
        /// <b>Description:</b> Returns margin value of the current account.<br>
        /// <b>URL:</b> http://docs.mql4.com/account/accountmargin.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
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
        /// <b>Function:</b> AccountName<br>
        /// <b>Description:</b> Returns the current account name.<br>
        /// <b>URL:</b> http://docs.mql4.com/account/accountname.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/accountname")]
        public void Handle_AccountName_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, AccountName_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> AccountName<br>
        /// <b>Description:</b> Returns the current account name.<br>
        /// <b>URL:</b> http://docs.mql4.com/account/accountname.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
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
        /// <b>Function:</b> AccountNumber<br>
        /// <b>Description:</b> Returns the current account number.<br>
        /// <b>URL:</b> http://docs.mql4.com/account/accountnumber.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/accountnumber")]
        public void Handle_AccountNumber_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, AccountNumber_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> AccountNumber<br>
        /// <b>Description:</b> Returns the current account number.<br>
        /// <b>URL:</b> http://docs.mql4.com/account/accountnumber.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
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
        /// <b>Function:</b> AccountProfit<br>
        /// <b>Description:</b> Returns profit value of the current account.<br>
        /// <b>URL:</b> http://docs.mql4.com/account/accountprofit.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/accountprofit")]
        public void Handle_AccountProfit_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, AccountProfit_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> AccountProfit<br>
        /// <b>Description:</b> Returns profit value of the current account.<br>
        /// <b>URL:</b> http://docs.mql4.com/account/accountprofit.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
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
        /// <b>Function:</b> AccountServer<br>
        /// <b>Description:</b> Returns the connected server name.<br>
        /// <b>URL:</b> http://docs.mql4.com/account/accountserver.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/accountserver")]
        public void Handle_AccountServer_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, AccountServer_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> AccountServer<br>
        /// <b>Description:</b> Returns the connected server name.<br>
        /// <b>URL:</b> http://docs.mql4.com/account/accountserver.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
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
        /// <b>Function:</b> AccountStopoutLevel<br>
        /// <b>Description:</b> Returns the value of the Stop Out level.<br>
        /// <b>URL:</b> http://docs.mql4.com/account/accountstopoutlevel.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/accountstopoutlevel")]
        public void Handle_AccountStopoutLevel_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, AccountStopoutLevel_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> AccountStopoutLevel<br>
        /// <b>Description:</b> Returns the value of the Stop Out level.<br>
        /// <b>URL:</b> http://docs.mql4.com/account/accountstopoutlevel.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
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
        /// <b>Function:</b> AccountStopoutMode<br>
        /// <b>Description:</b> Returns the calculation mode for the Stop Out level.<br>
        /// <b>URL:</b> http://docs.mql4.com/account/accountstopoutmode.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/accountstopoutmode")]
        public void Handle_AccountStopoutMode_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, AccountStopoutMode_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> AccountStopoutMode<br>
        /// <b>Description:</b> Returns the calculation mode for the Stop Out level.<br>
        /// <b>URL:</b> http://docs.mql4.com/account/accountstopoutmode.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
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
        /// <b>Function:</b> GetLastError<br>
        /// <b>Description:</b> Returns the contents of the<br>
        /// <b>URL:</b> http://docs.mql4.com/check/getlasterror.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/getlasterror")]
        public void Handle_GetLastError_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, GetLastError_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> GetLastError<br>
        /// <b>Description:</b> Returns the contents of the<br>
        /// <b>URL:</b> http://docs.mql4.com/check/getlasterror.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
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
        /// <b>Function:</b> IsStopped<br>
        /// <b>Description:</b> Checks the forced shutdown of an mql4 program.<br>
        /// <b>URL:</b> http://docs.mql4.com/check/isstopped.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/isstopped")]
        public void Handle_IsStopped_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, IsStopped_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> IsStopped<br>
        /// <b>Description:</b> Checks the forced shutdown of an mql4 program.<br>
        /// <b>URL:</b> http://docs.mql4.com/check/isstopped.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
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
        /// <b>Function:</b> UninitializeReason<br>
        /// <b>Description:</b> Returns the code of a<br>
        /// <b>URL:</b> http://docs.mql4.com/check/uninitializereason.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/uninitializereason")]
        public void Handle_UninitializeReason_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, UninitializeReason_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> UninitializeReason<br>
        /// <b>Description:</b> Returns the code of a<br>
        /// <b>URL:</b> http://docs.mql4.com/check/uninitializereason.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
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
        /// <b>Function:</b> MQLInfoInteger<br>
        /// <b>Description:</b> Returns the value of a corresponding property of a running mql4 program.<br>
        /// <b>URL:</b> http://docs.mql4.com/check/mqlinfointeger.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>property_id</b> :  [in] Identifier of a property. Can be one of values of the enumeration.</li>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/mqlinfointeger")]
        public void Handle_MQLInfoInteger_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, MQLInfoInteger_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> MQLInfoInteger<br>
        /// <b>Description:</b> Returns the value of a corresponding property of a running mql4 program.<br>
        /// <b>URL:</b> http://docs.mql4.com/check/mqlinfointeger.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>property_id</b> :  [in] Identifier of a property. Can be one of values of the enumeration.</li>
        /// </ul>
        /// </summary>
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
        /// <b>Function:</b> MQLInfoString<br>
        /// <b>Description:</b> Returns the value of a corresponding property of a running MQL4 program.<br>
        /// <b>URL:</b> http://docs.mql4.com/check/mqlinfostring.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>property_id</b> :  [in] Identifier of a property. Can be one of the enumeration.</li>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/mqlinfostring")]
        public void Handle_MQLInfoString_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, MQLInfoString_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> MQLInfoString<br>
        /// <b>Description:</b> Returns the value of a corresponding property of a running MQL4 program.<br>
        /// <b>URL:</b> http://docs.mql4.com/check/mqlinfostring.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>property_id</b> :  [in] Identifier of a property. Can be one of the enumeration.</li>
        /// </ul>
        /// </summary>
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
        /// <b>Function:</b> MQLSetInteger<br>
        /// <b>Description:</b> Sets the value of the<br>
        /// <b>URL:</b> http://docs.mql4.com/check/mqlsetinteger.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>property_id</b> :  [in] Identifier of a property. Only is supported, as other properties cannot be changed.</li>
        /// <li><b>property_value</b> :  [in] Value of property. Can be one of the .</li>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/mqlsetinteger")]
        public void Handle_MQLSetInteger_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, MQLSetInteger_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> MQLSetInteger<br>
        /// <b>Description:</b> Sets the value of the<br>
        /// <b>URL:</b> http://docs.mql4.com/check/mqlsetinteger.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>property_id</b> :  [in] Identifier of a property. Only is supported, as other properties cannot be changed.</li>
        /// <li><b>property_value</b> :  [in] Value of property. Can be one of the .</li>
        /// </ul>
        /// </summary>
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
        /// <b>Function:</b> TerminalInfoInteger<br>
        /// <b>Description:</b> Returns the value of a corresponding property of the mql4 program environment.<br>
        /// <b>URL:</b> http://docs.mql4.com/check/terminalinfointeger.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>property_id</b> :  [in] Identifier of a property. Can be one of the values of the enumeration.</li>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/terminalinfointeger")]
        public void Handle_TerminalInfoInteger_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, TerminalInfoInteger_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> TerminalInfoInteger<br>
        /// <b>Description:</b> Returns the value of a corresponding property of the mql4 program environment.<br>
        /// <b>URL:</b> http://docs.mql4.com/check/terminalinfointeger.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>property_id</b> :  [in] Identifier of a property. Can be one of the values of the enumeration.</li>
        /// </ul>
        /// </summary>
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
        /// <b>Function:</b> TerminalInfoDouble<br>
        /// <b>Description:</b> Returns the value of a corresponding property of the mql4 program environment.<br>
        /// <b>URL:</b> http://docs.mql4.com/check/terminalinfodouble.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>property_id</b> :  [in] Identifier of a property. Can be one of the values of the enumeration.</li>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/terminalinfodouble")]
        public void Handle_TerminalInfoDouble_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, TerminalInfoDouble_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> TerminalInfoDouble<br>
        /// <b>Description:</b> Returns the value of a corresponding property of the mql4 program environment.<br>
        /// <b>URL:</b> http://docs.mql4.com/check/terminalinfodouble.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>property_id</b> :  [in] Identifier of a property. Can be one of the values of the enumeration.</li>
        /// </ul>
        /// </summary>
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
        /// <b>Function:</b> TerminalInfoString<br>
        /// <b>Description:</b> Returns the value of a corresponding property of the mql4 program environment. The property must be of string type.<br>
        /// <b>URL:</b> http://docs.mql4.com/check/terminalinfostring.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>property_id</b> :  [in] Identifier of a property. Can be one of the values of the enumeration.</li>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/terminalinfostring")]
        public void Handle_TerminalInfoString_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, TerminalInfoString_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> TerminalInfoString<br>
        /// <b>Description:</b> Returns the value of a corresponding property of the mql4 program environment. The property must be of string type.<br>
        /// <b>URL:</b> http://docs.mql4.com/check/terminalinfostring.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>property_id</b> :  [in] Identifier of a property. Can be one of the values of the enumeration.</li>
        /// </ul>
        /// </summary>
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
        /// <b>Function:</b> Symbol<br>
        /// <b>Description:</b> Returns the name of a symbol of the current chart.<br>
        /// <b>URL:</b> http://docs.mql4.com/check/symbol.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/symbol")]
        public void Handle_Symbol_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, Symbol_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> Symbol<br>
        /// <b>Description:</b> Returns the name of a symbol of the current chart.<br>
        /// <b>URL:</b> http://docs.mql4.com/check/symbol.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
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
        /// <b>Function:</b> Period<br>
        /// <b>Description:</b> Returns the current chart timeframe.<br>
        /// <b>URL:</b> http://docs.mql4.com/check/period.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/period")]
        public void Handle_Period_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, Period_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> Period<br>
        /// <b>Description:</b> Returns the current chart timeframe.<br>
        /// <b>URL:</b> http://docs.mql4.com/check/period.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
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
        /// <b>Function:</b> Digits<br>
        /// <b>Description:</b> Returns the number of decimal digits determining the accuracy of price of the current chart symbol.<br>
        /// <b>URL:</b> http://docs.mql4.com/check/digits.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/digits")]
        public void Handle_Digits_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, Digits_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> Digits<br>
        /// <b>Description:</b> Returns the number of decimal digits determining the accuracy of price of the current chart symbol.<br>
        /// <b>URL:</b> http://docs.mql4.com/check/digits.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
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
        /// <b>Function:</b> Point<br>
        /// <b>Description:</b> Returns the point size of the current symbol in the quote currency.<br>
        /// <b>URL:</b> http://docs.mql4.com/check/point.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/point")]
        public void Handle_Point_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, Point_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> Point<br>
        /// <b>Description:</b> Returns the point size of the current symbol in the quote currency.<br>
        /// <b>URL:</b> http://docs.mql4.com/check/point.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
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
        /// <b>Function:</b> IsConnected<br>
        /// <b>Description:</b> Checks connection between client terminal and server.<br>
        /// <b>URL:</b> http://docs.mql4.com/check/isconnected.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/isconnected")]
        public void Handle_IsConnected_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, IsConnected_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> IsConnected<br>
        /// <b>Description:</b> Checks connection between client terminal and server.<br>
        /// <b>URL:</b> http://docs.mql4.com/check/isconnected.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
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
        /// <b>Function:</b> IsDemo<br>
        /// <b>Description:</b> Checks if the Expert Advisor runs on a demo account.<br>
        /// <b>URL:</b> http://docs.mql4.com/check/isdemo.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/isdemo")]
        public void Handle_IsDemo_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, IsDemo_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> IsDemo<br>
        /// <b>Description:</b> Checks if the Expert Advisor runs on a demo account.<br>
        /// <b>URL:</b> http://docs.mql4.com/check/isdemo.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
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
        /// <b>Function:</b> IsDllsAllowed<br>
        /// <b>Description:</b> Checks if the DLL function call is allowed for the Expert Advisor.<br>
        /// <b>URL:</b> http://docs.mql4.com/check/isdllsallowed.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/isdllsallowed")]
        public void Handle_IsDllsAllowed_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, IsDllsAllowed_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> IsDllsAllowed<br>
        /// <b>Description:</b> Checks if the DLL function call is allowed for the Expert Advisor.<br>
        /// <b>URL:</b> http://docs.mql4.com/check/isdllsallowed.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
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
        /// <b>Function:</b> IsExpertEnabled<br>
        /// <b>Description:</b> Checks if Expert Advisors are enabled for running.<br>
        /// <b>URL:</b> http://docs.mql4.com/check/isexpertenabled.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/isexpertenabled")]
        public void Handle_IsExpertEnabled_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, IsExpertEnabled_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> IsExpertEnabled<br>
        /// <b>Description:</b> Checks if Expert Advisors are enabled for running.<br>
        /// <b>URL:</b> http://docs.mql4.com/check/isexpertenabled.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
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
        /// <b>Function:</b> IsLibrariesAllowed<br>
        /// <b>Description:</b> Checks if the Expert Advisor can call library function.<br>
        /// <b>URL:</b> http://docs.mql4.com/check/islibrariesallowed.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/islibrariesallowed")]
        public void Handle_IsLibrariesAllowed_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, IsLibrariesAllowed_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> IsLibrariesAllowed<br>
        /// <b>Description:</b> Checks if the Expert Advisor can call library function.<br>
        /// <b>URL:</b> http://docs.mql4.com/check/islibrariesallowed.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
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
        /// <b>Function:</b> IsOptimization<br>
        /// <b>Description:</b> Checks if Expert Advisor runs in the Strategy Tester optimization mode.<br>
        /// <b>URL:</b> http://docs.mql4.com/check/isoptimization.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/isoptimization")]
        public void Handle_IsOptimization_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, IsOptimization_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> IsOptimization<br>
        /// <b>Description:</b> Checks if Expert Advisor runs in the Strategy Tester optimization mode.<br>
        /// <b>URL:</b> http://docs.mql4.com/check/isoptimization.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
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
        /// <b>Function:</b> IsTesting<br>
        /// <b>Description:</b> Checks<br>
        /// <b>URL:</b> http://docs.mql4.com/check/istesting.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/istesting")]
        public void Handle_IsTesting_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, IsTesting_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> IsTesting<br>
        /// <b>Description:</b> Checks<br>
        /// <b>URL:</b> http://docs.mql4.com/check/istesting.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
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
        /// <b>Function:</b> IsTradeAllowed<br>
        /// <b>Description:</b> Checks<br>
        /// <b>URL:</b> http://docs.mql4.com/check/istradeallowed.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/istradeallowed")]
        public void Handle_IsTradeAllowed_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, IsTradeAllowed_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> IsTradeAllowed<br>
        /// <b>Description:</b> Checks<br>
        /// <b>URL:</b> http://docs.mql4.com/check/istradeallowed.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
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
        /// <b>Function:</b> IsTradeAllowed<br>
        /// <b>Description:</b> Checks<br>
        /// <b>URL:</b> http://docs.mql4.com/check/istradeallowed.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol.</li>
        /// <li><b>tested_time</b> :  [in] Time to check status.</li>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/istradeallowed")]
        public void Handle_IsTradeAllowed_2(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, IsTradeAllowed_2(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> IsTradeAllowed<br>
        /// <b>Description:</b> Checks<br>
        /// <b>URL:</b> http://docs.mql4.com/check/istradeallowed.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol.</li>
        /// <li><b>tested_time</b> :  [in] Time to check status.</li>
        /// </ul>
        /// </summary>
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
        /// <b>Function:</b> IsTradeContextBusy<br>
        /// <b>Description:</b> Returns the information about trade context.<br>
        /// <b>URL:</b> http://docs.mql4.com/check/istradecontextbusy.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/istradecontextbusy")]
        public void Handle_IsTradeContextBusy_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, IsTradeContextBusy_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> IsTradeContextBusy<br>
        /// <b>Description:</b> Returns the information about trade context.<br>
        /// <b>URL:</b> http://docs.mql4.com/check/istradecontextbusy.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
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
        /// <b>Function:</b> IsVisualMode<br>
        /// <b>Description:</b> Checks<br>
        /// <b>URL:</b> http://docs.mql4.com/check/isvisualmode.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/isvisualmode")]
        public void Handle_IsVisualMode_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, IsVisualMode_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> IsVisualMode<br>
        /// <b>Description:</b> Checks<br>
        /// <b>URL:</b> http://docs.mql4.com/check/isvisualmode.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
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
        /// <b>Function:</b> TerminalCompany<br>
        /// <b>Description:</b> Returns the name of company owning the client terminal.<br>
        /// <b>URL:</b> http://docs.mql4.com/check/terminalcompany.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/terminalcompany")]
        public void Handle_TerminalCompany_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, TerminalCompany_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> TerminalCompany<br>
        /// <b>Description:</b> Returns the name of company owning the client terminal.<br>
        /// <b>URL:</b> http://docs.mql4.com/check/terminalcompany.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
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
        /// <b>Function:</b> TerminalName<br>
        /// <b>Description:</b> Returns client terminal name.<br>
        /// <b>URL:</b> http://docs.mql4.com/check/terminalname.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/terminalname")]
        public void Handle_TerminalName_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, TerminalName_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> TerminalName<br>
        /// <b>Description:</b> Returns client terminal name.<br>
        /// <b>URL:</b> http://docs.mql4.com/check/terminalname.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
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
        /// <b>Function:</b> TerminalPath<br>
        /// <b>Description:</b> Returns the directory, from which the client terminal was launched.<br>
        /// <b>URL:</b> http://docs.mql4.com/check/terminalpath.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/terminalpath")]
        public void Handle_TerminalPath_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, TerminalPath_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> TerminalPath<br>
        /// <b>Description:</b> Returns the directory, from which the client terminal was launched.<br>
        /// <b>URL:</b> http://docs.mql4.com/check/terminalpath.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
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
        /// <b>Function:</b> MarketInfo<br>
        /// <b>Description:</b> Returns various data about securities listed in the "Market Watch" window.<br>
        /// <b>URL:</b> http://docs.mql4.com/marketinformation/marketinfo.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol name.</li>
        /// <li><b>type</b> :  [in] Request of information to be returned. Can be any of values of request identifiers.</li>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/marketinfo")]
        public void Handle_MarketInfo_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, MarketInfo_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> MarketInfo<br>
        /// <b>Description:</b> Returns various data about securities listed in the "Market Watch" window.<br>
        /// <b>URL:</b> http://docs.mql4.com/marketinformation/marketinfo.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol name.</li>
        /// <li><b>type</b> :  [in] Request of information to be returned. Can be any of values of request identifiers.</li>
        /// </ul>
        /// </summary>
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
        /// <b>Function:</b> SymbolsTotal<br>
        /// <b>Description:</b> Returns the number of available (selected in Market Watch or all) symbols.<br>
        /// <b>URL:</b> http://docs.mql4.com/marketinformation/symbolstotal.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>selected</b> :  [in] Request mode. Can be true or false.</li>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/symbolstotal")]
        public void Handle_SymbolsTotal_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, SymbolsTotal_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> SymbolsTotal<br>
        /// <b>Description:</b> Returns the number of available (selected in Market Watch or all) symbols.<br>
        /// <b>URL:</b> http://docs.mql4.com/marketinformation/symbolstotal.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>selected</b> :  [in] Request mode. Can be true or false.</li>
        /// </ul>
        /// </summary>
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
        /// <b>Function:</b> SymbolName<br>
        /// <b>Description:</b> Returns the name of a symbol.<br>
        /// <b>URL:</b> http://docs.mql4.com/marketinformation/symbolname.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>pos</b> :  [in] Order number of a symbol.</li>
        /// <li><b>selected</b> :  [in] Request mode. If the value is true, the symbol is taken from the list of symbols selected in MarketWatch. If the value is false, the symbol is taken from the general list.</li>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/symbolname")]
        public void Handle_SymbolName_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, SymbolName_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> SymbolName<br>
        /// <b>Description:</b> Returns the name of a symbol.<br>
        /// <b>URL:</b> http://docs.mql4.com/marketinformation/symbolname.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>pos</b> :  [in] Order number of a symbol.</li>
        /// <li><b>selected</b> :  [in] Request mode. If the value is true, the symbol is taken from the list of symbols selected in MarketWatch. If the value is false, the symbol is taken from the general list.</li>
        /// </ul>
        /// </summary>
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
        /// <b>Function:</b> SymbolSelect<br>
        /// <b>Description:</b> Selects a symbol in the Market Watch window or removes a symbol from the window.<br>
        /// <b>URL:</b> http://docs.mql4.com/marketinformation/symbolselect.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>name</b> :  [in] Symbol name.</li>
        /// <li><b>select</b> :  [in] Switch. If the value is false, a symbol should be removed from MarketWatch, otherwise a symbol should be selected in this window. A symbol can't be removed if the symbol chart is open, or there are open orders for this symbol.</li>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/symbolselect")]
        public void Handle_SymbolSelect_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, SymbolSelect_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> SymbolSelect<br>
        /// <b>Description:</b> Selects a symbol in the Market Watch window or removes a symbol from the window.<br>
        /// <b>URL:</b> http://docs.mql4.com/marketinformation/symbolselect.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>name</b> :  [in] Symbol name.</li>
        /// <li><b>select</b> :  [in] Switch. If the value is false, a symbol should be removed from MarketWatch, otherwise a symbol should be selected in this window. A symbol can't be removed if the symbol chart is open, or there are open orders for this symbol.</li>
        /// </ul>
        /// </summary>
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
        /// <b>Function:</b> RefreshRates<br>
        /// <b>Description:</b> Refreshing of data in pre-defined variables and series arrays.<br>
        /// <b>URL:</b> http://docs.mql4.com/series/refreshrates.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/refreshrates")]
        public void Handle_RefreshRates_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, RefreshRates_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> RefreshRates<br>
        /// <b>Description:</b> Refreshing of data in pre-defined variables and series arrays.<br>
        /// <b>URL:</b> http://docs.mql4.com/series/refreshrates.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
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
        /// <b>Function:</b> Bars<br>
        /// <b>Description:</b> Returns the number of bars count in the history for a specified symbol and period. There are 2 variants of functions calls.<br>
        /// <b>URL:</b> http://docs.mql4.com/series/barsfunction.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol_name</b> :  [in] Symbol name.</li>
        /// <li><b>timeframe</b> :  [in] Period.</li>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/bars")]
        public void Handle_Bars_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, Bars_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> Bars<br>
        /// <b>Description:</b> Returns the number of bars count in the history for a specified symbol and period. There are 2 variants of functions calls.<br>
        /// <b>URL:</b> http://docs.mql4.com/series/barsfunction.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol_name</b> :  [in] Symbol name.</li>
        /// <li><b>timeframe</b> :  [in] Period.</li>
        /// </ul>
        /// </summary>
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
        /// <b>Function:</b> Bars<br>
        /// <b>Description:</b> Returns the number of bars count in the history for a specified symbol and period. There are 2 variants of functions calls.<br>
        /// <b>URL:</b> http://docs.mql4.com/series/barsfunction.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol_name</b> :  [in] Symbol name.</li>
        /// <li><b>timeframe</b> :  [in] Period.</li>
        /// <li><b>start_time</b> :  [in] Bar time corresponding to the first element.</li>
        /// <li><b>stop_time</b> :  [in] Bar time corresponding to the last element.</li>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/bars")]
        public void Handle_Bars_2(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, Bars_2(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> Bars<br>
        /// <b>Description:</b> Returns the number of bars count in the history for a specified symbol and period. There are 2 variants of functions calls.<br>
        /// <b>URL:</b> http://docs.mql4.com/series/barsfunction.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol_name</b> :  [in] Symbol name.</li>
        /// <li><b>timeframe</b> :  [in] Period.</li>
        /// <li><b>start_time</b> :  [in] Bar time corresponding to the first element.</li>
        /// <li><b>stop_time</b> :  [in] Bar time corresponding to the last element.</li>
        /// </ul>
        /// </summary>
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
        /// <b>Function:</b> iBars<br>
        /// <b>Description:</b> Returns the number of bars on the specified chart.<br>
        /// <b>URL:</b> http://docs.mql4.com/series/ibars.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol the data of which should be used to calculate indicator. means the current symbol.</li>
        /// <li><b>timeframe</b> :  [in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</li>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/ibars")]
        public void Handle_iBars_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, iBars_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> iBars<br>
        /// <b>Description:</b> Returns the number of bars on the specified chart.<br>
        /// <b>URL:</b> http://docs.mql4.com/series/ibars.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol the data of which should be used to calculate indicator. means the current symbol.</li>
        /// <li><b>timeframe</b> :  [in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</li>
        /// </ul>
        /// </summary>
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
        /// <b>Function:</b> iBarShift<br>
        /// <b>Description:</b> Search for a bar by its time. The function returns the index of the bar which covers the specified time.<br>
        /// <b>URL:</b> http://docs.mql4.com/series/ibarshift.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol name. means the current symbol.</li>
        /// <li><b>timeframe</b> :  [in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</li>
        /// <li><b>time</b> :  [in] Time value for searching.</li>
        /// <li><b>exact</b> :  [in] Return mode when the bar is not found (false - iBarShift returns the nearest, true - iBarShift returns -1).</li>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/ibarshift")]
        public void Handle_iBarShift_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, iBarShift_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> iBarShift<br>
        /// <b>Description:</b> Search for a bar by its time. The function returns the index of the bar which covers the specified time.<br>
        /// <b>URL:</b> http://docs.mql4.com/series/ibarshift.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol name. means the current symbol.</li>
        /// <li><b>timeframe</b> :  [in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</li>
        /// <li><b>time</b> :  [in] Time value for searching.</li>
        /// <li><b>exact</b> :  [in] Return mode when the bar is not found (false - iBarShift returns the nearest, true - iBarShift returns -1).</li>
        /// </ul>
        /// </summary>
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
        /// <b>Function:</b> iClose<br>
        /// <b>Description:</b> Returns Close price value for the bar of specified symbol with timeframe and shift.<br>
        /// <b>URL:</b> http://docs.mql4.com/series/iclose.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol name. means the current symbol.</li>
        /// <li><b>timeframe</b> :  [in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</li>
        /// <li><b>shift</b> :  [in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</li>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/iclose")]
        public void Handle_iClose_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, iClose_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> iClose<br>
        /// <b>Description:</b> Returns Close price value for the bar of specified symbol with timeframe and shift.<br>
        /// <b>URL:</b> http://docs.mql4.com/series/iclose.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol name. means the current symbol.</li>
        /// <li><b>timeframe</b> :  [in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</li>
        /// <li><b>shift</b> :  [in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</li>
        /// </ul>
        /// </summary>
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
        /// <b>Function:</b> iHigh<br>
        /// <b>Description:</b> Returns High price value for the bar of specified symbol with timeframe and shift.<br>
        /// <b>URL:</b> http://docs.mql4.com/series/ihigh.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol name. means the current symbol.</li>
        /// <li><b>timeframe</b> :  [in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</li>
        /// <li><b>shift</b> :  [in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</li>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/ihigh")]
        public void Handle_iHigh_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, iHigh_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> iHigh<br>
        /// <b>Description:</b> Returns High price value for the bar of specified symbol with timeframe and shift.<br>
        /// <b>URL:</b> http://docs.mql4.com/series/ihigh.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol name. means the current symbol.</li>
        /// <li><b>timeframe</b> :  [in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</li>
        /// <li><b>shift</b> :  [in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</li>
        /// </ul>
        /// </summary>
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
        /// <b>Function:</b> iHighest<br>
        /// <b>Description:</b> Returns the shift of the maximum value over a specific number of bars depending on type.<br>
        /// <b>URL:</b> http://docs.mql4.com/series/ihighest.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol the data of which should be used for search. means the current symbol.</li>
        /// <li><b>timeframe</b> :  [in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</li>
        /// <li><b>type</b> :  [in] Series array identifier. It can be any of the enumeration values.</li>
        /// <li><b>count</b> :  [in] Number of bars (in direction from the start bar to the back one) on which the search is carried out.</li>
        /// <li><b>start</b> :  [in] Shift showing the bar, relative to the current bar, that the data should be taken from.</li>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/ihighest")]
        public void Handle_iHighest_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, iHighest_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> iHighest<br>
        /// <b>Description:</b> Returns the shift of the maximum value over a specific number of bars depending on type.<br>
        /// <b>URL:</b> http://docs.mql4.com/series/ihighest.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol the data of which should be used for search. means the current symbol.</li>
        /// <li><b>timeframe</b> :  [in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</li>
        /// <li><b>type</b> :  [in] Series array identifier. It can be any of the enumeration values.</li>
        /// <li><b>count</b> :  [in] Number of bars (in direction from the start bar to the back one) on which the search is carried out.</li>
        /// <li><b>start</b> :  [in] Shift showing the bar, relative to the current bar, that the data should be taken from.</li>
        /// </ul>
        /// </summary>
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
        /// <b>Function:</b> iLow<br>
        /// <b>Description:</b> Returns Low price value for the bar of indicated symbol with timeframe and shift.<br>
        /// <b>URL:</b> http://docs.mql4.com/series/ilow.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol name. means the current symbol.</li>
        /// <li><b>timeframe</b> :  [in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</li>
        /// <li><b>shift</b> :  [in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</li>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/ilow")]
        public void Handle_iLow_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, iLow_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> iLow<br>
        /// <b>Description:</b> Returns Low price value for the bar of indicated symbol with timeframe and shift.<br>
        /// <b>URL:</b> http://docs.mql4.com/series/ilow.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol name. means the current symbol.</li>
        /// <li><b>timeframe</b> :  [in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</li>
        /// <li><b>shift</b> :  [in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</li>
        /// </ul>
        /// </summary>
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
        /// <b>Function:</b> iLowest<br>
        /// <b>Description:</b> Returns the shift of the lowest value over a specific number of bars depending on type.<br>
        /// <b>URL:</b> http://docs.mql4.com/series/ilowest.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol name. means the current symbol.</li>
        /// <li><b>timeframe</b> :  [in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</li>
        /// <li><b>type</b> :  [in] Series array identifier. It can be any of the enumeration values.</li>
        /// <li><b>count</b> :  [in] Number of bars (in direction from the start bar to the back one) on which the search is carried out.</li>
        /// <li><b>start</b> :  [in] Shift showing the bar, relative to the current bar, that the data should be taken from.</li>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/ilowest")]
        public void Handle_iLowest_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, iLowest_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> iLowest<br>
        /// <b>Description:</b> Returns the shift of the lowest value over a specific number of bars depending on type.<br>
        /// <b>URL:</b> http://docs.mql4.com/series/ilowest.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol name. means the current symbol.</li>
        /// <li><b>timeframe</b> :  [in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</li>
        /// <li><b>type</b> :  [in] Series array identifier. It can be any of the enumeration values.</li>
        /// <li><b>count</b> :  [in] Number of bars (in direction from the start bar to the back one) on which the search is carried out.</li>
        /// <li><b>start</b> :  [in] Shift showing the bar, relative to the current bar, that the data should be taken from.</li>
        /// </ul>
        /// </summary>
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
        /// <b>Function:</b> iOpen<br>
        /// <b>Description:</b> Returns Open price value for the bar of specified symbol with timeframe and shift.<br>
        /// <b>URL:</b> http://docs.mql4.com/series/iopen.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol name. means the current symbol.</li>
        /// <li><b>timeframe</b> :  [in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</li>
        /// <li><b>shift</b> :  [in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</li>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/iopen")]
        public void Handle_iOpen_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, iOpen_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> iOpen<br>
        /// <b>Description:</b> Returns Open price value for the bar of specified symbol with timeframe and shift.<br>
        /// <b>URL:</b> http://docs.mql4.com/series/iopen.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol name. means the current symbol.</li>
        /// <li><b>timeframe</b> :  [in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</li>
        /// <li><b>shift</b> :  [in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</li>
        /// </ul>
        /// </summary>
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
        /// <b>Function:</b> iTime<br>
        /// <b>Description:</b> Returns Time value for the bar of specified symbol with timeframe and shift.<br>
        /// <b>URL:</b> http://docs.mql4.com/series/itime.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol name. means the current symbol.</li>
        /// <li><b>timeframe</b> :  [in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</li>
        /// <li><b>shift</b> :  [in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</li>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/itime")]
        public void Handle_iTime_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, iTime_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> iTime<br>
        /// <b>Description:</b> Returns Time value for the bar of specified symbol with timeframe and shift.<br>
        /// <b>URL:</b> http://docs.mql4.com/series/itime.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol name. means the current symbol.</li>
        /// <li><b>timeframe</b> :  [in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</li>
        /// <li><b>shift</b> :  [in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</li>
        /// </ul>
        /// </summary>
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
        /// <b>Function:</b> iVolume<br>
        /// <b>Description:</b> Returns Tick Volume value for the bar of specified symbol with timeframe and shift.<br>
        /// <b>URL:</b> http://docs.mql4.com/series/ivolume.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol name. means the current symbol.</li>
        /// <li><b>timeframe</b> :  [in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</li>
        /// <li><b>shift</b> :  [in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</li>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/ivolume")]
        public void Handle_iVolume_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, iVolume_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> iVolume<br>
        /// <b>Description:</b> Returns Tick Volume value for the bar of specified symbol with timeframe and shift.<br>
        /// <b>URL:</b> http://docs.mql4.com/series/ivolume.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol name. means the current symbol.</li>
        /// <li><b>timeframe</b> :  [in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</li>
        /// <li><b>shift</b> :  [in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</li>
        /// </ul>
        /// </summary>
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
        /// <b>Function:</b> ChartApplyTemplate<br>
        /// <b>Description:</b> Applies a specific template from a specified file to the chart. The command is added to chart message queue and executed only after all previous commands have been processed.<br>
        /// <b>URL:</b> http://docs.mql4.com/chart_operations/chartapplytemplate.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>chart_id</b> :  [in] Chart ID. 0 means the current chart.</li>
        /// <li><b>filename</b> :  [in] The name of the file containing the template.</li>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/chartapplytemplate")]
        public void Handle_ChartApplyTemplate_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, ChartApplyTemplate_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> ChartApplyTemplate<br>
        /// <b>Description:</b> Applies a specific template from a specified file to the chart. The command is added to chart message queue and executed only after all previous commands have been processed.<br>
        /// <b>URL:</b> http://docs.mql4.com/chart_operations/chartapplytemplate.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>chart_id</b> :  [in] Chart ID. 0 means the current chart.</li>
        /// <li><b>filename</b> :  [in] The name of the file containing the template.</li>
        /// </ul>
        /// </summary>
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
        /// <b>Function:</b> ChartSaveTemplate<br>
        /// <b>Description:</b> Saves current chart settings in a template with a specified name. The command is added to chart message queue and executed only after all previous commands have been processed.<br>
        /// <b>URL:</b> http://docs.mql4.com/chart_operations/chartsavetemplate.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>chart_id</b> :  [in] Chart ID. 0 means the current chart.</li>
        /// <li><b>filename</b> :  [in] The filename to save the template. The ".tpl" extension will be added to the filename automatically; there is no need to specify it. The template is saved in terminal_directory\Profiles\Templates\ and can be used for manual application in the terminal. If a template with the same filename already exists, the contents of this file will be overwritten.</li>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/chartsavetemplate")]
        public void Handle_ChartSaveTemplate_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, ChartSaveTemplate_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> ChartSaveTemplate<br>
        /// <b>Description:</b> Saves current chart settings in a template with a specified name. The command is added to chart message queue and executed only after all previous commands have been processed.<br>
        /// <b>URL:</b> http://docs.mql4.com/chart_operations/chartsavetemplate.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>chart_id</b> :  [in] Chart ID. 0 means the current chart.</li>
        /// <li><b>filename</b> :  [in] The filename to save the template. The ".tpl" extension will be added to the filename automatically; there is no need to specify it. The template is saved in terminal_directory\Profiles\Templates\ and can be used for manual application in the terminal. If a template with the same filename already exists, the contents of this file will be overwritten.</li>
        /// </ul>
        /// </summary>
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
        /// <b>Function:</b> ChartWindowFind<br>
        /// <b>Description:</b> The function returns the number of a subwindow where an indicator is drawn. There are 2 variants of the function.<br>
        /// <b>URL:</b> http://docs.mql4.com/chart_operations/chartwindowfind.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>chart_id</b> :  [in] Chart ID. 0 denotes the current chart.</li>
        /// <li><b>indicator_shortname</b> :  [in] Short name of the indicator.</li>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/chartwindowfind")]
        public void Handle_ChartWindowFind_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, ChartWindowFind_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> ChartWindowFind<br>
        /// <b>Description:</b> The function returns the number of a subwindow where an indicator is drawn. There are 2 variants of the function.<br>
        /// <b>URL:</b> http://docs.mql4.com/chart_operations/chartwindowfind.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>chart_id</b> :  [in] Chart ID. 0 denotes the current chart.</li>
        /// <li><b>indicator_shortname</b> :  [in] Short name of the indicator.</li>
        /// </ul>
        /// </summary>
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
        /// <b>Function:</b> ChartWindowFind<br>
        /// <b>Description:</b> The function returns the number of a subwindow where an indicator is drawn. There are 2 variants of the function.<br>
        /// <b>URL:</b> http://docs.mql4.com/chart_operations/chartwindowfind.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/chartwindowfind")]
        public void Handle_ChartWindowFind_2(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, ChartWindowFind_2(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> ChartWindowFind<br>
        /// <b>Description:</b> The function returns the number of a subwindow where an indicator is drawn. There are 2 variants of the function.<br>
        /// <b>URL:</b> http://docs.mql4.com/chart_operations/chartwindowfind.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
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
        /// <b>Function:</b> ChartOpen<br>
        /// <b>Description:</b> Opens a new chart with the specified symbol and period. The command is added to chart message queue and executed only after all previous commands have been processed.<br>
        /// <b>URL:</b> http://docs.mql4.com/chart_operations/chartopen.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Chart symbol. means the symbol of the current chart (the Expert Advisor is attached to).</li>
        /// <li><b>period</b> :  [in] Chart period (timeframe). Can be one of the values. 0 means the current chart period.</li>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/chartopen")]
        public void Handle_ChartOpen_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, ChartOpen_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> ChartOpen<br>
        /// <b>Description:</b> Opens a new chart with the specified symbol and period. The command is added to chart message queue and executed only after all previous commands have been processed.<br>
        /// <b>URL:</b> http://docs.mql4.com/chart_operations/chartopen.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Chart symbol. means the symbol of the current chart (the Expert Advisor is attached to).</li>
        /// <li><b>period</b> :  [in] Chart period (timeframe). Can be one of the values. 0 means the current chart period.</li>
        /// </ul>
        /// </summary>
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
        /// <b>Function:</b> ChartFirst<br>
        /// <b>Description:</b> Returns the ID of the first chart of the client terminal.<br>
        /// <b>URL:</b> http://docs.mql4.com/chart_operations/chartfirst.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/chartfirst")]
        public void Handle_ChartFirst_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, ChartFirst_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> ChartFirst<br>
        /// <b>Description:</b> Returns the ID of the first chart of the client terminal.<br>
        /// <b>URL:</b> http://docs.mql4.com/chart_operations/chartfirst.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
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
        /// <b>Function:</b> ChartNext<br>
        /// <b>Description:</b> Returns the chart ID of the chart next to the specified one.<br>
        /// <b>URL:</b> http://docs.mql4.com/chart_operations/chartnext.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>chart_id</b> :  [in] Chart ID. 0 does not mean the current chart. 0 means "return the first chart ID".</li>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/chartnext")]
        public void Handle_ChartNext_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, ChartNext_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> ChartNext<br>
        /// <b>Description:</b> Returns the chart ID of the chart next to the specified one.<br>
        /// <b>URL:</b> http://docs.mql4.com/chart_operations/chartnext.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>chart_id</b> :  [in] Chart ID. 0 does not mean the current chart. 0 means "return the first chart ID".</li>
        /// </ul>
        /// </summary>
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
        /// <b>Function:</b> ChartClose<br>
        /// <b>Description:</b> Closes the specified chart.<br>
        /// <b>URL:</b> http://docs.mql4.com/chart_operations/chartclose.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>chart_id</b> :  [in] Chart ID. 0 means the current chart.</li>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/chartclose")]
        public void Handle_ChartClose_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, ChartClose_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> ChartClose<br>
        /// <b>Description:</b> Closes the specified chart.<br>
        /// <b>URL:</b> http://docs.mql4.com/chart_operations/chartclose.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>chart_id</b> :  [in] Chart ID. 0 means the current chart.</li>
        /// </ul>
        /// </summary>
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
        /// <b>Function:</b> ChartSymbol<br>
        /// <b>Description:</b> Returns the symbol name for the specified chart.<br>
        /// <b>URL:</b> http://docs.mql4.com/chart_operations/chartsymbol.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>chart_id</b> :  [in] Chart ID. 0 means the current chart.</li>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/chartsymbol")]
        public void Handle_ChartSymbol_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, ChartSymbol_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> ChartSymbol<br>
        /// <b>Description:</b> Returns the symbol name for the specified chart.<br>
        /// <b>URL:</b> http://docs.mql4.com/chart_operations/chartsymbol.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>chart_id</b> :  [in] Chart ID. 0 means the current chart.</li>
        /// </ul>
        /// </summary>
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
        /// <b>Function:</b> ChartRedraw<br>
        /// <b>Description:</b> This function calls a forced redrawing of a specified chart.<br>
        /// <b>URL:</b> http://docs.mql4.com/chart_operations/chartredraw.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>chart_id</b> :  [in] Chart ID. 0 means the current chart.</li>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/chartredraw")]
        public void Handle_ChartRedraw_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, ChartRedraw_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> ChartRedraw<br>
        /// <b>Description:</b> This function calls a forced redrawing of a specified chart.<br>
        /// <b>URL:</b> http://docs.mql4.com/chart_operations/chartredraw.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>chart_id</b> :  [in] Chart ID. 0 means the current chart.</li>
        /// </ul>
        /// </summary>
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
        /// <b>Function:</b> ChartSetDouble<br>
        /// <b>Description:</b> Sets a value for a corresponding property of the specified chart. Chart property should be of a<br>
        /// <b>URL:</b> http://docs.mql4.com/chart_operations/chartsetdouble.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>chart_id</b> :  [in] Chart ID. 0 means the current chart.</li>
        /// <li><b>prop_id</b> :  [in] Chart property ID. Can be one of the values (except the read-only properties).</li>
        /// <li><b>value</b> :  [in] Property value.</li>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/chartsetdouble")]
        public void Handle_ChartSetDouble_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, ChartSetDouble_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> ChartSetDouble<br>
        /// <b>Description:</b> Sets a value for a corresponding property of the specified chart. Chart property should be of a<br>
        /// <b>URL:</b> http://docs.mql4.com/chart_operations/chartsetdouble.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>chart_id</b> :  [in] Chart ID. 0 means the current chart.</li>
        /// <li><b>prop_id</b> :  [in] Chart property ID. Can be one of the values (except the read-only properties).</li>
        /// <li><b>value</b> :  [in] Property value.</li>
        /// </ul>
        /// </summary>
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
        /// <b>Function:</b> ChartSetInteger<br>
        /// <b>Description:</b> Sets a value for a corresponding property of the specified chart. Chart property must be<br>
        /// <b>URL:</b> http://docs.mql4.com/chart_operations/chartsetinteger.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>chart_id</b> :  [in] Chart ID. 0 means the current chart.</li>
        /// <li><b>prop_id</b> :  [in] Chart property ID. It can be one of the value (except the read-only properties).</li>
        /// <li><b>value</b> :  [in] Property value.</li>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/chartsetinteger")]
        public void Handle_ChartSetInteger_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, ChartSetInteger_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> ChartSetInteger<br>
        /// <b>Description:</b> Sets a value for a corresponding property of the specified chart. Chart property must be<br>
        /// <b>URL:</b> http://docs.mql4.com/chart_operations/chartsetinteger.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>chart_id</b> :  [in] Chart ID. 0 means the current chart.</li>
        /// <li><b>prop_id</b> :  [in] Chart property ID. It can be one of the value (except the read-only properties).</li>
        /// <li><b>value</b> :  [in] Property value.</li>
        /// </ul>
        /// </summary>
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
        /// <b>Function:</b> ChartSetInteger<br>
        /// <b>Description:</b> Sets a value for a corresponding property of the specified chart. Chart property must be<br>
        /// <b>URL:</b> http://docs.mql4.com/chart_operations/chartsetinteger.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>chart_id</b> :  [in] Chart ID. 0 means the current chart.</li>
        /// <li><b>property_id</b> :  </li>
        /// <li><b>sub_window</b> :  [in] Chart subwindow.</li>
        /// <li><b>value</b> :  [in] Property value.</li>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/chartsetinteger")]
        public void Handle_ChartSetInteger_2(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, ChartSetInteger_2(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> ChartSetInteger<br>
        /// <b>Description:</b> Sets a value for a corresponding property of the specified chart. Chart property must be<br>
        /// <b>URL:</b> http://docs.mql4.com/chart_operations/chartsetinteger.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>chart_id</b> :  [in] Chart ID. 0 means the current chart.</li>
        /// <li><b>property_id</b> :  </li>
        /// <li><b>sub_window</b> :  [in] Chart subwindow.</li>
        /// <li><b>value</b> :  [in] Property value.</li>
        /// </ul>
        /// </summary>
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
        /// <b>Function:</b> ChartSetString<br>
        /// <b>Description:</b> Sets a value for a corresponding property of the specified chart. Chart property must be of the string type. The command is added to chart message queue and executed only after all previous commands have been processed.<br>
        /// <b>URL:</b> http://docs.mql4.com/chart_operations/chartsetstring.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>chart_id</b> :  [in] Chart ID. 0 means the current chart.</li>
        /// <li><b>prop_id</b> :  [in] Chart property ID. Its value can be one of the values (except the read-only properties).</li>
        /// <li><b>str_value</b> :  [in] Property value string. String length cannot exceed 2045 characters (extra characters will be truncated).</li>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/chartsetstring")]
        public void Handle_ChartSetString_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, ChartSetString_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> ChartSetString<br>
        /// <b>Description:</b> Sets a value for a corresponding property of the specified chart. Chart property must be of the string type. The command is added to chart message queue and executed only after all previous commands have been processed.<br>
        /// <b>URL:</b> http://docs.mql4.com/chart_operations/chartsetstring.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>chart_id</b> :  [in] Chart ID. 0 means the current chart.</li>
        /// <li><b>prop_id</b> :  [in] Chart property ID. Its value can be one of the values (except the read-only properties).</li>
        /// <li><b>str_value</b> :  [in] Property value string. String length cannot exceed 2045 characters (extra characters will be truncated).</li>
        /// </ul>
        /// </summary>
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
        /// <b>Function:</b> ChartNavigate<br>
        /// <b>Description:</b> Performs shift of the specified chart by the specified number of bars relative to the specified position in the chart. The command is added to chart message queue and executed only after all previous commands have been processed.<br>
        /// <b>URL:</b> http://docs.mql4.com/chart_operations/chartnavigate.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>chart_id</b> :  [in] Chart ID. 0 means the current chart.</li>
        /// <li><b>position</b> :  [in] Chart position to perform a shift. Can be one of the values.</li>
        /// <li><b>shift</b> :  [in] Number of bars to shift the chart. Positive value means the right shift (to the end of chart), negative value means the left shift (to the beginning of chart). The zero shift can be used to navigate to the beginning or end of chart.</li>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/chartnavigate")]
        public void Handle_ChartNavigate_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, ChartNavigate_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> ChartNavigate<br>
        /// <b>Description:</b> Performs shift of the specified chart by the specified number of bars relative to the specified position in the chart. The command is added to chart message queue and executed only after all previous commands have been processed.<br>
        /// <b>URL:</b> http://docs.mql4.com/chart_operations/chartnavigate.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>chart_id</b> :  [in] Chart ID. 0 means the current chart.</li>
        /// <li><b>position</b> :  [in] Chart position to perform a shift. Can be one of the values.</li>
        /// <li><b>shift</b> :  [in] Number of bars to shift the chart. Positive value means the right shift (to the end of chart), negative value means the left shift (to the beginning of chart). The zero shift can be used to navigate to the beginning or end of chart.</li>
        /// </ul>
        /// </summary>
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
        /// <b>Function:</b> ChartID<br>
        /// <b>Description:</b> Returns the ID of the current chart.<br>
        /// <b>URL:</b> http://docs.mql4.com/chart_operations/chartid.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/chartid")]
        public void Handle_ChartID_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, ChartID_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> ChartID<br>
        /// <b>Description:</b> Returns the ID of the current chart.<br>
        /// <b>URL:</b> http://docs.mql4.com/chart_operations/chartid.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
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
        /// <b>Function:</b> ChartIndicatorDelete<br>
        /// <b>Description:</b> Removes an indicator with a specified name from the specified chart window. The command is added to chart message queue and executed only after all previous commands have been processed.<br>
        /// <b>URL:</b> http://docs.mql4.com/chart_operations/chartindicatordelete.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>chart_id</b> :  [in] Chart ID. 0 denotes the current chart.</li>
        /// <li><b>sub_window</b> :  [in] Number of the chart subwindow. 0 denotes the main chart subwindow.</li>
        /// <li><b>indicator_shortname</b> :  </li>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/chartindicatordelete")]
        public void Handle_ChartIndicatorDelete_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, ChartIndicatorDelete_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> ChartIndicatorDelete<br>
        /// <b>Description:</b> Removes an indicator with a specified name from the specified chart window. The command is added to chart message queue and executed only after all previous commands have been processed.<br>
        /// <b>URL:</b> http://docs.mql4.com/chart_operations/chartindicatordelete.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>chart_id</b> :  [in] Chart ID. 0 denotes the current chart.</li>
        /// <li><b>sub_window</b> :  [in] Number of the chart subwindow. 0 denotes the main chart subwindow.</li>
        /// <li><b>indicator_shortname</b> :  </li>
        /// </ul>
        /// </summary>
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
        /// <b>Function:</b> ChartIndicatorName<br>
        /// <b>Description:</b> Returns the short name of the indicator by the number in the indicators list on the specified chart window.<br>
        /// <b>URL:</b> http://docs.mql4.com/chart_operations/chartindicatorname.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>chart_id</b> :  [in] Chart ID. 0 denotes the current chart.</li>
        /// <li><b>sub_window</b> :  [in] Number of the chart subwindow. 0 denotes the main chart subwindow.</li>
        /// <li><b>index</b> :  [in] the index of the indicator in the list of indicators. The numeration of indicators start with zero, i.e. the first indicator in the list has the 0 index. To obtain the number of indicators in the list use the function.</li>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/chartindicatorname")]
        public void Handle_ChartIndicatorName_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, ChartIndicatorName_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> ChartIndicatorName<br>
        /// <b>Description:</b> Returns the short name of the indicator by the number in the indicators list on the specified chart window.<br>
        /// <b>URL:</b> http://docs.mql4.com/chart_operations/chartindicatorname.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>chart_id</b> :  [in] Chart ID. 0 denotes the current chart.</li>
        /// <li><b>sub_window</b> :  [in] Number of the chart subwindow. 0 denotes the main chart subwindow.</li>
        /// <li><b>index</b> :  [in] the index of the indicator in the list of indicators. The numeration of indicators start with zero, i.e. the first indicator in the list has the 0 index. To obtain the number of indicators in the list use the function.</li>
        /// </ul>
        /// </summary>
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
        /// <b>Function:</b> ChartIndicatorsTotal<br>
        /// <b>Description:</b> Returns the number of all indicators applied to the specified chart window.<br>
        /// <b>URL:</b> http://docs.mql4.com/chart_operations/chartindicatorstotal.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>chart_id</b> :  [in] Chart ID. 0 denotes the current chart.</li>
        /// <li><b>sub_window</b> :  [in] Number of the chart subwindow. 0 denotes the main chart subwindow.</li>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/chartindicatorstotal")]
        public void Handle_ChartIndicatorsTotal_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, ChartIndicatorsTotal_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> ChartIndicatorsTotal<br>
        /// <b>Description:</b> Returns the number of all indicators applied to the specified chart window.<br>
        /// <b>URL:</b> http://docs.mql4.com/chart_operations/chartindicatorstotal.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>chart_id</b> :  [in] Chart ID. 0 denotes the current chart.</li>
        /// <li><b>sub_window</b> :  [in] Number of the chart subwindow. 0 denotes the main chart subwindow.</li>
        /// </ul>
        /// </summary>
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
        /// <b>Function:</b> ChartWindowOnDropped<br>
        /// <b>Description:</b> Returns the number (index) of the chart subwindow the Expert Advisor or script has been dropped to. 0 means the main chart window.<br>
        /// <b>URL:</b> http://docs.mql4.com/chart_operations/chartwindowondropped.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/chartwindowondropped")]
        public void Handle_ChartWindowOnDropped_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, ChartWindowOnDropped_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> ChartWindowOnDropped<br>
        /// <b>Description:</b> Returns the number (index) of the chart subwindow the Expert Advisor or script has been dropped to. 0 means the main chart window.<br>
        /// <b>URL:</b> http://docs.mql4.com/chart_operations/chartwindowondropped.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
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
        /// <b>Function:</b> ChartPriceOnDropped<br>
        /// <b>Description:</b> Returns the price coordinate corresponding to the chart point the Expert Advisor or script has been dropped to.<br>
        /// <b>URL:</b> http://docs.mql4.com/chart_operations/chartpriceondropped.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/chartpriceondropped")]
        public void Handle_ChartPriceOnDropped_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, ChartPriceOnDropped_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> ChartPriceOnDropped<br>
        /// <b>Description:</b> Returns the price coordinate corresponding to the chart point the Expert Advisor or script has been dropped to.<br>
        /// <b>URL:</b> http://docs.mql4.com/chart_operations/chartpriceondropped.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
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
        /// <b>Function:</b> ChartTimeOnDropped<br>
        /// <b>Description:</b> Returns the time coordinate corresponding to the chart point the Expert Advisor or script has been dropped to.<br>
        /// <b>URL:</b> http://docs.mql4.com/chart_operations/charttimeondropped.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/charttimeondropped")]
        public void Handle_ChartTimeOnDropped_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, ChartTimeOnDropped_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> ChartTimeOnDropped<br>
        /// <b>Description:</b> Returns the time coordinate corresponding to the chart point the Expert Advisor or script has been dropped to.<br>
        /// <b>URL:</b> http://docs.mql4.com/chart_operations/charttimeondropped.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
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
        /// <b>Function:</b> ChartXOnDropped<br>
        /// <b>Description:</b> Returns the X coordinate of the chart point the Expert Advisor or script has been dropped to.<br>
        /// <b>URL:</b> http://docs.mql4.com/chart_operations/chartxondropped.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/chartxondropped")]
        public void Handle_ChartXOnDropped_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, ChartXOnDropped_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> ChartXOnDropped<br>
        /// <b>Description:</b> Returns the X coordinate of the chart point the Expert Advisor or script has been dropped to.<br>
        /// <b>URL:</b> http://docs.mql4.com/chart_operations/chartxondropped.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
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
        /// <b>Function:</b> ChartYOnDropped<br>
        /// <b>Description:</b> Returns the Y coordinateof the chart point the Expert Advisor or script has been dropped to.<br>
        /// <b>URL:</b> http://docs.mql4.com/chart_operations/chartyondropped.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/chartyondropped")]
        public void Handle_ChartYOnDropped_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, ChartYOnDropped_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> ChartYOnDropped<br>
        /// <b>Description:</b> Returns the Y coordinateof the chart point the Expert Advisor or script has been dropped to.<br>
        /// <b>URL:</b> http://docs.mql4.com/chart_operations/chartyondropped.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
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
        /// <b>Function:</b> ChartSetSymbolPeriod<br>
        /// <b>Description:</b> Changes the symbol and period of the specified chart. The function is asynchronous, i.e. it sends the command and does not wait for its execution completion. The command is added to chart message queue and executed only after all previous commands have been processed.<br>
        /// <b>URL:</b> http://docs.mql4.com/chart_operations/chartsetsymbolperiod.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>chart_id</b> :  [in] Chart ID. 0 means the current chart.</li>
        /// <li><b>symbol</b> :  [in] Chart symbol. value means the current chart symbol (Expert Advisor is attached to)</li>
        /// <li><b>period</b> :  [in] Chart period (timeframe). Can be one of the values. 0 means the current chart period.</li>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/chartsetsymbolperiod")]
        public void Handle_ChartSetSymbolPeriod_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, ChartSetSymbolPeriod_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> ChartSetSymbolPeriod<br>
        /// <b>Description:</b> Changes the symbol and period of the specified chart. The function is asynchronous, i.e. it sends the command and does not wait for its execution completion. The command is added to chart message queue and executed only after all previous commands have been processed.<br>
        /// <b>URL:</b> http://docs.mql4.com/chart_operations/chartsetsymbolperiod.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>chart_id</b> :  [in] Chart ID. 0 means the current chart.</li>
        /// <li><b>symbol</b> :  [in] Chart symbol. value means the current chart symbol (Expert Advisor is attached to)</li>
        /// <li><b>period</b> :  [in] Chart period (timeframe). Can be one of the values. 0 means the current chart period.</li>
        /// </ul>
        /// </summary>
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
        /// <b>Function:</b> ChartScreenShot<br>
        /// <b>Description:</b> Saves current chart screen shot as a GIF, PNG or BMP file depending on specified extension. The command is added to chart message queue and executed only after all previous commands have been processed.<br>
        /// <b>URL:</b> http://docs.mql4.com/chart_operations/chartscreenshot.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>chart_id</b> :  [in] Chart ID. 0 means the current chart.</li>
        /// <li><b>filename</b> :  [in] Screenshot file name. Cannot exceed 63 characters. Screenshot files are placed in the \Files directory.</li>
        /// <li><b>width</b> :  [in] Screenshot width in pixels.</li>
        /// <li><b>height</b> :  [in] Screenshot height in pixels.</li>
        /// <li><b>align_mode</b> :  [in] Output mode of a narrow screenshot. A value of the enumeration. ALIGN_RIGHT means align to the right margin (the output from the end). ALIGN_LEFT means Left justify.</li>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/chartscreenshot")]
        public void Handle_ChartScreenShot_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, ChartScreenShot_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> ChartScreenShot<br>
        /// <b>Description:</b> Saves current chart screen shot as a GIF, PNG or BMP file depending on specified extension. The command is added to chart message queue and executed only after all previous commands have been processed.<br>
        /// <b>URL:</b> http://docs.mql4.com/chart_operations/chartscreenshot.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>chart_id</b> :  [in] Chart ID. 0 means the current chart.</li>
        /// <li><b>filename</b> :  [in] Screenshot file name. Cannot exceed 63 characters. Screenshot files are placed in the \Files directory.</li>
        /// <li><b>width</b> :  [in] Screenshot width in pixels.</li>
        /// <li><b>height</b> :  [in] Screenshot height in pixels.</li>
        /// <li><b>align_mode</b> :  [in] Output mode of a narrow screenshot. A value of the enumeration. ALIGN_RIGHT means align to the right margin (the output from the end). ALIGN_LEFT means Left justify.</li>
        /// </ul>
        /// </summary>
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
        /// <b>Function:</b> WindowBarsPerChart<br>
        /// <b>Description:</b> Returns the amount of bars visible on the chart.<br>
        /// <b>URL:</b> http://docs.mql4.com/chart_operations/windowbarsperchart.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/windowbarsperchart")]
        public void Handle_WindowBarsPerChart_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, WindowBarsPerChart_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> WindowBarsPerChart<br>
        /// <b>Description:</b> Returns the amount of bars visible on the chart.<br>
        /// <b>URL:</b> http://docs.mql4.com/chart_operations/windowbarsperchart.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
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
        /// <b>Function:</b> WindowExpertName<br>
        /// <b>Description:</b> Returns the name of the executed Expert Advisor, script, custom indicator, or library.<br>
        /// <b>URL:</b> http://docs.mql4.com/chart_operations/windowexpertname.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/windowexpertname")]
        public void Handle_WindowExpertName_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, WindowExpertName_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> WindowExpertName<br>
        /// <b>Description:</b> Returns the name of the executed Expert Advisor, script, custom indicator, or library.<br>
        /// <b>URL:</b> http://docs.mql4.com/chart_operations/windowexpertname.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
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
        /// <b>Function:</b> WindowFind<br>
        /// <b>Description:</b> Returns the window index containing this specified indicator.<br>
        /// <b>URL:</b> http://docs.mql4.com/chart_operations/windowfind.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>name</b> :  [in] Indicator short name.</li>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/windowfind")]
        public void Handle_WindowFind_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, WindowFind_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> WindowFind<br>
        /// <b>Description:</b> Returns the window index containing this specified indicator.<br>
        /// <b>URL:</b> http://docs.mql4.com/chart_operations/windowfind.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>name</b> :  [in] Indicator short name.</li>
        /// </ul>
        /// </summary>
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
        /// <b>Function:</b> WindowFirstVisibleBar<br>
        /// <b>Description:</b> Returns index of the first visible bar in the current chart window.<br>
        /// <b>URL:</b> http://docs.mql4.com/chart_operations/windowfirstvisiblebar.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/windowfirstvisiblebar")]
        public void Handle_WindowFirstVisibleBar_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, WindowFirstVisibleBar_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> WindowFirstVisibleBar<br>
        /// <b>Description:</b> Returns index of the first visible bar in the current chart window.<br>
        /// <b>URL:</b> http://docs.mql4.com/chart_operations/windowfirstvisiblebar.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
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
        /// <b>Function:</b> WindowHandle<br>
        /// <b>Description:</b> Returns the system handle of the chart window.<br>
        /// <b>URL:</b> http://docs.mql4.com/chart_operations/windowhandle.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol.</li>
        /// <li><b>timeframe</b> :  [in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</li>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/windowhandle")]
        public void Handle_WindowHandle_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, WindowHandle_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> WindowHandle<br>
        /// <b>Description:</b> Returns the system handle of the chart window.<br>
        /// <b>URL:</b> http://docs.mql4.com/chart_operations/windowhandle.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol.</li>
        /// <li><b>timeframe</b> :  [in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</li>
        /// </ul>
        /// </summary>
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
        /// <b>Function:</b> WindowIsVisible<br>
        /// <b>Description:</b> Returns the visibility flag of the chart subwindow.<br>
        /// <b>URL:</b> http://docs.mql4.com/chart_operations/windowisvisible.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>index</b> :  [in] Subwindow index.</li>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/windowisvisible")]
        public void Handle_WindowIsVisible_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, WindowIsVisible_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> WindowIsVisible<br>
        /// <b>Description:</b> Returns the visibility flag of the chart subwindow.<br>
        /// <b>URL:</b> http://docs.mql4.com/chart_operations/windowisvisible.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>index</b> :  [in] Subwindow index.</li>
        /// </ul>
        /// </summary>
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
        /// <b>Function:</b> WindowOnDropped<br>
        /// <b>Description:</b> Returns the window index where Expert Advisor, custom indicator or script was dropped.<br>
        /// <b>URL:</b> http://docs.mql4.com/chart_operations/windowondropped.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/windowondropped")]
        public void Handle_WindowOnDropped_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, WindowOnDropped_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> WindowOnDropped<br>
        /// <b>Description:</b> Returns the window index where Expert Advisor, custom indicator or script was dropped.<br>
        /// <b>URL:</b> http://docs.mql4.com/chart_operations/windowondropped.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
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
        /// <b>Function:</b> WindowPriceMax<br>
        /// <b>Description:</b> Returns the maximal value of the vertical scale of the specified subwindow of the current chart.<br>
        /// <b>URL:</b> http://docs.mql4.com/chart_operations/windowpricemax.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>index</b> :  [in] Chart subwindow index (0 - main chart window).</li>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/windowpricemax")]
        public void Handle_WindowPriceMax_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, WindowPriceMax_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> WindowPriceMax<br>
        /// <b>Description:</b> Returns the maximal value of the vertical scale of the specified subwindow of the current chart.<br>
        /// <b>URL:</b> http://docs.mql4.com/chart_operations/windowpricemax.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>index</b> :  [in] Chart subwindow index (0 - main chart window).</li>
        /// </ul>
        /// </summary>
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
        /// <b>Function:</b> WindowPriceMin<br>
        /// <b>Description:</b> Returns the minimal value of the vertical scale of the specified subwindow of the current chart.<br>
        /// <b>URL:</b> http://docs.mql4.com/chart_operations/windowpricemin.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>index</b> :  [in] Chart subwindow index (0 - main chart window).</li>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/windowpricemin")]
        public void Handle_WindowPriceMin_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, WindowPriceMin_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> WindowPriceMin<br>
        /// <b>Description:</b> Returns the minimal value of the vertical scale of the specified subwindow of the current chart.<br>
        /// <b>URL:</b> http://docs.mql4.com/chart_operations/windowpricemin.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>index</b> :  [in] Chart subwindow index (0 - main chart window).</li>
        /// </ul>
        /// </summary>
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
        /// <b>Function:</b> WindowPriceOnDropped<br>
        /// <b>Description:</b> Returns the price of the chart point where Expert Advisor or script was dropped.<br>
        /// <b>URL:</b> http://docs.mql4.com/chart_operations/windowpriceondropped.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/windowpriceondropped")]
        public void Handle_WindowPriceOnDropped_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, WindowPriceOnDropped_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> WindowPriceOnDropped<br>
        /// <b>Description:</b> Returns the price of the chart point where Expert Advisor or script was dropped.<br>
        /// <b>URL:</b> http://docs.mql4.com/chart_operations/windowpriceondropped.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
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
        /// <b>Function:</b> WindowRedraw<br>
        /// <b>Description:</b> Redraws the current chart forcedly.<br>
        /// <b>URL:</b> http://docs.mql4.com/chart_operations/windowredraw.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/windowredraw")]
        public void Handle_WindowRedraw_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, WindowRedraw_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> WindowRedraw<br>
        /// <b>Description:</b> Redraws the current chart forcedly.<br>
        /// <b>URL:</b> http://docs.mql4.com/chart_operations/windowredraw.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
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
        /// <b>Function:</b> WindowScreenShot<br>
        /// <b>Description:</b> Saves current chart screen shot as a GIF file.<br>
        /// <b>URL:</b> http://docs.mql4.com/chart_operations/windowscreenshot.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>filename</b> :  [in] Screen shot file name. Screenshot is saved to \Files folder.</li>
        /// <li><b>size_x</b> :  [in] Screen shot width in pixels.</li>
        /// <li><b>size_y</b> :  [in] Screen shot height in pixels.</li>
        /// <li><b>start_bar</b> :  [in] Index of the first visible bar in the screen shot. If 0 value is set, the current first visible bar will be shot. If no value or negative value has been set, the end-of-chart screen shot will be produced, indent being taken into consideration.</li>
        /// <li><b>chart_scale</b> :  [in] Horizontal chart scale for screen shot. Can be in the range from 0 to 5. If no value or negative value has been set, the current chart scale will be used.</li>
        /// <li><b>chart_mode</b> :  [in] Chart displaying mode. It can take the following values: CHART_BAR (0 is a sequence of bars), CHART_CANDLE (1 is a sequence of candlesticks), CHART_LINE (2 is a close prices line). If no value or negative value has been set, the chart will be shown in its current mode.</li>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/windowscreenshot")]
        public void Handle_WindowScreenShot_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, WindowScreenShot_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> WindowScreenShot<br>
        /// <b>Description:</b> Saves current chart screen shot as a GIF file.<br>
        /// <b>URL:</b> http://docs.mql4.com/chart_operations/windowscreenshot.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>filename</b> :  [in] Screen shot file name. Screenshot is saved to \Files folder.</li>
        /// <li><b>size_x</b> :  [in] Screen shot width in pixels.</li>
        /// <li><b>size_y</b> :  [in] Screen shot height in pixels.</li>
        /// <li><b>start_bar</b> :  [in] Index of the first visible bar in the screen shot. If 0 value is set, the current first visible bar will be shot. If no value or negative value has been set, the end-of-chart screen shot will be produced, indent being taken into consideration.</li>
        /// <li><b>chart_scale</b> :  [in] Horizontal chart scale for screen shot. Can be in the range from 0 to 5. If no value or negative value has been set, the current chart scale will be used.</li>
        /// <li><b>chart_mode</b> :  [in] Chart displaying mode. It can take the following values: CHART_BAR (0 is a sequence of bars), CHART_CANDLE (1 is a sequence of candlesticks), CHART_LINE (2 is a close prices line). If no value or negative value has been set, the chart will be shown in its current mode.</li>
        /// </ul>
        /// </summary>
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
        /// <b>Function:</b> WindowTimeOnDropped<br>
        /// <b>Description:</b> Returns the time of the chart point where Expert Advisor or script was dropped.<br>
        /// <b>URL:</b> http://docs.mql4.com/chart_operations/windowtimeondropped.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/windowtimeondropped")]
        public void Handle_WindowTimeOnDropped_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, WindowTimeOnDropped_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> WindowTimeOnDropped<br>
        /// <b>Description:</b> Returns the time of the chart point where Expert Advisor or script was dropped.<br>
        /// <b>URL:</b> http://docs.mql4.com/chart_operations/windowtimeondropped.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
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
        /// <b>Function:</b> WindowsTotal<br>
        /// <b>Description:</b> Returns total number of indicator windows on the chart.<br>
        /// <b>URL:</b> http://docs.mql4.com/chart_operations/windowstotal.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/windowstotal")]
        public void Handle_WindowsTotal_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, WindowsTotal_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> WindowsTotal<br>
        /// <b>Description:</b> Returns total number of indicator windows on the chart.<br>
        /// <b>URL:</b> http://docs.mql4.com/chart_operations/windowstotal.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
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
        /// <b>Function:</b> WindowXOnDropped<br>
        /// <b>Description:</b> Returns the value at X axis in pixels for the chart window client area point at which the Expert Advisor or script was dropped.<br>
        /// <b>URL:</b> http://docs.mql4.com/chart_operations/windowxondropped.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/windowxondropped")]
        public void Handle_WindowXOnDropped_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, WindowXOnDropped_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> WindowXOnDropped<br>
        /// <b>Description:</b> Returns the value at X axis in pixels for the chart window client area point at which the Expert Advisor or script was dropped.<br>
        /// <b>URL:</b> http://docs.mql4.com/chart_operations/windowxondropped.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
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
        /// <b>Function:</b> WindowYOnDropped<br>
        /// <b>Description:</b> Returns the value at Y axis in pixels for the chart window client area point at which the Expert Advisor or script was dropped.<br>
        /// <b>URL:</b> http://docs.mql4.com/chart_operations/windowyondropped.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/windowyondropped")]
        public void Handle_WindowYOnDropped_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, WindowYOnDropped_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> WindowYOnDropped<br>
        /// <b>Description:</b> Returns the value at Y axis in pixels for the chart window client area point at which the Expert Advisor or script was dropped.<br>
        /// <b>URL:</b> http://docs.mql4.com/chart_operations/windowyondropped.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
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
        /// <b>Function:</b> OrderClose<br>
        /// <b>Description:</b> Closes opened order.<br>
        /// <b>URL:</b> http://docs.mql4.com/trading/orderclose.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>ticket</b> :  [in] Unique number of the order ticket.</li>
        /// <li><b>lots</b> :  [in] Number of lots.</li>
        /// <li><b>price</b> :  [in] Closing price.</li>
        /// <li><b>slippage</b> :  [in] Value of the maximum price slippage in points.</li>
        /// <li><b>arrow_color</b> :  [in] Color of the closing arrow on the chart. If the parameter is missing or has CLR_NONE value closing arrow will not be drawn on the chart.</li>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/orderclose")]
        public void Handle_OrderClose_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, OrderClose_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> OrderClose<br>
        /// <b>Description:</b> Closes opened order.<br>
        /// <b>URL:</b> http://docs.mql4.com/trading/orderclose.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>ticket</b> :  [in] Unique number of the order ticket.</li>
        /// <li><b>lots</b> :  [in] Number of lots.</li>
        /// <li><b>price</b> :  [in] Closing price.</li>
        /// <li><b>slippage</b> :  [in] Value of the maximum price slippage in points.</li>
        /// <li><b>arrow_color</b> :  [in] Color of the closing arrow on the chart. If the parameter is missing or has CLR_NONE value closing arrow will not be drawn on the chart.</li>
        /// </ul>
        /// </summary>
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
        /// <b>Function:</b> OrderCloseBy<br>
        /// <b>Description:</b> Closes an opened order by another opposite opened order.<br>
        /// <b>URL:</b> http://docs.mql4.com/trading/ordercloseby.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>ticket</b> :  [in] Unique number of the order ticket.</li>
        /// <li><b>opposite</b> :  [in] Unique number of the opposite order ticket.</li>
        /// <li><b>arrow_color</b> :  [in] Color of the closing arrow on the chart. If the parameter is missing or has CLR_NONE value closing arrow will not be drawn on the chart.</li>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/ordercloseby")]
        public void Handle_OrderCloseBy_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, OrderCloseBy_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> OrderCloseBy<br>
        /// <b>Description:</b> Closes an opened order by another opposite opened order.<br>
        /// <b>URL:</b> http://docs.mql4.com/trading/ordercloseby.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>ticket</b> :  [in] Unique number of the order ticket.</li>
        /// <li><b>opposite</b> :  [in] Unique number of the opposite order ticket.</li>
        /// <li><b>arrow_color</b> :  [in] Color of the closing arrow on the chart. If the parameter is missing or has CLR_NONE value closing arrow will not be drawn on the chart.</li>
        /// </ul>
        /// </summary>
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
        /// <b>Function:</b> OrderClosePrice<br>
        /// <b>Description:</b> Returns close price of the currently selected order.<br>
        /// <b>URL:</b> http://docs.mql4.com/trading/ordercloseprice.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/ordercloseprice")]
        public void Handle_OrderClosePrice_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, OrderClosePrice_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> OrderClosePrice<br>
        /// <b>Description:</b> Returns close price of the currently selected order.<br>
        /// <b>URL:</b> http://docs.mql4.com/trading/ordercloseprice.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
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
        /// <b>Function:</b> OrderCloseTime<br>
        /// <b>Description:</b> Returns close time of the currently selected order.<br>
        /// <b>URL:</b> http://docs.mql4.com/trading/orderclosetime.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/orderclosetime")]
        public void Handle_OrderCloseTime_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, OrderCloseTime_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> OrderCloseTime<br>
        /// <b>Description:</b> Returns close time of the currently selected order.<br>
        /// <b>URL:</b> http://docs.mql4.com/trading/orderclosetime.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
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
        /// <b>Function:</b> OrderComment<br>
        /// <b>Description:</b> Returns comment of the currently selected order.<br>
        /// <b>URL:</b> http://docs.mql4.com/trading/ordercomment.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/ordercomment")]
        public void Handle_OrderComment_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, OrderComment_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> OrderComment<br>
        /// <b>Description:</b> Returns comment of the currently selected order.<br>
        /// <b>URL:</b> http://docs.mql4.com/trading/ordercomment.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
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
        /// <b>Function:</b> OrderCommission<br>
        /// <b>Description:</b> Returns calculated commission of the currently selected order.<br>
        /// <b>URL:</b> http://docs.mql4.com/trading/ordercommission.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/ordercommission")]
        public void Handle_OrderCommission_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, OrderCommission_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> OrderCommission<br>
        /// <b>Description:</b> Returns calculated commission of the currently selected order.<br>
        /// <b>URL:</b> http://docs.mql4.com/trading/ordercommission.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
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
        /// <b>Function:</b> OrderDelete<br>
        /// <b>Description:</b> Deletes previously opened pending order.<br>
        /// <b>URL:</b> http://docs.mql4.com/trading/orderdelete.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>ticket</b> :  [in] Unique number of the order ticket.</li>
        /// <li><b>arrow_color</b> :  [in] Color of the arrow on the chart. If the parameter is missing or has CLR_NONE value arrow will not be drawn on the chart.</li>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/orderdelete")]
        public void Handle_OrderDelete_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, OrderDelete_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> OrderDelete<br>
        /// <b>Description:</b> Deletes previously opened pending order.<br>
        /// <b>URL:</b> http://docs.mql4.com/trading/orderdelete.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>ticket</b> :  [in] Unique number of the order ticket.</li>
        /// <li><b>arrow_color</b> :  [in] Color of the arrow on the chart. If the parameter is missing or has CLR_NONE value arrow will not be drawn on the chart.</li>
        /// </ul>
        /// </summary>
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
        /// <b>Function:</b> OrderExpiration<br>
        /// <b>Description:</b> Returns expiration date of the selected pending order.<br>
        /// <b>URL:</b> http://docs.mql4.com/trading/orderexpiration.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/orderexpiration")]
        public void Handle_OrderExpiration_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, OrderExpiration_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> OrderExpiration<br>
        /// <b>Description:</b> Returns expiration date of the selected pending order.<br>
        /// <b>URL:</b> http://docs.mql4.com/trading/orderexpiration.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
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
        /// <b>Function:</b> OrderLots<br>
        /// <b>Description:</b> Returns amount of lots of the selected order.<br>
        /// <b>URL:</b> http://docs.mql4.com/trading/orderlots.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/orderlots")]
        public void Handle_OrderLots_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, OrderLots_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> OrderLots<br>
        /// <b>Description:</b> Returns amount of lots of the selected order.<br>
        /// <b>URL:</b> http://docs.mql4.com/trading/orderlots.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
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
        /// <b>Function:</b> OrderMagicNumber<br>
        /// <b>Description:</b> Returns an identifying (magic) number of the currently selected order.<br>
        /// <b>URL:</b> http://docs.mql4.com/trading/ordermagicnumber.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/ordermagicnumber")]
        public void Handle_OrderMagicNumber_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, OrderMagicNumber_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> OrderMagicNumber<br>
        /// <b>Description:</b> Returns an identifying (magic) number of the currently selected order.<br>
        /// <b>URL:</b> http://docs.mql4.com/trading/ordermagicnumber.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
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
        /// <b>Function:</b> OrderModify<br>
        /// <b>Description:</b> Modification of characteristics of the previously opened or pending orders.<br>
        /// <b>URL:</b> http://docs.mql4.com/trading/ordermodify.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>ticket</b> :  [in] Unique number of the order ticket.</li>
        /// <li><b>price</b> :  [in] New open price of the pending order.</li>
        /// <li><b>stoploss</b> :  [in] New StopLoss level.</li>
        /// <li><b>takeprofit</b> :  [in] New TakeProfit level.</li>
        /// <li><b>expiration</b> :  [in] Pending order expiration time.</li>
        /// <li><b>arrow_color</b> :  [in] Arrow color for StopLoss/TakeProfit modifications in the chart. If the parameter is missing or has CLR_NONE value, the arrows will not be shown in the chart.</li>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/ordermodify")]
        public void Handle_OrderModify_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, OrderModify_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> OrderModify<br>
        /// <b>Description:</b> Modification of characteristics of the previously opened or pending orders.<br>
        /// <b>URL:</b> http://docs.mql4.com/trading/ordermodify.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>ticket</b> :  [in] Unique number of the order ticket.</li>
        /// <li><b>price</b> :  [in] New open price of the pending order.</li>
        /// <li><b>stoploss</b> :  [in] New StopLoss level.</li>
        /// <li><b>takeprofit</b> :  [in] New TakeProfit level.</li>
        /// <li><b>expiration</b> :  [in] Pending order expiration time.</li>
        /// <li><b>arrow_color</b> :  [in] Arrow color for StopLoss/TakeProfit modifications in the chart. If the parameter is missing or has CLR_NONE value, the arrows will not be shown in the chart.</li>
        /// </ul>
        /// </summary>
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
        /// <b>Function:</b> OrderOpenPrice<br>
        /// <b>Description:</b> Returns open price of the currently selected order.<br>
        /// <b>URL:</b> http://docs.mql4.com/trading/orderopenprice.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/orderopenprice")]
        public void Handle_OrderOpenPrice_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, OrderOpenPrice_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> OrderOpenPrice<br>
        /// <b>Description:</b> Returns open price of the currently selected order.<br>
        /// <b>URL:</b> http://docs.mql4.com/trading/orderopenprice.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
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
        /// <b>Function:</b> OrderOpenTime<br>
        /// <b>Description:</b> Returns open time of the currently selected order.<br>
        /// <b>URL:</b> http://docs.mql4.com/trading/orderopentime.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/orderopentime")]
        public void Handle_OrderOpenTime_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, OrderOpenTime_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> OrderOpenTime<br>
        /// <b>Description:</b> Returns open time of the currently selected order.<br>
        /// <b>URL:</b> http://docs.mql4.com/trading/orderopentime.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
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
        /// <b>Function:</b> OrderPrint<br>
        /// <b>Description:</b> Prints information about the selected order in the log.<br>
        /// <b>URL:</b> http://docs.mql4.com/trading/orderprint.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/orderprint")]
        public void Handle_OrderPrint_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, OrderPrint_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> OrderPrint<br>
        /// <b>Description:</b> Prints information about the selected order in the log.<br>
        /// <b>URL:</b> http://docs.mql4.com/trading/orderprint.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
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
        /// <b>Function:</b> OrderProfit<br>
        /// <b>Description:</b> Returns profit of the currently selected order.<br>
        /// <b>URL:</b> http://docs.mql4.com/trading/orderprofit.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/orderprofit")]
        public void Handle_OrderProfit_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, OrderProfit_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> OrderProfit<br>
        /// <b>Description:</b> Returns profit of the currently selected order.<br>
        /// <b>URL:</b> http://docs.mql4.com/trading/orderprofit.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
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
        /// <b>Function:</b> OrderSelect<br>
        /// <b>Description:</b> The function selects an order for further processing.<br>
        /// <b>URL:</b> http://docs.mql4.com/trading/orderselect.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>index</b> :  </li>
        /// <li><b>select</b> :  [in] Selecting flags. It can be any of the following values:</li>
        /// <li><b>pool</b> :  SELECT_BY_POS - index in the order pool, SELECT_BY_TICKET - index is order ticket.</li>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/orderselect")]
        public void Handle_OrderSelect_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, OrderSelect_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> OrderSelect<br>
        /// <b>Description:</b> The function selects an order for further processing.<br>
        /// <b>URL:</b> http://docs.mql4.com/trading/orderselect.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>index</b> :  </li>
        /// <li><b>select</b> :  [in] Selecting flags. It can be any of the following values:</li>
        /// <li><b>pool</b> :  SELECT_BY_POS - index in the order pool, SELECT_BY_TICKET - index is order ticket.</li>
        /// </ul>
        /// </summary>
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
        /// <b>Function:</b> OrderSend<br>
        /// <b>Description:</b> The main function used to open market or place a pending order.<br>
        /// <b>URL:</b> http://docs.mql4.com/trading/ordersend.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol for trading.</li>
        /// <li><b>cmd</b> :  [in] Operation type. It can be any of the enumeration.</li>
        /// <li><b>volume</b> :  [in] Number of lots.</li>
        /// <li><b>price</b> :  [in] Order price.</li>
        /// <li><b>slippage</b> :  [in] Maximum price slippage for buy or sell orders.</li>
        /// <li><b>stoploss</b> :  [in] Stop loss level.</li>
        /// <li><b>takeprofit</b> :  [in] Take profit level.</li>
        /// <li><b>comment</b> :  [in] Order comment text. Last part of the comment may be changed by server.</li>
        /// <li><b>magic</b> :  [in] Order magic number. May be used as user defined identifier.</li>
        /// <li><b>expiration</b> :  [in] Order expiration time (for pending orders only).</li>
        /// <li><b>arrow_color</b> :  [in] Color of the opening arrow on the chart. If parameter is missing or has CLR_NONE value opening arrow is not drawn on the chart.</li>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/ordersend")]
        public void Handle_OrderSend_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, OrderSend_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> OrderSend<br>
        /// <b>Description:</b> The main function used to open market or place a pending order.<br>
        /// <b>URL:</b> http://docs.mql4.com/trading/ordersend.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol for trading.</li>
        /// <li><b>cmd</b> :  [in] Operation type. It can be any of the enumeration.</li>
        /// <li><b>volume</b> :  [in] Number of lots.</li>
        /// <li><b>price</b> :  [in] Order price.</li>
        /// <li><b>slippage</b> :  [in] Maximum price slippage for buy or sell orders.</li>
        /// <li><b>stoploss</b> :  [in] Stop loss level.</li>
        /// <li><b>takeprofit</b> :  [in] Take profit level.</li>
        /// <li><b>comment</b> :  [in] Order comment text. Last part of the comment may be changed by server.</li>
        /// <li><b>magic</b> :  [in] Order magic number. May be used as user defined identifier.</li>
        /// <li><b>expiration</b> :  [in] Order expiration time (for pending orders only).</li>
        /// <li><b>arrow_color</b> :  [in] Color of the opening arrow on the chart. If parameter is missing or has CLR_NONE value opening arrow is not drawn on the chart.</li>
        /// </ul>
        /// </summary>
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
        /// <b>Function:</b> OrdersHistoryTotal<br>
        /// <b>Description:</b> Returns the number of closed orders in the account history loaded into the terminal.<br>
        /// <b>URL:</b> http://docs.mql4.com/trading/ordershistorytotal.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/ordershistorytotal")]
        public void Handle_OrdersHistoryTotal_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, OrdersHistoryTotal_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> OrdersHistoryTotal<br>
        /// <b>Description:</b> Returns the number of closed orders in the account history loaded into the terminal.<br>
        /// <b>URL:</b> http://docs.mql4.com/trading/ordershistorytotal.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
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
        /// <b>Function:</b> OrderStopLoss<br>
        /// <b>Description:</b> Returns stop loss value of the currently selected order.<br>
        /// <b>URL:</b> http://docs.mql4.com/trading/orderstoploss.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/orderstoploss")]
        public void Handle_OrderStopLoss_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, OrderStopLoss_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> OrderStopLoss<br>
        /// <b>Description:</b> Returns stop loss value of the currently selected order.<br>
        /// <b>URL:</b> http://docs.mql4.com/trading/orderstoploss.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
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
        /// <b>Function:</b> OrdersTotal<br>
        /// <b>Description:</b> Returns the number of market and pending orders.<br>
        /// <b>URL:</b> http://docs.mql4.com/trading/orderstotal.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/orderstotal")]
        public void Handle_OrdersTotal_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, OrdersTotal_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> OrdersTotal<br>
        /// <b>Description:</b> Returns the number of market and pending orders.<br>
        /// <b>URL:</b> http://docs.mql4.com/trading/orderstotal.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
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
        /// <b>Function:</b> OrderSwap<br>
        /// <b>Description:</b> Returns swap value of the currently selected order.<br>
        /// <b>URL:</b> http://docs.mql4.com/trading/orderswap.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/orderswap")]
        public void Handle_OrderSwap_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, OrderSwap_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> OrderSwap<br>
        /// <b>Description:</b> Returns swap value of the currently selected order.<br>
        /// <b>URL:</b> http://docs.mql4.com/trading/orderswap.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
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
        /// <b>Function:</b> OrderSymbol<br>
        /// <b>Description:</b> Returns symbol name of the currently selected order.<br>
        /// <b>URL:</b> http://docs.mql4.com/trading/ordersymbol.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/ordersymbol")]
        public void Handle_OrderSymbol_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, OrderSymbol_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> OrderSymbol<br>
        /// <b>Description:</b> Returns symbol name of the currently selected order.<br>
        /// <b>URL:</b> http://docs.mql4.com/trading/ordersymbol.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
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
        /// <b>Function:</b> OrderTakeProfit<br>
        /// <b>Description:</b> Returns take profit value of the currently selected order.<br>
        /// <b>URL:</b> http://docs.mql4.com/trading/ordertakeprofit.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/ordertakeprofit")]
        public void Handle_OrderTakeProfit_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, OrderTakeProfit_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> OrderTakeProfit<br>
        /// <b>Description:</b> Returns take profit value of the currently selected order.<br>
        /// <b>URL:</b> http://docs.mql4.com/trading/ordertakeprofit.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
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
        /// <b>Function:</b> OrderTicket<br>
        /// <b>Description:</b> Returns ticket number of the currently selected order.<br>
        /// <b>URL:</b> http://docs.mql4.com/trading/orderticket.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/orderticket")]
        public void Handle_OrderTicket_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, OrderTicket_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> OrderTicket<br>
        /// <b>Description:</b> Returns ticket number of the currently selected order.<br>
        /// <b>URL:</b> http://docs.mql4.com/trading/orderticket.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
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
        /// <b>Function:</b> OrderType<br>
        /// <b>Description:</b> Returns order operation type of the currently selected order.<br>
        /// <b>URL:</b> http://docs.mql4.com/trading/ordertype.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/ordertype")]
        public void Handle_OrderType_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, OrderType_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> OrderType<br>
        /// <b>Description:</b> Returns order operation type of the currently selected order.<br>
        /// <b>URL:</b> http://docs.mql4.com/trading/ordertype.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
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
        /// <b>Function:</b> SignalBaseGetDouble<br>
        /// <b>Description:</b> Returns the value of<br>
        /// <b>URL:</b> http://docs.mql4.com/signals/signalbasegetdouble.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>property_id</b> :  [in] Signal property identifier. The value can be one of the values of the enumeration.</li>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/signalbasegetdouble")]
        public void Handle_SignalBaseGetDouble_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, SignalBaseGetDouble_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> SignalBaseGetDouble<br>
        /// <b>Description:</b> Returns the value of<br>
        /// <b>URL:</b> http://docs.mql4.com/signals/signalbasegetdouble.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>property_id</b> :  [in] Signal property identifier. The value can be one of the values of the enumeration.</li>
        /// </ul>
        /// </summary>
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
        /// <b>Function:</b> SignalBaseGetInteger<br>
        /// <b>Description:</b> Returns the value of<br>
        /// <b>URL:</b> http://docs.mql4.com/signals/signalbasegetinteger.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>property_id</b> :  [in] Signal property identifier. The value can be one of the values of the enumeration.</li>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/signalbasegetinteger")]
        public void Handle_SignalBaseGetInteger_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, SignalBaseGetInteger_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> SignalBaseGetInteger<br>
        /// <b>Description:</b> Returns the value of<br>
        /// <b>URL:</b> http://docs.mql4.com/signals/signalbasegetinteger.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>property_id</b> :  [in] Signal property identifier. The value can be one of the values of the enumeration.</li>
        /// </ul>
        /// </summary>
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
        /// <b>Function:</b> SignalBaseGetString<br>
        /// <b>Description:</b> Returns the value of<br>
        /// <b>URL:</b> http://docs.mql4.com/signals/signalbasegetstring.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>property_id</b> :  [in] Signal property identifier. The value can be one of the values of the enumeration.</li>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/signalbasegetstring")]
        public void Handle_SignalBaseGetString_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, SignalBaseGetString_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> SignalBaseGetString<br>
        /// <b>Description:</b> Returns the value of<br>
        /// <b>URL:</b> http://docs.mql4.com/signals/signalbasegetstring.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>property_id</b> :  [in] Signal property identifier. The value can be one of the values of the enumeration.</li>
        /// </ul>
        /// </summary>
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
        /// <b>Function:</b> SignalBaseSelect<br>
        /// <b>Description:</b> Selects a signal from signals, available in terminal for further working with it.<br>
        /// <b>URL:</b> http://docs.mql4.com/signals/signalbaseselect.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>index</b> :  [in] Signal index in base of trading signals.</li>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/signalbaseselect")]
        public void Handle_SignalBaseSelect_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, SignalBaseSelect_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> SignalBaseSelect<br>
        /// <b>Description:</b> Selects a signal from signals, available in terminal for further working with it.<br>
        /// <b>URL:</b> http://docs.mql4.com/signals/signalbaseselect.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>index</b> :  [in] Signal index in base of trading signals.</li>
        /// </ul>
        /// </summary>
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
        /// <b>Function:</b> SignalBaseTotal<br>
        /// <b>Description:</b> Returns the total amount of signals, available in terminal.<br>
        /// <b>URL:</b> http://docs.mql4.com/signals/signalbasetotal.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/signalbasetotal")]
        public void Handle_SignalBaseTotal_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, SignalBaseTotal_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> SignalBaseTotal<br>
        /// <b>Description:</b> Returns the total amount of signals, available in terminal.<br>
        /// <b>URL:</b> http://docs.mql4.com/signals/signalbasetotal.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
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
        /// <b>Function:</b> SignalInfoGetDouble<br>
        /// <b>Description:</b> Returns the value of<br>
        /// <b>URL:</b> http://docs.mql4.com/signals/signalinfogetdouble.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>property_id</b> :  [in] Signal copy settings property identifier. The value can be one of the values of the enumeration.</li>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/signalinfogetdouble")]
        public void Handle_SignalInfoGetDouble_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, SignalInfoGetDouble_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> SignalInfoGetDouble<br>
        /// <b>Description:</b> Returns the value of<br>
        /// <b>URL:</b> http://docs.mql4.com/signals/signalinfogetdouble.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>property_id</b> :  [in] Signal copy settings property identifier. The value can be one of the values of the enumeration.</li>
        /// </ul>
        /// </summary>
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
        /// <b>Function:</b> SignalInfoGetInteger<br>
        /// <b>Description:</b> Returns the value of<br>
        /// <b>URL:</b> http://docs.mql4.com/signals/signalinfogetinteger.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>property_id</b> :  [in] Signal copy settings property identifier. The value can be one of the values of the enumeration.</li>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/signalinfogetinteger")]
        public void Handle_SignalInfoGetInteger_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, SignalInfoGetInteger_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> SignalInfoGetInteger<br>
        /// <b>Description:</b> Returns the value of<br>
        /// <b>URL:</b> http://docs.mql4.com/signals/signalinfogetinteger.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>property_id</b> :  [in] Signal copy settings property identifier. The value can be one of the values of the enumeration.</li>
        /// </ul>
        /// </summary>
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
        /// <b>Function:</b> SignalInfoGetString<br>
        /// <b>Description:</b> Returns the value of<br>
        /// <b>URL:</b> http://docs.mql4.com/signals/signalinfogetstring.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>property_id</b> :  [in] Signal copy settings property identifier. The value can be one of the values of the enumeration.</li>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/signalinfogetstring")]
        public void Handle_SignalInfoGetString_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, SignalInfoGetString_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> SignalInfoGetString<br>
        /// <b>Description:</b> Returns the value of<br>
        /// <b>URL:</b> http://docs.mql4.com/signals/signalinfogetstring.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>property_id</b> :  [in] Signal copy settings property identifier. The value can be one of the values of the enumeration.</li>
        /// </ul>
        /// </summary>
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
        /// <b>Function:</b> SignalInfoSetDouble<br>
        /// <b>Description:</b> Sets the value of<br>
        /// <b>URL:</b> http://docs.mql4.com/signals/signalinfosetdouble.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>property_id</b> :  [in] Signal copy settings property identifier. The value can be one of the values of the enumeration.</li>
        /// <li><b>value</b> :  [in] The value of signal copy settings property.</li>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/signalinfosetdouble")]
        public void Handle_SignalInfoSetDouble_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, SignalInfoSetDouble_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> SignalInfoSetDouble<br>
        /// <b>Description:</b> Sets the value of<br>
        /// <b>URL:</b> http://docs.mql4.com/signals/signalinfosetdouble.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>property_id</b> :  [in] Signal copy settings property identifier. The value can be one of the values of the enumeration.</li>
        /// <li><b>value</b> :  [in] The value of signal copy settings property.</li>
        /// </ul>
        /// </summary>
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
        /// <b>Function:</b> SignalInfoSetInteger<br>
        /// <b>Description:</b> Sets the value of<br>
        /// <b>URL:</b> http://docs.mql4.com/signals/signalinfosetinteger.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>property_id</b> :  [in] Signal copy settings property identifier. The value can be one of the values of the enumeration.</li>
        /// <li><b>value</b> :  [in] The value of signal copy settings property.</li>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/signalinfosetinteger")]
        public void Handle_SignalInfoSetInteger_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, SignalInfoSetInteger_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> SignalInfoSetInteger<br>
        /// <b>Description:</b> Sets the value of<br>
        /// <b>URL:</b> http://docs.mql4.com/signals/signalinfosetinteger.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>property_id</b> :  [in] Signal copy settings property identifier. The value can be one of the values of the enumeration.</li>
        /// <li><b>value</b> :  [in] The value of signal copy settings property.</li>
        /// </ul>
        /// </summary>
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
        /// <b>Function:</b> SignalSubscribe<br>
        /// <b>Description:</b> Subscribes to the trading signal.<br>
        /// <b>URL:</b> http://docs.mql4.com/signals/signalsubscribe.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>signal_id</b> :  [in] Signal identifier.</li>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/signalsubscribe")]
        public void Handle_SignalSubscribe_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, SignalSubscribe_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> SignalSubscribe<br>
        /// <b>Description:</b> Subscribes to the trading signal.<br>
        /// <b>URL:</b> http://docs.mql4.com/signals/signalsubscribe.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>signal_id</b> :  [in] Signal identifier.</li>
        /// </ul>
        /// </summary>
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
        /// <b>Function:</b> SignalUnsubscribe<br>
        /// <b>Description:</b> Cancels subscription.<br>
        /// <b>URL:</b> http://docs.mql4.com/signals/signalunsubscribe.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/signalunsubscribe")]
        public void Handle_SignalUnsubscribe_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, SignalUnsubscribe_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> SignalUnsubscribe<br>
        /// <b>Description:</b> Cancels subscription.<br>
        /// <b>URL:</b> http://docs.mql4.com/signals/signalunsubscribe.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
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
        /// <b>Function:</b> GlobalVariableCheck<br>
        /// <b>Description:</b> Checks the existence of a global variable with the specified name<br>
        /// <b>URL:</b> http://docs.mql4.com/globals/globalvariablecheck.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>name</b> :  [in] Global variable name.</li>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/globalvariablecheck")]
        public void Handle_GlobalVariableCheck_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, GlobalVariableCheck_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> GlobalVariableCheck<br>
        /// <b>Description:</b> Checks the existence of a global variable with the specified name<br>
        /// <b>URL:</b> http://docs.mql4.com/globals/globalvariablecheck.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>name</b> :  [in] Global variable name.</li>
        /// </ul>
        /// </summary>
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
        /// <b>Function:</b> GlobalVariableTime<br>
        /// <b>Description:</b> Returns the time when the global variable was last accessed.<br>
        /// <b>URL:</b> http://docs.mql4.com/globals/globalvariabletime.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>name</b> :  [in] Name of the global variable.</li>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/globalvariabletime")]
        public void Handle_GlobalVariableTime_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, GlobalVariableTime_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> GlobalVariableTime<br>
        /// <b>Description:</b> Returns the time when the global variable was last accessed.<br>
        /// <b>URL:</b> http://docs.mql4.com/globals/globalvariabletime.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>name</b> :  [in] Name of the global variable.</li>
        /// </ul>
        /// </summary>
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
        /// <b>Function:</b> GlobalVariableDel<br>
        /// <b>Description:</b> Deletes a global variable from the client terminal<br>
        /// <b>URL:</b> http://docs.mql4.com/globals/globalvariabledel.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>name</b> :  [in] Global variable name.</li>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/globalvariabledel")]
        public void Handle_GlobalVariableDel_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, GlobalVariableDel_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> GlobalVariableDel<br>
        /// <b>Description:</b> Deletes a global variable from the client terminal<br>
        /// <b>URL:</b> http://docs.mql4.com/globals/globalvariabledel.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>name</b> :  [in] Global variable name.</li>
        /// </ul>
        /// </summary>
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
        /// <b>Function:</b> GlobalVariableGet<br>
        /// <b>Description:</b> Returns the value of an existing global variable of the client terminal. There are 2 variants of the function.<br>
        /// <b>URL:</b> http://docs.mql4.com/globals/globalvariableget.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>name</b> :  [in] Global variable name.</li>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/globalvariableget")]
        public void Handle_GlobalVariableGet_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, GlobalVariableGet_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> GlobalVariableGet<br>
        /// <b>Description:</b> Returns the value of an existing global variable of the client terminal. There are 2 variants of the function.<br>
        /// <b>URL:</b> http://docs.mql4.com/globals/globalvariableget.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>name</b> :  [in] Global variable name.</li>
        /// </ul>
        /// </summary>
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
        /// <b>Function:</b> GlobalVariableName<br>
        /// <b>Description:</b> Returns the name of a global variable by its ordinal number.<br>
        /// <b>URL:</b> http://docs.mql4.com/globals/globalvariablename.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>index</b> :  [in] Sequence number in the list of global variables. It should be greater than or equal to 0 and less than .</li>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/globalvariablename")]
        public void Handle_GlobalVariableName_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, GlobalVariableName_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> GlobalVariableName<br>
        /// <b>Description:</b> Returns the name of a global variable by its ordinal number.<br>
        /// <b>URL:</b> http://docs.mql4.com/globals/globalvariablename.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>index</b> :  [in] Sequence number in the list of global variables. It should be greater than or equal to 0 and less than .</li>
        /// </ul>
        /// </summary>
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
        /// <b>Function:</b> GlobalVariableSet<br>
        /// <b>Description:</b> Sets a new value for a global variable. If the variable does not exist, the system creates a new global variable.<br>
        /// <b>URL:</b> http://docs.mql4.com/globals/globalvariableset.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>name</b> :  [in] Global variable name.</li>
        /// <li><b>value</b> :  [in] The new numerical value.</li>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/globalvariableset")]
        public void Handle_GlobalVariableSet_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, GlobalVariableSet_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> GlobalVariableSet<br>
        /// <b>Description:</b> Sets a new value for a global variable. If the variable does not exist, the system creates a new global variable.<br>
        /// <b>URL:</b> http://docs.mql4.com/globals/globalvariableset.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>name</b> :  [in] Global variable name.</li>
        /// <li><b>value</b> :  [in] The new numerical value.</li>
        /// </ul>
        /// </summary>
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
        /// <b>Function:</b> GlobalVariablesFlush<br>
        /// <b>Description:</b> Forcibly saves contents of all global variables to a disk.<br>
        /// <b>URL:</b> http://docs.mql4.com/globals/globalvariablesflush.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/globalvariablesflush")]
        public void Handle_GlobalVariablesFlush_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, GlobalVariablesFlush_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> GlobalVariablesFlush<br>
        /// <b>Description:</b> Forcibly saves contents of all global variables to a disk.<br>
        /// <b>URL:</b> http://docs.mql4.com/globals/globalvariablesflush.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
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
        /// <b>Function:</b> GlobalVariableTemp<br>
        /// <b>Description:</b> The function attempts to create a temporary global variable. If the variable doesn't exist, the system creates a new temporary global variable.<br>
        /// <b>URL:</b> http://docs.mql4.com/globals/globalvariabletemp.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>name</b> :  [in] The name of a temporary global variable.</li>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/globalvariabletemp")]
        public void Handle_GlobalVariableTemp_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, GlobalVariableTemp_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> GlobalVariableTemp<br>
        /// <b>Description:</b> The function attempts to create a temporary global variable. If the variable doesn't exist, the system creates a new temporary global variable.<br>
        /// <b>URL:</b> http://docs.mql4.com/globals/globalvariabletemp.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>name</b> :  [in] The name of a temporary global variable.</li>
        /// </ul>
        /// </summary>
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
        /// <b>Function:</b> GlobalVariableSetOnCondition<br>
        /// <b>Description:</b> Sets the new value of the existing global variable if the current value equals to the third parameter check_value. If there is no global variable, the function will generate an error ERR_GLOBALVARIABLE_NOT_FOUND (4501) and return false.<br>
        /// <b>URL:</b> http://docs.mql4.com/globals/globalvariablesetoncondition.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>name</b> :  [in] The name of a global variable.</li>
        /// <li><b>value</b> :  [in] New value.</li>
        /// <li><b>check_value</b> :  [in] The value to check the current value of the global variable.</li>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/globalvariablesetoncondition")]
        public void Handle_GlobalVariableSetOnCondition_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, GlobalVariableSetOnCondition_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> GlobalVariableSetOnCondition<br>
        /// <b>Description:</b> Sets the new value of the existing global variable if the current value equals to the third parameter check_value. If there is no global variable, the function will generate an error ERR_GLOBALVARIABLE_NOT_FOUND (4501) and return false.<br>
        /// <b>URL:</b> http://docs.mql4.com/globals/globalvariablesetoncondition.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>name</b> :  [in] The name of a global variable.</li>
        /// <li><b>value</b> :  [in] New value.</li>
        /// <li><b>check_value</b> :  [in] The value to check the current value of the global variable.</li>
        /// </ul>
        /// </summary>
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
        /// <b>Function:</b> GlobalVariablesDeleteAll<br>
        /// <b>Description:</b> Deletes global variables of the client terminal.<br>
        /// <b>URL:</b> http://docs.mql4.com/globals/globalvariablesdeleteall.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>prefix_name</b> :  [in] Name prefix global variables to remove. If you specify a prefix NULL or empty string, then all variables that meet the data criterion will be deleted.</li>
        /// <li><b>limit_data</b> :  [in] Optional parameter. Date to select global variables by the time of their last modification. The function removes global variables, which were changed before this date. If the parameter is zero, then all variables that meet the first criterion (prefix) are deleted.</li>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/globalvariablesdeleteall")]
        public void Handle_GlobalVariablesDeleteAll_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, GlobalVariablesDeleteAll_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> GlobalVariablesDeleteAll<br>
        /// <b>Description:</b> Deletes global variables of the client terminal.<br>
        /// <b>URL:</b> http://docs.mql4.com/globals/globalvariablesdeleteall.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>prefix_name</b> :  [in] Name prefix global variables to remove. If you specify a prefix NULL or empty string, then all variables that meet the data criterion will be deleted.</li>
        /// <li><b>limit_data</b> :  [in] Optional parameter. Date to select global variables by the time of their last modification. The function removes global variables, which were changed before this date. If the parameter is zero, then all variables that meet the first criterion (prefix) are deleted.</li>
        /// </ul>
        /// </summary>
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
        /// <b>Function:</b> GlobalVariablesTotal<br>
        /// <b>Description:</b> Returns the total number of global variables of the client terminal.<br>
        /// <b>URL:</b> http://docs.mql4.com/globals/globalvariablestotal.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/globalvariablestotal")]
        public void Handle_GlobalVariablesTotal_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, GlobalVariablesTotal_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> GlobalVariablesTotal<br>
        /// <b>Description:</b> Returns the total number of global variables of the client terminal.<br>
        /// <b>URL:</b> http://docs.mql4.com/globals/globalvariablestotal.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
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
        /// <b>Function:</b> HideTestIndicators<br>
        /// <b>Description:</b> The function sets a flag hiding indicators called by the Expert Advisor.<br>
        /// <b>URL:</b> http://docs.mql4.com/customind/hidetestindicators.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>hide</b> :  [in] Hiding flag.</li>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/hidetestindicators")]
        public void Handle_HideTestIndicators_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, HideTestIndicators_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> HideTestIndicators<br>
        /// <b>Description:</b> The function sets a flag hiding indicators called by the Expert Advisor.<br>
        /// <b>URL:</b> http://docs.mql4.com/customind/hidetestindicators.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>hide</b> :  [in] Hiding flag.</li>
        /// </ul>
        /// </summary>
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
        /// <b>Function:</b> IndicatorSetDouble<br>
        /// <b>Description:</b> The function sets the value of the corresponding indicator property. Indicator property must be of the double type. There are two variants of the function.<br>
        /// <b>URL:</b> http://docs.mql4.com/customind/indicatorsetdouble.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>prop_id</b> :  [in] Identifier of the indicator property. The value can be one of the values of the enumeration.</li>
        /// <li><b>prop_value</b> :  [in] Value of property.</li>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/indicatorsetdouble")]
        public void Handle_IndicatorSetDouble_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, IndicatorSetDouble_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> IndicatorSetDouble<br>
        /// <b>Description:</b> The function sets the value of the corresponding indicator property. Indicator property must be of the double type. There are two variants of the function.<br>
        /// <b>URL:</b> http://docs.mql4.com/customind/indicatorsetdouble.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>prop_id</b> :  [in] Identifier of the indicator property. The value can be one of the values of the enumeration.</li>
        /// <li><b>prop_value</b> :  [in] Value of property.</li>
        /// </ul>
        /// </summary>
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
        /// <b>Function:</b> IndicatorSetDouble<br>
        /// <b>Description:</b> The function sets the value of the corresponding indicator property. Indicator property must be of the double type. There are two variants of the function.<br>
        /// <b>URL:</b> http://docs.mql4.com/customind/indicatorsetdouble.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>prop_id</b> :  [in] Identifier of the indicator property. The value can be one of the values of the enumeration.</li>
        /// <li><b>prop_modifier</b> :  [in] Modifier of the specified property. Only level properties require a modifier. Numbering of levels starts from 0. It means that in order to set property for the second level you need to specify 1 (1 less than when using ).</li>
        /// <li><b>prop_value</b> :  [in] Value of property.</li>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/indicatorsetdouble")]
        public void Handle_IndicatorSetDouble_2(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, IndicatorSetDouble_2(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> IndicatorSetDouble<br>
        /// <b>Description:</b> The function sets the value of the corresponding indicator property. Indicator property must be of the double type. There are two variants of the function.<br>
        /// <b>URL:</b> http://docs.mql4.com/customind/indicatorsetdouble.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>prop_id</b> :  [in] Identifier of the indicator property. The value can be one of the values of the enumeration.</li>
        /// <li><b>prop_modifier</b> :  [in] Modifier of the specified property. Only level properties require a modifier. Numbering of levels starts from 0. It means that in order to set property for the second level you need to specify 1 (1 less than when using ).</li>
        /// <li><b>prop_value</b> :  [in] Value of property.</li>
        /// </ul>
        /// </summary>
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
        /// <b>Function:</b> IndicatorSetInteger<br>
        /// <b>Description:</b> The function sets the value of the corresponding indicator property. Indicator property must be of the int or color type. There are two variants of the function.<br>
        /// <b>URL:</b> http://docs.mql4.com/customind/indicatorsetinteger.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>prop_id</b> :  [in] Identifier of the indicator property. The value can be one of the values of the enumeration.</li>
        /// <li><b>prop_value</b> :  [in] Value of property.</li>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/indicatorsetinteger")]
        public void Handle_IndicatorSetInteger_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, IndicatorSetInteger_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> IndicatorSetInteger<br>
        /// <b>Description:</b> The function sets the value of the corresponding indicator property. Indicator property must be of the int or color type. There are two variants of the function.<br>
        /// <b>URL:</b> http://docs.mql4.com/customind/indicatorsetinteger.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>prop_id</b> :  [in] Identifier of the indicator property. The value can be one of the values of the enumeration.</li>
        /// <li><b>prop_value</b> :  [in] Value of property.</li>
        /// </ul>
        /// </summary>
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
        /// <b>Function:</b> IndicatorSetInteger<br>
        /// <b>Description:</b> The function sets the value of the corresponding indicator property. Indicator property must be of the int or color type. There are two variants of the function.<br>
        /// <b>URL:</b> http://docs.mql4.com/customind/indicatorsetinteger.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>prop_id</b> :  [in] Identifier of the indicator property. The value can be one of the values of the enumeration.</li>
        /// <li><b>prop_modifier</b> :  [in] Modifier of the specified property. Only level properties require a modifier.</li>
        /// <li><b>prop_value</b> :  [in] Value of property.</li>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/indicatorsetinteger")]
        public void Handle_IndicatorSetInteger_2(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, IndicatorSetInteger_2(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> IndicatorSetInteger<br>
        /// <b>Description:</b> The function sets the value of the corresponding indicator property. Indicator property must be of the int or color type. There are two variants of the function.<br>
        /// <b>URL:</b> http://docs.mql4.com/customind/indicatorsetinteger.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>prop_id</b> :  [in] Identifier of the indicator property. The value can be one of the values of the enumeration.</li>
        /// <li><b>prop_modifier</b> :  [in] Modifier of the specified property. Only level properties require a modifier.</li>
        /// <li><b>prop_value</b> :  [in] Value of property.</li>
        /// </ul>
        /// </summary>
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
        /// <b>Function:</b> IndicatorSetString<br>
        /// <b>Description:</b> The function sets the value of the corresponding indicator property. Indicator property must be of the string type. There are two variants of the function.<br>
        /// <b>URL:</b> http://docs.mql4.com/customind/indicatorsetstring.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>prop_id</b> :  [in] Identifier of the indicator property. The value can be one of the values of the enumeration.</li>
        /// <li><b>prop_value</b> :  [in] Value of property.</li>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/indicatorsetstring")]
        public void Handle_IndicatorSetString_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, IndicatorSetString_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> IndicatorSetString<br>
        /// <b>Description:</b> The function sets the value of the corresponding indicator property. Indicator property must be of the string type. There are two variants of the function.<br>
        /// <b>URL:</b> http://docs.mql4.com/customind/indicatorsetstring.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>prop_id</b> :  [in] Identifier of the indicator property. The value can be one of the values of the enumeration.</li>
        /// <li><b>prop_value</b> :  [in] Value of property.</li>
        /// </ul>
        /// </summary>
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
        /// <b>Function:</b> IndicatorSetString<br>
        /// <b>Description:</b> The function sets the value of the corresponding indicator property. Indicator property must be of the string type. There are two variants of the function.<br>
        /// <b>URL:</b> http://docs.mql4.com/customind/indicatorsetstring.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>prop_id</b> :  [in] Identifier of the indicator property. The value can be one of the values of the enumeration.</li>
        /// <li><b>prop_modifier</b> :  [in] Modifier of the specified property. Only level properties require a modifier.</li>
        /// <li><b>prop_value</b> :  [in] Value of property.</li>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/indicatorsetstring")]
        public void Handle_IndicatorSetString_2(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, IndicatorSetString_2(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> IndicatorSetString<br>
        /// <b>Description:</b> The function sets the value of the corresponding indicator property. Indicator property must be of the string type. There are two variants of the function.<br>
        /// <b>URL:</b> http://docs.mql4.com/customind/indicatorsetstring.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>prop_id</b> :  [in] Identifier of the indicator property. The value can be one of the values of the enumeration.</li>
        /// <li><b>prop_modifier</b> :  [in] Modifier of the specified property. Only level properties require a modifier.</li>
        /// <li><b>prop_value</b> :  [in] Value of property.</li>
        /// </ul>
        /// </summary>
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
        /// <b>Function:</b> IndicatorBuffers<br>
        /// <b>Description:</b> Allocates memory for buffers used for custom indicator calculations.<br>
        /// <b>URL:</b> http://docs.mql4.com/customind/indicatorbuffers.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>count</b> :  [in] Amount of buffers to be allocated. Should be within the range between indicator_buffers and 512 buffers.</li>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/indicatorbuffers")]
        public void Handle_IndicatorBuffers_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, IndicatorBuffers_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> IndicatorBuffers<br>
        /// <b>Description:</b> Allocates memory for buffers used for custom indicator calculations.<br>
        /// <b>URL:</b> http://docs.mql4.com/customind/indicatorbuffers.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>count</b> :  [in] Amount of buffers to be allocated. Should be within the range between indicator_buffers and 512 buffers.</li>
        /// </ul>
        /// </summary>
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
        /// <b>Function:</b> IndicatorCounted<br>
        /// <b>Description:</b> The function returns the amount of bars not changed after the indicator had been launched last.<br>
        /// <b>URL:</b> http://docs.mql4.com/customind/indicatorcounted.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/indicatorcounted")]
        public void Handle_IndicatorCounted_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, IndicatorCounted_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> IndicatorCounted<br>
        /// <b>Description:</b> The function returns the amount of bars not changed after the indicator had been launched last.<br>
        /// <b>URL:</b> http://docs.mql4.com/customind/indicatorcounted.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// </ul>
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
        /// <b>Function:</b> IndicatorDigits<br>
        /// <b>Description:</b> Sets precision format (the count of digits after decimal point) to visualize indicator values.<br>
        /// <b>URL:</b> http://docs.mql4.com/customind/indicatordigits.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>digits</b> :  [in] Precision format, the count of digits after decimal point.</li>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/indicatordigits")]
        public void Handle_IndicatorDigits_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, IndicatorDigits_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> IndicatorDigits<br>
        /// <b>Description:</b> Sets precision format (the count of digits after decimal point) to visualize indicator values.<br>
        /// <b>URL:</b> http://docs.mql4.com/customind/indicatordigits.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>digits</b> :  [in] Precision format, the count of digits after decimal point.</li>
        /// </ul>
        /// </summary>
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
        /// <b>Function:</b> IndicatorShortName<br>
        /// <b>Description:</b> Sets the "short" name of a custom indicator to be shown in the DataWindow and in the chart subwindow.<br>
        /// <b>URL:</b> http://docs.mql4.com/customind/indicatorshortname.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>name</b> :  [in] New short name.</li>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/indicatorshortname")]
        public void Handle_IndicatorShortName_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, IndicatorShortName_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> IndicatorShortName<br>
        /// <b>Description:</b> Sets the "short" name of a custom indicator to be shown in the DataWindow and in the chart subwindow.<br>
        /// <b>URL:</b> http://docs.mql4.com/customind/indicatorshortname.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>name</b> :  [in] New short name.</li>
        /// </ul>
        /// </summary>
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
        /// <b>Function:</b> SetIndexArrow<br>
        /// <b>Description:</b> Sets an arrow symbol for indicators line of the DRAW_ARROW type.<br>
        /// <b>URL:</b> http://docs.mql4.com/customind/setindexarrow.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>index</b> :  [in] Line index. Must lie between 0 and 7.</li>
        /// <li><b>code</b> :  [in] Symbol code from or predefined .</li>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/setindexarrow")]
        public void Handle_SetIndexArrow_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, SetIndexArrow_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> SetIndexArrow<br>
        /// <b>Description:</b> Sets an arrow symbol for indicators line of the DRAW_ARROW type.<br>
        /// <b>URL:</b> http://docs.mql4.com/customind/setindexarrow.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>index</b> :  [in] Line index. Must lie between 0 and 7.</li>
        /// <li><b>code</b> :  [in] Symbol code from or predefined .</li>
        /// </ul>
        /// </summary>
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
        /// <b>Function:</b> SetIndexDrawBegin<br>
        /// <b>Description:</b> Sets the bar number (from the data beginning) from which the drawing of the given indicator line must start.<br>
        /// <b>URL:</b> http://docs.mql4.com/customind/setindexdrawbegin.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>index</b> :  [in] Line index. Must lie between 0 and 7.</li>
        /// <li><b>begin</b> :  [in] First drawing bar position number.</li>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/setindexdrawbegin")]
        public void Handle_SetIndexDrawBegin_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, SetIndexDrawBegin_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> SetIndexDrawBegin<br>
        /// <b>Description:</b> Sets the bar number (from the data beginning) from which the drawing of the given indicator line must start.<br>
        /// <b>URL:</b> http://docs.mql4.com/customind/setindexdrawbegin.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>index</b> :  [in] Line index. Must lie between 0 and 7.</li>
        /// <li><b>begin</b> :  [in] First drawing bar position number.</li>
        /// </ul>
        /// </summary>
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
        /// <b>Function:</b> SetIndexEmptyValue<br>
        /// <b>Description:</b> Sets drawing line empty value.<br>
        /// <b>URL:</b> http://docs.mql4.com/customind/setindexemptyvalue.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>index</b> :  [in] Line index. Must lie between 0 and 7.</li>
        /// <li><b>value</b> :  [in] New "empty" value.</li>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/setindexemptyvalue")]
        public void Handle_SetIndexEmptyValue_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, SetIndexEmptyValue_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> SetIndexEmptyValue<br>
        /// <b>Description:</b> Sets drawing line empty value.<br>
        /// <b>URL:</b> http://docs.mql4.com/customind/setindexemptyvalue.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>index</b> :  [in] Line index. Must lie between 0 and 7.</li>
        /// <li><b>value</b> :  [in] New "empty" value.</li>
        /// </ul>
        /// </summary>
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
        /// <b>Function:</b> SetIndexLabel<br>
        /// <b>Description:</b> Sets drawing line description for showing in the DataWindow and in the tooltip.<br>
        /// <b>URL:</b> http://docs.mql4.com/customind/setindexlabel.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>index</b> :  [in] Line index. Must lie between 0 and 7.</li>
        /// <li><b>text</b> :  [in] Label text. NULL means that index value is not shown in the DataWindow.</li>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/setindexlabel")]
        public void Handle_SetIndexLabel_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, SetIndexLabel_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> SetIndexLabel<br>
        /// <b>Description:</b> Sets drawing line description for showing in the DataWindow and in the tooltip.<br>
        /// <b>URL:</b> http://docs.mql4.com/customind/setindexlabel.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>index</b> :  [in] Line index. Must lie between 0 and 7.</li>
        /// <li><b>text</b> :  [in] Label text. NULL means that index value is not shown in the DataWindow.</li>
        /// </ul>
        /// </summary>
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
        /// <b>Function:</b> SetIndexShift<br>
        /// <b>Description:</b> Sets offset for the drawing line.<br>
        /// <b>URL:</b> http://docs.mql4.com/customind/setindexshift.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>index</b> :  [in] Line index. Must lie between 0 and 7.</li>
        /// <li><b>shift</b> :  [in] Shift value in bars.</li>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/setindexshift")]
        public void Handle_SetIndexShift_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, SetIndexShift_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> SetIndexShift<br>
        /// <b>Description:</b> Sets offset for the drawing line.<br>
        /// <b>URL:</b> http://docs.mql4.com/customind/setindexshift.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>index</b> :  [in] Line index. Must lie between 0 and 7.</li>
        /// <li><b>shift</b> :  [in] Shift value in bars.</li>
        /// </ul>
        /// </summary>
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
        /// <b>Function:</b> SetIndexStyle<br>
        /// <b>Description:</b> Sets the new type, style, width and color for a given indicator line.<br>
        /// <b>URL:</b> http://docs.mql4.com/customind/setindexstyle.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>index</b> :  [in] Line index. Must lie between 0 and 7.</li>
        /// <li><b>type</b> :  [in] Shape style. Can be one of listed.</li>
        /// <li><b>style</b> :  [in] Drawing style. It is used for one-pixel thick lines. It can be one of the listed. EMPTY value means that the style will not be changed.</li>
        /// <li><b>width</b> :  [in] Line width. Valid values are: 1,2,3,4,5. EMPTY value means that width will not be changed.</li>
        /// <li><b>clr</b> :  [in] Line color. Absence of this parameter means that the color will not be changed.</li>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/setindexstyle")]
        public void Handle_SetIndexStyle_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, SetIndexStyle_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> SetIndexStyle<br>
        /// <b>Description:</b> Sets the new type, style, width and color for a given indicator line.<br>
        /// <b>URL:</b> http://docs.mql4.com/customind/setindexstyle.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>index</b> :  [in] Line index. Must lie between 0 and 7.</li>
        /// <li><b>type</b> :  [in] Shape style. Can be one of listed.</li>
        /// <li><b>style</b> :  [in] Drawing style. It is used for one-pixel thick lines. It can be one of the listed. EMPTY value means that the style will not be changed.</li>
        /// <li><b>width</b> :  [in] Line width. Valid values are: 1,2,3,4,5. EMPTY value means that width will not be changed.</li>
        /// <li><b>clr</b> :  [in] Line color. Absence of this parameter means that the color will not be changed.</li>
        /// </ul>
        /// </summary>
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
        /// <b>Function:</b> SetLevelStyle<br>
        /// <b>Description:</b> The function sets a new style, width and color of horizontal levels of indicator to be output in a separate window.<br>
        /// <b>URL:</b> http://docs.mql4.com/customind/setlevelstyle.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>draw_style</b> :  [in] Drawing style. Can be one of the listed. EMPTY value means that the style will not be changed.</li>
        /// <li><b>line_width</b> :  [in] Line width. Valid values are 1,2,3,4,5. EMPTY value indicates that the width will not be changed.</li>
        /// <li><b>clr</b> :  [in] Line color. Empty value CLR_NONE means that the color will not be changed.</li>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/setlevelstyle")]
        public void Handle_SetLevelStyle_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, SetLevelStyle_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> SetLevelStyle<br>
        /// <b>Description:</b> The function sets a new style, width and color of horizontal levels of indicator to be output in a separate window.<br>
        /// <b>URL:</b> http://docs.mql4.com/customind/setlevelstyle.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>draw_style</b> :  [in] Drawing style. Can be one of the listed. EMPTY value means that the style will not be changed.</li>
        /// <li><b>line_width</b> :  [in] Line width. Valid values are 1,2,3,4,5. EMPTY value indicates that the width will not be changed.</li>
        /// <li><b>clr</b> :  [in] Line color. Empty value CLR_NONE means that the color will not be changed.</li>
        /// </ul>
        /// </summary>
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
        /// <b>Function:</b> SetLevelValue<br>
        /// <b>Description:</b> The function sets a value for a given horizontal level of the indicator to be output in a separate window.<br>
        /// <b>URL:</b> http://docs.mql4.com/customind/setlevelvalue.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>level</b> :  [in] Level index (0-31).</li>
        /// <li><b>value</b> :  [in] Value for the given indicator level.</li>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/setlevelvalue")]
        public void Handle_SetLevelValue_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, SetLevelValue_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> SetLevelValue<br>
        /// <b>Description:</b> The function sets a value for a given horizontal level of the indicator to be output in a separate window.<br>
        /// <b>URL:</b> http://docs.mql4.com/customind/setlevelvalue.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>level</b> :  [in] Level index (0-31).</li>
        /// <li><b>value</b> :  [in] Value for the given indicator level.</li>
        /// </ul>
        /// </summary>
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
        /// <b>Function:</b> ObjectCreate<br>
        /// <b>Description:</b> The function creates an object with the specified name, type, and the initial coordinates in the specified chart subwindow of the specified chart. There are two variants of the function:<br>
        /// <b>URL:</b> http://docs.mql4.com/objects/objectcreate.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>chart_id</b> :  [in] Chart identifier.</li>
        /// <li><b>object_name</b> :  [in] Name of the object. The name must be unique within a chart, including its subwindows.</li>
        /// <li><b>object_type</b> :  [in] Object type. The value can be one of the values of the enumeration.</li>
        /// <li><b>sub_window</b> :  [in] Number of the chart subwindow. 0 means the main chart window. The specified subwindow must exist (window index must be greater or equal to 0 and less than ), otherwise the function returns false.</li>
        /// <li><b>time1</b> :  [in] The time coordinate of the first anchor point.</li>
        /// <li><b>price1</b> :  [in] The price coordinate of the first anchor point.</li>
        /// <li><b>timeN</b> :  [in] The time coordinate of the N-th anchor point.</li>
        /// <li><b>priceN</b> :  [in] The price coordinate of the N-th anchor point.</li>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/objectcreate")]
        public void Handle_ObjectCreate_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, ObjectCreate_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> ObjectCreate<br>
        /// <b>Description:</b> The function creates an object with the specified name, type, and the initial coordinates in the specified chart subwindow of the specified chart. There are two variants of the function:<br>
        /// <b>URL:</b> http://docs.mql4.com/objects/objectcreate.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>chart_id</b> :  [in] Chart identifier.</li>
        /// <li><b>object_name</b> :  [in] Name of the object. The name must be unique within a chart, including its subwindows.</li>
        /// <li><b>object_type</b> :  [in] Object type. The value can be one of the values of the enumeration.</li>
        /// <li><b>sub_window</b> :  [in] Number of the chart subwindow. 0 means the main chart window. The specified subwindow must exist (window index must be greater or equal to 0 and less than ), otherwise the function returns false.</li>
        /// <li><b>time1</b> :  [in] The time coordinate of the first anchor point.</li>
        /// <li><b>price1</b> :  [in] The price coordinate of the first anchor point.</li>
        /// <li><b>timeN</b> :  [in] The time coordinate of the N-th anchor point.</li>
        /// <li><b>priceN</b> :  [in] The price coordinate of the N-th anchor point.</li>
        /// </ul>
        /// </summary>
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
        /// <b>Function:</b> ObjectCreate<br>
        /// <b>Description:</b> The function creates an object with the specified name, type, and the initial coordinates in the specified chart subwindow of the specified chart. There are two variants of the function:<br>
        /// <b>URL:</b> http://docs.mql4.com/objects/objectcreate.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>object_name</b> :  [in] Name of the object. The name must be unique within a chart, including its subwindows.</li>
        /// <li><b>object_type</b> :  [in] Object type. The value can be one of the values of the enumeration.</li>
        /// <li><b>sub_window</b> :  [in] Number of the chart subwindow. 0 means the main chart window. The specified subwindow must exist (window index must be greater or equal to 0 and less than ), otherwise the function returns false.</li>
        /// <li><b>time1</b> :  [in] The time coordinate of the first anchor point.</li>
        /// <li><b>price1</b> :  [in] The price coordinate of the first anchor point.</li>
        /// <li><b>time2</b> :  [in] The time coordinate of the second anchor point.</li>
        /// <li><b>price2</b> :  [in] The price coordinate of the second anchor point.</li>
        /// <li><b>time3</b> :  [in] The time coordinate of the third anchor point.</li>
        /// <li><b>price3</b> :  [in] The price coordinate of the third anchor point.</li>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/objectcreate")]
        public void Handle_ObjectCreate_2(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, ObjectCreate_2(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> ObjectCreate<br>
        /// <b>Description:</b> The function creates an object with the specified name, type, and the initial coordinates in the specified chart subwindow of the specified chart. There are two variants of the function:<br>
        /// <b>URL:</b> http://docs.mql4.com/objects/objectcreate.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>object_name</b> :  [in] Name of the object. The name must be unique within a chart, including its subwindows.</li>
        /// <li><b>object_type</b> :  [in] Object type. The value can be one of the values of the enumeration.</li>
        /// <li><b>sub_window</b> :  [in] Number of the chart subwindow. 0 means the main chart window. The specified subwindow must exist (window index must be greater or equal to 0 and less than ), otherwise the function returns false.</li>
        /// <li><b>time1</b> :  [in] The time coordinate of the first anchor point.</li>
        /// <li><b>price1</b> :  [in] The price coordinate of the first anchor point.</li>
        /// <li><b>time2</b> :  [in] The time coordinate of the second anchor point.</li>
        /// <li><b>price2</b> :  [in] The price coordinate of the second anchor point.</li>
        /// <li><b>time3</b> :  [in] The time coordinate of the third anchor point.</li>
        /// <li><b>price3</b> :  [in] The price coordinate of the third anchor point.</li>
        /// </ul>
        /// </summary>
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
        /// <b>Function:</b> ObjectName<br>
        /// <b>Description:</b> The function returns the name of the corresponding object by its index in the objects list.<br>
        /// <b>URL:</b> http://docs.mql4.com/objects/objectname.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>object_index</b> :  [in] Object index. This value must be greater or equal to 0 and less than .</li>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/objectname")]
        public void Handle_ObjectName_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, ObjectName_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> ObjectName<br>
        /// <b>Description:</b> The function returns the name of the corresponding object by its index in the objects list.<br>
        /// <b>URL:</b> http://docs.mql4.com/objects/objectname.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>object_index</b> :  [in] Object index. This value must be greater or equal to 0 and less than .</li>
        /// </ul>
        /// </summary>
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
        /// <b>Function:</b> ObjectDelete<br>
        /// <b>Description:</b> The function removes the object with the specified name at the specified chart. There are two variants of the function:<br>
        /// <b>URL:</b> http://docs.mql4.com/objects/objectdelete.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>chart_id</b> :  [in] Chart identifier.</li>
        /// <li><b>object_name</b> :  [in] Name of object to be deleted.</li>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/objectdelete")]
        public void Handle_ObjectDelete_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, ObjectDelete_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> ObjectDelete<br>
        /// <b>Description:</b> The function removes the object with the specified name at the specified chart. There are two variants of the function:<br>
        /// <b>URL:</b> http://docs.mql4.com/objects/objectdelete.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>chart_id</b> :  [in] Chart identifier.</li>
        /// <li><b>object_name</b> :  [in] Name of object to be deleted.</li>
        /// </ul>
        /// </summary>
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
        /// <b>Function:</b> ObjectDelete<br>
        /// <b>Description:</b> The function removes the object with the specified name at the specified chart. There are two variants of the function:<br>
        /// <b>URL:</b> http://docs.mql4.com/objects/objectdelete.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>object_name</b> :  [in] Name of object to be deleted.</li>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/objectdelete")]
        public void Handle_ObjectDelete_2(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, ObjectDelete_2(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> ObjectDelete<br>
        /// <b>Description:</b> The function removes the object with the specified name at the specified chart. There are two variants of the function:<br>
        /// <b>URL:</b> http://docs.mql4.com/objects/objectdelete.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>object_name</b> :  [in] Name of object to be deleted.</li>
        /// </ul>
        /// </summary>
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
        /// <b>Function:</b> ObjectsDeleteAll<br>
        /// <b>Description:</b> Removes all objects from the specified chart, specified chart subwindow, of the specified type.<br>
        /// <b>URL:</b> http://docs.mql4.com/objects/objectsdeleteall.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>chart_id</b> :  [in] Chart identifier.</li>
        /// <li><b>sub_window</b> :  [in] Number of the chart window. Must be greater or equal to -1 (-1 mean all subwindows, 0 means the main chart window) and less than .</li>
        /// <li><b>object_type</b> :  [in] Type of the object. The value can be one of the values of the enumeration. EMPTY (-1) means all types.</li>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/objectsdeleteall")]
        public void Handle_ObjectsDeleteAll_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, ObjectsDeleteAll_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> ObjectsDeleteAll<br>
        /// <b>Description:</b> Removes all objects from the specified chart, specified chart subwindow, of the specified type.<br>
        /// <b>URL:</b> http://docs.mql4.com/objects/objectsdeleteall.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>chart_id</b> :  [in] Chart identifier.</li>
        /// <li><b>sub_window</b> :  [in] Number of the chart window. Must be greater or equal to -1 (-1 mean all subwindows, 0 means the main chart window) and less than .</li>
        /// <li><b>object_type</b> :  [in] Type of the object. The value can be one of the values of the enumeration. EMPTY (-1) means all types.</li>
        /// </ul>
        /// </summary>
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
        /// <b>Function:</b> ObjectsDeleteAll<br>
        /// <b>Description:</b> Removes all objects from the specified chart, specified chart subwindow, of the specified type.<br>
        /// <b>URL:</b> http://docs.mql4.com/objects/objectsdeleteall.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>sub_window</b> :  [in] Number of the chart window. Must be greater or equal to -1 (-1 mean all subwindows, 0 means the main chart window) and less than .</li>
        /// <li><b>object_type</b> :  [in] Type of the object. The value can be one of the values of the enumeration. EMPTY (-1) means all types.</li>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/objectsdeleteall")]
        public void Handle_ObjectsDeleteAll_2(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, ObjectsDeleteAll_2(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> ObjectsDeleteAll<br>
        /// <b>Description:</b> Removes all objects from the specified chart, specified chart subwindow, of the specified type.<br>
        /// <b>URL:</b> http://docs.mql4.com/objects/objectsdeleteall.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>sub_window</b> :  [in] Number of the chart window. Must be greater or equal to -1 (-1 mean all subwindows, 0 means the main chart window) and less than .</li>
        /// <li><b>object_type</b> :  [in] Type of the object. The value can be one of the values of the enumeration. EMPTY (-1) means all types.</li>
        /// </ul>
        /// </summary>
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
        /// <b>Function:</b> ObjectsDeleteAll<br>
        /// <b>Description:</b> Removes all objects from the specified chart, specified chart subwindow, of the specified type.<br>
        /// <b>URL:</b> http://docs.mql4.com/objects/objectsdeleteall.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>chart_id</b> :  [in] Chart identifier.</li>
        /// <li><b>prefix</b> :  [in] Prefix in object names. All objects whose names start with this set of characters will be removed from chart. You can specify prefix as 'name' or 'name*' both variants will work the same. If an empty string is specified as the prefix, objects with all possible names will be removed.</li>
        /// <li><b>sub_window</b> :  [in] Number of the chart window. Must be greater or equal to -1 (-1 mean all subwindows, 0 means the main chart window) and less than .</li>
        /// <li><b>object_type</b> :  [in] Type of the object. The value can be one of the values of the enumeration. EMPTY (-1) means all types.</li>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/objectsdeleteall")]
        public void Handle_ObjectsDeleteAll_3(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, ObjectsDeleteAll_3(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> ObjectsDeleteAll<br>
        /// <b>Description:</b> Removes all objects from the specified chart, specified chart subwindow, of the specified type.<br>
        /// <b>URL:</b> http://docs.mql4.com/objects/objectsdeleteall.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>chart_id</b> :  [in] Chart identifier.</li>
        /// <li><b>prefix</b> :  [in] Prefix in object names. All objects whose names start with this set of characters will be removed from chart. You can specify prefix as 'name' or 'name*' both variants will work the same. If an empty string is specified as the prefix, objects with all possible names will be removed.</li>
        /// <li><b>sub_window</b> :  [in] Number of the chart window. Must be greater or equal to -1 (-1 mean all subwindows, 0 means the main chart window) and less than .</li>
        /// <li><b>object_type</b> :  [in] Type of the object. The value can be one of the values of the enumeration. EMPTY (-1) means all types.</li>
        /// </ul>
        /// </summary>
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
        /// <b>Function:</b> ObjectFind<br>
        /// <b>Description:</b> The function searches for an object having the specified name. There are two variants of the function:<br>
        /// <b>URL:</b> http://docs.mql4.com/objects/objectfind.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>chart_id</b> :  [in] Chart identifier.</li>
        /// <li><b>object_name</b> :  [in] The name of the object to find.</li>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/objectfind")]
        public void Handle_ObjectFind_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, ObjectFind_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> ObjectFind<br>
        /// <b>Description:</b> The function searches for an object having the specified name. There are two variants of the function:<br>
        /// <b>URL:</b> http://docs.mql4.com/objects/objectfind.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>chart_id</b> :  [in] Chart identifier.</li>
        /// <li><b>object_name</b> :  [in] The name of the object to find.</li>
        /// </ul>
        /// </summary>
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
        /// <b>Function:</b> ObjectFind<br>
        /// <b>Description:</b> The function searches for an object having the specified name. There are two variants of the function:<br>
        /// <b>URL:</b> http://docs.mql4.com/objects/objectfind.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>object_name</b> :  [in] The name of the object to find.</li>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/objectfind")]
        public void Handle_ObjectFind_2(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, ObjectFind_2(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> ObjectFind<br>
        /// <b>Description:</b> The function searches for an object having the specified name. There are two variants of the function:<br>
        /// <b>URL:</b> http://docs.mql4.com/objects/objectfind.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>object_name</b> :  [in] The name of the object to find.</li>
        /// </ul>
        /// </summary>
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
        /// <b>Function:</b> ObjectGetTimeByValue<br>
        /// <b>Description:</b> The function returns the time value for the specified price value of the specified object.<br>
        /// <b>URL:</b> http://docs.mql4.com/objects/objectgettimebyvalue.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>object_name</b> :  [in] Name of the object.</li>
        /// <li><b>value</b> :  [in] Price value.</li>
        /// <li><b>line_id</b> :  [in] Line identifier.</li>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/objectgettimebyvalue")]
        public void Handle_ObjectGetTimeByValue_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, ObjectGetTimeByValue_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> ObjectGetTimeByValue<br>
        /// <b>Description:</b> The function returns the time value for the specified price value of the specified object.<br>
        /// <b>URL:</b> http://docs.mql4.com/objects/objectgettimebyvalue.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>object_name</b> :  [in] Name of the object.</li>
        /// <li><b>value</b> :  [in] Price value.</li>
        /// <li><b>line_id</b> :  [in] Line identifier.</li>
        /// </ul>
        /// </summary>
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
        /// <b>Function:</b> ObjectGetValueByTime<br>
        /// <b>Description:</b> The function returns the price value for the specified time value of the specified object.<br>
        /// <b>URL:</b> http://docs.mql4.com/objects/objectgetvaluebytime.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>chart_id</b> :  [in] Chart identifier.</li>
        /// <li><b>object_name</b> :  [in] Name of the object.</li>
        /// <li><b>time</b> :  [in] Time value.</li>
        /// <li><b>line_id</b> :  [in] Line identifier.</li>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/objectgetvaluebytime")]
        public void Handle_ObjectGetValueByTime_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, ObjectGetValueByTime_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> ObjectGetValueByTime<br>
        /// <b>Description:</b> The function returns the price value for the specified time value of the specified object.<br>
        /// <b>URL:</b> http://docs.mql4.com/objects/objectgetvaluebytime.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>chart_id</b> :  [in] Chart identifier.</li>
        /// <li><b>object_name</b> :  [in] Name of the object.</li>
        /// <li><b>time</b> :  [in] Time value.</li>
        /// <li><b>line_id</b> :  [in] Line identifier.</li>
        /// </ul>
        /// </summary>
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
        /// <b>Function:</b> ObjectMove<br>
        /// <b>Description:</b> The function changes coordinates of the specified anchor point of the object at the specified chart. There are two variants of the function:<br>
        /// <b>URL:</b> http://docs.mql4.com/objects/objectmove.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>object_name</b> :  [in] Name of the object.</li>
        /// <li><b>point_index</b> :  [in] Index of the anchor point. The number of anchor points depends on the .</li>
        /// <li><b>time</b> :  [in] Time coordinate of the selected anchor point.</li>
        /// <li><b>price</b> :  [in] Price coordinate of the selected anchor point.</li>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/objectmove")]
        public void Handle_ObjectMove_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, ObjectMove_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> ObjectMove<br>
        /// <b>Description:</b> The function changes coordinates of the specified anchor point of the object at the specified chart. There are two variants of the function:<br>
        /// <b>URL:</b> http://docs.mql4.com/objects/objectmove.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>object_name</b> :  [in] Name of the object.</li>
        /// <li><b>point_index</b> :  [in] Index of the anchor point. The number of anchor points depends on the .</li>
        /// <li><b>time</b> :  [in] Time coordinate of the selected anchor point.</li>
        /// <li><b>price</b> :  [in] Price coordinate of the selected anchor point.</li>
        /// </ul>
        /// </summary>
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
        /// <b>Function:</b> ObjectsTotal<br>
        /// <b>Description:</b> The function returns the number of objects of the specified type in the specified chart. There are two variants of the function:<br>
        /// <b>URL:</b> http://docs.mql4.com/objects/objectstotal.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>chart_id</b> :  [in] Chart identifier.</li>
        /// <li><b>sub_window</b> :  [in] Number of the chart subwindow. 0 means the main chart window, -1 means all the subwindows of the chart, including the main window.</li>
        /// <li><b>type</b> :  [in] Type of the object. The value can be one of the values of the enumeration. EMPTY(-1) means all types.</li>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/objectstotal")]
        public void Handle_ObjectsTotal_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, ObjectsTotal_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> ObjectsTotal<br>
        /// <b>Description:</b> The function returns the number of objects of the specified type in the specified chart. There are two variants of the function:<br>
        /// <b>URL:</b> http://docs.mql4.com/objects/objectstotal.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>chart_id</b> :  [in] Chart identifier.</li>
        /// <li><b>sub_window</b> :  [in] Number of the chart subwindow. 0 means the main chart window, -1 means all the subwindows of the chart, including the main window.</li>
        /// <li><b>type</b> :  [in] Type of the object. The value can be one of the values of the enumeration. EMPTY(-1) means all types.</li>
        /// </ul>
        /// </summary>
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
        /// <b>Function:</b> ObjectsTotal<br>
        /// <b>Description:</b> The function returns the number of objects of the specified type in the specified chart. There are two variants of the function:<br>
        /// <b>URL:</b> http://docs.mql4.com/objects/objectstotal.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>type</b> :  [in] Type of the object. The value can be one of the values of the enumeration. EMPTY(-1) means all types.</li>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/objectstotal")]
        public void Handle_ObjectsTotal_2(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, ObjectsTotal_2(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> ObjectsTotal<br>
        /// <b>Description:</b> The function returns the number of objects of the specified type in the specified chart. There are two variants of the function:<br>
        /// <b>URL:</b> http://docs.mql4.com/objects/objectstotal.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>type</b> :  [in] Type of the object. The value can be one of the values of the enumeration. EMPTY(-1) means all types.</li>
        /// </ul>
        /// </summary>
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
        /// <b>Function:</b> ObjectGetDouble<br>
        /// <b>Description:</b> The function returns the value of the corresponding object property. The object property must be of the<br>
        /// <b>URL:</b> http://docs.mql4.com/objects/objectgetdouble.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>chart_id</b> :  [in] Chart identifier. 0 means the current chart.</li>
        /// <li><b>object_name</b> :  [in] Name of the object.</li>
        /// <li><b>prop_id</b> :  [in] ID of the object property. The value can be one of the values of the enumeration.</li>
        /// <li><b>prop_modifier</b> :  [in] Modifier of the specified property. For the first variant, the default modifier value is equal to 0. Most properties do not require a modifier. It denotes the number of the level in and in the graphical object Andrew's pitchfork. The numeration of levels starts from zero.</li>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/objectgetdouble")]
        public void Handle_ObjectGetDouble_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, ObjectGetDouble_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> ObjectGetDouble<br>
        /// <b>Description:</b> The function returns the value of the corresponding object property. The object property must be of the<br>
        /// <b>URL:</b> http://docs.mql4.com/objects/objectgetdouble.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>chart_id</b> :  [in] Chart identifier. 0 means the current chart.</li>
        /// <li><b>object_name</b> :  [in] Name of the object.</li>
        /// <li><b>prop_id</b> :  [in] ID of the object property. The value can be one of the values of the enumeration.</li>
        /// <li><b>prop_modifier</b> :  [in] Modifier of the specified property. For the first variant, the default modifier value is equal to 0. Most properties do not require a modifier. It denotes the number of the level in and in the graphical object Andrew's pitchfork. The numeration of levels starts from zero.</li>
        /// </ul>
        /// </summary>
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
        /// <b>Function:</b> ObjectGetInteger<br>
        /// <b>Description:</b> The function returns the value of the corresponding object property. The object property must be of the<br>
        /// <b>URL:</b> http://docs.mql4.com/objects/objectgetinteger.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>chart_id</b> :  [in] Chart identifier. 0 means the current chart.</li>
        /// <li><b>object_name</b> :  [in] Name of the object.</li>
        /// <li><b>prop_id</b> :  [in] ID of the object property. The value can be one of the values of the enumeration.</li>
        /// <li><b>prop_modifier</b> :  [in] Modifier of the specified property. For the first variant, the default modifier value is equal to 0. Most properties do not require a modifier. It denotes the number of the level in and in the graphical object Andrew's pitchfork. The numeration of levels starts from zero.</li>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/objectgetinteger")]
        public void Handle_ObjectGetInteger_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, ObjectGetInteger_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> ObjectGetInteger<br>
        /// <b>Description:</b> The function returns the value of the corresponding object property. The object property must be of the<br>
        /// <b>URL:</b> http://docs.mql4.com/objects/objectgetinteger.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>chart_id</b> :  [in] Chart identifier. 0 means the current chart.</li>
        /// <li><b>object_name</b> :  [in] Name of the object.</li>
        /// <li><b>prop_id</b> :  [in] ID of the object property. The value can be one of the values of the enumeration.</li>
        /// <li><b>prop_modifier</b> :  [in] Modifier of the specified property. For the first variant, the default modifier value is equal to 0. Most properties do not require a modifier. It denotes the number of the level in and in the graphical object Andrew's pitchfork. The numeration of levels starts from zero.</li>
        /// </ul>
        /// </summary>
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
        /// <b>Function:</b> ObjectGetString<br>
        /// <b>Description:</b> The function returns the value of the corresponding object property. The object property must be of the<br>
        /// <b>URL:</b> http://docs.mql4.com/objects/objectgetstring.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>chart_id</b> :  [in] Chart identifier. 0 means the current chart.</li>
        /// <li><b>object_name</b> :  [in] Name of the object.</li>
        /// <li><b>prop_id</b> :  [in] ID of the object property. The value can be one of the values of the enumeration.</li>
        /// <li><b>prop_modifier</b> :  [in] Modifier of the specified property. For the first variant, the default modifier value is equal to 0. Most properties do not require a modifier. It denotes the number of the level in and in the graphical object Andrew's pitchfork. The numeration of levels starts from zero.</li>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/objectgetstring")]
        public void Handle_ObjectGetString_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, ObjectGetString_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> ObjectGetString<br>
        /// <b>Description:</b> The function returns the value of the corresponding object property. The object property must be of the<br>
        /// <b>URL:</b> http://docs.mql4.com/objects/objectgetstring.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>chart_id</b> :  [in] Chart identifier. 0 means the current chart.</li>
        /// <li><b>object_name</b> :  [in] Name of the object.</li>
        /// <li><b>prop_id</b> :  [in] ID of the object property. The value can be one of the values of the enumeration.</li>
        /// <li><b>prop_modifier</b> :  [in] Modifier of the specified property. For the first variant, the default modifier value is equal to 0. Most properties do not require a modifier. It denotes the number of the level in and in the graphical object Andrew's pitchfork. The numeration of levels starts from zero.</li>
        /// </ul>
        /// </summary>
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
        /// <b>Function:</b> ObjectSetDouble<br>
        /// <b>Description:</b> The function sets the value of the corresponding object property. The object property must be of the<br>
        /// <b>URL:</b> http://docs.mql4.com/objects/objectsetdouble.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>chart_id</b> :  [in] Chart identifier. 0 means the current chart.</li>
        /// <li><b>object_name</b> :  [in] Name of the object.</li>
        /// <li><b>prop_id</b> :  [in] ID of the object property. The value can be one of the values of the enumeration.</li>
        /// <li><b>prop_value</b> :  [in] The value of the property.</li>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/objectsetdouble")]
        public void Handle_ObjectSetDouble_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, ObjectSetDouble_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> ObjectSetDouble<br>
        /// <b>Description:</b> The function sets the value of the corresponding object property. The object property must be of the<br>
        /// <b>URL:</b> http://docs.mql4.com/objects/objectsetdouble.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>chart_id</b> :  [in] Chart identifier. 0 means the current chart.</li>
        /// <li><b>object_name</b> :  [in] Name of the object.</li>
        /// <li><b>prop_id</b> :  [in] ID of the object property. The value can be one of the values of the enumeration.</li>
        /// <li><b>prop_value</b> :  [in] The value of the property.</li>
        /// </ul>
        /// </summary>
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
        /// <b>Function:</b> ObjectSetDouble<br>
        /// <b>Description:</b> The function sets the value of the corresponding object property. The object property must be of the<br>
        /// <b>URL:</b> http://docs.mql4.com/objects/objectsetdouble.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>chart_id</b> :  [in] Chart identifier. 0 means the current chart.</li>
        /// <li><b>object_name</b> :  [in] Name of the object.</li>
        /// <li><b>prop_id</b> :  [in] ID of the object property. The value can be one of the values of the enumeration.</li>
        /// <li><b>prop_modifier</b> :  [in] Modifier of the specified property. It denotes the number of the level in and in the graphical object Andrew's pitchfork. The numeration of levels starts from zero.</li>
        /// <li><b>prop_value</b> :  [in] The value of the property.</li>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/objectsetdouble")]
        public void Handle_ObjectSetDouble_2(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, ObjectSetDouble_2(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> ObjectSetDouble<br>
        /// <b>Description:</b> The function sets the value of the corresponding object property. The object property must be of the<br>
        /// <b>URL:</b> http://docs.mql4.com/objects/objectsetdouble.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>chart_id</b> :  [in] Chart identifier. 0 means the current chart.</li>
        /// <li><b>object_name</b> :  [in] Name of the object.</li>
        /// <li><b>prop_id</b> :  [in] ID of the object property. The value can be one of the values of the enumeration.</li>
        /// <li><b>prop_modifier</b> :  [in] Modifier of the specified property. It denotes the number of the level in and in the graphical object Andrew's pitchfork. The numeration of levels starts from zero.</li>
        /// <li><b>prop_value</b> :  [in] The value of the property.</li>
        /// </ul>
        /// </summary>
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
        /// <b>Function:</b> ObjectSetInteger<br>
        /// <b>Description:</b> The function sets the value of the corresponding object property. The object property must be of the<br>
        /// <b>URL:</b> http://docs.mql4.com/objects/objectsetinteger.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>chart_id</b> :  [in] Chart identifier. 0 means the current chart.</li>
        /// <li><b>object_name</b> :  [in] Name of the object.</li>
        /// <li><b>prop_id</b> :  [in] ID of the object property. The value can be one of the values of the enumeration.</li>
        /// <li><b>prop_value</b> :  [in] The value of the property.</li>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/objectsetinteger")]
        public void Handle_ObjectSetInteger_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, ObjectSetInteger_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> ObjectSetInteger<br>
        /// <b>Description:</b> The function sets the value of the corresponding object property. The object property must be of the<br>
        /// <b>URL:</b> http://docs.mql4.com/objects/objectsetinteger.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>chart_id</b> :  [in] Chart identifier. 0 means the current chart.</li>
        /// <li><b>object_name</b> :  [in] Name of the object.</li>
        /// <li><b>prop_id</b> :  [in] ID of the object property. The value can be one of the values of the enumeration.</li>
        /// <li><b>prop_value</b> :  [in] The value of the property.</li>
        /// </ul>
        /// </summary>
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
        /// <b>Function:</b> ObjectSetInteger<br>
        /// <b>Description:</b> The function sets the value of the corresponding object property. The object property must be of the<br>
        /// <b>URL:</b> http://docs.mql4.com/objects/objectsetinteger.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>chart_id</b> :  [in] Chart identifier. 0 means the current chart.</li>
        /// <li><b>object_name</b> :  [in] Name of the object.</li>
        /// <li><b>prop_id</b> :  [in] ID of the object property. The value can be one of the values of the enumeration.</li>
        /// <li><b>prop_modifier</b> :  [in] Modifier of the specified property. It denotes the number of the level in and in the graphical object Andrew's pitchfork. The numeration of levels starts from zero.</li>
        /// <li><b>prop_value</b> :  [in] The value of the property.</li>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/objectsetinteger")]
        public void Handle_ObjectSetInteger_2(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, ObjectSetInteger_2(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> ObjectSetInteger<br>
        /// <b>Description:</b> The function sets the value of the corresponding object property. The object property must be of the<br>
        /// <b>URL:</b> http://docs.mql4.com/objects/objectsetinteger.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>chart_id</b> :  [in] Chart identifier. 0 means the current chart.</li>
        /// <li><b>object_name</b> :  [in] Name of the object.</li>
        /// <li><b>prop_id</b> :  [in] ID of the object property. The value can be one of the values of the enumeration.</li>
        /// <li><b>prop_modifier</b> :  [in] Modifier of the specified property. It denotes the number of the level in and in the graphical object Andrew's pitchfork. The numeration of levels starts from zero.</li>
        /// <li><b>prop_value</b> :  [in] The value of the property.</li>
        /// </ul>
        /// </summary>
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
        /// <b>Function:</b> ObjectSetString<br>
        /// <b>Description:</b> The function sets the value of the corresponding object property. The object property must be of the<br>
        /// <b>URL:</b> http://docs.mql4.com/objects/objectsetstring.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>chart_id</b> :  [in] Chart identifier. 0 means the current chart.</li>
        /// <li><b>object_name</b> :  [in] Name of the object.</li>
        /// <li><b>prop_id</b> :  [in] ID of the object property. The value can be one of the values of the enumeration.</li>
        /// <li><b>prop_value</b> :  [in] The value of the property.</li>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/objectsetstring")]
        public void Handle_ObjectSetString_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, ObjectSetString_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> ObjectSetString<br>
        /// <b>Description:</b> The function sets the value of the corresponding object property. The object property must be of the<br>
        /// <b>URL:</b> http://docs.mql4.com/objects/objectsetstring.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>chart_id</b> :  [in] Chart identifier. 0 means the current chart.</li>
        /// <li><b>object_name</b> :  [in] Name of the object.</li>
        /// <li><b>prop_id</b> :  [in] ID of the object property. The value can be one of the values of the enumeration.</li>
        /// <li><b>prop_value</b> :  [in] The value of the property.</li>
        /// </ul>
        /// </summary>
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
        /// <b>Function:</b> ObjectSetString<br>
        /// <b>Description:</b> The function sets the value of the corresponding object property. The object property must be of the<br>
        /// <b>URL:</b> http://docs.mql4.com/objects/objectsetstring.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>chart_id</b> :  [in] Chart identifier. 0 means the current chart.</li>
        /// <li><b>object_name</b> :  [in] Name of the object.</li>
        /// <li><b>prop_id</b> :  [in] ID of the object property. The value can be one of the values of the enumeration.</li>
        /// <li><b>prop_modifier</b> :  [in] Modifier of the specified property. It denotes the number of the level in and in the graphical object Andrew's pitchfork. The numeration of levels starts from zero.</li>
        /// <li><b>prop_value</b> :  [in] The value of the property.</li>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/objectsetstring")]
        public void Handle_ObjectSetString_2(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, ObjectSetString_2(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> ObjectSetString<br>
        /// <b>Description:</b> The function sets the value of the corresponding object property. The object property must be of the<br>
        /// <b>URL:</b> http://docs.mql4.com/objects/objectsetstring.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>chart_id</b> :  [in] Chart identifier. 0 means the current chart.</li>
        /// <li><b>object_name</b> :  [in] Name of the object.</li>
        /// <li><b>prop_id</b> :  [in] ID of the object property. The value can be one of the values of the enumeration.</li>
        /// <li><b>prop_modifier</b> :  [in] Modifier of the specified property. It denotes the number of the level in and in the graphical object Andrew's pitchfork. The numeration of levels starts from zero.</li>
        /// <li><b>prop_value</b> :  [in] The value of the property.</li>
        /// </ul>
        /// </summary>
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
        /// <b>Function:</b> TextSetFont<br>
        /// <b>Description:</b> The function sets the font for displaying the text using drawing methods and returns the result of that operation. Arial font with the size -120 (12 pt) is used by default.<br>
        /// <b>URL:</b> http://docs.mql4.com/objects/textsetfont.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>name</b> :  [in] Font name in the system or the name of the resource containing the font or the path to font file on the disk.</li>
        /// <li><b>size</b> :  [in] The font size that can be set using positive and negative values. In case of positive values, the size of a displayed text does not depend on the operating system's font size settings. In case of negative values, the value is set in tenths of a point and the text size depends on the operating system settings ("standard scale" or "large scale"). See the Note below for more information about the differences between the modes.</li>
        /// <li><b>flags</b> :  [in] Combination of describing font style.</li>
        /// <li><b>orientation</b> :  [in] Text's horizontal inclination to X axis, the unit of measurement is 0.1 degrees. It means that orientation=450 stands for inclination equal to 45 degrees.</li>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/textsetfont")]
        public void Handle_TextSetFont_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, TextSetFont_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> TextSetFont<br>
        /// <b>Description:</b> The function sets the font for displaying the text using drawing methods and returns the result of that operation. Arial font with the size -120 (12 pt) is used by default.<br>
        /// <b>URL:</b> http://docs.mql4.com/objects/textsetfont.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>name</b> :  [in] Font name in the system or the name of the resource containing the font or the path to font file on the disk.</li>
        /// <li><b>size</b> :  [in] The font size that can be set using positive and negative values. In case of positive values, the size of a displayed text does not depend on the operating system's font size settings. In case of negative values, the value is set in tenths of a point and the text size depends on the operating system settings ("standard scale" or "large scale"). See the Note below for more information about the differences between the modes.</li>
        /// <li><b>flags</b> :  [in] Combination of describing font style.</li>
        /// <li><b>orientation</b> :  [in] Text's horizontal inclination to X axis, the unit of measurement is 0.1 degrees. It means that orientation=450 stands for inclination equal to 45 degrees.</li>
        /// </ul>
        /// </summary>
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
        /// <b>Function:</b> ObjectDescription<br>
        /// <b>Description:</b> Returns the object description.<br>
        /// <b>URL:</b> http://docs.mql4.com/objects/objectdescription.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>object_name</b> :  [in] Object name.</li>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/objectdescription")]
        public void Handle_ObjectDescription_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, ObjectDescription_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> ObjectDescription<br>
        /// <b>Description:</b> Returns the object description.<br>
        /// <b>URL:</b> http://docs.mql4.com/objects/objectdescription.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>object_name</b> :  [in] Object name.</li>
        /// </ul>
        /// </summary>
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
        /// <b>Function:</b> ObjectGet<br>
        /// <b>Description:</b> Returns the value of the specified object property.<br>
        /// <b>URL:</b> http://docs.mql4.com/objects/objectget.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>object_name</b> :  [in] Object name.</li>
        /// <li><b>index</b> :  [in] Object property index. It can be any of the enumeration values.</li>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/objectget")]
        public void Handle_ObjectGet_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, ObjectGet_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> ObjectGet<br>
        /// <b>Description:</b> Returns the value of the specified object property.<br>
        /// <b>URL:</b> http://docs.mql4.com/objects/objectget.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>object_name</b> :  [in] Object name.</li>
        /// <li><b>index</b> :  [in] Object property index. It can be any of the enumeration values.</li>
        /// </ul>
        /// </summary>
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
        /// <b>Function:</b> ObjectGetFiboDescription<br>
        /// <b>Description:</b> Returns the level description of a Fibonacci object.<br>
        /// <b>URL:</b> http://docs.mql4.com/objects/objectgetfibodescription.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>object_name</b> :  [in] Fibonacci object name.</li>
        /// <li><b>index</b> :  [in] Index of the Fibonacci level (0-31).</li>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/objectgetfibodescription")]
        public void Handle_ObjectGetFiboDescription_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, ObjectGetFiboDescription_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> ObjectGetFiboDescription<br>
        /// <b>Description:</b> Returns the level description of a Fibonacci object.<br>
        /// <b>URL:</b> http://docs.mql4.com/objects/objectgetfibodescription.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>object_name</b> :  [in] Fibonacci object name.</li>
        /// <li><b>index</b> :  [in] Index of the Fibonacci level (0-31).</li>
        /// </ul>
        /// </summary>
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
        /// <b>Function:</b> ObjectGetShiftByValue<br>
        /// <b>Description:</b> The function calculates and returns bar index (shift related to the current bar) for the given price.<br>
        /// <b>URL:</b> http://docs.mql4.com/objects/objectgetshiftbyvalue.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>object_name</b> :  [in] Object name.</li>
        /// <li><b>value</b> :  [in] Price value.</li>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/objectgetshiftbyvalue")]
        public void Handle_ObjectGetShiftByValue_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, ObjectGetShiftByValue_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> ObjectGetShiftByValue<br>
        /// <b>Description:</b> The function calculates and returns bar index (shift related to the current bar) for the given price.<br>
        /// <b>URL:</b> http://docs.mql4.com/objects/objectgetshiftbyvalue.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>object_name</b> :  [in] Object name.</li>
        /// <li><b>value</b> :  [in] Price value.</li>
        /// </ul>
        /// </summary>
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
        /// <b>Function:</b> ObjectGetValueByShift<br>
        /// <b>Description:</b> The function calculates and returns the price value for the specified bar (shift related to the current bar).<br>
        /// <b>URL:</b> http://docs.mql4.com/objects/objectgetvaluebyshift.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>object_name</b> :  [in] Object name.</li>
        /// <li><b>shift</b> :  [in] Bar index.</li>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/objectgetvaluebyshift")]
        public void Handle_ObjectGetValueByShift_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, ObjectGetValueByShift_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> ObjectGetValueByShift<br>
        /// <b>Description:</b> The function calculates and returns the price value for the specified bar (shift related to the current bar).<br>
        /// <b>URL:</b> http://docs.mql4.com/objects/objectgetvaluebyshift.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>object_name</b> :  [in] Object name.</li>
        /// <li><b>shift</b> :  [in] Bar index.</li>
        /// </ul>
        /// </summary>
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
        /// <b>Function:</b> ObjectSet<br>
        /// <b>Description:</b> Changes the value of the specified object property.<br>
        /// <b>URL:</b> http://docs.mql4.com/objects/objectset.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>object_name</b> :  [in] Object name.</li>
        /// <li><b>index</b> :  [in] Object property index. It can be any of enumeration values.</li>
        /// <li><b>value</b> :  [in] New value of the given property.</li>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/objectset")]
        public void Handle_ObjectSet_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, ObjectSet_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> ObjectSet<br>
        /// <b>Description:</b> Changes the value of the specified object property.<br>
        /// <b>URL:</b> http://docs.mql4.com/objects/objectset.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>object_name</b> :  [in] Object name.</li>
        /// <li><b>index</b> :  [in] Object property index. It can be any of enumeration values.</li>
        /// <li><b>value</b> :  [in] New value of the given property.</li>
        /// </ul>
        /// </summary>
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
        /// <b>Function:</b> ObjectSetFiboDescription<br>
        /// <b>Description:</b> The function sets a new description to a level of a Fibonacci object.<br>
        /// <b>URL:</b> http://docs.mql4.com/objects/objectsetfibodescription.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>object_name</b> :  [in] Object name.</li>
        /// <li><b>index</b> :  [in] Index of the Fibonacci level (0-31).</li>
        /// <li><b>text</b> :  [in] New description of the level.</li>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/objectsetfibodescription")]
        public void Handle_ObjectSetFiboDescription_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, ObjectSetFiboDescription_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> ObjectSetFiboDescription<br>
        /// <b>Description:</b> The function sets a new description to a level of a Fibonacci object.<br>
        /// <b>URL:</b> http://docs.mql4.com/objects/objectsetfibodescription.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>object_name</b> :  [in] Object name.</li>
        /// <li><b>index</b> :  [in] Index of the Fibonacci level (0-31).</li>
        /// <li><b>text</b> :  [in] New description of the level.</li>
        /// </ul>
        /// </summary>
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
        /// <b>Function:</b> ObjectSetText<br>
        /// <b>Description:</b> The function c<br>
        /// <b>URL:</b> http://docs.mql4.com/objects/objectsettext.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>object_name</b> :  [in] Object name.</li>
        /// <li><b>text</b> :  [in] A text describing the object.</li>
        /// <li><b>font_size</b> :  [in] Font size in points.</li>
        /// <li><b>font_name</b> :  [in] Font name.</li>
        /// <li><b>text_color</b> :  [in] Font color.</li>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/objectsettext")]
        public void Handle_ObjectSetText_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, ObjectSetText_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> ObjectSetText<br>
        /// <b>Description:</b> The function c<br>
        /// <b>URL:</b> http://docs.mql4.com/objects/objectsettext.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>object_name</b> :  [in] Object name.</li>
        /// <li><b>text</b> :  [in] A text describing the object.</li>
        /// <li><b>font_size</b> :  [in] Font size in points.</li>
        /// <li><b>font_name</b> :  [in] Font name.</li>
        /// <li><b>text_color</b> :  [in] Font color.</li>
        /// </ul>
        /// </summary>
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
        /// <b>Function:</b> ObjectType<br>
        /// <b>Description:</b> The function returns the object type value.<br>
        /// <b>URL:</b> http://docs.mql4.com/objects/objecttype.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>object_name</b> :  [in] Object name.</li>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/objecttype")]
        public void Handle_ObjectType_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, ObjectType_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> ObjectType<br>
        /// <b>Description:</b> The function returns the object type value.<br>
        /// <b>URL:</b> http://docs.mql4.com/objects/objecttype.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>object_name</b> :  [in] Object name.</li>
        /// </ul>
        /// </summary>
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
        /// <b>Function:</b> iAC<br>
        /// <b>Description:</b> Calculates the Bill Williams' Accelerator/Decelerator oscillator and returns its value.<br>
        /// <b>URL:</b> http://docs.mql4.com/indicators/iac.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</li>
        /// <li><b>timeframe</b> :  [in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</li>
        /// <li><b>shift</b> :  [in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</li>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/iac")]
        public void Handle_iAC_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, iAC_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> iAC<br>
        /// <b>Description:</b> Calculates the Bill Williams' Accelerator/Decelerator oscillator and returns its value.<br>
        /// <b>URL:</b> http://docs.mql4.com/indicators/iac.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</li>
        /// <li><b>timeframe</b> :  [in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</li>
        /// <li><b>shift</b> :  [in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</li>
        /// </ul>
        /// </summary>
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
        /// <b>Function:</b> iAD<br>
        /// <b>Description:</b> Calculates the Accumulation/Distribution indicator and returns its value.<br>
        /// <b>URL:</b> http://docs.mql4.com/indicators/iad.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</li>
        /// <li><b>timeframe</b> :  [in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</li>
        /// <li><b>shift</b> :  [in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</li>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/iad")]
        public void Handle_iAD_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, iAD_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> iAD<br>
        /// <b>Description:</b> Calculates the Accumulation/Distribution indicator and returns its value.<br>
        /// <b>URL:</b> http://docs.mql4.com/indicators/iad.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</li>
        /// <li><b>timeframe</b> :  [in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</li>
        /// <li><b>shift</b> :  [in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</li>
        /// </ul>
        /// </summary>
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
        /// <b>Function:</b> iADX<br>
        /// <b>Description:</b> Calculates the Average Directional Movement Index indicator and returns its value.<br>
        /// <b>URL:</b> http://docs.mql4.com/indicators/iadx.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</li>
        /// <li><b>timeframe</b> :  [in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</li>
        /// <li><b>period</b> :  [in] Averaging period for calculation.</li>
        /// <li><b>applied_price</b> :  [in] Applied price. It can be any of enumeration values.</li>
        /// <li><b>mode</b> :  [in] Indicator line index. It can be any of the enumeration value. (0 - MODE_MAIN, 1 - MODE_PLUSDI, 2 - MODE_MINUSDI).</li>
        /// <li><b>shift</b> :  [in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</li>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/iadx")]
        public void Handle_iADX_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, iADX_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> iADX<br>
        /// <b>Description:</b> Calculates the Average Directional Movement Index indicator and returns its value.<br>
        /// <b>URL:</b> http://docs.mql4.com/indicators/iadx.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</li>
        /// <li><b>timeframe</b> :  [in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</li>
        /// <li><b>period</b> :  [in] Averaging period for calculation.</li>
        /// <li><b>applied_price</b> :  [in] Applied price. It can be any of enumeration values.</li>
        /// <li><b>mode</b> :  [in] Indicator line index. It can be any of the enumeration value. (0 - MODE_MAIN, 1 - MODE_PLUSDI, 2 - MODE_MINUSDI).</li>
        /// <li><b>shift</b> :  [in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</li>
        /// </ul>
        /// </summary>
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
        /// <b>Function:</b> iAlligator<br>
        /// <b>Description:</b> Calculates the Alligator indicator and returns its value.<br>
        /// <b>URL:</b> http://docs.mql4.com/indicators/ialligator.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</li>
        /// <li><b>timeframe</b> :  [in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</li>
        /// <li><b>jaw_period</b> :  [in] Blue line averaging period (Alligator's Jaw).</li>
        /// <li><b>jaw_shift</b> :  [in] Blue line shift relative to the chart.</li>
        /// <li><b>teeth_period</b> :  [in] Red line averaging period (Alligator's Teeth).</li>
        /// <li><b>teeth_shift</b> :  [in] Red line shift relative to the chart.</li>
        /// <li><b>lips_period</b> :  [in] Green line averaging period (Alligator's Lips).</li>
        /// <li><b>lips_shift</b> :  [in] Green line shift relative to the chart.</li>
        /// <li><b>ma_method</b> :  [in] MA method. It can be any of Moving Average methods. It can be any of enumeration values.</li>
        /// <li><b>applied_price</b> :  [in] Applied price. It can be any of enumeration values.</li>
        /// <li><b>mode</b> :  [in] Data source, identifier of the . It can be any of the following values:</li>
        /// <li><b>shift</b> :  MODE_GATORJAW - Gator Jaw (blue) balance line,MODE_GATORTEETH - Gator Teeth (red) balance line,MODE_GATORLIPS - Gator Lips (green) balance line.</li>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/ialligator")]
        public void Handle_iAlligator_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, iAlligator_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> iAlligator<br>
        /// <b>Description:</b> Calculates the Alligator indicator and returns its value.<br>
        /// <b>URL:</b> http://docs.mql4.com/indicators/ialligator.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</li>
        /// <li><b>timeframe</b> :  [in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</li>
        /// <li><b>jaw_period</b> :  [in] Blue line averaging period (Alligator's Jaw).</li>
        /// <li><b>jaw_shift</b> :  [in] Blue line shift relative to the chart.</li>
        /// <li><b>teeth_period</b> :  [in] Red line averaging period (Alligator's Teeth).</li>
        /// <li><b>teeth_shift</b> :  [in] Red line shift relative to the chart.</li>
        /// <li><b>lips_period</b> :  [in] Green line averaging period (Alligator's Lips).</li>
        /// <li><b>lips_shift</b> :  [in] Green line shift relative to the chart.</li>
        /// <li><b>ma_method</b> :  [in] MA method. It can be any of Moving Average methods. It can be any of enumeration values.</li>
        /// <li><b>applied_price</b> :  [in] Applied price. It can be any of enumeration values.</li>
        /// <li><b>mode</b> :  [in] Data source, identifier of the . It can be any of the following values:</li>
        /// <li><b>shift</b> :  MODE_GATORJAW - Gator Jaw (blue) balance line,MODE_GATORTEETH - Gator Teeth (red) balance line,MODE_GATORLIPS - Gator Lips (green) balance line.</li>
        /// </ul>
        /// </summary>
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
        /// <b>Function:</b> iAO<br>
        /// <b>Description:</b> Calculates the Awesome oscillator and returns its value.<br>
        /// <b>URL:</b> http://docs.mql4.com/indicators/iao.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</li>
        /// <li><b>timeframe</b> :  [in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</li>
        /// <li><b>shift</b> :  [in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</li>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/iao")]
        public void Handle_iAO_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, iAO_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> iAO<br>
        /// <b>Description:</b> Calculates the Awesome oscillator and returns its value.<br>
        /// <b>URL:</b> http://docs.mql4.com/indicators/iao.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</li>
        /// <li><b>timeframe</b> :  [in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</li>
        /// <li><b>shift</b> :  [in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</li>
        /// </ul>
        /// </summary>
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
        /// <b>Function:</b> iATR<br>
        /// <b>Description:</b> Calculates the Average True Range indicator and returns its value.<br>
        /// <b>URL:</b> http://docs.mql4.com/indicators/iatr.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</li>
        /// <li><b>timeframe</b> :  [in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</li>
        /// <li><b>period</b> :  [in] Averaging period.</li>
        /// <li><b>shift</b> :  [in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</li>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/iatr")]
        public void Handle_iATR_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, iATR_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> iATR<br>
        /// <b>Description:</b> Calculates the Average True Range indicator and returns its value.<br>
        /// <b>URL:</b> http://docs.mql4.com/indicators/iatr.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</li>
        /// <li><b>timeframe</b> :  [in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</li>
        /// <li><b>period</b> :  [in] Averaging period.</li>
        /// <li><b>shift</b> :  [in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</li>
        /// </ul>
        /// </summary>
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
        /// <b>Function:</b> iBearsPower<br>
        /// <b>Description:</b> Calculates the Bears Power indicator and returns its value.<br>
        /// <b>URL:</b> http://docs.mql4.com/indicators/ibearspower.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</li>
        /// <li><b>timeframe</b> :  [in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</li>
        /// <li><b>period</b> :  [in] Averaging period.</li>
        /// <li><b>applied_price</b> :  [in] Applied price. It can be any of enumeration values.</li>
        /// <li><b>shift</b> :  [in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</li>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/ibearspower")]
        public void Handle_iBearsPower_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, iBearsPower_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> iBearsPower<br>
        /// <b>Description:</b> Calculates the Bears Power indicator and returns its value.<br>
        /// <b>URL:</b> http://docs.mql4.com/indicators/ibearspower.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</li>
        /// <li><b>timeframe</b> :  [in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</li>
        /// <li><b>period</b> :  [in] Averaging period.</li>
        /// <li><b>applied_price</b> :  [in] Applied price. It can be any of enumeration values.</li>
        /// <li><b>shift</b> :  [in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</li>
        /// </ul>
        /// </summary>
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
        /// <b>Function:</b> iBands<br>
        /// <b>Description:</b> Calculates the Bollinger Bands indicator and returns its value.<br>
        /// <b>URL:</b> http://docs.mql4.com/indicators/ibands.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</li>
        /// <li><b>timeframe</b> :  [in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</li>
        /// <li><b>period</b> :  [in] Averaging period to calculate the main line.</li>
        /// <li><b>deviation</b> :  [in] Number of standard deviations from the main line.</li>
        /// <li><b>bands_shift</b> :  [in] The indicator shift relative to the chart.</li>
        /// <li><b>applied_price</b> :  [in] Applied price. It can be any of enumeration values.</li>
        /// <li><b>mode</b> :  [in] Indicator line index. It can be any of the enumeration value (0 - MODE_MAIN, 1 - MODE_UPPER, 2 - MODE_LOWER).</li>
        /// <li><b>shift</b> :  [in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</li>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/ibands")]
        public void Handle_iBands_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, iBands_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> iBands<br>
        /// <b>Description:</b> Calculates the Bollinger Bands indicator and returns its value.<br>
        /// <b>URL:</b> http://docs.mql4.com/indicators/ibands.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</li>
        /// <li><b>timeframe</b> :  [in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</li>
        /// <li><b>period</b> :  [in] Averaging period to calculate the main line.</li>
        /// <li><b>deviation</b> :  [in] Number of standard deviations from the main line.</li>
        /// <li><b>bands_shift</b> :  [in] The indicator shift relative to the chart.</li>
        /// <li><b>applied_price</b> :  [in] Applied price. It can be any of enumeration values.</li>
        /// <li><b>mode</b> :  [in] Indicator line index. It can be any of the enumeration value (0 - MODE_MAIN, 1 - MODE_UPPER, 2 - MODE_LOWER).</li>
        /// <li><b>shift</b> :  [in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</li>
        /// </ul>
        /// </summary>
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
        /// <b>Function:</b> iBullsPower<br>
        /// <b>Description:</b> Calculates the Bulls Power indicator and returns its value.<br>
        /// <b>URL:</b> http://docs.mql4.com/indicators/ibullspower.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</li>
        /// <li><b>timeframe</b> :  [in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</li>
        /// <li><b>period</b> :  [in] Averaging period for calculation.</li>
        /// <li><b>applied_price</b> :  [in] Applied price. It can be any of enumeration values.</li>
        /// <li><b>shift</b> :  [in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</li>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/ibullspower")]
        public void Handle_iBullsPower_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, iBullsPower_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> iBullsPower<br>
        /// <b>Description:</b> Calculates the Bulls Power indicator and returns its value.<br>
        /// <b>URL:</b> http://docs.mql4.com/indicators/ibullspower.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</li>
        /// <li><b>timeframe</b> :  [in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</li>
        /// <li><b>period</b> :  [in] Averaging period for calculation.</li>
        /// <li><b>applied_price</b> :  [in] Applied price. It can be any of enumeration values.</li>
        /// <li><b>shift</b> :  [in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</li>
        /// </ul>
        /// </summary>
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
        /// <b>Function:</b> iCCI<br>
        /// <b>Description:</b> Calculates the Commodity Channel Index indicator and returns its value.<br>
        /// <b>URL:</b> http://docs.mql4.com/indicators/icci.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</li>
        /// <li><b>timeframe</b> :  [in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</li>
        /// <li><b>period</b> :  [in] Averaging period for calculation.</li>
        /// <li><b>applied_price</b> :  [in] Applied price. It can be any of enumeration values.</li>
        /// <li><b>shift</b> :  [in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</li>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/icci")]
        public void Handle_iCCI_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, iCCI_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> iCCI<br>
        /// <b>Description:</b> Calculates the Commodity Channel Index indicator and returns its value.<br>
        /// <b>URL:</b> http://docs.mql4.com/indicators/icci.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</li>
        /// <li><b>timeframe</b> :  [in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</li>
        /// <li><b>period</b> :  [in] Averaging period for calculation.</li>
        /// <li><b>applied_price</b> :  [in] Applied price. It can be any of enumeration values.</li>
        /// <li><b>shift</b> :  [in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</li>
        /// </ul>
        /// </summary>
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
        /// <b>Function:</b> iDeMarker<br>
        /// <b>Description:</b> Calculates the DeMarker indicator and returns its value.<br>
        /// <b>URL:</b> http://docs.mql4.com/indicators/idemarker.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</li>
        /// <li><b>timeframe</b> :  [in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</li>
        /// <li><b>period</b> :  [in] Averaging period for calculation.</li>
        /// <li><b>shift</b> :  [in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</li>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/idemarker")]
        public void Handle_iDeMarker_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, iDeMarker_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> iDeMarker<br>
        /// <b>Description:</b> Calculates the DeMarker indicator and returns its value.<br>
        /// <b>URL:</b> http://docs.mql4.com/indicators/idemarker.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</li>
        /// <li><b>timeframe</b> :  [in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</li>
        /// <li><b>period</b> :  [in] Averaging period for calculation.</li>
        /// <li><b>shift</b> :  [in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</li>
        /// </ul>
        /// </summary>
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
        /// <b>Function:</b> iEnvelopes<br>
        /// <b>Description:</b> Calculates the Envelopes indicator and returns its value.<br>
        /// <b>URL:</b> http://docs.mql4.com/indicators/ienvelopes.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</li>
        /// <li><b>timeframe</b> :  [in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</li>
        /// <li><b>ma_period</b> :  [in] Averaging period for calculation of the main line.</li>
        /// <li><b>ma_method</b> :  [in] Moving Average method. It can be any of enumeration values.</li>
        /// <li><b>ma_shift</b> :  [in] MA shift. Indicator line offset relate to the chart by timeframe.</li>
        /// <li><b>applied_price</b> :  [in] Applied price. It can be any of enumeration values.</li>
        /// <li><b>deviation</b> :  [in] Percent deviation from the main line.</li>
        /// <li><b>mode</b> :  [in] Indicator line index. It can be any of enumeration value (0 - MODE_MAIN, 1 - MODE_UPPER, 2 - MODE_LOWER).</li>
        /// <li><b>shift</b> :  [in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</li>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/ienvelopes")]
        public void Handle_iEnvelopes_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, iEnvelopes_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> iEnvelopes<br>
        /// <b>Description:</b> Calculates the Envelopes indicator and returns its value.<br>
        /// <b>URL:</b> http://docs.mql4.com/indicators/ienvelopes.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</li>
        /// <li><b>timeframe</b> :  [in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</li>
        /// <li><b>ma_period</b> :  [in] Averaging period for calculation of the main line.</li>
        /// <li><b>ma_method</b> :  [in] Moving Average method. It can be any of enumeration values.</li>
        /// <li><b>ma_shift</b> :  [in] MA shift. Indicator line offset relate to the chart by timeframe.</li>
        /// <li><b>applied_price</b> :  [in] Applied price. It can be any of enumeration values.</li>
        /// <li><b>deviation</b> :  [in] Percent deviation from the main line.</li>
        /// <li><b>mode</b> :  [in] Indicator line index. It can be any of enumeration value (0 - MODE_MAIN, 1 - MODE_UPPER, 2 - MODE_LOWER).</li>
        /// <li><b>shift</b> :  [in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</li>
        /// </ul>
        /// </summary>
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
        /// <b>Function:</b> iForce<br>
        /// <b>Description:</b> Calculates the Force Index indicator and returns its value.<br>
        /// <b>URL:</b> http://docs.mql4.com/indicators/iforce.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</li>
        /// <li><b>timeframe</b> :  [in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</li>
        /// <li><b>period</b> :  [in] Averaging period for calculation.</li>
        /// <li><b>ma_method</b> :  [in] Moving Average method. It can be any of enumeration values.</li>
        /// <li><b>applied_price</b> :  [in] Applied price. It can be any of enumeration values.</li>
        /// <li><b>shift</b> :  [in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</li>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/iforce")]
        public void Handle_iForce_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, iForce_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> iForce<br>
        /// <b>Description:</b> Calculates the Force Index indicator and returns its value.<br>
        /// <b>URL:</b> http://docs.mql4.com/indicators/iforce.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</li>
        /// <li><b>timeframe</b> :  [in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</li>
        /// <li><b>period</b> :  [in] Averaging period for calculation.</li>
        /// <li><b>ma_method</b> :  [in] Moving Average method. It can be any of enumeration values.</li>
        /// <li><b>applied_price</b> :  [in] Applied price. It can be any of enumeration values.</li>
        /// <li><b>shift</b> :  [in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</li>
        /// </ul>
        /// </summary>
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
        /// <b>Function:</b> iFractals<br>
        /// <b>Description:</b> Calculates the Fractals indicator and returns its value.<br>
        /// <b>URL:</b> http://docs.mql4.com/indicators/ifractals.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</li>
        /// <li><b>timeframe</b> :  [in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</li>
        /// <li><b>mode</b> :  [in] Indicator line index. It can be any of the enumeration value.</li>
        /// <li><b>shift</b> :  [in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</li>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/ifractals")]
        public void Handle_iFractals_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, iFractals_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> iFractals<br>
        /// <b>Description:</b> Calculates the Fractals indicator and returns its value.<br>
        /// <b>URL:</b> http://docs.mql4.com/indicators/ifractals.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</li>
        /// <li><b>timeframe</b> :  [in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</li>
        /// <li><b>mode</b> :  [in] Indicator line index. It can be any of the enumeration value.</li>
        /// <li><b>shift</b> :  [in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</li>
        /// </ul>
        /// </summary>
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
        /// <b>Function:</b> iGator<br>
        /// <b>Description:</b> Calculates the Gator oscillator and returns its value.<br>
        /// <b>URL:</b> http://docs.mql4.com/indicators/igator.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</li>
        /// <li><b>timeframe</b> :  [in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</li>
        /// <li><b>jaw_period</b> :  [in] Blue line averaging period (Alligator's Jaw).</li>
        /// <li><b>jaw_shift</b> :  [in] Blue line shift relative to the chart.</li>
        /// <li><b>teeth_period</b> :  [in] Red line averaging period (Alligator's Teeth).</li>
        /// <li><b>teeth_shift</b> :  [in] Red line shift relative to the chart.</li>
        /// <li><b>lips_period</b> :  [in] Green line averaging period (Alligator's Lips).</li>
        /// <li><b>lips_shift</b> :  [in] Green line shift relative to the chart.</li>
        /// <li><b>ma_method</b> :  [in] MA method. It can be any of enumeration value.</li>
        /// <li><b>applied_price</b> :  [in] Applied price. It can be any of enumeration values.</li>
        /// <li><b>mode</b> :  [in] Indicator line index. It can be any of enumeration value.</li>
        /// <li><b>shift</b> :  MODE_GATORJAW - blue line (Jaw line),MODE_GATORTEETH - red line (Teeth line),MODE_GATORLIPS - green line (Lips line).</li>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/igator")]
        public void Handle_iGator_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, iGator_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> iGator<br>
        /// <b>Description:</b> Calculates the Gator oscillator and returns its value.<br>
        /// <b>URL:</b> http://docs.mql4.com/indicators/igator.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</li>
        /// <li><b>timeframe</b> :  [in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</li>
        /// <li><b>jaw_period</b> :  [in] Blue line averaging period (Alligator's Jaw).</li>
        /// <li><b>jaw_shift</b> :  [in] Blue line shift relative to the chart.</li>
        /// <li><b>teeth_period</b> :  [in] Red line averaging period (Alligator's Teeth).</li>
        /// <li><b>teeth_shift</b> :  [in] Red line shift relative to the chart.</li>
        /// <li><b>lips_period</b> :  [in] Green line averaging period (Alligator's Lips).</li>
        /// <li><b>lips_shift</b> :  [in] Green line shift relative to the chart.</li>
        /// <li><b>ma_method</b> :  [in] MA method. It can be any of enumeration value.</li>
        /// <li><b>applied_price</b> :  [in] Applied price. It can be any of enumeration values.</li>
        /// <li><b>mode</b> :  [in] Indicator line index. It can be any of enumeration value.</li>
        /// <li><b>shift</b> :  MODE_GATORJAW - blue line (Jaw line),MODE_GATORTEETH - red line (Teeth line),MODE_GATORLIPS - green line (Lips line).</li>
        /// </ul>
        /// </summary>
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
        /// <b>Function:</b> iIchimoku<br>
        /// <b>Description:</b> Calculates the Ichimoku Kinko Hyo indicator and returns its value.<br>
        /// <b>URL:</b> http://docs.mql4.com/indicators/iichimoku.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</li>
        /// <li><b>timeframe</b> :  [in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</li>
        /// <li><b>tenkan_sen</b> :  [in] Tenkan Sen averaging period.</li>
        /// <li><b>kijun_sen</b> :  [in] Kijun Sen averaging period.</li>
        /// <li><b>senkou_span_b</b> :  [in] Senkou SpanB averaging period.</li>
        /// <li><b>mode</b> :  [in] Source of data. It can be one of the enumeration (1 - MODE_TENKANSEN, 2 - MODE_KIJUNSEN, 3 - MODE_SENKOUSPANA, 4 - MODE_SENKOUSPANB, 5 - MODE_CHIKOUSPAN).</li>
        /// <li><b>shift</b> :  [in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</li>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/iichimoku")]
        public void Handle_iIchimoku_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, iIchimoku_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> iIchimoku<br>
        /// <b>Description:</b> Calculates the Ichimoku Kinko Hyo indicator and returns its value.<br>
        /// <b>URL:</b> http://docs.mql4.com/indicators/iichimoku.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</li>
        /// <li><b>timeframe</b> :  [in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</li>
        /// <li><b>tenkan_sen</b> :  [in] Tenkan Sen averaging period.</li>
        /// <li><b>kijun_sen</b> :  [in] Kijun Sen averaging period.</li>
        /// <li><b>senkou_span_b</b> :  [in] Senkou SpanB averaging period.</li>
        /// <li><b>mode</b> :  [in] Source of data. It can be one of the enumeration (1 - MODE_TENKANSEN, 2 - MODE_KIJUNSEN, 3 - MODE_SENKOUSPANA, 4 - MODE_SENKOUSPANB, 5 - MODE_CHIKOUSPAN).</li>
        /// <li><b>shift</b> :  [in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</li>
        /// </ul>
        /// </summary>
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
        /// <b>Function:</b> iBWMFI<br>
        /// <b>Description:</b> Calculates the Market Facilitation Index indicator and returns its value.<br>
        /// <b>URL:</b> http://docs.mql4.com/indicators/ibwmfi.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</li>
        /// <li><b>timeframe</b> :  [in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</li>
        /// <li><b>shift</b> :  [in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</li>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/ibwmfi")]
        public void Handle_iBWMFI_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, iBWMFI_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> iBWMFI<br>
        /// <b>Description:</b> Calculates the Market Facilitation Index indicator and returns its value.<br>
        /// <b>URL:</b> http://docs.mql4.com/indicators/ibwmfi.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</li>
        /// <li><b>timeframe</b> :  [in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</li>
        /// <li><b>shift</b> :  [in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</li>
        /// </ul>
        /// </summary>
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
        /// <b>Function:</b> iMomentum<br>
        /// <b>Description:</b> Calculates the Momentum indicator and returns its value.<br>
        /// <b>URL:</b> http://docs.mql4.com/indicators/imomentum.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</li>
        /// <li><b>timeframe</b> :  [in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</li>
        /// <li><b>period</b> :  [in] Averaging period (amount of bars) for calculation of price changes.</li>
        /// <li><b>applied_price</b> :  [in] Applied price. It can be any of enumeration values.</li>
        /// <li><b>shift</b> :  [in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</li>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/imomentum")]
        public void Handle_iMomentum_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, iMomentum_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> iMomentum<br>
        /// <b>Description:</b> Calculates the Momentum indicator and returns its value.<br>
        /// <b>URL:</b> http://docs.mql4.com/indicators/imomentum.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</li>
        /// <li><b>timeframe</b> :  [in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</li>
        /// <li><b>period</b> :  [in] Averaging period (amount of bars) for calculation of price changes.</li>
        /// <li><b>applied_price</b> :  [in] Applied price. It can be any of enumeration values.</li>
        /// <li><b>shift</b> :  [in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</li>
        /// </ul>
        /// </summary>
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
        /// <b>Function:</b> iMFI<br>
        /// <b>Description:</b> Calculates the Money Flow Index indicator and returns its value.<br>
        /// <b>URL:</b> http://docs.mql4.com/indicators/imfi.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</li>
        /// <li><b>timeframe</b> :  [in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</li>
        /// <li><b>period</b> :  [in] Period (amount of bars) for calculation of the indicator.</li>
        /// <li><b>shift</b> :  [in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</li>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/imfi")]
        public void Handle_iMFI_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, iMFI_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> iMFI<br>
        /// <b>Description:</b> Calculates the Money Flow Index indicator and returns its value.<br>
        /// <b>URL:</b> http://docs.mql4.com/indicators/imfi.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</li>
        /// <li><b>timeframe</b> :  [in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</li>
        /// <li><b>period</b> :  [in] Period (amount of bars) for calculation of the indicator.</li>
        /// <li><b>shift</b> :  [in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</li>
        /// </ul>
        /// </summary>
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
        /// <b>Function:</b> iMA<br>
        /// <b>Description:</b> Calculates the Moving Average indicator and returns its value.<br>
        /// <b>URL:</b> http://docs.mql4.com/indicators/ima.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</li>
        /// <li><b>timeframe</b> :  [in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</li>
        /// <li><b>ma_period</b> :  [in] Averaging period for calculation.</li>
        /// <li><b>ma_shift</b> :  [in] MA shift. Indicators line offset relate to the chart by timeframe.</li>
        /// <li><b>ma_method</b> :  [in] Moving Average method. It can be any of enumeration values.</li>
        /// <li><b>applied_price</b> :  [in] Applied price. It can be any of enumeration values.</li>
        /// <li><b>shift</b> :  [in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</li>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/ima")]
        public void Handle_iMA_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, iMA_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> iMA<br>
        /// <b>Description:</b> Calculates the Moving Average indicator and returns its value.<br>
        /// <b>URL:</b> http://docs.mql4.com/indicators/ima.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</li>
        /// <li><b>timeframe</b> :  [in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</li>
        /// <li><b>ma_period</b> :  [in] Averaging period for calculation.</li>
        /// <li><b>ma_shift</b> :  [in] MA shift. Indicators line offset relate to the chart by timeframe.</li>
        /// <li><b>ma_method</b> :  [in] Moving Average method. It can be any of enumeration values.</li>
        /// <li><b>applied_price</b> :  [in] Applied price. It can be any of enumeration values.</li>
        /// <li><b>shift</b> :  [in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</li>
        /// </ul>
        /// </summary>
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
        /// <b>Function:</b> iOsMA<br>
        /// <b>Description:</b> iOsMA<br>
        /// <b>URL:</b> http://docs.mql4.com/indicators/iosma.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</li>
        /// <li><b>timeframe</b> :  [in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</li>
        /// <li><b>fast_ema_period</b> :  [in] Fast EMA averaging period.</li>
        /// <li><b>slow_ema_period</b> :  [in] Slow EMA averaging period.</li>
        /// <li><b>signal_period</b> :  [in] Signal line averaging period.</li>
        /// <li><b>applied_price</b> :  [in] Applied price. It can be any of enumeration values.</li>
        /// <li><b>shift</b> :  [in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</li>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/iosma")]
        public void Handle_iOsMA_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, iOsMA_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> iOsMA<br>
        /// <b>Description:</b> iOsMA<br>
        /// <b>URL:</b> http://docs.mql4.com/indicators/iosma.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</li>
        /// <li><b>timeframe</b> :  [in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</li>
        /// <li><b>fast_ema_period</b> :  [in] Fast EMA averaging period.</li>
        /// <li><b>slow_ema_period</b> :  [in] Slow EMA averaging period.</li>
        /// <li><b>signal_period</b> :  [in] Signal line averaging period.</li>
        /// <li><b>applied_price</b> :  [in] Applied price. It can be any of enumeration values.</li>
        /// <li><b>shift</b> :  [in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</li>
        /// </ul>
        /// </summary>
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
        /// <b>Function:</b> iMACD<br>
        /// <b>Description:</b> Calculates the Moving Averages Convergence/Divergence indicator and returns its value.<br>
        /// <b>URL:</b> http://docs.mql4.com/indicators/imacd.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</li>
        /// <li><b>timeframe</b> :  [in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</li>
        /// <li><b>fast_ema_period</b> :  [in] Fast EMA averaging period.</li>
        /// <li><b>slow_ema_period</b> :  [in] Slow EMA averaging period.</li>
        /// <li><b>signal_period</b> :  [in] Signal line averaging period.</li>
        /// <li><b>applied_price</b> :  [in] Applied price. It can be any of enumeration values.</li>
        /// <li><b>mode</b> :  [in] Indicator line index. It can be one of the enumeration values (0-MODE_MAIN, 1-MODE_SIGNAL).</li>
        /// <li><b>shift</b> :  [in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</li>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/imacd")]
        public void Handle_iMACD_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, iMACD_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> iMACD<br>
        /// <b>Description:</b> Calculates the Moving Averages Convergence/Divergence indicator and returns its value.<br>
        /// <b>URL:</b> http://docs.mql4.com/indicators/imacd.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</li>
        /// <li><b>timeframe</b> :  [in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</li>
        /// <li><b>fast_ema_period</b> :  [in] Fast EMA averaging period.</li>
        /// <li><b>slow_ema_period</b> :  [in] Slow EMA averaging period.</li>
        /// <li><b>signal_period</b> :  [in] Signal line averaging period.</li>
        /// <li><b>applied_price</b> :  [in] Applied price. It can be any of enumeration values.</li>
        /// <li><b>mode</b> :  [in] Indicator line index. It can be one of the enumeration values (0-MODE_MAIN, 1-MODE_SIGNAL).</li>
        /// <li><b>shift</b> :  [in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</li>
        /// </ul>
        /// </summary>
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
        /// <b>Function:</b> iOBV<br>
        /// <b>Description:</b> Calculates the On Balance Volume indicator and returns its value.<br>
        /// <b>URL:</b> http://docs.mql4.com/indicators/iobv.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</li>
        /// <li><b>timeframe</b> :  [in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</li>
        /// <li><b>applied_price</b> :  [in] Applied price. It can be any of enumeration values.</li>
        /// <li><b>shift</b> :  [in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</li>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/iobv")]
        public void Handle_iOBV_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, iOBV_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> iOBV<br>
        /// <b>Description:</b> Calculates the On Balance Volume indicator and returns its value.<br>
        /// <b>URL:</b> http://docs.mql4.com/indicators/iobv.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</li>
        /// <li><b>timeframe</b> :  [in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</li>
        /// <li><b>applied_price</b> :  [in] Applied price. It can be any of enumeration values.</li>
        /// <li><b>shift</b> :  [in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</li>
        /// </ul>
        /// </summary>
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
        /// <b>Function:</b> iSAR<br>
        /// <b>Description:</b> Calculates the Parabolic Stop and Reverse system indicator and returns its value.<br>
        /// <b>URL:</b> http://docs.mql4.com/indicators/isar.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</li>
        /// <li><b>timeframe</b> :  [in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</li>
        /// <li><b>step</b> :  [in] The step of price increment, usually 0.02.</li>
        /// <li><b>maximum</b> :  [in] The maximum step, usually 0.2.</li>
        /// <li><b>shift</b> :  [in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</li>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/isar")]
        public void Handle_iSAR_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, iSAR_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> iSAR<br>
        /// <b>Description:</b> Calculates the Parabolic Stop and Reverse system indicator and returns its value.<br>
        /// <b>URL:</b> http://docs.mql4.com/indicators/isar.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</li>
        /// <li><b>timeframe</b> :  [in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</li>
        /// <li><b>step</b> :  [in] The step of price increment, usually 0.02.</li>
        /// <li><b>maximum</b> :  [in] The maximum step, usually 0.2.</li>
        /// <li><b>shift</b> :  [in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</li>
        /// </ul>
        /// </summary>
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
        /// <b>Function:</b> iRSI<br>
        /// <b>Description:</b> Calculates the Relative Strength Index indicator and returns its value.<br>
        /// <b>URL:</b> http://docs.mql4.com/indicators/irsi.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</li>
        /// <li><b>timeframe</b> :  [in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</li>
        /// <li><b>period</b> :  [in] Averaging period for calculation.</li>
        /// <li><b>applied_price</b> :  [in] Applied price. It can be any of enumeration values.</li>
        /// <li><b>shift</b> :  [in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</li>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/irsi")]
        public void Handle_iRSI_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, iRSI_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> iRSI<br>
        /// <b>Description:</b> Calculates the Relative Strength Index indicator and returns its value.<br>
        /// <b>URL:</b> http://docs.mql4.com/indicators/irsi.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</li>
        /// <li><b>timeframe</b> :  [in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</li>
        /// <li><b>period</b> :  [in] Averaging period for calculation.</li>
        /// <li><b>applied_price</b> :  [in] Applied price. It can be any of enumeration values.</li>
        /// <li><b>shift</b> :  [in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</li>
        /// </ul>
        /// </summary>
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
        /// <b>Function:</b> iRVI<br>
        /// <b>Description:</b> Calculates the Relative Vigor Index indicator and returns its value.<br>
        /// <b>URL:</b> http://docs.mql4.com/indicators/irvi.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</li>
        /// <li><b>timeframe</b> :  [in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</li>
        /// <li><b>period</b> :  [in] Averaging period for calculation.</li>
        /// <li><b>mode</b> :  [in] Indicator line index. It can be any of enumeration value.</li>
        /// <li><b>shift</b> :  [in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</li>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/irvi")]
        public void Handle_iRVI_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, iRVI_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> iRVI<br>
        /// <b>Description:</b> Calculates the Relative Vigor Index indicator and returns its value.<br>
        /// <b>URL:</b> http://docs.mql4.com/indicators/irvi.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</li>
        /// <li><b>timeframe</b> :  [in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</li>
        /// <li><b>period</b> :  [in] Averaging period for calculation.</li>
        /// <li><b>mode</b> :  [in] Indicator line index. It can be any of enumeration value.</li>
        /// <li><b>shift</b> :  [in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</li>
        /// </ul>
        /// </summary>
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
        /// <b>Function:</b> iStdDev<br>
        /// <b>Description:</b> Calculates the Standard Deviation indicator and returns its value.<br>
        /// <b>URL:</b> http://docs.mql4.com/indicators/istddev.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</li>
        /// <li><b>timeframe</b> :  [in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</li>
        /// <li><b>ma_period</b> :  [in] Moving Average period.</li>
        /// <li><b>ma_shift</b> :  [in] Moving Average shift.</li>
        /// <li><b>ma_method</b> :  [in] Moving Average method. It can be any of enumeration values.</li>
        /// <li><b>applied_price</b> :  [in] Applied price. It can be any of enumeration values.</li>
        /// <li><b>shift</b> :  [in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</li>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/istddev")]
        public void Handle_iStdDev_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, iStdDev_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> iStdDev<br>
        /// <b>Description:</b> Calculates the Standard Deviation indicator and returns its value.<br>
        /// <b>URL:</b> http://docs.mql4.com/indicators/istddev.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</li>
        /// <li><b>timeframe</b> :  [in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</li>
        /// <li><b>ma_period</b> :  [in] Moving Average period.</li>
        /// <li><b>ma_shift</b> :  [in] Moving Average shift.</li>
        /// <li><b>ma_method</b> :  [in] Moving Average method. It can be any of enumeration values.</li>
        /// <li><b>applied_price</b> :  [in] Applied price. It can be any of enumeration values.</li>
        /// <li><b>shift</b> :  [in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</li>
        /// </ul>
        /// </summary>
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
        /// <b>Function:</b> iStochastic<br>
        /// <b>Description:</b> Calculates the Stochastic Oscillator and returns its value.<br>
        /// <b>URL:</b> http://docs.mql4.com/indicators/istochastic.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</li>
        /// <li><b>timeframe</b> :  [in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</li>
        /// <li><b>Kperiod</b> :  [in] Period of the %K line.</li>
        /// <li><b>Dperiod</b> :  [in] Period of the %D line.</li>
        /// <li><b>slowing</b> :  [in] Slowing value.</li>
        /// <li><b>method</b> :  [in] Moving Average method. It can be any of enumeration values.</li>
        /// <li><b>price_field</b> :  [in] Price field parameter. Can be one of this values: 0 - Low/High or 1 - Close/Close.</li>
        /// <li><b>mode</b> :  [in] Indicator line index. It can be any of the enumeration value (0 - MODE_MAIN, 1 - MODE_SIGNAL).</li>
        /// <li><b>shift</b> :  [in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</li>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/istochastic")]
        public void Handle_iStochastic_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, iStochastic_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> iStochastic<br>
        /// <b>Description:</b> Calculates the Stochastic Oscillator and returns its value.<br>
        /// <b>URL:</b> http://docs.mql4.com/indicators/istochastic.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</li>
        /// <li><b>timeframe</b> :  [in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</li>
        /// <li><b>Kperiod</b> :  [in] Period of the %K line.</li>
        /// <li><b>Dperiod</b> :  [in] Period of the %D line.</li>
        /// <li><b>slowing</b> :  [in] Slowing value.</li>
        /// <li><b>method</b> :  [in] Moving Average method. It can be any of enumeration values.</li>
        /// <li><b>price_field</b> :  [in] Price field parameter. Can be one of this values: 0 - Low/High or 1 - Close/Close.</li>
        /// <li><b>mode</b> :  [in] Indicator line index. It can be any of the enumeration value (0 - MODE_MAIN, 1 - MODE_SIGNAL).</li>
        /// <li><b>shift</b> :  [in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</li>
        /// </ul>
        /// </summary>
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
        /// <b>Function:</b> iWPR<br>
        /// <b>Description:</b> Calculates the Larry Williams' Percent Range and returns its value.<br>
        /// <b>URL:</b> http://docs.mql4.com/indicators/iwpr.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</li>
        /// <li><b>timeframe</b> :  [in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</li>
        /// <li><b>period</b> :  [in] Averaging period for calculation.</li>
        /// <li><b>shift</b> :  [in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</li>
        /// </ul>
        /// </summary>
        [RESTRoute(Method = HttpMethod.POST, PathInfo = @"^/[0-9]+/iwpr")]
        public void Handle_iWPR_1(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, iWPR_1(context, chartid));
        }

        /// <summary>
        /// <b>Function:</b> iWPR<br>
        /// <b>Description:</b> Calculates the Larry Williams' Percent Range and returns its value.<br>
        /// <b>URL:</b> http://docs.mql4.com/indicators/iwpr.html<br>
        /// <b>JSON Input Parameters:</b><br>
        /// <ul>
        /// <li><b>symbol</b> :  [in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</li>
        /// <li><b>timeframe</b> :  [in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</li>
        /// <li><b>period</b> :  [in] Averaging period for calculation.</li>
        /// <li><b>shift</b> :  [in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</li>
        /// </ul>
        /// </summary>
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
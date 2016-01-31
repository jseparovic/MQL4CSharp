using log4net;
using System;
using System.Collections.Generic;
using MQL4CSharp.Base.Enums;
using MQL4CSharp.Base.MQL;
using System.Threading;

namespace MQL4CSharp.Base
{
    public abstract class MQLBase
    {
        public ILog LOG;

        public MQLBase()
        {
            LOG = LogManager.GetLogger(GetType());
        }

        public void setTimerInterval(Int64 intervalMillis)
        {
            MQLExpert.getInstance().setTimerInterval(intervalMillis);
        }

        public abstract void OnInit();
        public abstract void OnDeinit();
        public abstract void OnTick();
        public abstract void OnTimer();

        /// <summary>
        /// ITime from the RatesInfo Structure, this is for the current chart symbol and timeframe
        /// </summary>
        /// <param name="i">Shift</param>
        /// <returns>DateTime</returns>
        public unsafe DateTime ITime(int i)
        {
            return MQLRates.getInstance().ITime(i);
        }

        /// <summary>
        /// IOpen from the RatesInfo Structure, this is for the current chart symbol and timeframe
        /// </summary>
        /// <param name="i">Shift</param>
        /// <returns>double</returns>
        public unsafe double IOpen(int i)
        {
            return MQLRates.getInstance().IOpen(i);
        }

        /// <summary>
        /// IHigh from the RatesInfo Structure, this is for the current chart symbol and timeframe
        /// </summary>
        /// <param name="i">Shift</param>
        /// <returns>double</returns>
        public unsafe double IHigh(int i)
        {
            return MQLRates.getInstance().IHigh(i);
        }

        /// <summary>
        /// ILow from the RatesInfo Structure, this is for the current chart symbol and timeframe
        /// </summary>
        /// <param name="i">Shift</param>
        /// <returns>double</returns>
        public unsafe double ILow(int i)
        {
            return MQLRates.getInstance().ILow(i);
        }

        /// <summary>
        /// IVolume from the RatesInfo Structure, this is for the current chart symbol and timeframe
        /// </summary>
        /// <param name="i">Shift</param>
        /// <returns>double</returns>
        public unsafe double IVolume(int i)
        {
            return MQLRates.getInstance().IVolume(i);
        }

        /// <summary>
        /// IClose from the RatesInfo Structure, this is for the current chart symbol and timeframe
        /// </summary>
        /// <param name="i">Shift</param>
        /// <returns>double</returns>
        public unsafe double IClose(int i)
        {
            return MQLRates.getInstance().IClose(i);
        }



        /// <summary>
        /// Function: Alert
        /// Description: Displays a message in a separate window.
        /// URL: http://mm.l/mql4/docs.mql4.com/common/alert.html
        /// </summary>
        /// <param name="argument"></param>
        public void Alert(string argument)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(argument);
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.Alert_1, parameters); // MQLCommand ENUM = 1
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
        }

        /// <summary>
        /// Function: Comment
        /// Description: This function outputs a comment defined by a user in the top left corner of a chart.
        /// URL: http://mm.l/mql4/docs.mql4.com/common/comment.html
        /// </summary>
        /// <param name="argument">[in] Any values, separated by commas. To delimit output information into several lines, a line break symbol "\n" or "\r\n" is used. Number of parameters cannot exceed 64. Total length of the input comment (including invisible symbols) cannot exceed 2045 characters (excess symbols will be cut out during output).</param>
        public void Comment(string argument)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(argument);
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.Comment_1, parameters); // MQLCommand ENUM = 2
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
        }

        /// <summary>
        /// Function: SendFTP
        /// Description: Sends a file at the address, specified in the setting window of the "FTP" tab.
        /// URL: http://mm.l/mql4/docs.mql4.com/common/sendftp.html
        /// </summary>
        /// <param name="filename">[in] Name of sent file.</param>
        /// <param name="ftp_path">[in] FTP catalog. If a directory is not specified, directory described in settings is used.</param>
        public bool SendFTP(string filename, string ftp_path)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(filename);
            parameters.Add(ftp_path);
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.SendFTP_1, parameters); // MQLCommand ENUM = 3
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (bool)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: SendNotification
        /// Description: Sends push notifications to the mobile terminals, whose MetaQuotes IDs are specified in the "Notifications" tab.
        /// URL: http://mm.l/mql4/docs.mql4.com/common/sendnotification.html
        /// </summary>
        /// <param name="text">[in] The text of the notification. The message length should not exceed 255 characters.</param>
        public bool SendNotification(string text)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(text);
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.SendNotification_1, parameters); // MQLCommand ENUM = 4
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (bool)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: SendMail
        /// Description: Sends an email at the address specified in the settings window of the "Email" tab.
        /// URL: http://mm.l/mql4/docs.mql4.com/common/sendmail.html
        /// </summary>
        /// <param name="subject">[in] Email header.</param>
        /// <param name="some_text">[in] Email body.</param>
        public bool SendMail(string subject, string some_text)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(subject);
            parameters.Add(some_text);
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.SendMail_1, parameters); // MQLCommand ENUM = 5
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (bool)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: AccountInfoDouble
        /// Description: Returns the value of the corresponding account property.
        /// URL: http://mm.l/mql4/docs.mql4.com/account/accountinfodouble.html
        /// </summary>
        /// <param name="property_id">[in] Identifier of the property. The value can be one of the values of .</param>
        public double AccountInfoDouble(int property_id)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(property_id);
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.AccountInfoDouble_1, parameters); // MQLCommand ENUM = 6
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (double)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: AccountInfoInteger
        /// Description: Returns the value of the properties of the account.
        /// URL: http://mm.l/mql4/docs.mql4.com/account/accountinfointeger.html
        /// </summary>
        /// <param name="property_id">[in] Identifier of the property. The value can be one of the values of .</param>
        public long AccountInfoInteger(int property_id)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(property_id);
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.AccountInfoInteger_1, parameters); // MQLCommand ENUM = 7
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (long)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: AccountInfoString
        /// Description: Returns the value of the corresponding account property.
        /// URL: http://mm.l/mql4/docs.mql4.com/account/accountinfostring.html
        /// </summary>
        /// <param name="property_id">[in] Identifier of the property. The value can be one of the values of .</param>
        public string AccountInfoString(int property_id)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(property_id);
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.AccountInfoString_1, parameters); // MQLCommand ENUM = 8
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (string)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: AccountBalance
        /// Description: Returns balance value of the current account.
        /// URL: http://mm.l/mql4/docs.mql4.com/account/accountbalance.html
        /// </summary>
        public double AccountBalance()
        {
            List<Object> parameters = new List<Object>();
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.AccountBalance_1, parameters); // MQLCommand ENUM = 9
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (double)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: AccountCredit
        /// Description: Returns credit value of the current account.
        /// URL: http://mm.l/mql4/docs.mql4.com/account/accountcredit.html
        /// </summary>
        public double AccountCredit()
        {
            List<Object> parameters = new List<Object>();
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.AccountCredit_1, parameters); // MQLCommand ENUM = 10
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (double)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: AccountCompany
        /// Description: Returns the brokerage company name where the current account was registered.
        /// URL: http://mm.l/mql4/docs.mql4.com/account/accountcompany.html
        /// </summary>
        public string AccountCompany()
        {
            List<Object> parameters = new List<Object>();
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.AccountCompany_1, parameters); // MQLCommand ENUM = 11
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (string)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: AccountCurrency
        /// Description: Returns currency name of the current account.
        /// URL: http://mm.l/mql4/docs.mql4.com/account/accountcurrency.html
        /// </summary>
        public string AccountCurrency()
        {
            List<Object> parameters = new List<Object>();
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.AccountCurrency_1, parameters); // MQLCommand ENUM = 12
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (string)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: AccountEquity
        /// Description: Returns equity value of the current account.
        /// URL: http://mm.l/mql4/docs.mql4.com/account/accountequity.html
        /// </summary>
        public double AccountEquity()
        {
            List<Object> parameters = new List<Object>();
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.AccountEquity_1, parameters); // MQLCommand ENUM = 13
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (double)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: AccountFreeMargin
        /// Description: Returns free margin value of the current account.
        /// URL: http://mm.l/mql4/docs.mql4.com/account/accountfreemargin.html
        /// </summary>
        public double AccountFreeMargin()
        {
            List<Object> parameters = new List<Object>();
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.AccountFreeMargin_1, parameters); // MQLCommand ENUM = 14
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (double)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: AccountFreeMarginCheck
        /// Description: Returns free margin that remains after the specified order has been opened at the current price on the current account.
        /// URL: http://mm.l/mql4/docs.mql4.com/account/accountfreemargincheck.html
        /// </summary>
        /// <param name="symbol">[in] Symbol for trading operation.</param>
        /// <param name="cmd">[in] Operation type. It can be either OP_BUY or OP_SELL.</param>
        /// <param name="volume">[in] Number of lots.</param>
        public double AccountFreeMarginCheck(string symbol, int cmd, double volume)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(symbol);
            parameters.Add(cmd);
            parameters.Add(volume);
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.AccountFreeMarginCheck_1, parameters); // MQLCommand ENUM = 15
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (double)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: AccountFreeMarginMode
        /// Description: Returns the calculation mode of free margin allowed to open orders on the current account.
        /// URL: http://mm.l/mql4/docs.mql4.com/account/accountfreemarginmode.html
        /// </summary>
        public double AccountFreeMarginMode()
        {
            List<Object> parameters = new List<Object>();
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.AccountFreeMarginMode_1, parameters); // MQLCommand ENUM = 16
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (double)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: AccountLeverage
        /// Description: Returns leverage of the current account.
        /// URL: http://mm.l/mql4/docs.mql4.com/account/accountleverage.html
        /// </summary>
        public int AccountLeverage()
        {
            List<Object> parameters = new List<Object>();
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.AccountLeverage_1, parameters); // MQLCommand ENUM = 17
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (int)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: AccountMargin
        /// Description: Returns margin value of the current account.
        /// URL: http://mm.l/mql4/docs.mql4.com/account/accountmargin.html
        /// </summary>
        public double AccountMargin()
        {
            List<Object> parameters = new List<Object>();
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.AccountMargin_1, parameters); // MQLCommand ENUM = 18
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (double)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: AccountName
        /// Description: Returns the current account name.
        /// URL: http://mm.l/mql4/docs.mql4.com/account/accountname.html
        /// </summary>
        public string AccountName()
        {
            List<Object> parameters = new List<Object>();
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.AccountName_1, parameters); // MQLCommand ENUM = 19
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (string)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: AccountNumber
        /// Description: Returns the current account number.
        /// URL: http://mm.l/mql4/docs.mql4.com/account/accountnumber.html
        /// </summary>
        public int AccountNumber()
        {
            List<Object> parameters = new List<Object>();
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.AccountNumber_1, parameters); // MQLCommand ENUM = 20
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (int)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: AccountProfit
        /// Description: Returns profit value of the current account.
        /// URL: http://mm.l/mql4/docs.mql4.com/account/accountprofit.html
        /// </summary>
        public double AccountProfit()
        {
            List<Object> parameters = new List<Object>();
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.AccountProfit_1, parameters); // MQLCommand ENUM = 21
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (double)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: AccountServer
        /// Description: Returns the connected server name.
        /// URL: http://mm.l/mql4/docs.mql4.com/account/accountserver.html
        /// </summary>
        public string AccountServer()
        {
            List<Object> parameters = new List<Object>();
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.AccountServer_1, parameters); // MQLCommand ENUM = 22
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (string)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: AccountStopoutLevel
        /// Description: Returns the value of the Stop Out level.
        /// URL: http://mm.l/mql4/docs.mql4.com/account/accountstopoutlevel.html
        /// </summary>
        public int AccountStopoutLevel()
        {
            List<Object> parameters = new List<Object>();
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.AccountStopoutLevel_1, parameters); // MQLCommand ENUM = 23
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (int)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: AccountStopoutMode
        /// Description: Returns the calculation mode for the Stop Out level.
        /// URL: http://mm.l/mql4/docs.mql4.com/account/accountstopoutmode.html
        /// </summary>
        public int AccountStopoutMode()
        {
            List<Object> parameters = new List<Object>();
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.AccountStopoutMode_1, parameters); // MQLCommand ENUM = 24
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (int)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: GetLastError
        /// Description: Returns the contents of the
        /// URL: http://mm.l/mql4/docs.mql4.com/check/getlasterror.html
        /// </summary>
        public int GetLastError()
        {
            List<Object> parameters = new List<Object>();
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.GetLastError_1, parameters); // MQLCommand ENUM = 25
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (int)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: IsStopped
        /// Description: Checks the forced shutdown of an mql4 program.
        /// URL: http://mm.l/mql4/docs.mql4.com/check/isstopped.html
        /// </summary>
        public bool IsStopped()
        {
            List<Object> parameters = new List<Object>();
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.IsStopped_1, parameters); // MQLCommand ENUM = 26
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (bool)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: UninitializeReason
        /// Description: Returns the code of a
        /// URL: http://mm.l/mql4/docs.mql4.com/check/uninitializereason.html
        /// </summary>
        public int UninitializeReason()
        {
            List<Object> parameters = new List<Object>();
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.UninitializeReason_1, parameters); // MQLCommand ENUM = 27
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (int)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: MQLInfoInteger
        /// Description: Returns the value of a corresponding property of a running mql4 program.
        /// URL: http://mm.l/mql4/docs.mql4.com/check/mqlinfointeger.html
        /// </summary>
        /// <param name="property_id">[in] Identifier of a property. Can be one of values of the enumeration.</param>
        public int MQLInfoInteger(int property_id)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(property_id);
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.MQLInfoInteger_1, parameters); // MQLCommand ENUM = 28
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (int)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: MQLInfoString
        /// Description: Returns the value of a corresponding property of a running MQL4 program.
        /// URL: http://mm.l/mql4/docs.mql4.com/check/mqlinfostring.html
        /// </summary>
        /// <param name="property_id">[in] Identifier of a property. Can be one of the enumeration.</param>
        public string MQLInfoString(int property_id)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(property_id);
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.MQLInfoString_1, parameters); // MQLCommand ENUM = 29
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (string)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: MQLSetInteger
        /// Description: Sets the value of the
        /// URL: http://mm.l/mql4/docs.mql4.com/check/mqlsetinteger.html
        /// </summary>
        /// <param name="property_id">[in] Identifier of a property. Only is supported, as other properties cannot be changed.</param>
        /// <param name="property_value">[in] Value of property. Can be one of the .</param>
        public void MQLSetInteger(int property_id, int property_value)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(property_id);
            parameters.Add(property_value);
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.MQLSetInteger_1, parameters); // MQLCommand ENUM = 30
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
        }

        /// <summary>
        /// Function: TerminalInfoInteger
        /// Description: Returns the value of a corresponding property of the mql4 program environment.
        /// URL: http://mm.l/mql4/docs.mql4.com/check/terminalinfointeger.html
        /// </summary>
        /// <param name="property_id">[in] Identifier of a property. Can be one of the values of the enumeration.</param>
        public int TerminalInfoInteger(int property_id)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(property_id);
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.TerminalInfoInteger_1, parameters); // MQLCommand ENUM = 31
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (int)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: TerminalInfoDouble
        /// Description: Returns the value of a corresponding property of the mql4 program environment.
        /// URL: http://mm.l/mql4/docs.mql4.com/check/terminalinfodouble.html
        /// </summary>
        /// <param name="property_id">[in] Identifier of a property. Can be one of the values of the enumeration.</param>
        public double TerminalInfoDouble(int property_id)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(property_id);
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.TerminalInfoDouble_1, parameters); // MQLCommand ENUM = 32
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (double)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: TerminalInfoString
        /// Description: Returns the value of a corresponding property of the mql4 program environment. The property must be of string type.
        /// URL: http://mm.l/mql4/docs.mql4.com/check/terminalinfostring.html
        /// </summary>
        /// <param name="property_id">[in] Identifier of a property. Can be one of the values of the enumeration.</param>
        public string TerminalInfoString(int property_id)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(property_id);
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.TerminalInfoString_1, parameters); // MQLCommand ENUM = 33
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (string)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: Symbol
        /// Description: Returns the name of a symbol of the current chart.
        /// URL: http://mm.l/mql4/docs.mql4.com/check/symbol.html
        /// </summary>
        public string Symbol()
        {
            List<Object> parameters = new List<Object>();
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.Symbol_1, parameters); // MQLCommand ENUM = 34
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (string)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: Period
        /// Description: Returns the current chart timeframe.
        /// URL: http://mm.l/mql4/docs.mql4.com/check/period.html
        /// </summary>
        public int Period()
        {
            List<Object> parameters = new List<Object>();
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.Period_1, parameters); // MQLCommand ENUM = 35
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (int)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: Digits
        /// Description: Returns the number of decimal digits determining the accuracy of price of the current chart symbol.
        /// URL: http://mm.l/mql4/docs.mql4.com/check/digits.html
        /// </summary>
        public int Digits()
        {
            List<Object> parameters = new List<Object>();
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.Digits_1, parameters); // MQLCommand ENUM = 36
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (int)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: Point
        /// Description: Returns the point size of the current symbol in the quote currency.
        /// URL: http://mm.l/mql4/docs.mql4.com/check/point.html
        /// </summary>
        public double Point()
        {
            List<Object> parameters = new List<Object>();
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.Point_1, parameters); // MQLCommand ENUM = 37
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (double)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: IsConnected
        /// Description: Checks connection between client terminal and server.
        /// URL: http://mm.l/mql4/docs.mql4.com/check/isconnected.html
        /// </summary>
        public bool IsConnected()
        {
            List<Object> parameters = new List<Object>();
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.IsConnected_1, parameters); // MQLCommand ENUM = 38
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (bool)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: IsDemo
        /// Description: Checks if the Expert Advisor runs on a demo account.
        /// URL: http://mm.l/mql4/docs.mql4.com/check/isdemo.html
        /// </summary>
        public bool IsDemo()
        {
            List<Object> parameters = new List<Object>();
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.IsDemo_1, parameters); // MQLCommand ENUM = 39
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (bool)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: IsDllsAllowed
        /// Description: Checks if the DLL function call is allowed for the Expert Advisor.
        /// URL: http://mm.l/mql4/docs.mql4.com/check/isdllsallowed.html
        /// </summary>
        public bool IsDllsAllowed()
        {
            List<Object> parameters = new List<Object>();
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.IsDllsAllowed_1, parameters); // MQLCommand ENUM = 40
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (bool)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: IsExpertEnabled
        /// Description: Checks if Expert Advisors are enabled for running.
        /// URL: http://mm.l/mql4/docs.mql4.com/check/isexpertenabled.html
        /// </summary>
        public bool IsExpertEnabled()
        {
            List<Object> parameters = new List<Object>();
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.IsExpertEnabled_1, parameters); // MQLCommand ENUM = 41
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (bool)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: IsLibrariesAllowed
        /// Description: Checks if the Expert Advisor can call library function.
        /// URL: http://mm.l/mql4/docs.mql4.com/check/islibrariesallowed.html
        /// </summary>
        public bool IsLibrariesAllowed()
        {
            List<Object> parameters = new List<Object>();
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.IsLibrariesAllowed_1, parameters); // MQLCommand ENUM = 42
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (bool)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: IsOptimization
        /// Description: Checks if Expert Advisor runs in the Strategy Tester optimization mode.
        /// URL: http://mm.l/mql4/docs.mql4.com/check/isoptimization.html
        /// </summary>
        public bool IsOptimization()
        {
            List<Object> parameters = new List<Object>();
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.IsOptimization_1, parameters); // MQLCommand ENUM = 43
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (bool)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: IsTesting
        /// Description: Checks
        /// URL: http://mm.l/mql4/docs.mql4.com/check/istesting.html
        /// </summary>
        public bool IsTesting()
        {
            List<Object> parameters = new List<Object>();
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.IsTesting_1, parameters); // MQLCommand ENUM = 44
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (bool)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: IsTradeAllowed
        /// Description: Checks
        /// URL: http://mm.l/mql4/docs.mql4.com/check/istradeallowed.html
        /// </summary>
        public bool IsTradeAllowed()
        {
            List<Object> parameters = new List<Object>();
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.IsTradeAllowed_1, parameters); // MQLCommand ENUM = 45
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (bool)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: IsTradeAllowed
        /// Description: Checks
        /// URL: http://mm.l/mql4/docs.mql4.com/check/istradeallowed.html
        /// </summary>
        /// <param name="symbol">[in] Symbol.</param>
        /// <param name="tested_time">[in] Time to check status.</param>
        public bool IsTradeAllowed(string symbol, DateTime tested_time)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(symbol);
            parameters.Add(tested_time);
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.IsTradeAllowed_2, parameters); // MQLCommand ENUM = 45
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (bool)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: IsTradeContextBusy
        /// Description: Returns the information about trade context.
        /// URL: http://mm.l/mql4/docs.mql4.com/check/istradecontextbusy.html
        /// </summary>
        public bool IsTradeContextBusy()
        {
            List<Object> parameters = new List<Object>();
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.IsTradeContextBusy_1, parameters); // MQLCommand ENUM = 46
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (bool)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: IsVisualMode
        /// Description: Checks
        /// URL: http://mm.l/mql4/docs.mql4.com/check/isvisualmode.html
        /// </summary>
        public bool IsVisualMode()
        {
            List<Object> parameters = new List<Object>();
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.IsVisualMode_1, parameters); // MQLCommand ENUM = 47
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (bool)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: TerminalCompany
        /// Description: Returns the name of company owning the client terminal.
        /// URL: http://mm.l/mql4/docs.mql4.com/check/terminalcompany.html
        /// </summary>
        public string TerminalCompany()
        {
            List<Object> parameters = new List<Object>();
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.TerminalCompany_1, parameters); // MQLCommand ENUM = 48
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (string)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: TerminalName
        /// Description: Returns client terminal name.
        /// URL: http://mm.l/mql4/docs.mql4.com/check/terminalname.html
        /// </summary>
        public string TerminalName()
        {
            List<Object> parameters = new List<Object>();
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.TerminalName_1, parameters); // MQLCommand ENUM = 49
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (string)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: TerminalPath
        /// Description: Returns the directory, from which the client terminal was launched.
        /// URL: http://mm.l/mql4/docs.mql4.com/check/terminalpath.html
        /// </summary>
        public string TerminalPath()
        {
            List<Object> parameters = new List<Object>();
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.TerminalPath_1, parameters); // MQLCommand ENUM = 50
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (string)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: MarketInfo
        /// Description: Returns various data about securities listed in the "Market Watch" window.
        /// URL: http://mm.l/mql4/docs.mql4.com/marketinformation/marketinfo.html
        /// </summary>
        /// <param name="symbol">[in] Symbol name.</param>
        /// <param name="type">[in] Request of information to be returned. Can be any of values of request identifiers.</param>
        public double MarketInfo(string symbol, int type)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(symbol);
            parameters.Add(type);
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.MarketInfo_1, parameters); // MQLCommand ENUM = 51
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (double)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: SymbolsTotal
        /// Description: Returns the number of available (selected in Market Watch or all) symbols.
        /// URL: http://mm.l/mql4/docs.mql4.com/marketinformation/symbolstotal.html
        /// </summary>
        /// <param name="selected">[in] Request mode. Can be true or false.</param>
        public int SymbolsTotal(bool selected)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(selected);
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.SymbolsTotal_1, parameters); // MQLCommand ENUM = 52
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (int)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: SymbolName
        /// Description: Returns the name of a symbol.
        /// URL: http://mm.l/mql4/docs.mql4.com/marketinformation/symbolname.html
        /// </summary>
        /// <param name="pos">[in] Order number of a symbol.</param>
        /// <param name="selected">[in] Request mode. If the value is true, the symbol is taken from the list of symbols selected in MarketWatch. If the value is false, the symbol is taken from the general list.</param>
        public string SymbolName(int pos, bool selected)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(pos);
            parameters.Add(selected);
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.SymbolName_1, parameters); // MQLCommand ENUM = 53
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (string)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: SymbolSelect
        /// Description: Selects a symbol in the Market Watch window or removes a symbol from the window.
        /// URL: http://mm.l/mql4/docs.mql4.com/marketinformation/symbolselect.html
        /// </summary>
        /// <param name="name">[in] Symbol name.</param>
        /// <param name="select">[in] Switch. If the value is false, a symbol should be removed from MarketWatch, otherwise a symbol should be selected in this window. A symbol can't be removed if the symbol chart is open, or there are open orders for this symbol.</param>
        public bool SymbolSelect(string name, bool select)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(name);
            parameters.Add(select);
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.SymbolSelect_1, parameters); // MQLCommand ENUM = 54
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (bool)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: RefreshRates
        /// Description: Refreshing of data in pre-defined variables and series arrays.
        /// URL: http://mm.l/mql4/docs.mql4.com/series/refreshrates.html
        /// </summary>
        public bool RefreshRates()
        {
            List<Object> parameters = new List<Object>();
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.RefreshRates_1, parameters); // MQLCommand ENUM = 55
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (bool)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: Bars
        /// Description: Returns the number of bars count in the history for a specified symbol and period. There are 2 variants of functions calls.
        /// URL: http://mm.l/mql4/docs.mql4.com/series/barsfunction.html
        /// </summary>
        /// <param name="symbol_name">[in] Symbol name.</param>
        /// <param name="timeframe">[in] Period.</param>
        public int Bars(string symbol_name, TIMEFRAME timeframe)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(symbol_name);
            parameters.Add(timeframe.ToString());
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.Bars_1, parameters); // MQLCommand ENUM = 56
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (int)MQLCommandManager.getInstance().GetCommandResult();
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
        public int Bars(string symbol_name, TIMEFRAME timeframe, DateTime start_time, DateTime stop_time)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(symbol_name);
            parameters.Add(timeframe.ToString());
            parameters.Add(start_time);
            parameters.Add(stop_time);
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.Bars_2, parameters); // MQLCommand ENUM = 56
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (int)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: iBars
        /// Description: Returns the number of bars on the specified chart.
        /// URL: http://mm.l/mql4/docs.mql4.com/series/ibars.html
        /// </summary>
        /// <param name="symbol">[in] Symbol the data of which should be used to calculate indicator. means the current symbol.</param>
        /// <param name="timeframe">[in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</param>
        public int iBars(string symbol, int timeframe)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(symbol);
            parameters.Add(timeframe);
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.iBars_1, parameters); // MQLCommand ENUM = 57
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (int)MQLCommandManager.getInstance().GetCommandResult();
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
        public int iBarShift(string symbol, int timeframe, DateTime time, bool exact)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(symbol);
            parameters.Add(timeframe);
            parameters.Add(time);
            parameters.Add(exact);
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.iBarShift_1, parameters); // MQLCommand ENUM = 58
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (int)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: iClose
        /// Description: Returns Close price value for the bar of specified symbol with timeframe and shift.
        /// URL: http://mm.l/mql4/docs.mql4.com/series/iclose.html
        /// </summary>
        /// <param name="symbol">[in] Symbol name. means the current symbol.</param>
        /// <param name="timeframe">[in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</param>
        /// <param name="shift">[in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</param>
        public double iClose(string symbol, int timeframe, int shift)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(symbol);
            parameters.Add(timeframe);
            parameters.Add(shift);
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.iClose_1, parameters); // MQLCommand ENUM = 59
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (double)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: iHigh
        /// Description: Returns High price value for the bar of specified symbol with timeframe and shift.
        /// URL: http://mm.l/mql4/docs.mql4.com/series/ihigh.html
        /// </summary>
        /// <param name="symbol">[in] Symbol name. means the current symbol.</param>
        /// <param name="timeframe">[in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</param>
        /// <param name="shift">[in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</param>
        public double iHigh(string symbol, int timeframe, int shift)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(symbol);
            parameters.Add(timeframe);
            parameters.Add(shift);
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.iHigh_1, parameters); // MQLCommand ENUM = 60
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (double)MQLCommandManager.getInstance().GetCommandResult();
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
        public int iHighest(string symbol, int timeframe, int type, int count, int start)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(symbol);
            parameters.Add(timeframe);
            parameters.Add(type);
            parameters.Add(count);
            parameters.Add(start);
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.iHighest_1, parameters); // MQLCommand ENUM = 61
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (int)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: iLow
        /// Description: Returns Low price value for the bar of indicated symbol with timeframe and shift.
        /// URL: http://mm.l/mql4/docs.mql4.com/series/ilow.html
        /// </summary>
        /// <param name="symbol">[in] Symbol name. means the current symbol.</param>
        /// <param name="timeframe">[in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</param>
        /// <param name="shift">[in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</param>
        public double iLow(string symbol, int timeframe, int shift)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(symbol);
            parameters.Add(timeframe);
            parameters.Add(shift);
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.iLow_1, parameters); // MQLCommand ENUM = 62
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (double)MQLCommandManager.getInstance().GetCommandResult();
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
        public int iLowest(string symbol, int timeframe, int type, int count, int start)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(symbol);
            parameters.Add(timeframe);
            parameters.Add(type);
            parameters.Add(count);
            parameters.Add(start);
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.iLowest_1, parameters); // MQLCommand ENUM = 63
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (int)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: iOpen
        /// Description: Returns Open price value for the bar of specified symbol with timeframe and shift.
        /// URL: http://mm.l/mql4/docs.mql4.com/series/iopen.html
        /// </summary>
        /// <param name="symbol">[in] Symbol name. means the current symbol.</param>
        /// <param name="timeframe">[in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</param>
        /// <param name="shift">[in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</param>
        public double iOpen(string symbol, int timeframe, int shift)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(symbol);
            parameters.Add(timeframe);
            parameters.Add(shift);
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.iOpen_1, parameters); // MQLCommand ENUM = 64
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (double)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: iTime
        /// Description: Returns Time value for the bar of specified symbol with timeframe and shift.
        /// URL: http://mm.l/mql4/docs.mql4.com/series/itime.html
        /// </summary>
        /// <param name="symbol">[in] Symbol name. means the current symbol.</param>
        /// <param name="timeframe">[in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</param>
        /// <param name="shift">[in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</param>
        public DateTime iTime(string symbol, int timeframe, int shift)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(symbol);
            parameters.Add(timeframe);
            parameters.Add(shift);
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.iTime_1, parameters); // MQLCommand ENUM = 65
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (DateTime)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: iVolume
        /// Description: Returns Tick Volume value for the bar of specified symbol with timeframe and shift.
        /// URL: http://mm.l/mql4/docs.mql4.com/series/ivolume.html
        /// </summary>
        /// <param name="symbol">[in] Symbol name. means the current symbol.</param>
        /// <param name="timeframe">[in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</param>
        /// <param name="shift">[in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</param>
        public long iVolume(string symbol, int timeframe, int shift)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(symbol);
            parameters.Add(timeframe);
            parameters.Add(shift);
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.iVolume_1, parameters); // MQLCommand ENUM = 66
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (long)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: ChartApplyTemplate
        /// Description: Applies a specific template from a specified file to the chart. The command is added to chart message queue and executed only after all previous commands have been processed.
        /// URL: http://mm.l/mql4/docs.mql4.com/chart_operations/chartapplytemplate.html
        /// </summary>
        /// <param name="chart_id">[in] Chart ID. 0 means the current chart.</param>
        /// <param name="filename">[in] The name of the file containing the template.</param>
        public bool ChartApplyTemplate(long chart_id, string filename)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(chart_id);
            parameters.Add(filename);
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.ChartApplyTemplate_1, parameters); // MQLCommand ENUM = 67
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (bool)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: ChartSaveTemplate
        /// Description: Saves current chart settings in a template with a specified name. The command is added to chart message queue and executed only after all previous commands have been processed.
        /// URL: http://mm.l/mql4/docs.mql4.com/chart_operations/chartsavetemplate.html
        /// </summary>
        /// <param name="chart_id">[in] Chart ID. 0 means the current chart.</param>
        /// <param name="filename">[in] The filename to save the template. The ".tpl" extension will be added to the filename automatically; there is no need to specify it. The template is saved in terminal_directory\Profiles\Templates\ and can be used for manual application in the terminal. If a template with the same filename already exists, the contents of this file will be overwritten.</param>
        public bool ChartSaveTemplate(long chart_id, string filename)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(chart_id);
            parameters.Add(filename);
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.ChartSaveTemplate_1, parameters); // MQLCommand ENUM = 68
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (bool)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: ChartWindowFind
        /// Description: The function returns the number of a subwindow where an indicator is drawn. There are 2 variants of the function.
        /// URL: http://mm.l/mql4/docs.mql4.com/chart_operations/chartwindowfind.html
        /// </summary>
        /// <param name="chart_id">[in] Chart ID. 0 denotes the current chart.</param>
        /// <param name="indicator_shortname">[in] Short name of the indicator.</param>
        public int ChartWindowFind(long chart_id, string indicator_shortname)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(chart_id);
            parameters.Add(indicator_shortname);
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.ChartWindowFind_1, parameters); // MQLCommand ENUM = 69
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (int)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: ChartWindowFind
        /// Description: The function returns the number of a subwindow where an indicator is drawn. There are 2 variants of the function.
        /// URL: http://mm.l/mql4/docs.mql4.com/chart_operations/chartwindowfind.html
        /// </summary>
        public int ChartWindowFind()
        {
            List<Object> parameters = new List<Object>();
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.ChartWindowFind_2, parameters); // MQLCommand ENUM = 69
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (int)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: ChartOpen
        /// Description: Opens a new chart with the specified symbol and period. The command is added to chart message queue and executed only after all previous commands have been processed.
        /// URL: http://mm.l/mql4/docs.mql4.com/chart_operations/chartopen.html
        /// </summary>
        /// <param name="symbol">[in] Chart symbol. means the symbol of the current chart (the Expert Advisor is attached to).</param>
        /// <param name="period">[in] Chart period (timeframe). Can be one of the values. 0 means the current chart period.</param>
        public long ChartOpen(string symbol, TIMEFRAME period)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(symbol);
            parameters.Add(period.ToString());
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.ChartOpen_1, parameters); // MQLCommand ENUM = 70
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (long)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: ChartFirst
        /// Description: Returns the ID of the first chart of the client terminal.
        /// URL: http://mm.l/mql4/docs.mql4.com/chart_operations/chartfirst.html
        /// </summary>
        public long ChartFirst()
        {
            List<Object> parameters = new List<Object>();
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.ChartFirst_1, parameters); // MQLCommand ENUM = 71
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (long)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: ChartNext
        /// Description: Returns the chart ID of the chart next to the specified one.
        /// URL: http://mm.l/mql4/docs.mql4.com/chart_operations/chartnext.html
        /// </summary>
        /// <param name="chart_id">[in] Chart ID. 0 does not mean the current chart. 0 means "return the first chart ID".</param>
        public long ChartNext(long chart_id)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(chart_id);
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.ChartNext_1, parameters); // MQLCommand ENUM = 72
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (long)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: ChartClose
        /// Description: Closes the specified chart.
        /// URL: http://mm.l/mql4/docs.mql4.com/chart_operations/chartclose.html
        /// </summary>
        /// <param name="chart_id">[in] Chart ID. 0 means the current chart.</param>
        public bool ChartClose(long chart_id)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(chart_id);
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.ChartClose_1, parameters); // MQLCommand ENUM = 73
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (bool)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: ChartSymbol
        /// Description: Returns the symbol name for the specified chart.
        /// URL: http://mm.l/mql4/docs.mql4.com/chart_operations/chartsymbol.html
        /// </summary>
        /// <param name="chart_id">[in] Chart ID. 0 means the current chart.</param>
        public string ChartSymbol(long chart_id)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(chart_id);
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.ChartSymbol_1, parameters); // MQLCommand ENUM = 74
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (string)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: ChartRedraw
        /// Description: This function calls a forced redrawing of a specified chart.
        /// URL: http://mm.l/mql4/docs.mql4.com/chart_operations/chartredraw.html
        /// </summary>
        /// <param name="chart_id">[in] Chart ID. 0 means the current chart.</param>
        public void ChartRedraw(long chart_id)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(chart_id);
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.ChartRedraw_1, parameters); // MQLCommand ENUM = 75
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
        }

        /// <summary>
        /// Function: ChartSetDouble
        /// Description: Sets a value for a corresponding property of the specified chart. Chart property should be of a
        /// URL: http://mm.l/mql4/docs.mql4.com/chart_operations/chartsetdouble.html
        /// </summary>
        /// <param name="chart_id">[in] Chart ID. 0 means the current chart.</param>
        /// <param name="prop_id">[in] Chart property ID. Can be one of the values (except the read-only properties).</param>
        /// <param name="value">[in] Property value.</param>
        public bool ChartSetDouble(long chart_id, int prop_id, double value)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(chart_id);
            parameters.Add(prop_id);
            parameters.Add(value);
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.ChartSetDouble_1, parameters); // MQLCommand ENUM = 76
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (bool)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: ChartSetInteger
        /// Description: Sets a value for a corresponding property of the specified chart. Chart property must be
        /// URL: http://mm.l/mql4/docs.mql4.com/chart_operations/chartsetinteger.html
        /// </summary>
        /// <param name="chart_id">[in] Chart ID. 0 means the current chart.</param>
        /// <param name="prop_id">[in] Chart property ID. It can be one of the value (except the read-only properties).</param>
        /// <param name="value">[in] Property value.</param>
        public bool ChartSetInteger(long chart_id, int prop_id, long value)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(chart_id);
            parameters.Add(prop_id);
            parameters.Add(value);
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.ChartSetInteger_1, parameters); // MQLCommand ENUM = 77
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (bool)MQLCommandManager.getInstance().GetCommandResult();
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
        public bool ChartSetInteger(long chart_id, int property_id, uint sub_window, long value)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(chart_id);
            parameters.Add(property_id);
            parameters.Add(sub_window);
            parameters.Add(value);
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.ChartSetInteger_2, parameters); // MQLCommand ENUM = 77
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (bool)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: ChartSetString
        /// Description: Sets a value for a corresponding property of the specified chart. Chart property must be of the string type. The command is added to chart message queue and executed only after all previous commands have been processed.
        /// URL: http://mm.l/mql4/docs.mql4.com/chart_operations/chartsetstring.html
        /// </summary>
        /// <param name="chart_id">[in] Chart ID. 0 means the current chart.</param>
        /// <param name="prop_id">[in] Chart property ID. Its value can be one of the values (except the read-only properties).</param>
        /// <param name="str_value">[in] Property value string. String length cannot exceed 2045 characters (extra characters will be truncated).</param>
        public bool ChartSetString(long chart_id, int prop_id, string str_value)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(chart_id);
            parameters.Add(prop_id);
            parameters.Add(str_value);
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.ChartSetString_1, parameters); // MQLCommand ENUM = 78
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (bool)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: ChartNavigate
        /// Description: Performs shift of the specified chart by the specified number of bars relative to the specified position in the chart. The command is added to chart message queue and executed only after all previous commands have been processed.
        /// URL: http://mm.l/mql4/docs.mql4.com/chart_operations/chartnavigate.html
        /// </summary>
        /// <param name="chart_id">[in] Chart ID. 0 means the current chart.</param>
        /// <param name="position">[in] Chart position to perform a shift. Can be one of the values.</param>
        /// <param name="shift">[in] Number of bars to shift the chart. Positive value means the right shift (to the end of chart), negative value means the left shift (to the beginning of chart). The zero shift can be used to navigate to the beginning or end of chart.</param>
        public bool ChartNavigate(long chart_id, int position, int shift)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(chart_id);
            parameters.Add(position);
            parameters.Add(shift);
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.ChartNavigate_1, parameters); // MQLCommand ENUM = 79
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (bool)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: ChartID
        /// Description: Returns the ID of the current chart.
        /// URL: http://mm.l/mql4/docs.mql4.com/chart_operations/chartid.html
        /// </summary>
        public long ChartID()
        {
            List<Object> parameters = new List<Object>();
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.ChartID_1, parameters); // MQLCommand ENUM = 80
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (long)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: ChartIndicatorDelete
        /// Description: Removes an indicator with a specified name from the specified chart window. The command is added to chart message queue and executed only after all previous commands have been processed.
        /// URL: http://mm.l/mql4/docs.mql4.com/chart_operations/chartindicatordelete.html
        /// </summary>
        /// <param name="chart_id">[in] Chart ID. 0 denotes the current chart.</param>
        /// <param name="sub_window">[in] Number of the chart subwindow. 0 denotes the main chart subwindow.</param>
        /// <param name="indicator_shortname"></param>
        public bool ChartIndicatorDelete(long chart_id, int sub_window, string indicator_shortname)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(chart_id);
            parameters.Add(sub_window);
            parameters.Add(indicator_shortname);
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.ChartIndicatorDelete_1, parameters); // MQLCommand ENUM = 81
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (bool)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: ChartIndicatorName
        /// Description: Returns the short name of the indicator by the number in the indicators list on the specified chart window.
        /// URL: http://mm.l/mql4/docs.mql4.com/chart_operations/chartindicatorname.html
        /// </summary>
        /// <param name="chart_id">[in] Chart ID. 0 denotes the current chart.</param>
        /// <param name="sub_window">[in] Number of the chart subwindow. 0 denotes the main chart subwindow.</param>
        /// <param name="index">[in] the index of the indicator in the list of indicators. The numeration of indicators start with zero, i.e. the first indicator in the list has the 0 index. To obtain the number of indicators in the list use the function.</param>
        public string ChartIndicatorName(long chart_id, int sub_window, int index)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(chart_id);
            parameters.Add(sub_window);
            parameters.Add(index);
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.ChartIndicatorName_1, parameters); // MQLCommand ENUM = 82
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (string)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: ChartIndicatorsTotal
        /// Description: Returns the number of all indicators applied to the specified chart window.
        /// URL: http://mm.l/mql4/docs.mql4.com/chart_operations/chartindicatorstotal.html
        /// </summary>
        /// <param name="chart_id">[in] Chart ID. 0 denotes the current chart.</param>
        /// <param name="sub_window">[in] Number of the chart subwindow. 0 denotes the main chart subwindow.</param>
        public int ChartIndicatorsTotal(long chart_id, int sub_window)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(chart_id);
            parameters.Add(sub_window);
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.ChartIndicatorsTotal_1, parameters); // MQLCommand ENUM = 83
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (int)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: ChartWindowOnDropped
        /// Description: Returns the number (index) of the chart subwindow the Expert Advisor or script has been dropped to. 0 means the main chart window.
        /// URL: http://mm.l/mql4/docs.mql4.com/chart_operations/chartwindowondropped.html
        /// </summary>
        public int ChartWindowOnDropped()
        {
            List<Object> parameters = new List<Object>();
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.ChartWindowOnDropped_1, parameters); // MQLCommand ENUM = 84
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (int)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: ChartPriceOnDropped
        /// Description: Returns the price coordinate corresponding to the chart point the Expert Advisor or script has been dropped to.
        /// URL: http://mm.l/mql4/docs.mql4.com/chart_operations/chartpriceondropped.html
        /// </summary>
        public double ChartPriceOnDropped()
        {
            List<Object> parameters = new List<Object>();
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.ChartPriceOnDropped_1, parameters); // MQLCommand ENUM = 85
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (double)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: ChartTimeOnDropped
        /// Description: Returns the time coordinate corresponding to the chart point the Expert Advisor or script has been dropped to.
        /// URL: http://mm.l/mql4/docs.mql4.com/chart_operations/charttimeondropped.html
        /// </summary>
        public DateTime ChartTimeOnDropped()
        {
            List<Object> parameters = new List<Object>();
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.ChartTimeOnDropped_1, parameters); // MQLCommand ENUM = 86
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (DateTime)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: ChartXOnDropped
        /// Description: Returns the X coordinate of the chart point the Expert Advisor or script has been dropped to.
        /// URL: http://mm.l/mql4/docs.mql4.com/chart_operations/chartxondropped.html
        /// </summary>
        public int ChartXOnDropped()
        {
            List<Object> parameters = new List<Object>();
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.ChartXOnDropped_1, parameters); // MQLCommand ENUM = 87
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (int)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: ChartYOnDropped
        /// Description: Returns the Y coordinateof the chart point the Expert Advisor or script has been dropped to.
        /// URL: http://mm.l/mql4/docs.mql4.com/chart_operations/chartyondropped.html
        /// </summary>
        public int ChartYOnDropped()
        {
            List<Object> parameters = new List<Object>();
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.ChartYOnDropped_1, parameters); // MQLCommand ENUM = 88
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (int)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: ChartSetSymbolPeriod
        /// Description: Changes the symbol and period of the specified chart. The function is asynchronous, i.e. it sends the command and does not wait for its execution completion. The command is added to chart message queue and executed only after all previous commands have been processed.
        /// URL: http://mm.l/mql4/docs.mql4.com/chart_operations/chartsetsymbolperiod.html
        /// </summary>
        /// <param name="chart_id">[in] Chart ID. 0 means the current chart.</param>
        /// <param name="symbol">[in] Chart symbol. value means the current chart symbol (Expert Advisor is attached to)</param>
        /// <param name="period">[in] Chart period (timeframe). Can be one of the values. 0 means the current chart period.</param>
        public bool ChartSetSymbolPeriod(long chart_id, string symbol, TIMEFRAME period)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(chart_id);
            parameters.Add(symbol);
            parameters.Add(period.ToString());
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.ChartSetSymbolPeriod_1, parameters); // MQLCommand ENUM = 89
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (bool)MQLCommandManager.getInstance().GetCommandResult();
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
        public bool ChartScreenShot(long chart_id, string filename, int width, int height, ENUM_ALIGN_MODE align_mode)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(chart_id);
            parameters.Add(filename);
            parameters.Add(width);
            parameters.Add(height);
            parameters.Add(align_mode.ToString());
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.ChartScreenShot_1, parameters); // MQLCommand ENUM = 90
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (bool)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: WindowBarsPerChart
        /// Description: Returns the amount of bars visible on the chart.
        /// URL: http://mm.l/mql4/docs.mql4.com/chart_operations/windowbarsperchart.html
        /// </summary>
        public int WindowBarsPerChart()
        {
            List<Object> parameters = new List<Object>();
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.WindowBarsPerChart_1, parameters); // MQLCommand ENUM = 91
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (int)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: WindowExpertName
        /// Description: Returns the name of the executed Expert Advisor, script, custom indicator, or library.
        /// URL: http://mm.l/mql4/docs.mql4.com/chart_operations/windowexpertname.html
        /// </summary>
        public string WindowExpertName()
        {
            List<Object> parameters = new List<Object>();
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.WindowExpertName_1, parameters); // MQLCommand ENUM = 92
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (string)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: WindowFind
        /// Description: Returns the window index containing this specified indicator.
        /// URL: http://mm.l/mql4/docs.mql4.com/chart_operations/windowfind.html
        /// </summary>
        /// <param name="name">[in] Indicator short name.</param>
        public int WindowFind(string name)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(name);
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.WindowFind_1, parameters); // MQLCommand ENUM = 93
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (int)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: WindowFirstVisibleBar
        /// Description: Returns index of the first visible bar in the current chart window.
        /// URL: http://mm.l/mql4/docs.mql4.com/chart_operations/windowfirstvisiblebar.html
        /// </summary>
        public int WindowFirstVisibleBar()
        {
            List<Object> parameters = new List<Object>();
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.WindowFirstVisibleBar_1, parameters); // MQLCommand ENUM = 94
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (int)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: WindowHandle
        /// Description: Returns the system handle of the chart window.
        /// URL: http://mm.l/mql4/docs.mql4.com/chart_operations/windowhandle.html
        /// </summary>
        /// <param name="symbol">[in] Symbol.</param>
        /// <param name="timeframe">[in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</param>
        public int WindowHandle(string symbol, int timeframe)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(symbol);
            parameters.Add(timeframe);
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.WindowHandle_1, parameters); // MQLCommand ENUM = 95
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (int)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: WindowIsVisible
        /// Description: Returns the visibility flag of the chart subwindow.
        /// URL: http://mm.l/mql4/docs.mql4.com/chart_operations/windowisvisible.html
        /// </summary>
        /// <param name="index">[in] Subwindow index.</param>
        public int WindowIsVisible(int index)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(index);
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.WindowIsVisible_1, parameters); // MQLCommand ENUM = 96
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (int)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: WindowOnDropped
        /// Description: Returns the window index where Expert Advisor, custom indicator or script was dropped.
        /// URL: http://mm.l/mql4/docs.mql4.com/chart_operations/windowondropped.html
        /// </summary>
        public int WindowOnDropped()
        {
            List<Object> parameters = new List<Object>();
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.WindowOnDropped_1, parameters); // MQLCommand ENUM = 97
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (int)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: WindowPriceMax
        /// Description: Returns the maximal value of the vertical scale of the specified subwindow of the current chart.
        /// URL: http://mm.l/mql4/docs.mql4.com/chart_operations/windowpricemax.html
        /// </summary>
        /// <param name="index">[in] Chart subwindow index (0 - main chart window).</param>
        public int WindowPriceMax(int index)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(index);
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.WindowPriceMax_1, parameters); // MQLCommand ENUM = 98
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (int)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: WindowPriceMin
        /// Description: Returns the minimal value of the vertical scale of the specified subwindow of the current chart.
        /// URL: http://mm.l/mql4/docs.mql4.com/chart_operations/windowpricemin.html
        /// </summary>
        /// <param name="index">[in] Chart subwindow index (0 - main chart window).</param>
        public int WindowPriceMin(int index)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(index);
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.WindowPriceMin_1, parameters); // MQLCommand ENUM = 99
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (int)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: WindowPriceOnDropped
        /// Description: Returns the price of the chart point where Expert Advisor or script was dropped.
        /// URL: http://mm.l/mql4/docs.mql4.com/chart_operations/windowpriceondropped.html
        /// </summary>
        public double WindowPriceOnDropped()
        {
            List<Object> parameters = new List<Object>();
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.WindowPriceOnDropped_1, parameters); // MQLCommand ENUM = 100
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (double)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: WindowRedraw
        /// Description: Redraws the current chart forcedly.
        /// URL: http://mm.l/mql4/docs.mql4.com/chart_operations/windowredraw.html
        /// </summary>
        public void WindowRedraw()
        {
            List<Object> parameters = new List<Object>();
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.WindowRedraw_1, parameters); // MQLCommand ENUM = 101
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
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
        public bool WindowScreenShot(string filename, int size_x, int size_y, int start_bar, int chart_scale, int chart_mode)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(filename);
            parameters.Add(size_x);
            parameters.Add(size_y);
            parameters.Add(start_bar);
            parameters.Add(chart_scale);
            parameters.Add(chart_mode);
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.WindowScreenShot_1, parameters); // MQLCommand ENUM = 102
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (bool)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: WindowTimeOnDropped
        /// Description: Returns the time of the chart point where Expert Advisor or script was dropped.
        /// URL: http://mm.l/mql4/docs.mql4.com/chart_operations/windowtimeondropped.html
        /// </summary>
        public DateTime WindowTimeOnDropped()
        {
            List<Object> parameters = new List<Object>();
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.WindowTimeOnDropped_1, parameters); // MQLCommand ENUM = 103
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (DateTime)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: WindowsTotal
        /// Description: Returns total number of indicator windows on the chart.
        /// URL: http://mm.l/mql4/docs.mql4.com/chart_operations/windowstotal.html
        /// </summary>
        public int WindowsTotal()
        {
            List<Object> parameters = new List<Object>();
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.WindowsTotal_1, parameters); // MQLCommand ENUM = 104
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (int)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: WindowXOnDropped
        /// Description: Returns the value at X axis in pixels for the chart window client area point at which the Expert Advisor or script was dropped.
        /// URL: http://mm.l/mql4/docs.mql4.com/chart_operations/windowxondropped.html
        /// </summary>
        public int WindowXOnDropped()
        {
            List<Object> parameters = new List<Object>();
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.WindowXOnDropped_1, parameters); // MQLCommand ENUM = 105
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (int)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: WindowYOnDropped
        /// Description: Returns the value at Y axis in pixels for the chart window client area point at which the Expert Advisor or script was dropped.
        /// URL: http://mm.l/mql4/docs.mql4.com/chart_operations/windowyondropped.html
        /// </summary>
        public int WindowYOnDropped()
        {
            List<Object> parameters = new List<Object>();
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.WindowYOnDropped_1, parameters); // MQLCommand ENUM = 106
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (int)MQLCommandManager.getInstance().GetCommandResult();
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
        public bool OrderClose(int ticket, double lots, double price, int slippage, COLOR arrow_color)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(ticket);
            parameters.Add(lots);
            parameters.Add(price);
            parameters.Add(slippage);
            parameters.Add(arrow_color);
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.OrderClose_1, parameters); // MQLCommand ENUM = 107
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (bool)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: OrderCloseBy
        /// Description: Closes an opened order by another opposite opened order.
        /// URL: http://mm.l/mql4/docs.mql4.com/trading/ordercloseby.html
        /// </summary>
        /// <param name="ticket">[in] Unique number of the order ticket.</param>
        /// <param name="opposite">[in] Unique number of the opposite order ticket.</param>
        /// <param name="arrow_color">[in] Color of the closing arrow on the chart. If the parameter is missing or has CLR_NONE value closing arrow will not be drawn on the chart.</param>
        public bool OrderCloseBy(int ticket, int opposite, COLOR arrow_color)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(ticket);
            parameters.Add(opposite);
            parameters.Add(arrow_color);
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.OrderCloseBy_1, parameters); // MQLCommand ENUM = 108
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (bool)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: OrderClosePrice
        /// Description: Returns close price of the currently selected order.
        /// URL: http://mm.l/mql4/docs.mql4.com/trading/ordercloseprice.html
        /// </summary>
        public double OrderClosePrice()
        {
            List<Object> parameters = new List<Object>();
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.OrderClosePrice_1, parameters); // MQLCommand ENUM = 109
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (double)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: OrderCloseTime
        /// Description: Returns close time of the currently selected order.
        /// URL: http://mm.l/mql4/docs.mql4.com/trading/orderclosetime.html
        /// </summary>
        public DateTime OrderCloseTime()
        {
            List<Object> parameters = new List<Object>();
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.OrderCloseTime_1, parameters); // MQLCommand ENUM = 110
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (DateTime)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: OrderComment
        /// Description: Returns comment of the currently selected order.
        /// URL: http://mm.l/mql4/docs.mql4.com/trading/ordercomment.html
        /// </summary>
        public string OrderComment()
        {
            List<Object> parameters = new List<Object>();
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.OrderComment_1, parameters); // MQLCommand ENUM = 111
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (string)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: OrderCommission
        /// Description: Returns calculated commission of the currently selected order.
        /// URL: http://mm.l/mql4/docs.mql4.com/trading/ordercommission.html
        /// </summary>
        public double OrderCommission()
        {
            List<Object> parameters = new List<Object>();
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.OrderCommission_1, parameters); // MQLCommand ENUM = 112
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (double)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: OrderDelete
        /// Description: Deletes previously opened pending order.
        /// URL: http://mm.l/mql4/docs.mql4.com/trading/orderdelete.html
        /// </summary>
        /// <param name="ticket">[in] Unique number of the order ticket.</param>
        /// <param name="arrow_color">[in] Color of the arrow on the chart. If the parameter is missing or has CLR_NONE value arrow will not be drawn on the chart.</param>
        public bool OrderDelete(int ticket, COLOR arrow_color)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(ticket);
            parameters.Add(arrow_color);
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.OrderDelete_1, parameters); // MQLCommand ENUM = 113
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (bool)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: OrderExpiration
        /// Description: Returns expiration date of the selected pending order.
        /// URL: http://mm.l/mql4/docs.mql4.com/trading/orderexpiration.html
        /// </summary>
        public DateTime OrderExpiration()
        {
            List<Object> parameters = new List<Object>();
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.OrderExpiration_1, parameters); // MQLCommand ENUM = 114
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (DateTime)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: OrderLots
        /// Description: Returns amount of lots of the selected order.
        /// URL: http://mm.l/mql4/docs.mql4.com/trading/orderlots.html
        /// </summary>
        public double OrderLots()
        {
            List<Object> parameters = new List<Object>();
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.OrderLots_1, parameters); // MQLCommand ENUM = 115
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (double)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: OrderMagicNumber
        /// Description: Returns an identifying (magic) number of the currently selected order.
        /// URL: http://mm.l/mql4/docs.mql4.com/trading/ordermagicnumber.html
        /// </summary>
        public int OrderMagicNumber()
        {
            List<Object> parameters = new List<Object>();
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.OrderMagicNumber_1, parameters); // MQLCommand ENUM = 116
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (int)MQLCommandManager.getInstance().GetCommandResult();
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
        public bool OrderModify(int ticket, double price, double stoploss, double takeprofit, DateTime expiration, COLOR arrow_color)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(ticket);
            parameters.Add(price);
            parameters.Add(stoploss);
            parameters.Add(takeprofit);
            parameters.Add(expiration);
            parameters.Add(arrow_color);
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.OrderModify_1, parameters); // MQLCommand ENUM = 117
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (bool)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: OrderOpenPrice
        /// Description: Returns open price of the currently selected order.
        /// URL: http://mm.l/mql4/docs.mql4.com/trading/orderopenprice.html
        /// </summary>
        public double OrderOpenPrice()
        {
            List<Object> parameters = new List<Object>();
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.OrderOpenPrice_1, parameters); // MQLCommand ENUM = 118
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (double)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: OrderOpenTime
        /// Description: Returns open time of the currently selected order.
        /// URL: http://mm.l/mql4/docs.mql4.com/trading/orderopentime.html
        /// </summary>
        public DateTime OrderOpenTime()
        {
            List<Object> parameters = new List<Object>();
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.OrderOpenTime_1, parameters); // MQLCommand ENUM = 119
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (DateTime)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: OrderPrint
        /// Description: Prints information about the selected order in the log.
        /// URL: http://mm.l/mql4/docs.mql4.com/trading/orderprint.html
        /// </summary>
        public void OrderPrint()
        {
            List<Object> parameters = new List<Object>();
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.OrderPrint_1, parameters); // MQLCommand ENUM = 120
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
        }

        /// <summary>
        /// Function: OrderProfit
        /// Description: Returns profit of the currently selected order.
        /// URL: http://mm.l/mql4/docs.mql4.com/trading/orderprofit.html
        /// </summary>
        public double OrderProfit()
        {
            List<Object> parameters = new List<Object>();
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.OrderProfit_1, parameters); // MQLCommand ENUM = 121
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (double)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: OrderSelect
        /// Description: The function selects an order for further processing.
        /// URL: http://mm.l/mql4/docs.mql4.com/trading/orderselect.html
        /// </summary>
        /// <param name="index"></param>
        /// <param name="select">[in] Selecting flags. It can be any of the following values:</param>
        /// <param name="pool">SELECT_BY_POS - index in the order pool, SELECT_BY_TICKET - index is order ticket.</param>
        public bool OrderSelect(int index, int select, int pool)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(index);
            parameters.Add(select);
            parameters.Add(pool);
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.OrderSelect_1, parameters); // MQLCommand ENUM = 122
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (bool)MQLCommandManager.getInstance().GetCommandResult();
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
        public int OrderSend(string symbol, int cmd, double volume, double price, int slippage, double stoploss, double takeprofit, string comment, int magic, DateTime expiration, COLOR arrow_color)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(symbol);
            parameters.Add(cmd);
            parameters.Add(volume);
            parameters.Add(price);
            parameters.Add(slippage);
            parameters.Add(stoploss);
            parameters.Add(takeprofit);
            parameters.Add(comment);
            parameters.Add(magic);
            parameters.Add(expiration);
            parameters.Add(arrow_color);
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.OrderSend_1, parameters); // MQLCommand ENUM = 123
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (int)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: OrdersHistoryTotal
        /// Description: Returns the number of closed orders in the account history loaded into the terminal.
        /// URL: http://mm.l/mql4/docs.mql4.com/trading/ordershistorytotal.html
        /// </summary>
        public int OrdersHistoryTotal()
        {
            List<Object> parameters = new List<Object>();
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.OrdersHistoryTotal_1, parameters); // MQLCommand ENUM = 124
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (int)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: OrderStopLoss
        /// Description: Returns stop loss value of the currently selected order.
        /// URL: http://mm.l/mql4/docs.mql4.com/trading/orderstoploss.html
        /// </summary>
        public double OrderStopLoss()
        {
            List<Object> parameters = new List<Object>();
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.OrderStopLoss_1, parameters); // MQLCommand ENUM = 125
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (double)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: OrdersTotal
        /// Description: Returns the number of market and pending orders.
        /// URL: http://mm.l/mql4/docs.mql4.com/trading/orderstotal.html
        /// </summary>
        public int OrdersTotal()
        {
            List<Object> parameters = new List<Object>();
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.OrdersTotal_1, parameters); // MQLCommand ENUM = 126
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (int)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: OrderSwap
        /// Description: Returns swap value of the currently selected order.
        /// URL: http://mm.l/mql4/docs.mql4.com/trading/orderswap.html
        /// </summary>
        public double OrderSwap()
        {
            List<Object> parameters = new List<Object>();
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.OrderSwap_1, parameters); // MQLCommand ENUM = 127
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (double)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: OrderSymbol
        /// Description: Returns symbol name of the currently selected order.
        /// URL: http://mm.l/mql4/docs.mql4.com/trading/ordersymbol.html
        /// </summary>
        public string OrderSymbol()
        {
            List<Object> parameters = new List<Object>();
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.OrderSymbol_1, parameters); // MQLCommand ENUM = 128
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (string)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: OrderTakeProfit
        /// Description: Returns take profit value of the currently selected order.
        /// URL: http://mm.l/mql4/docs.mql4.com/trading/ordertakeprofit.html
        /// </summary>
        public double OrderTakeProfit()
        {
            List<Object> parameters = new List<Object>();
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.OrderTakeProfit_1, parameters); // MQLCommand ENUM = 129
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (double)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: OrderTicket
        /// Description: Returns ticket number of the currently selected order.
        /// URL: http://mm.l/mql4/docs.mql4.com/trading/orderticket.html
        /// </summary>
        public int OrderTicket()
        {
            List<Object> parameters = new List<Object>();
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.OrderTicket_1, parameters); // MQLCommand ENUM = 130
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (int)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: OrderType
        /// Description: Returns order operation type of the currently selected order.
        /// URL: http://mm.l/mql4/docs.mql4.com/trading/ordertype.html
        /// </summary>
        public int OrderType()
        {
            List<Object> parameters = new List<Object>();
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.OrderType_1, parameters); // MQLCommand ENUM = 131
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (int)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: SignalBaseGetDouble
        /// Description: Returns the value of
        /// URL: http://mm.l/mql4/docs.mql4.com/signals/signalbasegetdouble.html
        /// </summary>
        /// <param name="property_id">[in] Signal property identifier. The value can be one of the values of the enumeration.</param>
        public double SignalBaseGetDouble(ENUM_SIGNAL_BASE_DOUBLE property_id)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(property_id.ToString());
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.SignalBaseGetDouble_1, parameters); // MQLCommand ENUM = 132
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (double)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: SignalBaseGetInteger
        /// Description: Returns the value of
        /// URL: http://mm.l/mql4/docs.mql4.com/signals/signalbasegetinteger.html
        /// </summary>
        /// <param name="property_id">[in] Signal property identifier. The value can be one of the values of the enumeration.</param>
        public long SignalBaseGetInteger(ENUM_SIGNAL_BASE_INTEGER property_id)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(property_id.ToString());
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.SignalBaseGetInteger_1, parameters); // MQLCommand ENUM = 133
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (long)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: SignalBaseGetString
        /// Description: Returns the value of
        /// URL: http://mm.l/mql4/docs.mql4.com/signals/signalbasegetstring.html
        /// </summary>
        /// <param name="property_id">[in] Signal property identifier. The value can be one of the values of the enumeration.</param>
        public string SignalBaseGetString(ENUM_SIGNAL_BASE_STRING property_id)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(property_id.ToString());
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.SignalBaseGetString_1, parameters); // MQLCommand ENUM = 134
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (string)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: SignalBaseSelect
        /// Description: Selects a signal from signals, available in terminal for further working with it.
        /// URL: http://mm.l/mql4/docs.mql4.com/signals/signalbaseselect.html
        /// </summary>
        /// <param name="index">[in] Signal index in base of trading signals.</param>
        public bool SignalBaseSelect(int index)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(index);
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.SignalBaseSelect_1, parameters); // MQLCommand ENUM = 135
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (bool)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: SignalBaseTotal
        /// Description: Returns the total amount of signals, available in terminal.
        /// URL: http://mm.l/mql4/docs.mql4.com/signals/signalbasetotal.html
        /// </summary>
        public int SignalBaseTotal()
        {
            List<Object> parameters = new List<Object>();
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.SignalBaseTotal_1, parameters); // MQLCommand ENUM = 136
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (int)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: SignalInfoGetDouble
        /// Description: Returns the value of
        /// URL: http://mm.l/mql4/docs.mql4.com/signals/signalinfogetdouble.html
        /// </summary>
        /// <param name="property_id">[in] Signal copy settings property identifier. The value can be one of the values of the enumeration.</param>
        public double SignalInfoGetDouble(ENUM_SIGNAL_INFO_DOUBLE property_id)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(property_id.ToString());
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.SignalInfoGetDouble_1, parameters); // MQLCommand ENUM = 137
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (double)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: SignalInfoGetInteger
        /// Description: Returns the value of
        /// URL: http://mm.l/mql4/docs.mql4.com/signals/signalinfogetinteger.html
        /// </summary>
        /// <param name="property_id">[in] Signal copy settings property identifier. The value can be one of the values of the enumeration.</param>
        public long SignalInfoGetInteger(ENUM_SIGNAL_INFO_INTEGER property_id)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(property_id.ToString());
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.SignalInfoGetInteger_1, parameters); // MQLCommand ENUM = 138
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (long)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: SignalInfoGetString
        /// Description: Returns the value of
        /// URL: http://mm.l/mql4/docs.mql4.com/signals/signalinfogetstring.html
        /// </summary>
        /// <param name="property_id">[in] Signal copy settings property identifier. The value can be one of the values of the enumeration.</param>
        public string SignalInfoGetString(ENUM_SIGNAL_INFO_STRING property_id)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(property_id.ToString());
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.SignalInfoGetString_1, parameters); // MQLCommand ENUM = 139
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (string)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: SignalInfoSetDouble
        /// Description: Sets the value of
        /// URL: http://mm.l/mql4/docs.mql4.com/signals/signalinfosetdouble.html
        /// </summary>
        /// <param name="property_id">[in] Signal copy settings property identifier. The value can be one of the values of the enumeration.</param>
        /// <param name="value">[in] The value of signal copy settings property.</param>
        public bool SignalInfoSetDouble(ENUM_SIGNAL_INFO_DOUBLE property_id, double value)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(property_id.ToString());
            parameters.Add(value);
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.SignalInfoSetDouble_1, parameters); // MQLCommand ENUM = 140
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (bool)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: SignalInfoSetInteger
        /// Description: Sets the value of
        /// URL: http://mm.l/mql4/docs.mql4.com/signals/signalinfosetinteger.html
        /// </summary>
        /// <param name="property_id">[in] Signal copy settings property identifier. The value can be one of the values of the enumeration.</param>
        /// <param name="value">[in] The value of signal copy settings property.</param>
        public bool SignalInfoSetInteger(ENUM_SIGNAL_INFO_INTEGER property_id, long value)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(property_id.ToString());
            parameters.Add(value);
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.SignalInfoSetInteger_1, parameters); // MQLCommand ENUM = 141
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (bool)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: SignalSubscribe
        /// Description: Subscribes to the trading signal.
        /// URL: http://mm.l/mql4/docs.mql4.com/signals/signalsubscribe.html
        /// </summary>
        /// <param name="signal_id">[in] Signal identifier.</param>
        public bool SignalSubscribe(long signal_id)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(signal_id);
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.SignalSubscribe_1, parameters); // MQLCommand ENUM = 142
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (bool)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: SignalUnsubscribe
        /// Description: Cancels subscription.
        /// URL: http://mm.l/mql4/docs.mql4.com/signals/signalunsubscribe.html
        /// </summary>
        public bool SignalUnsubscribe()
        {
            List<Object> parameters = new List<Object>();
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.SignalUnsubscribe_1, parameters); // MQLCommand ENUM = 143
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (bool)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: GlobalVariableCheck
        /// Description: Checks the existence of a global variable with the specified name
        /// URL: http://mm.l/mql4/docs.mql4.com/globals/globalvariablecheck.html
        /// </summary>
        /// <param name="name">[in] Global variable name.</param>
        public bool GlobalVariableCheck(string name)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(name);
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.GlobalVariableCheck_1, parameters); // MQLCommand ENUM = 144
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (bool)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: GlobalVariableTime
        /// Description: Returns the time when the global variable was last accessed.
        /// URL: http://mm.l/mql4/docs.mql4.com/globals/globalvariabletime.html
        /// </summary>
        /// <param name="name">[in] Name of the global variable.</param>
        public DateTime GlobalVariableTime(string name)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(name);
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.GlobalVariableTime_1, parameters); // MQLCommand ENUM = 145
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (DateTime)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: GlobalVariableDel
        /// Description: Deletes a global variable from the client terminal
        /// URL: http://mm.l/mql4/docs.mql4.com/globals/globalvariabledel.html
        /// </summary>
        /// <param name="name">[in] Global variable name.</param>
        public bool GlobalVariableDel(string name)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(name);
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.GlobalVariableDel_1, parameters); // MQLCommand ENUM = 146
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (bool)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: GlobalVariableGet
        /// Description: Returns the value of an existing global variable of the client terminal. There are 2 variants of the function.
        /// URL: http://mm.l/mql4/docs.mql4.com/globals/globalvariableget.html
        /// </summary>
        /// <param name="name">[in] Global variable name.</param>
        public double GlobalVariableGet(string name)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(name);
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.GlobalVariableGet_1, parameters); // MQLCommand ENUM = 147
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (double)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: GlobalVariableName
        /// Description: Returns the name of a global variable by its ordinal number.
        /// URL: http://mm.l/mql4/docs.mql4.com/globals/globalvariablename.html
        /// </summary>
        /// <param name="index">[in] Sequence number in the list of global variables. It should be greater than or equal to 0 and less than .</param>
        public string GlobalVariableName(int index)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(index);
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.GlobalVariableName_1, parameters); // MQLCommand ENUM = 148
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (string)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: GlobalVariableSet
        /// Description: Sets a new value for a global variable. If the variable does not exist, the system creates a new global variable.
        /// URL: http://mm.l/mql4/docs.mql4.com/globals/globalvariableset.html
        /// </summary>
        /// <param name="name">[in] Global variable name.</param>
        /// <param name="value">[in] The new numerical value.</param>
        public DateTime GlobalVariableSet(string name, double value)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(name);
            parameters.Add(value);
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.GlobalVariableSet_1, parameters); // MQLCommand ENUM = 149
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (DateTime)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: GlobalVariablesFlush
        /// Description: Forcibly saves contents of all global variables to a disk.
        /// URL: http://mm.l/mql4/docs.mql4.com/globals/globalvariablesflush.html
        /// </summary>
        public void GlobalVariablesFlush()
        {
            List<Object> parameters = new List<Object>();
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.GlobalVariablesFlush_1, parameters); // MQLCommand ENUM = 150
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
        }

        /// <summary>
        /// Function: GlobalVariableTemp
        /// Description: The function attempts to create a temporary global variable. If the variable doesn't exist, the system creates a new temporary global variable.
        /// URL: http://mm.l/mql4/docs.mql4.com/globals/globalvariabletemp.html
        /// </summary>
        /// <param name="name">[in] The name of a temporary global variable.</param>
        public bool GlobalVariableTemp(string name)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(name);
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.GlobalVariableTemp_1, parameters); // MQLCommand ENUM = 151
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (bool)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: GlobalVariableSetOnCondition
        /// Description: Sets the new value of the existing global variable if the current value equals to the third parameter check_value. If there is no global variable, the function will generate an error ERR_GLOBALVARIABLE_NOT_FOUND (4501) and return false.
        /// URL: http://mm.l/mql4/docs.mql4.com/globals/globalvariablesetoncondition.html
        /// </summary>
        /// <param name="name">[in] The name of a global variable.</param>
        /// <param name="value">[in] New value.</param>
        /// <param name="check_value">[in] The value to check the current value of the global variable.</param>
        public bool GlobalVariableSetOnCondition(string name, double value, double check_value)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(name);
            parameters.Add(value);
            parameters.Add(check_value);
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.GlobalVariableSetOnCondition_1, parameters); // MQLCommand ENUM = 152
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (bool)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: GlobalVariablesDeleteAll
        /// Description: Deletes global variables of the client terminal.
        /// URL: http://mm.l/mql4/docs.mql4.com/globals/globalvariablesdeleteall.html
        /// </summary>
        /// <param name="prefix_name">[in] Name prefix global variables to remove. If you specify a prefix NULL or empty string, then all variables that meet the data criterion will be deleted.</param>
        /// <param name="limit_data">[in] Optional parameter. Date to select global variables by the time of their last modification. The function removes global variables, which were changed before this date. If the parameter is zero, then all variables that meet the first criterion (prefix) are deleted.</param>
        public int GlobalVariablesDeleteAll(string prefix_name, DateTime limit_data)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(prefix_name);
            parameters.Add(limit_data);
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.GlobalVariablesDeleteAll_1, parameters); // MQLCommand ENUM = 153
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (int)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: GlobalVariablesTotal
        /// Description: Returns the total number of global variables of the client terminal.
        /// URL: http://mm.l/mql4/docs.mql4.com/globals/globalvariablestotal.html
        /// </summary>
        public int GlobalVariablesTotal()
        {
            List<Object> parameters = new List<Object>();
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.GlobalVariablesTotal_1, parameters); // MQLCommand ENUM = 154
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (int)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: HideTestIndicators
        /// Description: The function sets a flag hiding indicators called by the Expert Advisor.
        /// URL: http://mm.l/mql4/docs.mql4.com/customind/hidetestindicators.html
        /// </summary>
        /// <param name="hide">[in] Hiding flag.</param>
        public void HideTestIndicators(bool hide)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(hide);
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.HideTestIndicators_1, parameters); // MQLCommand ENUM = 155
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
        }

        /// <summary>
        /// Function: IndicatorSetDouble
        /// Description: The function sets the value of the corresponding indicator property. Indicator property must be of the double type. There are two variants of the function.
        /// URL: http://mm.l/mql4/docs.mql4.com/customind/indicatorsetdouble.html
        /// </summary>
        /// <param name="prop_id">[in] Identifier of the indicator property. The value can be one of the values of the enumeration.</param>
        /// <param name="prop_value">[in] Value of property.</param>
        public bool IndicatorSetDouble(int prop_id, double prop_value)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(prop_id);
            parameters.Add(prop_value);
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.IndicatorSetDouble_1, parameters); // MQLCommand ENUM = 156
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (bool)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: IndicatorSetDouble
        /// Description: The function sets the value of the corresponding indicator property. Indicator property must be of the double type. There are two variants of the function.
        /// URL: http://mm.l/mql4/docs.mql4.com/customind/indicatorsetdouble.html
        /// </summary>
        /// <param name="prop_id">[in] Identifier of the indicator property. The value can be one of the values of the enumeration.</param>
        /// <param name="prop_modifier">[in] Modifier of the specified property. Only level properties require a modifier. Numbering of levels starts from 0. It means that in order to set property for the second level you need to specify 1 (1 less than when using ).</param>
        /// <param name="prop_value">[in] Value of property.</param>
        public bool IndicatorSetDouble(int prop_id, int prop_modifier, double prop_value)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(prop_id);
            parameters.Add(prop_modifier);
            parameters.Add(prop_value);
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.IndicatorSetDouble_2, parameters); // MQLCommand ENUM = 156
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (bool)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: IndicatorSetInteger
        /// Description: The function sets the value of the corresponding indicator property. Indicator property must be of the int or color type. There are two variants of the function.
        /// URL: http://mm.l/mql4/docs.mql4.com/customind/indicatorsetinteger.html
        /// </summary>
        /// <param name="prop_id">[in] Identifier of the indicator property. The value can be one of the values of the enumeration.</param>
        /// <param name="prop_value">[in] Value of property.</param>
        public bool IndicatorSetInteger(int prop_id, int prop_value)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(prop_id);
            parameters.Add(prop_value);
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.IndicatorSetInteger_1, parameters); // MQLCommand ENUM = 157
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (bool)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: IndicatorSetInteger
        /// Description: The function sets the value of the corresponding indicator property. Indicator property must be of the int or color type. There are two variants of the function.
        /// URL: http://mm.l/mql4/docs.mql4.com/customind/indicatorsetinteger.html
        /// </summary>
        /// <param name="prop_id">[in] Identifier of the indicator property. The value can be one of the values of the enumeration.</param>
        /// <param name="prop_modifier">[in] Modifier of the specified property. Only level properties require a modifier.</param>
        /// <param name="prop_value">[in] Value of property.</param>
        public bool IndicatorSetInteger(int prop_id, int prop_modifier, int prop_value)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(prop_id);
            parameters.Add(prop_modifier);
            parameters.Add(prop_value);
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.IndicatorSetInteger_2, parameters); // MQLCommand ENUM = 157
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (bool)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: IndicatorSetString
        /// Description: The function sets the value of the corresponding indicator property. Indicator property must be of the string type. There are two variants of the function.
        /// URL: http://mm.l/mql4/docs.mql4.com/customind/indicatorsetstring.html
        /// </summary>
        /// <param name="prop_id">[in] Identifier of the indicator property. The value can be one of the values of the enumeration.</param>
        /// <param name="prop_value">[in] Value of property.</param>
        public bool IndicatorSetString(int prop_id, string prop_value)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(prop_id);
            parameters.Add(prop_value);
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.IndicatorSetString_1, parameters); // MQLCommand ENUM = 158
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (bool)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: IndicatorSetString
        /// Description: The function sets the value of the corresponding indicator property. Indicator property must be of the string type. There are two variants of the function.
        /// URL: http://mm.l/mql4/docs.mql4.com/customind/indicatorsetstring.html
        /// </summary>
        /// <param name="prop_id">[in] Identifier of the indicator property. The value can be one of the values of the enumeration.</param>
        /// <param name="prop_modifier">[in] Modifier of the specified property. Only level properties require a modifier.</param>
        /// <param name="prop_value">[in] Value of property.</param>
        public bool IndicatorSetString(int prop_id, int prop_modifier, string prop_value)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(prop_id);
            parameters.Add(prop_modifier);
            parameters.Add(prop_value);
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.IndicatorSetString_2, parameters); // MQLCommand ENUM = 158
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (bool)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: IndicatorBuffers
        /// Description: Allocates memory for buffers used for custom indicator calculations.
        /// URL: http://mm.l/mql4/docs.mql4.com/customind/indicatorbuffers.html
        /// </summary>
        /// <param name="count">[in] Amount of buffers to be allocated. Should be within the range between indicator_buffers and 512 buffers.</param>
        public bool IndicatorBuffers(int count)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(count);
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.IndicatorBuffers_1, parameters); // MQLCommand ENUM = 159
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (bool)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: IndicatorCounted
        /// Description: The function returns the amount of bars not changed after the indicator had been launched last.
        /// URL: http://mm.l/mql4/docs.mql4.com/customind/indicatorcounted.html
        /// </summary>
        public int IndicatorCounted()
        {
            List<Object> parameters = new List<Object>();
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.IndicatorCounted_1, parameters); // MQLCommand ENUM = 160
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (int)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: IndicatorDigits
        /// Description: Sets precision format (the count of digits after decimal point) to visualize indicator values.
        /// URL: http://mm.l/mql4/docs.mql4.com/customind/indicatordigits.html
        /// </summary>
        /// <param name="digits">[in] Precision format, the count of digits after decimal point.</param>
        public void IndicatorDigits(int digits)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(digits);
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.IndicatorDigits_1, parameters); // MQLCommand ENUM = 161
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
        }

        /// <summary>
        /// Function: IndicatorShortName
        /// Description: Sets the "short" name of a custom indicator to be shown in the DataWindow and in the chart subwindow.
        /// URL: http://mm.l/mql4/docs.mql4.com/customind/indicatorshortname.html
        /// </summary>
        /// <param name="name">[in] New short name.</param>
        public void IndicatorShortName(string name)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(name);
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.IndicatorShortName_1, parameters); // MQLCommand ENUM = 162
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
        }

        /// <summary>
        /// Function: SetIndexArrow
        /// Description: Sets an arrow symbol for indicators line of the DRAW_ARROW type.
        /// URL: http://mm.l/mql4/docs.mql4.com/customind/setindexarrow.html
        /// </summary>
        /// <param name="index">[in] Line index. Must lie between 0 and 7.</param>
        /// <param name="code">[in] Symbol code from or predefined .</param>
        public void SetIndexArrow(int index, int code)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(index);
            parameters.Add(code);
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.SetIndexArrow_1, parameters); // MQLCommand ENUM = 163
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
        }

        /// <summary>
        /// Function: SetIndexDrawBegin
        /// Description: Sets the bar number (from the data beginning) from which the drawing of the given indicator line must start.
        /// URL: http://mm.l/mql4/docs.mql4.com/customind/setindexdrawbegin.html
        /// </summary>
        /// <param name="index">[in] Line index. Must lie between 0 and 7.</param>
        /// <param name="begin">[in] First drawing bar position number.</param>
        public void SetIndexDrawBegin(int index, int begin)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(index);
            parameters.Add(begin);
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.SetIndexDrawBegin_1, parameters); // MQLCommand ENUM = 164
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
        }

        /// <summary>
        /// Function: SetIndexEmptyValue
        /// Description: Sets drawing line empty value.
        /// URL: http://mm.l/mql4/docs.mql4.com/customind/setindexemptyvalue.html
        /// </summary>
        /// <param name="index">[in] Line index. Must lie between 0 and 7.</param>
        /// <param name="value">[in] New "empty" value.</param>
        public void SetIndexEmptyValue(int index, double value)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(index);
            parameters.Add(value);
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.SetIndexEmptyValue_1, parameters); // MQLCommand ENUM = 165
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
        }

        /// <summary>
        /// Function: SetIndexLabel
        /// Description: Sets drawing line description for showing in the DataWindow and in the tooltip.
        /// URL: http://mm.l/mql4/docs.mql4.com/customind/setindexlabel.html
        /// </summary>
        /// <param name="index">[in] Line index. Must lie between 0 and 7.</param>
        /// <param name="text">[in] Label text. NULL means that index value is not shown in the DataWindow.</param>
        public void SetIndexLabel(int index, string text)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(index);
            parameters.Add(text);
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.SetIndexLabel_1, parameters); // MQLCommand ENUM = 166
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
        }

        /// <summary>
        /// Function: SetIndexShift
        /// Description: Sets offset for the drawing line.
        /// URL: http://mm.l/mql4/docs.mql4.com/customind/setindexshift.html
        /// </summary>
        /// <param name="index">[in] Line index. Must lie between 0 and 7.</param>
        /// <param name="shift">[in] Shift value in bars.</param>
        public void SetIndexShift(int index, int shift)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(index);
            parameters.Add(shift);
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.SetIndexShift_1, parameters); // MQLCommand ENUM = 167
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
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
        public void SetIndexStyle(int index, int type, int style, int width, COLOR clr)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(index);
            parameters.Add(type);
            parameters.Add(style);
            parameters.Add(width);
            parameters.Add(clr);
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.SetIndexStyle_1, parameters); // MQLCommand ENUM = 168
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
        }

        /// <summary>
        /// Function: SetLevelStyle
        /// Description: The function sets a new style, width and color of horizontal levels of indicator to be output in a separate window.
        /// URL: http://mm.l/mql4/docs.mql4.com/customind/setlevelstyle.html
        /// </summary>
        /// <param name="draw_style">[in] Drawing style. Can be one of the listed. EMPTY value means that the style will not be changed.</param>
        /// <param name="line_width">[in] Line width. Valid values are 1,2,3,4,5. EMPTY value indicates that the width will not be changed.</param>
        /// <param name="clr">[in] Line color. Empty value CLR_NONE means that the color will not be changed.</param>
        public void SetLevelStyle(int draw_style, int line_width, COLOR clr)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(draw_style);
            parameters.Add(line_width);
            parameters.Add(clr);
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.SetLevelStyle_1, parameters); // MQLCommand ENUM = 169
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
        }

        /// <summary>
        /// Function: SetLevelValue
        /// Description: The function sets a value for a given horizontal level of the indicator to be output in a separate window.
        /// URL: http://mm.l/mql4/docs.mql4.com/customind/setlevelvalue.html
        /// </summary>
        /// <param name="level">[in] Level index (0-31).</param>
        /// <param name="value">[in] Value for the given indicator level.</param>
        public void SetLevelValue(int level, double value)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(level);
            parameters.Add(value);
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.SetLevelValue_1, parameters); // MQLCommand ENUM = 170
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
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
        public bool ObjectCreate(long chart_id, string object_name, ENUM_OBJECT object_type, int sub_window, DateTime time1, double price1, DateTime timeN, double priceN)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(chart_id);
            parameters.Add(object_name);
            parameters.Add(object_type.ToString());
            parameters.Add(sub_window);
            parameters.Add(time1);
            parameters.Add(price1);
            parameters.Add(timeN);
            parameters.Add(priceN);
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.ObjectCreate_1, parameters); // MQLCommand ENUM = 171
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (bool)MQLCommandManager.getInstance().GetCommandResult();
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
        public bool ObjectCreate(string object_name, ENUM_OBJECT object_type, int sub_window, DateTime time1, double price1, DateTime time2, double price2, DateTime time3, double price3)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(object_name);
            parameters.Add(object_type.ToString());
            parameters.Add(sub_window);
            parameters.Add(time1);
            parameters.Add(price1);
            parameters.Add(time2);
            parameters.Add(price2);
            parameters.Add(time3);
            parameters.Add(price3);
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.ObjectCreate_2, parameters); // MQLCommand ENUM = 171
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (bool)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: ObjectName
        /// Description: The function returns the name of the corresponding object by its index in the objects list.
        /// URL: http://mm.l/mql4/docs.mql4.com/objects/objectname.html
        /// </summary>
        /// <param name="object_index">[in] Object index. This value must be greater or equal to 0 and less than .</param>
        public string ObjectName(int object_index)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(object_index);
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.ObjectName_1, parameters); // MQLCommand ENUM = 172
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (string)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: ObjectDelete
        /// Description: The function removes the object with the specified name at the specified chart. There are two variants of the function:
        /// URL: http://mm.l/mql4/docs.mql4.com/objects/objectdelete.html
        /// </summary>
        /// <param name="chart_id">[in] Chart identifier.</param>
        /// <param name="object_name">[in] Name of object to be deleted.</param>
        public bool ObjectDelete(long chart_id, string object_name)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(chart_id);
            parameters.Add(object_name);
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.ObjectDelete_1, parameters); // MQLCommand ENUM = 173
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (bool)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: ObjectDelete
        /// Description: The function removes the object with the specified name at the specified chart. There are two variants of the function:
        /// URL: http://mm.l/mql4/docs.mql4.com/objects/objectdelete.html
        /// </summary>
        /// <param name="object_name">[in] Name of object to be deleted.</param>
        public bool ObjectDelete(string object_name)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(object_name);
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.ObjectDelete_2, parameters); // MQLCommand ENUM = 173
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (bool)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: ObjectsDeleteAll
        /// Description: Removes all objects from the specified chart, specified chart subwindow, of the specified type.
        /// URL: http://mm.l/mql4/docs.mql4.com/objects/objectsdeleteall.html
        /// </summary>
        /// <param name="chart_id">[in] Chart identifier.</param>
        /// <param name="sub_window">[in] Number of the chart window. Must be greater or equal to -1 (-1 mean all subwindows, 0 means the main chart window) and less than .</param>
        /// <param name="object_type">[in] Type of the object. The value can be one of the values of the enumeration. EMPTY (-1) means all types.</param>
        public int ObjectsDeleteAll(long chart_id, int sub_window, int object_type)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(chart_id);
            parameters.Add(sub_window);
            parameters.Add(object_type);
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.ObjectsDeleteAll_1, parameters); // MQLCommand ENUM = 174
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (int)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: ObjectsDeleteAll
        /// Description: Removes all objects from the specified chart, specified chart subwindow, of the specified type.
        /// URL: http://mm.l/mql4/docs.mql4.com/objects/objectsdeleteall.html
        /// </summary>
        /// <param name="sub_window">[in] Number of the chart window. Must be greater or equal to -1 (-1 mean all subwindows, 0 means the main chart window) and less than .</param>
        /// <param name="object_type">[in] Type of the object. The value can be one of the values of the enumeration. EMPTY (-1) means all types.</param>
        public int ObjectsDeleteAll(int sub_window, int object_type)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(sub_window);
            parameters.Add(object_type);
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.ObjectsDeleteAll_2, parameters); // MQLCommand ENUM = 174
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (int)MQLCommandManager.getInstance().GetCommandResult();
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
        public int ObjectsDeleteAll(long chart_id, string prefix, int sub_window, int object_type)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(chart_id);
            parameters.Add(prefix);
            parameters.Add(sub_window);
            parameters.Add(object_type);
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.ObjectsDeleteAll_3, parameters); // MQLCommand ENUM = 174
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (int)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: ObjectFind
        /// Description: The function searches for an object having the specified name. There are two variants of the function:
        /// URL: http://mm.l/mql4/docs.mql4.com/objects/objectfind.html
        /// </summary>
        /// <param name="chart_id">[in] Chart identifier.</param>
        /// <param name="object_name">[in] The name of the object to find.</param>
        public int ObjectFind(long chart_id, string object_name)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(chart_id);
            parameters.Add(object_name);
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.ObjectFind_1, parameters); // MQLCommand ENUM = 175
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (int)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: ObjectFind
        /// Description: The function searches for an object having the specified name. There are two variants of the function:
        /// URL: http://mm.l/mql4/docs.mql4.com/objects/objectfind.html
        /// </summary>
        /// <param name="object_name">[in] The name of the object to find.</param>
        public int ObjectFind(string object_name)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(object_name);
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.ObjectFind_2, parameters); // MQLCommand ENUM = 175
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (int)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: ObjectGetTimeByValue
        /// Description: The function returns the time value for the specified price value of the specified object.
        /// URL: http://mm.l/mql4/docs.mql4.com/objects/objectgettimebyvalue.html
        /// </summary>
        /// <param name="object_name">[in] Name of the object.</param>
        /// <param name="value">[in] Price value.</param>
        /// <param name="line_id">[in] Line identifier.</param>
        public DateTime ObjectGetTimeByValue(string object_name, double value, int line_id)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(object_name);
            parameters.Add(value);
            parameters.Add(line_id);
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.ObjectGetTimeByValue_1, parameters); // MQLCommand ENUM = 176
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (DateTime)MQLCommandManager.getInstance().GetCommandResult();
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
        public double ObjectGetValueByTime(long chart_id, string object_name, DateTime time, int line_id)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(chart_id);
            parameters.Add(object_name);
            parameters.Add(time);
            parameters.Add(line_id);
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.ObjectGetValueByTime_1, parameters); // MQLCommand ENUM = 177
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (double)MQLCommandManager.getInstance().GetCommandResult();
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
        public bool ObjectMove(string object_name, int point_index, DateTime time, double price)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(object_name);
            parameters.Add(point_index);
            parameters.Add(time);
            parameters.Add(price);
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.ObjectMove_1, parameters); // MQLCommand ENUM = 178
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (bool)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: ObjectsTotal
        /// Description: The function returns the number of objects of the specified type in the specified chart. There are two variants of the function:
        /// URL: http://mm.l/mql4/docs.mql4.com/objects/objectstotal.html
        /// </summary>
        /// <param name="chart_id">[in] Chart identifier.</param>
        /// <param name="sub_window">[in] Number of the chart subwindow. 0 means the main chart window, -1 means all the subwindows of the chart, including the main window.</param>
        /// <param name="type">[in] Type of the object. The value can be one of the values of the enumeration. EMPTY(-1) means all types.</param>
        public int ObjectsTotal(long chart_id, int sub_window, int type)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(chart_id);
            parameters.Add(sub_window);
            parameters.Add(type);
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.ObjectsTotal_1, parameters); // MQLCommand ENUM = 179
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (int)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: ObjectsTotal
        /// Description: The function returns the number of objects of the specified type in the specified chart. There are two variants of the function:
        /// URL: http://mm.l/mql4/docs.mql4.com/objects/objectstotal.html
        /// </summary>
        /// <param name="type">[in] Type of the object. The value can be one of the values of the enumeration. EMPTY(-1) means all types.</param>
        public int ObjectsTotal(int type)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(type);
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.ObjectsTotal_2, parameters); // MQLCommand ENUM = 179
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (int)MQLCommandManager.getInstance().GetCommandResult();
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
        public double ObjectGetDouble(long chart_id, string object_name, int prop_id, int prop_modifier)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(chart_id);
            parameters.Add(object_name);
            parameters.Add(prop_id);
            parameters.Add(prop_modifier);
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.ObjectGetDouble_1, parameters); // MQLCommand ENUM = 180
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (double)MQLCommandManager.getInstance().GetCommandResult();
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
        public long ObjectGetInteger(long chart_id, string object_name, int prop_id, int prop_modifier)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(chart_id);
            parameters.Add(object_name);
            parameters.Add(prop_id);
            parameters.Add(prop_modifier);
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.ObjectGetInteger_1, parameters); // MQLCommand ENUM = 181
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (long)MQLCommandManager.getInstance().GetCommandResult();
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
        public string ObjectGetString(long chart_id, string object_name, int prop_id, int prop_modifier)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(chart_id);
            parameters.Add(object_name);
            parameters.Add(prop_id);
            parameters.Add(prop_modifier);
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.ObjectGetString_1, parameters); // MQLCommand ENUM = 182
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (string)MQLCommandManager.getInstance().GetCommandResult();
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
        public bool ObjectSetDouble(long chart_id, string object_name, int prop_id, double prop_value)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(chart_id);
            parameters.Add(object_name);
            parameters.Add(prop_id);
            parameters.Add(prop_value);
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.ObjectSetDouble_1, parameters); // MQLCommand ENUM = 183
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (bool)MQLCommandManager.getInstance().GetCommandResult();
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
        public bool ObjectSetDouble(long chart_id, string object_name, int prop_id, int prop_modifier, double prop_value)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(chart_id);
            parameters.Add(object_name);
            parameters.Add(prop_id);
            parameters.Add(prop_modifier);
            parameters.Add(prop_value);
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.ObjectSetDouble_2, parameters); // MQLCommand ENUM = 183
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (bool)MQLCommandManager.getInstance().GetCommandResult();
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
        public bool ObjectSetInteger(long chart_id, string object_name, int prop_id, long prop_value)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(chart_id);
            parameters.Add(object_name);
            parameters.Add(prop_id);
            parameters.Add(prop_value);
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.ObjectSetInteger_1, parameters); // MQLCommand ENUM = 184
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (bool)MQLCommandManager.getInstance().GetCommandResult();
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
        public bool ObjectSetInteger(long chart_id, string object_name, int prop_id, int prop_modifier, long prop_value)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(chart_id);
            parameters.Add(object_name);
            parameters.Add(prop_id);
            parameters.Add(prop_modifier);
            parameters.Add(prop_value);
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.ObjectSetInteger_2, parameters); // MQLCommand ENUM = 184
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (bool)MQLCommandManager.getInstance().GetCommandResult();
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
        public bool ObjectSetString(long chart_id, string object_name, int prop_id, string prop_value)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(chart_id);
            parameters.Add(object_name);
            parameters.Add(prop_id);
            parameters.Add(prop_value);
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.ObjectSetString_1, parameters); // MQLCommand ENUM = 185
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (bool)MQLCommandManager.getInstance().GetCommandResult();
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
        public bool ObjectSetString(long chart_id, string object_name, int prop_id, int prop_modifier, string prop_value)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(chart_id);
            parameters.Add(object_name);
            parameters.Add(prop_id);
            parameters.Add(prop_modifier);
            parameters.Add(prop_value);
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.ObjectSetString_2, parameters); // MQLCommand ENUM = 185
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (bool)MQLCommandManager.getInstance().GetCommandResult();
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
        public bool TextSetFont(string name, int size, uint flags, int orientation)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(name);
            parameters.Add(size);
            parameters.Add(flags);
            parameters.Add(orientation);
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.TextSetFont_1, parameters); // MQLCommand ENUM = 186
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (bool)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: ObjectDescription
        /// Description: Returns the object description.
        /// URL: http://mm.l/mql4/docs.mql4.com/objects/objectdescription.html
        /// </summary>
        /// <param name="object_name">[in] Object name.</param>
        public string ObjectDescription(string object_name)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(object_name);
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.ObjectDescription_1, parameters); // MQLCommand ENUM = 187
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (string)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: ObjectGet
        /// Description: Returns the value of the specified object property.
        /// URL: http://mm.l/mql4/docs.mql4.com/objects/objectget.html
        /// </summary>
        /// <param name="object_name">[in] Object name.</param>
        /// <param name="index">[in] Object property index. It can be any of the enumeration values.</param>
        public double ObjectGet(string object_name, int index)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(object_name);
            parameters.Add(index);
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.ObjectGet_1, parameters); // MQLCommand ENUM = 188
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (double)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: ObjectGetFiboDescription
        /// Description: Returns the level description of a Fibonacci object.
        /// URL: http://mm.l/mql4/docs.mql4.com/objects/objectgetfibodescription.html
        /// </summary>
        /// <param name="object_name">[in] Fibonacci object name.</param>
        /// <param name="index">[in] Index of the Fibonacci level (0-31).</param>
        public string ObjectGetFiboDescription(string object_name, int index)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(object_name);
            parameters.Add(index);
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.ObjectGetFiboDescription_1, parameters); // MQLCommand ENUM = 189
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (string)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: ObjectGetShiftByValue
        /// Description: The function calculates and returns bar index (shift related to the current bar) for the given price.
        /// URL: http://mm.l/mql4/docs.mql4.com/objects/objectgetshiftbyvalue.html
        /// </summary>
        /// <param name="object_name">[in] Object name.</param>
        /// <param name="value">[in] Price value.</param>
        public int ObjectGetShiftByValue(string object_name, double value)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(object_name);
            parameters.Add(value);
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.ObjectGetShiftByValue_1, parameters); // MQLCommand ENUM = 190
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (int)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: ObjectGetValueByShift
        /// Description: The function calculates and returns the price value for the specified bar (shift related to the current bar).
        /// URL: http://mm.l/mql4/docs.mql4.com/objects/objectgetvaluebyshift.html
        /// </summary>
        /// <param name="object_name">[in] Object name.</param>
        /// <param name="shift">[in] Bar index.</param>
        public double ObjectGetValueByShift(string object_name, int shift)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(object_name);
            parameters.Add(shift);
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.ObjectGetValueByShift_1, parameters); // MQLCommand ENUM = 191
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (double)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: ObjectSet
        /// Description: Changes the value of the specified object property.
        /// URL: http://mm.l/mql4/docs.mql4.com/objects/objectset.html
        /// </summary>
        /// <param name="object_name">[in] Object name.</param>
        /// <param name="index">[in] Object property index. It can be any of enumeration values.</param>
        /// <param name="value">[in] New value of the given property.</param>
        public bool ObjectSet(string object_name, int index, double value)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(object_name);
            parameters.Add(index);
            parameters.Add(value);
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.ObjectSet_1, parameters); // MQLCommand ENUM = 192
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (bool)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: ObjectSetFiboDescription
        /// Description: The function sets a new description to a level of a Fibonacci object.
        /// URL: http://mm.l/mql4/docs.mql4.com/objects/objectsetfibodescription.html
        /// </summary>
        /// <param name="object_name">[in] Object name.</param>
        /// <param name="index">[in] Index of the Fibonacci level (0-31).</param>
        /// <param name="text">[in] New description of the level.</param>
        public bool ObjectSetFiboDescription(string object_name, int index, string text)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(object_name);
            parameters.Add(index);
            parameters.Add(text);
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.ObjectSetFiboDescription_1, parameters); // MQLCommand ENUM = 193
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (bool)MQLCommandManager.getInstance().GetCommandResult();
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
        public bool ObjectSetText(string object_name, string text, int font_size, string font_name, COLOR text_color)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(object_name);
            parameters.Add(text);
            parameters.Add(font_size);
            parameters.Add(font_name);
            parameters.Add(text_color);
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.ObjectSetText_1, parameters); // MQLCommand ENUM = 194
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (bool)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: ObjectType
        /// Description: The function returns the object type value.
        /// URL: http://mm.l/mql4/docs.mql4.com/objects/objecttype.html
        /// </summary>
        /// <param name="object_name">[in] Object name.</param>
        public int ObjectType(string object_name)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(object_name);
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.ObjectType_1, parameters); // MQLCommand ENUM = 195
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (int)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: iAC
        /// Description: Calculates the Bill Williams' Accelerator/Decelerator oscillator and returns its value.
        /// URL: http://mm.l/mql4/docs.mql4.com/indicators/iac.html
        /// </summary>
        /// <param name="symbol">[in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</param>
        /// <param name="timeframe">[in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</param>
        /// <param name="shift">[in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</param>
        public double iAC(string symbol, int timeframe, int shift)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(symbol);
            parameters.Add(timeframe);
            parameters.Add(shift);
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.iAC_1, parameters); // MQLCommand ENUM = 196
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (double)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: iAD
        /// Description: Calculates the Accumulation/Distribution indicator and returns its value.
        /// URL: http://mm.l/mql4/docs.mql4.com/indicators/iad.html
        /// </summary>
        /// <param name="symbol">[in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</param>
        /// <param name="timeframe">[in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</param>
        /// <param name="shift">[in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</param>
        public double iAD(string symbol, int timeframe, int shift)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(symbol);
            parameters.Add(timeframe);
            parameters.Add(shift);
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.iAD_1, parameters); // MQLCommand ENUM = 197
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (double)MQLCommandManager.getInstance().GetCommandResult();
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
        public double iADX(string symbol, int timeframe, int period, int applied_price, int mode, int shift)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(symbol);
            parameters.Add(timeframe);
            parameters.Add(period);
            parameters.Add(applied_price);
            parameters.Add(mode);
            parameters.Add(shift);
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.iADX_1, parameters); // MQLCommand ENUM = 198
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (double)MQLCommandManager.getInstance().GetCommandResult();
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
        public double iAlligator(string symbol, int timeframe, int jaw_period, int jaw_shift, int teeth_period, int teeth_shift, int lips_period, int lips_shift, int ma_method, int applied_price, int mode, int shift)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(symbol);
            parameters.Add(timeframe);
            parameters.Add(jaw_period);
            parameters.Add(jaw_shift);
            parameters.Add(teeth_period);
            parameters.Add(teeth_shift);
            parameters.Add(lips_period);
            parameters.Add(lips_shift);
            parameters.Add(ma_method);
            parameters.Add(applied_price);
            parameters.Add(mode);
            parameters.Add(shift);
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.iAlligator_1, parameters); // MQLCommand ENUM = 199
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (double)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: iAO
        /// Description: Calculates the Awesome oscillator and returns its value.
        /// URL: http://mm.l/mql4/docs.mql4.com/indicators/iao.html
        /// </summary>
        /// <param name="symbol">[in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</param>
        /// <param name="timeframe">[in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</param>
        /// <param name="shift">[in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</param>
        public double iAO(string symbol, int timeframe, int shift)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(symbol);
            parameters.Add(timeframe);
            parameters.Add(shift);
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.iAO_1, parameters); // MQLCommand ENUM = 200
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (double)MQLCommandManager.getInstance().GetCommandResult();
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
        public double iATR(string symbol, int timeframe, int period, int shift)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(symbol);
            parameters.Add(timeframe);
            parameters.Add(period);
            parameters.Add(shift);
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.iATR_1, parameters); // MQLCommand ENUM = 201
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (double)MQLCommandManager.getInstance().GetCommandResult();
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
        public double iBearsPower(string symbol, int timeframe, int period, int applied_price, int shift)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(symbol);
            parameters.Add(timeframe);
            parameters.Add(period);
            parameters.Add(applied_price);
            parameters.Add(shift);
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.iBearsPower_1, parameters); // MQLCommand ENUM = 202
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (double)MQLCommandManager.getInstance().GetCommandResult();
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
        public double iBands(string symbol, int timeframe, int period, double deviation, int bands_shift, int applied_price, int mode, int shift)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(symbol);
            parameters.Add(timeframe);
            parameters.Add(period);
            parameters.Add(deviation);
            parameters.Add(bands_shift);
            parameters.Add(applied_price);
            parameters.Add(mode);
            parameters.Add(shift);
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.iBands_1, parameters); // MQLCommand ENUM = 203
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (double)MQLCommandManager.getInstance().GetCommandResult();
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
        public double iBullsPower(string symbol, int timeframe, int period, int applied_price, int shift)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(symbol);
            parameters.Add(timeframe);
            parameters.Add(period);
            parameters.Add(applied_price);
            parameters.Add(shift);
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.iBullsPower_1, parameters); // MQLCommand ENUM = 204
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (double)MQLCommandManager.getInstance().GetCommandResult();
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
        public double iCCI(string symbol, int timeframe, int period, int applied_price, int shift)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(symbol);
            parameters.Add(timeframe);
            parameters.Add(period);
            parameters.Add(applied_price);
            parameters.Add(shift);
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.iCCI_1, parameters); // MQLCommand ENUM = 205
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (double)MQLCommandManager.getInstance().GetCommandResult();
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
        public double iDeMarker(string symbol, int timeframe, int period, int shift)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(symbol);
            parameters.Add(timeframe);
            parameters.Add(period);
            parameters.Add(shift);
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.iDeMarker_1, parameters); // MQLCommand ENUM = 206
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (double)MQLCommandManager.getInstance().GetCommandResult();
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
        public double iEnvelopes(string symbol, int timeframe, int ma_period, int ma_method, int ma_shift, int applied_price, double deviation, int mode, int shift)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(symbol);
            parameters.Add(timeframe);
            parameters.Add(ma_period);
            parameters.Add(ma_method);
            parameters.Add(ma_shift);
            parameters.Add(applied_price);
            parameters.Add(deviation);
            parameters.Add(mode);
            parameters.Add(shift);
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.iEnvelopes_1, parameters); // MQLCommand ENUM = 207
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (double)MQLCommandManager.getInstance().GetCommandResult();
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
        public double iForce(string symbol, int timeframe, int period, int ma_method, int applied_price, int shift)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(symbol);
            parameters.Add(timeframe);
            parameters.Add(period);
            parameters.Add(ma_method);
            parameters.Add(applied_price);
            parameters.Add(shift);
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.iForce_1, parameters); // MQLCommand ENUM = 208
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (double)MQLCommandManager.getInstance().GetCommandResult();
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
        public double iFractals(string symbol, int timeframe, int mode, int shift)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(symbol);
            parameters.Add(timeframe);
            parameters.Add(mode);
            parameters.Add(shift);
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.iFractals_1, parameters); // MQLCommand ENUM = 209
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (double)MQLCommandManager.getInstance().GetCommandResult();
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
        public double iGator(string symbol, int timeframe, int jaw_period, int jaw_shift, int teeth_period, int teeth_shift, int lips_period, int lips_shift, int ma_method, int applied_price, int mode, int shift)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(symbol);
            parameters.Add(timeframe);
            parameters.Add(jaw_period);
            parameters.Add(jaw_shift);
            parameters.Add(teeth_period);
            parameters.Add(teeth_shift);
            parameters.Add(lips_period);
            parameters.Add(lips_shift);
            parameters.Add(ma_method);
            parameters.Add(applied_price);
            parameters.Add(mode);
            parameters.Add(shift);
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.iGator_1, parameters); // MQLCommand ENUM = 210
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (double)MQLCommandManager.getInstance().GetCommandResult();
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
        public double iIchimoku(string symbol, int timeframe, int tenkan_sen, int kijun_sen, int senkou_span_b, int mode, int shift)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(symbol);
            parameters.Add(timeframe);
            parameters.Add(tenkan_sen);
            parameters.Add(kijun_sen);
            parameters.Add(senkou_span_b);
            parameters.Add(mode);
            parameters.Add(shift);
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.iIchimoku_1, parameters); // MQLCommand ENUM = 211
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (double)MQLCommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Function: iBWMFI
        /// Description: Calculates the Market Facilitation Index indicator and returns its value.
        /// URL: http://mm.l/mql4/docs.mql4.com/indicators/ibwmfi.html
        /// </summary>
        /// <param name="symbol">[in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</param>
        /// <param name="timeframe">[in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</param>
        /// <param name="shift">[in] Index of the value taken from the indicator buffer (shift relative to the current bar the given amount of periods ago).</param>
        public double iBWMFI(string symbol, int timeframe, int shift)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(symbol);
            parameters.Add(timeframe);
            parameters.Add(shift);
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.iBWMFI_1, parameters); // MQLCommand ENUM = 212
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (double)MQLCommandManager.getInstance().GetCommandResult();
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
        public double iMomentum(string symbol, int timeframe, int period, int applied_price, int shift)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(symbol);
            parameters.Add(timeframe);
            parameters.Add(period);
            parameters.Add(applied_price);
            parameters.Add(shift);
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.iMomentum_1, parameters); // MQLCommand ENUM = 213
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (double)MQLCommandManager.getInstance().GetCommandResult();
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
        public double iMFI(string symbol, int timeframe, int period, int shift)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(symbol);
            parameters.Add(timeframe);
            parameters.Add(period);
            parameters.Add(shift);
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.iMFI_1, parameters); // MQLCommand ENUM = 214
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (double)MQLCommandManager.getInstance().GetCommandResult();
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
        public double iMA(string symbol, int timeframe, int ma_period, int ma_shift, int ma_method, int applied_price, int shift)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(symbol);
            parameters.Add(timeframe);
            parameters.Add(ma_period);
            parameters.Add(ma_shift);
            parameters.Add(ma_method);
            parameters.Add(applied_price);
            parameters.Add(shift);
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.iMA_1, parameters); // MQLCommand ENUM = 215
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (double)MQLCommandManager.getInstance().GetCommandResult();
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
        public double iOsMA(string symbol, int timeframe, int fast_ema_period, int slow_ema_period, int signal_period, int applied_price, int shift)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(symbol);
            parameters.Add(timeframe);
            parameters.Add(fast_ema_period);
            parameters.Add(slow_ema_period);
            parameters.Add(signal_period);
            parameters.Add(applied_price);
            parameters.Add(shift);
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.iOsMA_1, parameters); // MQLCommand ENUM = 216
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (double)MQLCommandManager.getInstance().GetCommandResult();
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
        public double iMACD(string symbol, int timeframe, int fast_ema_period, int slow_ema_period, int signal_period, int applied_price, int mode, int shift)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(symbol);
            parameters.Add(timeframe);
            parameters.Add(fast_ema_period);
            parameters.Add(slow_ema_period);
            parameters.Add(signal_period);
            parameters.Add(applied_price);
            parameters.Add(mode);
            parameters.Add(shift);
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.iMACD_1, parameters); // MQLCommand ENUM = 217
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (double)MQLCommandManager.getInstance().GetCommandResult();
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
        public double iOBV(string symbol, int timeframe, int applied_price, int shift)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(symbol);
            parameters.Add(timeframe);
            parameters.Add(applied_price);
            parameters.Add(shift);
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.iOBV_1, parameters); // MQLCommand ENUM = 218
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (double)MQLCommandManager.getInstance().GetCommandResult();
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
        public double iSAR(string symbol, int timeframe, double step, double maximum, int shift)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(symbol);
            parameters.Add(timeframe);
            parameters.Add(step);
            parameters.Add(maximum);
            parameters.Add(shift);
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.iSAR_1, parameters); // MQLCommand ENUM = 219
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (double)MQLCommandManager.getInstance().GetCommandResult();
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
        public double iRSI(string symbol, int timeframe, int period, int applied_price, int shift)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(symbol);
            parameters.Add(timeframe);
            parameters.Add(period);
            parameters.Add(applied_price);
            parameters.Add(shift);
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.iRSI_1, parameters); // MQLCommand ENUM = 220
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (double)MQLCommandManager.getInstance().GetCommandResult();
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
        public double iRVI(string symbol, int timeframe, int period, int mode, int shift)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(symbol);
            parameters.Add(timeframe);
            parameters.Add(period);
            parameters.Add(mode);
            parameters.Add(shift);
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.iRVI_1, parameters); // MQLCommand ENUM = 221
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (double)MQLCommandManager.getInstance().GetCommandResult();
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
        public double iStdDev(string symbol, int timeframe, int ma_period, int ma_shift, int ma_method, int applied_price, int shift)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(symbol);
            parameters.Add(timeframe);
            parameters.Add(ma_period);
            parameters.Add(ma_shift);
            parameters.Add(ma_method);
            parameters.Add(applied_price);
            parameters.Add(shift);
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.iStdDev_1, parameters); // MQLCommand ENUM = 222
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (double)MQLCommandManager.getInstance().GetCommandResult();
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
        public double iStochastic(string symbol, int timeframe, int Kperiod, int Dperiod, int slowing, int method, int price_field, int mode, int shift)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(symbol);
            parameters.Add(timeframe);
            parameters.Add(Kperiod);
            parameters.Add(Dperiod);
            parameters.Add(slowing);
            parameters.Add(method);
            parameters.Add(price_field);
            parameters.Add(mode);
            parameters.Add(shift);
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.iStochastic_1, parameters); // MQLCommand ENUM = 223
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (double)MQLCommandManager.getInstance().GetCommandResult();
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
        public double iWPR(string symbol, int timeframe, int period, int shift)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(symbol);
            parameters.Add(timeframe);
            parameters.Add(period);
            parameters.Add(shift);
            MQLCommandManager.getInstance().ExecCommand(MQLCommand.iWPR_1, parameters); // MQLCommand ENUM = 224
            while (MQLCommandManager.getInstance().IsCommandRunning())
            {
                //Thread.Sleep(1);
            }
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (double)MQLCommandManager.getInstance().GetCommandResult();
        }

        /*
        /// <summary>
        /// Function: iCustom
        /// Description: Calculates the specified custom indicator and returns its value.
        /// URL: http://mm.l/mql4/docs.mql4.com/indicators/icustom.html
        /// </summary>
        /// <param name="symbol">[in] Symbol name on the data of which the indicator will be calculated. means the current symbol.</param>
        /// <param name="timeframe">[in] Timeframe. It can be any of enumeration values. 0 means the current chart timeframe.</param>
        /// <param name="name">[in] Custom indicator compiled program name, relative to the root indicators directory (MQL4/Indicators/). If the indicator is located in subdirectory, for example, in MQL4/Indicators/Examples, its name must be specified as "Examples\\indicator_name" (double backslash "\\"must be specified as separator instead of a single one).</param>
        /// <param name="mode"></param>
        /// <param name="shift"></param>
        public double iCustom(string symbol, int timeframe, string name, int mode, int shift)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(symbol);
            parameters.Add(timeframe);
            parameters.Add(name);
            parameters.Add(mode);
            parameters.Add(shift);

            MQLCommandManager.getInstance().ExecCommand(MQLCommand.iCustom_1, parameters); // MQLCommand ENUM = 1000
            while (MQLCommandManager.getInstance().IsCommandRunning()) Thread.Sleep(1);
            MQLCommandManager.getInstance().throwExceptionIfErrorResponse();
            return (double) MQLCommandManager.getInstance().GetCommandResult();
        }*/

    }
}
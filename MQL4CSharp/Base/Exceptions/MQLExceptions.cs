using System;
using log4net;
using Newtonsoft.Json.Linq;

namespace MQL4CSharp.Base.Exceptions
{
    public class MQLExceptions : Exception
    {
        private static readonly ILog LOG = LogManager.GetLogger(typeof(MQLExceptions));

        public MQLExceptions(string message) : base(message)
        {

        }

        public static String convertRESTException(string message)
        {
            return message;
        }

        public static void throwMQLException(int error, String functionCall)
        {
            LOG.DebugFormat("throwMQLException({0},{1})", error, functionCall);

            if (error == 1)
            {
                throw new NoResultException(functionCall);
            }
            else if (error == 2)
            {
                throw new CommonErrorException(functionCall);
            }
            else if (error == 3)
            {
                throw new InvalidTradeParametersException(functionCall);
            }
            else if (error == 4)
            {
                throw new ServerBusyException(functionCall);
            }
            else if (error == 5)
            {
                throw new OldVersionException(functionCall);
            }
            else if (error == 6)
            {
                throw new NoConnectionException(functionCall);
            }
            else if (error == 7)
            {
                throw new NotEnoughRightsException(functionCall);
            }
            else if (error == 8)
            {
                throw new TooFrequentRequestsException(functionCall);
            }
            else if (error == 9)
            {
                throw new MalfunctionalTradeException(functionCall);
            }
            else if (error == 64)
            {
                throw new AccountDisabledException(functionCall);
            }
            else if (error == 65)
            {
                throw new InvalidAccountException(functionCall);
            }
            else if (error == 128)
            {
                throw new TradeTimeoutException(functionCall);
            }
            else if (error == 129)
            {
                throw new InvalidPriceException(functionCall);
            }
            else if (error == 130)
            {
                throw new InvalidStopsException(functionCall);
            }
            else if (error == 131)
            {
                throw new InvalidTradeVolumeException(functionCall);
            }
            else if (error == 132)
            {
                throw new MarketClosedException(functionCall);
            }
            else if (error == 133)
            {
                throw new TradeDisabledException(functionCall);
            }
            else if (error == 134)
            {
                throw new NotEnoughMoneyException(functionCall);
            }
            else if (error == 135)
            {
                throw new PriceChangedException(functionCall);
            }
            else if (error == 136)
            {
                throw new OffQuotesException(functionCall);
            }
            else if (error == 137)
            {
                throw new BrokerBusyException(functionCall);
            }
            else if (error == 138)
            {
                throw new RequoteException(functionCall);
            }
            else if (error == 139)
            {
                throw new OrderLockedException(functionCall);
            }
            else if (error == 140)
            {
                throw new LongPositionsOnlyAllowedException(functionCall);
            }
            else if (error == 141)
            {
                throw new TooManyRequestsException(functionCall);
            }
            else if (error == 145)
            {
                throw new TradeModifyDeniedException(functionCall);
            }
            else if (error == 146)
            {
                throw new TradeContextBusyException(functionCall);
            }
            else if (error == 147)
            {
                throw new TradeExpirationDeniedException(functionCall);
            }
            else if (error == 148)
            {
                throw new TradeTooManyOrdersException(functionCall);
            }
            else if (error == 149)
            {
                throw new TradeHedgeProhibitedException(functionCall);
            }
            else if (error == 150)
            {
                throw new TradeProhibitedByFifoException(functionCall);
            }
            else if (error == 4000)
            {
                throw new NoMqlerrorException(functionCall);
            }
            else if (error == 4001)
            {
                throw new WrongFunctionPointerException(functionCall);
            }
            else if (error == 4002)
            {
                throw new ArrayIndexOutOfRangeException(functionCall);
            }
            else if (error == 4003)
            {
                throw new NoMemoryForCallStackException(functionCall);
            }
            else if (error == 4004)
            {
                throw new RecursiveStackOverflowException(functionCall);
            }
            else if (error == 4005)
            {
                throw new NotEnoughStackForParamException(functionCall);
            }
            else if (error == 4006)
            {
                throw new NoMemoryForParamStringException(functionCall);
            }
            else if (error == 4007)
            {
                throw new NoMemoryForTempStringException(functionCall);
            }
            else if (error == 4008)
            {
                throw new NotInitializedStringException(functionCall);
            }
            else if (error == 4009)
            {
                throw new NotInitializedArraystringException(functionCall);
            }
            else if (error == 4010)
            {
                throw new NoMemoryForArraystringException(functionCall);
            }
            else if (error == 4011)
            {
                throw new TooLongStringException(functionCall);
            }
            else if (error == 4012)
            {
                throw new RemainderFromZeroDivideException(functionCall);
            }
            else if (error == 4013)
            {
                throw new ZeroDivideException(functionCall);
            }
            else if (error == 4014)
            {
                throw new UnknownCommandException(functionCall);
            }
            else if (error == 4015)
            {
                throw new WrongJumpException(functionCall);
            }
            else if (error == 4016)
            {
                throw new NotInitializedArrayException(functionCall);
            }
            else if (error == 4017)
            {
                throw new DllCallsNotAllowedException(functionCall);
            }
            else if (error == 4018)
            {
                throw new CannotLoadLibraryException(functionCall);
            }
            else if (error == 4019)
            {
                throw new CannotCallFunctionException(functionCall);
            }
            else if (error == 4020)
            {
                throw new ExternalCallsNotAllowedException(functionCall);
            }
            else if (error == 4021)
            {
                throw new NoMemoryForReturnedStrException(functionCall);
            }
            else if (error == 4022)
            {
                throw new SystemBusyException(functionCall);
            }
            else if (error == 4023)
            {
                throw new DllfuncCriticalerrorException(functionCall);
            }
            else if (error == 4024)
            {
                throw new InternalErrorException(functionCall);
            }
            else if (error == 4025)
            {
                throw new OutOfMemoryException(functionCall);
            }
            else if (error == 4026)
            {
                throw new InvalidPointerException(functionCall);
            }
            else if (error == 4027)
            {
                throw new FormatTooManyFormattersException(functionCall);
            }
            else if (error == 4028)
            {
                throw new FormatTooManyParametersException(functionCall);
            }
            else if (error == 4029)
            {
                throw new ArrayInvalidException(functionCall);
            }
            else if (error == 4030)
            {
                throw new ChartNoreplyException(functionCall);
            }
            else if (error == 4050)
            {
                throw new InvalidFunctionParamscntException(functionCall);
            }
            else if (error == 4051)
            {
                throw new InvalidFunctionParamvalueException(functionCall);
            }
            else if (error == 4052)
            {
                throw new StringFunctionInternalException(functionCall);
            }
            else if (error == 4053)
            {
                throw new SomeArrayErrorException(functionCall);
            }
            else if (error == 4054)
            {
                throw new IncorrectSeriesarrayUsingException(functionCall);
            }
            else if (error == 4055)
            {
                throw new CustomIndicatorErrorException(functionCall);
            }
            else if (error == 4056)
            {
                throw new IncompatibleArraysException(functionCall);
            }
            else if (error == 4057)
            {
                throw new GlobalVariablesProcessingException(functionCall);
            }
            else if (error == 4058)
            {
                throw new GlobalVariableNotFoundException(functionCall);
            }
            else if (error == 4059)
            {
                throw new FuncNotAllowedInTestingException(functionCall);
            }
            else if (error == 4060)
            {
                throw new FunctionNotConfirmedException(functionCall);
            }
            else if (error == 4061)
            {
                throw new SendMailErrorException(functionCall);
            }
            else if (error == 4062)
            {
                throw new StringParameterExpectedException(functionCall);
            }
            else if (error == 4063)
            {
                throw new IntegerParameterExpectedException(functionCall);
            }
            else if (error == 4064)
            {
                throw new DoubleParameterExpectedException(functionCall);
            }
            else if (error == 4065)
            {
                throw new ArrayAsParameterExpectedException(functionCall);
            }
            else if (error == 4066)
            {
                throw new HistoryWillUpdatedException(functionCall);
            }
            else if (error == 4067)
            {
                throw new TradeErrorException(functionCall);
            }
            else if (error == 4068)
            {
                throw new ResourceNotFoundException(functionCall);
            }
            else if (error == 4069)
            {
                throw new ResourceNotSupportedException(functionCall);
            }
            else if (error == 4070)
            {
                throw new ResourceDuplicatedException(functionCall);
            }
            else if (error == 4071)
            {
                throw new IndicatorCannotInitException(functionCall);
            }
            else if (error == 4072)
            {
                throw new IndicatorCannotLoadException(functionCall);
            }
            else if (error == 4073)
            {
                throw new NoHistoryDataException(functionCall);
            }
            else if (error == 4074)
            {
                throw new NoMemoryForHistoryException(functionCall);
            }
            else if (error == 4075)
            {
                throw new NoMemoryForIndicatorException(functionCall);
            }
            else if (error == 4099)
            {
                throw new EndOfFileException(functionCall);
            }
            else if (error == 4100)
            {
                throw new SomeFileErrorException(functionCall);
            }
            else if (error == 4101)
            {
                throw new WrongFileNameException(functionCall);
            }
            else if (error == 4102)
            {
                throw new TooManyOpenedFilesException(functionCall);
            }
            else if (error == 4103)
            {
                throw new CannotOpenFileException(functionCall);
            }
            else if (error == 4104)
            {
                throw new IncompatibleFileaccessException(functionCall);
            }
            else if (error == 4105)
            {
                throw new NoOrderSelectedException(functionCall);
            }
            else if (error == 4106)
            {
                throw new UnknownSymbolException(functionCall);
            }
            else if (error == 4107)
            {
                throw new InvalidPriceParamException(functionCall);
            }
            else if (error == 4108)
            {
                throw new InvalidTicketException(functionCall);
            }
            else if (error == 4109)
            {
                throw new TradeNotAllowedException(functionCall);
            }
            else if (error == 4110)
            {
                throw new LongsNotAllowedException(functionCall);
            }
            else if (error == 4111)
            {
                throw new ShortsNotAllowedExceptionException(functionCall);
            }
            else if (error == 4112)
            {
                throw new TradeExpertDisabledByServerException(functionCall);
            }
            else if (error == 4200)
            {
                throw new ObjectAlreadyExistsException(functionCall);
            }
            else if (error == 4201)
            {
                throw new UnknownObjectPropertyException(functionCall);
            }
            else if (error == 4202)
            {
                throw new ObjectDoesNotExistException(functionCall);
            }
            else if (error == 4203)
            {
                throw new UnknownObjectTypeException(functionCall);
            }
            else if (error == 4204)
            {
                throw new NoObjectNameException(functionCall);
            }
            else if (error == 4205)
            {
                throw new ObjectCoordinatesErrorException(functionCall);
            }
            else if (error == 4206)
            {
                throw new NoSpecifiedSubwindowException(functionCall);
            }
            else if (error == 4207)
            {
                throw new SomeObjectErrorException(functionCall);
            }
            else if (error == 4210)
            {
                throw new ChartPropInvalidException(functionCall);
            }
            else if (error == 4211)
            {
                throw new ChartNotFoundException(functionCall);
            }
            else if (error == 4212)
            {
                throw new ChartwindowNotFoundException(functionCall);
            }
            else if (error == 4213)
            {
                throw new ChartindicatorNotFoundException(functionCall);
            }
            else if (error == 4220)
            {
                throw new SymbolSelectException(functionCall);
            }
            else if (error == 4250)
            {
                throw new NotificationErrorException(functionCall);
            }
            else if (error == 4251)
            {
                throw new NotificationParameterException(functionCall);
            }
            else if (error == 4252)
            {
                throw new NotificationSettingsException(functionCall);
            }
            else if (error == 4253)
            {
                throw new NotificationTooFrequentException(functionCall);
            }
            else if (error == 4260)
            {
                throw new FtpNoserverException(functionCall);
            }
            else if (error == 4261)
            {
                throw new FtpNologinException(functionCall);
            }
            else if (error == 4262)
            {
                throw new FtpConnectFailedException(functionCall);
            }
            else if (error == 4263)
            {
                throw new FtpClosedException(functionCall);
            }
            else if (error == 4264)
            {
                throw new FtpChangedirException(functionCall);
            }
            else if (error == 4265)
            {
                throw new FtpFileErrorException(functionCall);
            }
            else if (error == 4266)
            {
                throw new FtpErrorException(functionCall);
            }
            else if (error == 5001)
            {
                throw new FileTooManyOpenedException(functionCall);
            }
            else if (error == 5002)
            {
                throw new FileWrongFilenameException(functionCall);
            }
            else if (error == 5003)
            {
                throw new FileTooLongFilenameException(functionCall);
            }
            else if (error == 5004)
            {
                throw new FileCannotOpenException(functionCall);
            }
            else if (error == 5005)
            {
                throw new FileBufferAllocationErrorException(functionCall);
            }
            else if (error == 5006)
            {
                throw new FileCannotDeleteException(functionCall);
            }
            else if (error == 5007)
            {
                throw new FileInvalidHandleException(functionCall);
            }
            else if (error == 5008)
            {
                throw new FileWrongHandleException(functionCall);
            }
            else if (error == 5009)
            {
                throw new FileNotTowriteException(functionCall);
            }
            else if (error == 5010)
            {
                throw new FileNotToreadException(functionCall);
            }
            else if (error == 5011)
            {
                throw new FileNotBinException(functionCall);
            }
            else if (error == 5012)
            {
                throw new FileNotTxtException(functionCall);
            }
            else if (error == 5013)
            {
                throw new FileNotTxtorcsvException(functionCall);
            }
            else if (error == 5014)
            {
                throw new FileNotCsvException(functionCall);
            }
            else if (error == 5015)
            {
                throw new FileReadErrorException(functionCall);
            }
            else if (error == 5016)
            {
                throw new FileWriteErrorException(functionCall);
            }
            else if (error == 5017)
            {
                throw new FileBinStringsizeException(functionCall);
            }
            else if (error == 5018)
            {
                throw new FileIncompatibleException(functionCall);
            }
            else if (error == 5019)
            {
                throw new FileIsDirectoryException(functionCall);
            }
            else if (error == 5020)
            {
                throw new FileNotExistException(functionCall);
            }
            else if (error == 5021)
            {
                throw new FileCannotRewriteException(functionCall);
            }
            else if (error == 5022)
            {
                throw new FileWrongDirectorynameException(functionCall);
            }
            else if (error == 5023)
            {
                throw new FileDirectoryNotExistException(functionCall);
            }
            else if (error == 5024)
            {
                throw new FileNotDirectoryException(functionCall);
            }
            else if (error == 5025)
            {
                throw new FileCannotDeleteDirectoryException(functionCall);
            }
            else if (error == 5026)
            {
                throw new FileCannotCleanDirectoryException(functionCall);
            }
            else if (error == 5027)
            {
                throw new FileArrayresizeErrorException(functionCall);
            }
            else if (error == 5028)
            {
                throw new FileStringresizeErrorException(functionCall);
            }
            else if (error == 5029)
            {
                throw new FileStructWithObjectsException(functionCall);
            }
            else if (error == 5200)
            {
                throw new WebrequestInvalidAddressException(functionCall);
            }
            else if (error == 5201)
            {
                throw new WebrequestConnectFailedException(functionCall);
            }
            else if (error == 5202)
            {
                throw new WebrequestTimeoutException(functionCall);
            }
            else if (error == 5203)
            {
                throw new WebrequestRequestFailedException(functionCall);
            }
            else if (error == 65536)
            {
                throw new UserErrorFirstException(functionCall);
            }
        }
    }

    public class NoResultException : MQLExceptions
    {
        public NoResultException(String functionCall) : base("No error returned, but the result is unknown: " + functionCall)
        {

        }
    }
    public class CommonErrorException : MQLExceptions
    {
        public CommonErrorException(String functionCall) : base("Common error: " + functionCall)
        {

        }
    }
    public class InvalidTradeParametersException : MQLExceptions
    {
        public InvalidTradeParametersException(String functionCall) : base("Invalid trade parameters: " + functionCall)
        {

        }
    }
    public class ServerBusyException : MQLExceptions
    {
        public ServerBusyException(String functionCall) : base("Trade server is busy: " + functionCall)
        {

        }
    }
    public class OldVersionException : MQLExceptions
    {
        public OldVersionException(String functionCall) : base("Old version of the client terminal: " + functionCall)
        {

        }
    }
    public class NoConnectionException : MQLExceptions
    {
        public NoConnectionException(String functionCall) : base("No connection with trade server: " + functionCall)
        {

        }
    }
    public class NotEnoughRightsException : MQLExceptions
    {
        public NotEnoughRightsException(String functionCall) : base("Not enough rights: " + functionCall)
        {

        }
    }
    public class TooFrequentRequestsException : MQLExceptions
    {
        public TooFrequentRequestsException(String functionCall) : base("Too frequent requests: " + functionCall)
        {

        }
    }
    public class MalfunctionalTradeException : MQLExceptions
    {
        public MalfunctionalTradeException(String functionCall) : base("Malfunctional trade operation: " + functionCall)
        {

        }
    }
    public class AccountDisabledException : MQLExceptions
    {
        public AccountDisabledException(String functionCall) : base("Account disabled: " + functionCall)
        {

        }
    }
    public class InvalidAccountException : MQLExceptions
    {
        public InvalidAccountException(String functionCall) : base("Invalid account: " + functionCall)
        {

        }
    }
    public class TradeTimeoutException : MQLExceptions
    {
        public TradeTimeoutException(String functionCall) : base("Trade timeout: " + functionCall)
        {

        }
    }
    public class InvalidPriceException : MQLExceptions
    {
        public InvalidPriceException(String functionCall) : base("Invalid price: " + functionCall)
        {

        }
    }
    public class InvalidStopsException : MQLExceptions
    {
        public InvalidStopsException(String functionCall) : base("Invalid stops: " + functionCall)
        {

        }
    }
    public class InvalidTradeVolumeException : MQLExceptions
    {
        public InvalidTradeVolumeException(String functionCall) : base("Invalid trade volume: " + functionCall)
        {

        }
    }
    public class MarketClosedException : MQLExceptions
    {
        public MarketClosedException(String functionCall) : base("Market is closed: " + functionCall)
        {

        }
    }
    public class TradeDisabledException : MQLExceptions
    {
        public TradeDisabledException(String functionCall) : base("Trade is disabled: " + functionCall)
        {

        }
    }
    public class NotEnoughMoneyException : MQLExceptions
    {
        public NotEnoughMoneyException(String functionCall) : base("Not enough money: " + functionCall)
        {

        }
    }
    public class PriceChangedException : MQLExceptions
    {
        public PriceChangedException(String functionCall) : base("Price changed: " + functionCall)
        {

        }
    }
    public class OffQuotesException : MQLExceptions
    {
        public OffQuotesException(String functionCall) : base("Off quotes: " + functionCall)
        {

        }
    }
    public class BrokerBusyException : MQLExceptions
    {
        public BrokerBusyException(String functionCall) : base("Broker is busy: " + functionCall)
        {

        }
    }
    public class RequoteException : MQLExceptions
    {
        public RequoteException(String functionCall) : base("Requote: " + functionCall)
        {

        }
    }
    public class OrderLockedException : MQLExceptions
    {
        public OrderLockedException(String functionCall) : base("Order is locked: " + functionCall)
        {

        }
    }
    public class LongPositionsOnlyAllowedException : MQLExceptions
    {
        public LongPositionsOnlyAllowedException(String functionCall) : base("Buy orders only allowed: " + functionCall)
        {

        }
    }
    public class TooManyRequestsException : MQLExceptions
    {
        public TooManyRequestsException(String functionCall) : base("Too many requests: " + functionCall)
        {

        }
    }
    public class TradeModifyDeniedException : MQLExceptions
    {
        public TradeModifyDeniedException(String functionCall) : base("Modification denied because order is too close to market: " + functionCall)
        {

        }
    }
    public class TradeContextBusyException : MQLExceptions
    {
        public TradeContextBusyException(String functionCall) : base("Trade context is busy: " + functionCall)
        {

        }
    }
    public class TradeExpirationDeniedException : MQLExceptions
    {
        public TradeExpirationDeniedException(String functionCall) : base("Expirations are denied by broker: " + functionCall)
        {

        }
    }
    public class TradeTooManyOrdersException : MQLExceptions
    {
        public TradeTooManyOrdersException(String functionCall) : base("The amount of open and pending orders has reached the limit set by the broker: " + functionCall)
        {

        }
    }
    public class TradeHedgeProhibitedException : MQLExceptions
    {
        public TradeHedgeProhibitedException(String functionCall) : base("An attempt to open an order opposite to the existing one when hedging is disabled: " + functionCall)
        {

        }
    }
    public class TradeProhibitedByFifoException : MQLExceptions
    {
        public TradeProhibitedByFifoException(String functionCall) : base("An attempt to close an order contravening the FIFO rule: " + functionCall)
        {

        }
    }
    public class NoMqlerrorException : MQLExceptions
    {
        public NoMqlerrorException(String functionCall) : base("No error returned: " + functionCall)
        {

        }
    }
    public class WrongFunctionPointerException : MQLExceptions
    {
        public WrongFunctionPointerException(String functionCall) : base("Wrong function pointer: " + functionCall)
        {

        }
    }
    public class ArrayIndexOutOfRangeException : MQLExceptions
    {
        public ArrayIndexOutOfRangeException(String functionCall) : base("Array index is out of range: " + functionCall)
        {

        }
    }
    public class NoMemoryForCallStackException : MQLExceptions
    {
        public NoMemoryForCallStackException(String functionCall) : base("No memory for function call stack: " + functionCall)
        {

        }
    }
    public class RecursiveStackOverflowException : MQLExceptions
    {
        public RecursiveStackOverflowException(String functionCall) : base("Recursive stack overflow: " + functionCall)
        {

        }
    }
    public class NotEnoughStackForParamException : MQLExceptions
    {
        public NotEnoughStackForParamException(String functionCall) : base("Not enough stack for parameter: " + functionCall)
        {

        }
    }
    public class NoMemoryForParamStringException : MQLExceptions
    {
        public NoMemoryForParamStringException(String functionCall) : base("No memory for parameter string: " + functionCall)
        {

        }
    }
    public class NoMemoryForTempStringException : MQLExceptions
    {
        public NoMemoryForTempStringException(String functionCall) : base("No memory for temp string: " + functionCall)
        {

        }
    }
    public class NotInitializedStringException : MQLExceptions
    {
        public NotInitializedStringException(String functionCall) : base("Not initialized string: " + functionCall)
        {

        }
    }
    public class NotInitializedArraystringException : MQLExceptions
    {
        public NotInitializedArraystringException(String functionCall) : base("Not initialized string in array: " + functionCall)
        {

        }
    }
    public class NoMemoryForArraystringException : MQLExceptions
    {
        public NoMemoryForArraystringException(String functionCall) : base("No memory for array string: " + functionCall)
        {

        }
    }
    public class TooLongStringException : MQLExceptions
    {
        public TooLongStringException(String functionCall) : base("Too long string: " + functionCall)
        {

        }
    }
    public class RemainderFromZeroDivideException : MQLExceptions
    {
        public RemainderFromZeroDivideException(String functionCall) : base("Remainder from zero divide: " + functionCall)
        {

        }
    }
    public class ZeroDivideException : MQLExceptions
    {
        public ZeroDivideException(String functionCall) : base("Zero divide: " + functionCall)
        {

        }
    }
    public class UnknownCommandException : MQLExceptions
    {
        public UnknownCommandException(String functionCall) : base("Unknown command: " + functionCall)
        {

        }
    }
    public class WrongJumpException : MQLExceptions
    {
        public WrongJumpException(String functionCall) : base("Wrong jump (never generated error): " + functionCall)
        {

        }
    }
    public class NotInitializedArrayException : MQLExceptions
    {
        public NotInitializedArrayException(String functionCall) : base("Not initialized array: " + functionCall)
        {

        }
    }
    public class DllCallsNotAllowedException : MQLExceptions
    {
        public DllCallsNotAllowedException(String functionCall) : base("DLL calls are not allowed: " + functionCall)
        {

        }
    }
    public class CannotLoadLibraryException : MQLExceptions
    {
        public CannotLoadLibraryException(String functionCall) : base("Cannot load library: " + functionCall)
        {

        }
    }
    public class CannotCallFunctionException : MQLExceptions
    {
        public CannotCallFunctionException(String functionCall) : base("Cannot call function: " + functionCall)
        {

        }
    }
    public class ExternalCallsNotAllowedException : MQLExceptions
    {
        public ExternalCallsNotAllowedException(String functionCall) : base("Expert function calls are not allowed: " + functionCall)
        {

        }
    }
    public class NoMemoryForReturnedStrException : MQLExceptions
    {
        public NoMemoryForReturnedStrException(String functionCall) : base("Not enough memory for temp string returned from function: " + functionCall)
        {

        }
    }
    public class SystemBusyException : MQLExceptions
    {
        public SystemBusyException(String functionCall) : base("System is busy (never generated error): " + functionCall)
        {

        }
    }
    public class DllfuncCriticalerrorException : MQLExceptions
    {
        public DllfuncCriticalerrorException(String functionCall) : base("DLL-function call critical error: " + functionCall)
        {

        }
    }
    public class InternalErrorException : MQLExceptions
    {
        public InternalErrorException(String functionCall) : base("Internal error: " + functionCall)
        {

        }
    }
    public class OutOfMemoryException : MQLExceptions
    {
        public OutOfMemoryException(String functionCall) : base("Out of memory: " + functionCall)
        {

        }
    }
    public class InvalidPointerException : MQLExceptions
    {
        public InvalidPointerException(String functionCall) : base("Invalid pointer: " + functionCall)
        {

        }
    }
    public class FormatTooManyFormattersException : MQLExceptions
    {
        public FormatTooManyFormattersException(String functionCall) : base("Too many formatters in the format function: " + functionCall)
        {

        }
    }
    public class FormatTooManyParametersException : MQLExceptions
    {
        public FormatTooManyParametersException(String functionCall) : base("Parameters count exceeds formatters count: " + functionCall)
        {

        }
    }
    public class ArrayInvalidException : MQLExceptions
    {
        public ArrayInvalidException(String functionCall) : base("Invalid array: " + functionCall)
        {

        }
    }
    public class ChartNoreplyException : MQLExceptions
    {
        public ChartNoreplyException(String functionCall) : base("No reply from chart: " + functionCall)
        {

        }
    }
    public class InvalidFunctionParamscntException : MQLExceptions
    {
        public InvalidFunctionParamscntException(String functionCall) : base("Invalid function parameters count: " + functionCall)
        {

        }
    }
    public class InvalidFunctionParamvalueException : MQLExceptions
    {
        public InvalidFunctionParamvalueException(String functionCall) : base("Invalid function parameter value: " + functionCall)
        {

        }
    }
    public class StringFunctionInternalException : MQLExceptions
    {
        public StringFunctionInternalException(String functionCall) : base("String function internal error: " + functionCall)
        {

        }
    }
    public class SomeArrayErrorException : MQLExceptions
    {
        public SomeArrayErrorException(String functionCall) : base("Some array error: " + functionCall)
        {

        }
    }
    public class IncorrectSeriesarrayUsingException : MQLExceptions
    {
        public IncorrectSeriesarrayUsingException(String functionCall) : base("Incorrect series array using: " + functionCall)
        {

        }
    }
    public class CustomIndicatorErrorException : MQLExceptions
    {
        public CustomIndicatorErrorException(String functionCall) : base("Custom indicator error: " + functionCall)
        {

        }
    }
    public class IncompatibleArraysException : MQLExceptions
    {
        public IncompatibleArraysException(String functionCall) : base("Arrays are incompatible: " + functionCall)
        {

        }
    }
    public class GlobalVariablesProcessingException : MQLExceptions
    {
        public GlobalVariablesProcessingException(String functionCall) : base("Global variables processing error: " + functionCall)
        {

        }
    }
    public class GlobalVariableNotFoundException : MQLExceptions
    {
        public GlobalVariableNotFoundException(String functionCall) : base("Global variable not found: " + functionCall)
        {

        }
    }
    public class FuncNotAllowedInTestingException : MQLExceptions
    {
        public FuncNotAllowedInTestingException(String functionCall) : base("Function is not allowed in testing mode: " + functionCall)
        {

        }
    }
    public class FunctionNotConfirmedException : MQLExceptions
    {
        public FunctionNotConfirmedException(String functionCall) : base("Function is not allowed for call: " + functionCall)
        {

        }
    }
    public class SendMailErrorException : MQLExceptions
    {
        public SendMailErrorException(String functionCall) : base("Send mail error: " + functionCall)
        {

        }
    }
    public class StringParameterExpectedException : MQLExceptions
    {
        public StringParameterExpectedException(String functionCall) : base("String parameter expected: " + functionCall)
        {

        }
    }
    public class IntegerParameterExpectedException : MQLExceptions
    {
        public IntegerParameterExpectedException(String functionCall) : base("Integer parameter expected: " + functionCall)
        {

        }
    }
    public class DoubleParameterExpectedException : MQLExceptions
    {
        public DoubleParameterExpectedException(String functionCall) : base("Double parameter expected: " + functionCall)
        {

        }
    }
    public class ArrayAsParameterExpectedException : MQLExceptions
    {
        public ArrayAsParameterExpectedException(String functionCall) : base("Array as parameter expected: " + functionCall)
        {

        }
    }
    public class HistoryWillUpdatedException : MQLExceptions
    {
        public HistoryWillUpdatedException(String functionCall) : base("Requested history data is in updating state: " + functionCall)
        {

        }
    }
    public class TradeErrorException : MQLExceptions
    {
        public TradeErrorException(String functionCall) : base("Internal trade error: " + functionCall)
        {

        }
    }
    public class ResourceNotFoundException : MQLExceptions
    {
        public ResourceNotFoundException(String functionCall) : base("Resource not found: " + functionCall)
        {

        }
    }
    public class ResourceNotSupportedException : MQLExceptions
    {
        public ResourceNotSupportedException(String functionCall) : base("Resource not supported: " + functionCall)
        {

        }
    }
    public class ResourceDuplicatedException : MQLExceptions
    {
        public ResourceDuplicatedException(String functionCall) : base("Duplicate resource: " + functionCall)
        {

        }
    }
    public class IndicatorCannotInitException : MQLExceptions
    {
        public IndicatorCannotInitException(String functionCall) : base("Custom indicator cannot initialize: " + functionCall)
        {

        }
    }
    public class IndicatorCannotLoadException : MQLExceptions
    {
        public IndicatorCannotLoadException(String functionCall) : base("Cannot load custom indicator: " + functionCall)
        {

        }
    }
    public class NoHistoryDataException : MQLExceptions
    {
        public NoHistoryDataException(String functionCall) : base("No history data: " + functionCall)
        {

        }
    }
    public class NoMemoryForHistoryException : MQLExceptions
    {
        public NoMemoryForHistoryException(String functionCall) : base("No memory for history data: " + functionCall)
        {

        }
    }
    public class NoMemoryForIndicatorException : MQLExceptions
    {
        public NoMemoryForIndicatorException(String functionCall) : base("Not enough memory for indicator calculation: " + functionCall)
        {

        }
    }
    public class EndOfFileException : MQLExceptions
    {
        public EndOfFileException(String functionCall) : base("End of file: " + functionCall)
        {

        }
    }
    public class SomeFileErrorException : MQLExceptions
    {
        public SomeFileErrorException(String functionCall) : base("Some file error: " + functionCall)
        {

        }
    }
    public class WrongFileNameException : MQLExceptions
    {
        public WrongFileNameException(String functionCall) : base("Wrong file name: " + functionCall)
        {

        }
    }
    public class TooManyOpenedFilesException : MQLExceptions
    {
        public TooManyOpenedFilesException(String functionCall) : base("Too many opened files: " + functionCall)
        {

        }
    }
    public class CannotOpenFileException : MQLExceptions
    {
        public CannotOpenFileException(String functionCall) : base("Cannot open file: " + functionCall)
        {

        }
    }
    public class IncompatibleFileaccessException : MQLExceptions
    {
        public IncompatibleFileaccessException(String functionCall) : base("Incompatible access to a file: " + functionCall)
        {

        }
    }
    public class NoOrderSelectedException : MQLExceptions
    {
        public NoOrderSelectedException(String functionCall) : base("No order selected: " + functionCall)
        {

        }
    }
    public class UnknownSymbolException : MQLExceptions
    {
        public UnknownSymbolException(String functionCall) : base("Unknown symbol: " + functionCall)
        {

        }
    }
    public class InvalidPriceParamException : MQLExceptions
    {
        public InvalidPriceParamException(String functionCall) : base("Invalid price: " + functionCall)
        {

        }
    }
    public class InvalidTicketException : MQLExceptions
    {
        public InvalidTicketException(String functionCall) : base("Invalid ticket: " + functionCall)
        {

        }
    }
    public class TradeNotAllowedException : MQLExceptions
    {
        public TradeNotAllowedException(String functionCall) : base("Trade is not allowed. Enable checkbox: " + functionCall)
        {

        }
    }
    public class LongsNotAllowedException : MQLExceptions
    {
        public LongsNotAllowedException(String functionCall) : base("Longs are not allowed. Check the Expert Advisor properties: " + functionCall)
        {

        }
    }
    public class ShortsNotAllowedExceptionException : MQLExceptions
    {
        public ShortsNotAllowedExceptionException(String functionCall) : base("Shorts are not allowed. Check the Expert Advisor properties: " + functionCall)
        {

        }
    }
    public class TradeExpertDisabledByServerException : MQLExceptions
    {
        public TradeExpertDisabledByServerException(String functionCall) : base("Automated trading by Expert Advisors/Scripts disabled by trade server: " + functionCall)
        {

        }
    }
    public class ObjectAlreadyExistsException : MQLExceptions
    {
        public ObjectAlreadyExistsException(String functionCall) : base("Object already exists: " + functionCall)
        {

        }
    }
    public class UnknownObjectPropertyException : MQLExceptions
    {
        public UnknownObjectPropertyException(String functionCall) : base("Unknown object property: " + functionCall)
        {

        }
    }
    public class ObjectDoesNotExistException : MQLExceptions
    {
        public ObjectDoesNotExistException(String functionCall) : base("Object does not exist: " + functionCall)
        {

        }
    }
    public class UnknownObjectTypeException : MQLExceptions
    {
        public UnknownObjectTypeException(String functionCall) : base("Unknown object type: " + functionCall)
        {

        }
    }
    public class NoObjectNameException : MQLExceptions
    {
        public NoObjectNameException(String functionCall) : base("No object name: " + functionCall)
        {

        }
    }
    public class ObjectCoordinatesErrorException : MQLExceptions
    {
        public ObjectCoordinatesErrorException(String functionCall) : base("Object coordinates error: " + functionCall)
        {

        }
    }
    public class NoSpecifiedSubwindowException : MQLExceptions
    {
        public NoSpecifiedSubwindowException(String functionCall) : base("No specified subwindow: " + functionCall)
        {

        }
    }
    public class SomeObjectErrorException : MQLExceptions
    {
        public SomeObjectErrorException(String functionCall) : base("Graphical object error: " + functionCall)
        {

        }
    }
    public class ChartPropInvalidException : MQLExceptions
    {
        public ChartPropInvalidException(String functionCall) : base("Unknown chart property: " + functionCall)
        {

        }
    }
    public class ChartNotFoundException : MQLExceptions
    {
        public ChartNotFoundException(String functionCall) : base("Chart not found: " + functionCall)
        {

        }
    }
    public class ChartwindowNotFoundException : MQLExceptions
    {
        public ChartwindowNotFoundException(String functionCall) : base("Chart subwindow not found: " + functionCall)
        {

        }
    }
    public class ChartindicatorNotFoundException : MQLExceptions
    {
        public ChartindicatorNotFoundException(String functionCall) : base("Chart indicator not found: " + functionCall)
        {

        }
    }
    public class SymbolSelectException : MQLExceptions
    {
        public SymbolSelectException(String functionCall) : base("Symbol select error: " + functionCall)
        {

        }
    }
    public class NotificationErrorException : MQLExceptions
    {
        public NotificationErrorException(String functionCall) : base("Notification error: " + functionCall)
        {

        }
    }
    public class NotificationParameterException : MQLExceptions
    {
        public NotificationParameterException(String functionCall) : base("Notification parameter error: " + functionCall)
        {

        }
    }
    public class NotificationSettingsException : MQLExceptions
    {
        public NotificationSettingsException(String functionCall) : base("Notifications disabled: " + functionCall)
        {

        }
    }
    public class NotificationTooFrequentException : MQLExceptions
    {
        public NotificationTooFrequentException(String functionCall) : base("Notification send too frequent: " + functionCall)
        {

        }
    }
    public class FtpNoserverException : MQLExceptions
    {
        public FtpNoserverException(String functionCall) : base("FTP server is not specified: " + functionCall)
        {

        }
    }
    public class FtpNologinException : MQLExceptions
    {
        public FtpNologinException(String functionCall) : base("FTP login is not specified: " + functionCall)
        {

        }
    }
    public class FtpConnectFailedException : MQLExceptions
    {
        public FtpConnectFailedException(String functionCall) : base("FTP connection failed: " + functionCall)
        {

        }
    }
    public class FtpClosedException : MQLExceptions
    {
        public FtpClosedException(String functionCall) : base("FTP connection closed: " + functionCall)
        {

        }
    }
    public class FtpChangedirException : MQLExceptions
    {
        public FtpChangedirException(String functionCall) : base("FTP path not found on server: " + functionCall)
        {

        }
    }
    public class FtpFileErrorException : MQLExceptions
    {
        public FtpFileErrorException(String functionCall) : base("File not found in the MQL4\\Files directory to send on FTP server: " + functionCall)
        {

        }
    }
    public class FtpErrorException : MQLExceptions
    {
        public FtpErrorException(String functionCall) : base("Common error during FTP data transmission: " + functionCall)
        {

        }
    }
    public class FileTooManyOpenedException : MQLExceptions
    {
        public FileTooManyOpenedException(String functionCall) : base("Too many opened files: " + functionCall)
        {

        }
    }
    public class FileWrongFilenameException : MQLExceptions
    {
        public FileWrongFilenameException(String functionCall) : base("Wrong file name: " + functionCall)
        {

        }
    }
    public class FileTooLongFilenameException : MQLExceptions
    {
        public FileTooLongFilenameException(String functionCall) : base("Too long file name: " + functionCall)
        {

        }
    }
    public class FileCannotOpenException : MQLExceptions
    {
        public FileCannotOpenException(String functionCall) : base("Cannot open file: " + functionCall)
        {

        }
    }
    public class FileBufferAllocationErrorException : MQLExceptions
    {
        public FileBufferAllocationErrorException(String functionCall) : base("Text file buffer allocation error: " + functionCall)
        {

        }
    }
    public class FileCannotDeleteException : MQLExceptions
    {
        public FileCannotDeleteException(String functionCall) : base("Cannot delete file: " + functionCall)
        {

        }
    }
    public class FileInvalidHandleException : MQLExceptions
    {
        public FileInvalidHandleException(String functionCall) : base("Invalid file handle (file closed or was not opened): " + functionCall)
        {

        }
    }
    public class FileWrongHandleException : MQLExceptions
    {
        public FileWrongHandleException(String functionCall) : base("Wrong file handle (handle index is out of handle table): " + functionCall)
        {

        }
    }
    public class FileNotTowriteException : MQLExceptions
    {
        public FileNotTowriteException(String functionCall) : base("File must be opened with FILE_WRITE flag: " + functionCall)
        {

        }
    }
    public class FileNotToreadException : MQLExceptions
    {
        public FileNotToreadException(String functionCall) : base("File must be opened with FILE_READ flag: " + functionCall)
        {

        }
    }
    public class FileNotBinException : MQLExceptions
    {
        public FileNotBinException(String functionCall) : base("File must be opened with FILE_BIN flag: " + functionCall)
        {

        }
    }
    public class FileNotTxtException : MQLExceptions
    {
        public FileNotTxtException(String functionCall) : base("File must be opened with FILE_TXT flag: " + functionCall)
        {

        }
    }
    public class FileNotTxtorcsvException : MQLExceptions
    {
        public FileNotTxtorcsvException(String functionCall) : base("File must be opened with FILE_TXT or FILE_CSV flag: " + functionCall)
        {

        }
    }
    public class FileNotCsvException : MQLExceptions
    {
        public FileNotCsvException(String functionCall) : base("File must be opened with FILE_CSV flag: " + functionCall)
        {

        }
    }
    public class FileReadErrorException : MQLExceptions
    {
        public FileReadErrorException(String functionCall) : base("File read error: " + functionCall)
        {

        }
    }
    public class FileWriteErrorException : MQLExceptions
    {
        public FileWriteErrorException(String functionCall) : base("File write error: " + functionCall)
        {

        }
    }
    public class FileBinStringsizeException : MQLExceptions
    {
        public FileBinStringsizeException(String functionCall) : base("String size must be specified for binary file: " + functionCall)
        {

        }
    }
    public class FileIncompatibleException : MQLExceptions
    {
        public FileIncompatibleException(String functionCall) : base("Incompatible file (for string arrays-TXT, for others-BIN): " + functionCall)
        {

        }
    }
    public class FileIsDirectoryException : MQLExceptions
    {
        public FileIsDirectoryException(String functionCall) : base("File is directory not file: " + functionCall)
        {

        }
    }
    public class FileNotExistException : MQLExceptions
    {
        public FileNotExistException(String functionCall) : base("File does not exist: " + functionCall)
        {

        }
    }
    public class FileCannotRewriteException : MQLExceptions
    {
        public FileCannotRewriteException(String functionCall) : base("File cannot be rewritten: " + functionCall)
        {

        }
    }
    public class FileWrongDirectorynameException : MQLExceptions
    {
        public FileWrongDirectorynameException(String functionCall) : base("Wrong directory name: " + functionCall)
        {

        }
    }
    public class FileDirectoryNotExistException : MQLExceptions
    {
        public FileDirectoryNotExistException(String functionCall) : base("Directory does not exist: " + functionCall)
        {

        }
    }
    public class FileNotDirectoryException : MQLExceptions
    {
        public FileNotDirectoryException(String functionCall) : base("Specified file is not directory: " + functionCall)
        {

        }
    }
    public class FileCannotDeleteDirectoryException : MQLExceptions
    {
        public FileCannotDeleteDirectoryException(String functionCall) : base("Cannot delete directory: " + functionCall)
        {

        }
    }
    public class FileCannotCleanDirectoryException : MQLExceptions
    {
        public FileCannotCleanDirectoryException(String functionCall) : base("Cannot clean directory: " + functionCall)
        {

        }
    }
    public class FileArrayresizeErrorException : MQLExceptions
    {
        public FileArrayresizeErrorException(String functionCall) : base("Array resize error: " + functionCall)
        {

        }
    }
    public class FileStringresizeErrorException : MQLExceptions
    {
        public FileStringresizeErrorException(String functionCall) : base("String resize error: " + functionCall)
        {

        }
    }
    public class FileStructWithObjectsException : MQLExceptions
    {
        public FileStructWithObjectsException(String functionCall) : base("Structure contains strings or dynamic arrays: " + functionCall)
        {

        }
    }
    public class WebrequestInvalidAddressException : MQLExceptions
    {
        public WebrequestInvalidAddressException(String functionCall) : base("Invalid URL: " + functionCall)
        {

        }
    }
    public class WebrequestConnectFailedException : MQLExceptions
    {
        public WebrequestConnectFailedException(String functionCall) : base("Failed to connect to specified URL: " + functionCall)
        {

        }
    }
    public class WebrequestTimeoutException : MQLExceptions
    {
        public WebrequestTimeoutException(String functionCall) : base("Timeout exceeded: " + functionCall)
        {

        }
    }
    public class WebrequestRequestFailedException : MQLExceptions
    {
        public WebrequestRequestFailedException(String functionCall) : base("HTTP request failed: " + functionCall)
        {

        }
    }
    public class UserErrorFirstException : MQLExceptions
    {
        public UserErrorFirstException(String functionCall) : base("User defined errors start with this code: " + functionCall)
        {

        }
    }

}
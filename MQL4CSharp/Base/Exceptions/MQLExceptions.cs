using System;

namespace MQL4CSharp.Base.Exceptions
{
    public class MQLExceptions : Exception
    {
        public MQLExceptions(string message) : base(message)
        {

        }

        public static void throwMQLException(int error)
        {
            if (error == 1)
            {
                throw new NoResultException();
            }
            else if (error == 2)
            {
                throw new CommonErrorException();
            }
            else if (error == 3)
            {
                throw new InvalidTradeParametersException();
            }
            else if (error == 4)
            {
                throw new ServerBusyException();
            }
            else if (error == 5)
            {
                throw new OldVersionException();
            }
            else if (error == 6)
            {
                throw new NoConnectionException();
            }
            else if (error == 7)
            {
                throw new NotEnoughRightsException();
            }
            else if (error == 8)
            {
                throw new TooFrequentRequestsException();
            }
            else if (error == 9)
            {
                throw new MalfunctionalTradeException();
            }
            else if (error == 64)
            {
                throw new AccountDisabledException();
            }
            else if (error == 65)
            {
                throw new InvalidAccountException();
            }
            else if (error == 128)
            {
                throw new TradeTimeoutException();
            }
            else if (error == 129)
            {
                throw new InvalidPriceException();
            }
            else if (error == 130)
            {
                throw new InvalidStopsException();
            }
            else if (error == 131)
            {
                throw new InvalidTradeVolumeException();
            }
            else if (error == 132)
            {
                throw new MarketClosedException();
            }
            else if (error == 133)
            {
                throw new TradeDisabledException();
            }
            else if (error == 134)
            {
                throw new NotEnoughMoneyException();
            }
            else if (error == 135)
            {
                throw new PriceChangedException();
            }
            else if (error == 136)
            {
                throw new OffQuotesException();
            }
            else if (error == 137)
            {
                throw new BrokerBusyException();
            }
            else if (error == 138)
            {
                throw new RequoteException();
            }
            else if (error == 139)
            {
                throw new OrderLockedException();
            }
            else if (error == 140)
            {
                throw new LongPositionsOnlyAllowedException();
            }
            else if (error == 141)
            {
                throw new TooManyRequestsException();
            }
            else if (error == 145)
            {
                throw new TradeModifyDeniedException();
            }
            else if (error == 146)
            {
                throw new TradeContextBusyException();
            }
            else if (error == 147)
            {
                throw new TradeExpirationDeniedException();
            }
            else if (error == 148)
            {
                throw new TradeTooManyOrdersException();
            }
            else if (error == 149)
            {
                throw new TradeHedgeProhibitedException();
            }
            else if (error == 150)
            {
                throw new TradeProhibitedByFifoException();
            }
            else if (error == 4000)
            {
                throw new NoMqlerrorException();
            }
            else if (error == 4001)
            {
                throw new WrongFunctionPointerException();
            }
            else if (error == 4002)
            {
                throw new ArrayIndexOutOfRangeException();
            }
            else if (error == 4003)
            {
                throw new NoMemoryForCallStackException();
            }
            else if (error == 4004)
            {
                throw new RecursiveStackOverflowException();
            }
            else if (error == 4005)
            {
                throw new NotEnoughStackForParamException();
            }
            else if (error == 4006)
            {
                throw new NoMemoryForParamStringException();
            }
            else if (error == 4007)
            {
                throw new NoMemoryForTempStringException();
            }
            else if (error == 4008)
            {
                throw new NotInitializedStringException();
            }
            else if (error == 4009)
            {
                throw new NotInitializedArraystringException();
            }
            else if (error == 4010)
            {
                throw new NoMemoryForArraystringException();
            }
            else if (error == 4011)
            {
                throw new TooLongStringException();
            }
            else if (error == 4012)
            {
                throw new RemainderFromZeroDivideException();
            }
            else if (error == 4013)
            {
                throw new ZeroDivideException();
            }
            else if (error == 4014)
            {
                throw new UnknownCommandException();
            }
            else if (error == 4015)
            {
                throw new WrongJumpException();
            }
            else if (error == 4016)
            {
                throw new NotInitializedArrayException();
            }
            else if (error == 4017)
            {
                throw new DllCallsNotAllowedException();
            }
            else if (error == 4018)
            {
                throw new CannotLoadLibraryException();
            }
            else if (error == 4019)
            {
                throw new CannotCallFunctionException();
            }
            else if (error == 4020)
            {
                throw new ExternalCallsNotAllowedException();
            }
            else if (error == 4021)
            {
                throw new NoMemoryForReturnedStrException();
            }
            else if (error == 4022)
            {
                throw new SystemBusyException();
            }
            else if (error == 4023)
            {
                throw new DllfuncCriticalerrorException();
            }
            else if (error == 4024)
            {
                throw new InternalErrorException();
            }
            else if (error == 4025)
            {
                throw new OutOfMemoryException();
            }
            else if (error == 4026)
            {
                throw new InvalidPointerException();
            }
            else if (error == 4027)
            {
                throw new FormatTooManyFormattersException();
            }
            else if (error == 4028)
            {
                throw new FormatTooManyParametersException();
            }
            else if (error == 4029)
            {
                throw new ArrayInvalidException();
            }
            else if (error == 4030)
            {
                throw new ChartNoreplyException();
            }
            else if (error == 4050)
            {
                throw new InvalidFunctionParamscntException();
            }
            else if (error == 4051)
            {
                throw new InvalidFunctionParamvalueException();
            }
            else if (error == 4052)
            {
                throw new StringFunctionInternalException();
            }
            else if (error == 4053)
            {
                throw new SomeArrayErrorException();
            }
            else if (error == 4054)
            {
                throw new IncorrectSeriesarrayUsingException();
            }
            else if (error == 4055)
            {
                throw new CustomIndicatorErrorException();
            }
            else if (error == 4056)
            {
                throw new IncompatibleArraysException();
            }
            else if (error == 4057)
            {
                throw new GlobalVariablesProcessingException();
            }
            else if (error == 4058)
            {
                throw new GlobalVariableNotFoundException();
            }
            else if (error == 4059)
            {
                throw new FuncNotAllowedInTestingException();
            }
            else if (error == 4060)
            {
                throw new FunctionNotConfirmedException();
            }
            else if (error == 4061)
            {
                throw new SendMailErrorException();
            }
            else if (error == 4062)
            {
                throw new StringParameterExpectedException();
            }
            else if (error == 4063)
            {
                throw new IntegerParameterExpectedException();
            }
            else if (error == 4064)
            {
                throw new DoubleParameterExpectedException();
            }
            else if (error == 4065)
            {
                throw new ArrayAsParameterExpectedException();
            }
            else if (error == 4066)
            {
                throw new HistoryWillUpdatedException();
            }
            else if (error == 4067)
            {
                throw new TradeErrorException();
            }
            else if (error == 4068)
            {
                throw new ResourceNotFoundException();
            }
            else if (error == 4069)
            {
                throw new ResourceNotSupportedException();
            }
            else if (error == 4070)
            {
                throw new ResourceDuplicatedException();
            }
            else if (error == 4071)
            {
                throw new IndicatorCannotInitException();
            }
            else if (error == 4072)
            {
                throw new IndicatorCannotLoadException();
            }
            else if (error == 4073)
            {
                throw new NoHistoryDataException();
            }
            else if (error == 4074)
            {
                throw new NoMemoryForHistoryException();
            }
            else if (error == 4075)
            {
                throw new NoMemoryForIndicatorException();
            }
            else if (error == 4099)
            {
                throw new EndOfFileException();
            }
            else if (error == 4100)
            {
                throw new SomeFileErrorException();
            }
            else if (error == 4101)
            {
                throw new WrongFileNameException();
            }
            else if (error == 4102)
            {
                throw new TooManyOpenedFilesException();
            }
            else if (error == 4103)
            {
                throw new CannotOpenFileException();
            }
            else if (error == 4104)
            {
                throw new IncompatibleFileaccessException();
            }
            else if (error == 4105)
            {
                throw new NoOrderSelectedException();
            }
            else if (error == 4106)
            {
                throw new UnknownSymbolException();
            }
            else if (error == 4107)
            {
                throw new InvalidPriceParamException();
            }
            else if (error == 4108)
            {
                throw new InvalidTicketException();
            }
            else if (error == 4109)
            {
                throw new TradeNotAllowedException();
            }
            else if (error == 4110)
            {
                throw new LongsNotAllowedException();
            }
            else if (error == 4111)
            {
                throw new ShortsNotAllowedExceptionException();
            }
            else if (error == 4112)
            {
                throw new TradeExpertDisabledByServerException();
            }
            else if (error == 4200)
            {
                throw new ObjectAlreadyExistsException();
            }
            else if (error == 4201)
            {
                throw new UnknownObjectPropertyException();
            }
            else if (error == 4202)
            {
                throw new ObjectDoesNotExistException();
            }
            else if (error == 4203)
            {
                throw new UnknownObjectTypeException();
            }
            else if (error == 4204)
            {
                throw new NoObjectNameException();
            }
            else if (error == 4205)
            {
                throw new ObjectCoordinatesErrorException();
            }
            else if (error == 4206)
            {
                throw new NoSpecifiedSubwindowException();
            }
            else if (error == 4207)
            {
                throw new SomeObjectErrorException();
            }
            else if (error == 4210)
            {
                throw new ChartPropInvalidException();
            }
            else if (error == 4211)
            {
                throw new ChartNotFoundException();
            }
            else if (error == 4212)
            {
                throw new ChartwindowNotFoundException();
            }
            else if (error == 4213)
            {
                throw new ChartindicatorNotFoundException();
            }
            else if (error == 4220)
            {
                throw new SymbolSelectException();
            }
            else if (error == 4250)
            {
                throw new NotificationErrorException();
            }
            else if (error == 4251)
            {
                throw new NotificationParameterException();
            }
            else if (error == 4252)
            {
                throw new NotificationSettingsException();
            }
            else if (error == 4253)
            {
                throw new NotificationTooFrequentException();
            }
            else if (error == 4260)
            {
                throw new FtpNoserverException();
            }
            else if (error == 4261)
            {
                throw new FtpNologinException();
            }
            else if (error == 4262)
            {
                throw new FtpConnectFailedException();
            }
            else if (error == 4263)
            {
                throw new FtpClosedException();
            }
            else if (error == 4264)
            {
                throw new FtpChangedirException();
            }
            else if (error == 4265)
            {
                throw new FtpFileErrorException();
            }
            else if (error == 4266)
            {
                throw new FtpErrorException();
            }
            else if (error == 5001)
            {
                throw new FileTooManyOpenedException();
            }
            else if (error == 5002)
            {
                throw new FileWrongFilenameException();
            }
            else if (error == 5003)
            {
                throw new FileTooLongFilenameException();
            }
            else if (error == 5004)
            {
                throw new FileCannotOpenException();
            }
            else if (error == 5005)
            {
                throw new FileBufferAllocationErrorException();
            }
            else if (error == 5006)
            {
                throw new FileCannotDeleteException();
            }
            else if (error == 5007)
            {
                throw new FileInvalidHandleException();
            }
            else if (error == 5008)
            {
                throw new FileWrongHandleException();
            }
            else if (error == 5009)
            {
                throw new FileNotTowriteException();
            }
            else if (error == 5010)
            {
                throw new FileNotToreadException();
            }
            else if (error == 5011)
            {
                throw new FileNotBinException();
            }
            else if (error == 5012)
            {
                throw new FileNotTxtException();
            }
            else if (error == 5013)
            {
                throw new FileNotTxtorcsvException();
            }
            else if (error == 5014)
            {
                throw new FileNotCsvException();
            }
            else if (error == 5015)
            {
                throw new FileReadErrorException();
            }
            else if (error == 5016)
            {
                throw new FileWriteErrorException();
            }
            else if (error == 5017)
            {
                throw new FileBinStringsizeException();
            }
            else if (error == 5018)
            {
                throw new FileIncompatibleException();
            }
            else if (error == 5019)
            {
                throw new FileIsDirectoryException();
            }
            else if (error == 5020)
            {
                throw new FileNotExistException();
            }
            else if (error == 5021)
            {
                throw new FileCannotRewriteException();
            }
            else if (error == 5022)
            {
                throw new FileWrongDirectorynameException();
            }
            else if (error == 5023)
            {
                throw new FileDirectoryNotExistException();
            }
            else if (error == 5024)
            {
                throw new FileNotDirectoryException();
            }
            else if (error == 5025)
            {
                throw new FileCannotDeleteDirectoryException();
            }
            else if (error == 5026)
            {
                throw new FileCannotCleanDirectoryException();
            }
            else if (error == 5027)
            {
                throw new FileArrayresizeErrorException();
            }
            else if (error == 5028)
            {
                throw new FileStringresizeErrorException();
            }
            else if (error == 5029)
            {
                throw new FileStructWithObjectsException();
            }
            else if (error == 5200)
            {
                throw new WebrequestInvalidAddressException();
            }
            else if (error == 5201)
            {
                throw new WebrequestConnectFailedException();
            }
            else if (error == 5202)
            {
                throw new WebrequestTimeoutException();
            }
            else if (error == 5203)
            {
                throw new WebrequestRequestFailedException();
            }
            else if (error == 65536)
            {
                throw new UserErrorFirstException();
            }
        }
    }

    public class NoResultException : MQLExceptions
    {
        public NoResultException() : base("No error returned, but the result is unknown")
        {

        }
    }
    public class CommonErrorException : MQLExceptions
    {
        public CommonErrorException() : base("Common error")
        {

        }
    }
    public class InvalidTradeParametersException : MQLExceptions
    {
        public InvalidTradeParametersException() : base("Invalid trade parameters")
        {

        }
    }
    public class ServerBusyException : MQLExceptions
    {
        public ServerBusyException() : base("Trade server is busy")
        {

        }
    }
    public class OldVersionException : MQLExceptions
    {
        public OldVersionException() : base("Old version of the client terminal")
        {

        }
    }
    public class NoConnectionException : MQLExceptions
    {
        public NoConnectionException() : base("No connection with trade server")
        {

        }
    }
    public class NotEnoughRightsException : MQLExceptions
    {
        public NotEnoughRightsException() : base("Not enough rights")
        {

        }
    }
    public class TooFrequentRequestsException : MQLExceptions
    {
        public TooFrequentRequestsException() : base("Too frequent requests")
        {

        }
    }
    public class MalfunctionalTradeException : MQLExceptions
    {
        public MalfunctionalTradeException() : base("Malfunctional trade operation")
        {

        }
    }
    public class AccountDisabledException : MQLExceptions
    {
        public AccountDisabledException() : base("Account disabled")
        {

        }
    }
    public class InvalidAccountException : MQLExceptions
    {
        public InvalidAccountException() : base("Invalid account")
        {

        }
    }
    public class TradeTimeoutException : MQLExceptions
    {
        public TradeTimeoutException() : base("Trade timeout")
        {

        }
    }
    public class InvalidPriceException : MQLExceptions
    {
        public InvalidPriceException() : base("Invalid price")
        {

        }
    }
    public class InvalidStopsException : MQLExceptions
    {
        public InvalidStopsException() : base("Invalid stops")
        {

        }
    }
    public class InvalidTradeVolumeException : MQLExceptions
    {
        public InvalidTradeVolumeException() : base("Invalid trade volume")
        {

        }
    }
    public class MarketClosedException : MQLExceptions
    {
        public MarketClosedException() : base("Market is closed")
        {

        }
    }
    public class TradeDisabledException : MQLExceptions
    {
        public TradeDisabledException() : base("Trade is disabled")
        {

        }
    }
    public class NotEnoughMoneyException : MQLExceptions
    {
        public NotEnoughMoneyException() : base("Not enough money")
        {

        }
    }
    public class PriceChangedException : MQLExceptions
    {
        public PriceChangedException() : base("Price changed")
        {

        }
    }
    public class OffQuotesException : MQLExceptions
    {
        public OffQuotesException() : base("Off quotes")
        {

        }
    }
    public class BrokerBusyException : MQLExceptions
    {
        public BrokerBusyException() : base("Broker is busy")
        {

        }
    }
    public class RequoteException : MQLExceptions
    {
        public RequoteException() : base("Requote")
        {

        }
    }
    public class OrderLockedException : MQLExceptions
    {
        public OrderLockedException() : base("Order is locked")
        {

        }
    }
    public class LongPositionsOnlyAllowedException : MQLExceptions
    {
        public LongPositionsOnlyAllowedException() : base("Buy orders only allowed")
        {

        }
    }
    public class TooManyRequestsException : MQLExceptions
    {
        public TooManyRequestsException() : base("Too many requests")
        {

        }
    }
    public class TradeModifyDeniedException : MQLExceptions
    {
        public TradeModifyDeniedException() : base("Modification denied because order is too close to market")
        {

        }
    }
    public class TradeContextBusyException : MQLExceptions
    {
        public TradeContextBusyException() : base("Trade context is busy")
        {

        }
    }
    public class TradeExpirationDeniedException : MQLExceptions
    {
        public TradeExpirationDeniedException() : base("Expirations are denied by broker")
        {

        }
    }
    public class TradeTooManyOrdersException : MQLExceptions
    {
        public TradeTooManyOrdersException() : base("The amount of open and pending orders has reached the limit set by the broker")
        {

        }
    }
    public class TradeHedgeProhibitedException : MQLExceptions
    {
        public TradeHedgeProhibitedException() : base("An attempt to open an order opposite to the existing one when hedging is disabled")
        {

        }
    }
    public class TradeProhibitedByFifoException : MQLExceptions
    {
        public TradeProhibitedByFifoException() : base("An attempt to close an order contravening the FIFO rule")
        {

        }
    }
    public class NoMqlerrorException : MQLExceptions
    {
        public NoMqlerrorException() : base("No error returned")
        {

        }
    }
    public class WrongFunctionPointerException : MQLExceptions
    {
        public WrongFunctionPointerException() : base("Wrong function pointer")
        {

        }
    }
    public class ArrayIndexOutOfRangeException : MQLExceptions
    {
        public ArrayIndexOutOfRangeException() : base("Array index is out of range")
        {

        }
    }
    public class NoMemoryForCallStackException : MQLExceptions
    {
        public NoMemoryForCallStackException() : base("No memory for function call stack")
        {

        }
    }
    public class RecursiveStackOverflowException : MQLExceptions
    {
        public RecursiveStackOverflowException() : base("Recursive stack overflow")
        {

        }
    }
    public class NotEnoughStackForParamException : MQLExceptions
    {
        public NotEnoughStackForParamException() : base("Not enough stack for parameter")
        {

        }
    }
    public class NoMemoryForParamStringException : MQLExceptions
    {
        public NoMemoryForParamStringException() : base("No memory for parameter string")
        {

        }
    }
    public class NoMemoryForTempStringException : MQLExceptions
    {
        public NoMemoryForTempStringException() : base("No memory for temp string")
        {

        }
    }
    public class NotInitializedStringException : MQLExceptions
    {
        public NotInitializedStringException() : base("Not initialized string")
        {

        }
    }
    public class NotInitializedArraystringException : MQLExceptions
    {
        public NotInitializedArraystringException() : base("Not initialized string in array")
        {

        }
    }
    public class NoMemoryForArraystringException : MQLExceptions
    {
        public NoMemoryForArraystringException() : base("No memory for array string")
        {

        }
    }
    public class TooLongStringException : MQLExceptions
    {
        public TooLongStringException() : base("Too long string")
        {

        }
    }
    public class RemainderFromZeroDivideException : MQLExceptions
    {
        public RemainderFromZeroDivideException() : base("Remainder from zero divide")
        {

        }
    }
    public class ZeroDivideException : MQLExceptions
    {
        public ZeroDivideException() : base("Zero divide")
        {

        }
    }
    public class UnknownCommandException : MQLExceptions
    {
        public UnknownCommandException() : base("Unknown command")
        {

        }
    }
    public class WrongJumpException : MQLExceptions
    {
        public WrongJumpException() : base("Wrong jump (never generated error)")
        {

        }
    }
    public class NotInitializedArrayException : MQLExceptions
    {
        public NotInitializedArrayException() : base("Not initialized array")
        {

        }
    }
    public class DllCallsNotAllowedException : MQLExceptions
    {
        public DllCallsNotAllowedException() : base("DLL calls are not allowed")
        {

        }
    }
    public class CannotLoadLibraryException : MQLExceptions
    {
        public CannotLoadLibraryException() : base("Cannot load library")
        {

        }
    }
    public class CannotCallFunctionException : MQLExceptions
    {
        public CannotCallFunctionException() : base("Cannot call function")
        {

        }
    }
    public class ExternalCallsNotAllowedException : MQLExceptions
    {
        public ExternalCallsNotAllowedException() : base("Expert function calls are not allowed")
        {

        }
    }
    public class NoMemoryForReturnedStrException : MQLExceptions
    {
        public NoMemoryForReturnedStrException() : base("Not enough memory for temp string returned from function")
        {

        }
    }
    public class SystemBusyException : MQLExceptions
    {
        public SystemBusyException() : base("System is busy (never generated error)")
        {

        }
    }
    public class DllfuncCriticalerrorException : MQLExceptions
    {
        public DllfuncCriticalerrorException() : base("DLL-function call critical error")
        {

        }
    }
    public class InternalErrorException : MQLExceptions
    {
        public InternalErrorException() : base("Internal error")
        {

        }
    }
    public class OutOfMemoryException : MQLExceptions
    {
        public OutOfMemoryException() : base("Out of memory")
        {

        }
    }
    public class InvalidPointerException : MQLExceptions
    {
        public InvalidPointerException() : base("Invalid pointer")
        {

        }
    }
    public class FormatTooManyFormattersException : MQLExceptions
    {
        public FormatTooManyFormattersException() : base("Too many formatters in the format function")
        {

        }
    }
    public class FormatTooManyParametersException : MQLExceptions
    {
        public FormatTooManyParametersException() : base("Parameters count exceeds formatters count")
        {

        }
    }
    public class ArrayInvalidException : MQLExceptions
    {
        public ArrayInvalidException() : base("Invalid array")
        {

        }
    }
    public class ChartNoreplyException : MQLExceptions
    {
        public ChartNoreplyException() : base("No reply from chart")
        {

        }
    }
    public class InvalidFunctionParamscntException : MQLExceptions
    {
        public InvalidFunctionParamscntException() : base("Invalid function parameters count")
        {

        }
    }
    public class InvalidFunctionParamvalueException : MQLExceptions
    {
        public InvalidFunctionParamvalueException() : base("Invalid function parameter value")
        {

        }
    }
    public class StringFunctionInternalException : MQLExceptions
    {
        public StringFunctionInternalException() : base("String function internal error")
        {

        }
    }
    public class SomeArrayErrorException : MQLExceptions
    {
        public SomeArrayErrorException() : base("Some array error")
        {

        }
    }
    public class IncorrectSeriesarrayUsingException : MQLExceptions
    {
        public IncorrectSeriesarrayUsingException() : base("Incorrect series array using")
        {

        }
    }
    public class CustomIndicatorErrorException : MQLExceptions
    {
        public CustomIndicatorErrorException() : base("Custom indicator error")
        {

        }
    }
    public class IncompatibleArraysException : MQLExceptions
    {
        public IncompatibleArraysException() : base("Arrays are incompatible")
        {

        }
    }
    public class GlobalVariablesProcessingException : MQLExceptions
    {
        public GlobalVariablesProcessingException() : base("Global variables processing error")
        {

        }
    }
    public class GlobalVariableNotFoundException : MQLExceptions
    {
        public GlobalVariableNotFoundException() : base("Global variable not found")
        {

        }
    }
    public class FuncNotAllowedInTestingException : MQLExceptions
    {
        public FuncNotAllowedInTestingException() : base("Function is not allowed in testing mode")
        {

        }
    }
    public class FunctionNotConfirmedException : MQLExceptions
    {
        public FunctionNotConfirmedException() : base("Function is not allowed for call")
        {

        }
    }
    public class SendMailErrorException : MQLExceptions
    {
        public SendMailErrorException() : base("Send mail error")
        {

        }
    }
    public class StringParameterExpectedException : MQLExceptions
    {
        public StringParameterExpectedException() : base("String parameter expected")
        {

        }
    }
    public class IntegerParameterExpectedException : MQLExceptions
    {
        public IntegerParameterExpectedException() : base("Integer parameter expected")
        {

        }
    }
    public class DoubleParameterExpectedException : MQLExceptions
    {
        public DoubleParameterExpectedException() : base("Double parameter expected")
        {

        }
    }
    public class ArrayAsParameterExpectedException : MQLExceptions
    {
        public ArrayAsParameterExpectedException() : base("Array as parameter expected")
        {

        }
    }
    public class HistoryWillUpdatedException : MQLExceptions
    {
        public HistoryWillUpdatedException() : base("Requested history data is in updating state")
        {

        }
    }
    public class TradeErrorException : MQLExceptions
    {
        public TradeErrorException() : base("Internal trade error")
        {

        }
    }
    public class ResourceNotFoundException : MQLExceptions
    {
        public ResourceNotFoundException() : base("Resource not found")
        {

        }
    }
    public class ResourceNotSupportedException : MQLExceptions
    {
        public ResourceNotSupportedException() : base("Resource not supported")
        {

        }
    }
    public class ResourceDuplicatedException : MQLExceptions
    {
        public ResourceDuplicatedException() : base("Duplicate resource")
        {

        }
    }
    public class IndicatorCannotInitException : MQLExceptions
    {
        public IndicatorCannotInitException() : base("Custom indicator cannot initialize")
        {

        }
    }
    public class IndicatorCannotLoadException : MQLExceptions
    {
        public IndicatorCannotLoadException() : base("Cannot load custom indicator")
        {

        }
    }
    public class NoHistoryDataException : MQLExceptions
    {
        public NoHistoryDataException() : base("No history data")
        {

        }
    }
    public class NoMemoryForHistoryException : MQLExceptions
    {
        public NoMemoryForHistoryException() : base("No memory for history data")
        {

        }
    }
    public class NoMemoryForIndicatorException : MQLExceptions
    {
        public NoMemoryForIndicatorException() : base("Not enough memory for indicator calculation")
        {

        }
    }
    public class EndOfFileException : MQLExceptions
    {
        public EndOfFileException() : base("End of file")
        {

        }
    }
    public class SomeFileErrorException : MQLExceptions
    {
        public SomeFileErrorException() : base("Some file error")
        {

        }
    }
    public class WrongFileNameException : MQLExceptions
    {
        public WrongFileNameException() : base("Wrong file name")
        {

        }
    }
    public class TooManyOpenedFilesException : MQLExceptions
    {
        public TooManyOpenedFilesException() : base("Too many opened files")
        {

        }
    }
    public class CannotOpenFileException : MQLExceptions
    {
        public CannotOpenFileException() : base("Cannot open file")
        {

        }
    }
    public class IncompatibleFileaccessException : MQLExceptions
    {
        public IncompatibleFileaccessException() : base("Incompatible access to a file")
        {

        }
    }
    public class NoOrderSelectedException : MQLExceptions
    {
        public NoOrderSelectedException() : base("No order selected")
        {

        }
    }
    public class UnknownSymbolException : MQLExceptions
    {
        public UnknownSymbolException() : base("Unknown symbol")
        {

        }
    }
    public class InvalidPriceParamException : MQLExceptions
    {
        public InvalidPriceParamException() : base("Invalid price")
        {

        }
    }
    public class InvalidTicketException : MQLExceptions
    {
        public InvalidTicketException() : base("Invalid ticket")
        {

        }
    }
    public class TradeNotAllowedException : MQLExceptions
    {
        public TradeNotAllowedException() : base("Trade is not allowed. Enable checkbox")
        {

        }
    }
    public class LongsNotAllowedException : MQLExceptions
    {
        public LongsNotAllowedException() : base("Longs are not allowed. Check the Expert Advisor properties")
        {

        }
    }
    public class ShortsNotAllowedExceptionException : MQLExceptions
    {
        public ShortsNotAllowedExceptionException() : base("Shorts are not allowed. Check the Expert Advisor properties")
        {

        }
    }
    public class TradeExpertDisabledByServerException : MQLExceptions
    {
        public TradeExpertDisabledByServerException() : base("Automated trading by Expert Advisors/Scripts disabled by trade server")
        {

        }
    }
    public class ObjectAlreadyExistsException : MQLExceptions
    {
        public ObjectAlreadyExistsException() : base("Object already exists")
        {

        }
    }
    public class UnknownObjectPropertyException : MQLExceptions
    {
        public UnknownObjectPropertyException() : base("Unknown object property")
        {

        }
    }
    public class ObjectDoesNotExistException : MQLExceptions
    {
        public ObjectDoesNotExistException() : base("Object does not exist")
        {

        }
    }
    public class UnknownObjectTypeException : MQLExceptions
    {
        public UnknownObjectTypeException() : base("Unknown object type")
        {

        }
    }
    public class NoObjectNameException : MQLExceptions
    {
        public NoObjectNameException() : base("No object name")
        {

        }
    }
    public class ObjectCoordinatesErrorException : MQLExceptions
    {
        public ObjectCoordinatesErrorException() : base("Object coordinates error")
        {

        }
    }
    public class NoSpecifiedSubwindowException : MQLExceptions
    {
        public NoSpecifiedSubwindowException() : base("No specified subwindow")
        {

        }
    }
    public class SomeObjectErrorException : MQLExceptions
    {
        public SomeObjectErrorException() : base("Graphical object error")
        {

        }
    }
    public class ChartPropInvalidException : MQLExceptions
    {
        public ChartPropInvalidException() : base("Unknown chart property")
        {

        }
    }
    public class ChartNotFoundException : MQLExceptions
    {
        public ChartNotFoundException() : base("Chart not found")
        {

        }
    }
    public class ChartwindowNotFoundException : MQLExceptions
    {
        public ChartwindowNotFoundException() : base("Chart subwindow not found")
        {

        }
    }
    public class ChartindicatorNotFoundException : MQLExceptions
    {
        public ChartindicatorNotFoundException() : base("Chart indicator not found")
        {

        }
    }
    public class SymbolSelectException : MQLExceptions
    {
        public SymbolSelectException() : base("Symbol select error")
        {

        }
    }
    public class NotificationErrorException : MQLExceptions
    {
        public NotificationErrorException() : base("Notification error")
        {

        }
    }
    public class NotificationParameterException : MQLExceptions
    {
        public NotificationParameterException() : base("Notification parameter error")
        {

        }
    }
    public class NotificationSettingsException : MQLExceptions
    {
        public NotificationSettingsException() : base("Notifications disabled")
        {

        }
    }
    public class NotificationTooFrequentException : MQLExceptions
    {
        public NotificationTooFrequentException() : base("Notification send too frequent")
        {

        }
    }
    public class FtpNoserverException : MQLExceptions
    {
        public FtpNoserverException() : base("FTP server is not specified")
        {

        }
    }
    public class FtpNologinException : MQLExceptions
    {
        public FtpNologinException() : base("FTP login is not specified")
        {

        }
    }
    public class FtpConnectFailedException : MQLExceptions
    {
        public FtpConnectFailedException() : base("FTP connection failed")
        {

        }
    }
    public class FtpClosedException : MQLExceptions
    {
        public FtpClosedException() : base("FTP connection closed")
        {

        }
    }
    public class FtpChangedirException : MQLExceptions
    {
        public FtpChangedirException() : base("FTP path not found on server")
        {

        }
    }
    public class FtpFileErrorException : MQLExceptions
    {
        public FtpFileErrorException() : base("File not found in the MQL4\\Files directory to send on FTP server")
        {

        }
    }
    public class FtpErrorException : MQLExceptions
    {
        public FtpErrorException() : base("Common error during FTP data transmission")
        {

        }
    }
    public class FileTooManyOpenedException : MQLExceptions
    {
        public FileTooManyOpenedException() : base("Too many opened files")
        {

        }
    }
    public class FileWrongFilenameException : MQLExceptions
    {
        public FileWrongFilenameException() : base("Wrong file name")
        {

        }
    }
    public class FileTooLongFilenameException : MQLExceptions
    {
        public FileTooLongFilenameException() : base("Too long file name")
        {

        }
    }
    public class FileCannotOpenException : MQLExceptions
    {
        public FileCannotOpenException() : base("Cannot open file")
        {

        }
    }
    public class FileBufferAllocationErrorException : MQLExceptions
    {
        public FileBufferAllocationErrorException() : base("Text file buffer allocation error")
        {

        }
    }
    public class FileCannotDeleteException : MQLExceptions
    {
        public FileCannotDeleteException() : base("Cannot delete file")
        {

        }
    }
    public class FileInvalidHandleException : MQLExceptions
    {
        public FileInvalidHandleException() : base("Invalid file handle (file closed or was not opened)")
        {

        }
    }
    public class FileWrongHandleException : MQLExceptions
    {
        public FileWrongHandleException() : base("Wrong file handle (handle index is out of handle table)")
        {

        }
    }
    public class FileNotTowriteException : MQLExceptions
    {
        public FileNotTowriteException() : base("File must be opened with FILE_WRITE flag")
        {

        }
    }
    public class FileNotToreadException : MQLExceptions
    {
        public FileNotToreadException() : base("File must be opened with FILE_READ flag")
        {

        }
    }
    public class FileNotBinException : MQLExceptions
    {
        public FileNotBinException() : base("File must be opened with FILE_BIN flag")
        {

        }
    }
    public class FileNotTxtException : MQLExceptions
    {
        public FileNotTxtException() : base("File must be opened with FILE_TXT flag")
        {

        }
    }
    public class FileNotTxtorcsvException : MQLExceptions
    {
        public FileNotTxtorcsvException() : base("File must be opened with FILE_TXT or FILE_CSV flag")
        {

        }
    }
    public class FileNotCsvException : MQLExceptions
    {
        public FileNotCsvException() : base("File must be opened with FILE_CSV flag")
        {

        }
    }
    public class FileReadErrorException : MQLExceptions
    {
        public FileReadErrorException() : base("File read error")
        {

        }
    }
    public class FileWriteErrorException : MQLExceptions
    {
        public FileWriteErrorException() : base("File write error")
        {

        }
    }
    public class FileBinStringsizeException : MQLExceptions
    {
        public FileBinStringsizeException() : base("String size must be specified for binary file")
        {

        }
    }
    public class FileIncompatibleException : MQLExceptions
    {
        public FileIncompatibleException() : base("Incompatible file (for string arrays-TXT, for others-BIN)")
        {

        }
    }
    public class FileIsDirectoryException : MQLExceptions
    {
        public FileIsDirectoryException() : base("File is directory not file")
        {

        }
    }
    public class FileNotExistException : MQLExceptions
    {
        public FileNotExistException() : base("File does not exist")
        {

        }
    }
    public class FileCannotRewriteException : MQLExceptions
    {
        public FileCannotRewriteException() : base("File cannot be rewritten")
        {

        }
    }
    public class FileWrongDirectorynameException : MQLExceptions
    {
        public FileWrongDirectorynameException() : base("Wrong directory name")
        {

        }
    }
    public class FileDirectoryNotExistException : MQLExceptions
    {
        public FileDirectoryNotExistException() : base("Directory does not exist")
        {

        }
    }
    public class FileNotDirectoryException : MQLExceptions
    {
        public FileNotDirectoryException() : base("Specified file is not directory")
        {

        }
    }
    public class FileCannotDeleteDirectoryException : MQLExceptions
    {
        public FileCannotDeleteDirectoryException() : base("Cannot delete directory")
        {

        }
    }
    public class FileCannotCleanDirectoryException : MQLExceptions
    {
        public FileCannotCleanDirectoryException() : base("Cannot clean directory")
        {

        }
    }
    public class FileArrayresizeErrorException : MQLExceptions
    {
        public FileArrayresizeErrorException() : base("Array resize error")
        {

        }
    }
    public class FileStringresizeErrorException : MQLExceptions
    {
        public FileStringresizeErrorException() : base("String resize error")
        {

        }
    }
    public class FileStructWithObjectsException : MQLExceptions
    {
        public FileStructWithObjectsException() : base("Structure contains strings or dynamic arrays")
        {

        }
    }
    public class WebrequestInvalidAddressException : MQLExceptions
    {
        public WebrequestInvalidAddressException() : base("Invalid URL")
        {

        }
    }
    public class WebrequestConnectFailedException : MQLExceptions
    {
        public WebrequestConnectFailedException() : base("Failed to connect to specified URL")
        {

        }
    }
    public class WebrequestTimeoutException : MQLExceptions
    {
        public WebrequestTimeoutException() : base("Timeout exceeded")
        {

        }
    }
    public class WebrequestRequestFailedException : MQLExceptions
    {
        public WebrequestRequestFailedException() : base("HTTP request failed")
        {

        }
    }
    public class UserErrorFirstException : MQLExceptions
    {
        public UserErrorFirstException() : base("User defined errors start with this code")
        {

        }
    }

}
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using mqlsharp.Util;
using MQL4CSharp.Base.Enums;
using MQL4CSharp.Base.MQL;

namespace MQL4CSharp.Base
{
    public abstract class BaseStrategy : MQLBase
    {
        public ILog LOG;

        public BaseStrategy()
        {
            LOG = LogManager.GetLogger(GetType());
        }


        public JStrategy(String strategyName)
        {
            super();
            LOG.info("Running JStrategy: " + strategyName);
        }

        /**
         *
         * @param symbol
         * @param timeframe
         * @param strategyRunner
         */
        @Override
    public synchronized void init(String symbol, int timeframe, StrategyRunner strategyRunner) throws ErrUnknownSymbol, IOException
    {
        LOG.info("Running init method");
        super.init(symbol, timeframe, strategyRunner);

        symbols = Arrays.asList(new String[]{symbol
    });

        LOG.info("Symbols: " + symbols.toString());
    }

@Override
    public long coordinationIntervalMillis()
{
    return 100; // check market each 100ms seconds
}

/**
 *
 */
@Override
    public void coordinate()
{
    for (String symbol : symbols)
    {
        try
        {
            this.manageOpenTrades(symbol);

            if (this.isAsleep(symbol))
            {
                continue;
            }

            // Check for a signal
            int signal = this.evaluate(symbol);
            if (signal != 0)
            {
                this.executeTrade(symbol, signal);
            }
        }
        catch (Exception ex)
        {
            LOG.error(null, ex);
            //System.exit(0);
        }
    }
    //LOG.info( "Leaving coordinate");
}

/* This method closes the paper trade */
HashMap<String, Integer> openTradeTicket = new HashMap();

public void recordTradeClose(String symbol) throws Exception
{
        if (openTradeTicket.containsKey(symbol))
        {
        // record close trade
        LOG.info("ticket: " + openTradeTicket.get(symbol));
        //tradeReport.closeOpenTrade(this, symbol, openTradeTicket.get(symbol));
        openTradeTicket.remove(symbol);
    }
}
/* This function is for recording trades only, will not send to server */
int ticket = 0;

public void recordTradeOpen(String symbol, int signal) throws Exception
{
    TradeOperation op;
        double price;
        int slippage = 5;
        double stoploss = this.getStopLoss(symbol, signal);
        double takeprofit = this.getTakeProfit(symbol, signal);
        double lots = this.getLotSize(symbol, stoploss);

        if (signal == Signal.LONG)
        {
        op = TradeOperation.OP_BUY;
        //price = this.marketInfo(symbol, MarketInfo.MODE_ASK);
        price = this.iClose(symbol, Timeframe.PERIOD_D1, 0) + this.marketInfo(this.symbol(), MarketInfo.MODE_SPREAD) * this.marketInfo(this.symbol(), MarketInfo.MODE_POINT);
    }
        else if (signal == Signal.SHORT)
        {
        op = TradeOperation.OP_SELL;
        //price = this.marketInfo(symbol, MarketInfo.MODE_BID);
        price = this.iClose(symbol, Timeframe.PERIOD_D1, 0);
    }
        else if (signal == Signal.BUYSTOP)
        {
        op = TradeOperation.OP_BUYSTOP;
        price = this.getStopEntry(symbol, signal);
    }
        else if (signal == Signal.SELLSTOP)
        {
        op = TradeOperation.OP_SELLSTOP;
        price = this.getStopEntry(symbol, signal);
    }
        else
        {
        throw new Exception("Invalid Signal signal=" + signal);
    }

    //MapType<String, Object> tradeReportEntry = getTradeReportEntry(++ticket, this.marketInfo_MODE_TIME(this.symbol()), symbol, op, lots, price, stoploss, takeprofit);
    //tradeReport.getTradeHistory().put(ticket, tradeReportEntry);
    openTradeTicket.put(symbol, ticket);

    LOG.info("Trade executed ticket={0}", new Object[]{ticket});
    }

    @Override
    public void deinit()
{
    /*
    //System.err.println("=== TradeReport ===");
    try {
        //JaxbUtil.marshal(tradeReport, new File(DIR + "\\" + DATE + "\\tradeReport_" + this.symbol() + ".xml"));

        String filename = DIR + "\\" + DATE + "\\tradeReport.xml";
        System.err.print("Saving " + filename + " .. ");
        JaxbUtil.marshal(tradeReport, new File(filename));
        System.err.println(" Done!");

        filename = DIR + "\\" + DATE + "\\tradeReport.csv";
        System.err.print("Saving " + filename + " .. ");
        FileUtils.writeStringToFile(new File(filename), tradeReport.toCSV(","));
        System.err.println(" Done!");

        //System.err.println(JaxbUtil.marshalToString(tradeReport));
        //System.err.println(JaxbUtil.unmarshal(TradeReport.class, JaxbUtil.marshalToString(tradeReport)).toString());
    } catch (Exception ex) {
        LoggerFactory.getLogger(JStrategy.class.getName()).log(Level.SEVERE, null, ex);
    }
    */
}

public double pipToPoint(String symbol) throws Exception
{
        if (marketInfo(symbol, MarketInfo.MODE_DIGITS) == 3 || marketInfo(symbol, MarketInfo.MODE_DIGITS)  == 5)
        {
        return 10 * marketInfo(symbol, MarketInfo.MODE_TICKSIZE);
    }
        else
        {
        return marketInfo(symbol, MarketInfo.MODE_TICKSIZE);
    }
}

private void updateBarStats(String symbol) throws ErrHistoryWillUpdated, ErrUnknownSymbol {
        /*
        BarStatsRecord barStatsRecord;
        for (Timeframe timeframe : BarStats.timeframes) {
            // Check for a bar change
            barStatsRecord = barStats.get(symbol).getHashMap().get(timeframe);
            //LOG.info( "updateBarStats barTime={0} newTime={1}", new Object[]{barStatsRecord.getTime(), iTime(symbol, timeframe, 0)});
            if (iTime(symbol, timeframe, 0).equals((barStatsRecord.getTime()))) {
                barStatsRecord.update(marketInfo_MODE_TIME(symbol));
            } else {
                barStatsRecord.init(iTime(symbol, timeframe, 0), marketInfo_MODE_TIME(symbol));
            }
            barStats.get(symbol).getHashMap().put(timeframe, barStatsRecord);
        }
        //LOG.info( "updateBarStats {0}",  barStats.get(symbol).toString());
        */
    }

    // Method to execute the trade
    public void executeTrade(String symbol, int signal) throws Exception
{
    TradeOperation op;
        double price, lots;
        int slippage = 5;
        double stoploss = this.getStopLoss(symbol, signal);

        double takeprofit = this.getTakeProfit(symbol, signal);
    String comment = this.getComment(symbol);
        int magic = this.getMagicNumber(symbol);
    Date expiration = null;
    Color arrowColor = Color.Aqua;

    Date lastBuyOpen, lastSellOpen;
    boolean openBuyOrder = false, openSellOrder = false, openBuyStopOrder = false, openSellStopOrder = false;

        if (signal == Signal.LONG)
        {
        op = TradeOperation.OP_BUY;
        price = this.marketInfo(symbol, MarketInfo.MODE_ASK);
    }
        else if (signal == Signal.SHORT)
        {
        op = TradeOperation.OP_SELL;
        price = this.marketInfo(symbol, MarketInfo.MODE_BID);
    }
        else if (signal == Signal.BUYSTOP)
        {
        op = TradeOperation.OP_BUYSTOP;
        price = this.getStopEntry(symbol, signal);
    }
        else if (signal == Signal.SELLSTOP)
        {
        op = TradeOperation.OP_SELLSTOP;
        price = this.getStopEntry(symbol, signal);
    }
        else
        {
        throw new Exception("Invalid Signal signal=" + signal);
    }

    // Calculate lots
    lots = this.getLotSize(symbol, price);

        // Check open trades on this symbol
        for (int i = 0; i < this.ordersTotal(); i++)
        {
        this.orderSelect(i, SelectionType.SELECT_BY_POS, SelectionPool.MODE_TRADES);
        if (this.orderType() == TradeOperation._OP_BUY && this.orderSymbol().equals(symbol) && this.orderMagicNumber() == magic)
        {
            lastBuyOpen = this.orderOpenTime();
            openBuyOrder = true;
        }
        else if (this.orderType() == TradeOperation._OP_SELL && this.orderSymbol().equals(symbol) && this.orderMagicNumber() == magic)
        {
            lastSellOpen = this.orderOpenTime();
            openSellOrder = true;
        }
        else if (this.orderType() == TradeOperation._OP_BUYSTOP && this.orderSymbol().equals(symbol) && this.orderMagicNumber() == magic)
        {
            openBuyStopOrder = true;
        }
        else if (this.orderType() == TradeOperation._OP_SELLSTOP && this.orderSymbol().equals(symbol) && this.orderMagicNumber() == magic)
        {
            openSellStopOrder = true;
        }
    }

        if ((signal == Signal.LONG && !openBuyOrder) || (signal == Signal.SHORT && !openSellOrder) || (signal == Signal.BUYSTOP && !openBuyStopOrder) || (signal == Signal.SELLSTOP && !openSellStopOrder)) {
        LOG.info("Executing Trade on {0} at {1}", new Object[] { symbol, marketInfo_MODE_TIME(symbol) });
        refreshRates();
        if (signal == Signal.LONG)
        {
            price = this.marketInfo(symbol, MarketInfo.MODE_ASK);
        }
        else if (signal == Signal.SHORT)
        {
            price = this.marketInfo(symbol, MarketInfo.MODE_BID);
        }

        int ticket = this.orderSend(symbol, op, lots, price, slippage, stoploss, takeprofit, comment, magic, expiration, arrowColor.val);
        int err = this.getLastError();
    }
}

public void reportTrade()
{
    /*
    if (err == 0) {
        // Trade Report
        this.orderSelect(ticket, SelectionType.SELECT_BY_TICKET, SelectionPool.MODE_TRADES);

        MapType<String, Object> tradeReportEntry = getTradeReportEntry(ticket, this.orderOpenTime(), symbol, op, lots, price, stoploss, takeprofit);
        tradeReport.getTradeHistory().put(ticket, tradeReportEntry);

        //LOG.info( "Trade report entry={0}", new Object[]{tradeReportEntry.toString()});

        LOG.info( "Trade executed ticket={0}", new Object[]{ticket});


            /*
             *
             bool saveOpenChart(string path, int tradeNum)
             {
             int size_x = 1600;
             int size_y = 1200;

             return(WindowScreenShot( path + "\\" + AccountNumber() + "_" + tradeNum + ".gif", size_x, size_y, -1, -1, -1));
             }
             * /
        int size_x = 1600;
        int size_y = 1200;

        this.hideTestIndicators(false);
        this.windowScreenShot("reports\\" + DATE + "\\trade_" + ticket + ".png", size_x, size_y, -1, -1, -1);

    }
    else {
        LOG.info( "Error executing trade type={0} error={1}", new Object[]{op, err});
    }

    */
}

public List<String> getSymbolList()
{
    return symbols;
}

public void setSymbolList(List<String> symbols)
{
    this.symbols = symbols;
}

// Abstract method to evaluate the current tick and check whether or not a signal exists
public abstract int evaluate(String symbol) throws Exception;

public abstract double getStopLoss(String symbol, int signal) throws Exception;

public abstract double getTakeProfit(String symbol, int signal) throws Exception;

public abstract double getLotSize(String symbol, double stopDistance) throws Exception;

public abstract int getMagicNumber(String symbol) throws Exception;

public abstract String getComment(String symbol) throws Exception;

public abstract boolean isAsleep(String symbol) throws Exception;

// Non Abstract methods
public double getStopEntry(String symbol, int signal) throws Exception
{
        return 0;
}

// Method to manage the trade
public abstract void manageOpenTrades(String symbol) throws Exception;


    }
}
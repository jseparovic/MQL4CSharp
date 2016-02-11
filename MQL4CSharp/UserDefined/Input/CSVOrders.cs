using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using log4net.Repository.Hierarchy;
using mqlsharp.Util;

namespace MQL4CSharp.UserDefined.Input
{
    public class CSVOrders : List<CSVOrder>
    {
        public ILog LOG;

        static String file = "c:\\trading\\orders.csv";
        static char separator = ',';

        public static CSVOrders csvOrders { get; private set; }

        public static CSVOrders getInstance()
        {
            if(csvOrders == null)
            {
                csvOrders = new CSVOrders(file, separator);
            }
            return csvOrders;
        }

        public static CSVOrders getInstance(String file, char separator)
        {
            if(csvOrders == null)
            {
                csvOrders = new CSVOrders(file, separator);
            }
            return csvOrders;
        }

        private CSVOrders(String file, char separator)
        {
            LOG = LogManager.GetLogger(GetType());
            parse(file, separator);
        }

        private void parse(String fileName, char separator)
        {
            int counter = 0;
            string line;

            // Read the file and display it line by line.
            System.IO.StreamReader file =
               new System.IO.StreamReader(fileName);
            while ((line = file.ReadLine()) != null)
            {
                if(!line.StartsWith("#") && !line.Equals(""))
                {
                    String[] parts = line.Split(separator);
                    String pair = parts[0];
                    String setup = parts[1];
                    String timeframe = parts[2];
                    Double entry = Convert.ToDouble(parts[3]);
                    Double stop = Convert.ToDouble(parts[4]);
                    Double takeProfit1 = Convert.ToDouble(parts[5]);
                    Double takeProfit2 = Convert.ToDouble(parts[6]);
                    Add(new CSVOrder(pair, setup, timeframe, entry, stop, takeProfit1, takeProfit2));
                }
            }

            file.Close();

        }
    }

}

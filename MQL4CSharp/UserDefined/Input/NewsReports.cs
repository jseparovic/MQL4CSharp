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
    public class NewsReports : List<NewsReport>
    {
        public ILog LOG;

        static String file = "c:\\trading\\news.txt";
        static char separator = ',';

        private static NewsReports newsReports;

        public static NewsReports getInstance()
        {
            if(newsReports == null)
            {
                newsReports = new NewsReports(file, separator);
            }
            return newsReports;
        }

        public static NewsReports getInstance(String file, char separator)
        {
            if(newsReports == null)
            {
                newsReports = new NewsReports(file, separator);
            }
            return newsReports;
        }

        private NewsReports(String file, char separator)
        {
            LOG = LogManager.GetLogger(GetType());
            parseInputLevels(file, separator);
        }

        private void parseInputLevels(String fileName, char separator)
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
                    String name = parts[0];
                    String currency = parts[1];
                    DateTime dateTime = DateTime.Parse(parts[2], CultureInfo.CreateSpecificCulture("en-AU"));
                    String noEntryMinsPrior = parts[3];
                    String noEntryMinsPost = parts[4];
                    String closeOutMinsPrior = parts[5];

                    NewsReport nr = new NewsReport(name, currency, dateTime, Int32.Parse(noEntryMinsPrior), Int32.Parse(noEntryMinsPost), Int32.Parse(closeOutMinsPrior));


                    Add(nr);
                }
            }

            file.Close();

        }
    }

}

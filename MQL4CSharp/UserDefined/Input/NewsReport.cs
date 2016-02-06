using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MQL4CSharp.UserDefined.Input
{
    public class NewsReport
    {
        /**
         * News Report Name
         */
        string name;

        /**
         * The currency this report relates to. Eg: GBP, USD, EUR
         * Filter will use this to pick which symbol to apply filter to
          */
        String currency;

        DateTime datetime;

        /**
         * the filter will not open a trade X minutes prior to the release
         */
        int noEntryMinutesPrior;

        /**
         * the filter will not open a trade X minutes after to the release
         */
        int noEntryMinutesPost;

        /**
         * the filter will close open trades X minutes prior the release
         */
        int closeOutMinutesPrior;

        private DateTime noEntryPriorDateTime;
        private DateTime noEntryPostDateTime;
        private DateTime closeOutPriorDateTime;


        public NewsReport(string name, string currency, DateTime datetime, int noEntryMinutesPrior, int noEntryMinutesPost, int closeOutMinutesPrior)
        {
            this.name = name;
            this.currency = currency;
            this.datetime = datetime;
            this.noEntryMinutesPrior = noEntryMinutesPrior;
            this.noEntryMinutesPost = noEntryMinutesPost;
            this.closeOutMinutesPrior = closeOutMinutesPrior;

            this.noEntryPriorDateTime = datetime.AddMinutes(-noEntryMinutesPrior);
            this.noEntryPostDateTime = datetime.AddMinutes(noEntryMinutesPost);
            this.closeOutPriorDateTime = datetime.AddMinutes(-closeOutMinutesPrior);

        }

        public string getName()
        {
            return name;
        }

        public void setName(string name)
        {
            this.name = name;
        }

        public string getCurrency()
        {
            return currency;
        }

        public void setCurrency(string currency)
        {
            this.currency = currency;
        }

        public DateTime getDateTime()
        {
            return datetime;
        }

        public void setDateTime(DateTime datetime)
        {
            this.datetime = datetime;
        }

        public int getNoEntryMinutesPrior()
        {
            return noEntryMinutesPrior;
        }

        public void setNoEntryMinutesPrior(int noEntryMinutesPrior)
        {
            this.noEntryMinutesPrior = noEntryMinutesPrior;
        }

        public int getNoEntryMinutesPost()
        {
            return noEntryMinutesPost;
        }

        public void setNoEntryMinutesPost(int noEntryMinutesPost)
        {
            this.noEntryMinutesPost = noEntryMinutesPost;
        }

        public int getCloseOutMinutesPrior()
        {
            return closeOutMinutesPrior;
        }

        public void setCloseOutMinutesPrior(int closeOutMinutesPrior)
        {
            this.closeOutMinutesPrior = closeOutMinutesPrior;
        }

        public DateTime getNoEntryPrior()
        {
            return noEntryPriorDateTime;
        }

        public DateTime getNoEntryPost()
        {
            return noEntryPostDateTime;
        }

        public DateTime getCloseOutPrior()
        {
            return closeOutPriorDateTime;
        }

    }

}

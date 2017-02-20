using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Net.Mobilink
{
    class OutlookItem
    {

        public String EntryID { get; set; }

        private String fromSender;

        public String FromSender
        {
            get { return fromSender; }
            set { fromSender = value.ToUpper(); }
        }
        private String toReceiver;

        public String ToReceiver
        {
            get { return toReceiver; }
            set { toReceiver = value.ToUpper(); }
        }

        
        public String EmailSubject { get; set; }
        public String EmailBody { get; set; }
        public DateTime ReceiveAt { get; set; }
        public DateTime SentOn { get; set; }
        public long EmailSize { get; set; }
        public String AlgoType { get; set; }
        public String TypeOfItem { get; set; }
        public bool HasAttachment { get; set; }
        public String SubscriberNumber { get; set; }
        public String InvalidEmailID { get; set; }

        
        /// <summary>
        /// This Method will give you MSISDN (Subscriber Number) from the given Email Subject or will find from Email Body
        /// </summary>
        /// <param name="aEmailSubject">The Subject of the email, Original or one changed by Mail-delivery System.</param>
        /// <param name="aEmailBody">The Complete Body of the Email Item.</param>
        /// <returns>Subscriber Number</returns>
        public String GetMSISDN(String aEmailSubject, String aEmailBody)
        {

            int startOfIndex;
            int indexLength;
            String result;

            if (aEmailSubject.Contains("Estimated Bill of Mobile#"))
            {
                indexLength = 11;
                result =aEmailSubject.Substring(Math.Max(0, aEmailSubject.Length - indexLength));
                return result;

            }
            else if (aEmailBody.Contains("Estimated Bill of Mobile#"))
	            {
                    startOfIndex = 25 + aEmailBody.IndexOf("Estimated Bill of Mobile#");

                    indexLength = 11;
                    result = aEmailBody.Substring(startOfIndex, indexLength);
                   return result;
	            }
            else return null;

        }

        public String GetInvalidEmailID(String aEmailSubject, String aEmailBody)
        {

            int startOfIndex;
            int endOfIndex;
            int indexLength;
            String algorithmType;
            String result;
             
          
            if (aEmailBody.Contains("@yahoo.com"))
            {
                startOfIndex = 13 + aEmailBody.IndexOf("failed:");
                endOfIndex = 10 + aEmailBody.IndexOf("@yahoo.com");
                indexLength = endOfIndex - startOfIndex;
                result= aEmailBody.Substring(startOfIndex, indexLength);
                algorithmType = "A";
                //return result;
            }
            else if (aEmailBody.Contains("@hotmail.com"))
            {

                startOfIndex = 1 + aEmailBody.IndexOf("<");
                endOfIndex = aEmailBody.IndexOf(">");
                indexLength = endOfIndex - startOfIndex;
                result = aEmailBody.Substring(startOfIndex, indexLength);
                algorithmType = "B";
                //return result;
            }
            else if (aEmailSubject.Contains("Warning: message"))
            {

                if (aEmailBody.Contains("<"))
                {
                    startOfIndex = 1 + aEmailBody.IndexOf("<");
                    endOfIndex = aEmailBody.IndexOf(">");
                    indexLength = endOfIndex - startOfIndex;
                    result = aEmailBody.Substring(startOfIndex, indexLength);
                    algorithmType = "CA";
                    //return result;
                }
                else if (aEmailBody.Contains("has not yet been delivered is:"))
                {
                    startOfIndex = 36 + aEmailBody.IndexOf("has not yet been delivered is:");
                    endOfIndex = aEmailBody.IndexOf("No action is required on your part.") - 4;
                    indexLength = endOfIndex - startOfIndex;
                    result = aEmailBody.Substring(startOfIndex, indexLength);
                    algorithmType = "CB";
                    //return result;
                }
                else { 
                    result = null;
                    algorithmType = "CZ";   
                }

            }
            else if (aEmailSubject.Contains("Mail delivery failed:"))
            {
                if (aEmailBody.Contains("<"))
                {
                    startOfIndex = 1 + aEmailBody.IndexOf("<");
                    endOfIndex = aEmailBody.IndexOf(">");
                    indexLength = endOfIndex - startOfIndex;
                    result = aEmailBody.Substring(startOfIndex, indexLength);
                    algorithmType = "DA";
                    //return result;
                }
                else
                {
                    startOfIndex = 13 + aEmailBody.IndexOf("failed:");
                    endOfIndex = aEmailBody.Substring(startOfIndex).IndexOf(" ");
                    indexLength = endOfIndex - startOfIndex;
                    result = aEmailBody.Substring(startOfIndex, indexLength);
                    algorithmType = "DB";
                    //return result;
                }
            }
            else { 
                result = null;
                algorithmType = "DZ";
            }


            // Last Try to get Email ID
            if (result == "donotreplycc@mobilink.net")
            {

                startOfIndex = 13 + aEmailBody.IndexOf("failed:");
                endOfIndex = aEmailBody.IndexOf(" ", startOfIndex)-2;
                indexLength = endOfIndex - startOfIndex;
                result = aEmailBody.Substring(startOfIndex, indexLength);
                algorithmType = "E";
                //throw new Exception("donotreplycc ID Found");
            }


            if (result == null) { result = ""; }


            return result + "|" + algorithmType;

        }

       


    }
}

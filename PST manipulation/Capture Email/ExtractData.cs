using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Interop.Outlook;

namespace Net.Mobilink
{
    class ExtractData
    {

        public void GetMailItemsData(List<MailItem> aMailItemList, MAPIFolder aProcessedFolder, MAPIFolder aExceptionFolder)
        {




            foreach (MailItem myitem in aMailItemList)
            {
                OutlookItem myMailItem = new OutlookItem();
                EmailProperties myEmailProperties = new EmailProperties();


                try
                {
                    //Assign Values
                    myMailItem.EntryID = myitem.EntryID;
                    myMailItem.FromSender = myitem.SenderName;
                    myMailItem.ToReceiver = myitem.To;
                    myMailItem.EmailSubject = myitem.Subject;
                    myMailItem.EmailBody = myitem.Body;
                    //myMailItem.EmailBody = Encoding.UTF8.GetString(new UnicodeEncoding().GetBytes(myitem.Body));

                    //Get MSISDN from Subject or Body
                    myMailItem.SubscriberNumber = myMailItem.GetMSISDN(myMailItem.EmailSubject, myMailItem.EmailBody);
                    
                    //Get Email ID from Body
                    String[] SplitDataString = myMailItem.GetInvalidEmailID(myMailItem.EmailSubject, myMailItem.EmailBody).Split('|');                    
                    myMailItem.InvalidEmailID = (SplitDataString[0] == "") ? null : SplitDataString[0];
                    myMailItem.AlgoType = SplitDataString[1];

                    //myMailItem.InvalidEmailID = myMailItem.GetInvalidEmailID(myMailItem.EmailSubject, myMailItem.EmailBody).Split('|');

                    myMailItem.TypeOfItem = "MailItem";
                    myMailItem.HasAttachment = (Boolean)myitem.PropertyAccessor.GetProperty(myEmailProperties.PR_HASATTACH);
                    myMailItem.EmailSize = myitem.Size;
                    myMailItem.ReceiveAt = myitem.ReceivedTime;
                    myMailItem.SentOn = myitem.SentOn;

                    
                    //Display Some Info
                    Console.WriteLine(myMailItem.InvalidEmailID);
                    Console.WriteLine(myMailItem.FromSender);
                    Console.WriteLine(myMailItem.ToReceiver);
                    Console.WriteLine(myMailItem.EmailSubject);


                    //Insert Into Database 
                    new Database().InsertIntoTable(myMailItem);


                    //Move read items
                    myitem.Move(aProcessedFolder);

                }


                catch (System.Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    myitem.Move(aExceptionFolder);
                }

            }
        }


        public void GetReportItemsData(List<ReportItem> aReportItemList, MAPIFolder aProcessedFolder, MAPIFolder aExceptionFolder)
        {

            foreach (ReportItem myitem in aReportItemList)
            {
                OutlookItem myReportItem = new OutlookItem();
                EmailProperties myEmailProperties = new EmailProperties();


                try
                {
                    //Assign Values
                    myReportItem.EntryID = myitem.EntryID;
                    myReportItem.FromSender = (String)myitem.PropertyAccessor.GetProperty(myEmailProperties.PR_SENT_REPRESENTING_SMTP_ADDRESS_W);
                    myReportItem.ToReceiver = (String)myitem.PropertyAccessor.GetProperty(myEmailProperties.PR_DISPLAY_TO_W);
                    myReportItem.EmailSubject = (String)myitem.PropertyAccessor.GetProperty(myEmailProperties.PR_ORIGINAL_SUBJECT_W);
                    myReportItem.EmailBody = myitem.Body;
                    //myReportItem.EmailBody = Encoding.UTF8.GetString(new UnicodeEncoding().GetBytes(myitem.Body)).Substring(0, 200);
                    myReportItem.SubscriberNumber = myReportItem.GetMSISDN(myReportItem.EmailSubject, myReportItem.EmailBody);
                    myReportItem.InvalidEmailID = null;
                    myReportItem.AlgoType = "FZ";
                    myReportItem.TypeOfItem = "ReportItem";
                    myReportItem.HasAttachment = (Boolean)myitem.PropertyAccessor.GetProperty(myEmailProperties.PR_HASATTACH);
                    myReportItem.EmailSize = myitem.Size;
                    myReportItem.ReceiveAt = (DateTime)myitem.PropertyAccessor.GetProperty(myEmailProperties.PR_MESSAGE_DELIVERY_TIME);
                    myReportItem.SentOn = (DateTime)myitem.PropertyAccessor.GetProperty(myEmailProperties.PR_ORIGINAL_SUBMIT_TIME);

                    // Get Invalid ID from To List
                    if (myReportItem.ToReceiver.Contains("@"))
                    {
                        myReportItem.InvalidEmailID = myReportItem.ToReceiver;
                        myReportItem.AlgoType = "FA";
                    }


                    //Display Some info
                    Console.WriteLine(myReportItem.FromSender);
                    Console.WriteLine(myReportItem.ToReceiver);
                    Console.WriteLine(myReportItem.EmailSubject);

                    //Insert Into database
                    new Database().InsertIntoTable(myReportItem);

                    //Move read items
                    myitem.Move(aProcessedFolder);

                }
                catch (System.Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    myitem.Move(aExceptionFolder);
                }
            }

        }


    }
}

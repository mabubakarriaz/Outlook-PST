using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Interop.Outlook;


namespace Net.Mobilink
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*******************************************************");
            Console.WriteLine("Invalid Email Address identification Process Started...");
            Console.WriteLine("*******************************************************\n\n");

            //Intialize variables
            Application outlookApplication = null;
            _NameSpace outlookNameSpace = null;
            MAPIFolder inboxFolder = null;
            MAPIFolder workingFolder = null;
            MAPIFolder processedReportFolder = null;
            MAPIFolder processedMailFolder = null;
            MAPIFolder exceptionReportFolder = null;
            MAPIFolder exceptionMailFolder = null;
            int totalOutlookItems;
            int totalMailItems;
            int totalReportItems;

            List<MailItem> MailItemList = new List<MailItem>();
            List<ReportItem> ReportItemList = new List<ReportItem>();

            Console.WriteLine("Required variables Intialized...\n\n");
            



            try 
            {
              //Logon to outlook Application using default profile
              outlookApplication = new Application();
              outlookNameSpace = outlookApplication.GetNamespace("MAPI");
              outlookNameSpace.AddStore("");
              outlookNameSpace.Logon(null,null,false, false); //first value null as Default outlook profile
              
              
              //Set working folders
              inboxFolder = outlookNameSpace.GetDefaultFolder(OlDefaultFolders.olFolderInbox);
              workingFolder = inboxFolder.Folders["Working Folder"];        //folder.Folders[1]; also works
              
              processedReportFolder = workingFolder.Folders["Done Folder"].Folders["Report Items Folder"];    //assuming folders are in working folder
              processedMailFolder = workingFolder.Folders["Done Folder"].Folders["Mail Items Folder"];    //assuming folders are in working folder

              exceptionReportFolder = workingFolder.Folders["Error Folder"].Folders["Report Items Folder"];    //assuming folders are in working folder
              exceptionMailFolder = workingFolder.Folders["Error Folder"].Folders["Mail Items Folder"];    //assuming folders are in working folder
              
              // Displaying All Folders
              Console.WriteLine("Inbox Folder: {0},\n Working Folder: {1},\n Processed Folder: {2} & {3},\n Exception Folder: {4} & {5}", inboxFolder.Name, workingFolder.Name, processedReportFolder.Name, processedMailFolder.Name, exceptionReportFolder.Name, exceptionMailFolder.Name);


                totalOutlookItems = workingFolder.Items.Count;
                Console.WriteLine("\tComplete number of Items found: {0}", totalOutlookItems.ToString());


                #region doingStuff
                
                // only run when some outlook items are found
                if (totalOutlookItems>0)
                {

                    //Saves List of all Mail Items
                    foreach (MailItem myitem in workingFolder.Items.OfType<MailItem>())
                    {
                        MailItemList.Add(myitem);
                    }
                    
                    totalMailItems = MailItemList.Count;
                    Console.WriteLine("\t\tMail Items found: {0}", totalMailItems.ToString());



                    //Saves List of all Report Items
                    foreach (ReportItem myitem in workingFolder.Items.OfType<ReportItem>())
                    {
                        ReportItemList.Add(myitem);
                    }

                    totalReportItems = ReportItemList.Count;
                    Console.WriteLine("\t\tReport Items found: {0}", totalReportItems.ToString());

                    //Pause
                    //Console.ReadKey();
                    
                    //Processing of 
                    //Invalid Email
                    //Address


                    new ExtractData().GetMailItemsData(MailItemList, processedMailFolder, exceptionMailFolder);

                    new ExtractData().GetReportItemsData(ReportItemList, processedReportFolder, exceptionReportFolder);

                }
                else
                {
                    Console.WriteLine("\nNo Outlook item found for processing.");
                }
                #endregion doingStuff


            } 
            catch (System.Runtime.InteropServices.COMException ex) 
            {
              Console.WriteLine(ex.ToString());
            }
            finally
            {
                Console.WriteLine("\nLogging Off...\n");
                outlookNameSpace.Logoff();
              outlookNameSpace = null;
              outlookApplication = null;
              inboxFolder = null;
              Console.WriteLine("Process Ended. Press any key to close this Black Window...");
              //Console.ReadKey();

            }

        }
    }
}

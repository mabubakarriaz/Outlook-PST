using Microsoft.Office.Interop.Outlook;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PST_Sorting_App
{
    public partial class Form1 : Form
    {

        StringBuilder sb = new StringBuilder();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<MailItem> mailItems = new List<MailItem>();
            Microsoft.Office.Interop.Outlook.Application app = new Microsoft.Office.Interop.Outlook.Application();
            NameSpace outlookNs = app.GetNamespace("MAPI");
            // Add PST file (Outlook Data File) to Default Profile
            outlookNs.AddStore(textBox1.Text);
            //outlookNs.
            sb.Append(outlookNs.Stores.Count);

            textBox3.Text = sb.ToString();
            
            MAPIFolder rootFolder = outlookNs.Stores["Hooked PST"].GetRootFolder();
            Folders subFolders = rootFolder.Folders;

            foreach (Folder folder in subFolders)
            {

                sb.Append(folder.Name);
                Items items = folder.Items;
                foreach (object item in items)
                {
                    if (item is MailItem)
                    {
                        MailItem mailItem = item as MailItem;
                        mailItems.Add(mailItem);
                    }
                }
            }
            textBox3.Text = sb.ToString();
        }


        private IEnumerable<MailItem> readPst(string pstFilePath, string pstName)
        {
            List<MailItem> mailItems = new List<MailItem>();
            Microsoft.Office.Interop.Outlook.Application app = new Microsoft.Office.Interop.Outlook.Application();
            NameSpace outlookNs = app.GetNamespace("MAPI");
            // Add PST file (Outlook Data File) to Default Profile
            outlookNs.AddStore(pstFilePath);
            MAPIFolder rootFolder = outlookNs.Stores[pstName].GetRootFolder();
            // Traverse through all folders in the PST file
            // TODO: This is not recursive, refactor
            Folders subFolders = rootFolder.Folders;
            foreach (Folder folder in subFolders)
            {
                Items items = folder.Items;
                foreach (object item in items)
                {
                    if (item is MailItem)
                    {
                        MailItem mailItem = item as MailItem;
                        mailItems.Add(mailItem);
                    }
                }
            }
            // Remove PST file from Default Profile
            outlookNs.RemoveStore(rootFolder);
            return mailItems;
        }
    }
}

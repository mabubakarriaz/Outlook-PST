using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Net.Mobilink
{
    class Database
    {

        internal void InsertIntoTable(OutlookItem anOutlookItem)
        {

            SqlConnection con = MobilinkConnectionString.getSixtyConnection();
            SqlCommand cmd = new SqlCommand("SP_EmailGrid_Insert", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@EntryID", anOutlookItem.EntryID);
            cmd.Parameters.AddWithValue("@FromSender", anOutlookItem.FromSender);
            cmd.Parameters.AddWithValue("@ToReceiver", anOutlookItem.ToReceiver);
            cmd.Parameters.AddWithValue("@EmailSubject", String.IsNullOrEmpty(anOutlookItem.EmailSubject) ? Convert.DBNull : anOutlookItem.EmailSubject );
            cmd.Parameters.AddWithValue("@EmailBody", String.IsNullOrEmpty(anOutlookItem.EmailBody) ? Convert.DBNull : anOutlookItem.EmailBody.Substring(0, 300));
            cmd.Parameters.AddWithValue("@MSISDN", String.IsNullOrEmpty(anOutlookItem.SubscriberNumber) ? Convert.DBNull : anOutlookItem.SubscriberNumber);
            cmd.Parameters.AddWithValue("@InvalidEmail", String.IsNullOrEmpty(anOutlookItem.InvalidEmailID) ? Convert.DBNull : anOutlookItem.InvalidEmailID);
            cmd.Parameters.AddWithValue("@AlgoType", String.IsNullOrEmpty(anOutlookItem.AlgoType) ? Convert.DBNull : anOutlookItem.AlgoType);
            cmd.Parameters.AddWithValue("@TypeOfItem", anOutlookItem.TypeOfItem);
            cmd.Parameters.AddWithValue("@HasAttachment", anOutlookItem.HasAttachment);
            cmd.Parameters.AddWithValue("@EmailSizeKB", anOutlookItem.EmailSize);
            cmd.Parameters.AddWithValue("@ReceiveAt", anOutlookItem.ReceiveAt);
            cmd.Parameters.AddWithValue("@SentOn", anOutlookItem.SentOn);

            con.Open();
            using (con)
            {
                cmd.ExecuteNonQuery();
            }
            con.Close();
        }

    }
}

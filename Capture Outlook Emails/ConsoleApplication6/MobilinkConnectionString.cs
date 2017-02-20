using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Net.Mobilink
{
    class MobilinkConnectionString
    {

        internal static SqlConnection getSixtyConnection()
        {

            return new SqlConnection(@"Data Source=10.50.15.60\SQLSERVER2005; Initial Catalog=PCI_CER; Integrated Security=True;");

        }

        
        internal static SqlConnection getFCRConnection()
        {

            return new SqlConnection(@"Data Source=C-LHE-CC-58943\FCR; Initial Catalog=HUR; Integrated Security=True;");

        }

       
    }
}

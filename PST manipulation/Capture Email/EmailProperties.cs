using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Net.Mobilink
{
    class EmailProperties
    {
        
        //Email Properties
        internal String PR_SENT_REPRESENTING_SMTP_ADDRESS_W = @"http://schemas.microsoft.com/mapi/proptag/0x5D02001F";
        internal String PR_DISPLAY_TO_W = @"http://schemas.microsoft.com/mapi/proptag/0x0E04001F";
        internal String PR_ORIGINAL_SUBJECT_W = @"http://schemas.microsoft.com/mapi/proptag/0x0049001F";
        internal String PR_HASATTACH = @"urn:schemas:httpmail:hasattachment";
        internal String PR_MESSAGE_DELIVERY_TIME = @"urn:schemas:httpmail:datereceived";
        internal String PR_ORIGINAL_SUBMIT_TIME = @"http://schemas.microsoft.com/mapi/proptag/0x004E0040";


    }
}

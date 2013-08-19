using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SignalR_Chrome_Issues
{
    public partial class TestForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGo_Click(object sender, EventArgs e)
        {
            var msg = GlobalHost.ConnectionManager.GetHubContext<ChatHub>();
            string rpttoprocess = "----------Start of Messages...----------";

            if (msg != null)
            {
                //Sleep for 3 seconds so setup the connection (Possible Bug in SignalR?)
                Thread.Sleep(3000);

                //Send the message
                msg.Clients.Client(contextid.Value).broadcastMessage(rpttoprocess);


                int i = 0;
                while (i < 10)
                {
                    rpttoprocess = "Processing Message " + i.ToString();
                    msg.Clients.Client(contextid.Value).broadcastMessage(rpttoprocess);
                    Thread.Sleep(250);
                    i++;
                }

                rpttoprocess = "----------End of Messages <Pause for 10 seconds>----------";
                msg.Clients.Client(contextid.Value).broadcastMessage(rpttoprocess);

                //Show messages for 10 seconds
                Thread.Sleep(10000);
            }
        }
    }
}
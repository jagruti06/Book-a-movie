using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project5WebApp
{
    public partial class SendInvite : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            details.Text = "for " + Session["MovieName"] + " in " + Session["TheatreName"] + " at " + Session["Time"];
        }

        protected void SendInvite_Handler(object sender, EventArgs e)
        {
            try
            {
                MovieService.lProjectServiceClient sr = new MovieService.lProjectServiceClient();
                string to_emailID = send_invite_text.Text;
                string details = "Your friend "+ Session["Name"] +" has invited you to watch movie with them.\n" +
                        "Details : \n" +
                        "\t Movie -" + Session["MovieName"] + "\n" +
                        "\t Venue - " + Session["TheatreName"] + "\n" +
                        "\t Time - " + Session["Time"];
                invite_ans.Text = sr.sendMail(to_emailID, details);
            }
            catch (Exception ex)
            {
                invite_ans.Text = ex.Message;
            }
        }
    }
}
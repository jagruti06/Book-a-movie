using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TryItWebApp
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SendInvite_Handler(object sender, EventArgs e)
        {

            try
            {
                ServiceReference1.lProjectServiceClient sr = new ServiceReference1.lProjectServiceClient();
                string to_emailID = send_invite_text.Text;
                string details = "Your friend has invited you to watch movie with them.\n" +
                        "Details : \n" +
                        "\t Movie - Venom\n" +
                        "\t Venue - AMC Centerpoint 11 \n" +
                        "\t Time - 25th Oct 19:30PM MST";
                invite_ans.Text = sr.sendMail(to_emailID, details);
            }
            catch (Exception ex)
            {
                invite_ans.Text = ex.Message;
            }
        }
    }
}
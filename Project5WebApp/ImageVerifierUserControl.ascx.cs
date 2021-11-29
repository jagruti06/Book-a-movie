using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project5WebApp
{
    public partial class ImageVerifierUserControl : System.Web.UI.UserControl
    {
        //string verifierstring = "";
        //bool pageLoad = true;
        imageVerServiceRef.ServiceClient client = new imageVerServiceRef.ServiceClient();
        string len = "4";
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((int)Session["count"] == 0)
            {
                string verfstr = getVerifierString(len);
                Imageverifier2.ImageUrl = "https://venus.sod.asu.edu/WSRepository/Services/ImageVerifier/Service.svc/GetImage/" + verfstr;
            }
            Session["count"] = (int)Session["count"] + 1;
        }

        public string getVerifierString(string len)
        {
            string sessionState = client.GetVerifierString(len);
            Session["verfstr"] = sessionState;
            return sessionState;
        }

        public string GeneratedString
        {
            get
            {
                return Session["verfstr"].ToString();
            }

        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            string verfstr = getVerifierString(len);
            Imageverifier2.ImageUrl = "https://venus.sod.asu.edu/WSRepository/Services/ImageVerifier/Service.svc/GetImage/" + verfstr;
        }
    }
}
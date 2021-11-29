using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project5WebApp
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie myCookies = Request.Cookies["movieCookies"];
            if ((myCookies == null) || (myCookies["Name"] == "") || Session["Name"] == null)
            {
                Button1.Visible = false;
            }
            else
            {
                Button1.Visible = true;
            }
        }

        protected void Logout_Handler(object sender, EventArgs e)
        {
           
            //session end
            HttpCookie myCookies = Request.Cookies["movieCookies"];
            myCookies["Name"] = "";
            myCookies["Role"] = "";
            myCookies.Expires = DateTime.Now.AddMonths(-6);
            Response.Cookies.Add(myCookies);
            Session["Name"] = null;
            Response.Redirect("~/Default.aspx");
        }
    }
}
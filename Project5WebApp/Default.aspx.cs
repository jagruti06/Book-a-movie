using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PasswordCrypt;

namespace Project5WebApp
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          
        }

        protected void Member_Handler(object sender, EventArgs e)
        {
            Response.Redirect("Account/MemberLogin.aspx");
        }

        protected void MemReg_Handler(object sender, EventArgs e)
        {
            Response.Redirect("Account/MemberRegister.aspx");
        }

        protected void Staff_Handler(object sender, EventArgs e)
        {
            Response.Redirect("Account/StaffLogin.aspx");
        }

        protected void StaffReg_Handler(object sender, EventArgs e)
        {
            Response.Redirect("Account/StaffRegister.aspx");
        }

        protected void About_Handler(object sender, EventArgs e)
        {
            Response.Redirect("Account/StaffRegister.aspx");
        }
    }
}
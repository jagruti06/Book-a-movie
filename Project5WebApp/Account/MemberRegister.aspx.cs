using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PasswordCrypt;

namespace Project5WebApp
{
    public partial class MemberRegister : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Register_Handler(object sender, EventArgs e)
        {
            string uname = username.Text;
            string pwd = password.Text;
            LoginServiceRef.Service1Client service = new LoginServiceRef.Service1Client();
            string pwdEncrypt = CryptLibrary.Encrypt(pwd);
   
            string result = service.addUser(uname, pwdEncrypt, "Member");
            if (result == "true")
                Response.Redirect("MemberLogin.aspx"); //redirect to login page
            else
                Label3.Text = "Registration failed. Please try again";
        }
    }
}
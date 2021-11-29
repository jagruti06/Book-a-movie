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

            if (verifierText.Text == ImageVerifierUserControl1.GeneratedString)
            {
                image_label.Text = "Text Verified";
                string result = service.addUser(uname, pwdEncrypt, "Member");
                if (result == "true")
                    Response.Redirect("MemberLogin.aspx"); //redirect to login page
                else
                    Label3.Text = "Registration failed. Please try again";
            }
            else if(verifierText.Text =="")
            {
                image_label.Text = "Please enter the below captcha";
            }
            else 
            {
                image_label.Text = "Incorrect text entered";
            }
           


        }

        /*protected void Button2_Click(object sender, EventArgs e)
        {
            if(verifierText.Text == ImageVerifierUserControl1.GeneratedString)
            {
                image_label.Text = "Text Verified";
            }
            else
            {
                image_label.Text = "Incorrect text entered";
            }
        }*/
    }
}
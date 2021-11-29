using PasswordCrypt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project5WebApp
{
    public partial class StaffLogin : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            users_label.Text = "No of Users online: " + Application["UsersOnline"].ToString();
            HttpCookie myCookies = Request.Cookies["movieCookies"];
            if ((myCookies == null) || (myCookies["Name"] == ""))
            {
                username.Visible = true;
                password.Visible = true;
                login_btn.Visible = true;
               
            }
            else
            {
                if(myCookies["Role"] == "Member")
                {
                    Label4.Visible = true;
                }
                else
                {
                    Session["Name"] = myCookies["Name"];
                    Response.Redirect("../MovieApp/StaffApp.aspx"); // application page
                }
               
            }

        }

        protected void Login_Handler(object sender, EventArgs e)
        {
            string uname = username.Text;
            string pwd = password.Text;
            LoginServiceRef.Service1Client service = new LoginServiceRef.Service1Client();
            string pwdEncrypt = CryptLibrary.Encrypt(pwd);

            string[] result = service.searchUser(uname, pwdEncrypt, "Staff");
            if (result != null)
            {
                HttpCookie myCookies = new HttpCookie("movieCookies");
                myCookies["Role"] = "Staff";
                myCookies["Name"] = uname;
                Session["Name"] = uname;
                // myCookies["Email"] = TextBox2.Text;
                myCookies.Expires = DateTime.Now.AddMonths(6);
                Response.Cookies.Add(myCookies);
                Response.Redirect("../MovieApp/StaffApp.aspx"); //redirect to application page
            }
            else
                Label3.Text = "User not found. Please register";
        }

       
    }
}
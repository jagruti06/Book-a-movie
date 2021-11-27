using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TryItWebApp
{
    public partial class XMLTryIt : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Add_Handler(object sender, EventArgs e)
        {
            string uname = uname_text.Text;
            string pwd = pwd_text.Text;

            LoginServiceRef.Service1Client service = new LoginServiceRef.Service1Client();
            string status = service.addUser(uname, pwd, "Staff");
            if (status == "true")
                Label7.Text = "added user successfully";
            else
                Label7.Text = "user could not be added";
            Label7.Text = "added user successfully";
        }

        protected void Search_Handler(object sender, EventArgs e)
        {
            string uname = username_text.Text;
            string pwd = password_text.Text;

            LoginServiceRef.Service1Client service = new LoginServiceRef.Service1Client();
            string status = service.searchUser(uname, pwd, "Staff");
            if (status == "true")
                Label8.Text = "user found";
            else
                Label8.Text = "user could not be found";
            
        }
    }
}
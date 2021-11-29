using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project5WebApp
{
    public partial class StaffApp : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        public string getCreditCardsTable()
        {
            LoginServiceRef.Service1Client sr = new LoginServiceRef.Service1Client();
            return sr.getCreditCards();
           
           
        }
    }
}
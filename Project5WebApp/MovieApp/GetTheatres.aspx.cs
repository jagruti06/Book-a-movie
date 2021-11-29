using PasswordCrypt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project5WebApp
{
    public partial class GetTheatres : Page
    {

        public string[] arr = null;
        public string[] showTimes = null;
        public string filmID = null;
        public string movie = null;
        public string theatre = null;
        protected void Button1_Click(object sender, EventArgs e)
        {
            //   string zipcode = zip.Text;
            string movie_local = movieName.Text;
            if (string.IsNullOrEmpty(movie_local) || (movie_local.ToLower() != "encanto" && movie_local.ToLower() != "house of gucci" && movie_local.ToLower() != "ghostbusters: afterlife"))
            {
                Label8.Visible = true;
            }
            else
            {
                MovieService.lProjectServiceClient service = new MovieService.lProjectServiceClient();

                string[] cinemas = service.TheatreList(movie_local);

                if (cinemas.Length != 0)
                {
                    movie = movie_local;
                    filmID = cinemas[cinemas.Length - 1];
                    arr = cinemas;
                }
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Label8.Visible = false;
            Label1.Text = "Started at - " + Global.startTime;
        }
        public string getListOfTheatres()
        {
            string output = "";
            if (arr != null)
            {
                //  TheatreTable.Visible = true;
                Button2.Visible = true;
                for(int i = 0; i < arr.Length - 1; ++i) //foreach (string s in arr)
                {
                    output += "<tr><td>" + arr[i] + "</td></tr>";
                }
            } else
                output += "<tr><td> No Theatres Available</td></tr>";

            return output;
        }
        protected void Button2_Click(object sender, EventArgs e)
        {

            string textBoxInput = theatreName.Text;
            if (string.IsNullOrEmpty(textBoxInput) )
            {

            }
            else
            {
                MovieService.lProjectServiceClient service = new MovieService.lProjectServiceClient();

                string[] movieTimes = service.GetShowTimings(movieName.Text, filmID, textBoxInput);

                if (movieTimes.Length != 0)
                {
                    showTimes = movieTimes;
                    theatre = textBoxInput;
                }
            }
        }

        public string getListOfShows()
        {
            string output = "";
            if (showTimes != null)
            {
                Button3.Visible = true;
                TimeSlot.Visible = true;
                Label7.Visible = true;
                foreach (string s in showTimes)
                {
                    output += "<tr><td>" + s + "</td></tr>";
                }
            }
            else
                output += "<tr><td> No ShowTimes Available</td></tr>";

            return output;
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Session["MovieName"] = movieName.Text;
            Session["TheatreName"] = theatreName.Text;
            Session["Time"] = TimeSlot.Text;

            Response.Redirect("SendInvite.aspx");
        }
    }
}
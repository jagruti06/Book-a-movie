using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Net.Mail;


namespace Project5Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : lProjectService
    {
        public string sendMail(string to, string details)
        {

            //read email and password from web config
            string from = GmailCredentials.getUsername();
            string password = GmailCredentials.getPassword();

            //form mail body 
            MailMessage message = new MailMessage(from, to);
            message.Subject = "You have received a movie invite";
            message.Body = @"" + details;

            //create smtp client
            SmtpClient client = new SmtpClient("smtp.gmail.com");
            client.Port = 587;
            // the server will authenticate before it will send email on the application's behalf.
            client.Credentials =
                new System.Net.NetworkCredential(from, password);
            client.EnableSsl = true;

            try
            {
                client.Send(message);
                Console.WriteLine("Message sent");
                return "Invite sent to " + to;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught in CreateTestMessage2(): {0}",
                    ex.ToString());
            }

            return "Failed to send invite";
        }
        
        
        // Get show timings
        
        public IDictionary<string, string[]> GetShowTimings(string filmname)
        {
            string date_time = DateTime.UtcNow.AddDays(1).ToString("yyyy-MM-ddTHH:mm:ssZ");
            var client = new RestClient("https://api-gate2.movieglu.com/filmsNowShowing/?n=25"); // service call to fetch the current movies whicg=h are playing.
            IDictionary<string, string> films = new Dictionary<string, string>(); // dictionary to store the film names.
            DateTime utcTime = DateTime.UtcNow;

            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("api-version", "v200");
            request.AddHeader("Authorization", "Basic U1RVRF8xOTE6d3hKNTcwRkluT2xv");
            request.AddHeader("client", "STUD_191");
            request.AddHeader("x-api-key", "iNuhHMcoOO6vCtX8lHlQC2Yn6ldxJ07X4aQ7FYAq");
            request.AddHeader("device-datetime", date_time);
            request.AddHeader("territory", "US");
            IRestResponse response = client.Execute(request);
            dynamic film_lst = JObject.Parse(response.Content); // getting lits of films which are currently playing in theatres.


            foreach (var item in film_lst.films)
            {
                string filmid = item.film_id;
                string filmnames = item.film_name;     // looping through the list of films and adding it to the dictionary with key as fillname and value as filmid.
                films.Add(filmnames.ToLower(), filmid);
            }



            var dateString2 = DateTime.Now.ToString("yyyy-MM-dd");

            bool flag = films.ContainsKey(filmname.ToLower());

            if (flag)
            {

                var obj = new RestClient("https://api-gate2.movieglu.com/filmShowTimes/?film_id=" + films[filmname] + "&date=" + dateString2 + "&n=5"); // service call to get the movie show times based on the film id.
                obj.Timeout = -1;
                var request_2 = new RestRequest(Method.GET);
                request.AddHeader("api-version", "v200");
                request.AddHeader("Authorization", "Basic U1RVRF8xOTE6d3hKNTcwRkluT2xv");
                request.AddHeader("client", "STUD_191");
                request.AddHeader("x-api-key", "iNuhHMcoOO6vCtX8lHlQC2Yn6ldxJ07X4aQ7FYAq");
                request.AddHeader("device-datetime", date_time);
                request.AddHeader("territory", "US");
                request_2.AddHeader("geolocation", "33.42192;-111.8798");
                IRestResponse response_2 = obj.Execute(request_2);
                dynamic film_json = JObject.Parse(response_2.Content);

                IDictionary<string, string[]> movies = new Dictionary<string, string[]>();

                foreach (var item in film_json.cinemas)
                {
                    List<string> lst = new List<string>();
                    string cinemaname = item.cinema_name;

                    foreach (var i in item.showings.Standard.times)
                    {
                        string time = "start_time: " + i.start_time + ", end_time: " + i.end_time;
                        lst.Add(time);

                    }
                    string[] lst_arr = lst.ToArray();
                    movies.Add(cinemaname, lst_arr);

                }

                return movies; // returning the theatre names and their corresponding show times.
            }
            else
            {
                return null;
            }


        }

    }
}

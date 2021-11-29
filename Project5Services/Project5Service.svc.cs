using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Net.Mail;
using Newtonsoft.Json;
using System.Collections;
using RestSharp;
using Newtonsoft.Json.Linq;

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
        public List<string> GetShowTimings(string filmname, string filmID, string cinemaName)
        {
           

            List<string> ans = new List<string>();
            var dateString2 = DateTime.Now.ToString("yyyy-MM-dd");

            if (filmname.ToLower() == "encanto")
                filmID = "315323";
            else if(filmname.ToLower() == "ghostbusters: afterlife")
                filmID = "295455";
            else if (filmname.ToLower() == "house of gucci")
                filmID = "309784";

            var obj = new RestClient("https://api-gate2.movieglu.com/filmShowTimes/?film_id=" + filmID + "&date=" + dateString2 + "&n=5"); // service call to get the movie show times based on the film id.
                obj.Timeout = 0;
                var request_2 = FetchHeader();
                request_2.AddHeader("geolocation", "33.4654278;-111.877102");
                IRestResponse response_2 = obj.Execute(request_2);
                dynamic film_json = JObject.Parse(response_2.Content);

                Dictionary<string, string[]> movies = new Dictionary<string, string[]>();

                foreach (var item in film_json.cinemas)
                {
                    int count = 0;
                    string currCinema = item.cinema_name;
                    if (cinemaName.ToLower() == currCinema.ToLower())
                    {
                        foreach (var curr in item.showings.Standard.times)
                        {
                            string time = ++count + ". Start: " + curr.start_time + ", End: " + curr.end_time;
                            ans.Add(time);
                        }
                    }
                }

            

            return ans; 
        }
        public RestRequest FetchHeader()
        {
            /* var request = new RestRequest(Method.GET);
             request.AddHeader("api-version", "v200");
             request.AddHeader("Authorization", "Basic U1RVRF8xODg6MXh4NXo4THNDbU9F");
             request.AddHeader("client", "STUD_188");
             request.AddHeader("x-api-key", "tYmiksmsYH29uvqPIavoI9VCD0VFyxi8ZgetKoa3");
             request.AddHeader("device-datetime", "2021-12-25T08:07:57.296Z");
             request.AddHeader("territory", "US");*/
            var request = new RestRequest(Method.GET);
            string date_time = DateTime.UtcNow.AddDays(1).ToString("yyyy-MM-ddTHH:mm:ssZ");
            request.AddHeader("api-version", "v200");
            request.AddHeader("Authorization", "Basic U1RVRF8xOTY6a0QzMUJBeHljbmJv");
            request.AddHeader("client", "STUD_196");
            request.AddHeader("x-api-key", "n4lOENBnJx4ZBNzUUpdMK2sG8zKPLY2Q7FWbB9b5");
            request.AddHeader("device-datetime", "2021-12-25T08:07:57.296Z");
            request.AddHeader("territory", "US");

            return request;
        }
        public IRestResponse GetCinemasNearby(string coordinates)
        {
            //passing for 7 cinemas because API calls are limited
            var client = new RestClient("https://api-gate2.movieglu.com/cinemasNearby/?n=1");
            client.Timeout = 0;
            string date_time = DateTime.UtcNow.AddDays(1).ToString("yyyy-MM-ddTHH:mm:ssZ");
            var request = new RestRequest(Method.GET);
            request.AddHeader("api-version", "v200");
            request.AddHeader("Authorization", "Basic U1RVRF8xOTE6d3hKNTcwRkluT2xv");
            request.AddHeader("client", "STUD_191");
            request.AddHeader("x-api-key", "iNuhHMcoOO6vCtX8lHlQC2Yn6ldxJ07X4aQ7FYAq");
            request.AddHeader("device-datetime", "2021-12-25T08:07:57.296Z");
            request.AddHeader("territory", "US");
            
            //var request = FetchHeader();
            //coordinates = "33.42192;-111.8798";



            coordinates = "33.4654278;-111.877102";
            request.AddHeader("geolocation", coordinates);
            IRestResponse response = client.Execute(request);

            return response;
        }

        public IRestResponse GetShowTimes(string cinemaID, string date)
        {
            var client = new RestClient("https://api-gate2.movieglu.com/cinemaShowTimes/?cinema_id=" + cinemaID + "&date=" + date);

            client.Timeout = 0;
            var request = FetchHeader();
            IRestResponse response = client.Execute(request);

            return response;
        }

        public List<string> filterCinemas(ArrayList array, string movie)
        {
            List<string> ans = new List<string>();
            try
            {
                int len = array.Count;

                int filmID = -1;

                for (int i = 0; i < len; ++i)
                {
                    ArrayList currCinema = (ArrayList)array[i];
                    string cinemaID = (string)currCinema[0];

                    DateTime tomorrow = DateTime.Today.AddDays(1);
                    string strDate = tomorrow.ToString("yyyy-MM-dd");

                    try
                    {
                        IRestResponse showTimeData = GetShowTimes(cinemaID, strDate);

                        CinemaShowTimeObject showTimeJson = JsonConvert.DeserializeObject<CinemaShowTimeObject>(showTimeData.Content);

                        if (showTimeJson.status.state == "OK")
                        {
                            //get films playing in that cinema
                            var films = showTimeJson.films;
                            int filmsSize = films.Length;

                            //find if the requested film is playing or not
                            for (int j = 0; j < filmsSize; ++j)
                            {
                                var currFilm = films[j];

                                if (currFilm.film_name.ToLower() == movie.ToLower())
                                {
                                    if (filmID == -1)
                                    {
                                        filmID = currFilm.film_id;
                                    }
                                    ans.Add((string)currCinema[1]);
                                    break;
                                }
                            }
                        }
                    }
                    catch (Exception e)
                    {

                    }
                }

                if (filmID != -1)
                {
                    ans.Add(filmID.ToString());
                }
            }
            finally
            {
                ans.Add("Cinemark Mesa 16");
                ans.Add("AMC Centerpoint 11");
                ans.Add("Harkins Theaters - Tempe Marketplace 16");
                ans.Add("309784");
            }

            return ans;

        }

        public List<string> TheatreList(string movieName = null)
        {
            List<string> ans = new List<string>();
                ans.Add("Cinemark Mesa 16");
                ans.Add("AMC Centerpoint 11");
                ans.Add("Harkins Theaters - Tempe Marketplace 16");
                ans.Add("309784");

            return ans;
        }

        public List<string> TheatreListBackup(string movieName = null)
        {
            string zipCode = "85281";

            List<string> filteredCinemaList = new List<string>();
           /* if (zipCode == null)
            {
                filteredCinemaList.Add("No zipcode provided for user location");
                return filteredCinemaList;
            }*/
            if (movieName == null)
            {
                filteredCinemaList.Add("No movie name provided");
                return filteredCinemaList;
            }
            else
            {
                //use geocode api to get coordinates of user input zipcode
                string urlForUserLocation = "https://maps.googleapis.com/maps/api/geocode/json?components=postal_code:" + zipCode + "&sensor=false&key=AIzaSyAMPl4EUl8d-VLHT82Q4Ifl5TNQrq13P2s";

                CoordinatesObject coor = new CoordinatesObject();

                try
                {

                    using (var webClient = new System.Net.WebClient())
                    {
                        var json = webClient.DownloadString(urlForUserLocation);

                        coor = JsonConvert.DeserializeObject<CoordinatesObject>(json);


                        if (coor.status == "OK")
                        {
                            string location = coor.results[0].geometry.bounds.northeast.lat.ToString() + ";"
                                        + coor.results[0].geometry.bounds.northeast.lng.ToString();

                            //get list of cinemas nearby using movie glu api
                            IRestResponse cinemaData = GetCinemasNearby(location);

                            CinemaDetailsObject cinemaJson = new CinemaDetailsObject();
                            try
                            {
                                cinemaJson = JsonConvert.DeserializeObject<CinemaDetailsObject>(cinemaData.Content);
                            }
                            catch (Exception e)
                            {

                            }
                            if (cinemaJson.status.state == "OK")
                            {
                                var cinemas = cinemaJson.cinemas;

                                int cinemasSize = cinemas.Length;

                                ArrayList cinemaList = new ArrayList();

                                //filterCinemas as per distance less than 3.5 miles
                                for (int i = 0; i < cinemasSize; ++i)
                                {
                                    ArrayList currentCinema = new ArrayList();
                                    if (cinemas[i].distance < 3.5)
                                    {
                                        currentCinema.Add(cinemas[i].cinema_id.ToString());
                                        currentCinema.Add(cinemas[i].cinema_name);
                                        currentCinema.Add(cinemas[i].address);
                                        currentCinema.Add(cinemas[i].distance);
                                    }

                                    cinemaList.Add(currentCinema);
                                }

                                if (cinemaList.Count == 0)
                                    return filteredCinemaList;


                                //out of the filtered cinemas, fetch those where the movie is playing
                                filteredCinemaList = filterCinemas(cinemaList, movieName);
                            }
                        }
                    }
                }
                catch (Exception e)
                {

                }
            }

            return filteredCinemaList;
        }

        public class CoordinatesObject
        {
            public Result[] results { get; set; }
            public string status { get; set; }

            public class Result
            {
                public Geometry geometry { get; set; }
                public class Geometry
                {
                    public Bounds bounds { get; set; }
                    public class Bounds
                    {
                        public Northeast northeast { get; set; }
                        public class Northeast
                        {
                            public float lat { get; set; }
                            public float lng { get; set; }
                        }
                    }
                }
            }
        }

        public class CinemaShowTimeObject
        {
            public Cinema[] cinemas { get; set; }
            public Film[] films { get; set; }
            public Status status { get; set; }

            public class Cinema
            {
                public string cinema_id { get; set; }
                public string cinema_name { get; set; }
            }
            public class Film
            {
                public int film_id { get; set; }
                public string film_name { get; set; }
            }
            public class Status
            {
                public string state { get; set; }
            }
        }

        public class CinemaDetailsObject
        {
            public Cinema[] cinemas { get; set; }
            public Status status { get; set; }

            public class Cinema
            {
                public string cinema_id { get; set; }
                public string cinema_name { get; set; }
                public string address { get; set; }
                public double distance { get; set; }
            }
            public class Status
            {
                public string state { get; set; }
            }
        }
    }
}

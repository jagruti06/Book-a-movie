using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Newtonsoft.Json;
using RestSharp;

namespace GetListOfCinemas
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public RestRequest FetchHeader()
        {
            var request = new RestRequest(Method.GET);
            request.AddHeader("api-version", "v200");
            request.AddHeader("Authorization", "Basic U1RVRF8xODg6MXh4NXo4THNDbU9F");
            request.AddHeader("client", "STUD_188");
            request.AddHeader("x-api-key", "tYmiksmsYH29uvqPIavoI9VCD0VFyxi8ZgetKoa3");
            request.AddHeader("device-datetime", "2021-12-25T08:07:57.296Z");
            request.AddHeader("territory", "US");

            return request;
        }
        public IRestResponse GetCinemasNearby(string coordinates)
        {
            //passing for 7 cinemas because API calls are limited
            var client = new RestClient("https://api-gate2.movieglu.com/cinemasNearby/?n=7");

            client.Timeout = 0;
            var request = FetchHeader();   
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
            int len = array.Count;
            List<string> ans = new List<string>();

            for (int i = 0; i < len; ++i)
            {
                ArrayList currCinema = (ArrayList)array[i];
                string cinemaID = (string)currCinema[0];

                DateTime tomorrow = DateTime.Today.AddDays(1);
                string strDate = tomorrow.ToString("yyyy-MM-dd");

                IRestResponse showTimeData = GetShowTimes(cinemaID, strDate);

                try
                {
                    CinemaShowTimeObject showTimeJson = JsonConvert.DeserializeObject<CinemaShowTimeObject>(showTimeData.Content);

                    if (showTimeJson.status.state == "OK")
                    {
                        //get films playing in that cinema
                        var films = showTimeJson.films;
                        int filmsSize = films.Length;

                        //find if the requested film is playing or not
                        for (int j = 0; j < filmsSize; ++j)
                        {
                            var currFilm = films[i];

                            if (currFilm.film_name.ToLower() == movie.ToLower())
                            {
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

            return ans;
        }

        public List<string> TheatreList(string zipCode = null, string movieName = null)
        {
            List<string> filteredCinemaList = new List<string>();
            if (zipCode == null)
            {
                filteredCinemaList.Add("No zipcode provided for user location");
                return filteredCinemaList;
            }
            else if (movieName == null)
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

using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Net;

namespace HotelReservationsClient
{
    class APIService
    {
        private readonly string API_URL = "";
        private readonly RestClient client = new RestClient();
        private API_User user = new API_User();

        public bool LoggedIn { get { return !string.IsNullOrWhiteSpace(user.Token); } }

        public APIService(string api_url)
        {
            API_URL = api_url;
        }

        public List<Hotel> GetHotels()
        {
            RestRequest request = new RestRequest(API_URL + "hotels");
            IRestResponse<List<Hotel>> response = client.Get<List<Hotel>>(request);

            CheckResponse(response); // Will throw if there's an error
            return response.Data;
        }

        public List<Reservation> GetReservations(int hotelId = 0)
        {
            string url = API_URL;
            if (hotelId != 0)
                url += $"hotels/{hotelId}/reservations";
            else
                url += "reservations";

            RestRequest request = new RestRequest(url);
            IRestResponse<List<Reservation>> response = client.Get<List<Reservation>>(request);

            CheckResponse(response); // Will throw if there's an error
            return response.Data;
        }

        public Reservation GetReservation(int reservationId)
        {
            RestRequest request = new RestRequest(API_URL + "reservations/" + reservationId);
            IRestResponse<Reservation> response = client.Get<Reservation>(request);

            CheckResponse(response); // Will throw if there's an error
            return response.Data;
        }

        public Reservation AddReservation(Reservation newReservation)
        {
            RestRequest request = new RestRequest(API_URL + "reservations");
            request.AddJsonBody(newReservation);
            IRestResponse<Reservation> response = client.Post<Reservation>(request);

            CheckResponse(response); // Will throw if there's an error
            return response.Data;
        }

        public Reservation UpdateReservation(Reservation reservationToUpdate)
        {
            RestRequest request = new RestRequest(API_URL + "reservations/" + reservationToUpdate.id);
            request.AddJsonBody(reservationToUpdate);
            IRestResponse<Reservation> response = client.Put<Reservation>(request);

            CheckResponse(response); // Will throw if there's an error
            return response.Data;
        }

        public void DeleteReservation(int reservationId)
        {
            RestRequest request = new RestRequest(API_URL + "reservations/" + reservationId);
            IRestResponse response = client.Delete(request);

            CheckResponse(response); // Will throw if there's an error
            return;
        }

        // TODO 11: Note the new error handling technique.  After any call to the api, CheckResponse is called.
        //          It will throw if there is an error or bad status code, so the callers really don't need
        //          to do anything special.
        //      Also notice the conversion of certain status codes to human-readable errors.
        private void CheckResponse(IRestResponse response)
        {
            if (response.ResponseStatus != ResponseStatus.Completed)
            {
                throw new Exception("Error occurred - unable to reach server.");
            }

            if (!response.IsSuccessful)
            {
                if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    throw new Exception("Authorization is required for this option. Please log in.");
                }
                if (response.StatusCode == HttpStatusCode.Forbidden)
                {
                    throw new Exception("You do not have permission to perform the requested action");
                }

                throw new Exception($"Error occurred - received non-success response: {response.StatusCode} ({(int)response.StatusCode})");
            }
        }

        public bool Login(string submittedName, string submittedPass)
        {
            var credentials = new { username = submittedName, password = submittedPass }; //this gets converted to JSON by RestSharp
            RestRequest request = new RestRequest(API_URL + "login");
            request.AddJsonBody(credentials);
            IRestResponse<API_User> response = client.Post<API_User>(request);

            CheckResponse(response); // Will throw if there's an error
            user.Token = response.Data.Token;

            // TODO 10: Create a new Authenticator and add it to the client for subsequent calls
            client.Authenticator = new JwtAuthenticator(user.Token);

            return true;
        }

        public void Logout()
        {
            user = new API_User();
            client.Authenticator = null;
        }
    }
}

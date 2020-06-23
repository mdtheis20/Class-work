using RestSharp;
using System;
using System.Collections.Generic;

namespace HTTP_Web_Services_POST_PUT_DELETE_lecture
{
    class APIService
    {
        //private readonly string API_URL = "";
        private readonly RestClient client = new RestClient();

        public APIService(string api_url)
        {
            //API_URL = api_url;
            this.client = new RestClient(api_url);
        }

        public List<Hotel> GetHotels()
        {
            RestRequest request = new RestRequest("hotels");
            IRestResponse<List<Hotel>> response = client.Get<List<Hotel>>(request);
            if (response.ResponseStatus != ResponseStatus.Completed)
            {
                throw new Exception("Error occurred - unable to reach server.");
            }
            else if (!response.IsSuccessful)
            {
                throw new Exception("Error occurred - received non-success response: " + (int)response.StatusCode);
            }
            return response.Data;
        }

        public List<Reservation> GetReservations(int hotelId = 0)
        {
            string url;
            if (hotelId != 0)
                url = $"hotels/{hotelId}/reservations";
            else
                url = "reservations";

            RestRequest request = new RestRequest(url);
            IRestResponse<List<Reservation>> response = client.Get<List<Reservation>>(request);
            if (response.ResponseStatus != ResponseStatus.Completed)
            {
                throw new Exception("Error occurred - unable to reach server.");
            }
            else if (!response.IsSuccessful)
            {
                throw new Exception("Error occurred - received non-success response: " + (int)response.StatusCode);
            }
            return response.Data;
        }

        public Reservation GetReservation(int reservationId)
        {
            RestRequest request = new RestRequest("reservations/" + reservationId);
            IRestResponse<Reservation> response = client.Get<Reservation>(request);
            if (response.ResponseStatus != ResponseStatus.Completed)
            {
                throw new Exception("Error occurred - unable to reach server.");
            }
            else if (!response.IsSuccessful)
            {
                throw new Exception("Error occurred - received non-success response: " + (int)response.StatusCode);
            }
            return response.Data;
        }

        public Reservation AddReservation(Reservation newReservation)
        {
            RestRequest req = new RestRequest("reservations");
            req.AddJsonBody(newReservation);
            IRestResponse<Reservation> resp = client.Post<Reservation>(req);
            if (resp.ResponseStatus != ResponseStatus.Completed)
            {
                throw new Exception("Error occurred - unable to reach server.");
            }
            else if (!resp.IsSuccessful)
            {
                throw new Exception("Error occurred - received non-success response: " + (int)resp.StatusCode);
            }

            return resp.Data;
        }

        public Reservation UpdateReservation(Reservation reservationToUpdate)
        {
            RestRequest req = new RestRequest($"reservations/{reservationToUpdate.Id}");
            req.AddJsonBody(reservationToUpdate);
            IRestResponse<Reservation> resp = client.Put<Reservation>(req);
            if (resp.ResponseStatus != ResponseStatus.Completed)
            {
                throw new Exception("Error occurred - unable to reach server.");
            }
            else if (!resp.IsSuccessful)
            {
                throw new Exception("Error occurred - received non-success response: " + (int)resp.StatusCode);
            }

            return resp.Data;
        }

        public void DeleteReservation(int reservationId)
        {
            RestRequest req = new RestRequest($"reservations/{reservationId}");
            IRestResponse resp = client.Delete(req);
            if (resp.ResponseStatus != ResponseStatus.Completed)
            {
                throw new Exception("Error occurred - unable to reach server.");
            }
            else if (!resp.IsSuccessful)
            {
                throw new Exception("Error occurred - received non-success response: " + (int)resp.StatusCode);
            }

            return;
        }
    }
}

using CatCards.Models;
using RestSharp;

namespace CatCards.Services
{
    public class CatFactService : ICatFactService
    {
        // Random cat fact API is https://cat-fact.herokuapp.com/facts/random
        const string CAT_FACT_URL = "https://cat-fact.herokuapp.com/facts/random";
        public CatFact GetFact()
        {
            RestClient client = new RestClient(CAT_FACT_URL);
            RestRequest request = new RestRequest();
            IRestResponse<CatFact> response = client.Get<CatFact>(request);

            // TODO: Check for errors here....

            return response.Data;
        }
    }
}

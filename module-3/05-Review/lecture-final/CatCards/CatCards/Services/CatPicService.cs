using CatCards.Models;
using RestSharp;

namespace CatCards.Services
{
    public class CatPicService : ICatPicService
    {
        const string CAT_PIC_URL = "https://random-cat-image.herokuapp.com/";
        public CatPic GetPic()
        {
            RestClient client = new RestClient();
            RestRequest request = new RestRequest(CAT_PIC_URL);

            IRestResponse<CatPic> response = client.Get<CatPic>(request);

            // TODO: Handle errors here...

            return response.Data;
        }
    }
}

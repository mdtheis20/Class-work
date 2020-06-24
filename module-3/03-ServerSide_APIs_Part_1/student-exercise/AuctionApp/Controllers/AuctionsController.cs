using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AuctionApp.Models;
using AuctionApp.DAO;

namespace AuctionApp.Controllers
{
    [Route("/")]
    [ApiController]
    public class AuctionsController : ControllerBase
    {
        private readonly IAuctionDao dao;

        public AuctionsController(IAuctionDao auctionDao = null)
        {
            if (auctionDao == null)
            {
                dao = new AuctionDao();
            }
            else
            {
                dao = auctionDao;
            }



        }

        [HttpGet("auctions")]
        public List<Auction> GetAuctions(string title_like = "", double currentBid_lte = 0)
        {
            if ( currentBid_lte > 0)
            {
                List<Auction> result = dao.SearchByTitleAndPrice(title_like, currentBid_lte);
                    return result;
            }
            else
            {
                List<Auction> result = dao.SearchByTitle(title_like);
                return result;
            }
        }

        [HttpGet("auctions/{id}")]
        public Auction GetAuction(int id)
        {
            Auction auction = dao.Get(id);
            if (auction != null)
            {
                return auction;
            }
            return null;
        }




        [HttpPost("auctions")]
        public Auction AddAuction(Auction newAuction)
        {
            return dao.Create(newAuction);
        }



    }
}

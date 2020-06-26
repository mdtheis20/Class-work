using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AuctionApp.Models;
using AuctionApp.DAO;

namespace AuctionApp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuctionsController : ControllerBase
    {
        private readonly IAuctionDao dao;

        public AuctionsController(IAuctionDao auctionDao)
        {
            dao = auctionDao;
        }

        [HttpGet]
        public List<Auction> List(string title_like = "", double currentBid_lte = 0)
        {
            if (title_like != "")
            {
                return dao.SearchByTitle(title_like);
            }
            if (currentBid_lte > 0)
            {
                return dao.SearchByPrice(currentBid_lte);
            }

            return dao.List();
        }

        [HttpGet("{id}")]
        public ActionResult<Auction> Get(int id)
        {
            Auction auction = dao.Get(id);
            if (auction != null)
            {
                return Ok(auction);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public ActionResult<Auction> Create(Auction auction)
        {
            Auction auct =  dao.Create(auction);
            string location = $"{auct.Id}";
            return Created(location, auct);
        }

        [HttpPut("{auctId}")]
        public ActionResult<Auction>  UpdateAuction(int auctId, Auction newAuct)
        {
            Auction auction = dao.Get(auctId);
            if (auction != null)
            {
                auction = dao.Update(auctId, newAuct);
            }

            else
            {
                return NotFound();
            }
            return auction;

            
            
        }


        [HttpDelete("{idToDelete}")]
        public ActionResult Delete(int idToDelete)
        {
            bool wasDeleted = dao.Delete(idToDelete);
            if (wasDeleted)
            {
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }


    }
}

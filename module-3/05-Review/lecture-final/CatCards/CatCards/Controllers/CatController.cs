using System;
using System.Collections.Generic;
using CatCards.DAO;
using CatCards.Models;
using CatCards.Services;
using Microsoft.AspNetCore.Mvc;

namespace CatCards.Controllers
{
    /*************************
        GET /api/cards: Provides a list of all Cat Cards in the user's collection.
        GET /api/cards/{id}: Provides a Cat Card with the given ID.
        GET /api/cards/random: Provides a new, randomly created Cat Card containing information from the cat fact and picture services.
        POST /api/cards: Saves a card to the user's collection.
        PUT /api/cards: Updates a card in the user's collection.
        DELETE /api/cards: Removes a card from the user's collection.
    * ***********************/
    [ApiController]
    [Route("/api/cards")]
    public class CatController : ControllerBase
    {
        private readonly ICatCardDAO cardDAO;
        private readonly ICatFactService catFactService;
        private readonly ICatPicService catPicService;

        public CatController(ICatCardDAO _cardDAO, ICatFactService _catFact, ICatPicService _catPic)
        {
            catFactService = _catFact;
            catPicService = _catPic;
            cardDAO = _cardDAO;
        }

        [HttpGet]
        public ActionResult<List<CatCard>> GetList()
        {
            return cardDAO.GetAllCards();
        }

        [HttpGet("{id}")]
        public ActionResult<CatCard> GetOne(int id)
        {
            CatCard card = cardDAO.GetCard(id);
            if (card == null)
            {
                return NotFound();
            }

            return card;
        }

        [HttpGet("random")]
        public ActionResult<CatCard> GetRandom()
        {
            CatCard catCard = new CatCard();

            // TODO: Replace these hard-coded values with calls to the appropriate api service
            CatFact theFact = catFactService.GetFact();
            catCard.CatFact = theFact.Text;

            CatPic thePic =  catPicService.GetPic();
            catCard.ImgUrl = thePic.File;

            return catCard;
        }

        [HttpPost]
        public ActionResult<CatCard> AddCard(CatCard card)
        {
            try
            {
                // Add the cat card to the db
                CatCard newCard = cardDAO.SaveCard(card);

                // Return the new card to caller: status code 201 Created
                string location = $"/api/cards/{newCard.CatCardId}";
                return Created(location, newCard);

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }

        [HttpPut("{id}")]
        public ActionResult UpdateCard(int id, CatCard card)
        {
            card.CatCardId = id;
            bool updated = cardDAO.UpdateCard(card);
            if (updated)
            {
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteCard(int id)
        {
            bool deleted = cardDAO.RemoveCard(id);
            if (deleted)
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

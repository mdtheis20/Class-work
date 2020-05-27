using System;
using System.Collections.Generic;
using System.Text;

namespace DeckOfCards.Models
{
    public class Deck
    {
        private List<Card> cards;

        public Deck()
        {
            //Create a new list of cards 
            this.cards = new List<Card>();

            //populate the list with a card from each suit and each value;
            string[] suits = { "H", "D", "C", "S" };

            foreach (string suit in suits)
            {
                foreach (KeyValuePair<int, string> entry in Card.ValueNames)
                {
                    Card card = new Card(entry.Key, suit);
                    cards.Add(card);
                }
            }
        }

        public Card DealOne()
        {
            if (cards.Count == 0)
            {
                return null;
            }
            Card card = cards[0];

            cards.RemoveAt(0);new

            return card;
        }

        public void Shuffle()
        {
            //Create a new empty list where I will put the shuffled cards

            //Loop while there are still cards in the unshuffled list
                //Get a random number from 0 - unshuffled.Count - 1

            //Copy that card to the end of suffled list. 

        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace DeckOfCards.Models
{
    public class Card
    {
        //Constructor to set the value and the suit of the card
        public Card(int value, string suit)
        {
            this.Value = value;
            this.Suit = suit;
        }

        //public Card(int value, string suit, bool IsFaceUp)
        //{
        //    this.Value = value;
        //    this.Suit = suit;
        //    this.IsFaceUp = IsFaceUp;

        //}

            static public string BackPattern { get; set; } = "Bicycle";

            //Suit is read-only - it's value can only be set in a constructor
        public string Suit { get; }  //D H S or C
        //same for the value of Value
        public int Value { get; }


       static public readonly Dictionary<int, string> ValueNames = new Dictionary<int, string>()
                {
                    {1, "Ace" },
                    {2, "Two" },
                    {3, "Three" },
                    {4, "Four" },
                    {5, "Five" },
                    {6, "Six" },
                    {7, "Seven" },
                    {8, "Eight" },
                    {9, "Nine" },
                    {10, "Ten" },
                    {11, "Jack" },
                    {12, "Queen" },
                    {13, "King" },
                };

        //ValueName is derieved from the Value
        public string ValueName 
        { 
            get
            {
            

                return ValueNames[this.Value];
            }
                
                }


        //IsFaceCard is a derived property from Suit. 
        public bool IsFaceCard { 
            
            get
            {
                return (this.Value > 10);
            }
                
                }

        public string Color  //Color is a derived property from a suit. 
        {
            get
            {
                if (this.Suit == "D" || this.Suit == "H")
                {
                    return "Red";
                }
                else
                {
                    return "Black";
                }
            }
        }


        public bool IsFaceUp { get; private set; } = false;


        public bool Flip()
        {
            this.IsFaceUp = !this.IsFaceCard;
            return this.IsFaceUp;
        }
    }
}

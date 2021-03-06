﻿using DeckOfCards.Models;
using System;
using System.Collections.Generic;


namespace DeckOfCards
{
    class Program
    {
        static void Main(string[] args)
        {
            // Default output encoding (character set) is ASCII
            // Set it to Unicode so we can display card symbols
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // TODO: Create a card game and start playing!


            //Create a card
            Card card = new Card(12, "H");

            Console.WriteLine($"Card is a {card.ValueName} of {card.Suit}, its color is {card.Color}, and IsFaceUp equals {card.IsFaceUp}");

            Deck deck = new Deck();


            card = deck.DealOne();

            while (card != null)
            {
                Console.WriteLine($"{card.ValueName} of {card.Suit}");
                card = deck.DealOne();
            }

            
        }

        
    }
}

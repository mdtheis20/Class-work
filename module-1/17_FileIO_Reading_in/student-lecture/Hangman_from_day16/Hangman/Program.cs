﻿using System;

namespace Hangman
{
    class Program
    {
        static void Main(string[] args)
        {
            GameManager gameManager = new GameManager();
            gameManager.Run();
        }
    }
}

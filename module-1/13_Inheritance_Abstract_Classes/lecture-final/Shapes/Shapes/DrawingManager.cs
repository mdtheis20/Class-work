﻿using Shapes.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    class DrawingManager
    {
        #region Fields
        List<IDrawable> drawables = new List<IDrawable>();
        #endregion

        #region Methods

        /// <summary>
        /// Starts the drawing manager interacting with the user
        /// </summary>
        public void Run()
        {
            // TODO 01 Add "Get total area" to the menu
            while (true)
            {
                Console.Write(@"
    1) Add a Circle
    2) Add a Rectangle
    3) Draw the Canvas
    4) List all Shapes
    5) Clear the Canvas
    6) Add a Label
    Q) Quit

Please choose an option: ");

                String input = Console.ReadLine().ToLower();

                if (input.Length == 0)
                {
                    Console.Clear();
                    continue;
                }
                input = input.Substring(0, 1);

                if (input == "q")
                {
                    break;
                }
                else if (input == "1")
                {
                    NewCircle();
                }
                else if (input == "2")
                {
                    NewRectangle();
                }
                else if (input == "3")
                {
                    DrawCanvas();
                }
                else if (input == "4")
                {
                    ListDrawingObjects();
                }
                else if (input == "5")
                {
                    ClearCanvas();
                }
                else if (input == "6")
                {
                    NewText();
                }
                // TODO 01: Check for "Get total area" and call a method to calculate and report
                else
                {
                    Error($"'{input}' is an invalid entry. Press enter, then try again.");
                }
                Console.ReadLine();
                Console.Clear();
            }
        }

        private void NewText()
        {
            // Prompt the user for text
            Console.Write("Label Text: ");
            string label = Console.ReadLine();
            ConsoleColor color = GetColor("Label Color: ");
            Text txt = new Text(label, color);
            drawables.Add(txt);
            Success("Text was created");
        }

        /// <summary>
        /// Clear all the shapes
        /// </summary>
        private void ClearCanvas()
        {
            drawables.Clear();
            Success("Canvas was cleared");
        }

        /// <summary>
        /// Show the user the list of shapes
        /// </summary>
        private void ListDrawingObjects()
        {
            Success("Shapes:");
            foreach (IDrawable drawable in drawables)
            {
                Success($"\t{drawable}");
            }
        }

        /// <summary>
        /// Prompt the user and create a new rectangle
        /// </summary>
        private void NewRectangle()
        {
            int width = GetPositiveInt("Width: ", 1, 30);
            int height = GetPositiveInt("Height: ", 1, 30);
            ConsoleColor color = GetColor("Enter the shape color: ");
            bool filled = GetBool("Do you want the shape filled? ");
            drawables.Add(new Rectangle(width, height, color, filled));
            Success("New Rectangle was added");

        }

        /// <summary>
        /// Prompt the user and create a new circle
        /// </summary>
        private void NewCircle()
        {
            int radius = GetPositiveInt("Radius: ", 1, 15);
            ConsoleColor color = GetColor("Enter the shape color: ");
            bool filled = GetBool("Do you want the shape filled? ");
            drawables.Add(new Circle(radius, color, filled));
            Success("New Circle was added");
        }

        /********************************************
         * TODO 07: Create method *private void AddText*
         *          1. Prompt the user for the text label
         *          2. Prompt the user for the text color
         *          3. Create the new Text object
         *          4. Add the new Text object to the list of drawables
         *          5. Report success to the user
         ********************************************/

        // TODO 01: Create method to "Get total area" and report it to the user

        /// <summary>
        /// Draw all the shapes onto the canvas (Console)
        /// </summary>
        public void DrawCanvas()
        {
            foreach (IDrawable drawable in drawables)
            {
                drawable.Draw();
            }
            Success("*** End of Display ***");
        }
        #endregion

        #region Helper Methods

        /// <summary>
        /// Show a prompt and get a Y/N answer from the user.  Y & T == true, everything else == false.
        /// </summary>
        /// <param name="prompt">The prompt to display to the user</param>
        /// <returns>True or false</returns>
        private bool GetBool(string prompt)
        {
            Console.Write(prompt);
            string input = Console.ReadLine().ToLower();
            return (input == "y" || input == "t");
        }

        /// <summary>
        /// Prompt the user for a color. Must match ConsoleColors, even in case.
        /// </summary>
        /// <param name="prompt">Prompt to display to the user</param>
        /// <returns>A ConsoleColor value</returns>
        private ConsoleColor GetColor(string prompt)
        {
            Console.Clear();
            // List all the colors, allow the user to select the number
            string[] colorNames = Enum.GetNames(typeof(ConsoleColor));
            for (int i = 0; i < colorNames.Length; i++)
            {
                Console.WriteLine($"{i + 1} {colorNames[i]}");
            }
            int index = GetPositiveInt(prompt, 1, colorNames.Length);
            return (ConsoleColor)Enum.Parse(typeof(ConsoleColor), colorNames[index - 1]);
        }

        /// <summary>
        /// Prompt the user and get a positive integer
        /// </summary>
        /// <param name="prompt">Prompt to display to the user</param>
        /// <param name="min">User's value must be >= this.</param>
        /// <param name="max">User's value must be &lt;= this</param>
        /// <returns>An integer between min and max inclusive</returns>
        private int GetPositiveInt(string prompt, int min, int max)
        {
            int num = 0;
            while (num <= 0)
            {
                Console.Write(prompt);
                if (!int.TryParse(Console.ReadLine(), out num) || num < min || num > max)
                {
                    Error($"Please enter an integer from {min} to {max}.");
                    num = 0;
                }
            }
            return num;
        }

        /// <summary>
        /// Display a message in the success color
        /// </summary>
        /// <param name="msg">Message to display</param>
        private void Success(string msg)
        {
            ConsoleColor color = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(msg);
            Console.ForegroundColor = color;
        }

        /// <summary>
        /// Display a message in the error color
        /// </summary>
        /// <param name="msg">Message to display</param>
        private void Error(string msg)
        {
            ConsoleColor color = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(msg);
            Console.ForegroundColor = color;
        }
        #endregion
    }
}

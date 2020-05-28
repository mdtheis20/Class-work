using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes.Models
{
    /**************************************************
    * Until now, we have been Drawing Shape2D objects (including anything that IS A Shape2D by inheritance).  But we
    * need to include other drawable things which are not 2D shapes, like sprites and lines.  So we defined an IDrawable 
    * interface to say what a class CAN DO.  
    * 
    **************************************************/

    // TODO 02: Should any of the methods of Shape2D be abstract?

    /// <summary>
    /// A two-dimensional shape that can be drawn on the screen
    /// </summary>
    public abstract class Shape2D : IDrawable
    {
        #region Properties
        public bool IsFilled { get; set; }

        public ConsoleColor Color { get; set; }
        #endregion

        #region Fields
        // A place to save the current color for restoring after the draw
        private ConsoleColor savedColor = ConsoleColor.White;
        #endregion

        #region Constructors
        public Shape2D(ConsoleColor color, bool isFilled )
        {
            this.Color = color;
            this.IsFilled = isFilled;
        }
        #endregion

        #region Public Methods

        // This should be abstract later
        abstract  public void Draw();
        
        // This should be abstract later
        abstract public int Area { get; }

        // This should be abstract later
        abstract public int Perimeter { get;  }

        #endregion

        #region Helper Methods
        protected void SetConsoleColor()
        {
            this.savedColor = Console.ForegroundColor;
            Console.ForegroundColor = Color;
        }

        protected void ResetConsoleColor()
        {
            Console.ForegroundColor = savedColor;
        }
        #endregion
    }
}


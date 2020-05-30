﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractExercise
{
    public class SquareWall : RectangleWall
    {

        public int SideLength { get; }
        public SquareWall(string name, string color, int sideLength) : base(name, color, sideLength, sideLength)
        {
            SideLength = sideLength;
        }



        public override int GetArea()
        {
            return SideLength * SideLength;


        }
        public override string ToString()
        {
            return $"{Name} ({SideLength}x{SideLength}) square";
        }
    }
}



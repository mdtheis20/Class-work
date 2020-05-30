using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractExercise
{ 
    abstract public class Wall
    {
        public string Name { get; }
        public string Color { get; }
        abstract public int GetArea();

        public Wall(string name, string color)
        {
            Name = name;
            Color = color;
        }
        

        
    }
}

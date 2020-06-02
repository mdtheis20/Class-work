using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace States.Model
{
    class StateFileLoader
    {
        public List<State> StateList { get; set; }
        public StateFileLoader(string filePath)
        {
            // TODO 21: Open the file, read each line, parse it, and load up a list of states.
            StateList = new List<State>();


            //Open the file

            using (StreamReader rdr = new StreamReader(filePath))
            {
                while (!rdr.EndOfStream)
                {
                    //Read a line from the states file
                    string line = rdr.ReadLine();

                    //SPlit the line by the pipe | character

                    string[] fields = line.Split("|");

                    //Create a state fro, these fields
                    State state = new State(fields[1], fields[0], fields[2], fields[3]);
                    //Add it to the list
                    StateList.Add(state);

                }
            }
        }
    }
}

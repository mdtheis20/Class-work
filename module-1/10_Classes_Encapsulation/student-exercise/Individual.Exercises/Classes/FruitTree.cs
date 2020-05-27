namespace Individual.Exercises.Classes
{
    public class FruitTree
    {
        public string TypeOfFruit { get; }
        public int PiecesOfFruitLeft { get; private set; }

        public FruitTree (string typeOfFruit, int startingPiecesOfFruit)
        {
            this.TypeOfFruit = typeOfFruit;

            this.PiecesOfFruitLeft = startingPiecesOfFruit;
            
        }

        public bool PickFruit(int numberOfPiecesToRemove)
        {
            if ( numberOfPiecesToRemove <= PiecesOfFruitLeft)
            {
                PiecesOfFruitLeft -= numberOfPiecesToRemove;
                return true;
            }
          
            else 
            {
                
                return false;
            }
            
        }

    }
}

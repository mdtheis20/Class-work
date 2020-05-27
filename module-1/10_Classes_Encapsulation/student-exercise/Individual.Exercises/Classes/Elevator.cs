namespace Individual.Exercises.Classes
{
    public class Elevator
    {
        public int CurrentLevel { get; private set; } = 1;
        public int NumberOfLevels { get; }
        public bool DoorIsOpen { get; private set; }


        public Elevator(int numberOfLevels)
        {
            this.NumberOfLevels = numberOfLevels;
        }



        public void OpenDoor()
        {
            DoorIsOpen = true;
        }
        public void CloseDoor()
        {
            DoorIsOpen = false;
        }
        public void GoUp(int desiredFloor)
        {
            
            if (!DoorIsOpen && desiredFloor <= NumberOfLevels && desiredFloor > CurrentLevel)
            {
                CurrentLevel = desiredFloor; 

            }
            else
            {
                CurrentLevel = CurrentLevel;
            }
        }
        public void GoDown(int desiredFloor)
        {
            
            if (!DoorIsOpen && desiredFloor >= 1 && CurrentLevel > desiredFloor)
            {
                CurrentLevel = desiredFloor;
            }
            else
            {
                CurrentLevel = CurrentLevel;
            }
        }
    }

}

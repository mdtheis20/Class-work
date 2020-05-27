namespace Individual.Exercises.Classes
{
    public class HomeworkAssignment
    {
        public int EarnedMarks { get; set; }
        public int PossibleMarks { get; }
        public string SubmitterName { get; }
        public string LetterGrade
        {
            get

            {
                double percentage = (double)EarnedMarks / PossibleMarks;
                if (percentage >= .90)
                {
                    return "A";
                }
                if (percentage >= .80)
                {
                    return "B";
                }
                if (percentage >= .70)
                {
                    return "C";

                }
                if (percentage >= .60)
                {
                    return "D";


                }
                return "F";
            }
        }
        public HomeworkAssignment(int possibleMarks, string submitterName)
        {
            PossibleMarks = possibleMarks;
            SubmitterName = submitterName;
        }
    }
}
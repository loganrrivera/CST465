namespace Lab3.Objects
{
    public class ChoreLaborer
    {
        public string Name {get;set;}
        public int Age {get;set;}
        public int Difficulty 
        {
            get{
                return _Difficulty;
            } 
            set{
                if(value < 0)
                {
                    _Difficulty = 0;
                }
                else if(value > 10)
                {
                    _Difficulty = 10;
                }
                else
                {
                    _Difficulty = value;
                }
            }
        }
        private int _Difficulty;

    }
}
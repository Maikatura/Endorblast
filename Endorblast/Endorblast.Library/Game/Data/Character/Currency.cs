namespace Endorblast.Lib.Game.Data
{
    public class Currency
    {
        
        // Variables
        
        private int gold;
        private int premium;

        
        
        // Get set!
        
        public int Premium
        {
            get => premium;
            set => premium = value;
        }
        public int Gold
        {
            get => gold;
            set => gold = value;
        }
    }
}
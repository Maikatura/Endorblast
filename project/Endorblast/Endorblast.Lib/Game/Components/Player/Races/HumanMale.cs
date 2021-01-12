namespace Endorblast.Lib.Game.Player.Races
{
    class HumanMale : RaceClass
    {
        
        

        public HumanMale()
        {
            // Female Human.
            idle = ContentLoader.LoadSprites(path + "/Human/Male/Idle.png", 64,64);
            walking = ContentLoader.LoadSprites(path + "/Human/Male/Running.png", 64, 64);
            basicAttack = ContentLoader.LoadSprites(path + "/Human/Male/BasicAttack.png", 64, 64);


        }
        
    }
}
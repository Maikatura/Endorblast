namespace Endorblast.Lib.Game.Player.Races
{
    class HumanFemale : RaceClass
    {
        
        
        public HumanFemale()
        {
            idle = ContentLoader.LoadSprites(path + "/Human/Female/Idle.png", 64,64);
            walking = ContentLoader.LoadSprites(path + "/Human/Female/Running.png", 64, 64);
            basicAttack = ContentLoader.LoadSprites(path + "/Human/Female/BasicAttack.png", 64, 64);
            slide = ContentLoader.LoadSprites(path + "/Human/Female/Slide.png", 64, 64);
            
        }
    }
}
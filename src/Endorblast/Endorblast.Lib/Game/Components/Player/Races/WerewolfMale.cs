namespace Endorblast.Lib.Game.Player.Races
{
    class WerewolfMale : RaceClass
    {
        public WerewolfMale()
        {
            // Male Werewolf.
            idle = ContentLoader.LoadSprites(path + "/Werewolf/Male/Idle.png", 64,64);
            walking = ContentLoader.LoadSprites(path + "/Werewolf/Male/Running.png", 64, 64);
            basicAttack = ContentLoader.LoadSprites(path + "/Werewolf/Male/BasicAttack.png", 64, 64);
            
        }
    }
}
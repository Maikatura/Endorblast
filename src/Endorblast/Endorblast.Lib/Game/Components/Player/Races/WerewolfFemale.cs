namespace Endorblast.Lib.Game.Player.Races
{
    class WerewolfFemale : RaceClass
    {
        public WerewolfFemale()
        {
            // Female Human.
            idle = ContentLoader.LoadSprites(path + "/Werewolf/Female/Idle.png", 64,64);
            walking = ContentLoader.LoadSprites(path + "/Werewolf/Female/Running.png", 64, 64);
            basicAttack = ContentLoader.LoadSprites(path + "/Werewolf/Female/BasicAttack.png", 64, 64);


        }
    }
}
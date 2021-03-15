using Endorblast.Lib.Game.Data;
using Endorblast.Lib.Game.Utils;
using Lidgren.Network;

namespace Endorblast.Game.Data
{
    public class ServerPlayer
    {
        private NetConnection connection;
        public int DBAccountID;
        public int DBCharacterID;


        public Stats stats;
        public Currency currency;
        public CharacterInformation charaInfo;
        public WorldInfo worldInfo;
        public Role rank;

        public ServerPlayer()
        {
            rank = new Role();
            charaInfo = new CharacterInformation();
            worldInfo = new WorldInfo();
            currency = new Currency();
            stats = new Stats();
        }
        
        
        
        
        

        


        

    }
}
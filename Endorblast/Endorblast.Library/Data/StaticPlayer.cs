using Endorblast.Library;
using Endorblast.Library.Entities;
using Endorblast.Library.Enums;
using Nez;

namespace Endorblast.LoginServer.Data
{
    public class StaticPlayer
    {
        public GenderTypes Gender { get; set; }
        public PlayerClassTypes PlayableClass { get; set; }
        public PlayerRaceTypes Race { get; set; }
        
        public string Name { get; set; }
        public int Level { get; set; }







        public BasePlayer ToBasePlayer()
        {
            var basePlayer = new BasePlayer(Name)
            {
                Gender =  this.Gender,
                PlayableClass = this.PlayableClass,
                Race = this.Race,
                Name = this.Name,
                Level = this.Level
            };




            return basePlayer;

        }
    }
}
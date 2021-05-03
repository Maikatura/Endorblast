using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Endorblast.Game;
using Endorblast.Library.Skills;
using Endorblast.Library;
using Endorblast.Library.Entities;
using Endorblast.Library.Network;

namespace Endorblast.Library
{
    public class PlayerManager
    {

        static PlayerManager instance = new PlayerManager();
        public static PlayerManager Instance => instance;


        public List<BasePlayer> Players = new List<BasePlayer>();
        //public Player Player;

        //double activityTimer = 20;
        public bool TimedOut;

        public BasePlayer GetPlayer(int pid) => Players.FirstOrDefault(x => x.WorldID == pid);
        public BasePlayer GetPlayer(string name) => Players.FirstOrDefault(x => x.CharacterName == name);

        PlayerManager()
        {
            //WorldCharacterEnterCommand.Event += WorldCharacterEnterCommand_Event;
            //WorldRemoveCharacterCommand.Event += WorldRemoveCharacterCommand_Event;
            //CharacterActivityCommand.Event += CharacterActivityCommand_Event;
            //CharacterDataCommand.PositionEvent += CharacterDataCommand_PositionEvent;
            //CharacterListCommand.CharacterListEvent += CharacterListCommand_CharacterListEvent;
            //CharacterSkillCastCommand.Event += CharacterSkillCastCommand_CharacterSkillCastEvent;
            // https://i.imgur.com/2dR1tey.png
        }

        public void Load()
        {
            Players = new List<BasePlayer>();

            Console.WriteLine("# PLAYERMANAGER LOADED");
        }

        //private void CharacterActivityCommand_Event(object sender, CharacterActivityEvent e)
        //{
        //    activityTimer = 5;
        //}

        private void CharacterSkillCastCommand_CharacterSkillCastEvent(object sender, CharacterSkillCastEvent e)
        {
            var player = GetPlayer(e.pid);

            if (player == null)
            {
                Console.WriteLine("Player was null when doing skill - - pid:" + e.pid);
                return;
            }

            //player.currentSkill = Skill.DoSkill(e.skillType, player, e.direction);
            Console.WriteLine($"{player.CharacterName} did skill {e.ActionType.ToString()}");
        }


        //private void WorldRemoveCharacterCommand_Event(object sender, WorldRemoveCharacterEvent e)
        //{

        //}

        private void CharacterListCommand_CharacterListEvent(object sender, CharacterListEvent e)
        {
            Console.WriteLine("DID EVENT");

            foreach (var bp in e.Characters)
            {
                //AddPlayer(bp);
            }
        }

        private void CharacterDataCommand_PositionEvent(object sender, CharacterDataPositionEvent e)
        {
            var p = Players.FirstOrDefault(x => x.WorldID == e.worldid);

            if (p == null)
            {
                Console.WriteLine("[ERROR] Update player position - player was null, worldID -- " + e.worldid);
                return;
            }

            p.Transform.Position = new Vector2(e.x, e.y);
        }

    }
}

using System;
using Endorblast.Library.Classes;
using Endorblast.Library.Enums;
using Endorblast.Library.Movement;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Nez;
using Nez.Sprites;
using Nez.Tiled;
using Random = Nez.Random;

namespace Endorblast.Library.Entities
{
    public class BasePlayerV2 : Component, IUpdatable
    {
        PlayerName playerName;
        private BaseCharacterClass playerClass;
        protected BaseMovement movement;
        

        private string saveUsername;


        public BasePlayerV2(string username)
        {
            saveUsername = username;

            
            
        }
        
        public override void OnAddedToEntity()
        {
            base.OnAddedToEntity();
            
            playerClass = Entity.GetComponent<BaseWarriorClass>();
            playerName = Entity.GetComponent<PlayerName>();
            movement = Entity.GetComponent<BaseMovement>();
            
            
            
            
            LoadClass(GenderTypes.Female, PlayerRaceTypes.Human, PlayerClassTypes.Warrior);
            
        }
        
        
        public override void Initialize()
        {
            base.Initialize();
            Init();
        }
        

        public void Update()
        {
            if (!Entity.Equals(null))
            {
                movement.Update();
            }
        }
        
        

        protected virtual void Init()
        {
            
        }
        
        
        public void LoadClass(GenderTypes gender, PlayerRaceTypes race, PlayerClassTypes type)
        {
            playerClass.LoadSprites(gender, race);
            movement = movement.GetMovement(type);
            
        }
    }
}
using System;
using Endorblast.Library.Classes;
using Endorblast.Library.Entities;
using Endorblast.Library.Enums;
using Endorblast.Library.Movement;
using Endorblast.Library.Player;
using Nez;
using Nez.Sprites;
using Nez.Tiled;

namespace Endorblast.Library
{
    public class BasePlayer : Entity, IUpdatable
    {
        
        protected BaseCharacterClass playerClass;
        public GenderTypes Gender;
        public PlayerClassTypes PlayableClass;
        public PlayerRaceTypes Race;
        
        public string Name;
        public int Level;
        

        protected BaseMovement movement;


        public BasePlayer(string entityName) : base(entityName)
        {
            Name = entityName;
        }
        
        public override void OnAddedToScene()
        {
            base.OnAddedToScene();
            
            
            AddComponent(new TiledMapMover(MapManager.Instance.groundLayer));
            AddComponent(new BasePlayerV2( "Zyro"));

            AddComponent(LoadPlayerClass(Gender, PlayableClass, Race));
            AddComponent(new PlayerName(Name, Level));
            movement = AddComponent(new BaseMovement());

            AddComponent(new SpriteAnimator());

            AddComponent(new OutfitChanger());
            AddComponent(new BodyPart());
            AddComponent(new HatPart());
            AddComponent(new ClothPart());
            AddComponent(new FeetPart());
            
            
            var boxCollider = AddComponent(new BoxCollider());
            boxCollider.Width = 8;
            boxCollider.Height = 64;
            
            
        }


        private BaseCharacterClass LoadPlayerClass(GenderTypes gender, PlayerClassTypes playableClass,PlayerRaceTypes race)
        {
            switch (playableClass, gender)
            {
                case (PlayerClassTypes.Archer, GenderTypes.Female):
                    return new BaseWarriorClass();
                    break;
                case (PlayerClassTypes.Warrior, GenderTypes.Female):
                    return new BaseWarriorClass();
                    break;
                case (PlayerClassTypes.Mage, GenderTypes.Female):
                    return new BaseWarriorClass();
                    break;
                default:
                    return new BaseCharacterClass();
            }
        }
        
        
    }
}
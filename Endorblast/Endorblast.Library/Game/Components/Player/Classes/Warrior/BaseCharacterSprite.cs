using System;
using System.Collections.Generic;
using System.Linq;
using Endorblast.Library.Enums;
using Endorblast.Library.Game.Player.Races;
using Microsoft.Xna.Framework;
using Nez.Sprites;
using Nez.Textures;

namespace Endorblast.Library.Classes
{
    public class BaseCharacterSprite
    {
        
        private Dictionary<ActionType, SpriteAnimation> baseSprites;

        private Sprite headSprite;

        public Vector2 headOffset;
        public Vector2 headSpriteOffset;

        #region Get / Set

        public Sprite HeadSprite
        {
            get => headSprite;
            set => headSprite = value;
        }

        #endregion
        public Dictionary<ActionType, SpriteAnimation> BaseSprites
        {
            get => baseSprites;
            set => baseSprites = value;
        }
        
        public SpriteAnimation GetSprites(ActionType actionType)
        {
            if (!baseSprites.ContainsKey(actionType))
                return null;
            
            return baseSprites.FirstOrDefault(x => x.Key == actionType).Value;
        }

        public Sprite GetHead()
        {
            return HeadSprite;
        }
        
        public BaseCharacterSprite()
        {
            baseSprites = new Dictionary<ActionType, SpriteAnimation>();
            LoadSprites();
            LoadInfomation();
        }

        protected virtual void LoadSprites()
        {
            
        }
        
        protected virtual void LoadInfomation()
        {
            
        }
        
        
        public void LoadClass(GenderTypes gender, PlayerRaceTypes race, PlayerClassTypes type)
        {
            
        }

        public BaseCharacterSprite SetSprites(GenderTypes gender, PlayerRaceTypes race)
        {
            BaseCharacterSprite returnValue = null;
            
            switch (gender, race)
            {
                ///////////////////////////
                //       Human
                ///////////////////////////
                case (GenderTypes.Female, PlayerRaceTypes.Human):
                    returnValue = new HumanFemaleSprite();
                    break;
                case (GenderTypes.Male, PlayerRaceTypes.Human):
                    break;
                
                default:
                    Console.WriteLine("That combination is not available");
                    break;
            }

            return returnValue;
        }
        
    }
}
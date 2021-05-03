using System.Collections.Generic;
using System.Linq;
using Endorblast.Library.Enums;
using Nez.Sprites;

namespace Endorblast.Library.Classes
{
    public class BaseCharacterSprite
    {
        
        private Dictionary<ActionType, SpriteAnimation> baseSprites;


        #region Get / Set

        

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
        
        public BaseCharacterSprite()
        {
            baseSprites = new Dictionary<ActionType, SpriteAnimation>();
            LoadSprites();
        }

        protected virtual void LoadSprites()
        {
            
        }
        
    }
}
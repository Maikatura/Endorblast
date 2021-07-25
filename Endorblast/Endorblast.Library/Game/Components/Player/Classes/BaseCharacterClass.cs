using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Endorblast.Library.Classes;
using Endorblast.Library.Enums;
using Endorblast.Library.Game.Player.Races;
using Endorblast.Library.Movement;
using Endorblast.Library.Skills;
using Nez;
using Nez.Sprites;

namespace Endorblast.Library
{
    public class BaseCharacterClass : Component
    {

        private string characterClassName;
        private string characterClassDescription;
        private string characterClassSecret;
        

        private int strength;
        private int intellect;
        private int mana;
        private int stamina;

        
        protected BaseCharacterSprite sprites;

        public BaseCharacterClass()
        {
            sprites = new BaseCharacterSprite();
           
        }
        
        
        
        public string CharacterClassName
        {
            get => characterClassName;
            set => characterClassName = value;
        }
        public string CharacterClassDescription
        {
            get => characterClassDescription;
            set => characterClassDescription = value;
        }
        public string CharacterClassSecret
        {
            get => characterClassSecret;
            set => characterClassSecret = value;
        }

        public int Strength
        {
            get => strength;
            set => strength = value;
        }
        public int Intellect
        {
            get => intellect;
            set => intellect = value;
        }
        public int Mana
        {
            get => mana;
            set => mana = value;
        }
        public int Stamina
        {
            get => stamina;
            set => stamina = value;
        }

        public BaseCharacterSprite Sprites
        {
            get => sprites;
        }

        public void LoadSprites(GenderTypes gender, PlayerRaceTypes race)
        {
            sprites = sprites.SetSprites(gender, race);
        }
        
    }
}
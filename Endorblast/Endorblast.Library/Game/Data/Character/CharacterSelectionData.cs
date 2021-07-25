using System;
using Endorblast.LoginServer.Data;

namespace Endorblast.Lib.Game.Data
{
    public class CharacterSelectionData
    {
        public int ID;
        public int AccountID;
        public string CharacterName;
        public int Level;

        public int WeaponId = 0;
        public int SubWeaponId = 0;
        
        public int HairId = 0;
        public int HelmetId = 0;
        public int ChestId = 0;
        public int LegId = 0;
        public int ShoeId = 0;


        public override string ToString()
        {
            return $"Character Name: {CharacterName}\nID: {ID}\nChest ID: {ChestId}";
        }
    }
}
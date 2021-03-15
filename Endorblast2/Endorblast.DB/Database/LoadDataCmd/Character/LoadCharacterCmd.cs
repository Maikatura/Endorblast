using System;
using Endorblast.Game.Data;
using Lidgren.Network;

namespace Endorblast.DB
{
    public class LoadCharacterCmd
    {

        
        public static void LoadCharacter(int AccountID, int CharacterID)
        {
            ServerPlayer player = new ServerPlayer();
            
           
            
            
            var charaterInfo = LoadAccountCharacterCmd.GrabAccountCharacter(AccountID, CharacterID);
            var worldInfo = LoadCharacterPositionCmd.GrabCharacterPosition(CharacterID);
            var position = LoadCharacterPositionCmd.GrabCharacterPosition(CharacterID);
            var stats = LoadCharacterStatsCmd.GrabCharacterStats( CharacterID);
            var goldAmount = LoadCharacterGoldCmd.GrabCharacterGold(CharacterID);
            var rank = LoadRankCmd.GrabAccountRank(AccountID);

            player.charaInfo = charaterInfo;
            player.worldInfo = worldInfo;
            player.stats = stats;
            player.currency.Gold = goldAmount;
            player.rank = rank;

            Console.WriteLine("Loading Character....");
            Console.WriteLine($"Character Name  : {player.charaInfo.CharacterName}");
            Console.WriteLine($"Account Rank    : {player.rank.RoleName}");
            Console.WriteLine($"Gold            : {player.currency.Gold}");
            Console.WriteLine($"Level           : {player.stats.Level}");
            Console.WriteLine($"Exp             : {player.stats.Exp}");
            Console.WriteLine($"WorldID         : {player.worldInfo.WorldID}");
            Console.WriteLine($"Position        : {player.worldInfo.Position}");

        }
        
    }
}
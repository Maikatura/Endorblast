using System;
using Endorblast.Lib.Game.Data;
using MySql.Data.MySqlClient;

namespace Endorblast.DBase
{
    public class LoadAccountCharacterCmd : DatabaseCmd
    {
        
        public static CharacterInformation GrabAccountCharacter(int accountID, int characterID)
        {

            var charaInfo = new CharacterInformation();
            
            con = null;
            reader = null;

            try
            {
                con = new MySqlConnection(DBStr);
                con.Open();
                
                
                // Database String && Variables
                string cmdText = "SELECT * FROM characters WHERE AccountID='" + accountID + "' AND id='" + characterID + "';";

                // Unimportant
                MySqlCommand cmd = new MySqlCommand(cmdText, con);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    // Setup Stuff....
                    charaInfo.CharacterName = reader.GetString(2);
                }
                
                // Build Character First
                charaInfo.CharacterId = characterID;
                charaInfo.AccountId = accountID;


                // Return Stuff Below
                
            }
            catch (MySqlException err)
            {
                Console.WriteLine(err);
               
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }

            return charaInfo;
        }
        
    }
}
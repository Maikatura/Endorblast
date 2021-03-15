using System;
using MySql.Data.MySqlClient;

namespace Endorblast.DB
{
    public class LoadCharacterGoldCmd : DatabaseCmd
    {
        public static int GrabCharacterGold(int characterID)
        {
            con = null;
            reader = null;
            
            int gold = 0;

            try
            {
                con = new MySqlConnection(DBStr);
                con.Open();
                
                // Database String && Variables
                string cmdText = "SELECT * FROM characters_currency WHERE CharacterID='" + characterID + "';";

                
                // Unimportant
                MySqlCommand cmd = new MySqlCommand(cmdText, con);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    // Setup Stuff....
                    gold = reader.GetInt32(2);
                }
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
                    con.Dispose();
                }
            }

            return gold;
        }
    }
}
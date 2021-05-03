using System;
using MySql.Data.MySqlClient;

namespace Endorblast.DBase
{



        public class LoadCharacterCurrencyCmd : DatabaseCmd
        {

            public static int GrabStorageGold(int characterID)
            {
                con = null;
                reader = null;

                try
                {
                    con = new MySqlConnection(DBStr);
                    con.Open();


                    // Database String && Variables
                    string cmdText = "SELECT * FROM characters_currency WHERE CharacterID='" + characterID + "';";

                    int storageGold = 0;


                    // Unimportant
                    MySqlCommand cmd = new MySqlCommand(cmdText, con);
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        // Setup Stuff....
                        storageGold = reader.GetInt32(3);
                    }

                    return storageGold;

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

                return 0;
            }
        }
}
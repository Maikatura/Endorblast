using System;
using Endorblast.Lib.Game.Data;
using Endorblast.LoginServer.Data;
using MySql.Data.MySqlClient;

namespace Endorblast.DBase
{
    public class LoadCharacterGearCmd : DatabaseCmd
    {


        public CharacterSelectionData LoadGear(int characterId, CharacterSelectionData currentData)
        {

            con = null;
            reader = null;

            try
            {
                con = new MySqlConnection(DBStr);
                con.Open();
                
                
                // Database String && Variables
                string cmdText = "SELECT * FROM characters_equipment WHERE CharacterID='" + characterId + "';";

                // Unimportant
                MySqlCommand cmd = new MySqlCommand(cmdText, con);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    currentData.HelmetId = reader.GetInt32(2);
                    currentData.ChestId = reader.GetInt32(3);
                    currentData.LegId = reader.GetInt32(4);
                    currentData.ShoeId = reader.GetInt32(5);
                    currentData.WeaponId = reader.GetInt32(6);
                    currentData.SubWeaponId = reader.GetInt32(7);
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
                }
            }

            return currentData;
        }
        
    }
}
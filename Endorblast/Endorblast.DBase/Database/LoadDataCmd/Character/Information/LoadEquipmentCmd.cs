using System;
using Endorblast.Lib.Game.Data;
using Endorblast.Library.Game.Data;
using MySql.Data.MySqlClient;

namespace Endorblast.DBase
{
    public class LoadEquipmentCmd : DatabaseCmd
    {
        public Equipment LoadEquipment(int charaId)
        {
            con = null;
            reader = null;
            
            var equip = new Equipment();

            try
            {
                con = new MySqlConnection(DBStr);
                con.Open();
                
                // Database String && Variables
                string cmdText = "SELECT * FROM characters_equipment WHERE CharacterID='"+ charaId +"';";

                // Unimportant
                MySqlCommand cmd = new MySqlCommand(cmdText, con);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    equip.headId = reader.GetInt32(2);
                    equip.armorId = reader.GetInt32(3);
                    equip.legsId = reader.GetInt32(4);
                    equip.shoeId = reader.GetInt32(5);
                    equip.weaponId = reader.GetInt32(6);
                    equip.offhandId = reader.GetInt32(7);
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

            return equip;
        }
    }
}
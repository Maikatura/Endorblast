using System;
using Endorblast.Lib.Game.Data;
using MySql.Data.MySqlClient;

namespace Endorblast.DBase.LoadDataCmd.Data
{
    public class LoadItemCmd : DatabaseCmd
    {


        public ItemData LoadItem(int id)
        {
            con = null;
            reader = null;
            
            var item = new ItemData();

            try
            {
                con = new MySqlConnection(DBStr);
                con.Open();
                
                // Database String && Variables
                string cmdText = "SELECT * FROM item WHERE id='"+ id +"';";

                // Unimportant
                MySqlCommand cmd = new MySqlCommand(cmdText, con);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    item.Id = reader.GetInt32(0);
                    item.Name = reader.GetString(1);
                    item.Stackable = reader.GetBoolean(2);
                    item.Equippable = reader.GetBoolean(3);
                    item.Consumable = reader.GetBoolean(4);
                    item.IconSheetId = reader.GetInt32(5);
                    item.IconId = reader.GetInt32(6);
                    item.Value = reader.GetInt32(7);
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

            return item;
        }
        
    }
}
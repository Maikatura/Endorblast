using System;
using System.Collections.Generic;
using Endorblast.Lib.Game.Data;
using MySql.Data.MySqlClient;

namespace Endorblast.DBase.LoadDataCmd.Data
{
    public class LoadItemsCmd : DatabaseCmd
    {


        public List<ItemData> LoadItems()
        {
            var itemData = new List<ItemData>();


            con = null;
            reader = null;

            try
            {
                con = new MySqlConnection(DBStr);
                con.Open();
                
                // Database String && Variables
                string cmdText = "SELECT * FROM item;";

                // Unimportant
                MySqlCommand cmd = new MySqlCommand(cmdText, con);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var newItem = new ItemData();
                    newItem.Id = reader.GetInt32(0);
                    newItem.Name = reader.GetString(1);
                    newItem.Stackable = reader.GetBoolean(2);
                    newItem.Equippable = reader.GetBoolean(3);
                    newItem.Consumable = reader.GetBoolean(4);
                    newItem.IconSheetId = reader.GetInt32(5);
                    newItem.IconId = reader.GetInt32(6);
                    newItem.Value = reader.GetInt32(7);
                    
                    itemData.Add(newItem);
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


            return itemData;
        }
        
        
        

    }
}
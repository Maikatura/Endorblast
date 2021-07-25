using System;
using System.Collections.Generic;
using Endorblast.Lib.Game.Data;
using MySql.Data.MySqlClient;

namespace Endorblast.DBase
{
    public class LoadCharactersDBCmd : DatabaseCmd
    {

        public List<CharacterSelectionData> LoadAllCharacters()
        {
            return null;
        }

        // Load All Account Characters
        public List<CharacterSelectionData> LoadAllCharacters(int id)
        {
            var list = new List<CharacterSelectionData>();
            
            con = null;
            reader = null;

            try
            {
                
                string cmdText = "SELECT id, AccountID, CharacterName FROM characters WHERE AccountID='" + id + "';";
                
                con = new MySqlConnection(DBStr);
                con.Open();
                MySqlCommand cmd = new MySqlCommand(cmdText, con);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var data = new CharacterSelectionData();
                    data.ID = reader.GetInt32(0);
                    data.AccountID = reader.GetInt32(1);
                    data.CharacterName = reader.GetString(2);

                    

                    list.Add(data);
                }

                

                for (int i = 0; i < list.Count; i++)
                {
                    int charaId = list[i].ID;
                    list[i].Level = new LoadCharacterLevelCmd().GrabLevel(charaId);
                    list[i] = new LoadCharacterGearCmd().LoadGear(charaId, list[i]);
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
            
            
            
            return list;
        }
        
        // Load All Account Characters by Account Name
        public List<CharacterSelectionData> LoadAllCharacters(string name)
        {
            
            
            MySqlConnection con = null;
            MySqlDataReader reader = null;

            try
            {
                con = new MySqlConnection(DBStr);

                con.Open();
                

                string cmdText = "SELECT CharacterName FROM characters WHERE CharacterName='" + name + "';";

                MySqlCommand cmd = new MySqlCommand(cmdText, con);

                var list = new List<CharacterSelectionData>();

                reader = cmd.ExecuteReader();

                bool rightLoggin = false;
                int userID = 0;

                while (reader.Read())
                {
                    
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
            
            return null;
        }
        
        // Load Specific Characters
        public CharacterSelectionData LoadCharacter(int id)
        {
            
            
            
            MySqlConnection con = null;
            MySqlDataReader reader = null;

            try
            {
                var data = new CharacterSelectionData();
                
                // Database Stuffy thing
                string cmdText = "SELECT id, AccountID, CharacterName, Lvl FROM characters WHERE id='" + id + "';";

                // MySQL Stuff :)
                con = new MySqlConnection(DBStr);
                con.Open();
                MySqlCommand cmd = new MySqlCommand(cmdText, con);
                reader = cmd.ExecuteReader();
                

                while (reader.Read())
                {
                    data.ID = int.Parse(reader["id"].ToString());
                    data.AccountID = int.Parse(reader["AccountID"].ToString());
                    data.CharacterName = reader["CharacterName"].ToString();
                    data.Level = int.Parse(reader["Lvl"].ToString());
                }

                return data;


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
            
            return null;
        }

        
        
        
        
        
    }
}
using System;
using System.Collections.Generic;
using Endorblast.Lib;
using Endorblast.LoginServer.Data;
using MySql.Data.MySqlClient;

namespace Endorblast.GameServer.Login.DataCmd
{
    public class LoadCharactersDBCmd
    {

        public List<CharacterSelectionData> LoadAllCharacters()
        {
            return null;
        }

        // Load All Account Characters
        public List<CharacterSelectionData> LoadAllCharacters(int id)
        {
            string str = $@"server={Database.Instance.ip};database={Database.Instance.database};"
                         + $@"userid={Database.Instance.user};password={Database.Instance.pass};";
            
            MySqlConnection con = null;
            MySqlDataReader reader = null;

            try
            {
                ConsoleHelper.WriteLine($"MySQL Connected for ID: {id}", ServerErrors.Info);
                string cmdText = "SELECT id, AccountID, CharacterName, Lvl FROM characters WHERE AccountID='" + id + "';";
                
                con = new MySqlConnection(str);
                con.Open();
                MySqlCommand cmd = new MySqlCommand(cmdText, con);
                reader = cmd.ExecuteReader();
                
                var list = new List<CharacterSelectionData>();

                while (reader.Read())
                {
                    var data = new CharacterSelectionData();
                    data.ID = int.Parse(reader["id"].ToString());
                    data.AccountID = int.Parse(reader["AccountID"].ToString());
                    data.CharacterName = reader["CharacterName"].ToString();
                    data.Level = int.Parse(reader["Lvl"].ToString());
                    
                    list.Add(data);
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
        
        // Load All Account Characters by Account Name
        public List<CharacterSelectionData> LoadAllCharacters(string name)
        {
            string str = $@"server={Database.Instance.ip};database={Database.Instance.database};"
                         + $@"userid={Database.Instance.user};password={Database.Instance.pass};";
            
            
            MySqlConnection con = null;
            MySqlDataReader reader = null;

            try
            {
                con = new MySqlConnection(str);

                con.Open();

                ConsoleHelper.WriteLine($"MySQL Connected for Name: {name}", ServerErrors.Info);

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
            string str = $@"server={Database.Instance.ip};database={Database.Instance.database};"
                         + $@"userid={Database.Instance.user};password={Database.Instance.pass};";
            
            
            MySqlConnection con = null;
            MySqlDataReader reader = null;

            try
            {
                ConsoleHelper.WriteLine($"MySQL Connected for Character ID: {id}", ServerErrors.Info);
                var data = new CharacterSelectionData();
                
                // Database Stuffy thing
                string cmdText = "SELECT id, AccountID, CharacterName, Lvl FROM characters WHERE id='" + id + "';";

                // MySQL Stuff :)
                con = new MySqlConnection(str);
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
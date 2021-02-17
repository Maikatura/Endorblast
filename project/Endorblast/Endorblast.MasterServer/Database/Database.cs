

using System;
using System.Collections.Generic;
using Endorblast.Lib.Network;
using Endorblast.LoginServer.Data;
using MySql.Data.MySqlClient;

namespace Endorblast.LoginServer.Login
{
    public class Database
    {
        
        private static Database instance = new Database();
        public static Database Instance => instance;
        
        
        public string ip = "localhost";
        public string database = "endorblast";
        public string user = "root";
        public string pass = "";
        
        string str = @"server=localhost;database=endorblast;userid=root;password=;";

        

        public List<DatabaseCharacter> LoadAccountCharacters(int userId)
        {
            var list = new List<DatabaseCharacter>();

            
            MySqlConnection con = null;
            MySqlDataReader reader = null;

            try
            {
                con = new MySqlConnection(str);

                con.Open();

                Console.WriteLine("MySQL DB Connected");

                string cmdText = "SELECT CharacterName, id, AccountID, HairID FROM characters WHERE id='"+ userId + "';";

                MySqlCommand cmd = new MySqlCommand(cmdText, con);


                reader = cmd.ExecuteReader();

                bool rightLoggin = false;

                while (reader.Read())
                {
                    string charaName = reader["CharacterName"].ToString();
                    int hairId = int.Parse(reader["HairID"].ToString());
                        
                    // Todo : Make so equip also shows up.
                        
                    list.Add(new DatabaseCharacter(charaName, hairId));
                }

                return list;

            }
            catch (MySqlException err)
            {
                Console.WriteLine(err);
                return null;
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
        
        
        public List<GameServerInfo> LoadServers()
        {

            MySqlConnection con = null;
            MySqlDataReader reader = null;

            try
            {
                con = new MySqlConnection(str);

                con.Open();

                Console.WriteLine("MySQL DB Connected");

                string cmdText = "SELECT ServerName, ipAddress  FROM game_servers;";

                MySqlCommand cmd = new MySqlCommand(cmdText, con);


                reader = cmd.ExecuteReader();

                var data = new List<GameServerInfo>();
                
                while (reader.Read())
                {
                    data.Add(new GameServerInfo(reader["ServerName"].ToString(), reader["ipAddress"].ToString()));
                }

                return data;

            }
            catch (MySqlException err)
            {
                Console.WriteLine(err);
                return null;
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
        }
        



    }
}
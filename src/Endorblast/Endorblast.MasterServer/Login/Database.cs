

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

        
        string str = @"server=localhost;database=gamerenginenet;userid=root;password=;";

        public Tuple<bool, int> GetLoginAccount(string username, string password)
        {
            
            MySqlConnection con = null;
            MySqlDataReader reader = null;

            try
            {
                con = new MySqlConnection(str);

                con.Open();

                Console.WriteLine("MySQL DB Connected");

                string cmdText = "SELECT * FROM users WHERE username='" + username + "';";

                MySqlCommand cmd = new MySqlCommand(cmdText, con);


                reader = cmd.ExecuteReader();

                bool rightLoggin = false;
                int userID = 0;

                while (reader.Read())
                {
                    if (BCrypt.Net.BCrypt.Verify(password, reader["password"].ToString()))
                    {
                        rightLoggin = true;
                        userID = int.Parse(reader["id"].ToString());
                    }
                }

                if (rightLoggin)
                {
                    return new Tuple<bool, int>(rightLoggin, userID);
                }
                else
                {
                    return new Tuple<bool, int>(rightLoggin, 0);
                }

            }
            catch (MySqlException err)
            {
                Console.WriteLine(err);
                return new Tuple<bool, int>(false, 0);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
            
            
        }

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

                string cmdText = "SELECT charaName, id, accountID, hairID FROM users_characters WHERE id='"+ userId + "';";

                MySqlCommand cmd = new MySqlCommand(cmdText, con);


                reader = cmd.ExecuteReader();

                bool rightLoggin = false;

                while (reader.Read())
                {
                    string charaName = reader["charaName"].ToString();
                    int hairId = int.Parse(reader["hairID"].ToString());
                        
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
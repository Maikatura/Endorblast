using System;
using System.Collections.Generic;
using Endorblast.Lib.Game.Data;
using MySql.Data.MySqlClient;

namespace Endorblast.DBase
{
    public class LoadAllServerCmd : DatabaseCmd
    {
        public List<GameServerInfo> LoadServers()
        {
            con = null;
            reader = null;

            try
            {
                con = new MySqlConnection(DBStr);

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
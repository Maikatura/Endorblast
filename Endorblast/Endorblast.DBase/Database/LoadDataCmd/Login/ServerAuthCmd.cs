using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace Endorblast.DBase
{
    public class ServerAuthCmd : DatabaseCmd
    {
        public string GetToken()
        {
            string token = "";
            
            con = null;
            reader = null;

            try
            {
                con = new MySqlConnection(DBStr);

                con.Open();

                Console.WriteLine("MySQL DB Connected");

                string cmdText = "SELECT secret FROM server_token;";

                MySqlCommand cmd = new MySqlCommand(cmdText, con);


                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    token = reader.GetString(0);
                }

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

            return token;
        }
    }
}
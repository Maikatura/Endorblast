using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndorblastServer.Server.NetCommands
{
    class Database
    {

        static string str = @"server=localhost;database=gamerenginenet;userid=root;password=;";

        public static bool RightDetails(string username, string password)
        {
            if (RightDetailsDatabase(username, password))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private static bool RightDetailsDatabase(string username, string password)
        {
            MySqlConnection con = null;
            MySqlDataReader reader = null;

            try
            {
                con = new MySqlConnection(str);

                con.Open();

                Console.WriteLine("MySQL DB Connected");

                string cmdText = "SELECT username, password FROM users;";

                MySqlCommand cmd = new MySqlCommand(cmdText, con);


                reader = cmd.ExecuteReader();

                bool rightLoggin = false;

                while (reader.Read())
                {
                    if (reader["username"].ToString().ToUpper() == username.ToUpper() &&
                        BCrypt.Net.BCrypt.Verify(password, reader["password"].ToString())
                        )
                    {
                        rightLoggin = true;
                    }
                }

                if (rightLoggin)
                {
                    return rightLoggin;
                }
                else
                {
                    return rightLoggin;
                }

            }
            catch (MySqlException err)
            {
                Console.WriteLine(err);
                return false;
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
        }



        public static int LoadCharacterData(string username)
        {
            int id = LoadCharacterDataDB(username);
            if (id == -1)
            {
                Console.WriteLine("# ERROR GETTING PLAYER ID");
            }

            return id;
        }
        private static int LoadCharacterDataDB(string username)
        {
            MySqlConnection con = null;
            MySqlDataReader reader = null;

            try
            {
                con = new MySqlConnection(str);

                con.Open();

                Console.WriteLine("MySQL DB Connected");

                string cmdText = "SELECT username, id FROM users;";

                MySqlCommand cmd = new MySqlCommand(cmdText, con);


                reader = cmd.ExecuteReader();

                int id = -1;

                while (reader.Read())
                {
                    if (reader["username"].ToString().ToUpper() == username.ToUpper())
                    {
                        id = int.Parse(reader["id"].ToString());
                    }
                }


                return id;


            }
            catch (MySqlException err)
            {
                Console.WriteLine(err);
                return -1;
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
        }



        public static List<DatabaseCharacter> LoadCharacters(int id)
        {
            List<DatabaseCharacter> allCharas = LoadDBCharacters(id);
            return allCharas;
        }

        private static List<DatabaseCharacter> LoadDBCharacters(int id)
        {
            MySqlConnection con = null;
            MySqlDataReader reader = null;

            try
            {
                con = new MySqlConnection(str);

                con.Open();

                Console.WriteLine("MySQL DB Connected");

                string cmdText = "SELECT * FROM users_characters;";

                MySqlCommand cmd = new MySqlCommand(cmdText, con);


                reader = cmd.ExecuteReader();

                List<DatabaseCharacter> characters = new List<DatabaseCharacter>();

                while (reader.Read())
                {
                    if (int.Parse(reader["id"].ToString()) == id)
                    {
                        characters.Add(new DatabaseCharacter(
                            reader["charaName"].ToString(),
                            int.Parse(reader["hairID"].ToString())
                            ));

                    }
                }

                return characters;


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

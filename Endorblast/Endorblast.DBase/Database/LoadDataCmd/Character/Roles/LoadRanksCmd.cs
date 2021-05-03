using System;
using System.Collections.Generic;
using Endorblast.Lib.Game.Utils;
using MySql.Data.MySqlClient;

namespace Endorblast.DBase
{
    public class LoadRanksCmd : DatabaseCmd
    {
        
        public static List<Role> GrabGameRoles()
        {
            var roleList = new List<Role>();
            
            con = null;
            reader = null;

            try
            {
                con = new MySqlConnection(DBStr);
                con.Open();
                
                
                // Database String && Variables
                string cmdText = "SELECT * FROM roles;";

                // Unimportant
                MySqlCommand cmd = new MySqlCommand(cmdText, con);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var roleID = reader.GetInt32(0);
                    var permRank = reader.GetInt32(1);
                    
                    var roleName = reader.GetString(2);
                    var roleTag = reader.GetString(3);

                    bool active = reader.GetInt32(4) == 1;


                    var newRole = new Role(roleID, permRank, roleName, roleTag, active);
                    
                    roleList.Add(newRole);
                }
                
                // Build Character First

                

                return roleList;
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
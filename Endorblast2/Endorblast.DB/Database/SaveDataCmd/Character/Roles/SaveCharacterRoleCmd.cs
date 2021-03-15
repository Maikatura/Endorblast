using System;
using System.Collections.Generic;
using Endorblast.Lib.Game.Utils;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.CRUD;

namespace Endorblast.DB
{
    public class SaveCharacterRoleCmd : DatabaseCmd
    {
        
        
        public void UpdateRanks(List<Role> roleList)
        {
            var allRanks = LoadRanksCmd.GrabGameRoles();


            int a = 0;
            foreach (var rank in roleList)
            {
                var item = rank;
                if (rank.OldRoleName != "")
                {
                    if (allRanks.Find(x => x.RoleName.ToUpper() == rank.OldRoleName.ToUpper()) != null)
                        UpdateRank(item);
                }
                else
                {
                    if (allRanks.Find(x => x.RoleName == item.RoleName) != null)
                        return;
                    
                    InsertRank(item);
                }

                a++;
            }
            
        }
        
        private void UpdateRank(Role role)
        {
            UpdateRank(role.OldRoleName, role.RoleName, role.RoleTag, role.PermLevel, role.Active);
        }
        
        private void InsertRank(Role role)
        {
            InsertRank(role.RoleName, role.RoleTag,  role.PermLevel, role.Active);
        }

        public void RemoveRank(Role rank)
        {
            RemoveRank(rank.OldRoleName, rank.RoleName);
        }

        private void UpdateRank(string oldRankName, string newRankName, string roleTag, int rolePermNumber, bool active)
        {
            con = null;
            reader = null;

            if (string.IsNullOrEmpty(newRankName) || string.IsNullOrEmpty(roleTag))
                return;

            try
            {
                con = new MySqlConnection(DBStr);
                con.Open();
                
                int act = 0;
                if (active)
                    act = 1;
                
                
                // Database String && Variables
                
                string cmdText = "UPDATE roles SET "+
                                 "Permission='"+rolePermNumber+"'," + 
                                 "RankName='"+newRankName+"'," + 
                                 "RankTag='"+roleTag+"'," + 
                                 "Active='"+act+"' " + 
                                 "WHERE RankName='"+ oldRankName +"'";
                

                // Unimportant
                MySqlCommand cmd = new MySqlCommand(cmdText, con);

                cmd.Parameters.AddWithValue("@perm", rolePermNumber);
                cmd.Parameters.AddWithValue("@oldRankName", oldRankName);


                cmd.ExecuteNonQuery();
               
                


                // Build Character First

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
        }
        
        private void InsertRank(string roleName, string roleTag, int rolePermNumber, bool active)
        {
            con = null;
            reader = null;

            if (string.IsNullOrEmpty(roleName) || string.IsNullOrEmpty(roleTag) || roleName == "NULL" || roleTag == "NULL")
                return;

            try
            {
                con = new MySqlConnection(DBStr);
                con.Open();
                
                
                // Database String && Variables
                string cmdText = "INSERT INTO roles (Permission, RankName, RankTag, Active) VALUES (@perm, @rankName, @rankTag, @active);";
                
                // Unimportant
                MySqlCommand cmd = new MySqlCommand(cmdText, con);
                cmd.Parameters.AddWithValue("@perm", rolePermNumber);
                cmd.Parameters.AddWithValue("@rankName", roleName);
                cmd.Parameters.AddWithValue("@rankTag", roleTag);

                if (active) 
                    cmd.Parameters.AddWithValue("@active", 1);
                else
                    cmd.Parameters.AddWithValue("@active", 0);
                
                
                cmd.ExecuteNonQuery();


                // Build Character First

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
        }
        
        private void RemoveRank(string oldRoleName, string newRankName)
        {
            con = null;
            reader = null;

            

            try
            {
                con = new MySqlConnection(DBStr);
                con.Open();

                // Database String && Variables
                string cmdText = "DELETE FROM roles WHERE ";
                if (oldRoleName != "")
                    cmdText += "RankName='" + oldRoleName + "' OR ";

                cmdText += "RankName='"+newRankName+"';";
                
                // Unimportant
                MySqlCommand cmd = new MySqlCommand(cmdText, con);
                
                cmd.ExecuteNonQuery();


                // Build Character First

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
        }
        
        
    }
}

namespace Endorblast.Lib.Game.Utils
{
    public class Role
    {
        
        
        
        private int roleID;
        private int permLevel;
        private string roleName;
        private string oldRoleName = "";
        private string roleTag;
        private bool active;
        
        
        public int RoleID
        {
            get => roleID;
            set => roleID = value;
        }
        public int PermLevel
        {
            get => permLevel;
            set => permLevel = value;
        }
        public string RoleName
        {
            get => roleName;
            set
            {
                roleName = value;
            } 
        }
        
        public string OldRoleName
        {
            get => oldRoleName;
        }
        
        public string RoleTag
        {
            get => roleTag;
            set => roleTag = value;
        }
        
        public bool Active
        {
            get => active;
            set => active = value;
        }
        

        public Role()
        {
            RoleName = "NULL";
            RoleTag = "NULL";
            oldRoleName = "";
            PermLevel = 0;
            Active = false;
        }

        public Role( int id, int permLevel, string roleName, string roleTag, bool active)
        {
            RoleID = id;
            PermLevel = permLevel;
            RoleName = roleName;
            oldRoleName = RoleName;
            RoleTag = roleTag;
            Active = active;
        }
    }
}
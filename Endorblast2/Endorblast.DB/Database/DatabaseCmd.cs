using MySql.Data.MySqlClient;

namespace Endorblast.DB
{
    public class DatabaseCmd
    {
        
        protected static MySqlConnection con = null;
        protected static MySqlDataReader reader = null;
        
        
        private static string ip = "localhost";
        private static string database = "endorblast";
        private static string user = "root";
        private static string pass = "";
        
        static string dbStr = $@"server={ip};database={database};userid={user};password={pass};";

        protected static string DBStr => dbStr;
    }
}
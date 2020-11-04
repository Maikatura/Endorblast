using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EndorblastCore.Lib;

namespace Endorblast
{
    public class EnemyManager
    {
        static EnemyManager instance = new EnemyManager();
        public static EnemyManager Instance => instance;


        public List<Player> List = new List<Player>();
    }
}

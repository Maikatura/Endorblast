using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndorblastServer
{
    public class EnemyManager
    {
        static EnemyManager instance = new EnemyManager();
        public static EnemyManager Instance => instance;
    }
}

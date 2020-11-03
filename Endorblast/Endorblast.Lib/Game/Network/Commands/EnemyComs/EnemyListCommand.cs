using Lidgren.Network;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Endorblast.Lib.Enums;

namespace Endorblast.Lib.Network
{
    class EnemyListCommand : NetCommand
    {

        public static event EventHandler<EnemyListEvent> Event;

        public void Read(NetIncomingMessage msg)
        {
            //var list = new List<Enemy>();
            //int count = msg.ReadInt32();
            //for (int i = 0; i < count; i++)
            //{
            //    var type = (EnemyType)msg.ReadByte();
            //    var id = msg.ReadInt32();
            //    var x = msg.ReadInt32();
            //    var y = msg.ReadInt32();
            //    //list.Add(new Enemy(type, new Vector2(x, y)));
            //}

            //Event?.Invoke(this, new EnemyListEvent(list));
        }
    }

    public class EnemyListEvent : EventArgs
    {
        public List<Enemy> list;
        public EnemyListEvent(List<Enemy> l)
        {
            list = l;
        }
    }
}




using Lidgren.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endorblast.Game.Network.Commands
{
    public class LoginStateCommand : NetCommand
    {

        static event EventHandler<LoginStateEvent> _Event;
        public static event EventHandler<LoginStateEvent> Event
        {
            add
            {
                _Event = null;
                _Event += value;
            }
            remove
            {
                _Event -= value;
            }
        }

        static List<DatabaseCharacter> chars = new List<DatabaseCharacter>();

        public static void Read(NetIncomingMessage msg)
        {
            bool test = msg.ReadBoolean();

            if (test)
            {


                int count = msg.ReadInt32();

                Console.WriteLine(count);

                for (int i = 0; i < count; i++)
                {
                    var thisChara = new DatabaseCharacter();
                    msg.ReadAllFields(thisChara);
                    chars.Add(thisChara);
                }

                GameState.LoadCharacterSelect(chars);
                

            }
            else
            {

            }

            chars.Clear();
        }
    }

    public class LoginStateEvent : EventArgs
    {

    }
}

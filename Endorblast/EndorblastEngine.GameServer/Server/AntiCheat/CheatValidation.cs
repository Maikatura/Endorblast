using System.Linq;
using Endorblast.Library;
using Microsoft.Xna.Framework;
using Nez;
using Nez.Tiled;

namespace Endorblast.GameServer.AntiCheat
{
    public class CheatValidation
    {

        public static bool valid = true;
        
        
        
        public static bool IsValidSpeed(ServerCharacter player)
        {
            /*     Check if the players speed is a valid speed else ban them for speed hacking
             */
            
            return true;
        }

        public static bool IsValidPosition(ServerCharacter player)
        {
            /*     Check so if the players position on the server is a valid position
             *     which will say if the player is flying that is not a valid position
             *     therefore ban or suspend them.
             */
            
            return true;
        }

        public static bool IsNpcAccessValid(ServerCharacter player)
        {
            /*     Check when player access a npc interface is in a valid position
             *     If the position of the npc the player access is a large distance
             *     the player is cheating and ban/suspend them for x amount of time.
             */

            return true;
        }
        
    }
}
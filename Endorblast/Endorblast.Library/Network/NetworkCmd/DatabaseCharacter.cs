using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endorblast.Library.Network
{
    public class DatabaseCharacter
    {


        public string Name;

        public int currency;

        public int hairStyle;
        public int hatId;
        public int clothId;
        public int shoeId;



        public DatabaseCharacter(string characterName, int hairId)
        {
            Name = characterName;
            hairStyle = hairId;
        }

        public DatabaseCharacter()
        {

        }
    }
}

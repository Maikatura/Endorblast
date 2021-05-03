using System.Collections;

namespace Endorblast.Library
{
    public abstract class PlayerState
    {
        public virtual IEnumerator Init()
        {
            yield break;
        }

        public virtual IEnumerator Update()
        {
            yield break;
        }
        
        public virtual IEnumerator Draw()
        {
            yield break;
        }
    }
}
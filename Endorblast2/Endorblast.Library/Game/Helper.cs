using Microsoft.Xna.Framework;
using Vector4 = System.Numerics.Vector4;

namespace Endorblast.Lib.Game
{
    public class Helper
    {


        public static Vector4 ColorToVector4(Color color)
        {
            return new Vector4(
                (float)color.R / 255.0f,
                (float)color.G / 255.0f,
                (float)color.B / 255.0f,
                (float)color.A / 255.0f);
        }
        
    }
}
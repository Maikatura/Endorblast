using System.Drawing;
using Num = System.Numerics;
using XNA = Microsoft.Xna.Framework;

namespace Endorblast.DB.ImGui
{
    public class Calc
    {
        public static byte HexToByte(char c) => (byte)"0123456789ABCDEF".IndexOf(char.ToUpper(c));
        public static Color HexToColor(string hex)
        {
            if (hex.Length >= 6)
            {
                float r = (HexToByte(hex[0]) * 16 + HexToByte(hex[1])) / 255.0f;
                float g = (HexToByte(hex[2]) * 16 + HexToByte(hex[3])) / 255.0f;
                float b = (HexToByte(hex[4]) * 16 + HexToByte(hex[5])) / 255.0f;
                return Color.FromArgb((int)r, (int)g, (int)b);
            }

            return Color.White;
        }

         public static XNA.Color XNAHexToColor(string hex)
        {
            if (hex.Length >= 6)
            {
                float r = (HexToByte(hex[0]) * 16 + HexToByte(hex[1])) / 255.0f;
                float g = (HexToByte(hex[2]) * 16 + HexToByte(hex[3])) / 255.0f;
                float b = (HexToByte(hex[4]) * 16 + HexToByte(hex[5])) / 255.0f;
                return new XNA.Color(r,g,b);
            }

            return XNA.Color.White;
        }


        public static Num.Vector4 ColorToVec4(Color color)
        {
            return new Num.Vector4(color.R / 255, color.G / 255, color.B / 255, 1f);
        }
    }
}

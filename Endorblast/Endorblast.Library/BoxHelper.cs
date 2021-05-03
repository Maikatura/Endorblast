using System;
using Microsoft.Xna.Framework;
using Nez;

namespace Endorblast.Library
{

    public enum ImageAlign
    {
        Top,
        Center,
        Bottom
    }
    
    public class BoxHelper
    {
        
        /*
         *
         * if you say 3 points then this is how its being calculated:
         *      ########## <- 1.
         *      #        #
         *      #        # <- 2.
         *      #        #
         *      ########## <- 3.
         */
        

        public static Vector2[] ReturnAmount(int width, int height, int pointPerSide, ImageAlign align = ImageAlign.Bottom)
        {
            // Dont change size you cant have just 1 point in a cube....
            // well you can but it will just be in the same space!
            if (pointPerSide <= 1)
                throw new ArgumentException("Number can't be 1 or less!", nameof(pointPerSide));
                
            
            
            int size = pointPerSide * 4;
            var points = new Vector2[size];

            switch (align)
            {
                case ImageAlign.Bottom:
                    
                    
                    
                    
                    
                    break;
            }

            return points;
        }
        
    }
}
namespace Endorblast.Lib.Game
{
    class PlayerSettings
    {
        
        
        
        public static float moveSpeed = 10f;
        public static float jumpForce = 3f;
        
        public static float gravity = 1000;
        public static float jumpHeight = 16 * 5;


        private static float slideForce = 25f;
        
        public static float SlideForce => slideForce * 30;
    }
}
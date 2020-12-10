using System;


namespace EndorblastCore.Lib
{
    public static class PathInfo
    {
        public static string spritePath = "/Sprites";
        public static string soundPath = "/Sounds";
        public static string addonsPath = "/Addons"; // TODO Fix Addons support/API to Addons support
        
    }
    
    class ContentPath
    {
        
        
        private static ContentPath instance = new ContentPath();
        public static ContentPath Instance
        {
            get { return instance; }
            private set { return; }
        }

        /*    Info:
         *     go_ => GameObject
         *     ui_ => UI Sprites
         *     sfx_ => Sound Effects
         *     mfx_ => Music
         *
         *    Cloth and Hair Info:
         *     Cloth and Hair paths is stored in their script file
         *     if you wanna change them change them in their script!
         *
         *    GameObject Info:
         *     Some objects is currently only supported with sprite with exact
         *     specifications to work fine like scale and offset to be placed right.
         *     - TODO fix to auto scale to image source width and height.
         */
        
        
        //#########################################// 
        //                Useful Paths             //
        //#########################################//   
        
        // Shortcuts
        public string clothPath = $"{PathInfo.spritePath}/Player/Clothes";
        public string hairPath = $"{PathInfo.spritePath}/Player/Hair";
        public string goPath = $"{PathInfo.spritePath}/GameObject";
        
        //#########################################// 
        //                Sprites                  //
        //#########################################//  
        
        // UI (Buttons, Panels, Checkmarks.... )
        public string ui_Panel = $"{PathInfo.spritePath}/UI/Login/UI_Panel.png";
        
        
        // INVENTORY UI (Just thing for Inventory)
        public string ui_Inventory = $"{PathInfo.spritePath}/UI/Login/UI_Inventory.png";
        
        
        
        //#########################################// 
        //                Sounds                   //
        //#########################################//
        
        // SOUND FX
        public string sfx_PlayerWalk = $"{PathInfo.soundPath}/LOL.mp3";

        
        // MUSIC
        public string mfx_MainMenu = $"{PathInfo.soundPath}/LOL.mp3";

        

    }
}
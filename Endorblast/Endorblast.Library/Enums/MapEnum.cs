namespace Endorblast.Library.Enums
{
    #region Maps
        
        public enum MapType
        {
            None,
            Town,
            Forest,
            Snowlands,
            TownPrototype,
        }
    
        public enum ObjectTypes
        {
            TallGrass,
            Portal,
            
        }
    
        public enum AreaType
        {
            Peaceful,
            PvP,
            Dungeon
        }
    
        public enum BiomeType
        {
            Snow,       // Will take damage if not enough clothes on.
            Desert,     // Will take damage if character get to hot.
            Jungle,     // Nothing special.
            Forest,     // Nothing special.
            Village,    // Safe area
            Capital     // Safe area
        }
        
    
        
        #endregion
}
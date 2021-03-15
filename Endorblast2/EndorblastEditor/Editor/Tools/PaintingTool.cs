using Endorblast.DB.Lib.TileMap;
using Endorblast.Lib;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Input;

namespace EndorblastEditor.Editor.Tools
{
    public abstract class PaintingTool
    {
        
        public Tile BrushTile { get; set; }

        public abstract bool IsValidPosition(Map map, KeyboardStateExtended keyboardState,
            TileLayer.TilePositionDetail tilePosition, CollisionLayer.CellPositionDetail cellPosition);

        public abstract void Hover(Map map, KeyboardStateExtended keyboardState, TileLayer.TilePositionDetail tilePosition,
            CollisionLayer.CellPositionDetail cellPosition);

        public abstract void Paint(Map map, KeyboardStateExtended keyboardState, TileLayer.TilePositionDetail tilePosition,
            CollisionLayer.CellPositionDetail cellPosition);

    }
}

    
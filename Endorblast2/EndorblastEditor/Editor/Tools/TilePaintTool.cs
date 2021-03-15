using System;
using Endorblast.DB.Lib.TileMap;
using Endorblast.Lib;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Input;

namespace EndorblastEditor.Editor.Tools
{
    public class TilePaintTool : PaintingTool
    {
        

        public override void Hover(Map map, KeyboardStateExtended keyboardState, TileLayer.TilePositionDetail tilePosition, CollisionLayer.CellPositionDetail cellPosition)
        {
            map.AddImmediateTile(tilePosition.Coordinates.X, tilePosition.Coordinates.Y, BrushTile);
            
        }

        public override bool IsValidPosition(Map map, KeyboardStateExtended keyboardState, TileLayer.TilePositionDetail tilePosition, CollisionLayer.CellPositionDetail cellPosition)
        {
            return tilePosition.IsValidPosition && BrushTile != null;
        }

        public override void Paint(Map map, KeyboardStateExtended keyboardState, TileLayer.TilePositionDetail tilePosition, CollisionLayer.CellPositionDetail cellPosition)
        {
            tilePosition.Tile.TileIndex = BrushTile.TileIndex;
            tilePosition.Tile.TilesetIndex = BrushTile.TilesetIndex;
            tilePosition.Tile.color = BrushTile.color;
            // tilePosition.Tile.TilesetIndex = BrushTile.TilesetIndex;
            // tilePosition.Tile.TileIndex = BrushTile.TileIndex;
        }
    }
}
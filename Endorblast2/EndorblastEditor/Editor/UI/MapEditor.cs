using System;
using Endorblast.DB.Lib.Game.TileMap.Tilesets.Tools;
using Endorblast.DB.Lib.TileMap;
using ImGuiNET;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Num = System.Numerics;

namespace EndorblastEditor.Editor.UI
{
    public class MapEditor
    {
        private bool loadTileSetEditor = false;


        private bool showTileRules = false;
        private bool showTileMap = false;
        private bool showTilePainter = false;
        
        private AutoTileTool autoTileTool;
        private TilePainter tilePainter;
        


        public MapEditor()
        {
            autoTileTool = new AutoTileTool();
            tilePainter = new TilePainter();

        }
        
        public void Main()
        {
            if (ImGuiNET.ImGui.Button("Tile Painter")) showTilePainter = !showTilePainter;
            if (ImGuiNET.ImGui.Button("Tile Rules Editor")) showTileRules = !showTileRules;
            
            
            if (showTileRules)
            {
                ImGuiNET.ImGui.SetNextWindowSize(new Num.Vector2(200, 100), ImGuiCond.FirstUseEver);
                ImGuiNET.ImGui.Begin("Tile Rule Settings", ref showTileRules);
                autoTileTool.Main();
                ImGuiNET.ImGui.End();
            }

            if (showTilePainter)
            {
                ImGuiNET.ImGui.SetNextWindowSize(new Num.Vector2(200, 100), ImGuiCond.FirstUseEver);
                ImGuiNET.ImGui.Begin("Tile Rule Settings", ref showTileRules);
                tilePainter.Main();
                ImGuiNET.ImGui.End();
            }
        }

        
        
        public void Update(GameTime gt)
        {
            TileMap.Editor.Instance.Update(gt);
        }

        public void Draw(SpriteBatch sb, GameTime gt)
        { 
            TileMap.Editor.Instance.Draw(sb);
        }
    }
}
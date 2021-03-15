using System;
using Endorblast.DB.Lib.Game.TileMap.Tilesets.Tools;
using ImGuiNET;
using Num = System.Numerics;

namespace EndorblastEditor.Editor.UI
{
    public class MapEditor
    {
        private bool loadTileSetEditor = false;


        private bool showTileRules = false;
        private AutoTileTool autoTileTool;


        public MapEditor()
        {
            autoTileTool = new AutoTileTool();
        }
        
        public void Main()
        {
            if (ImGuiNET.ImGui.Button("Tile Rules Editor")) showTileRules = !showTileRules;
            
            if (showTileRules)
            {
                ImGuiNET.ImGui.SetNextWindowSize(new Num.Vector2(200, 100), ImGuiCond.FirstUseEver);
                ImGuiNET.ImGui.Begin("Tile Rule Settings", ref showTileRules);
                autoTileTool.Main();
                ImGuiNET.ImGui.End();
            }
                
            
        }
    }
}
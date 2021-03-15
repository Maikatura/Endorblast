using System;
using System.Collections.Generic;
using Endorblast.DB.Lib.TileMap;

namespace Endorblast.DB.Lib.Game.TileMap.Tilesets.Tools
{
    public class AutoTileTool
    {
        private int tileId = 0;

        private List<Tileset> tilesets = new List<Tileset>();

        private bool[] tileRules = new bool[9];
        
        
        public void Main()
        {
            
            
            
            ImGuiNET.ImGui.Text("Tile Rules");
            for (int i = 0; i < tileRules.Length; i++)
            {
                if (i % 3 == 0)
                    ImGuiNET.ImGui.NewLine();

                ImGuiNET.ImGui.SameLine();
                ImGuiNET.ImGui.Checkbox(i.ToString(), ref tileRules[i]);
            }
            
            if (ImGuiNET.ImGui.Button("Edit Collider")) Console.WriteLine("Fix it Zyro");
            
            
        }

        void LoadTilesets()
        {
            
        } 
    }
}
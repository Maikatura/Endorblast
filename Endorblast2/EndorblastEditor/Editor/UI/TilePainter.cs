using Endorblast.DB.Lib.TileMap;
using EndorblastEditor.Editor.Tools;
using ImGuiNET;
using Microsoft.Xna.Framework;

namespace EndorblastEditor.Editor.UI
{
    public class TilePainter
    {



        public void Main()
        {

            if (ImGuiNET.ImGui.Button("Grass")) TileMap.Editor.Instance.ActivePaintingTool.BrushTile = new Tile(Color.Green);
            if (ImGuiNET.ImGui.Button("Dirt")) TileMap.Editor.Instance.ActivePaintingTool.BrushTile = new Tile(Color.Brown);
            if (ImGuiNET.ImGui.Button("Water")) TileMap.Editor.Instance.ActivePaintingTool.BrushTile = new Tile(Color.Blue);
            
            if (ImGuiNET.ImGui.Button("Remove")) TileMap.Editor.Instance.ActivePaintingTool.BrushTile = new Tile();

        }
    }
}
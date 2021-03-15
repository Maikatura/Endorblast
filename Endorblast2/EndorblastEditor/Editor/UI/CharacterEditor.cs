
using Endorblast.Lib.Game.Utils;
using ImGuiNET;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Num = System.Numerics;

namespace EndorblastEditor.Editor.UI
{
    public class CharacterEditor
    {
        private bool showRoleEditorWindow = false;

        private RoleEditor roleEditor;
        

        public CharacterEditor()
        {
            roleEditor = new RoleEditor();
        }
        
        public void Main()
        {

            if (ImGui.Button("Role Editor")) showRoleEditorWindow = !showRoleEditorWindow;
            

            if (showRoleEditorWindow)
            {
                roleEditor.Main();
            }

        }

        public void Update(GameTime gt)
        {
            
        }

        public void Draw(SpriteBatch sb, GameTime gt)
        {
            
        }

        private void PreviewTag(string tag)
        {
            
        }
    }
}
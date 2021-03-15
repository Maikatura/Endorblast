
using Endorblast.Lib.Game.Utils;
using ImGuiNET;
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

        

        private void PreviewTag(string tag)
        {
            
        }
    }
}
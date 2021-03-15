using System;
using System.Collections.Generic;
using System.Linq;
using Endorblast.DB;
using Endorblast.Lib.Game.Utils;
using EndorblastEditor.Editor.UI;
using ImGuiNET;
using Num = System.Numerics;

namespace EndorblastEditor
{
    public class RoleEditor
    {
        private ConfirmWindow removeConfirm;
        
        private List<Role> roleList;

        private int selectedRoleId = 0;
        private int oldSelectedRole = 0;

        private int bufferSize = 20;

        private string _rankNameBuffer = "";
        private string _rankTagBuffer = "";
        private int permissionLevel = 0;
        private bool rankActive = false;

        private List<char> charaToRemove = new List<char>();

        public RoleEditor()
        {
            removeConfirm = new ConfirmWindow();
            roleList = LoadRoles();
        }

        private List<Role> LoadRoles()
        {
            var list = LoadRanksCmd.GrabGameRoles();
            list = list.OrderBy(x => x.PermLevel).ToList();
            return list;
        }

        public void Main()
        {
            ImGui.SetNextWindowSize(new Num.Vector2(300, 400));
            ImGui.Begin("Rank Editor", ImGuiWindowFlags.NoResize);

            if (ImGui.Button("Reload Ranks"))
            {
                selectedRoleId = 0;
                roleList = LoadRoles();
            }
            
            ImGui.SameLine();
            if (ImGui.Button("Save Ranks"))
            {
                new SaveCharacterRoleCmd().UpdateRanks(roleList);
                roleList = LoadRoles();
            }
            
            if (ImGui.Button("Add Rank")) roleList.Add(new Role());
            ImGui.SameLine();
            
            if (ImGui.Button("Remove Rank"))
                removeConfirm.ShowConfirmWindow();
            
            removeConfirm.ConfirmBox("Delete this Rank?", "Delete", "Keep");

            if (removeConfirm.ButtonHasBeenClicked())
                if (removeConfirm.ClickValue())
                {
                    new SaveCharacterRoleCmd().RemoveRank(roleList[selectedRoleId]);
                    roleList.Remove(roleList[selectedRoleId]);
                    if (roleList.Count == selectedRoleId) selectedRoleId -= 1;
                }

            
            if (roleList != null)
            {
                

                string[] roleArray = new string[roleList.Count];
                

                for (int i = 0; i < roleList.Count; i++)
                {
                    roleArray[i] = roleList[i].RoleName;
                }
                
                ImGui.ListBox("Ranks", ref selectedRoleId, roleArray, roleList.Count);

                _rankNameBuffer = roleList[selectedRoleId].RoleName; // length = 3;
                _rankTagBuffer = roleList[selectedRoleId].RoleTag;
                permissionLevel = roleList[selectedRoleId].PermLevel;
                rankActive = roleList[selectedRoleId].Active;

                ImGui.NewLine();
                ImGui.Text("Rank Information");
                ImGui.InputText("Rank Name", ref _rankNameBuffer, (uint) bufferSize);
                ImGui.InputText("Rank Tag", ref _rankTagBuffer, (uint) bufferSize);
                ImGui.InputInt("Perm Level", ref permissionLevel);
                ImGui.Checkbox("Active", ref rankActive);

                roleList[selectedRoleId].RoleName = _rankNameBuffer;
                roleList[selectedRoleId].RoleTag = _rankTagBuffer;
                roleList[selectedRoleId].PermLevel = permissionLevel;
                roleList[selectedRoleId].Active = rankActive;

                ImGui.NewLine();
                ImGui.Text("Tag Preview:");
                ImGui.Text($"[{roleList[selectedRoleId].RoleTag}] Zyro: Hello World!");
                

                oldSelectedRole = selectedRoleId;
            }


            ImGuiNET.ImGui.End();
        }
    }
}
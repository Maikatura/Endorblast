using System;
using System.Collections.Generic;
using Endorblast.DB;
using Endorblast.Lib.Game.Utils;
using ImGuiNET;
using Num = System.Numerics;

namespace EndorblastEditor.Editor.UI
{
    public class ConfirmWindow
    {
        private bool clickResult = false;
        public bool ShowThis = false;
        private bool buttonClicked = false;

        public void ConfirmBox(string confirmInfo = "This is not set so set it to something", string yesText = "Yes", string noText = "No")
        {
            if (!ShowThis)
                return; 
            
            ImGui.Begin("Confirm Box");
            
            ImGui.TextWrapped(confirmInfo);
            
            ImGui.NewLine();
            if (ImGui.Button(yesText))
            {
                buttonClicked = true;
                clickResult = true;
            }
            ImGui.SameLine();
            if (ImGui.Button(noText))
            {
                buttonClicked = true;
                clickResult = false;
            }
            
            ImGui.End();
        }

        public bool ClickValue()
        {
            buttonClicked = false;
            ShowThis = false;
            
            return clickResult;
        }

        public bool ButtonHasBeenClicked()
        {
            return buttonClicked;
        }

        public void ShowConfirmWindow()
        {
            ShowThis = true;
        }
        
    }
}
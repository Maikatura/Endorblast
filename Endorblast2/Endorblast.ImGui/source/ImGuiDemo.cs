using System;
using ImGuiNET;
using Num = System.Numerics;

namespace Endorblast.DB.ImGui
{
    public class ImGuiDemo 
    {
        private IntPtr _imGuiTexture;
        public ImGuiDemo(IntPtr imGuiTexture)
        {
            this._imGuiTexture = imGuiTexture;
        }
        private float f = 0.0f;
        private bool show_test_window = false;
        private bool show_another_window = false;
        private Num.Vector3 clear_color = new Num.Vector3(114f / 255f, 144f / 255f, 154f / 255f);
        private byte[] _textBuffer = new byte[100];
        public void Main()
        {
            // 1.Show a simple window
            // Tip: if we don't call ImGui.Begin()/ImGui.End() the widgets appears in a window automatically called "Debug"
            {
                ImGuiNET.ImGui.Text("Hello, world!");
                ImGuiNET.ImGui.SliderFloat("float", ref f, 0.0f, 1.0f, string.Empty);
                ImGuiNET.ImGui.ColorEdit3("clear color", ref clear_color);
                if (ImGuiNET.ImGui.Button("Test Window")) show_test_window = !show_test_window;
                if (ImGuiNET.ImGui.Button("Another Window")) show_another_window = !show_another_window;
                ImGuiNET.ImGui.Text(string.Format("Application average {0:F3} ms/frame ({1:F1} FPS)", 1000f / ImGuiNET.ImGui.GetIO().Framerate, ImGuiNET.ImGui.GetIO().Framerate));

                ImGuiNET.ImGui.InputText("Text input", _textBuffer, 100);

                
                ImGuiNET.ImGui.Text("Texture sample");
                ImGuiNET.ImGui.Image(_imGuiTexture, new Num.Vector2(300, 150), Num.Vector2.Zero, Num.Vector2.One, Num.Vector4.One, Num.Vector4.One); // Here, the previously loaded texture is used
            }

            // 2. Show another simple window, this time using an explicit Begin/End pair
            if (show_another_window)
            {
                ImGuiNET.ImGui.SetNextWindowSize(new Num.Vector2(200, 100), ImGuiCond.FirstUseEver);
                ImGuiNET.ImGui.Begin("Another Window", ref show_another_window);
                ImGuiNET.ImGui.Text("Hello");
                ImGuiNET.ImGui.End();
            }

            // 3. Show the ImGui test window. Most of the sample code is in ImGui.ShowTestWindow()
            if (show_test_window)
            {
                ImGuiNET.ImGui.SetNextWindowPos(new Num.Vector2(650, 20), ImGuiCond.FirstUseEver);
                ImGuiNET.ImGui.ShowDemoWindow(ref show_test_window);
            }
        }
    }
}

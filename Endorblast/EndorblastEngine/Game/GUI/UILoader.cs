using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Nez;
using Nez.UI;

namespace Endorblast.Library.GUI
{
    public class UILoader
    {
        public static Skin skin;


        public void Init()
        {
            var skin = new Skin();


            skin.AddSprites(Core.Content.LoadSpriteAtlas("Content/Textures/Misc/UI/UI1"));

         
            skin.Add("button", new ButtonStyle(skin.GetDrawable("default-round"),
                skin.GetDrawable("default-round-down"), null));

            skin.Add("toggle-button", new ButtonStyle(skin.GetDrawable("default-round-down"),
                skin.GetDrawable("default-round-down"), null)
                {
                    Checked = skin.GetDrawable("default-round")
                });

            skin.Add("text-button", new TextButtonStyle
            {
                Down = skin.GetDrawable("default-round-down"),
                Up = skin.GetDrawable("default-round"),
                FontColor = Color.White
            });

            skin.Add("progressbar-h", new ProgressBarStyle(skin.GetDrawable("default-slider"), 
                    skin.GetDrawable("default-slider-knob")));

            skin.Add("slider-h", new SliderStyle(skin.GetDrawable("default-slider"),
                skin.GetDrawable("default-slider-knob")));

            skin.Add("checkbox", new CheckBoxStyle(skin.GetDrawable("check-off"), 
                skin.GetDrawable("check-on"), null, Color.White));

            skin.Add("textfield", new TextFieldStyle(null, Color.White,
                skin.GetDrawable("cursor"), skin.GetDrawable("selection"),
                skin.GetDrawable("textfield")));
        }
    }
}
using Microsoft.Xna.Framework;
using Nez;

namespace Endorblast.Library
{
    public class PlayerName : Component
    {
        public string Name;
        public int Level;

        private TextComponent textComponent;
        
        public PlayerName(string username, int playerLevel)
        {
            Name = username;
            Level = playerLevel;
        }

        public override void OnAddedToEntity()
        {
            base.OnAddedToEntity();
            
            textComponent = Entity.AddComponent<TextComponent>();
            
            textComponent.SetVerticalAlign(VerticalAlign.Center);
            textComponent.SetHorizontalAlign(HorizontalAlign.Center);
            textComponent.RenderLayer = (int)RenderLayers.Layer.MainPlayer;
            textComponent.SetLocalOffset(new Vector2(0, -32));
            
            
            textComponent.Text = string.Format("Lv.{0} {1}", Level, Name);
        }

        


        public void Update()
        {
            
        }
    }
}
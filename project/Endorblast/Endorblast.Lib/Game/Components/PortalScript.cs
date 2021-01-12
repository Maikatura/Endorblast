using Endorblast.Lib.Network;
using Microsoft.Xna.Framework;
using Nez;

namespace Endorblast.Lib.Components
{
    public class PortalScript : Component
    {
        public int portalDestination = 0;
        private TextComponent text;
        private bool initedText = false;

        public bool InitedText
        {
            get
            {
                return initedText;
            }
            set
            {
                initedText = value;
            }
        }

        public PortalScript(int worldId = 0)
        {
            portalDestination = worldId;
        }

        public void EnterPortal()
        {
            new WorldCharacterChangeCommand().Send();
        }

        public void EnterText()
        {
            InitedText = true;
            text = Entity.AddComponent(new TextComponent());
            text.SetLocalOffset(new Vector2(0, -60f));
            text.SetText("Press 'E' to Enter\n123456789");
            text.SetRenderLayer(RenderLayers.FrontObjectLayer);
        }

        public void ExitText()
        {
            InitedText = false;
            text.RemoveComponent();
            text = null;
        }
        
    }
}
using EndorblastCore.Lib.Components;
using EndorblastCore.Lib.Game.Network.Commands;
using EndorblastCore.Lib.Network;
using Nez;
using Nez.Sprites;

namespace EndorblastCore.Lib.GameObjects
{
    public class Portal : Entity
    {
        private string spritePath = "/Enviorment/Portals/Portal1.png";
        
        private int portalWorldId;

        private PortalScript portalScript;

        public Portal(int worldId = 0)
        {
            portalWorldId = worldId;
        }
        
        
        public void EnterPortal()
        {
            new WorldCharacterChangeCommand().Send();
        }
        
        
        public override void OnAddedToScene()
        {
            
            
            var spriteRenderer = this.AddComponent(new SpriteRenderer());
            spriteRenderer.SetSprite(ContentLoader.LoadSprite((spritePath)));
            spriteRenderer.SetRenderLayer(RenderLayers.ObjectLayer);

            
            portalScript = this.AddComponent(new PortalScript(portalWorldId));

            this.AddComponent(new BoxCollider(64, 64));
        }
    }
}
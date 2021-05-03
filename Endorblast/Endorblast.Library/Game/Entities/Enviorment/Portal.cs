using Endorblast.Library.Game.Network.Commands;
using Endorblast.Library.Components;
using Endorblast.Library.Network;
using Nez;
using Nez.Sprites;

namespace Endorblast.Library.GameObjects
{
    public class Portal : Entity
    {
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
            spriteRenderer.SetSprite(ContentLoader.LoadSprite($"{ContentPath.Instance.goPath}/Portal/Portal1.png"));
            spriteRenderer.SetRenderLayer(RenderLayers.ObjectLayer);

            
            portalScript = this.AddComponent(new PortalScript(portalWorldId));

            this.AddComponent(new BoxCollider(64, 64));
        }
    }
}
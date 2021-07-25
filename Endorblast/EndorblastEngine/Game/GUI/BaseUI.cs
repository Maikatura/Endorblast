using Nez;
using Nez.UI;

namespace Endorblast.Library.GUI
{
    public class BaseUI
    {
        protected Stage stage;
        protected Table table;
        protected UICanvas canvas;
        
        protected Entity uiEntity;


        public BaseUI()
        {
            uiEntity = Core.Scene.CreateEntity("LoginMenu");
            canvas = uiEntity.AddComponent(new UICanvas());
            canvas.SetRenderLayer((int)RenderLayers.Layer.UILayerMin);
            
            table = canvas.Stage.AddElement(new Table());
            
            table.SetFillParent(true);
        }

        protected void Init()
        {
            
        }
    }
}
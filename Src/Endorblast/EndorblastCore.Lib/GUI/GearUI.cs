using Nez;
using Nez.Textures;
using Nez.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace EndorblastCore.Lib.GUI
{
    class GearUI
    {

        public static GearUI Instance { get; } = new GearUI();
        bool isOpenOrClosed = false;

        UICanvas canvas;
        Table gearUI;

        Entity canvasEntity;


        public void Init(Scene scene)
        {
            canvasEntity = new Entity("Gear-UI");
            canvas = canvasEntity.AddComponent(new UICanvas());
            canvas.SetRenderLayer(RenderLayers.UILayer1);
            gearUI = canvas.Stage.AddElement(new Table());
            gearUI.SetFillParent(true);


            Sprite panelSprite = ContentLoader.LoadSprite(ContentPath.Instance.ui_Inventory);
            Image panelImage = new Image(panelSprite);

            

            gearUI.Left();
            gearUI.Add(panelImage).Width(250).Height(400).SetPadLeft(20);


            canvasEntity.SetEnabled(isOpenOrClosed);
            scene.AddEntity(canvasEntity);
        }


        public void OpenAndClose()
        {
            isOpenOrClosed = !isOpenOrClosed;
            canvasEntity.SetEnabled(isOpenOrClosed);
        }

    }
}

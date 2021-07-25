using Nez;
using Nez.UI;

namespace Endorblast.Library.GUI
{
    public class InfoBox : BaseUI
    {
        private Entity infoBoxEntity;
        
        public void CreateInfoBox()
        {
            Init();

            table.Add(new Label("LOL"));

        }

        private void Close()
        {
            infoBoxEntity.Destroy();
        }
    }
}
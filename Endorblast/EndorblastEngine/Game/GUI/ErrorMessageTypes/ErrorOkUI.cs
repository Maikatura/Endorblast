
using System;
using Microsoft.VisualBasic.FileIO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Nez;
using Nez.Textures;
using Nez.UI;
using IDrawable = Nez.UI.IDrawable;

namespace Endorblast.Library.GUI.ErrorMessageTypes
{
    public class ErrorOkUI : BaseUI
    {
        private Label errorMessageText;
        private ImageTextButton submitOrOkButton;
        private Stack stackItems;


        private string labelSpritePath = "Content/Spritesheets/UI/Buttons/Button1.png";
        private string buttonSpritePath = "Content/Spritesheets/UI/Buttons/Button3.png";
        
        
        public void ShowError(string errorMessage, string confirmMessage = "Ok")
        {

            var labelSprite = ContentLoader.LoadSprite(labelSpritePath);
            var buttonSprite = ContentLoader.LoadSprite(buttonSpritePath);
            
            Image labelImage = new Image(labelSprite);
            IDrawable buttonImage = new SpriteDrawable(buttonSprite);

            int scale = 4;
            labelImage.SetScale(scale);
            
            
            var labelSpriteWidth = scale * labelSprite.Texture2D.Width;
            var labelSpriteHeight = scale * labelSprite.Texture2D.Height;
            
            var buttonSpriteWidth = scale * buttonSprite.Texture2D.Width;
            var buttonSpriteHeight = scale * buttonSprite.Texture2D.Height;
            
            

            errorMessageText = new Label(errorMessage);
            errorMessageText.SetFontScale(2, 2);
            errorMessageText.SetAlignment(Align.Center);
            errorMessageText.SetFontColor(Color.Black);
            errorMessageText.SetWrap(true);

            ImageTextButtonStyle style = new ImageTextButtonStyle(buttonImage, buttonImage, buttonImage, null);

            submitOrOkButton = new ImageTextButton(confirmMessage, style);
            submitOrOkButton.GetLabel().SetFontScale(2, 2);
            submitOrOkButton.GetStyle().FontColor = Color.Black;
            submitOrOkButton.OnClicked += button => uiEntity.Destroy();

            stackItems = new Stack();
            stackItems.Add(labelImage).ToBack();
            stackItems.Add(errorMessageText).ToFront();
            
            table.Add(stackItems).Width(labelSpriteWidth).Height(labelSpriteHeight).Fill();
            table.Row();
            table.Add(submitOrOkButton).Width(buttonSpriteWidth).Height(buttonSpriteHeight).Fill();
            
        }
    }
}
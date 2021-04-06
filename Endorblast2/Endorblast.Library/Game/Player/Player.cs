using Endorblast.Lib.Game.Data;
using Endorblast.Lib.Game.Objects;
using Endorblast.Lib.Game.Renderer;
using Endorblast.Lib.Game.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Endorblast.Lib.Game.Player
{
    public class Player
    {

        public CharacterInformation charaInfo;
        public Currency currency;
        public Stats stats;
        public Role rank;

        public SpriteAnimator renderer;


        public Player()
        {
            
            PlayerInit();
        }

        public void PlayerInit()
        {
            charaInfo = new CharacterInformation();
            currency = new Currency();
            stats = new Stats();
            rank = new Role();

            renderer = new SpriteAnimator();
            renderer.AddAnimation("Idle", SpriteAnimation.MakeAnimation("Content/Player/chara.png", 64,64, 10));
        }

        public void Insert(Player newPlayer)
        {
            this.currency = newPlayer.currency;
            this.rank = newPlayer.rank;
            this.renderer = newPlayer.renderer;
            this.stats = newPlayer.stats;
            this.charaInfo = newPlayer.charaInfo;
        }

        public void Update(float gt)
        {
            renderer.Update(gt);
        }

        public void Draw(SpriteBatch sb, float gt)
        {
            sb.Begin(SpriteSortMode.BackToFront, null, SamplerState.PointClamp);
            
            
            renderer.Draw(sb, gt, new Vector2(1,1), new Vector2(1,1), 0);
            
            
            sb.End();
        }

    }
}
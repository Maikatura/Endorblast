using Endorblast.Lib.TileMap;
using Microsoft.Xna.Framework.Graphics;

namespace Endorblast.Lib.Game.Components
{
    internal abstract class Component
    {


        protected IComponentOwner Owner;
        public bool IsActive { get; protected set; }

        public Component(IComponentOwner owner)
        {
            Owner = owner;
        }

        // public virtual void LoadContent();
        public abstract void Update(float dt);
        public abstract void Draw(SpriteBatch sb);

    }
}
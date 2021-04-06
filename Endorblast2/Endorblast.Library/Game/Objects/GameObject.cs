using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Xml;
using Endorblast.Lib.Game.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Component = Endorblast.Lib.Game.Components.Component;

namespace Endorblast.Lib.Game.Objects
{
    internal class GameObject : IComponentOwner
    {
    
        private readonly IList<Component> components;
        public string Id { get; }

        public GameObject(string id)
        {
            Id = id;
        }

        public GameObject(string id, IList<Component> components)
        {
            this.components = components;
            Id = id;
        }

        public T GetComponent<T>() where T : Component
        {
            var component = components.FirstOrDefault((c => c.GetType() == typeof(T)));
            return (T) component;
        }

        public void Remove(Component component)
        {
            if (components.Contains(component))
                components.Remove(component);
        }


        public void Update(float dt)
        {
            int index = 0;
            while (index < components.Count)
            {
                if (!components[index].IsActive)
                {
                    components.RemoveAt(index);
                }
                else
                {
                    components[index].Update(dt);
                    index++;
                }
            }
        }

        public void Draw(SpriteBatch sb)
        {
            foreach (var comp in components)
            {
                comp.Draw(sb);
            }
        }
    }
}
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Nez.Systems;
using Nez.Textures;
using Microsoft.Xna.Framework.Graphics;

namespace Nez
{
    public class SceneHeadless
    {
        
	    

		/// <summary>
		/// The list of entities within this Scene
		/// </summary>
		public readonly EntityList Entities;

		


		

		internal readonly FastList<SceneComponent> _sceneComponents = new FastList<SceneComponent>();
		bool _didSceneBegin;
		

		#region Scene creation helpers

		

		/// <summary>
		/// helper that creates a scene with no Renderer
		/// </summary>
		/// <returns>The with default renderer.</returns>
		[Obsolete("use new SceneHeadless() instead")]
		public static SceneHeadless Create()
		{
			var scene = new SceneHeadless();
			return scene;
		}

		

		#endregion


		public SceneHeadless()
		{
			Entities = new EntityList(this);
			
			Initialize(); // Init Scene
			Physics.Reset();
			_didSceneBegin = true;
			OnStart(); // Run Startup stuff
		}


		#region Scene lifecycle

		/// <summary>
		/// override this in Scene subclasses and do your loading here. This is called from the contructor after the scene sets itself up but
		/// before begin is ever called.
		/// </summary>
		public virtual void Initialize()
		{
		}

		/// <summary>
		/// override this in Scene subclasses. this will be called when Core sets this scene as the active scene.
		/// </summary>
		public virtual void OnStart()
		{
		}

		/// <summary>
		/// override this in Scene subclasses and do any unloading necessary here. this is called when Core removes this scene from the active slot.
		/// </summary>
		public virtual void Unload()
		{
		}

		internal void Begin()
		{
			Physics.Reset();
			
			_didSceneBegin = true;
			OnStart();
		}

		internal void End()
		{
			_didSceneBegin = false;

			// we kill Renderers and PostProcessors first since they rely on Entities

			// now we can remove the Entities and finally the SceneComponents
			
			Entities.RemoveAllEntities();

			for (var i = 0; i < _sceneComponents.Length; i++)
				_sceneComponents.Buffer[i].OnRemovedFromScene();
			_sceneComponents.Clear();
			
			Physics.Clear();

			Unload();
		}

		public virtual void Update()
		{
			// update our lists in case they have any changes then update our Entities
			Entities.UpdateLists();
			Entities.Update();
		}
		
		#endregion

		
		


		#region Entity Management

		/// <summary>
		/// add the Entity to this Scene, and return it
		/// </summary>
		/// <returns></returns>
		public Entity CreateEntity(string name)
		{
			var entity = new Entity(name);
			return AddEntity(entity);
		}

		/// <summary>
		/// add the Entity to this Scene at position, and return it
		/// </summary>
		/// <returns>The entity.</returns>
		/// <param name="name">Name.</param>
		/// <param name="position">Position.</param>
		public Entity CreateEntity(string name, Vector2 position)
		{
			var entity = new Entity(name);
			entity.Transform.Position = position;
			return AddEntity(entity);
		}

		/// <summary>
		/// adds an Entity to the Scene's Entities list
		/// </summary>
		/// <param name="entity">The Entity to add</param>
		public Entity AddEntity(Entity entity)
		{
			Insist.IsFalse(Entities.Contains(entity), "You are attempting to add the same entity to a scene twice: {0}", entity);
			Entities.Add(entity);
			entity.SceneHeadless = this;

			for (var i = 0; i < entity.Transform.ChildCount; i++)
				AddEntity(entity.Transform.GetChild(i).Entity);

			return entity;
		}

		/// <summary>
		/// adds an Entity to the Scene's Entities list
		/// </summary>
		/// <param name="entity">The Entity to add</param>
		public T AddEntity<T>(T entity) where T : Entity
		{
			Insist.IsFalse(Entities.Contains(entity), "You are attempting to add the same entity to a scene twice: {0}", entity);
			Entities.Add(entity);
			entity.SceneHeadless = this;
			return entity;
		}

		/// <summary>
		/// removes all entities from the scene
		/// </summary>
		public void DestroyAllEntities()
		{
			for (var i = 0; i < Entities.Count; i++)
				Entities[i].Destroy();
		}

		/// <summary>
		/// searches for and returns the first Entity with name
		/// </summary>
		/// <returns>The entity.</returns>
		/// <param name="name">Name.</param>
		public Entity FindEntity(string name) => Entities.FindEntity(name);

		/// <summary>
		/// returns all entities with the given tag
		/// </summary>
		/// <returns>The entities by tag.</returns>
		/// <param name="tag">Tag.</param>
		public List<Entity> FindEntitiesWithTag(int tag) => Entities.EntitiesWithTag(tag);

		/// <summary>
		/// returns all entities of Type T
		/// </summary>
		/// <returns>The of type.</returns>
		/// <typeparam name="T">The 1st type parameter.</typeparam>
		public List<T> EntitiesOfType<T>() where T : Entity => Entities.EntitiesOfType<T>();

		/// <summary>
		/// returns the first enabled loaded component of Type T
		/// </summary>
		/// <returns>The component of type.</returns>
		/// <typeparam name="T">The 1st type parameter.</typeparam>
		public T FindComponentOfType<T>() where T : Component => Entities.FindComponentOfType<T>();

		/// <summary>
		/// returns a list of all enabled loaded components of Type T
		/// </summary>
		/// <returns>The components of type.</returns>
		/// <typeparam name="T">The 1st type parameter.</typeparam>
		public List<T> FindComponentsOfType<T>() where T : Component => Entities.FindComponentsOfType<T>();

		#endregion

	}
}
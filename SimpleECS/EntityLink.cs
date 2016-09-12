using UnityEngine;
using System.Collections;
using ECS.Internal;

namespace ECS
{
	// used to link unity gameobjects into Simple ECS
	public class EntityLink : MonoBehaviour 
	{
		Entity _entity;
		public Entity entity
		{
			get
			{
				if (_entity == null)
					_entity = Entity.Create();
				return _entity;
			}
		}

		public void SetEntity(Entity e)
		{
			_entity = e;
		}

		/// <summary>
		/// Sets up components attached to Entity
		/// </summary>
		public virtual void SetUpComponents()
		{}
	}

}
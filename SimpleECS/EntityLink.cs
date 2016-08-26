using UnityEngine;
using System.Collections;
using ECS.Internal;

namespace ECS
{
	// used to link unity gameobjects into Simple ECS
	public class EntityLink : MonoBehaviour 
	{
		//[SerializeField]
		Entity _entity;
		public Entity entity
		{
			get
			{
				if (_entity == null)
					_entity = Entity.CreateEntity();
				return _entity;
			}
		}

		public void SetEntity(Entity e)
		{
			_entity = e;
		}

		public virtual void SetUpComponents()
		{}
	}

}
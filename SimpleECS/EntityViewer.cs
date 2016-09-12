using UnityEngine;
using System.Collections;

namespace ECS
{
	public class EntityViewer : MonoBehaviour 
	{
		EntityLink link;

		public Entity entity
		{
			get
			{
				if (link == null)
					link = GetComponent<EntityLink>();
				if (link != null)
					return link.entity;
				return null;
			}
		}
	}
}
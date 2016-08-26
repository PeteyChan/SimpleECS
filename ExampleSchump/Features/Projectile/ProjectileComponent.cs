using UnityEngine;
using System.Collections;
using ECS;

public class ProjectileComponent : EntityComponent 
{
	FactionComponent faction;
	public FactionComponent owner
	{
		get
		{
			if (faction == null)
				faction = entity.GetAdd<FactionComponent>();
			return faction;
		}
	}

}

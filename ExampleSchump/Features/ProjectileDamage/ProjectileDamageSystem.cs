using UnityEngine;
using System.Collections;
using ECS;

public class ProjectileDamageSystem : EntitySystem
{
	public override void SetGroups ()
	{
		enabled = false;
	}

	public override void OnEnable ()
	{
		CustomEvent.AddListener<CollisionEvent>(OnCollision);
	}

	public override void OnDisable ()
	{
		CustomEvent.RemoveListener<CollisionEvent>(OnCollision);
	}


	void OnCollision(CollisionEvent args)
	{
		FactionComponent senderFaction = args.sender.Get<FactionComponent>();
		FactionComponent recieverFaction = args.reciever.Get<FactionComponent>();

		if (senderFaction == null || recieverFaction == null)
		{
			return;
		}
		else
		{
			if (senderFaction.faction != recieverFaction.faction)
			{
				if (recieverFaction.faction != Faction.player)
				{
					CustomEvent.Invoke(new UpdateScoreEvent(1));
					args.reciever.Destroy();
				}
				else
					CustomEvent.Invoke(new UpdateScoreEvent(-5));
			}
		}
	}


}

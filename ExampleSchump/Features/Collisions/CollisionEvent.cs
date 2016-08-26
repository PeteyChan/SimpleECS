using UnityEngine;
using System.Collections;
using ECS;

public class CollisionEvent : IEvent 
{
	public CollisionEvent
	(Entity Sender, Collision CollisionData, Entity Reciever)
	{
		sender = Sender;
		collision = CollisionData;
		reciever = Reciever;
	}

	public Entity sender;
	public Collision collision;
	public Entity reciever;
}

using UnityEngine;
using System.Collections;
using ECS;

public enum Faction {world, player, enemy};

[System.Serializable]
public class FactionComponent : EntityComponent 
{
	public Faction faction = Faction.world;
}

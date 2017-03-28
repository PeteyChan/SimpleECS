using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[AddComponentMenu("EntityComponent/FactionComponent")]
public class FactionComponent : EntityComponent<FactionComponent>
{
	public Faction faction;
}

public enum Faction
{
	Player, Enemy
}
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[AddComponentMenu("EntityComponent/HealthComponent")]
public class HealthComponent : EntityComponent<HealthComponent>
{
	public int CurrentHealth = 5;
	public int MaxHealth = 5;
}

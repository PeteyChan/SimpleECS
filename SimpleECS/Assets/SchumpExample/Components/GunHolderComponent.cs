using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[AddComponentMenu("EntityComponent/GunHolderComponent")]
public class GunHolderComponent : EntityComponent<GunHolderComponent>
{
	public List<GunComponent> Guns;
}

using UnityEngine;
using System.Collections;
using ECS;

public class SystemInterface : MonoBehaviour 
{
	public EntitySystemManager manager = new EntitySystemManager();
	// Use this for initialization
	void Start () 
	{
		manager
			.Add(new ViewSystem())				// handles adding and removing views
			.Add(new MoveSystem())				// adds move vector to position

			.Add(new SpawnPlayerSystem())
			.Add("Input", new MoveInputSystem())		// updates move via input
			.Add("Input", new PlayerShootSystem())		// allows the player to shoot via input

			.Add(new EulerBankSystem())

			.Add(new SpawnEnemySystem())		// spawns enemies every 2 seconds
			.Add(new MoveEnemyLeftSystem())		// moves enemy left
			.Add(new EnemyShootSystem())

			.Add(new ProjectileBoundsSystem())	// destroys projectiles that exceed bounds
			.Add(new ProjectileDamageSystem())	// projectiles can damage

			.Add(new ShootBulletSystem())		// shoots bullets
			.Add(new PlayerBoundsSystem())		// stops player from going out of bounds
			.Add(new UpdatePositionSystem())	// updates view position to position
			.Add(new UpdateEulerAnglesSystem())

			.Add("Debug", new EntityViewerSystem())
			;
	}
	
	// Update is called once per frame
	void Update () 
	{
		manager.Update();
	}
}
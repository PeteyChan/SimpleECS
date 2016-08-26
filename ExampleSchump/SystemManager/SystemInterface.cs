using UnityEngine;
using System.Collections;
using ECS;

public class SystemInterface : MonoBehaviour 
{
	public EntitySystemManager Manager;

	// Use this for initialization
	void Start () 
	{
		Manager = new EntitySystemManager();

		Manager
			.Add(new ViewSystem())				// handles adding and removing views
			.Add(new MoveSystem())				// adds move vector to position

			.Add(new SpawnPlayerSystem())
			.Add(new MoveInputSystem())			// updates move via input
			.Add(new PlayerShootSystem())		// allows the player to shoot via input

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
			;
		
		Manager.Start();
	}
	
	// Update is called once per frame
	void Update () 
	{
		
		Manager.Update();
	}
}


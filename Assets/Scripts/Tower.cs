using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
	/** Parameter */
	[SerializeField] Transform	TurretTop;
	[SerializeField] float		Range = 20.0f;
	[SerializeField] GameObject	Bullet;
	[SerializeField] public Waypoint	BaseWaypoint;

	/** State */
	Transform	Enemy;

	// Update is called once per frame
	void	Update()
	{
		SetTargetEnemy();
		if (Enemy)
		{
			if (CalculateDistance() < Range)
			{
				TurretTop.LookAt(Enemy);
				Shoot(true);
			}
			else
			{
				Shoot(false);
			}
		}
		else
		{
			Shoot(false);
		}
	}

	float	CalculateDistance()
	{
		float Distance = Vector3.Distance(TurretTop.position, Enemy.position);
		return Distance;
	}

	void	Shoot(bool b_IsActive)
	{
		var EmissionModule = Bullet.GetComponent<ParticleSystem>().emission;
		EmissionModule.enabled = b_IsActive;
	}

	void	SetTargetEnemy()
	{
		var SceneEnemies = FindObjectsOfType<Enemy>();
		if (SceneEnemies.Length == 0) { return; }
		Transform ClosestEnemy = SceneEnemies[0].transform;
		foreach (Enemy TestEnemy in SceneEnemies)
		{
			ClosestEnemy = GetClosestEnemy(ClosestEnemy, TestEnemy.transform);
		}
		Enemy = ClosestEnemy;
	}

	Transform	GetClosestEnemy(Transform Transform_A, Transform Transform_B)
	{
		var DistToA = Vector3.Distance(gameObject.transform.position, Transform_A.position);
		var DistToB = Vector3.Distance(gameObject.transform.position, Transform_B.position);
		if (DistToA < DistToB)
		{
			return Transform_A;
		}
		else
		{
			return Transform_B;
		}
	}
}

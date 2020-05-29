using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
	[SerializeField] Transform	TurretTop;
	[SerializeField] Transform	Enemy;
	[SerializeField] float		Range = 20.0f;
	[SerializeField] GameObject	Bullet;

	// Update is called once per frame
	void	Update()
	{
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
}

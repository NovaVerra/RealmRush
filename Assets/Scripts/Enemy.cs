using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	[SerializeField] int	HitPoint = 25;

	void	OnParticleCollision(GameObject CollisionObject)
	{
		Hit();
	}

	void	Hit()
	{
		if (HitPoint > 0)
		{
			HitPoint--;
		}
		else
		{
			Destroy(gameObject);
		}
	}
}

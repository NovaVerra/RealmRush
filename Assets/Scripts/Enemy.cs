using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	[SerializeField] int	HitPoint = 25;
	[SerializeField] ParticleSystem	P_OnHit;
	[SerializeField] ParticleSystem	P_OnDeath;

	void	OnParticleCollision(GameObject CollisionObject)
	{
		Hit();
	}

	void	Hit()
	{
		if (HitPoint > 0)
		{
			HitPoint--;
			P_OnHit.Play();
		}
		else
		{
			Destroy(gameObject);
			var VFX = Instantiate(P_OnDeath, transform.position, Quaternion.identity);
			VFX.Play();
		}
	}
}

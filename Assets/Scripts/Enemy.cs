using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	[SerializeField] int			HitPoint = 25;
	[SerializeField] ParticleSystem	P_OnHit;
	[SerializeField] ParticleSystem	P_OnDeath;
	[SerializeField] AudioClip		A_EnemyHit;
	[SerializeField] AudioClip		A_EnemyDeath;

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
			GetComponent<AudioSource>().PlayOneShot(A_EnemyHit);
		}
		else
		{
			var VFX = Instantiate(P_OnDeath, transform.position, Quaternion.identity);
			VFX.Play();
			Destroy(VFX.gameObject, VFX.main.duration);
			AudioSource.PlayClipAtPoint(A_EnemyDeath, Camera.main.transform.position);
			Destroy(gameObject);
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Base : MonoBehaviour
{
	[SerializeField] int		HealthPoint = 10;
	[SerializeField] Text		BaseHealth;
	[SerializeField] AudioClip	A_EnemyHitBase;

	void	Update()
	{
		BaseHealth.text = HealthPoint.ToString();
	}

	void	OnTriggerEnter(Collider CollisionObject)
	{
		if (HealthPoint > 0)
		{
			GetComponent<AudioSource>().PlayOneShot(A_EnemyHitBase);
			HealthPoint--;
		}
		else
		{
			print("Game Over!!!");
		}
	}
}

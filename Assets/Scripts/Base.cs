using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{
	[SerializeField] int	HealthPoint = 10;

	void	OnTriggerEnter(Collider CollisionObject)
	{
		if (HealthPoint > 0)
		{
			HealthPoint--;
		}
		else
		{
			print("Game Over!!!");
		}
	}
}

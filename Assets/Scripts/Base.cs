using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Base : MonoBehaviour
{
	[SerializeField] int	HealthPoint = 10;
	[SerializeField] Text	BaseHealth;

	void	Update()
	{
		BaseHealth.text = HealthPoint.ToString();
	}

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

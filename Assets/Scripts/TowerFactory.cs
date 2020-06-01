using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
	[SerializeField] Tower	TowerPrefab;
	[SerializeField] int	TowerLimit = 5;
	int						CurrentTowerCount = 0;

	public void	SpawnTower(Waypoint Waypoint)
	{
		if (CurrentTowerCount < TowerLimit)
		{
			Instantiate(TowerPrefab, Waypoint.transform.position, Quaternion.identity);
			Waypoint.b_IsPlaceable = false;
			CurrentTowerCount++;
		}
		else
		{
			print("Too many towers");
		}
	}
}

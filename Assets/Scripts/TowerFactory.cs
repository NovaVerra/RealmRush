using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
	/** Parameters */
	[SerializeField] Transform	Parent;
	[SerializeField] Tower		TowerPrefab;
	[SerializeField] int		TowerLimit = 5;

	/** State */
	Queue<Tower>			TowerQueue = new Queue<Tower>();

	public void	PlaceTower(Waypoint Waypoint)
	{
		print(TowerQueue.Count);
		if (TowerQueue.Count < TowerLimit)
		{
			InstantiateNewTower(Waypoint);
		}
		else
		{
			MoveExistingTower(Waypoint);
		}
	}

	void	InstantiateNewTower(Waypoint Waypoint)
	{
		// Instantiate and Queue new towers
		var TowerInstance = Instantiate(TowerPrefab, Waypoint.transform.position, Quaternion.identity);
		TowerInstance.BaseWaypoint = Waypoint;
		TowerInstance.transform.parent = Parent;
		TowerQueue.Enqueue(TowerInstance);
		// Modify state
		Waypoint.b_IsPlaceable = false;
	}

	void	MoveExistingTower(Waypoint NewWaypoint)
	{
		var TowerToMove = TowerQueue.Dequeue();
		TowerToMove.BaseWaypoint.b_IsPlaceable = true;
		NewWaypoint.b_IsPlaceable = false;
		TowerToMove.BaseWaypoint = NewWaypoint;
		TowerToMove.transform.position = NewWaypoint.transform.position;
		TowerQueue.Enqueue(TowerToMove);
	}
}

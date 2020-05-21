using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
	/** Game State */
	bool	b_IsRunning = true;

	/** Game Config */
	Dictionary<Vector2Int, Waypoint>	WorldGrid = new Dictionary<Vector2Int, Waypoint>();
	Queue<Waypoint> 					Queue = new Queue<Waypoint>();
	[SerializeField] Waypoint 			StartWaypoint, EndWaypoint;
	Waypoint							SearchCenter;

	Vector2Int[] Directions = {
		Vector2Int.up,
		Vector2Int.right,
		Vector2Int.down,
		Vector2Int.left
	};

	/** Start is called before the first frame update */
	void	Start()
	{
		LoadBlocks();
		ColorStartEnd();
		Pathfind();
	}

	void	LoadBlocks()
	{
		var Waypoints = FindObjectsOfType<Waypoint>();
		foreach (Waypoint Waypoint in Waypoints)
		{
			/** if there are duplicates */
			if (WorldGrid.ContainsKey(Waypoint.GetGridPos()))
			{
				Debug.LogWarning("Overlapping grid: " + Waypoint.GetGridPos());
			}
			else
			{
				WorldGrid.Add(Waypoint.GetGridPos(), Waypoint);
			}
		}
	}

	void	ColorStartEnd()
	{
		StartWaypoint.SetTopColor(Color.yellow);
		EndWaypoint.SetTopColor(Color.red);
	}

	void	Pathfind()
	{
		Queue.Enqueue(StartWaypoint);
		while (Queue.Count > 0 && b_IsRunning)
		{
			SearchCenter = Queue.Dequeue();
			EndFound();
			ExploreNeighbours();
			SearchCenter.b_IsExplored = true;
		}
	}

	void	ExploreNeighbours()
	{
		foreach (Vector2Int Direction in Directions)
		{
			Vector2Int NeighbourCoordinate = SearchCenter.GetGridPos() + Direction;
			if (WorldGrid.ContainsKey(NeighbourCoordinate))
			{
				QueueNewNeighbours(NeighbourCoordinate);
			}
		}
	}

	bool	EndFound()
	{
		if (SearchCenter == EndWaypoint)
		{
			b_IsRunning = false;
			return true;
		}
		else
		{
			return false;
		}
	}

	void	QueueNewNeighbours(Vector2Int NeighbourCoordinate)
	{
		Waypoint Neighbour = WorldGrid[NeighbourCoordinate];
		if (!Neighbour.b_IsExplored || Queue.Contains(Neighbour))
		{
			Queue.Enqueue(WorldGrid[NeighbourCoordinate]);
			Neighbour.ExploredFrom = SearchCenter;
		}
	}
}

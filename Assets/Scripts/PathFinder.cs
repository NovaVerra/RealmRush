using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
	/** Game State */
	Dictionary<Vector2Int, Waypoint> WorldGrid = new Dictionary<Vector2Int, Waypoint>();
	[SerializeField]	Waypoint StartBlock, EndBlock;
	Vector2Int[] Directions = {
		Vector2Int.up,
		Vector2Int.down,
		Vector2Int.left,
		Vector2Int.right
	};

	// Start is called before the first frame update
	void	Start()
	{
		LoadBlocks();
		StartBlock.SetTopColor(Color.yellow);
		EndBlock.SetTopColor(Color.red);
		ExploreNeighbours();
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
		// print("Loaded " + WorldGrid.Count + " blocks.");
	}

	void	ExploreNeighbours()
	{
		foreach (Vector2Int Direction in Directions)
		{
			Vector2Int NeighbourCoordinate = StartBlock.GetGridPos() + Direction;
			if (WorldGrid.ContainsKey(NeighbourCoordinate))
			{
				WorldGrid[NeighbourCoordinate].SetTopColor(Color.blue);
			}
		}
	}
}

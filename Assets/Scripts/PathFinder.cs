using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
	Dictionary<Vector2Int, Waypoint> WorldGrid = new Dictionary<Vector2Int, Waypoint>();

	// Start is called before the first frame update
	void Start()
	{
		LoadBlocks();
	}

	void	LoadBlocks()
	{
		var Waypoints = FindObjectsOfType<Waypoint>();
		foreach (Waypoint Waypoint in Waypoints)
		{
			bool b_IsOverlapping = WorldGrid.ContainsKey(Waypoint.GetGridPos());
			if (b_IsOverlapping)
			{
				Debug.LogWarning("Overlapping grid: " + Waypoint.GetGridPos());
			}
			else
			{
				WorldGrid.Add(Waypoint.GetGridPos(), Waypoint);
			}
		}
		print(WorldGrid.Count);
	}

	// Update is called once per frame
	void Update()
	{
		
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
	[SerializeField] List<Waypoint>	Path;

	// Start is called before the first frame update
	void Start()
	{
		StartCoroutine(FollowPath());
	}

	IEnumerator	FollowPath()
	{
		// print("Starting Patrol...");
		foreach (Waypoint Coordinate in Path)
		{
			transform.position = Coordinate.transform.position;
			// print("Visiting block: " + Coordinate.name);
			yield return new WaitForSeconds(1.0f);
		}
		// print("Ending Patrol...");
	}
}

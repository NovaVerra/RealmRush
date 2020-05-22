using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

	// Start is called before the first frame update
	void Start()
	{
		List<Waypoint>	Path = FindObjectOfType<PathFinder>().GetPath();
		StartCoroutine(FollowPath(Path));
	}

	IEnumerator	FollowPath(List<Waypoint> Path)
	{
		foreach (Waypoint Coordinate in Path)
		{
			transform.position = Coordinate.transform.position;
			yield return new WaitForSeconds(1.0f);
		}
	}
}

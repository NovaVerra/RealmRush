using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
	[Range(0.25f, 2.0f)]
	[SerializeField] float			MoveSpeed = 1.0f;
	[SerializeField] ParticleSystem	GoalParticle;

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
			yield return new WaitForSeconds(MoveSpeed);
		}
		SelfDestruct();
	}

	void	SelfDestruct()
	{
		var VFX = Instantiate(GoalParticle, transform.position, Quaternion.identity);
		VFX.Play();
		Destroy(VFX.gameObject, VFX.main.duration);
		Destroy(gameObject);
	}
}

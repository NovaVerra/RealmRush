using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
	[SerializeField] List<Block>	Path;

	// Start is called before the first frame update
	void Start()
	{
		foreach (Block Coordinate in Path)
		{
			print(Coordinate);
		}
	}

	// Update is called once per frame
	void Update()
	{
		
	}
}

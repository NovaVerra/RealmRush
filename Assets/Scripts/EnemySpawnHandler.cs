using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnHandler : MonoBehaviour
{
	[SerializeField] GameObject	EnemyPrefab;
	[SerializeField] Transform	Parent;
	[SerializeField] float		SpawnRate = 1.0f;

	// Start is called before the first frame update
	void Start()
	{
		StartCoroutine(SpawnEnemy());
	}

	IEnumerator	SpawnEnemy()
	{
		while (true)
		{
			GameObject EnemyInstance = Instantiate(EnemyPrefab);
			EnemyInstance.transform.parent = Parent;
			yield return new WaitForSeconds(SpawnRate);
		}
	}
}

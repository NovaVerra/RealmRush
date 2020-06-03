using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawnHandler : MonoBehaviour
{
	/** Parameters */
	[SerializeField] EnemyMovement	EnemyPrefab;
	[SerializeField] Transform		Parent;
	[Range(2.0f, 10.0f)]
	[SerializeField] float			SpawnRate = 4.0f;
	int								EnemyCount = 0;
	[SerializeField] Text			EnemyCountText;

	// Start is called before the first frame update
	void Start()
	{
		StartCoroutine(SpawnEnemy());
	}

	IEnumerator	SpawnEnemy()
	{
		while (true)
		{
			EnemyCount++;
			EnemyCountText.text = EnemyCount.ToString();
			EnemyMovement EnemyInstance = Instantiate(EnemyPrefab, transform.position, Quaternion.identity);
			EnemyInstance.transform.parent = Parent;
			yield return new WaitForSeconds(SpawnRate);
		}
	}
}

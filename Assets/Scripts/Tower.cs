using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
	[SerializeField] Transform	TurretTop;
	[SerializeField] Transform	Enemy;

	// Update is called once per frame
	void Update()
	{
		TurretTop.LookAt(Enemy);
	}
}

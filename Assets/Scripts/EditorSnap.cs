using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class EditorSnap : MonoBehaviour
{
	void Update()
	{
		// Overwrites editors snap to grid setting
		Vector3 SnapPos;

		SnapPos.x = Mathf.RoundToInt(transform.position.x / 10.0f) * 10.0f;
		SnapPos.z = Mathf.RoundToInt(transform.position.z / 10.0f) * 10.0f;
		transform.position = new Vector3(SnapPos.x, 0.0f, SnapPos.z);
	}
}

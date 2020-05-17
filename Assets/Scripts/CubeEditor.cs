using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
public class CubeEditor : MonoBehaviour
{
	Vector3		SnapPos;
	TextMesh	TextMeshCoordinate;

	[SerializeField][Range(1.0f, 20.0f)]
	int		GridSize;

	void Start()
	{
		TextMeshCoordinate = GetComponentInChildren<TextMesh>();
	}

	// Overwrites editors snap to grid setting
	void Update()
	{
		SnapPos.x = Mathf.RoundToInt(transform.position.x / 10.0f) * GridSize;
		SnapPos.z = Mathf.RoundToInt(transform.position.z / 10.0f) * GridSize;
		transform.position = new Vector3(SnapPos.x, 0.0f, SnapPos.z);

		TextMeshCoordinate.text = SnapPos.x / GridSize + ", " + SnapPos.z / GridSize;
	}
}

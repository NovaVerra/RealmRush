using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
[RequireComponent(typeof(Waypoint))]
public class CubeEditor : MonoBehaviour
{
	TextMesh	TextMeshCoordinate;
	Waypoint	Waypoint;

	void	Awake()
	{
		Waypoint = GetComponent<Waypoint>();
	}

	void Start()
	{
		TextMeshCoordinate = GetComponentInChildren<TextMesh>();
	}

	// Overwrites editors snap to grid setting
	void Update()
	{
		SnapToGrid();
		UpdateLabel();
	}

	void	SnapToGrid()
	{
		int GridSize = Waypoint.GetGridSize();
		transform.position = new Vector3(
			Waypoint.GetGridPos().x,
			0.0f,
			Waypoint.GetGridPos().y
		);
	}

	void	UpdateLabel()
	{
		int GridSize = Waypoint.GetGridSize();
		string Coordinate = Waypoint.GetGridPos().x / GridSize + ", " + Waypoint.GetGridPos().y / GridSize;
		TextMeshCoordinate.text = Coordinate;
		gameObject.name = Coordinate;
	}
}

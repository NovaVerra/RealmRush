﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
	const int	GridSize = 10;
	Vector2Int	GridPos;

	public int	GetGridSize()
	{
		return GridSize;
	}

	public Vector2	GetGridPos()
	{
		return new Vector2Int(
			Mathf.RoundToInt(transform.position.x / 10.0f) * GridSize,
			Mathf.RoundToInt(transform.position.z / 10.0f) * GridSize
		);
	}
}

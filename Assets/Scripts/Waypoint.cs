using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
	public bool				b_IsExplored = false;
	public Waypoint			ExploredFrom;
	const int				GridSize = 10;
	Vector2Int				GridPos;
	[SerializeField] Color	ExploredColor = Color.blue;

	void	Update()
	{
		if (b_IsExplored)
		{
			SetTopColor(Color.blue);
		}
	}

	public int			GetGridSize()
	{
		return GridSize;
	}

	public Vector2Int	GetGridPos()
	{
		return new Vector2Int(
			Mathf.RoundToInt(transform.position.x / GridSize),
			Mathf.RoundToInt(transform.position.z / GridSize)
		);
	}

	public void			SetTopColor(Color Color)
	{
		MeshRenderer TopColor = transform.Find("Top").GetComponent<MeshRenderer>();
		TopColor.material.color = Color;
	}
}

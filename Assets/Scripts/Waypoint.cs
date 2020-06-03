using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
	const int				GridSize = 10;
	Vector2Int				GridPos;
	public bool				b_IsExplored = false;
	public bool				b_IsPlaceable = true;
	public Waypoint			ExploredFrom;
	[SerializeField] Color	ExploredColor = Color.blue;

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

	void	OnMouseOver()
	{
		if (Input.GetMouseButtonDown(0))
		{
			if (b_IsPlaceable)
			{
				FindObjectOfType<TowerFactory>().PlaceTower(this);
				b_IsPlaceable = false;
			}
			else
			{
				print("Cannot place turret here");
			}
		}
	}
}

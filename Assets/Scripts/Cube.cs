using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour {

	public GridPoint gridPoint;
	public List<Cube> neighbours = new List<Cube>();

    //call when a cube is created
	public void Setup(GridPoint gp)
	{
		gridPoint = gp;
		transform.SetParent(GameObject.Find("Board").transform);
		getNeighbours();
	}

    //find all adjacent cubes
	public void getNeighbours()
	{
		for (int i = gridPoint.x - 1; i < gridPoint.x + 2; i++)
		{
			for (int j= gridPoint.z - 1; j < gridPoint.z + 2; j++)
            {
				if (BoardManager.Instance.Cubes.ContainsKey(new GridPoint(i, j)))
				{
					neighbours.Add(BoardManager.Instance.Cubes[new GridPoint(i, j)]);
				}
            }
		}
        //add yourself to all your neighbours' lists
		foreach(Cube neighbour in neighbours)
		{
			neighbour.neighbours.Add(this);
		}
	}
}

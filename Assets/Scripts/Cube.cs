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
	}

}

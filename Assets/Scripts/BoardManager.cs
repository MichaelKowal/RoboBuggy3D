using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : Singleton<BoardManager>
{
    public int rows;
    public int columns;

    public Cube wall;
    [SerializeField]
    public Cube largeWall;
	public Cube hugeWall;
    public Dictionary<GridPoint, Cube> Cubes = new Dictionary<GridPoint, Cube>();

    //set up the board
    public void BoardSetup()
    {
        GameObject toInstantiate;

        for (int i = -1; i <= rows; i++)
        {
            for (int j = -1; j <= columns; j++)
            {
                if (i == -1 || i == rows || j == -1 || j == columns)
                {
                    //create outer wall 
                    toInstantiate = Instantiate(wall.gameObject, new Vector3(i, wall.gameObject.transform.localScale.y / 2f, j), Quaternion.identity);
                    Cubes.Add(new GridPoint(i, j), toInstantiate.GetComponent<Cube>());
                    toInstantiate.GetComponent<Cube>().Setup(new GridPoint(i, j));
                }
                if (i % 10 == 0 && j % 10 == 0)
                {
                    //create grid
                    toInstantiate = Instantiate(wall.gameObject, new Vector3(i, hugeWall.gameObject.transform.localScale.y / 2f, j), Quaternion.identity);
                    Cubes.Add(new GridPoint(i, j), toInstantiate.GetComponent<Cube>());
                    toInstantiate.GetComponent<Cube>().Setup(new GridPoint(i, j));
                }
            }
        }
    }
}

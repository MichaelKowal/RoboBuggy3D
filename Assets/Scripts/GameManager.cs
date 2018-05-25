using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager> 
{
	private BoardManager boardScript;
	[SerializeField]
	GameObject startScreen;
	float startScreenDelay = 2f;
	public int cameraSpeed = 10;

	private void Awake()
	{
		startScreen.SetActive(true);
		boardScript = GetComponent<BoardManager>();
		InitGame();
		Invoke("RemoveStart", startScreenDelay);
	}

    //very simple startup system
    void InitGame()
	{
		boardScript.BoardSetup();
	}

	//disable start screen
    void RemoveStart()
	{
		startScreen.SetActive(false);
	}
}

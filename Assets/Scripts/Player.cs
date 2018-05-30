using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour 
{
	[SerializeField]
	int baseSpeed = 10;
	int speed = 10;
	int sprint = 100;
	bool exhausted = false;
	GameObject sprintText;

	private void Start()
	{
		sprintText = GameObject.Find("SprintText");
	}

	// Update is called once per frame
	void Update ()
	{
		speed = baseSpeed;
		if (Input.GetKey("left shift") && sprint > 0 && !exhausted)
		{
			speed *= 3;
			sprint -= 2;
		}
		else if (sprint == 0 && !exhausted)
			exhausted = true;
		else if (sprint < 100)
			sprint += 1;
		else if (sprint == 100 && exhausted)
			exhausted = false;
		RaycastHit hit;
        //move forward
		if(Input.GetKey("w") && !Physics.Raycast(transform.position, transform.TransformDirection(new Vector3(0, 0, 0.25f)), out hit, 0.15f))
		{
			transform.Translate(new Vector3(0, 0, 0.25f) * Time.smoothDeltaTime * speed);
		}
        //move left
		if (Input.GetKey("a") && !Physics.Raycast(transform.position, transform.TransformDirection(new Vector3(-0.25f, 0, 0)), out hit, 0.15f))
        {
			transform.Translate(new Vector3(-0.25f, 0, 0) * Time.smoothDeltaTime * speed);
        }
        //move back
		if (Input.GetKey("s") && !Physics.Raycast(transform.position, transform.TransformDirection(new Vector3(0, 0, -0.25f)), out hit, 0.15f))
        {
			transform.Translate(new Vector3(0, 0, -0.25f) * Time.smoothDeltaTime * speed);
        }
        //move right
		if (Input.GetKey("d") && !Physics.Raycast(transform.position, transform.TransformDirection(new Vector3(0.25f, 0, 0)), out hit, 0.15f))
        {
			transform.Translate(new Vector3(0.25f, 0, 0) * Time.smoothDeltaTime * speed);
        }
        //rotate view with mouse
		if(Input.GetAxis("Horizontal") != 0)
		{
			transform.Rotate(new Vector3(0, Input.GetAxis("Horizontal"), 0));
		}
		sprintText.GetComponent<Text>().text = sprint.ToString();
	}
}

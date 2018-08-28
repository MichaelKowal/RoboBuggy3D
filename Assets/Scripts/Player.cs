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
	int power = 0;
	bool exhausted = false;
	GameObject sprintBar;
	GameObject powerBar;

	private void Start()
	{
		sprintBar = GameObject.Find("SprintBar");
		powerBar = GameObject.Find("PowerBar");
	}

	// Update is called once per frame
	void Update ()
	{
		speed = baseSpeed;
		if (Input.GetKey("left shift") && sprint > 0 && !exhausted)
		{
			speed *= 3;
			sprint -= 2;
			sprintBar.GetComponent<RectTransform>().position = new Vector3(sprintBar.GetComponent<RectTransform>().position.x,
                                                                       sprintBar.GetComponent<RectTransform>().position.y - 4,
                                                                       sprintBar.GetComponent<RectTransform>().position.z);
		}
		else if (sprint == 0 && !exhausted)
			exhausted = true;
		else if (sprint < 100)
		{
			sprint += 1;
			sprintBar.GetComponent<RectTransform>().position = new Vector3(sprintBar.GetComponent<RectTransform>().position.x,
                                                                       sprintBar.GetComponent<RectTransform>().position.y + 2,
                                                                       sprintBar.GetComponent<RectTransform>().position.z); 
		}
			
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
		sprintBar.GetComponent<RectTransform>().sizeDelta = new Vector2(30, sprint * 4);
		if(Input.GetMouseButtonDown(0) && power == 100)
		{
			power = 1;
			if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 10))
			{
				Destroy(hit.transform.gameObject, 1);
            }
		}
  	}

	private void FixedUpdate()
	{
		if (power < 100)
		{
			power += 2;
			powerBar.GetComponent<RectTransform>().sizeDelta = new Vector2(30, power * 4);
		}
	}
}



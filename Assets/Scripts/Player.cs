using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour 
{
	[SerializeField]
	int speed = 10;

	// Update is called once per frame
	void Update ()
	{
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
	}
}

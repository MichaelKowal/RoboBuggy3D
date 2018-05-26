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
		if(Input.GetKey("w") && !Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 1))
		{
			transform.Translate(Vector3.forward * Time.smoothDeltaTime * speed);
		}
        //move left
		if (Input.GetKey("a") && !Physics.Raycast(transform.position, transform.TransformDirection(Vector3.left), out hit, 1))
        {
			transform.Translate(Vector3.left * Time.smoothDeltaTime * speed);
        }
        //move back
		if (Input.GetKey("s") && !Physics.Raycast(transform.position, transform.TransformDirection(Vector3.back), out hit, 1))
        {
			transform.Translate(Vector3.back * Time.smoothDeltaTime * speed);
        }
        //move right
		if (Input.GetKey("d") && !Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), out hit, 1))
        {
			transform.Translate(Vector3.right * Time.smoothDeltaTime * speed);
        }
        //rotate view with mouse
		if(Input.GetAxis("Horizontal") != 0)
		{
			transform.Rotate(new Vector3(0, Input.GetAxis("Horizontal"), 0));
		}     
	}
}

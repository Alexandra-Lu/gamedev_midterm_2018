using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class KillMe : MonoBehaviour {
	

	public float moveSpeed = 7.5f;
	
	//this variable will remember input and pass it to physics
	Vector3 inputVector;
	void Update () {
		//get mouse input
		//these are mouse "deltas"       delta = difference (will be 0 when nothing is moving
		
		float mouseX = Input.GetAxis("Mouse X");
		float mouseY = Input.GetAxis("Mouse Y");
		
		//rotate the camera based on mouse input
		//first, rotate body based on horizontal mouse movement
		transform.Rotate( 0f, (mouseX *3), 0f);
		Camera.main.transform.Rotate((-mouseY *3), 0f, 0f);

		
		//WASD Movement
		//GetAxis usually returns a float between -1f and 1f
		//when you're not pressing anything, it returns ~of;
		float horizontal = Input.GetAxis("Horizontal"); //A/D, Left/Right
		float vertical = Input.GetAxis("Vertical");  //W/S, Up/Down
		

		inputVector = transform.forward * vertical;
		inputVector += transform.right * horizontal;
	}

	void FixedUpdate()   //runs every physics frame ( different framerate than input or rendering)
	{
		//override object's velocity with desired inputVector direction

		GetComponent<Rigidbody>().velocity = inputVector * moveSpeed + Physics.gravity * 0.4f;
	}
}

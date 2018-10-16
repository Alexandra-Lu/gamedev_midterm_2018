using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class Movement : MonoBehaviour {
	

	public float moveSpeed = 7.5f;
	float verticalLook = 0f;
	
	//this variable will remember input and pass it to physics
	Vector3 inputVector;
	void Update () {
		float mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * 100f; // horizontal mouse movement
		float mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * 100f; // vertical mouse movement


		// rotate the camera based on mouse input
		// first, rotate body based on horizontal mouse movement
		transform.Rotate(0f, mouseX, 0f); //yaw
		Camera.main.transform.Rotate(-mouseY, 0f, 0f);

		//BETTER MOUSE LOOK
		//add mouse input to verical look, then clamp vertical look
		verticalLook += -mouseY;
		verticalLook = Mathf.Clamp(verticalLook, -80f, 80f);

		//actually apply verticalLook to rotation
		Camera.main.transform.localEulerAngles = new Vector3(verticalLook, 0f, 0f);
	
		//BETTER MOUSE LOOk
		// lock and hide the mouse cursor, if they click their mouse
		if (Input.GetMouseButton(0))
		{
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
		}

		
		//WASD Movement
		//GetAxis usually returns a float between -1f and 1f
		//when you're not pressing anything, it returns ~of;
		float horizontal = Input.GetAxis("Horizontal"); //A/D, Left/Right
		float vertical = Input.GetAxis("Vertical");  //W/S, Up/Down
		

		inputVector = transform.forward * vertical;
		inputVector += transform.right * horizontal;
	}

	void FixedUpdate()  
	{
		//override object's velocity with desired inputVector direction

		GetComponent<Rigidbody>().velocity = inputVector * moveSpeed + Physics.gravity * 0.4f;
	}
}

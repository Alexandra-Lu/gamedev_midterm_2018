using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class Reticle : MonoBehaviour {

	//place on main camera
	//shoot a ray to items and suitcase to change color so the player knows when they are in range to interact with something
	
	private LayerMask itemMask;
	private LayerMask suitcaseMask;

	public Image reticle; 
	
	void Start ()
	{
		itemMask = LayerMask.GetMask("Items");
		suitcaseMask = LayerMask.GetMask("Suitcase");
	}
	
	
	
	void Update () {
		//define
		Ray myRay = new Ray(transform.position, transform.forward);
		//set max distance
		float maxRayDistance = 3f;
		
		//shooty shooty shoot
		//if ray collides with item, turn red
		if (Physics.Raycast(myRay, maxRayDistance, itemMask.value))
		{

			reticle.color = Color.red;
		}

		//if ray collides with suitcase, turn yellow
		else if (Physics.Raycast(myRay, maxRayDistance*4, suitcaseMask.value))
		{
			reticle.color = Color.yellow;
		}
		
		//if ray collides with nothing, stay white
		else
		{
			reticle.color = Color.white;
		}
	}
}

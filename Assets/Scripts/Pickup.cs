using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


//place on  main camera
//shoot a ray from the camera/player to the item, then pick up/parent it when clicked

public class Pickup : MonoBehaviour
{
	private RaycastHit hit;
	private LayerMask itemMask;
	private LayerMask suitcaseMask;
	private GameObject holding;

	public Transform AttachMe;
	public Transform BoopOverTheSuitcase;
	
	// Use this for initialization
	void Start ()
	{
		itemMask = LayerMask.GetMask("Items");
		suitcaseMask = LayerMask.GetMask("Suitcase");
	}
	
	void Update ()
	{
		//define
		Ray myRay = new Ray(transform.position, transform.forward);
		//set max distance
		float maxRayDistance = 4f;

		
		if (Input.GetMouseButtonDown(0))		
		{

			if (holding == null) //if not already holding item
			{
				if (Physics.Raycast(myRay, out hit, maxRayDistance, itemMask.value))
				{
					Debug.Log("pick up object");
					//sets the "holding" variable to the item the ray hits
					holding = hit.transform.gameObject;
					//parented by the camera
					holding.transform.SetParent(transform); //"this" but  not
				}
			}

			else
			{
				if (Physics.Raycast(myRay, maxRayDistance, suitcaseMask.value))
				{
				
					Debug.Log("put down object");
					//un-parent item from the camera
					holding.transform.SetParent(null);
					//move the item to the empty positioned over the suitcase
					holding.transform.position = BoopOverTheSuitcase.position;
					//add rigidbody to activate gravity, so it falls into the suitcase
					holding.AddComponent<Rigidbody>();

					//when item is placed into suitcase, cross it off the list
					holding.GetComponent<ItemList>().collected = true;
					
					//back to holding nothing!
					holding = null;

				}
			}
		}

		if (holding != null)   //so if holding item, parent it to the empty on the player
		{
			holding.transform.position = Vector3.Lerp(holding.transform.position, AttachMe.position, .1f);
		}
		
	}
	
}


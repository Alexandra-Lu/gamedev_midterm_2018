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
		float maxRayDistance = 3f;

		
		if (Input.GetMouseButtonDown(0))		
		{

			if (holding == null)
			{
				if (Physics.Raycast(myRay, out hit, maxRayDistance, itemMask.value))
				{
					Debug.Log("pick up object");
					holding = hit.transform.gameObject;
					holding.transform.SetParent(transform); //this but  not
				}
			}

			else
			{
				if (Physics.Raycast(myRay, maxRayDistance, suitcaseMask.value))
				{
					Debug.Log("put down object");
					holding.transform.SetParent(null);
					holding.transform.position = BoopOverTheSuitcase.position;
					holding.AddComponent<Rigidbody>();
					holding = null;

				}
			}
		}

		if (holding != null)   //so if holding
		{
			holding.transform.position = Vector3.Lerp(holding.transform.position, AttachMe.position, .1f);
		}
		
	}
	
}


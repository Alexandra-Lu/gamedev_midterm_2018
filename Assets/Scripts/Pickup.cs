using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Pickup : MonoBehaviour
{
	private RaycastHit hit;
	private LayerMask mask;
	private GameObject holding;

	public Transform AttachMe;
	
	// Use this for initialization
	void Start ()
	{
		mask = LayerMask.GetMask("Items");
	}
	
	void Update ()
	{
		//define
		Ray myRay = new Ray(transform.position, transform.forward);
		//set max distance
		float maxRayDistance = 3f;

		
		if (Input.GetMouseButtonDown(0)&& holding ==null)		
		{
			
			if (Physics.Raycast(myRay, out hit, maxRayDistance, mask.value))
			{
				Debug.Log("munch");
				holding = hit.transform.gameObject;
				holding.transform.SetParent(transform); //this but  not
			}
		}

		if (holding != null)
		{
			holding.transform.position = Vector3.Lerp(holding.transform.position, AttachMe.position, .1f);
		}
		
	}
	
}


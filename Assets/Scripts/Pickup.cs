using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Pickup : MonoBehaviour
{
	private RaycastHit hit;
	private LayerMask mask;

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

		
			if (Input.GetMouseButtonDown(0))
			{
				if (Physics.Raycast(myRay, out hit, maxRayDistance, mask.value))
				{
					Debug.Log("munch munch");
				//	hit.transform.SetParent(this);
				}

			}
		
		}
	
	}


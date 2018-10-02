using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Pickup : MonoBehaviour
{
	private RaycastHit hit;
	private LayerMask mask;
	
	// Use this for initialization
	void Start ()
	{
		mask = LayerMask.GetMask("Items");
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		if (Input.GetMouseButtonDown(0))
		{
			if (Physics.Raycast(transform.position, transform.forward,
				out hit, Mathf.Infinity, mask.value))
			{
				Destroy((hit.transform.gameObject));
				//this.transform.parent = transform;
			}
		}
	}
}

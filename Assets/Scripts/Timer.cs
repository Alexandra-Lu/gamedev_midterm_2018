using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
	public float timer = 60f;

	public Text timeRemaining; 
	
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (timer > 0)
		{
			timer -= Time.deltaTime;
			timeRemaining.text = "Timer: " + (int)timer;
		}
		else
		{
			Time.timeScale = 0;
		}
	}
}

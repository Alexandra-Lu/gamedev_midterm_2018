using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class ItemList : MonoBehaviour
{

	public Image strikethrough;
	public bool collected = false;

	private void Start()
	{
		strikethrough.rectTransform.localScale = new Vector3(0, strikethrough.rectTransform.localScale.y, 1);
	}

	void Update () {
		if (collected)
		{
			strikethrough.rectTransform.localScale = Vector3.Lerp(strikethrough.rectTransform.localScale, new Vector3(1, .04f, 1), Time.deltaTime);
			strikethrough.rectTransform.anchoredPosition = new Vector3(8 + (strikethrough.rectTransform.localScale.x * strikethrough.rectTransform.rect.width * .5f), strikethrough.rectTransform.anchoredPosition.y, 0);
		}
	}
}

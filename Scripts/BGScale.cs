using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScale : MonoBehaviour {

	// Use this for initialization
	void Start () {
		SpriteRenderer sr = GetComponent<SpriteRenderer>();
		Vector3 tempScale = transform.localScale;

		float height = sr.bounds.size.y;
		float weight = sr.bounds.size.x;

		float worldHeight = Camera.main.orthographicSize * 2f;
		float worldWeight = worldHeight * Screen.width/ Screen.height;

		tempScale.y = worldHeight / height;
		tempScale.x = worldWeight / weight;

		transform.localScale = tempScale;


	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

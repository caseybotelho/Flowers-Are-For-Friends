﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectPosition : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<SpriteRenderer> ().sortingOrder = Mathf.RoundToInt (transform.position.y * 100f - 150f) * -1;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
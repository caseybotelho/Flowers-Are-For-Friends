﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectPosition : MonoBehaviour {

	// Use this for initialization
	void Start () {
        if (this.gameObject.name == "house") { 
		    GetComponent<SpriteRenderer> ().sortingOrder = Mathf.RoundToInt (transform.position.y * 100f - 325f) * -1;
        } else {
		    GetComponent<SpriteRenderer> ().sortingOrder = Mathf.RoundToInt (transform.position.y * 100f - 150f) * -1;
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (this.gameObject.name == "sword" || this.gameObject.name == "headphones" || this.gameObject.name == "frosting") {
            GetComponent<SpriteRenderer>().sortingOrder = GetComponentInParent<spriteInfo>().currentOrder + 1;
        }
	}
}

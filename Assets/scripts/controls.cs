using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controls : MonoBehaviour {

    private Canvas window;

	// Use this for initialization
	void Start () {
        window = GetComponent<Canvas>();
        window.enabled = true;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.anyKey && window.enabled == true) {
            window.enabled = false;
        }

    }
}

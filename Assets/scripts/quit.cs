using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quit : MonoBehaviour {

    float timer;

	void Start () {
        timer = 0;
	}
	
	void FixedUpdate () {
        if (Input.GetKey("escape")) {
            timer++;
            Debug.Log(timer);
        }
        if (timer > 50) {
            Application.Quit();
        }
    }
}

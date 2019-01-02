using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shiphouse : MonoBehaviour {

    Vector3 originPosition;
    float shakeIntensity = .1f;

    public bool takeoff = false;

	// Use this for initialization
	void Start () {
        originPosition = transform.localPosition;
	}
	
	// Update is called once per frame
	void Update () {
        if (takeoff == true) {
            transform.localPosition = originPosition + Random.insideUnitSphere * shakeIntensity;
        }
    }
}

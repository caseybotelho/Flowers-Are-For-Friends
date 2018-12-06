using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class propulsion : MonoBehaviour {

    public bool takeoff = true;
    public bool alium = false;

    // Use this for initialization
    void Start () {
        StartCoroutine(TakeOff());
	}
	
	// Update is called once per frame
	void Update () {
        if (takeoff == true && alium == true) {
            transform.Translate(0, 3 * Time.deltaTime, 0);
        }
	}

    private IEnumerator TakeOff() {
        yield return new WaitForSeconds(4);
        alium = true;
    }
}

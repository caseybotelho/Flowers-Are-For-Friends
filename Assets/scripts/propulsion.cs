using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class propulsion : MonoBehaviour {

    public bool takeoff = false;
    public bool alium = false;
    private bool go = false;

    public GameObject creditsObj;

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        if (takeoff == true && alium == true) {
            StartCoroutine(TakeOff());
        }
        if (go == true) {
            transform.Translate(0, 3 * Time.deltaTime, 0);
            StartCoroutine(StartCredits());
        }
	}

    private void OnCollisionEnter2D(Collision2D collision) {
        Debug.Log("test");
        if (takeoff == true) { 
            if (collision.gameObject.name == "alien") {
                alium = true;
                collision.gameObject.SetActive(false);
            }
        } else {
            collision = null;
        }
    }

    private IEnumerator TakeOff() {
        yield return new WaitForSeconds(4);
        go = true;
    }

    private IEnumerator StartCredits() {
        yield return new WaitForSeconds(4);
        creditsObj.GetComponent<credits>().theEnd = true;
    }
}

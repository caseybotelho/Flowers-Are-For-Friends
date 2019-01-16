using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class propulsion : MonoBehaviour {

    public bool takeoff = false;
    public bool alium = false;
    private bool go = false;
    private bool initiated = false;
    private bool changeLoop = false;
    private bool quieter = false;

    public GameObject creditsObj;

    private AudioSource running;
    public AudioClip blastoff;

    public GameObject flames;
    private Vector3 flamesOrigin;

    // Use this for initialization
    void Start () {

        running = GetComponent<AudioSource>();
        running.enabled = false;

        flames.SetActive(false);
        flamesOrigin = flames.transform.localPosition;

    }
	
	// Update is called once per frame
	void Update () {
        if (takeoff == true && alium == true && initiated == false) {
            StartCoroutine(TakeOff());
            initiated = true;
        }
        if (go == true) {
            flames.SetActive(true);
            flames.transform.localPosition = flamesOrigin + Random.insideUnitSphere * .1f;
            transform.Translate(0, 3 * Time.deltaTime, 0);
            StartCoroutine(StartCredits());
            Debug.Log(running.time);
        }
        
        if (takeoff == true && running.enabled == false) {
            running.enabled = true;
        }

        if (changeLoop == true) {
            if (running.time > 5.8f) {
                running.time = 4.8f;
                if (quieter == false) {
                    quieter = true;
                }
            }
        }

        if (quieter == true) {
            if (running.volume > .05f) {
                running.volume = running.volume - .001f;
            }
        }
	}

    private void OnCollisionEnter2D(Collision2D collision) {
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
        running.clip = blastoff;
        running.Play();
        changeLoop = true;
    }

    private IEnumerator StartCredits() {
        yield return new WaitForSeconds(4);
        creditsObj.GetComponent<credits>().theEnd = true;
    }
}

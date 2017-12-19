using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class friend : MonoBehaviour {

    [SerializeField] GameObject alien;

	public int gifts = 0;

	private string def = "Hey! This is what I say by default!";
    private string thanks = "Wow! I love you!";
	private string curMes;

	private float rot = 0;

	private float speed = 2.0f;
	private float maxSpeed = 3.0f;
	private float minSpeed = .5f;

	float wait = 0;

	private float delta;
	private float lastTime;
	private float currentTime;

    private bool talkedTo;

	[SerializeField] Canvas speechCanvas;
	[SerializeField] Text speech;

	void Start() {
		curMes = def;

        talkedTo = false;

		rot = Random.Range(0, 360);
		delta = 0;
	}

    void Update() {
        if (talkedTo == false) { 
		    transform.Translate (0, speed * Time.deltaTime, 0);
		    transform.localEulerAngles = new Vector3 (0, 0, rot);
		    currentTime = Time.fixedTime - lastTime;
		    if (currentTime >= delta) {
		    	speed = 0;
		    }
		    if (currentTime >= delta + wait) {
		    	ChangeDirection ();
		    }
        } else {

        }
	}

	public void Hey() {
        talkedTo = true;
		speech.text = curMes;
		speechCanvas.enabled = true;
	}

    public void Bye() {
        speechCanvas.enabled = false;
        talkedTo = false;
    }

	public void GotGift() {
		gifts++;
		if (gifts > 3) {
			curMes = string.Concat("You've given me ", gifts, " flowers! I love you!");
        }
        talkedTo = true;
        speech.text = thanks;
        speechCanvas.enabled = true;
    }

	void OnTriggerEnter2D(Collider2D other) {
        talkedTo = true;
	}

	void OnTriggerExit2D(Collider2D other) {
        talkedTo = false;
	}

	private void ChangeDirection() {
		wait = Random.Range (0f, 2.0f);
		rot = Random.Range (0, 360);
		delta = Random.Range (.05f, 3.0f);
		lastTime = Time.fixedTime;
		speed = Random.Range (minSpeed, maxSpeed);
	}
}

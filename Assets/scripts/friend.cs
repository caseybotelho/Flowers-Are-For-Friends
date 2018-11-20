using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class friend : MonoBehaviour {

    [SerializeField] GameObject alien;
    [SerializeField] private GameObject controller;

    gameController behaviour;

    public int gifts = 0;

	private string def = "Hey! This is what I say by default!";
    private string thanks = "Wow! What a friend!";
    private string nah = "I'm not a fan of this one";
    public string love = "You're alright for an alien!";
    private string curMes;

    private tang tangSpeech;
    private trebbis trebbisSpeech;
    private creeg creegSpeech;

    private float rot = 0;

	private float speed = 1.0f;
	private float maxSpeed = 2.0f;
	private float minSpeed = .5f;

	float wait = 0;

	private float delta;
	private float lastTime;
	private float currentTime;

    private bool talkedTo;

    public enum FlowerTypes {
        snapdragon,
        dandelion,
        night_rider
    }

    public FlowerTypes prefer = FlowerTypes.snapdragon;

    public string whatFlower;

	[SerializeField] Canvas speechCanvas;
	[SerializeField] Text speech;
    [SerializeField] Text total;

    void Start() {

        behaviour = controller.GetComponent<gameController>();

        talkedTo = false;

		rot = Random.Range(0, 360);
		delta = 0;

        whatFlower = prefer.ToString();

        tangSpeech = GetComponent<tang>();
        trebbisSpeech = GetComponent<trebbis>();
        creegSpeech = GetComponent<creeg>();
        if (tangSpeech != null) {
            def = tangSpeech.def;
            thanks = tangSpeech.thanks;
            nah = tangSpeech.nah;
            love = tangSpeech.love;
        } else if (trebbisSpeech != null) {
            def = trebbisSpeech.def;
            thanks = trebbisSpeech.thanks;
            nah = trebbisSpeech.nah;
            love = trebbisSpeech.love;
        } else if (creegSpeech != null) {
            def = creegSpeech.def;
            thanks = creegSpeech.thanks;
            nah = creegSpeech.nah;
            love = creegSpeech.love;
        }

        curMes = def;

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
			if (speed == 0) {
				GetComponent<SpriteRenderer>().sortingOrder = Mathf.RoundToInt (transform.position.y * 100f) * -1;
			}
        } else {
			Vector3 alienDir = alien.transform.position - transform.position;
			float angle = Mathf.Atan2(alienDir.y, alienDir.x) * Mathf.Rad2Deg;
			Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
			transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * 6);
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
        total.text = gifts + "/4";
		if (gifts > 3) {
            if (tangSpeech != null) {
                tangSpeech.gifts = gifts;
                tangSpeech.LoveUpdate();
                love = tangSpeech.love;
            } else if (trebbisSpeech != null) {
                trebbisSpeech.gifts = gifts;
                trebbisSpeech.LoveUpdate();
                love = trebbisSpeech.love;
            } else if (creegSpeech != null) {
                creegSpeech.gifts = gifts;
                creegSpeech.LoveUpdate();
                love = creegSpeech.love;
            }
			curMes = love;
        }
        talkedTo = true;
        speech.text = thanks;
        speechCanvas.enabled = true;
        if (gifts == 4) {
            behaviour.NewFriend();
        }
    }

	public void NoThanks() {
        talkedTo = true;
        speech.text = nah;
        speechCanvas.enabled = true;
    }

	void OnTriggerEnter2D(Collider2D other) {
		if (other.transform.position == alien.transform.position) {
			talkedTo = true;
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if (other.transform.position == alien.transform.position) {
			talkedTo = false;
		}
	}

	private void ChangeDirection() {
		wait = Random.Range (0f, 2.0f);
		rot = Random.Range (0, 360);
		delta = Random.Range (.05f, 3.0f);
		lastTime = Time.fixedTime;
		speed = Random.Range (minSpeed, maxSpeed);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class creeg : MonoBehaviour {

    public string def = "There's no chance ANYTHING you say could be important enough for ME to listen. Buzz off.";
    public string thanks = "Alright, so you found ONE thing that I ACTUALLY like. Do you want a medal or something?";
    public string thanks2;
    public string nah = "Exactly what I would expect from someone like you. KEEP WALKING.";
    public string love;
    public string myName;

    private friend friendInfo;
    public int gifts;

    public GameObject present;

    private Quaternion iniRot;

    public SpriteRenderer creegSprite;
    
    void Awake() {
        def = "Oh, was today the day you were leaving? Not that I care or anything. Do you need something?";
        thanks = "DAMN IT. I can't believe you grew me my favorite flower! Why you always gotta be a GOOD person? Er, alien.";
        thanks2 = "I was going to wait until the last minute to give you this. Maybe throw it at your ship or something. CAN'T NOW.";
        nah = "Yeah? What about it?";
        myName = "Creeg";
    }

    void Start () {
        friendInfo = gameObject.GetComponentInParent<friend>();
        gifts = friendInfo.gifts;

        iniRot = transform.rotation;

        creegSprite = GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
        if (gifts > 3) {
            present.SetActive(true);
        }
    }

    void LateUpdate() {
        transform.rotation = iniRot;
    }

    public void LoveUpdate() {
        love = string.Concat("*Creeg is holding back tears while trying to give you a cool wink. It isn't working*");
    }
}

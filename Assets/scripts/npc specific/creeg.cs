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
        def = "I can't believe this is goodbye... you'll check in every once in a while, right? Wait, do y'all even have phones up there?";
        thanks = "You're the only one who never made fun of me for liking daffodils... Who cares if they're weeds? I like what I like.";
        thanks2 = "I got something for you, too. Strawberry frosted, just how you like. Baked them mysel- oh you stole them from me and ate them before I even said this.";
        nah = "You're growing them in your garden, right? Trebbis and Creeg will love these!";
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
        love = string.Concat("I was too judgemental before. I don't MEAN to be. ANYWAY, thanks for sticking with me. (", gifts, " gifts)");
    }
}

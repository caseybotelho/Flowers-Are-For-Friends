using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trebbis : MonoBehaviour {

    public string def;
    public string thanks;
    public string thanks2;
    public string nah;
    public string love;
    public string myName;

    private friend friendInfo;
    public int gifts;

    public GameObject present;

    private Quaternion iniRot;

    public SpriteRenderer trebbisSprite;

    void Awake() {
        def = "I can't believe this is goodbye... you'll check in every once in a while, right? Wait, do y'all even have phones up there?";
        thanks = "You're the only one who never made fun of me for liking daffodils... Who cares if they're weeds? I like what I like.";
        thanks2 = "I got something for you, too. Strawberry frosted, just how you like. Baked them mysel- oh you stole them from me and ate them all immediately.";
        nah = "You're growing them in your garden, right? Trebbis and Creeg will love these!";
        myName = "Trebbis";
    }

    void Start () {
        friendInfo = gameObject.GetComponentInParent<friend>();
        gifts = friendInfo.gifts;

        iniRot = transform.rotation;

        trebbisSprite = GetComponent<SpriteRenderer>();
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
        love = string.Concat("Don't forget about us!");
    }
}

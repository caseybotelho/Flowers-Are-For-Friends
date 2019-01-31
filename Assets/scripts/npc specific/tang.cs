using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tang : MonoBehaviour {

    public string def = "Woah! Impressed that you're an alien and all, but I don't have time for this right now!";
    public string thanks = "Hey! Where'd you find this!? Have any more?!";
    public string thanks2;
    public string nah = "Ugh! Keep it to yourself, alien dude. Don't have time for trash.";
    public string love;
    public string myName;

    private friend friendInfo;
    public int gifts;

    public GameObject present;

    private Quaternion iniRot;

    public SpriteRenderer tangSprite;

    void Awake() {
        def = "WAH! Don't sneak up on me like that! I've got too much on my mind today. What was I just doing...?";
        thanks = "SNAPDRAGONS! Did I tell you those were my favorite? Or did you pull some weird alien trick?";
        thanks2 = "OH! That reminded me! I was getting you this! Have a great trip, little buddy.";
        nah = "*Tang is too distracted to notice the flower*";
        myName = "Tang";
    }

    void Start () {
        friendInfo = gameObject.GetComponentInParent<friend>();
        gifts = friendInfo.gifts;

        iniRot = transform.rotation;

        tangSprite = GetComponent<SpriteRenderer>();
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
        love = string.Concat("How am I going to get anything done without you? You were my best personal assistent!");
    }
}

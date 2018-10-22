using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tang : MonoBehaviour {

    public string def = "Woah! Impressed that you're an alien and all, but I don't have time for this right now!";
    public string thanks = "Hey! Where'd you find this!? Have any more?!";
    public string nah = "Ugh! Keep it to yourself, alien dude. Don't have time for trash.";
    public string love;

    private friend friendInfo;
    public int gifts;

    void Start () {
        friendInfo = GetComponent<friend>();
        gifts = friendInfo.gifts;   
	}
	
	// Update is called once per frame
	void Update () {
        if (gifts != friendInfo.gifts) {
        }
    }

    public void LoveUpdate() {
        love = string.Concat("Ah! Maybe I was a little too hasty before. Thanks for being there for me, friendo. (",gifts," gifts)");
    }
}

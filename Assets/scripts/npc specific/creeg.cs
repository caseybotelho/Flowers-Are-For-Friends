using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class creeg : MonoBehaviour {

    public string def = "There's no chance ANYTHING you say could be important enough for ME to listen. Buzz off.";
    public string thanks = "Alright, so you found ONE thing that I ACTUALLY like. Do you want a medal or something?";
    public string nah = "Exactly what I would expect from someone like you. KEEP WALKING.";
    public string love;

    private friend friendInfo;
    public int gifts;

    public GameObject present;

    void Start () {
        friendInfo = GetComponent<friend>();
        gifts = friendInfo.gifts;   
	}
	
	// Update is called once per frame
	void Update () {
        if (gifts > 3) {
            present.SetActive(true);
        }
    }

    public void LoveUpdate() {
        love = string.Concat("I was too judgemental before. I don't MEAN to be. ANYWAY, thanks for sticking with me. (", gifts, " gifts)");
    }
}

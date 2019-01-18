using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trebbis : MonoBehaviour {

    public string def = "Sorry, I'm just not in the mood... maybe another time, little guy.";
    public string thanks = "Hey... how did you know this was my favorite flower...?";
    public string nah = "You keep it... It's not really my thing...";
    public string love;

    private friend friendInfo;
    public int gifts;

    public GameObject present;

    private Quaternion iniRot;

    public SpriteRenderer trebbisSprite;

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
        love = string.Concat("I think it's time for me to step up... thanks for helping me realize that, little guy. (", gifts, " gifts)");
    }
}

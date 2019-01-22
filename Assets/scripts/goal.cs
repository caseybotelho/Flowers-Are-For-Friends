using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class goal : MonoBehaviour {

    Text goalStatus;
    public int totalFriends;

    void Start () {

        goalStatus = GetComponent<Text>();

        totalFriends = 0;
        goalStatus.color = Color.blue;
    }
	
	void Update () {
	}

    public void GoalUpdate() {
        goalStatus.text = totalFriends + "/3";
        if (totalFriends == 3) {
            goalStatus.color = Color.blue;
        }
    }
}

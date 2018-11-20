using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class goal : MonoBehaviour {

    TextMesh goalStatus;
    public int totalFriends;

    void Start () {

        goalStatus = GetComponent<TextMesh>();

        totalFriends = 0;
    }
	
	void Update () {
        Debug.Log(goalStatus);
	}

    public void GoalUpdate() {
        goalStatus.text = totalFriends + "/3";
    }
}

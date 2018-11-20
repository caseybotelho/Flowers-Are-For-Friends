using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameController : MonoBehaviour {

    public int friendTotal;

    public GameObject goalText;
    goal friendGoal;

    void Start () {
        friendTotal = 0;
        friendGoal = goalText.GetComponent<goal>();
	}
	
	void Update () {
		
	}

    public void NewFriend() {
        friendTotal++;
        friendGoal.totalFriends = friendTotal;
        friendGoal.GoalUpdate();
    }
}

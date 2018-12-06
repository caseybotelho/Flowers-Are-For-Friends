using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameController : MonoBehaviour {

    public int friendTotal;

    public GameObject goalText;
    public GameObject house;
    public GameObject rocket;

    goal friendGoal;
    shiphouse movement;
    propulsion blastoff;

    void Start () {
        friendTotal = 0;
        friendGoal = goalText.GetComponent<goal>();
        movement = house.GetComponent<shiphouse>();
        blastoff = rocket.GetComponent<propulsion>();
    }
	
	void Update () {
		
	}
    
    public void NewFriend() {
        friendTotal++;
        friendGoal.totalFriends = friendTotal;
        friendGoal.GoalUpdate();
        if (friendTotal == 3) {
            movement.takeoff = true;
            blastoff.takeoff = true;
        }
    }
}

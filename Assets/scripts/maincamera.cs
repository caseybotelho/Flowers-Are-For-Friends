using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class maincamera : MonoBehaviour {

	[SerializeField] private GameObject character;
    [SerializeField] private GameObject house;

    private bool hasMoved = false;
    Vector3 housePos;

    void Update () {
        if (character.activeSelf == true) {
		    transform.position = new Vector3(character.transform.position.x, character.transform.position.y, -1);
        }
        if (character.activeSelf == false && hasMoved == false) {
            housePos = house.transform.position;
            housePos.z = -999;
            MoveCamera();
        }
	}

    private void MoveCamera() {
        this.transform.position = housePos;
        hasMoved = true;
    }
}

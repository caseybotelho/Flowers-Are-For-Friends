using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inventory : MonoBehaviour {

	public Canvas mainMenu;

	void Start () {
		mainMenu = GetComponent<Canvas> ();
        mainMenu.enabled = false;
    }

    void Update() { 
        if (Input.GetKeyDown("space")) {
            mainMenu.enabled = !mainMenu.enabled;
        }
    }
}

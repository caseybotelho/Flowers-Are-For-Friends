using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inventory : MonoBehaviour {

	private Canvas mainMenu;

    public int snapTotal = 0;
    public int nightTotal = 0;
    public int dandTotal = 0;

    [SerializeField] private Text snapText;
    [SerializeField] private Text nightText;
    [SerializeField] private Text dandText;

    void Start () {
		mainMenu = GetComponent<Canvas> ();
        mainMenu.enabled = false;
    }

    void Update() { 
        if (Input.GetKeyDown("space")) {
            mainMenu.enabled = !mainMenu.enabled;
        }
        snapText.text = snapTotal.ToString();
        nightText.text = nightTotal.ToString();
        dandText.text = dandTotal.ToString();
    }
}

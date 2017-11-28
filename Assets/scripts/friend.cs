using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class friend : MonoBehaviour {

	public int gifts = 0;

	private string def = "Hey! This is what I say by default!";

	private string curMes;

	void Start() {
		curMes = def;
	}

	void Update () {
		
	}

	public void Hey() {
		Debug.Log (curMes);
	}

	public void GotGift() {
		gifts++;
		if (gifts > 3) {
			curMes = string.Concat("You've given me ", gifts, " flowers! I love you!");
		}
	}
}

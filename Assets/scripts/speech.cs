using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class speech : MonoBehaviour {

	private Canvas speechBox;

	void Start () {
		speechBox = GetComponent<Canvas> ();
		speechBox.enabled = false;
	}
}

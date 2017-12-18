using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class maincamera : MonoBehaviour {

	[SerializeField] private GameObject character;

	void Update () {
		transform.position = new Vector3(character.transform.position.x, character.transform.position.y, -1);
	}
}

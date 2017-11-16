using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flower : MonoBehaviour {

	public GameObject alium;

	public bool attached = false;

    float direction = 1;

    public BoxCollider2D col;

	void Start () {
        col = GetComponent<BoxCollider2D>();
	}
	
	void Update () {
		if (attached) {
			float xPos = alium.transform.position.x - (1.0f * direction);

			transform.position = new Vector3(xPos, alium.transform.position.y , 0);
		}
	}

	public void newPos() {
		attached = true;
        col.enabled = !col.enabled;
	}

    public void Flip() {
        direction *= -1;
    }
}

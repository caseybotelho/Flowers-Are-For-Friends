using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flower : MonoBehaviour {

	public GameObject alium;

	public bool attached = false;

    float direction = 1;

    public BoxCollider2D col;

    public enum FlowerTypes {
        snapdragon,
        dandelion,
        night_rider
    }

    public FlowerTypes chooseFlower = FlowerTypes.snapdragon;
    public string whatFlower;

	void Start () {
        col = GetComponent<BoxCollider2D>();
        whatFlower = chooseFlower.ToString();
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

	public void Drop() {
		col.enabled = !col.enabled;
	}

    public void Flip() {
        direction *= -1;
    }
}

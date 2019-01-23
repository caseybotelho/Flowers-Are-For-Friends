using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spriteInfo : MonoBehaviour {

	public float currentDir = -1;
	float lastDir = -1;

    public int currentOrder;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Rotate() {
        transform.Rotate(0, 180f, 0);
        lastDir = currentDir;
    }

    public void SpriteOrder() {
        GetComponent<SpriteRenderer>().sortingOrder = Mathf.RoundToInt(transform.position.y * 100f) * -1;
        currentOrder = Mathf.RoundToInt(transform.position.y * 100f) * -1;
    }
}

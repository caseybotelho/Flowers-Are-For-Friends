using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alium : MonoBehaviour {

	private const float baseSpeed = 6.0f;
	private const float rotSens = 9.0f;

	float currentDir = -1;
	float lastDir = -1;

	[SerializeField] private GameObject testSpritePrefab;
	private GameObject testSprite;

	private CharacterController lover;
    flower myFlower;
    friend myFriend;

	void Start() {
		lover = GetComponent<CharacterController> ();

		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}

    void Update() {
        // lover movement
        float movY = Input.GetAxis("Vertical") * baseSpeed;
        float movX = Input.GetAxis("Horizontal") * baseSpeed;

        Vector3 mov = new Vector3(movX, movY, 0);
        mov = Vector3.ClampMagnitude(mov, baseSpeed);
        mov *= Time.deltaTime;

        // lover rotation
        // float rot = Input.GetAxis("Mouse X") * rotSens;

        if (movX != 0) {
            currentDir = Mathf.Sign(movX);
            if (lastDir != currentDir) {
                transform.Rotate(0, 180f, 0);
                lastDir = currentDir;
                if (myFlower) {
                    myFlower.Flip();
                }
            }
        }

        lover.Move(mov);
        // transform.Rotate (0, 0, -rot);

        // wind time
        if (Input.GetMouseButtonDown(0)) {
            //testSprite = Instantiate (testSpritePrefab) as GameObject;
            //testSprite.transform.position = transform.TransformPoint (0, .1f, 0);
            //testSprite.transform.rotation = transform.rotation;
            RaycastHit2D hit = Physics2D.CircleCast(transform.position, 2.0f, transform.up, 2.0f);
            if (hit.collider) {
                myFriend = hit.transform.gameObject.GetComponent<friend>();
                myFlower = hit.transform.gameObject.GetComponent<flower>();
                // pass position and rotation to potential so it knows where to fly away from
                if (myFlower) {
                    myFlower.alium = this.gameObject;
                    myFlower.newPos();
                }
                if (myFriend) {
                    if (myFlower && myFlower.attached){
                        Debug.Log("i love you!");
                    } else {
                        Debug.Log("hey!");
                    }
                }
            }
        }

        if (Input.GetMouseButtonDown(1)) {
            if (myFlower) { 
                myFlower.attached = false;
            } 
        }
    }
}

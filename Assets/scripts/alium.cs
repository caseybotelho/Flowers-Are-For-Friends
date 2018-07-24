using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alium : MonoBehaviour {

    [SerializeField] private Canvas mainMenu;

    private const float baseSpeed = 6.0f;
	private const float rotSens = 9.0f;

	float currentDir = -1;
	float lastDir = -1;

	[SerializeField] private GameObject testSpritePrefab;
	private GameObject testSprite;

	private CharacterController lover;
    flower myFlower;
    friend myFriend;
    inventory menuBehaviour;

    public bool talking;

    void Start() {
		lover = GetComponent<CharacterController> ();

		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;

        talking = false;

        menuBehaviour = mainMenu.GetComponent<inventory>();
    }

    void Update() {
        if (mainMenu.enabled == false) {
            // lover movement
            float movY = Input.GetAxis("Vertical") * baseSpeed;
            float movX = Input.GetAxis("Horizontal") * baseSpeed;

            Vector3 mov = new Vector3(movX, movY, 0);
            mov = Vector3.ClampMagnitude(mov, baseSpeed);
            mov *= Time.deltaTime;

            // lover rotation
            // float rot = Input.GetAxis("Mouse X") * rotSens;

            if (talking == false) { 
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
            }

            // transform.Rotate (0, 0, -rot);

            // wind time
            if (Input.GetMouseButtonDown(0)) {
                if (talking == false) { 
                    //testSprite = Instantiate (testSpritePrefab) as GameObject;
                    //testSprite.transform.position = transform.TransformPoint (0, .1f, 0);
                    //testSprite.transform.rotation = transform.rotation;
                    RaycastHit2D hit = Physics2D.CircleCast(transform.position, 2.0f, transform.up, 2.0f);
                    if (hit.collider) {
                        myFriend = hit.transform.gameObject.GetComponent<friend>();
		    	    	if (myFlower == null) {
		    	    		myFlower = hit.transform.gameObject.GetComponent<flower> ();
		    	    	}
                        // pass position and rotation to potential so it knows where to fly away from
                        if (myFlower && myFlower.attached == false) {
                            myFlower.alium = this.gameObject;
                            myFlower.newPos();
                        }
                        if (myFriend) {
                            talking = true;
                            if (myFlower && myFlower.attached){
                                if (myFlower.whatFlower == myFriend.whatFlower) { 
                                    Debug.Log("i love you!");
		    	    			    Destroy (myFlower.gameObject);
		    	    			    myFriend.GotGift ();
                                } else {
                                    myFriend.NoThanks();
                                }
		    	    		} else {
		    	    			myFriend.Hey ();
                            }
                        }
                    }
                } else {
                    myFriend.Bye();
                    talking = false;
                    myFriend = null;
                }
            }


            if (Input.GetMouseButtonDown(1) && talking == false) {
                if (myFlower) { 
                    myFlower.attached = false;
		    		myFlower.Drop ();
		    		myFlower = null;
                } 
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alium : MonoBehaviour {

    [SerializeField] private Canvas mainMenu;
    [SerializeField] private GameObject controller;

    [SerializeField] private GameObject flowerPrefab;
    private GameObject flower;

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
    gamecontroller behaviour;

    public bool talking;

    void Start() {
		lover = GetComponent<CharacterController> ();

		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;

        talking = false;

        menuBehaviour = mainMenu.GetComponent<inventory>();

        behaviour = controller.GetComponent<gamecontroller>();
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
            

            if (myFlower && myFlower.direction == currentDir) {
                myFlower.direction *= -1;
            }

			if (movY != 0) {
				GetComponent<SpriteRenderer>().sortingOrder = Mathf.RoundToInt (transform.position.y * 100f) * -1;
			}

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
                        if (myFlower && myFlower.attached == false) {
                            ChangePos();
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
                    myFlower.alium = null;
                    myFlower = null;
                } 
            }
            if (Input.GetKeyDown("e")) {
                if (myFlower) { 
                    if (myFlower.whatFlower == "snapdragon") {
                        menuBehaviour.snapTotal++;
                        Destroy(myFlower.gameObject);
                        myFlower.whatFlower = null;
                    } else if (myFlower.whatFlower == "night_rider") {
                        menuBehaviour.nightTotal++;
                        Destroy(myFlower.gameObject);
                        myFlower.whatFlower = null;
                    } else if (myFlower.whatFlower == "dandelion") {
                        menuBehaviour.dandTotal++;
                        Destroy(myFlower.gameObject);
                        myFlower.whatFlower = null;
                    }
                }
            }
            if (Input.GetKeyDown("1")) { 
                if (menuBehaviour.snapTotal > 0) { 
                    if (myFlower != null) {
                        if (myFlower.whatFlower == "night_rider") {
                            menuBehaviour.nightTotal++;
                            Destroy(myFlower.gameObject);
                        } else if (myFlower.whatFlower == "dandelion") { 
                            menuBehaviour.dandTotal++;
                            Destroy(myFlower.gameObject);
                        } else {
                            return;
                        }
                    }
                    menuBehaviour.snapTotal--;
                    flower = Instantiate(flowerPrefab) as GameObject;
                    myFlower = flower.GetComponent<flower>();
                    myFlower.whatFlower = "snapdragon";
                    myFlower.alium = this.gameObject;
                    myFlower.attached = true;
                    myFlower.col.enabled = false;
                }
            }
            if (Input.GetKeyDown("2")) { 
                if (menuBehaviour.nightTotal > 0) {
                    if (myFlower != null) {
                        if (myFlower.whatFlower == "snapdragon") {
                            menuBehaviour.snapTotal++;
                            Destroy(myFlower.gameObject);
                        } else if (myFlower.whatFlower == "dandelion") { 
                            menuBehaviour.dandTotal++;
                            Destroy(myFlower.gameObject);
                        } else {
                            return;
                        }
                    }
                    menuBehaviour.nightTotal--;
                    flower = Instantiate(flowerPrefab) as GameObject;
                    myFlower = flower.GetComponent<flower>();
                    myFlower.whatFlower = "night_rider";
                    myFlower.alium = this.gameObject;
                    myFlower.attached = true;
                    myFlower.col.enabled = false;
                }
            }
            if (Input.GetKeyDown("3")) { 
                if (menuBehaviour.dandTotal > 0) {
                    if (myFlower != null) {
                        if (myFlower.whatFlower == "snapdragon") {
                            menuBehaviour.snapTotal++;
                            Destroy(myFlower.gameObject);
                        } else if (myFlower.whatFlower == "night_rider") { 
                            menuBehaviour.nightTotal++;
                            Destroy(myFlower.gameObject);
                        } else {
                            return;
                        }
                    }
                    menuBehaviour.dandTotal--;
                    flower = Instantiate(flowerPrefab) as GameObject;
                    myFlower = flower.GetComponent<flower>();
                    myFlower.whatFlower = "dandelion";
                    myFlower.alium = this.gameObject;
                    myFlower.attached = true;
                    myFlower.col.enabled = false;
                }
            }
            if (Input.GetKeyDown("q")) {
                Debug.Log(myFlower);
            }
        }
    }

    private void ChangePos() { 
        myFlower.alium = this.gameObject;
        myFlower.newPos();
    }
}

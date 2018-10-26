using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flower : MonoBehaviour {

	public GameObject alium;

	public bool attached = false;

    public float direction = 1;

    public BoxCollider2D col;

    [SerializeField] Sprite snapSprite;
    [SerializeField] Sprite dandSprite;
    [SerializeField] Sprite nightSprite;

    private SpriteRenderer flowerSprite;

    public enum FlowerTypes {
        snapdragon,
        dandelion,
        night_rider
    }

    public FlowerTypes chooseFlower = FlowerTypes.snapdragon;
    public string whatFlower;

	void Awake () {
        col = GetComponent<BoxCollider2D>();
        whatFlower = chooseFlower.ToString();
        flowerSprite = GetComponent<SpriteRenderer>();
        flowerSprite.sprite = snapSprite;
    }
	
	void Update () {
		if (attached) {
			float xPos = alium.transform.position.x - (1.0f * direction);
			transform.position = new Vector3(xPos, alium.transform.position.y , 0);
            if (flowerSprite.enabled == false) {
                flowerSprite.enabled = true;
            }
		}
        if (whatFlower == "snapdragon" && flowerSprite.sprite != snapSprite) {
            flowerSprite.sprite = snapSprite;
        } else if (whatFlower == "dandelion" && flowerSprite.sprite != dandSprite) {
            flowerSprite.sprite = dandSprite;
        } else if (whatFlower == "night_rider" && flowerSprite.sprite != nightSprite) {
            flowerSprite.sprite = nightSprite;
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

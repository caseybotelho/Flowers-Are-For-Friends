using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class credits : MonoBehaviour {

    GameObject backgroundObj;
    GameObject line1Obj;
    GameObject line2Obj;

    Image background;
    Image line1;
    Image line2;

    public bool theEnd;

    bool textCycle;

    void Start () {

        textCycle = false;
        theEnd = false;

        backgroundObj = this.gameObject.transform.GetChild(0).gameObject;
        line1Obj = this.gameObject.transform.GetChild(1).gameObject;
        line2Obj = this.gameObject.transform.GetChild(2).gameObject;

        background = backgroundObj.GetComponent<Image>();
        background.canvasRenderer.SetAlpha(0.0f);

        line1 = line1Obj.GetComponent<Image>();
        line1.canvasRenderer.SetAlpha(0.0f);

        line2 = line2Obj.GetComponent<Image>();
        line2.canvasRenderer.SetAlpha(0.0f);
    }
	
	void Update () {
        if (theEnd == true) { 
            background.CrossFadeAlpha(1, 1.0f, false);
            if (textCycle == false) {
                StartCoroutine(NextLine());
            }
        }
    }

    private IEnumerator NextLine() {
        textCycle = true;
        yield return new WaitForSeconds(4f);
        line1.CrossFadeAlpha(1, .2f, false);
        yield return new WaitForSeconds(4f);
        line1.CrossFadeAlpha(0, .2f, false);
        yield return new WaitForSeconds(1f);
        line2.CrossFadeAlpha(1, .2f, false);
        yield return new WaitForSeconds(6f);
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("title");
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (IsPressButton()) {
            SceneManager.LoadScene("menuScene");
        }
    }
    bool IsPressButton() { //A버튼 눌렸는지 확인

        if (OVRInput.GetDown(OVRInput.RawButton.A)) {
            Debug.Log("check button");
            return true;
        }
        return false;
    }
}

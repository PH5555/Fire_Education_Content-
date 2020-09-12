using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetComment : MonoBehaviour {

    [SerializeField] Canvas success;
    [SerializeField] Canvas failed;
    [SerializeField] Text txt_commnet;
    [SerializeField] Text txt_score;
    
    // Use this for initialization
    void Start () {
		if(GlobalData.SuccessOrFail) {
            success.gameObject.SetActive(true);
            failed.gameObject.SetActive(false);
            txt_score.text = "" + GlobalData.score;
            txt_commnet.text = setComment(GlobalData.score);
            
        }
        else {
            success.gameObject.SetActive(false);
            failed.gameObject.SetActive(true);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    string setComment(float time) {
        if (time < 20) {
            return "잘했어요!";
        }
        else if (time < 40) {
            return "분발해요!";
        }
        else {
            return "이미 죽었어요!";
        }
    }
}

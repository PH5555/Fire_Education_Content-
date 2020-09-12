using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonChange : MonoBehaviour {

    [SerializeField] private Canvas Canvas_firstMenu;
    [SerializeField] private Canvas Canvas_secondMenu;
    [SerializeField] private Canvas Canvas_situation;

    public void changeButtonToPlaymenu() {
        Canvas_firstMenu.gameObject.SetActive(false);
        Canvas_secondMenu.gameObject.SetActive(true);
    }

    public void changeButtonToBack() {
        Canvas_firstMenu.gameObject.SetActive(true);
        Canvas_secondMenu.gameObject.SetActive(false);
    }

    public void changeButtonToSituation() {
        Canvas_secondMenu.gameObject.SetActive(false);
        Canvas_situation.gameObject.SetActive(true);
    }
}

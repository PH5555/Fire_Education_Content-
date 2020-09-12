using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class sceneChange : MonoBehaviour {

    public void ChangeMainScene()
    {
        SceneManager.LoadScene("mainScene");
    }
    public void ChangeSelectScene() 
    {
        SceneManager.LoadScene("selectScene");
    }
    public void ChangeScoreScene()
    {
        SceneManager.LoadScene("scoreScene");
    }
    public void ChangeClassroomScene() {
        SceneManager.LoadScene("ClassroomScene");
    }
    public void ChangeKitchenScene() {
        SceneManager.LoadScene("KitchenScene");
    }
    public void ChangeHouseScene() {
        SceneManager.LoadScene("HouseScene");
    }
    public void ChangeMenuScene() {
        SceneManager.LoadScene("menuScene");
    }
    public void Exit() {
        Application.Quit();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class FireExtinguisher : MonoBehaviour {

    [SerializeField] GameObject character;
    [SerializeField] GameObject fire;
    [SerializeField] GameObject addfire;
    [SerializeField] GameObject explosion;
    [SerializeField] ParticleSystem SmallFireParticle;
    [SerializeField] ParticleSystem SmallFireSpark;
    [SerializeField] ParticleSystem SmallFireSmoke;
    [SerializeField] GameObject sound;
    [SerializeField] GameObject FireLight;

    private AudioSource audio;
    private Light light;

    int FixedGrab = 0;
    // 1 : 마요네즈
    // 2 : 물

    float XScale = 0.494951f;
    float ZScale = 0.5650965f;

    float time = 0.0f;
    float finishTime = 0.0f;
    float volume = 1f;
    float intensity = 1f;

    bool isOnce = true;
    bool AudioCheck = false;

    private void Start() {
        audio = sound.GetComponent<AudioSource>();
        light = FireLight.GetComponent<Light>();
    }

    void Update () {


        time += Time.deltaTime;

        if (IsPressButton() && CheckSection() && isOnce) {
            
            if(GlobalData.ischeck == 1) {
                isOnce = false;
                FixedGrab = GlobalData.ischeck;
                Extinguish();
                GlobalData.SuccessOrFail = true;
                GlobalData.score = time;
                
            }
            else if(GlobalData.ischeck == 2) {
                isOnce = false;
                FixedGrab = GlobalData.ischeck;
                addfire.gameObject.SetActive(true);
                explosion.gameObject.SetActive(true);
                GlobalData.SuccessOrFail = false;
                
            }
            
        }

        if(isOnce == false) {

            finishTime += Time.deltaTime;

            if (FixedGrab == 1) {
                if (finishTime > 7) {
                    SceneManager.LoadScene("FinishScene");
                }
            } else if(FixedGrab == 2) {
                if (finishTime > 4.5) {
                    SceneManager.LoadScene("FinishScene");
                }
            }
        }

        if(AudioCheck == true) {
            volume = volume - 0.0033333f;
            audio.volume = volume;
            
            intensity = intensity - 0.0033333f;
            light.intensity = intensity;
        }

    }

    IEnumerator sleep() {
        yield return new WaitForSeconds(4);
    }

    bool IsPressButton() { //B버튼 눌렸는지 확인 OVRInput.GetDown(OVRInput.RawButton.B)

        if (OVRInput.GetDown(OVRInput.RawButton.B)) {
            Debug.Log("check button");
            return true;
        }
        return false;
    }

    bool CheckSection () { //플레이어 위치가 불앞인지 확인
        bool check = false;
        Vector3 pos;

        float x = -2.244f;// 오브젝트 x 위치값
        float z = 1.868f; ;// 오브젝트 z 위치값
      
        pos = character.transform.position;
        if(pos.x <= x + XScale+5 && pos.x >= x - XScale-5 && pos.z <= z + ZScale+5 && pos.z >= z - ZScale-5) {
            check = true;
        }
        else {
            check = false;
        }
        return check;
    }

    void Extinguish() {
        AudioCheck = true;
        SmallFireParticle.Stop();
        SmallFireSmoke.Stop();
        SmallFireSpark.Stop();
    }
}

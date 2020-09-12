using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FireExtinguishClassRoom : MonoBehaviour {

    [SerializeField] ParticleSystem[] smog = new ParticleSystem[12];

    [SerializeField] GameObject fireExtinguisher;
    [SerializeField] GameObject character;
    [SerializeField] GameObject fire;
    [SerializeField] ParticleSystem SmallFireParticle;
    [SerializeField] ParticleSystem SmallFireSpark;
    [SerializeField] ParticleSystem SmallFireSmoke;
    [SerializeField] GameObject sound;
    [SerializeField] GameObject FireLight;

    private AudioSource audio;
    private Light light;

    float volume = 1f;
    float intensity = 1f;
    float timer = 0.0f;
    float time = 0.0f;

    float X = 3.4883f;
    float Z = 2.9950f;

    bool AudioCheck = false;
    bool IsSuccess = false;
    bool IsIntheSection = false;

    // Use this for initialization
    void Start () {
        for(int i = 0; i < 12; i++) {
            smog[i].Stop();
        }
        
        audio = sound.GetComponent<AudioSource>();
        light = FireLight.GetComponent<Light>();
    }
	
	// Update is called once per frame
	void Update () {

        time += Time.deltaTime;

        Shot();

        if (CheckButton()) {
            Extinguish();
        }

        if (AudioCheck == true) {
            volume = volume - 0.0033333f;
            audio.volume = volume;

            intensity = intensity - 0.0033333f;
            light.intensity = intensity;
        }

        if(IsSuccess) {
            GlobalData.score = time;
            timer += Time.deltaTime;
            if(timer > 8) {
                SceneManager.LoadScene("FinishScene");
                GlobalData.SuccessOrFail = true;
            }
        }
    }

    void Shot() {
        if (OVRInput.GetDown(OVRInput.RawButton.B) && CheckGrab()) {
            if (smog[0].isPlaying == false) {
                for (int i = 0; i < 12; i++) {
                    smog[i].Play();
                }

            }
        }
        else if (OVRInput.GetUp(OVRInput.RawButton.B) && CheckGrab()) {
            if (smog[0].isPlaying == true) {
                for (int i = 0; i < 12; i++) {
                    smog[i].Stop();
                }
            }
        }
    }

    bool CheckButton() {
        if (OVRInput.GetDown(OVRInput.RawButton.B) && CheckGrab()) {
            return true;
        }
        else if (OVRInput.GetUp(OVRInput.RawButton.B) && CheckGrab()) {
            return false;
        }
        return false;
    }

    bool CheckSection() {
        bool check = false;
        Vector3 pos;

        float x = -32.55f;
        float z = -15.68f;

        pos = character.transform.position;
        if (pos.x <= x + X && pos.x >= x - X && pos.z <= z + Z && pos.z >= z - Z) {
            check = true;
        }
        else {
            check = false;
        }
        Debug.Log("check : " + check);
        return check;
        
    }

    bool CheckGrab() {
        if (GlobalData.ischeck == 3) {
            return true;
        }
        else {
            return false;
        }
    }

    void Extinguish() {
        AudioCheck = true;
        IsSuccess = true;
        SmallFireParticle.Stop();
        SmallFireSmoke.Stop();
        SmallFireSpark.Stop();
    }
}

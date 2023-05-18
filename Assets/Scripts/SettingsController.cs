using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsController : MonoBehaviour
{
    AudioSource audioSource;

    void Start()
        {
            //Debug.Log(SceneManager.GetActiveScene().name);

            //audioSource = GetComponent<AudioSource>();
            //Debug.Log(audioSource.volumen);
        }

        void Update()
        {
        /*if(SceneManager.GetActiveScene().name == "MainMenu")
           {
            audioSource.mute = true;
           }*/
        }
    public void Toggle(bool muted){
        if(muted)
        {
            AudioListener.volume = 1;
        }
        else
        {
            AudioListener.volume = 0;
        }
    }
}

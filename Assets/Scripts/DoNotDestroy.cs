using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DoNotDestroy : MonoBehaviour
{
    AudioSource audioSource;

    private void Awake(){
        //Debug.Log(SceneManager.GetActiveScene().name);

        GameObject[] musicObj = GameObject.FindGameObjectsWithTag("GameMusic");
        if(musicObj.Length > 1){
            Destroy(this.gameObject);
        }
        if(SceneManager.GetActiveScene().name == "MainMenu"){
            DontDestroyOnLoad(this.gameObject);
        }



        /*void Start()
        {
            //Debug.Log(SceneManager.GetActiveScene().name);

            //audioSource = GetComponent<AudioSource>();
        }

        /*void Update()
        {
        if(SceneManager.GetActiveScene().name == "MainMenu")
           {
            audioSource.mute = true;
           }
        }*/
    }
}

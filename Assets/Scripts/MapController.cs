using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MapController : MonoBehaviour
{
    private float time = 5f;
    [SerializeField] TMP_Text timeText;

    // Update is called once per frame
    void Update()
    {
        AudioMain.instance.GetComponent<AudioSource>().Pause();

        time -= Time.deltaTime;
        timeText.text = "MISSION START IN " +time.ToString("f0");
        if(time<=0){
            if(UIController.updateLevel==1){
                SceneManager.LoadScene("Scene1");
            }
            if(UIController.updateLevel==2){
                SceneManager.LoadScene("Scene2");
            }
            if(UIController.updateLevel==3){
                SceneManager.LoadScene("Scene3");
            }
            if(UIController.updateLevel==4){
                SceneManager.LoadScene("Scene4");
            }
            if(UIController.updateLevel==5){
                SceneManager.LoadScene("Scene5");
            }
            if(UIController.updateLevel==6){
                SceneManager.LoadScene("Scene6");
            }
        }

    }

    
}

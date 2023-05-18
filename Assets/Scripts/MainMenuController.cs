using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] GameObject credits;
    [SerializeField] GameObject settings;

    public void StartGame(){
        SceneManager.LoadScene("Intro");
    }

    public void Settings(){
        settings.SetActive(true);
    }

    public void BackSettings(){
        settings.SetActive(false);
    }

    public void Credits(){
        credits.SetActive(true);
    }

    public void BackCredits(){
        credits.SetActive(false);
    }
}

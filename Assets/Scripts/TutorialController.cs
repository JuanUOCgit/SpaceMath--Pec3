using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialController : MonoBehaviour
{
    public void Tutorial(){
        SceneManager.LoadScene("Map");
    }
}

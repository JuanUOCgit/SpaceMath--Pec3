using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapPlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(UIController.updateLevel);
        if(UIController.updateLevel==2){
            transform.position = new Vector3(-5.3f,3.7f,0);
        }
        if(UIController.updateLevel==3){
            transform.position = new Vector3(-2.7f,3.7f,0);
        }
        if(UIController.updateLevel==4){
            transform.position = new Vector3(-0.2f,3.7f,0);
        }
        if(UIController.updateLevel==5){
            transform.position = new Vector3(2.35f,3.7f,0);
        }
        if(UIController.updateLevel==6){
            transform.position = new Vector3(4.95f,3.7f,0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(UIController.updateLevel==1){
            if(transform.position.x<=-5.3f){
                transform.position += new Vector3(0.015f,0,0);
            }
        }
        if(UIController.updateLevel==2){
            if(transform.position.x<=-2.7f){
                transform.position += new Vector3(0.015f,0,0);
            }
        }
        if(UIController.updateLevel==3){
            if(transform.position.x<=-0.2f){
                transform.position += new Vector3(0.015f,0,0);
            }
        }
        if(UIController.updateLevel==4){
            if(transform.position.x<=2.35f){
                transform.position += new Vector3(0.015f,0,0);
            }
        }
        if(UIController.updateLevel==5){
            if(transform.position.x<=4.95f){
                transform.position += new Vector3(0.025f,0,0);
            }
        } 
        if(UIController.updateLevel==6){
            if(transform.position.x<=7.35f){
                transform.position += new Vector3(0.015f,0,0);
            }
        } 
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    public GameObject enemyPrefab;

    // Start is called before the first frame update
    void Start()
    {
        if(UIController.updateLevel==1){
            EnemiesPosition1();
        }
        if(UIController.updateLevel==2){
            EnemiesPosition2();
        }
        if(UIController.updateLevel==3){
            EnemiesPosition3();
        }
        if(UIController.updateLevel==4){
            EnemiesPosition4();
        }
        if(UIController.updateLevel==5){
            EnemiesPosition5();
        }
        if(UIController.updateLevel==6){
            EnemiesPosition6();
        }
    }

    public void EnemiesPosition1(){
        for(float j = 1; j<=2; j++){
            float y = 0 + j;
            for(float i = 0; i<=14; i++){
                float x = -7 + i;
                Vector3 position = new Vector3(x,y,0);
                Quaternion rotation = new Quaternion();
                Instantiate(enemyPrefab, position, rotation);
            }
        }
    }

    public void EnemiesPosition2(){
        for(float j = 0; j<=2.75; j++){
            float y = 0 + j;
            for(float i = 0; i<=14; i++){
                float x = -7 + i;
                if(x>=-2 && x<=2){
                    continue;
                }
                else{
                    Vector3 position = new Vector3(x,y,0);
                    Quaternion rotation = new Quaternion();
                    Instantiate(enemyPrefab, position, rotation);
                }
            }
        }
    }

    public void EnemiesPosition3(){
        for(float j = 0; j<=3; j+=0.75f){
            float y = -1 + j;
            for(float i = 0; i<=16; i+=4){
                float x = -8 + i;
                Vector3 position = new Vector3(x,y,0);
                Quaternion rotation = new Quaternion();
                Instantiate(enemyPrefab, position, rotation);

            }
        }
    }

    public void EnemiesPosition6(){
        for(float j = 0; j<=1; j++){
            float y = 1 + j;
            for(float i = 0; i<=14; i++){
                float x = -7 + i;
                if(y == 1 && (x % 2 == 1 || x % 2 == -1) || (y == 2 && x % 2 == 0)) {
                    continue;
                }
                else{
                    Vector3 position = new Vector3(x,y,0);
                    Quaternion rotation = new Quaternion();
                    Instantiate(enemyPrefab, position, rotation);
                }
            }
        }
    }

    public void EnemiesPosition5(){
        for(float i = 0; i<=14; i+=2){
            float x = -7 + i;
            Vector3 position = new Vector3(x,2,0);
            Quaternion rotation = new Quaternion();
            Instantiate(enemyPrefab, position, rotation);
        }
    }


    public void EnemiesPosition4(){
        for(float j = 0; j<=4; j++){
            float y = -2 + j;
            for(float i = 0; i<=14; i++){
                float x = -7 + i;
                if((y == -2 || y == 2) && (x>=-3 && x<=3)){
                    continue;
                }
                if(y == 0 && (x <= -2 ||x >= 2)){
                    continue;
                }
                if((y == -1 || y == 1) && (x <= -4 ||x >= 4)){
                    continue;
                }

                Vector3 position = new Vector3(x,y,0);
                Quaternion rotation = new Quaternion();
                Instantiate(enemyPrefab, position, rotation);
            }
        }
    }

}

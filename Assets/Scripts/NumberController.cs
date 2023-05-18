using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberController : MonoBehaviour
{
    public int ramdonNumber;
    
    public UIController solution;
    public UIController spaceship;

    [SerializeField] private int valueCorrectNum;
    [SerializeField] private int valueCorrectNum2;
    [SerializeField] private int valueWrongNum;

    public UIController check;
    public bool check1;

    public Sprite number0;
    public Sprite number1;
    public Sprite number2;
    public Sprite number3;
    public Sprite number4;
    public Sprite number5;
    public Sprite number6;
    public Sprite number7;
    public Sprite number8;
    public Sprite number9;

    public string n1;
    public string n2;

    public int num1;
    public int num2;

    private AudioSource audioPlayer;
    public AudioClip soundCorrect;
    public AudioClip soundWrong;


    // Start is called before the first frame update
    void Start()
    {
        audioPlayer = GetComponent<AudioSource>();
        check1 = true;
        Destroy(gameObject,10f);
        ramdonNumber = Random.Range(0,10);

        switch (ramdonNumber)
        {
        case 0:
            this.gameObject.GetComponent<SpriteRenderer>().sprite = number0;
            break;
        case 1:
            this.gameObject.GetComponent<SpriteRenderer>().sprite = number1;
            break;
        case 2:
            this.gameObject.GetComponent<SpriteRenderer>().sprite = number2;
            break;
        case 3:
            this.gameObject.GetComponent<SpriteRenderer>().sprite = number3;
            break;
        case 4:
            this.gameObject.GetComponent<SpriteRenderer>().sprite = number4;
            break;
        case 5:
            this.gameObject.GetComponent<SpriteRenderer>().sprite = number5;
            break;
        case 6:
            this.gameObject.GetComponent<SpriteRenderer>().sprite = number6;
            break;
        case 7:
            this.gameObject.GetComponent<SpriteRenderer>().sprite = number7;
            break;
        case 8:
            this.gameObject.GetComponent<SpriteRenderer>().sprite = number8;
            break;
        case 9:
            this.gameObject.GetComponent<SpriteRenderer>().sprite = number9;
            break;
        default:
            break;
        }
        solution = FindObjectOfType<UIController>();
    }

    private void OnCollisionEnter2D(Collision2D collision) {

        if (collision.gameObject.tag == "Spaceship"){
            Destroy(gameObject);
        
            if(solution.sum>9 || solution.res>9 || solution.sec>9 || solution.db>9){

                if(UIController.updateLevel==1){
                    n1 = solution.sum.ToString().Substring(0, 1);
                    n2 = solution.sum.ToString().Substring(1, 1);
                    num1 = int.Parse(n1);
                    num2 = int.Parse(n2);
                }

                if(UIController.updateLevel==2){
                    n1 = solution.res.ToString().Substring(0, 1);
                    n2 = solution.res.ToString().Substring(1, 1);
                    num1 = int.Parse(n1);
                    num2 = int.Parse(n2);
                }

                if(UIController.updateLevel==3){
                    n1 = solution.sec.ToString().Substring(0, 1);
                    n2 = solution.sec.ToString().Substring(1, 1);
                    num1 = int.Parse(n1);
                    num2 = int.Parse(n2);
                }

                if(UIController.updateLevel==4){
                    n1 = solution.db.ToString().Substring(0, 1);
                    n2 = solution.db.ToString().Substring(1, 1);
                    num1 = int.Parse(n1);
                    num2 = int.Parse(n2);
                }

                check = FindObjectOfType<UIController>();

                if(ramdonNumber == num2 && check1 == true){
                    audioPlayer.PlayOneShot(soundCorrect);
                    //soundControl.PlayOneShot(soundCorrect);
                    FindObjectOfType<UIController>().updateOperation2a(num2);
                    check1 = false;
                    FindObjectOfType<UIController>().Sumlives(valueCorrectNum2);
                } 
                else if (ramdonNumber == num1 && check.check2 == true){
                    audioPlayer.PlayOneShot(soundCorrect);
                    FindObjectOfType<UIController>().Sumlives(valueCorrectNum);
                    FindObjectOfType<UIController>().updateOperation2b(num2,num1);
                    FindObjectOfType<UIController>().Victory();
                } 
                else if(ramdonNumber != num1 || ramdonNumber != num2){
                    audioPlayer.PlayOneShot(soundWrong);
                    FindObjectOfType<UIController>().Sumlives(valueWrongNum);
                    if(UIController.updateLives<=0){
                        FindObjectOfType<UIController>().Gameover();
                    }
                }
            }else{
                if(ramdonNumber == solution.sum || ramdonNumber == solution.res || ramdonNumber == solution.sec || ramdonNumber == solution.db){ 

                    audioPlayer.PlayOneShot(soundCorrect);

                    FindObjectOfType<UIController>().Sumlives(valueCorrectNum);
                    FindObjectOfType<UIController>().updateOperation();
                    FindObjectOfType<UIController>().Victory();

                }else{
                    audioPlayer.PlayOneShot(soundWrong);
                    FindObjectOfType<UIController>().Sumlives(valueWrongNum);
                    if(UIController.updateLives<=0){
                        FindObjectOfType<UIController>().Gameover();
                    }
                }
            }     
        }
    }
}

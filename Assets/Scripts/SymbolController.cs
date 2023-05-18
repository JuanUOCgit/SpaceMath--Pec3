using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SymbolController : MonoBehaviour
{
    public int ramdonNumber;
    public int randomSymbol;
    public int randomFigure;
    
    public UIController solution;

    [SerializeField] private int valueCorrectNum;
    [SerializeField] private int valueCorrectNum2;
    [SerializeField] private int valueWrongNum;

    public UIController check;
    public bool check1;
    //public bool check2 = true;

    public Sprite greater_than;
    public Sprite less_than;
    public Sprite equals;
    public Sprite circle;
    public Sprite rectangle;
    public Sprite triangle;
    public Sprite square;
    public Sprite diamond;

    public string n1;
    public string n2;

    public int num1;
    public int num2;

    public string symbol;
    public string figure;

    // Start is called before the first frame update
    void Start()
    {
        check1 = true;
        Destroy(gameObject,10f);
        //ramdonNumber = Random.Range(0,9);

        if(UIController.updateLevel==5){
            randomSymbol = Random.Range(0,2);
            switch (randomSymbol)
                {
                case 0:
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = greater_than;
                    symbol=">";
                    break;
                case 1:
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = less_than;
                    symbol="<";
                    break;
                case 2:
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = equals;
                    symbol="=";
                    break;
                default:
                    break;
                }
        }

        if(UIController.updateLevel==6){
            randomFigure = Random.Range(0,4);
            switch (randomFigure)
            {
            case 0:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = circle;
                figure="Circle";
                break;
            case 1:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = rectangle;
                figure="Rectangle";
                break;
            case 2:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = triangle;
                figure="Triangle";
                break;
            case 3:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = square;
                figure="Square";
                break;
            case 4:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = diamond;
                figure="Diamond";
                break;
            default:
                break;
            }
        }

        solution = FindObjectOfType<UIController>();
        //Debug.Log(symbol);
        //Debug.Log(solution.mm.ToString());
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.tag == "Spaceship"){
            Destroy(gameObject);
            if(symbol == solution.mm.ToString() || figure == solution.fig.ToString()){ 
                FindObjectOfType<UIController>().Sumlives(valueCorrectNum);
                FindObjectOfType<UIController>().updateOperation();
                FindObjectOfType<UIController>().Victory();
            }
            else{
                FindObjectOfType<UIController>().Sumlives(valueWrongNum);
                if(UIController.updateLives<=0){
                    FindObjectOfType<UIController>().Gameover();
                    }
            }
        }   
    }
}


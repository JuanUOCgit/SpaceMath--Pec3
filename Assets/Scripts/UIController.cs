using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class UIController : MonoBehaviour
{
    public static UIController Instance;
    [SerializeField] GameObject gameOver;
    [SerializeField] GameObject victory;
    [SerializeField] GameObject pause;
    [SerializeField] GameObject settings;

    [SerializeField] TMP_Text livesText;
    [SerializeField] TMP_Text coinsText;
    [SerializeField] TMP_Text levelText;
    [SerializeField] TMP_Text timeText;
    [SerializeField] TMP_Text operationText;

    public static int updateCoins = 0;
    public static int updateLives = 3;
    public static int updateLevel = 1;

    public float time;
    public int sum;
    public int res;
    public int sec;
    public char mm;
    public string fig;

    public int db;
    public int n1;
    public int n2;
    public int multi;
    public bool onPause;
    public bool check2;
    int[] secuence = new int[5];
    string[] listFigures = new string[5];


    // Start is called before the first frame update
    void Start()
    {
        Operation();
        livesText.text = "LIVES " + updateLives.ToString();
        coinsText.text = "COINS " + updateCoins.ToString();
        levelText.text = updateLevel.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        timeText.text = time.ToString("f0");
        if(time<=0){
            timeText.text = "0";
            gameOver.SetActive(true);
        }

        if(Input.GetKey(KeyCode.P)){
            Pause();
        }
        if(SceneManager.GetActiveScene().name == "Map"){
            AudioMain.instance.GetComponent<AudioSource>().Pause();
        }
    }

    public void SumCoins(int coins){
        updateCoins += coins;
        coinsText.text = "COINS " + updateCoins.ToString();
    }

    public void Sumlives(int lives){
        switch (lives)
        {
        case 0:
            break;
        case 1:
            updateLives++;
            break;
        case -1:
            updateLives--;
            break;
        default:
            break;
        }
        livesText.text = "LIVES " + updateLives.ToString();

    }

    public void SumLevel(){
        ++updateLevel;
        levelText.text = updateLevel.ToString();
    }

    public void Gameover(){
        Time.timeScale = 0;
        Camera.main.GetComponent<AudioSource>().Stop();
        gameOver.SetActive(true);
    }

    public void Victory(){
        Time.timeScale = 0;
        Camera.main.GetComponent<AudioSource>().Stop();
        victory.SetActive(true);
    }

    public void Settings(){
        settings.SetActive(true);
    }

    public void BackSettings(){
        settings.SetActive(false);
    }

    public void Pause(){
        if(onPause){
            Camera.main.GetComponent<AudioSource>().Pause();
            pause.SetActive(true);
            Time.timeScale = 0;
            onPause = false;
        }else{
            Camera.main.GetComponent<AudioSource>().Play();
            pause.SetActive(false);
            Time.timeScale = 1;
            onPause = true;
        }
    }

    public void Continue(){
        pause.SetActive(false);
        Time.timeScale = 1;
    }

    public void PlayAgain(){
        if(updateLevel==1)
        {
            SceneManager.LoadScene("Scene1");
            updateLevel = 1;
        }
        if(updateLevel==2)
        {
            SceneManager.LoadScene("Scene2");
            updateLevel = 2;
        }
        if(updateLevel==3)
        {
            SceneManager.LoadScene("Scene3");
            updateLevel = 3;
        }
       if(updateLevel==4)
        {
            SceneManager.LoadScene("Scene4");
            updateLevel = 4;
        }
        if(updateLevel==5)
        {
            SceneManager.LoadScene("Scene5");
            updateLevel = 5;
        }
        if(updateLevel==6)
        {
            SceneManager.LoadScene("Scene6");
            updateLevel = 6;
        }
        //SceneManager.LoadScene("Scene1");
        Time.timeScale = 1;
        updateCoins = 0;
        updateLives = 3;
        //updateLevel = 1;
    }

    public void MainMenu(){
        SceneManager.LoadScene("MainMenu");
    }

    public void Intro(){
        SceneManager.LoadScene("Intro");
    }

    public void NextLevel(){
        SumLevel();
        if(updateLevel==7)
        {
            SceneManager.LoadScene("TheEnd");
        }
        else{
            SceneManager.LoadScene("Map");
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            Time.timeScale = 1;
            time = 45;
        }
    }

    public void Operation(){
        if(updateLevel==1)
        {
            n1 = Random.Range(0,9);
            n2 = Random.Range(0,9);
            sum = n1 + n2;
            operationText.text = n1.ToString() + " + " + n2.ToString() + " = ?";            
        }
        if(updateLevel==2)
        {
            do{
                n1 = Random.Range(0,9);
                n2 = Random.Range(0,9);
            }while(n1<n2);
            res = n1 - n2;
            operationText.text = n1.ToString() + " - " + n2.ToString() + " = ?";            
        }
        if(updateLevel==3)
        {
            n1 = Random.Range(0,10);
            multi = Random.Range(1,5);

            for(int i=0; i<=4; i++) {
                secuence[i] = n1;
                n1 += multi;
            }
            sec = secuence[2];
            operationText.text +=  secuence[0] + " - " + secuence[1] + " - ? - " + secuence[3] + " - " +secuence[4];
        }

        if(updateLevel==4)
        {
            n1 = Random.Range(0,10);
            n2 = 2;
            db = n1 * n2;
            operationText.text = "El doble de " + n1.ToString() + " es" +  " ?";            
        }

        if(updateLevel==5)
        {
            n1 = Random.Range(0,50);
            //Debug.Log(n1);
            n2 = Random.Range(0,50);
            //Debug.Log(n2);
            operationText.text +=  n1 + " es" + " ? " + "que "+ n2;
            if(n1 > n2){
                mm = '>';
            }else if(n1 < n2){
                mm = '<';
            }else if(n1 == n2){
                mm = '=';
            }
            //Debug.Log(mm);
        }

        if(updateLevel==6)
        {
            listFigures = new string[5] { "Circle", "Square", "Triangle", "Rectangle", "Diamond"};
            int randomIndex = Random.Range(0, 5);
            fig = listFigures[randomIndex];
            operationText.text +=  fig;
        }
            

    }
    
    public void updateOperation(){

        if(updateLevel==1)
        {
            operationText.text = n1.ToString() + " + " + n2.ToString() + " = " + sum;
        }
        else if(updateLevel==2){
            operationText.text = n1.ToString() + " - " + n2.ToString() + " = " + res;
        }
        else if(updateLevel==3){
            operationText.text +=  secuence[0] + " - " + secuence[1] + " - " + sec + " - " + secuence[3] + " - " +secuence[4];
        }
        else if(updateLevel==4){
            operationText.text = "El doble de " + n1.ToString() + " es " + db;            
        }
        else if(updateLevel==5){
            operationText.text +=  n1 + " es " + mm + " que "+ n2;
        }
    }

    public void updateOperation2a(int number2){
        if(updateLevel==1)
        {
        operationText.text = n1.ToString() + " + " + n2.ToString() + " = ?"+ number2;
        }
        else if(updateLevel==2){
        operationText.text = n1.ToString() + " - " + n2.ToString() + " = ?"+ number2;
        }
        else if(updateLevel==3){
            operationText.text +=  secuence[0] + " - " + secuence[1] + " - " + "?" + number2 + " - " + secuence[3] + " - " +secuence[4];
        }
        else if(updateLevel==4){
            operationText.text = "El doble de " + n1.ToString() + " es " + "?" + number2;            
        }
        else if(updateLevel==5){
            operationText.text +=  n1 + " es " + mm + " que "+ n2;
        }
        check2 = true;
    }

    public void updateOperation2b(int number3, int number2){
        if(updateLevel==1)
        {
        operationText.text = n1.ToString() + " + " + n2.ToString() + " = " + number2 + number3;
        }
        else if(updateLevel==2){
        operationText.text = n1.ToString() + " -" + n2.ToString() + " = " + number2 + number3;
        }
        else if(updateLevel==3){
            operationText.text +=  secuence[0] + " - " + secuence[1] + " - " + number3 + number2 + " - " + secuence[3] + " - " +secuence[4];
        }
        else if(updateLevel==4){
            operationText.text = "El doble de " + n1.ToString() + " es " + number2 + number3;            
        }
        else if(updateLevel==5){
            operationText.text +=  n1 + " es " + mm + " que "+ n2;
        }
    }

}

    




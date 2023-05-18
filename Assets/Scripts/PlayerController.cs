using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 4;
    [SerializeField] private Transform shootStart;
    [SerializeField] private GameObject shoot;

    private bool right;
    private bool left;

    public CharacterController controller;

    public AudioSource soundControl;
    public AudioClip soundShoot;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("right") && transform.position.x < 8){
            transform.position += Time.deltaTime * Vector3.right * speed;
        }
        if(Input.GetKey("left") && transform.position.x > -8){
            transform.position += Time.deltaTime * Vector3.left * speed;
        }
        if(Input.GetKeyDown("space")){
            Shoot();
            soundControl.PlayOneShot(soundShoot);
        } 
        if(right==true && transform.position.x < 8){
            //controller.Move(transform.right*speed*Time.deltaTime);
            transform.position += Time.deltaTime * Vector3.right * speed;

        }
        if(left==true && transform.position.x > -8){
            //controller.Move(-transform.right*speed*Time.deltaTime);
            transform.position += Time.deltaTime * Vector3.left * speed;

        }

        // Input.GetAxis("Horizontal");
        /* Para mover el personaje en el eje horizontal,
        puede usar las flechas del teclado 
        el bloque QWSD
        o un gamepad
        */
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Coin")){
                GetComponent<AudioSource>().Play();
        }
        if (collision.gameObject.CompareTag("power")){
                FindObjectOfType<UIController>().Victory();
        }

    }
    public void Shoot(){
        Instantiate(shoot,shootStart.position,shootStart.rotation);
    }

    public void leftMove(){
        left=true;
    }

    public void rightMove(){
        right=true;
    }

    public void attack(){
        Shoot();
        soundControl.PlayOneShot(soundShoot);
    }

    public void noMove(){
        left=false;
        right=false;
    }

}

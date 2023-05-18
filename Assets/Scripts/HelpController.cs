using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpController : MonoBehaviour
{
    [SerializeField] private GameObject powerUp;
    [SerializeField] List<Transform> wayPoints;
    float speed = 5;
    float distance = 0.2f;
    byte next = 0;

    void Update(){
        transform.position = Vector3.MoveTowards(
            transform.position,
            wayPoints[next].transform.position,
            speed * Time.deltaTime
        );

        if(Vector3.Distance(transform.position,
        wayPoints[next].transform.position)<distance){
            next++;
            Vector3 lTemp = transform.localScale;
            lTemp *= -1;
            transform.localScale = lTemp;
            if(next >= wayPoints.Count)
                next = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        powerUp.SetActive(true);
        powerUp.transform.SetParent(null);
        Destroy(gameObject);
    }


}

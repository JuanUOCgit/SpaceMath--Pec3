using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundBtn : MonoBehaviour
{
    [SerializeField] AudioClip sound;
    // Start is called before the first frame update
    void Start()
    {
        AudioSource.PlayClipAtPoint(sound, Camera.main.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
    }


}


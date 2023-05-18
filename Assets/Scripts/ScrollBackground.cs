using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScrollBackground : MonoBehaviour
{
    Material mt;
    [SerializeField] float speed = 0.025f;
    Vector2 offset;
    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer sp = GetComponent<SpriteRenderer>();
        mt = sp. material;
        offset = mt.mainTextureOffset;
    }

    // Update is called once per frame
    void Update()
    {
        offset.y += Time.deltaTime * speed;
        mt.mainTextureOffset = offset;
    }
}

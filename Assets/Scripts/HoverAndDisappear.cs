using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverAndDisappear : MonoBehaviour
{
    SpriteRenderer sprite;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        /*if(sprite.enabled == true)
        {
            transform.Translate(transform.position.x, 2, transform.position.z);
        }*/
    }
}

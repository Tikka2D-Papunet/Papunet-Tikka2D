using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyDarts : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Dart")
        {
            Destroy(collision.gameObject);
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingTransparentBackground : MonoBehaviour
{
    SpriteRenderer sprite;
    public MouseAndSpawnManager MaSmanager;
    int howManyDartsThrownFetch;

    float counter;
    float maxTime = 1;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        howManyDartsThrownFetch = MaSmanager.GetComponent<MouseAndSpawnManager>().howManyDartsThrown;

        if (howManyDartsThrownFetch == 5)
        {
            if (counter < maxTime)
            {
                counter += Time.deltaTime;
            }
            else
                sprite.enabled = true;
        }
        else
        {
            sprite.enabled = false;
        }
    }
}

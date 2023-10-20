using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndingTransparentBackground : MonoBehaviour
{
    Image backgroundImage;
    public MouseAndSpawnManager MaSmanager;
    int howManyDartsThrownFetch;

    float counter;
    float maxTime = 2;

    private void Start()
    {
        backgroundImage = GetComponent<Image>();
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
            {
                backgroundImage.enabled = true;
            }
        }
        else
        {
            backgroundImage.enabled = false;
        }
    }
}

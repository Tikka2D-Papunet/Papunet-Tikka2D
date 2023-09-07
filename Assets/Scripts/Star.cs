using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    [SerializeField] GameObject mouseAndSpawnManager;
    bool scoreBool1Fetch, scoreBool2Fetch, scoreBool3Fetch, scoreBool4Fetch, scoreBool5Fetch, scoreBool6Fetch,
        scoreBool7Fetch, scoreBool8Fetch, scoreBool9Fetch, scoreBool10Fetch;
    [SerializeField] GameObject star1, star2, star3, star4, star5, star6, star7, star8, star9, star10;
    SpriteRenderer sprite1, sprite2, sprite3, sprite4, sprite5, sprite6, sprite7, sprite8, sprite9, sprite10;

    float maxTime = 1.2f;
    float counter;

    Vector3 childCastPointPositionFetch;

    private void Start()
    {
        sprite1 = star1.GetComponent<SpriteRenderer>();
        sprite2 = star2.GetComponent<SpriteRenderer>();
        sprite3 = star3.GetComponent<SpriteRenderer>();
        sprite4 = star4.GetComponent<SpriteRenderer>();
        sprite5 = star5.GetComponent<SpriteRenderer>();
        sprite6 = star6.GetComponent<SpriteRenderer>();
        sprite7 = star7.GetComponent<SpriteRenderer>();
        sprite8 = star8.GetComponent<SpriteRenderer>();
        sprite9 = star9.GetComponent<SpriteRenderer>();
        sprite10 = star10.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        childCastPointPositionFetch = mouseAndSpawnManager.GetComponent<MouseAndSpawnManager>().childCastpointPosition;

        ScoreBoolFetches();
        Stars();
    }

    void ScoreBoolFetches()
    {
        scoreBool10Fetch = mouseAndSpawnManager.GetComponent<MouseAndSpawnManager>().scoreBool10;
        scoreBool9Fetch = mouseAndSpawnManager.GetComponent<MouseAndSpawnManager>().scoreBool9;
        scoreBool8Fetch = mouseAndSpawnManager.GetComponent<MouseAndSpawnManager>().scoreBool8;
        scoreBool7Fetch = mouseAndSpawnManager.GetComponent<MouseAndSpawnManager>().scoreBool7;
        scoreBool6Fetch = mouseAndSpawnManager.GetComponent<MouseAndSpawnManager>().scoreBool6;
        scoreBool5Fetch = mouseAndSpawnManager.GetComponent<MouseAndSpawnManager>().scoreBool5;
        scoreBool4Fetch = mouseAndSpawnManager.GetComponent<MouseAndSpawnManager>().scoreBool4;
        scoreBool3Fetch = mouseAndSpawnManager.GetComponent<MouseAndSpawnManager>().scoreBool3;
        scoreBool2Fetch = mouseAndSpawnManager.GetComponent<MouseAndSpawnManager>().scoreBool2;
        scoreBool1Fetch = mouseAndSpawnManager.GetComponent<MouseAndSpawnManager>().scoreBool1;
    }

    void Stars()
    {
        if(scoreBool10Fetch)
        {
            star10.transform.position = childCastPointPositionFetch;
            sprite10.enabled = true;
        }
        else
        {
            if(sprite10.enabled == true)
            {
                if(maxTime >= counter)
                {
                    counter += Time.deltaTime;
                }
                else
                {
                    sprite10.enabled = false;
                    counter = 0;
                }
            }
        }
    }
}

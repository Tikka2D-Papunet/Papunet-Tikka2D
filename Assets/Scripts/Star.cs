using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    [SerializeField] GameObject mouseAndSpawnManager;
    bool scoreBool1Fetch, scoreBool2Fetch, scoreBool3Fetch, scoreBool4Fetch, scoreBool5Fetch, scoreBool6Fetch,
        scoreBool7Fetch, scoreBool8Fetch, scoreBool9Fetch, scoreBool10Fetch;
    [SerializeField] GameObject star10;
    int index;
    SpriteRenderer sprite10;

    float maxTime = 1.2f;
    float counter;

    Vector3 childCastPointPositionFetch;

    private void Start()
    {
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
        if(scoreBool1Fetch)
        {
            sprite10.enabled = true;
        }
        else
        {
            if(maxTime >= counter)
            {
                counter += Time.deltaTime;
            }
            else
            {
                sprite10.enabled = false;
            }
        }
    }
}

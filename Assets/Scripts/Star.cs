using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    [SerializeField] GameObject mouseAndSpawnManager;
    bool scoreBool1Fetch, scoreBool2Fetch, scoreBool3Fetch, scoreBool4Fetch, scoreBool5Fetch, scoreBool6Fetch,
        scoreBool7Fetch, scoreBool8Fetch, scoreBool9Fetch, scoreBool10Fetch;
    [SerializeField] GameObject star1, star2, star3, star4, star5, star6, star7, star8, star9, star10;

    Vector3 childCastPointPositionFetch;

    private void Start()
    {
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
            star10 = Instantiate(star10, childCastPointPositionFetch, Quaternion.identity);
        }
        else
        {
            //star10.transform.Translate(transform.position.x, 0.5f, transform.position.z);
        }
    }

    IEnumerator SpawnStar10()
    {
        yield return new WaitForSeconds(0.1f);
    }
}

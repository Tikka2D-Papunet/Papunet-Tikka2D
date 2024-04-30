using System.Collections;
using UnityEngine;
public class Star : MonoBehaviour
{
    [SerializeField] GameObject mouseAndSpawnManager;
    bool scoreBool1Fetch, scoreBool2Fetch, scoreBool3Fetch, scoreBool4Fetch, scoreBool5Fetch, scoreBool6Fetch,
        scoreBool7Fetch, scoreBool8Fetch, scoreBool9Fetch, scoreBool10Fetch;
    [SerializeField] GameObject star1, star2, star3, star4, star5, star6, star7, star8, star9, star10;
    Vector3 childCastPointPositionFetch;
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
            StartCoroutine(SpawnStar10());
        if (scoreBool9Fetch)
            StartCoroutine(SpawnStar9());
        if (scoreBool8Fetch)
            StartCoroutine(SpawnStar8());
        if (scoreBool7Fetch)
            StartCoroutine(SpawnStar7());
        if (scoreBool6Fetch)
            StartCoroutine(SpawnStar6());
        if (scoreBool5Fetch)
            StartCoroutine(SpawnStar5());
        if (scoreBool4Fetch)
            StartCoroutine(SpawnStar4());
        if (scoreBool3Fetch)
            StartCoroutine(SpawnStar3());
        if (scoreBool2Fetch)
            StartCoroutine(SpawnStar2());
        if (scoreBool1Fetch)
            StartCoroutine(SpawnStar1());
    }
    void CreateAndDestroyStar(GameObject newStar)
    {
        transform.position = childCastPointPositionFetch;
        GameObject starPrefab = Instantiate(newStar, transform.position, Quaternion.identity);
        Rigidbody2D rb2d = starPrefab.GetComponent<Rigidbody2D>();
        rb2d.velocity = new Vector2(0, 2);
        Destroy(starPrefab, 1.5f);
    }
    IEnumerator SpawnStar10()
    {
        yield return new WaitForSeconds(0.1f);
        CreateAndDestroyStar(star10);
    }
    IEnumerator SpawnStar9()
    {
        yield return new WaitForSeconds(0.1f);
        CreateAndDestroyStar(star9);
    }
    IEnumerator SpawnStar8()
    {
        yield return new WaitForSeconds(0.1f);
        CreateAndDestroyStar(star8);
    }
    IEnumerator SpawnStar7()
    {
        yield return new WaitForSeconds(0.1f);
        CreateAndDestroyStar(star7);
    }
    IEnumerator SpawnStar6()
    {
        yield return new WaitForSeconds(0.1f);
        CreateAndDestroyStar(star6);
    }
    IEnumerator SpawnStar5()
    {
        yield return new WaitForSeconds(0.1f);
        CreateAndDestroyStar(star5);
    }
    IEnumerator SpawnStar4()
    {
        yield return new WaitForSeconds(0.1f);
        CreateAndDestroyStar(star4);
    }
    IEnumerator SpawnStar3()
    {
        yield return new WaitForSeconds(0.1f);
        CreateAndDestroyStar(star3);
    }
    IEnumerator SpawnStar2()
    {
        yield return new WaitForSeconds(0.1f);
        CreateAndDestroyStar(star2);
    }
    IEnumerator SpawnStar1()
    {
        yield return new WaitForSeconds(0.1f);
        CreateAndDestroyStar(star1);
    }
}
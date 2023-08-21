using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    public static bool controlMouseTargeting = true;
    public static bool automaticMouseTargeting;

    public GameObject crosshair;
    public GameObject manager;

    SpriteRenderer sprite;
    bool invisible = false;
    bool startCounting = false;

    float maxTime = 1.1f;
    float counter = 0;

    int dartsThrown;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        dartsThrown = manager.GetComponent<MouseAndSpawnManager>().howManyDartsThrown;

        if (dartsThrown == 5)
        {
            sprite.enabled = false;
        }

        FollowCrosshair();

        if (Input.GetMouseButtonDown(0))
        {
            invisible = true;
        }

        if (Input.GetMouseButtonUp(0) && invisible)
        {
            startCounting = true;
        }

        if (startCounting)
        {
            sprite.enabled = false;

            if (maxTime > counter)
            {
                counter += Time.deltaTime;
            }
            else
            {
                sprite.enabled = true;
                invisible = false;
                startCounting = false;
                counter = 0;
            }
        }
    }

    void FollowCrosshair()
    {
        transform.position = new Vector3(crosshair.transform.position.x + 4.8f, crosshair.transform.position.y - 4.7f,
    transform.position.z);
    }
}
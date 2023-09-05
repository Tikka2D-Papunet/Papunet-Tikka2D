using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public static bool controlMouseTargeting = true;
    public static bool automaticMouseTargeting;

    float rotateSpeed = 10;
    Vector3 rotateDirection = Vector3.forward;
    float rotateDirectionMaxTime;
    float rotateDirectionCounter = 0;
    public float changeRotateDirection;
    public bool checkRotateDirectionMaxTime = true;

    private void Update()
    {
        if(automaticMouseTargeting)
        {
            if (checkRotateDirectionMaxTime)
            {
                rotateDirectionMaxTime = Random.Range(3, 5);
                checkRotateDirectionMaxTime = false;
            }

            if (rotateDirectionMaxTime > rotateDirectionCounter)
            {
                rotateDirectionCounter += Time.deltaTime;
            }
            else
            {
                changeRotateDirection = Random.Range(0, 2);
                rotateDirectionCounter = 0;
                rotateDirectionMaxTime = 0;
                checkRotateDirectionMaxTime = true;
            }

            if (changeRotateDirection == 0)
            {
                rotateDirection = Vector3.forward;
            }
            else
            {
                rotateDirection = Vector3.back;
            }

            transform.Rotate(rotateDirection, rotateSpeed * Time.deltaTime);
        }
    }
}

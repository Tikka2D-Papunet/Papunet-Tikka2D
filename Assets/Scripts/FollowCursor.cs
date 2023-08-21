using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCursor : MonoBehaviour
{
    public static bool controlMouseTargeting = true;
    public static bool automaticMouseTargeting;

    Vector3 mousePosition;

    float distance; // distance to cursor
    float maxDistance = 1; // max distance to cursor
    float followSpeed = 10; // crosshair cursor follow speed

    private void Update()
    {
        if(controlMouseTargeting)
        {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0;

            distance = Vector3.Distance(mousePosition, transform.position);

            if(distance > maxDistance)
            {
                transform.position = Vector3.Lerp(transform.position, mousePosition, Time.deltaTime * followSpeed);
            }
        }
    }
}

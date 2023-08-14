using System.Collections;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
    public static bool controlMouseTargeting = true;
    public static bool automaticMouseTargeting;

    SpriteRenderer sprite;

    Vector3 mousePosition; // Cursor position

    [Header("Crosshair Movement Speeds")]
    float moveSpeed = 0.001f; // Conrolled crosshair speed
    float controlledMoveSpeed = 100f;
    float originalControlledMoveSpeed;
    float originalSpeed;

    [Header("Crosshair Distances")]
    float distance;
    float maxDistance = 1f;

    public Vector3 direction = Vector3.up; // (0, 0, 0)
    bool running = false;

    [Header("MouseAndSpawnManager Boolean Fetches")]
    public MouseAndSpawnManager manager;
    bool mouseDown;
    bool startThrowCountFetch;

    [Header("Automatic Crosshair Parameters")]
    float speed = 2;
    float rangeX = 5;
    float rangeY = 3;
    Vector2 startPosition;
    float newX;
    float newY;

    //[Header("Controlled Mouse Targeting Parameters")]
    float moveRange = 1;
    Vector3 startPos;
    Vector3 targetPos;
    bool movingRight = true;

    private void Start()
    {
        originalSpeed = moveSpeed;
        if(automaticMouseTargeting)
        {
            startPosition = transform.position;
        }
        sprite = GetComponent<SpriteRenderer>();

        originalControlledMoveSpeed = controlledMoveSpeed;

        startPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void Update()
    {
        if(controlMouseTargeting)
        {
            Debug.Log("controlMouseTargetin p‰‰ll‰");
            ControlMouseTargeting();
        }
        if(automaticMouseTargeting)
        {
            Debug.Log("automaticMouseTargeting p‰‰ll‰");
            AutomaticMouseTargeting();
        }


    }

    void ControlMouseTargeting()
    {
        mouseDown = manager.GetComponent<MouseAndSpawnManager>().mouseDown;
        startThrowCountFetch = manager.GetComponent<MouseAndSpawnManager>().startThrowCount;

        if (startThrowCountFetch)
        {
            sprite.enabled = false;
        }
        else
        {
            sprite.enabled = true;
        }

        if (mouseDown) // When mouse button is pressed down the crosshair movement slows down
        {
            moveSpeed = 0.001f;
            controlledMoveSpeed = 0.005f;
        }
        else
        {
            moveSpeed = originalSpeed;
            controlledMoveSpeed = originalControlledMoveSpeed;
        }

        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;

        distance = Vector3.Distance(mousePosition, transform.position);

        if (distance > maxDistance) // if crosshairs distance to cursor is larger than maxDistance return crosshair back to minimun distance
        {
            transform.position = Vector3.Lerp(transform.position, mousePosition,
                Time.deltaTime * controlledMoveSpeed);
        }


        if (!running) // Changes crosshairs movement direction randomly 1
        {
            StartCoroutine(ChangeDirection());
        }
        transform.position += direction * moveSpeed;
    }

    void AutomaticMouseTargeting()
    {
        mouseDown = manager.GetComponent<MouseAndSpawnManager>().mouseDown;
        startThrowCountFetch = manager.GetComponent<MouseAndSpawnManager>().startThrowCount;

        if (startThrowCountFetch)
        {
            sprite.enabled = false;
        }
        else
        {
            sprite.enabled = true;
        }

        if (mouseDown) // When mouse button is pressed down the crosshair movement slows down
        {
            if (distance > maxDistance) // if crosshairs distance to center of the darts board is larger than maxDistance return crosshair back to minimun distance
            {
                transform.position = Vector3.Lerp(transform.position, transform.position,
                    Time.deltaTime * 10f);
            }

            moveSpeed = 0.0005f;
            if (!running) // Changes crosshairs movement direction randomly 1
            {
                StartCoroutine(ChangeDirection());
            }
            transform.position += direction * moveSpeed;
        }
        else
        {
            moveSpeed = originalSpeed;

            newX = Mathf.PingPong(Time.time * speed, rangeX * 2) - rangeX;
            newY = Mathf.PingPong(Time.time * speed, rangeY * 2) - rangeY;
            transform.position = startPosition + new Vector2(newX, newY);
        }

        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;

        distance = Vector3.Distance(mousePosition, transform.position);
    }

    IEnumerator ChangeDirection()
    {
        // Changes crosshairs movement direction randomly 2

        running = true;
        yield return new WaitForSeconds(0.3f);
        direction.x = Random.Range(-1, 2);
        direction.y = Random.Range(-1, 2);
        running = false;
    }
}

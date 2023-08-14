using UnityEngine;

public class Dart : MonoBehaviour
{
    public static bool automaticThrowForce = true;
    public static bool controlledThrowForce;

    Rigidbody2D rb2d;
    public bool flying = false;
    bool throwed = false;

    float maxTime = 0.5f;
    public float timer = 0;

    public Camera cam;
    public MouseAndSpawnManager manager;
    float throwForce;
    //float lateralForce = 3.5f;
    float lateralForce = 7f;
    float lateralDirection; // don't delete
    float shrinkinSpeed = 0.5f; // Dart shrinking speed after throwed


    [Header("Dart Hit Parameters")]
    public Transform castPoint;
    public int score;
    public float checkIfHitCounter;

    [Header("Public Bools")]
    public bool checkDistance = false;

    [Header("Fetching Crosshair")]
    public GameObject crosshair;

    [Header("Fetch if Game Has Ended")]
    int DartsThrown;

    [SerializeField] SpriteRenderer sprite;

    [Header("Fetch Current Dart Index")]
    int currentDartIndex;

    public bool enoughPowerOnThrowFetch;

    public Transform GetChildObjectTransform()
    {
        return castPoint;
    }

    private void Awake()
    {
        cam = FindObjectOfType<Camera>();
        manager = FindObjectOfType<MouseAndSpawnManager>();
        crosshair = GameObject.FindGameObjectWithTag("Crosshair");
    }

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.bodyType = RigidbodyType2D.Kinematic;
    }

    public void Update()
    {
        DartsThrown = manager.GetComponent<MouseAndSpawnManager>().howManyDartsThrown;
        enoughPowerOnThrowFetch = manager.GetComponent<MouseAndSpawnManager>().enoughPowerOnThrow;

        if (DartsThrown == 5)
        {
            Invoke("DestroyDart", 2);
        }

        if (crosshair == null)
        {
            crosshair = GameObject.FindGameObjectWithTag("Crosshair");
        }

        throwForce = manager.GetComponent<MouseAndSpawnManager>().throwForce;

        if (Input.GetMouseButtonDown(0))
        {
            Fly();
        }

        if (Input.GetMouseButtonUp(0) && flying)
        {
            ThrowDart();
        }

        if (throwed)
        {
            if (maxTime > timer)
            {
                timer += Time.deltaTime;
                transform.localScale -= new Vector3(shrinkinSpeed * Time.deltaTime,
                    shrinkinSpeed * Time.deltaTime, 0);
            }
            else if (enoughPowerOnThrowFetch | automaticThrowForce)
            {
                rb2d.bodyType = RigidbodyType2D.Static;
                rb2d.AddForce(Vector2.zero);
                checkDistance = true;
            }
        }
        else
        {
            Vector2 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(crosshair.transform.position.x + 4, crosshair.transform.position.y - 2,
                transform.position.z);
        }

        Debug.Log("Throw Force: " + throwForce);
    }

    void Fly()
    {
        flying = true;
        throwForce = 0;
    }

    void ThrowDart()
    {
        flying = false;
        lateralDirection = Random.Range(-1, 1);
        rb2d.velocity = new Vector2(-lateralForce, rb2d.velocity.y);
        throwed = true;
    }

    void DestroyDart()
    {
        sprite.enabled = false;
    }
}

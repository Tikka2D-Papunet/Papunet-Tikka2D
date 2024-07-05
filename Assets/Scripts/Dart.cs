using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Dart : MonoBehaviour
{
    public static bool automaticThrowForce = true;
    public static bool controlledThrowForce;
    [HideInInspector] public Rigidbody2D rb2d;
    public bool throwed = false;
    float maxTime = 0.5f;
    public float timer = 0;
    public Camera cam;
    public MouseAndDartManager manager;
    float throwForce;
    //float lateralForce = 7f;
    float lateralDirection; // don't delete
    //float shrinkinSpeed = 0.6f; // Dart shrinking speed after throwed 0.6f original
    [Header("Dart Hit Parameters")]
    public Transform castPoint;
    public int score;
    public float checkIfHitCounter;
    [Header("Public Bools")]
    [Header("Fetching Crosshair")]
    public GameObject crosshair;
    [Header("Fetch if Game Has Ended")]
    int DartsThrown;
    [SerializeField] SpriteRenderer sprite;
    public GameObject childObject;
    [HideInInspector] public SpriteRenderer childSprite;
    public GameObject childObjectAnimator;
    [HideInInspector] public Animator childAnim;
    [Header("Fetch Current Dart Index")]
    int currentDartIndex;
    public bool enoughPowerOnThrowFetch;
    [SerializeField] InputManager inputManager;
    public bool canThrowFetch;
    [SerializeField] public GameObject childShadow;
    [HideInInspector] public SpriteRenderer shadowSprite;
    int changeThrowAnimation;
    bool releaseMouseFetch; // from MouseAndDartManager -script
    public Transform GetChildObjectTransform()
    {
        return castPoint;
    }
    private void Awake()
    {
        cam = FindObjectOfType<Camera>();
        manager = FindObjectOfType<MouseAndDartManager>();
        crosshair = GameObject.FindGameObjectWithTag("Crosshair");
    }
    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.bodyType = RigidbodyType2D.Kinematic;
        childSprite = childObject.GetComponent<SpriteRenderer>();
        childAnim = childObjectAnimator.GetComponent<Animator>();
        shadowSprite = childShadow.GetComponent<SpriteRenderer>();
        inputManager = FindObjectOfType<InputManager>();
    }
    public void Update()
    {
        if (!throwed)
        {
            Vector2 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(crosshair.transform.position.x + 3.4f, crosshair.transform.position.y - 0.75f,
                transform.position.z);
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
    void DestroyDart()
    {
        childSprite.enabled = false;
        shadowSprite.enabled = false;
    }
}
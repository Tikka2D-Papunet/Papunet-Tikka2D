using UnityEngine;
using System.Collections;
using System.Collections.Generic;
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
    public bool checkDistance = false;
    [Header("Fetching Crosshair")]
    public GameObject crosshair;
    [Header("Fetch if Game Has Ended")]
    int DartsThrown;
    [SerializeField] SpriteRenderer sprite;
    public GameObject childObject;
    [HideInInspector] public SpriteRenderer childSprite;
    public GameObject childObjectAnimator;
    Animator childAnim;
    [Header("Fetch Current Dart Index")]
    int currentDartIndex;
    public bool enoughPowerOnThrowFetch;
    bool dontThrowManagerFetch; // fetching dont throw from MouseAndSpawnManager that fetches original dont throw from ListenButton
    [SerializeField] GameObject childShadow;
    SpriteRenderer shadowSprite;
    int changeThrowAnimation;
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
    }
    public void Update()
    {
        DartsThrown = manager.GetComponent<MouseAndDartManager>().howManyDartsThrown;
        enoughPowerOnThrowFetch = manager.GetComponent<MouseAndDartManager>().enoughPowerOnThrow;
        dontThrowManagerFetch = manager.GetComponent<MouseAndDartManager>().dontThrowFetch;
        if (DartsThrown == 5)
            Invoke("DestroyDart", 2);
        if (crosshair == null)
            crosshair = GameObject.FindGameObjectWithTag("Crosshair");
        throwForce = manager.GetComponent<MouseAndDartManager>().throwForce;
        if(!dontThrowManagerFetch)
        {
            if (Input.GetMouseButtonDown(0))
                Fly();

            if (Input.GetMouseButtonUp(0) && flying)
                ThrowDart();
        }
        if (throwed)
        {
            Invoke("ShowDart", 0.2f);
            changeThrowAnimation = Random.Range(0, 1);
            if(changeThrowAnimation == 0)
                childAnim.SetTrigger("Throw1");
            else
                childAnim.SetTrigger("Throw2");

            if (maxTime > timer)
            {
                timer += Time.deltaTime;
                checkDistance = true;
            }
            else if (enoughPowerOnThrowFetch | automaticThrowForce && checkDistance)
            {
                rb2d.bodyType = RigidbodyType2D.Static;
                rb2d.AddForce(Vector2.zero);
                MouseAndDartManager.Instance.CalculateDistance();
                checkDistance = false;
                StartCoroutine(ChangeLayerOrder());
                StartCoroutine(ShowShadow());
            }
            else
            {
                checkDistance = false;
                EndingScript.Instance.IfEndingConditionsAreMet(MouseAndDartManager.Instance.howManyDartsThrown, MouseAndDartManager.Instance.score);
                StartCoroutine(ChangeLayerOrder());
            }
        }
        else
        {
            Vector2 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(crosshair.transform.position.x + 3.4f, crosshair.transform.position.y - 0.75f,
                transform.position.z);
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
    void Fly()
    {
        flying = true;
        throwForce = 0;
    }
    void ThrowDart()
    {
        flying = false;
        lateralDirection = Random.Range(6.5f, 7.5f);
        rb2d.velocity = new Vector2(-lateralDirection, rb2d.velocity.y);
        throwed = true;
    }
    IEnumerator ChangeLayerOrder()
    {
        yield return new WaitForSeconds(0.4f);
        childSprite.sortingOrder = 3;
    }
    IEnumerator ShowShadow()
    {
        yield return new WaitForSeconds(0.08f);
        shadowSprite.sortingOrder = 2;
    }
    void DestroyDart()
    {
        childSprite.enabled = false;
        shadowSprite.enabled = false;
    }
    void ShowDart()
    {
        childSprite.enabled = true;
    }
}
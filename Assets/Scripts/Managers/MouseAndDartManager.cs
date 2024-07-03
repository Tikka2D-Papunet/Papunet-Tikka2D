using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;
public class MouseAndDartManager : MonoBehaviour
{
    #region Singleton
    public static MouseAndDartManager Instance;
    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(this);
        else
            Instance = this;
    }
    #endregion
    public static bool automaticThrowForce = true;
    public static bool controlledThrowForce;
    public Camera cam;
    Vector2 mousePos;
    public float throwForce;
    [Header("Dartprefab Parameters")]
    public GameObject dartPrefab;
    public int currentDartIndex = 0;
    public Dart dart;
    bool flying;
    float maxForce = 15;
    float forceFactor = 8;
    public Energybar energybar;
    [SerializeField] float maxEnergy = 100;
    public float currentEnergy;
    public bool increaseEnergy = false;
    public bool increasingForce = true;
    public bool mouseDown = false;
    [Header("Scoring")]
    [SerializeField] public int score = 0;
    [SerializeField] StarSpawnManager starSpawnManager;
    [SerializeField] EndingScript endingScript;
    [Header("UI Score")]
    public TextMeshProUGUI scoreText;
    [Header("Public Bools")]
    bool checkDistance;
    public GameObject dartBoardCenter;
    public GameObject dartObject;
    public GameObject testDistance;
    [Header("Timer between throws")]
    float maxThrowTime = 1;
    float throwCounter = 0;
    public bool startThrowCount = false;
    [Header("Spawn And Find New Darts Booleans")]
    bool pressMouse = false;
    bool releaseMouse = false;
    public int howManyDartsThrown = 0; // Counter for dart throws.
    public bool enoughPowerOnThrow;
    float lateralDirection;
    public bool showEnergybar = false; // shows energybar if you press mouse
    public Transform childTransform;
    public Vector3 childCastpointPosition;
    public GameObject handAnim; // käsiii hand animations
    [SerializeField] AudioClip ähSound;
    [SerializeField] AudioClip hitSound;
    [SerializeField] AudioClip throwPastSound;
    [SerializeField] AudioClip wauSound;
    bool isHitSoundPlayed = false;
    bool isThrownPastSoundPlayed = false;
    bool isWauSoundPlayed = false;
    public ListenButton listenButton;
    [SerializeField] InputManager inputManager;
    public bool canThrowFetch; // from InputManager
    private void Start()
    {
        energybar = FindObjectOfType<Energybar>();
        energybar.SetMaxEnergy(maxEnergy);
        currentEnergy = 100;
        cam = FindObjectOfType<Camera>();
        Instantiate(dartPrefab);
        dart = FindObjectOfType<Dart>();
        dartObject = GameObject.FindGameObjectWithTag("Dart");
        listenButton = FindObjectOfType<ListenButton>();
        handAnim.GetComponent<Animator>();
        starSpawnManager.GetComponent<StarSpawnManager>();
        endingScript.GetComponent<EndingScript>();
        inputManager.GetComponent<InputManager>();
    }
    private void Update()
    {
        flying = dart.GetComponent<Dart>().readyToThrow;
        checkDistance = dart.GetComponent<Dart>().checkDistance;
        float distance = Vector3.Distance(testDistance.transform.position, dartBoardCenter.transform.position);
        canThrowFetch = inputManager.canThrow;
        MouseLogic();
        EnergyBarLogic();
    }

    void EnergyBarLogic()
    {
        if (controlledThrowForce)
        {
            if (increasingForce == false)
            {
                if (increaseEnergy)
                    currentEnergy += 80 * Time.deltaTime;
                else
                    currentEnergy = 100;
            }
            else
            {
                if (increaseEnergy)
                    currentEnergy -= 80 * Time.deltaTime;
                else
                    currentEnergy = 100;
            }
            energybar.SetEnergy(currentEnergy);
        }
    }
    public void CalculateDistance()
    {
        childTransform = dart.GetChildObjectTransform();
        childCastpointPosition = childTransform.position;
        float distance = Vector3.Distance(childCastpointPosition, dartBoardCenter.transform.position);
        if (distance < 4.851f)
        {
            SoundManager.Instance.PlaySound(hitSound);
            if (distance < 0.475f)
            {
                ScoreAndSpawnStar(10);
                SoundManager.Instance.PlaySound(wauSound);
            }
            else if (distance > 0.475f && distance < 0.966f)
                ScoreAndSpawnStar(9);
            else if (distance > 0.966f && distance < 1.442f)
                ScoreAndSpawnStar(8);
            else if (distance > 1.442f && distance < 1.95f)
                ScoreAndSpawnStar(7);
            else if (distance > 1.95f && distance < 2.421f)
                ScoreAndSpawnStar(6);
            else if (distance > 2.421f && distance < 2.912f)
                ScoreAndSpawnStar(5);
            else if (distance > 2.912f && distance < 3.394f)
                ScoreAndSpawnStar(4);
            else if (distance > 3.394f && distance < 3.885f)
                ScoreAndSpawnStar(3);
            else if (distance > 3.885f && distance < 4.363f)
                ScoreAndSpawnStar(2);
            else if (distance > 4.363f && distance < 4.851f)
                ScoreAndSpawnStar(1);
            scoreText.text = score + " pistettä";
        }
        else
            SoundManager.Instance.PlaySound(throwPastSound);
        endingScript.IfEndingConditionsAreMet(howManyDartsThrown, score);
    }
    void ScoreAndSpawnStar(int num)
    {
        score += num;
        starSpawnManager.StarSpawner(num);
    }
    void FindNewDart()
    {
        dart = FindObjectOfType<Dart>();
    }
    public void IncreaseForce()
    {
        if (controlledThrowForce)
        {
            if (increasingForce)
            {
                if (currentEnergy > 0)
                {
                    if (throwForce < maxForce)
                        throwForce += forceFactor * Time.deltaTime;
                }
                else
                    increasingForce = false;
            }
            else
            {
                if (currentEnergy < 100)
                {
                    if (throwForce > 0)
                        throwForce -= forceFactor * Time.deltaTime;
                }
                else
                    increasingForce = true;
            }
        }
        else
            throwForce = 4.0f;
    }

    void MouseLogic() // throwing darts by using mouse (left click) or keyboard (enter) input
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(mousePos.x + 2, mousePos.y, transform.position.z);
        if (howManyDartsThrown < 5)
        {
            if (startThrowCount == true)
            {
                if (throwCounter < maxThrowTime)
                    throwCounter += Time.deltaTime;
                else
                {
                    throwCounter = 0;
                    startThrowCount = false;
                }
            }
            if (startThrowCount == false)
            {
                if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Return) && releaseMouse == false && canThrowFetch == true)
                {
                    if (controlledThrowForce)
                        showEnergybar = true;
                    mouseDown = true;
                    throwForce = 0;
                    increaseEnergy = true;
                    pressMouse = true;
                }
                if (Input.GetMouseButton(0) || Input.GetKey(KeyCode.Return) && flying && releaseMouse == false && canThrowFetch == true)
                    IncreaseForce();
                if (Input.GetMouseButtonUp(0) ||Input.GetKeyUp(KeyCode.Return) && pressMouse && canThrowFetch == true)
                {
                    handAnim.GetComponent<Animator>().SetTrigger("Throw");
                    SoundManager.Instance.PlaySound(ähSound);
                    dart.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                    dart.GetComponent<Rigidbody2D>().AddForce(Vector2.up * throwForce, ForceMode2D.Impulse);
                    increaseEnergy = false;
                    increasingForce = true;
                    mouseDown = false;
                    startThrowCount = true;
                    releaseMouse = true;
                    howManyDartsThrown++;
                    currentDartIndex++;
                    if (currentEnergy < 80)
                        enoughPowerOnThrow = true;
                    if (controlledThrowForce)
                        showEnergybar = false;
                    HowManyThrowsLeft.Instance.HowManyDartsThrown();
                    //StartCoroutine(CountDartLayerOrders());
                }
            }
            if (pressMouse && releaseMouse && startThrowCount == false)
            {
                Invoke("Throw", 0.1f);
                Invoke("FindNewDart", 0.1f);
                pressMouse = false;
                releaseMouse = false;
                enoughPowerOnThrow = false;
            }
        }
    }
    IEnumerator CountDartLayerOrders()
    {
        yield return new WaitForSeconds(0.08f);
        GameObject[] throwedDarts = GameObject.FindGameObjectsWithTag("Dart");
        List<GameObject> dartObjectListY = new List<GameObject>(throwedDarts);
        dartObjectListY.Sort((a, b) => a.transform.position.y.CompareTo(b.transform.position.y));
        for (int i = 0; i < dartObjectListY.Count; i++)
        {
            if (dartObjectListY[i] != null)
                dartObjectListY[i].GetComponent<Dart>().childSprite.sortingOrder = 8 - i;
        }
    }
    void Throw()
    {
        GameObject dart = Instantiate(dartPrefab, mousePos, Quaternion.identity);
    }
}
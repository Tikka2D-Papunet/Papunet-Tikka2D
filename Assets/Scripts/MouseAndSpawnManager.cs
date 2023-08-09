using UnityEngine;
using TMPro;

public class MouseAndSpawnManager : MonoBehaviour
{
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
    float forceFactor = 5;

    public Energybar energybar;
    [SerializeField] float maxEnergy = 100;
    public float currentEnergy;
    public bool increaseEnergy = false;

    bool increasingForce = true;

    float spinForce = 100f;

    public bool mouseDown = false;

    [Header("Scoring")]
    [SerializeField] public int score = 0;
    bool scoreBool1 = false;
    bool scoreBool2 = false;
    bool scorebool3 = false;
    bool scoreBool4 = false;
    bool scoreBool5 = false;
    bool scoreBool6 = false;
    bool scoreBool7 = false;
    bool scoreBool8 = false;
    bool scoreBool9 = false;
    bool scoreBool10 = false;
    float scoreCounter1;
    float scoreCounter2;
    float scoreCounter3;
    float scoreCounter4;
    float scoreCounter5;
    float scoreCounter6;
    float scoreCounter7;
    float scoreCounter8;
    float scoreCounter9;
    float scoreCounter10;
    float scoreMaxTime = 0.00005f;

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

    float lateralForce = 3.5f;
    float lateralDirection;

    private void Awake()
    {
        energybar = FindObjectOfType<Energybar>();
        energybar.SetMaxEnergy(maxEnergy);
        currentEnergy = 0;
        cam = FindObjectOfType<Camera>();
    }

    private void Start()
    {
        Instantiate(dartPrefab);
        dart = FindObjectOfType<Dart>();
        dartObject = GameObject.FindGameObjectWithTag("Dart");
    }

    private void Update()
    {
        flying = dart.GetComponent<Dart>().flying;
        checkDistance = dart.GetComponent<Dart>().checkDistance;

        float distance = Vector3.Distance(testDistance.transform.position, dartBoardCenter.transform.position);
        Debug.Log("Distance test: " + distance);

        MouseLogic();

        EnergyBarLogic();

        Debug.Log("throwForce MouseAndSpawn: " + throwForce);

        CalculateDistance();
    }

    void EnergyBarLogic()
    {
        if (controlledThrowForce)
        {
            if (increasingForce)
            {
                if (increaseEnergy)
                {
                    currentEnergy += 80 * Time.deltaTime;
                }
                else
                {
                    currentEnergy = 0;
                }
            }
            else
            {
                if (increaseEnergy)
                {
                    currentEnergy -= 80 * Time.deltaTime;
                }
                else
                {
                    currentEnergy = 0;
                }
            }


            energybar.SetEnergy(currentEnergy);
        }
    }

    void CalculateDistance()
    {
        if (checkDistance)
        {
            float distance = Vector3.Distance(dart.transform.position, dartBoardCenter.transform.position);
            Debug.Log("Distance: " + distance);
            if (distance != 100)
            {
                if (distance < 0.52f)
                {
                    scoreBool1 = true;
                }
                else if (distance > 0.52f && distance < 1.014f)
                {
                    scoreBool2 = true;
                }
                else if (distance > 1.014f && distance < 1.49f)
                {
                    scorebool3 = true;
                }
                else if (distance > 1.49f && distance < 1.99f)
                {
                    scoreBool4 = true;
                }
                else if (distance > 1.99f && distance < 2.485f)
                {
                    scoreBool5 = true;
                }
                else if (distance > 2.485f && distance < 2.98f)
                {
                    scoreBool6 = true;
                }
                else if (distance > 2.98f && distance < 3.46f)
                {
                    scoreBool7 = true;
                }
                else if (distance > 3.46f && distance < 3.97f)
                {
                    scoreBool8 = true;
                }
                else if (distance > 3.97f && distance < 4.46f)
                {
                    scoreBool9 = true;
                }
            }
        }

        if (scoreBool1)
        {
            if (scoreCounter1 < scoreMaxTime)
            {
                scoreCounter1 += Time.deltaTime;
                score += 10;
                scoreText.text = score + " pistettä";
            }
            else
            {
                scoreBool1 = false;
            }
        }
        else
        {
            scoreCounter1 = 0;
        }

        if (scoreBool2)
        {
            if (scoreCounter2 < scoreMaxTime)
            {
                scoreCounter2 += Time.deltaTime;
                score += 9;
                scoreText.text = score + " pistettä";
            }
            else
            {
                scoreBool2 = false;
            }
        }
        else
        {
            scoreCounter2 = 0;
        }

        if (scorebool3)
        {
            if (scoreCounter3 < scoreMaxTime)
            {
                scoreCounter3 += Time.deltaTime;
                score += 8;
                scoreText.text = score + " pistettä";
            }
            else
            {
                scorebool3 = false;
            }
        }
        else
        {
            scoreCounter3 = 0;
        }

        if (scoreBool4)
        {
            if (scoreCounter4 < scoreMaxTime)
            {
                scoreCounter4 += Time.deltaTime;
                score += 7;
                scoreText.text = score + " pistettä";
            }
            else
            {
                scoreBool4 = false;
            }
        }
        else
        {
            scoreCounter4 = 0;
        }

        if (scoreBool5)
        {
            if (scoreCounter5 < scoreMaxTime)
            {
                scoreCounter5 += Time.deltaTime;
                score += 6;
                scoreText.text = score + " pistettä";
            }
            else
            {
                scoreBool5 = false;
            }
        }
        else
        {
            scoreCounter5 = 0;
        }

        if (scoreBool6)
        {
            if (scoreCounter6 < scoreMaxTime)
            {
                scoreCounter6 += Time.deltaTime;
                score += 5;
                scoreText.text = score + " pistettä";
            }
            else
            {
                scoreBool6 = false;
            }
        }
        else
        {
            scoreCounter6 = 0;
        }

        if (scoreBool7)
        {
            if (scoreCounter7 < scoreMaxTime)
            {
                scoreCounter7 += Time.deltaTime;
                score += 4;
                scoreText.text = score + " pistettä";
            }
            else
            {
                scoreBool7 = false;
            }
        }
        else
        {
            scoreCounter7 = 0;
        }

        if (scoreBool8)
        {
            if (scoreCounter8 < scoreMaxTime)
            {
                scoreCounter8 += Time.deltaTime;
                score += 3;
                scoreText.text = score + " pistettä";
            }
            else
            {
                scoreBool8 = false;
            }
        }
        else
        {
            scoreCounter8 = 0;
        }

        if (scoreBool9)
        {
            if (scoreCounter9 < scoreMaxTime)
            {
                scoreCounter9 += Time.deltaTime;
                score += 2;
                scoreText.text = score + " pistettä";
            }
            else
            {
                scoreBool9 = false;
            }
        }
        else
        {
            scoreCounter9 = 0;
        }

        if (scoreBool10)
        {
            if (scoreCounter10 < scoreMaxTime)
            {
                scoreCounter10 += Time.deltaTime;
                score += 1;
                scoreText.text = score + " pistettä";
            }
            else
            {
                scoreBool10 = false;
            }
        }
        else
        {
            scoreCounter10 = 0;
        }
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
                if (currentEnergy < 100)
                {
                    if (throwForce < maxForce)
                    {
                        throwForce += forceFactor * Time.deltaTime;
                    }
                }
                else
                {
                    increasingForce = false;
                }
            }
            else
            {
                if (currentEnergy > 0)
                {
                    if (throwForce > 0)
                    {
                        throwForce -= forceFactor * Time.deltaTime;
                    }
                }
                else
                {
                    increasingForce = true;
                }
            }
        }
        else
        {
            throwForce = 3;
        }
    }

    void MouseLogic()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(mousePos.x + 2, mousePos.y, transform.position.z);

        if (howManyDartsThrown < 5)
        {
            if (startThrowCount == true)
            {
                if (throwCounter < maxThrowTime)
                {
                    throwCounter += Time.deltaTime;
                }
                else
                {
                    throwCounter = 0;
                    startThrowCount = false;
                }
            }

            if (startThrowCount == false)
            {
                if (Input.GetMouseButtonDown(0) && releaseMouse == false)
                {
                    mouseDown = true;
                    throwForce = 0;
                    increaseEnergy = true;
                    pressMouse = true;
                }

                if (Input.GetMouseButton(0) && flying && releaseMouse == false)
                {
                    IncreaseForce();
                }

                if (Input.GetMouseButtonUp(0) && pressMouse)
                {
                    dart.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                    float randomSpin = Random.Range(-spinForce, spinForce);
                    dart.transform.Rotate(0, 0, randomSpin);
                    dart.GetComponent<Rigidbody2D>().AddForce(Vector2.up * throwForce, ForceMode2D.Impulse);

                    increaseEnergy = false;
                    increasingForce = true;

                    mouseDown = false;
                    startThrowCount = true;
                    releaseMouse = true;
                    howManyDartsThrown++;
                    currentDartIndex++;
                    if (currentEnergy > 20)
                    {
                        enoughPowerOnThrow = true;
                    }
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

    void Throw()
    {
        GameObject dart = Instantiate(dartPrefab, mousePos, Quaternion.identity);
    }

    void TakeDamage(float damage)
    {
        currentEnergy -= damage;

        energybar.SetEnergy(currentEnergy);
    }

    void AddHealth(float health)
    {
        currentEnergy += health;

        energybar.SetEnergy(currentEnergy);
    }
}

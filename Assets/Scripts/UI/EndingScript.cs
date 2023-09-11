using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class EndingScript : MonoBehaviour
{
    public MouseAndSpawnManager MaSmanager;
    //public static int score;
    public int score;
    public int publicScore;
    int howManyDartsThrown;
    public GameObject[] endings;
    int index;
    public TextMeshProUGUI scoreText1;
    public TextMeshProUGUI scoreText2;
    public TextMeshProUGUI scoreText3;
    public TextMeshProUGUI scoreText4;
    public Button playAgain;
    public Button backToMenu;

    float counter;
    float maxTime = 2;

    private void Start()
    {
        publicScore = score;
    }

    private void Update()
    {
        howManyDartsThrown = MaSmanager.GetComponent<MouseAndSpawnManager>().howManyDartsThrown;
        score = MaSmanager.GetComponent<MouseAndSpawnManager>().score;

        if(howManyDartsThrown == 5)
        {
            if(counter < maxTime)
            {
                counter += Time.deltaTime;
            }
            else
            {
                playAgain.gameObject.SetActive(true);
                backToMenu.gameObject.SetActive(true);

                if (score < 25)
                {
                    endings[0].SetActive(isActiveAndEnabled);
                    scoreText1.text = "SAIT YHTEENSÄ " + score + " PISTETTÄ.";
                }
                else if (score >= 25 && score < 35)
                {
                    endings[1].SetActive(isActiveAndEnabled);
                    scoreText2.text = "SAIT YHTEENSÄ " + score + " PISTETTÄ.";
                }
                else if (score > 34 && score < 45)
                {
                    endings[2].SetActive(isActiveAndEnabled);
                    scoreText3.text = "SAIT YHTEENSÄ " + score + " PISTETTÄ.";
                }
                else if (score > 44)
                {
                    endings[3].SetActive(isActiveAndEnabled);
                    scoreText4.text = "SAIT YHTEENSÄ " + score + " PISTETTÄ.";
                }
            }
        }
    }

    public void LoadGameAgain()
    {
        SceneManager.LoadScene("Dart");
    }

    public void GoBackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}

using UnityEngine;
using TMPro;
public class CloseScoreText : MonoBehaviour
{
    public MouseAndSpawnManager MaSmanager;
    int dartThrowsCount;
    public TextMeshProUGUI scoreText;
    float maxTime = 2;
    float counter = 0;
    private void Update()
    {
        dartThrowsCount = MaSmanager.GetComponent<MouseAndSpawnManager>().howManyDartsThrown;
        if(dartThrowsCount > 4)
        {
            if(counter < maxTime)
                counter += Time.deltaTime;
            else
                scoreText.enabled = false;
        }
    }
}
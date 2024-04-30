using UnityEngine;
using UnityEngine.UI;
public class HowManyThrowsLeft : MonoBehaviour
{
    public MouseAndSpawnManager manager;
    int howManyDartsThrownFetch; // fetch from MouseAndSpawnManager -script
    [SerializeField] GameObject dart1;
    [SerializeField] GameObject dart2;
    [SerializeField] GameObject dart3;
    [SerializeField] GameObject dart4;
    [SerializeField] GameObject dart5;
    private void Update()
    {
        howManyDartsThrownFetch = manager.GetComponent<MouseAndSpawnManager>().howManyDartsThrown;
        if(howManyDartsThrownFetch == 1)
        {
            Image childImage = dart1.GetComponent<Image>();
            childImage.enabled = false;
        }
        if (howManyDartsThrownFetch == 2)
        {
            Image childImage = dart2.GetComponent<Image>();
            childImage.enabled = false;
        }
        if (howManyDartsThrownFetch == 3)
        {
            Image childImage = dart3.GetComponent<Image>();
            childImage.enabled = false;
        }
        if (howManyDartsThrownFetch == 4)
        {
            Image childImage = dart4.GetComponent<Image>();
            childImage.enabled = false;
        }
        if (howManyDartsThrownFetch == 5)
        {
            Image childImage = dart5.GetComponent<Image>();
            childImage.enabled = false;
        }
    }
}
using UnityEngine;
using UnityEngine.UI;
public class HowManyThrowsLeft : MonoBehaviour
{
    #region Singleton
    public static HowManyThrowsLeft Instance;
    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(this);
        else
            Instance = this;
    }
    #endregion
    public MouseAndDartManager manager;
    int howManyDartsThrownFetch; // fetch from MouseAndSpawnManager -script
    [SerializeField] GameObject dart1;
    [SerializeField] GameObject dart2;
    [SerializeField] GameObject dart3;
    [SerializeField] GameObject dart4;
    [SerializeField] GameObject dart5;
    public void HowManyDartsThrown()
    {
        howManyDartsThrownFetch = manager.GetComponent<MouseAndDartManager>().howManyDartsThrown;
        if (howManyDartsThrownFetch == 1)
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
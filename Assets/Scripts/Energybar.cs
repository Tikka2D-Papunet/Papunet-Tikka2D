using UnityEngine;
using UnityEngine.UI;

public class Energybar : MonoBehaviour
{
    public Slider slider;
    public Image fill;
    public Image border;

    public MouseAndSpawnManager MaSmanager;
    int howManyDartsThrown;

    private void Start()
    {
        if(MouseAndSpawnManager.automaticThrowForce)
        {
            fill.enabled = false;
            border.enabled = false;
        }
    }

    private void Update()
    {
        howManyDartsThrown = MaSmanager.GetComponent<MouseAndSpawnManager>().howManyDartsThrown;

        if(howManyDartsThrown > 4)
        {
            fill.enabled = false;
            border.enabled = false;
        }
    }

    public void SetMaxEnergy(float energy)
    {
        slider.maxValue = energy;
        slider.value = energy;
    }

    public void SetEnergy(float energy)
    {
        slider.value = energy;
    }
}

using UnityEngine;
using UnityEngine.UI;

public class Energybar : MonoBehaviour
{
    public Slider slider;
    public Image fill;
    public Image border;

    public MouseAndSpawnManager MaSmanager;
    int howManyDartsThrown;

    bool showEnergybarFetch; // fetches boolean from MouseAndSpawnManager

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
        showEnergybarFetch = MaSmanager.GetComponent<MouseAndSpawnManager>().showEnergybar;

        if(howManyDartsThrown > 4)
        {
            fill.enabled = false;
            border.enabled = false;
        }
        else if(showEnergybarFetch == false)
        {
            fill.enabled = false;
            border.enabled = false;
        }
        else
        {
            fill.enabled = true;
            border.enabled = true;
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutomaticAimingButton : MonoBehaviour
{
    public static bool controlMouseTargeting = true;
    public static bool automaticMouseTargeting;

    Button button;
    Image buttonImage;
    Sprite originalSprite;
    public Sprite spriteClicked;

    void Start()
    {
        button = GetComponent<Button>();
        buttonImage = button.image;
        originalSprite = buttonImage.sprite;
    }

    private void Update()
    {
        if (automaticMouseTargeting)
        {
            buttonImage.sprite = spriteClicked;
        }
        else
        {
            buttonImage.sprite = originalSprite;
        }
    }
}

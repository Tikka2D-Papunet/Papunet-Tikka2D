using UnityEngine;
using UnityEngine.UI;
public class MouseAimingButton : MonoBehaviour
{
    public static bool controlMouseTargeting;
    public static bool automaticMouseTargeting = true;
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
        if(controlMouseTargeting)
            buttonImage.sprite = spriteClicked;
        else
            buttonImage.sprite = originalSprite;
    }
}
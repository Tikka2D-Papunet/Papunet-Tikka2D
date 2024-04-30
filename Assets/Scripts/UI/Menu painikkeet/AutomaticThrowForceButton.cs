using UnityEngine;
using UnityEngine.UI;
public class AutomaticThrowForceButton : MonoBehaviour
{
    public static bool automaticThrowForce = true;
    public static bool controlledThrowForce;
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
        if (automaticThrowForce)
            buttonImage.sprite = spriteClicked;
        else
            buttonImage.sprite = originalSprite;
    }
}
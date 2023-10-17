using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class AutomaticThrowForceButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public static bool automaticThrowForce = true;
    public static bool controlledThrowForce;

    Button button;
    Image buttonImage;
    Sprite originalSprite;
    public Sprite spriteClicked;

    RectTransform buttonRect;
    Vector2 localMousePosition;
    public bool mouse_over = false;

    void Start()
    {
        button = GetComponent<Button>();
        buttonRect = GetComponent<RectTransform>();
        buttonImage = button.image;
        originalSprite = buttonImage.sprite;
    }

    private void Update()
    {
        if (mouse_over)
        {
            if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
            {
                button.onClick.Invoke();

            }
        }

        if (automaticThrowForce)
        {
            buttonImage.sprite = spriteClicked;
        }
        else
        {
            buttonImage.sprite = originalSprite;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        mouse_over = true;
        Debug.Log("Mouse enter");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        mouse_over = false;
        Debug.Log("Mouse exit");
    }
}

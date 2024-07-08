using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class CloseGuideScreenButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, ISelectHandler, IDeselectHandler
{
    Button button;
    [HideInInspector] public Image buttonImage;
    [HideInInspector] public Sprite originalSprite;
    public Sprite hoverSprite;
    private bool isSelected;
    [SerializeField] InputManager inputManager;
    [SerializeField] CursorController cursor;
    void Start()
    {
        button = GetComponent<Button>();
        buttonImage = button.image;
        originalSprite = buttonImage.sprite;
        if (inputManager != null)
            inputManager.GetComponent<InputManager>();
        cursor.GetComponent<CursorController>();
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (inputManager != null)
            inputManager.canThrow = false;
        if (buttonImage != null)
            buttonImage.sprite = hoverSprite;
        cursor.ChangeCursor(cursor.cursorHover);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        if (inputManager != null)
            inputManager.canThrow = true;
        if (buttonImage != null)
            buttonImage.sprite = originalSprite;
        cursor.ChangeCursor(cursor.cursorOriginal);
    }
    public void OnSelect(BaseEventData eventData)
    {
        if (buttonImage != null)
            buttonImage.sprite = hoverSprite;
    }
    public void OnDeselect(BaseEventData eventData)
    {
        if (buttonImage != null)
            buttonImage.sprite = originalSprite;
    }
}
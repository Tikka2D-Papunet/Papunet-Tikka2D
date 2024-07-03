using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class ControlledThrowForceButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, ISelectHandler, IDeselectHandler
{
    public static bool automaticThrowForce = true;
    public static bool controlledThrowForce;
    Button button;
    Image buttonImage;
    Sprite originalSprite;
    public Sprite spriteClicked;
    [SerializeField] CursorController cursor;
    void Start()
    {
        button = GetComponent<Button>();
        buttonImage = button.image;
        originalSprite = buttonImage.sprite;
    }
    private void Update()
    {
        if (controlledThrowForce)
            buttonImage.sprite = spriteClicked;
        else
            buttonImage.sprite = originalSprite;
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        //if (buttonImage != null)
        //buttonImage.sprite = hoverSprite;
        cursor.ChangeCursor(cursor.cursorHover);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        if (buttonImage != null)
            buttonImage.sprite = originalSprite;
        cursor.ChangeCursor(cursor.cursorOriginal);
    }
    public void OnSelect(BaseEventData eventData)
    {
        //if (buttonImage != null)
        //buttonImage.sprite = hoverSprite;
    }
    public void OnDeselect(BaseEventData eventData)
    {
        if (buttonImage != null)
            buttonImage.sprite = originalSprite;
    }
}
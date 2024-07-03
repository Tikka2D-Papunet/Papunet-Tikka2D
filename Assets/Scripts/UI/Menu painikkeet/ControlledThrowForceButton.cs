using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class ControlledThrowForceButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, ISelectHandler, IDeselectHandler
{
    public static bool automaticThrowForce = true;
    public static bool controlledThrowForce;
    [HideInInspector] public Button button;
    [HideInInspector] public Image buttonImage;
    [HideInInspector] public Sprite originalSprite;
    public Sprite spriteClicked;
    [SerializeField] CursorController cursor;
    [SerializeField] Image img;
    [SerializeField] AutomaticThrowForceButton automaticThrowForceButton;
    void Start()
    {
        button = GetComponent<Button>();
        buttonImage = button.image;
        originalSprite = buttonImage.sprite;
        if (!automaticThrowForce)
            buttonImage.sprite = spriteClicked;
        else
            buttonImage.sprite = originalSprite;
        automaticThrowForceButton.GetComponent<AutomaticThrowForceButton>();
        button.onClick.AddListener(OnButtonClick);
    }
    void OnButtonClick()
    {
        if (controlledThrowForce)
            buttonImage.sprite = spriteClicked;
        else
            buttonImage.sprite = originalSprite;
        automaticThrowForceButton.buttonImage.sprite = automaticThrowForceButton.originalSprite;
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        cursor.ChangeCursor(cursor.cursorHover);
        img.enabled = true;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        cursor.ChangeCursor(cursor.cursorOriginal);
        img.enabled = false;
    }
    public void OnSelect(BaseEventData eventData)
    {
        img.enabled = true;
    }
    public void OnDeselect(BaseEventData eventData)
    {
        img.enabled = false;
    }
}
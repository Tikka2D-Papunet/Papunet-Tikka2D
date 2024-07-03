using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class MouseAimingButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, ISelectHandler, IDeselectHandler
{
    public static bool controlMouseTargeting;
    public static bool automaticMouseTargeting = true;
    [HideInInspector] public Button button;
    [HideInInspector] public Image buttonImage;
    [HideInInspector] public Sprite originalSprite;
    public Sprite spriteClicked;
    [SerializeField] CursorController cursor;
    [SerializeField] Image img;
    [SerializeField] AutomaticAimingButton automaticAimingButton;
    void Start()
    {
        button = GetComponent<Button>();
        buttonImage = button.image;
        originalSprite = buttonImage.sprite;
        if (!automaticMouseTargeting)
            buttonImage.sprite = spriteClicked;
        else
            buttonImage.sprite = originalSprite;
        automaticAimingButton.GetComponent<AutomaticAimingButton>();
        button.onClick.AddListener(OnButtonClick);
    }
    void OnButtonClick()
    {
        if (controlMouseTargeting)
            buttonImage.sprite = spriteClicked;
        else
            buttonImage.sprite = originalSprite;
        automaticAimingButton.buttonImage.sprite = automaticAimingButton.originalSprite;
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
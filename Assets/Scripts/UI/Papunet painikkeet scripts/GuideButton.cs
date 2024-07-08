using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class GuideButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, ISelectHandler, IDeselectHandler
{
    Button button;
    [HideInInspector] public Image buttonImage;
    [HideInInspector] public Sprite originalSprite;
    public Sprite hoverSprite;
    public GameObject speechBubble;
    [SerializeField] InputManager inputManager;
    [SerializeField] CursorController cursor;
    [SerializeField] GameObject guideScreen;
    public bool guideScreenOpen;
    void Start()
    {
        button = GetComponent<Button>();
        buttonImage = button.image;
        originalSprite = buttonImage.sprite;
        speechBubble.gameObject.SetActive(false);
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
        speechBubble.SetActive(true);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        if (inputManager != null)
            inputManager.canThrow = true;
        if (buttonImage != null)
            buttonImage.sprite = originalSprite;
        cursor.ChangeCursor(cursor.cursorOriginal);
        speechBubble.SetActive(false);
    }
    public void OnSelect(BaseEventData eventData)
    {
        if (buttonImage != null)
            buttonImage.sprite = hoverSprite;
        speechBubble.SetActive(true);
    }
    public void OnDeselect(BaseEventData eventData)
    {
        if (buttonImage != null)
            buttonImage.sprite = originalSprite;
        speechBubble.SetActive(false);
    }
    public void OpenGuideScreen()
    {
        guideScreen.SetActive(true);
        guideScreenOpen = true;
    }
    public void CloseGuideScreen()
    {
        guideScreen.SetActive(false);
        guideScreenOpen = false;
        SoundManager.Instance.source.Stop();
    }
}
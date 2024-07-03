using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class AgainButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, ISelectHandler, IDeselectHandler
{
    Button button;
    [HideInInspector] public Image buttonImage;
    [HideInInspector] public Sprite originalSprite;
    public Sprite hoverSprite;
    public GameObject speechBubble;
    private bool isSelected;
    [SerializeField] InputManager inputManager;
    void Start()
    {
        button = GetComponent<Button>();
        buttonImage = button.image;
        originalSprite = buttonImage.sprite;
        speechBubble.gameObject.SetActive(false);
        if (inputManager != null)
            inputManager.GetComponent<InputManager>();
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (inputManager != null)
            inputManager.canThrow = false;
        if (buttonImage != null)
            buttonImage.sprite = hoverSprite;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        if (inputManager != null)
            inputManager.canThrow = true;
        if (buttonImage != null)
            buttonImage.sprite = originalSprite;
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
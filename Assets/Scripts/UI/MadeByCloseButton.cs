using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class MadeByCloseButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, ISelectHandler, IDeselectHandler, IPointerClickHandler, ISubmitHandler
{
    Button button;
    [HideInInspector] public Image buttonImage;
    [HideInInspector] public Sprite originalSprite;
    public Sprite hoverSprite;
    [SerializeField] CursorController cursor;
    [SerializeField] GameObject madeByScreen;
    [SerializeField] GameObject transparentBG;
    [SerializeField] MadeByButton madeByButton;
    void Start()
    {
        button = GetComponent<Button>();
        buttonImage = button.image;
        originalSprite = buttonImage.sprite;
        cursor.GetComponent<CursorController>();
        if(madeByButton != null)
            madeByButton.GetComponent<MadeByButton>();
    }
    void Update()
    {
        bool input = Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Tab);
        if(input)
        {
            madeByScreen.SetActive(false);
            transparentBG.SetActive(false);
            madeByButton.ButtonTextBackToNormal();
        }
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        cursor.ChangeCursor(cursor.cursorHover);
        buttonImage.sprite = hoverSprite;

    }
    public void OnPointerClick(PointerEventData eventData)
    {
        madeByScreen.SetActive(false);
        transparentBG.SetActive(false);
        madeByButton.ButtonTextBackToNormal();
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        cursor.ChangeCursor(cursor.cursorOriginal);
        buttonImage.sprite = originalSprite;
    }
    public void OnSelect(BaseEventData eventData)
    {
        buttonImage.sprite = hoverSprite;
    }
    public void OnSubmit(BaseEventData eventData)
    {
        madeByScreen.SetActive(false);
        transparentBG.SetActive(false);
        madeByButton.ButtonTextBackToNormal();
    }
    public void OnDeselect(BaseEventData eventData)
    {
        buttonImage.sprite = originalSprite;
    }
}

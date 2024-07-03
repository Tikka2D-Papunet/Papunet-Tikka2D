using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class ListenButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, ISelectHandler, IDeselectHandler
{
    Button button;
    Image buttonImage;
    [SerializeField] Sprite soundOnOriginalSprite;
    [SerializeField] Sprite soundOffOriginalSprite;
    public Sprite soundOnHoverSprite;
    public GameObject soundOnSpeechBubble;
    public Sprite soundOffHoverSprite;
    public GameObject soundOffSpeechBubble;
    bool isMutedFetch;
    bool soundOn = true;
    [SerializeField] InputManager inputManager;
    void Start()
    {
        button = GetComponent<Button>();
        buttonImage = button.image;
        soundOnOriginalSprite = buttonImage.sprite;
        if (SoundManager.Instance.isMuted)
            buttonImage.sprite = soundOffOriginalSprite;
        soundOnSpeechBubble.gameObject.SetActive(false);
        if (inputManager != null)
            inputManager.GetComponent<InputManager>();
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        if(inputManager != null)
            inputManager.canThrow = false;
        if(!SoundManager.Instance.isMuted)
            buttonImage.sprite = soundOnHoverSprite;
        else
            buttonImage.sprite = soundOffHoverSprite;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        if(inputManager != null)
            inputManager.canThrow = true;
        if (!SoundManager.Instance.isMuted)
            buttonImage.sprite = soundOnOriginalSprite;
        else
            buttonImage.sprite = soundOffOriginalSprite;
    }
    public void OnSelect(BaseEventData eventData)
    {
        if (!SoundManager.Instance.isMuted)
            buttonImage.sprite = soundOnHoverSprite;
        else
            buttonImage.sprite = soundOffHoverSprite;
    }
    public void OnDeselect(BaseEventData eventData)
    {
        if (!SoundManager.Instance.isMuted)
            buttonImage.sprite = soundOnOriginalSprite;
        else
            buttonImage.sprite = soundOffOriginalSprite;
    }
    public void ToggleSoundOnOrOff()
    {
        SoundManager.Instance.isMuted = !SoundManager.Instance.isMuted;
        SoundManager.Instance.source.mute = SoundManager.Instance.isMuted;
        PlayerPrefs.SetInt("isMuted", SoundManager.Instance.isMuted ? 1 : 0);
        PlayerPrefs.Save();
        if (!SoundManager.Instance.isMuted)
            buttonImage.sprite = soundOnHoverSprite;
        else
            buttonImage.sprite = soundOffHoverSprite;
    }
}
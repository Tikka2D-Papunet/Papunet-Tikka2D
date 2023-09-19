using UnityEngine;
using UnityEngine.UI;

public class ListenButton : MonoBehaviour
{
    //public static ListenButton instance { get; set; }
    Button button;
    Image buttonImage;
    [SerializeField] Sprite soundOnOriginalSprite;
    [SerializeField] Sprite soundOffOriginalSprite;
    public Sprite soundOnHoverSprite;
    public GameObject soundOnSpeechBubble;
    public Sprite soundOffHoverSprite;
    public GameObject soundOffSpeechBubble;

    public static bool staticSoundOn = true;
    public bool soundOn = true;

    void Start()
    {
        button = GetComponent<Button>();
        buttonImage = button.image;
        soundOnOriginalSprite = buttonImage.sprite;
        soundOnSpeechBubble.gameObject.SetActive(false);
    }

    public void Update()
    {
        if(soundOn)
        {
            if (RectTransformUtility.RectangleContainsScreenPoint(buttonImage.rectTransform,
    Input.mousePosition))
            {
                buttonImage.sprite = soundOnHoverSprite;
                soundOnSpeechBubble.gameObject.SetActive(true);

            }
            else
            {
                buttonImage.sprite = soundOnOriginalSprite;
                soundOnSpeechBubble.gameObject.SetActive(false);
            }
        }
        else
        {
            if (RectTransformUtility.RectangleContainsScreenPoint(buttonImage.rectTransform,
    Input.mousePosition))
            {
                buttonImage.sprite = soundOffHoverSprite;
                //soundOnSpeechBubble.gameObject.SetActive(true);

            }
            else
            {
                buttonImage.sprite = soundOffOriginalSprite;
                //soundOnSpeechBubble.gameObject.SetActive(false);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class GuideAudioButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, ISelectHandler, IDeselectHandler, IPointerClickHandler, ISubmitHandler
{
    Button button;
    [HideInInspector] public Image buttonImage;
    [HideInInspector] public Sprite originalSprite;
    public GameObject originalBlack;
    public Sprite stopPlaySprite;
    [SerializeField] InputManager inputManager;
    [SerializeField] CursorController cursor;
    [SerializeField] AudioClip guideAudioClip;
    public bool guideAudioOn;
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
        originalBlack.SetActive(true);
        cursor.ChangeCursor(cursor.cursorHover);
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (buttonImage != null)
        {
            if (!guideAudioOn)
                buttonImage.sprite = originalSprite;
            else
                buttonImage.sprite = stopPlaySprite;
        }
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        originalBlack.SetActive(false);
        cursor.ChangeCursor(cursor.cursorOriginal);
    }
    public void OnSelect(BaseEventData eventData)
    {
        originalBlack.SetActive(true);
    }
    public void OnSubmit(BaseEventData eventData)
    {
        if (buttonImage != null)
        {
            if (!guideAudioOn)
                buttonImage.sprite = originalSprite;
            else
                buttonImage.sprite = stopPlaySprite;
        }
    }
    public void OnDeselect(BaseEventData eventData)
    {
        originalBlack.SetActive(false);
    }
    public void PlayAudioGuide()
    {
        if(!guideAudioOn)
        {
            guideAudioOn = true;
            SoundManager.Instance.PlaySound(guideAudioClip);
        }
        else
        {
            guideAudioOn = false;
            SoundManager.Instance.source.Stop();
        }
    }
}
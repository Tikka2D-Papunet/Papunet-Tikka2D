using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class GuideAudioButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, ISelectHandler, IDeselectHandler
{
    Button button;
    [HideInInspector] public Image buttonImage;
    [HideInInspector] public Sprite originalSprite;
    public Sprite hoverSprite;
    public Sprite originalStopSprite;
    public Sprite hoverStopSprite;
    private bool isSelected;
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
        if (inputManager != null)
            inputManager.canThrow = false;
        if (buttonImage != null)
        {
            if (!guideAudioOn)
                buttonImage.sprite = hoverSprite;
            else
                buttonImage.sprite = hoverStopSprite;
        }
        cursor.ChangeCursor(cursor.cursorHover);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        if (inputManager != null)
            inputManager.canThrow = true;
        if (buttonImage != null)
        {
            if (!guideAudioOn)
                buttonImage.sprite = originalSprite;
            else
                buttonImage.sprite = originalStopSprite;
        }
        cursor.ChangeCursor(cursor.cursorOriginal);
    }
    public void OnSelect(BaseEventData eventData)
    {
        if (buttonImage != null)
        {
            if (!guideAudioOn)
                buttonImage.sprite = hoverSprite;
            else
                buttonImage.sprite = hoverStopSprite;
        }
    }
    public void OnDeselect(BaseEventData eventData)
    {
        if (buttonImage != null)
        {
            if (!guideAudioOn)
                buttonImage.sprite = originalSprite;
            else
                buttonImage.sprite = originalStopSprite;
        }
    }
    public void PlayAudioGuide()
    {
        if(!guideAudioOn)
        {
            guideAudioOn = true;
            SoundManager.Instance.PlaySound(guideAudioClip);
            buttonImage.sprite = hoverStopSprite;
        }
        else
        {
            guideAudioOn = false;
            SoundManager.Instance.source.Stop();
            buttonImage.sprite = hoverSprite;
        }
    }
}
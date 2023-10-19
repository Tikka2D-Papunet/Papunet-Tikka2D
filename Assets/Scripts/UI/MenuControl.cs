using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MenuControl : MonoBehaviour
{
    //public Button[] buttonsList;
    public Button[] buttonsArray;
    public int selectedButtonIndex = 0;

    ListenButton listenButton;
    public Sprite soundOnHover;
    public Sprite SoundOnSprite;
    public Sprite soundOffHover;
    public Sprite soundOffSprite;
    public Sprite soundOnSpeechBubble;
    public Sprite soundOffSpeechBubble;
    bool soundOn;

    private void Start()
    {
        buttonsArray = FindObjectsOfType<Button>();
        listenButton = FindObjectOfType<ListenButton>();
        //SelectButton(selectedButtonIndex);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            //buttons[selectedButtonIndex].onClick.Invoke();
            buttonsArray[selectedButtonIndex].onClick.Invoke();
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            //selectedButtonIndex = (selectedButtonIndex + 1) % buttons.Length;
            //DeselectButton(selectedButtonIndex);
            //ChangeButtonSprite(selectedButtonIndex, null);
            selectedButtonIndex++;
            Debug.Log("Selected button index: " + selectedButtonIndex);
            if(selectedButtonIndex >= buttonsArray.Length)
            {
                selectedButtonIndex = 0;
            }
            //SelectButton(selectedButtonIndex);
            //ChangeButtonSprite(selectedButtonIndex, hoverSprite)
        }
    }

    void SelectButton(int index)
    {
        buttonsArray[index].image.color = Color.green;
    }

    void DeselectButton(int index)
    {
        buttonsArray[index].image.color = Color.white;
    }

    void ChangeButtonSprite(int index, SpriteRenderer sprite)
    {
        Image buttonImage = buttonsArray[index].GetComponent<Image>();
        if(buttonImage != null)
        {
            if(index == 2)
            {
                buttonImage.sprite = SoundOnSprite;
            }
        }
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("Dart");
    }

    public void LoadControlMouseTargeting()
    {
        Crosshair.controlMouseTargeting = true;
        Crosshair.automaticMouseTargeting = false;

        FollowCursor.controlMouseTargeting = true;
        FollowCursor.automaticMouseTargeting = false;

        Rotate.controlMouseTargeting = true;
        Rotate.automaticMouseTargeting = false;

        MouseAimingButton.controlMouseTargeting = true;
        MouseAimingButton.automaticMouseTargeting = false;

        AutomaticAimingButton.controlMouseTargeting = true;
        AutomaticAimingButton.automaticMouseTargeting = false;
    }

    public void LoadAutomaticMouseTargeting()
    {
        Crosshair.automaticMouseTargeting = true;
        Crosshair.controlMouseTargeting = false;

        FollowCursor.automaticMouseTargeting = true;
        FollowCursor.controlMouseTargeting = false;

        Rotate.automaticMouseTargeting = true;
        Rotate.controlMouseTargeting = false;

        MouseAimingButton.automaticMouseTargeting = true;
        MouseAimingButton.controlMouseTargeting = false;

        AutomaticAimingButton.automaticMouseTargeting = true;
        AutomaticAimingButton.controlMouseTargeting = false;
    }

    public void AutomaticThrowForce()
    {
        MouseAndSpawnManager.automaticThrowForce = true;
        MouseAndSpawnManager.controlledThrowForce = false;

        Dart.automaticThrowForce = true;
        Dart.controlledThrowForce = false;

        AutomaticThrowForceButton.automaticThrowForce = true;
        AutomaticThrowForceButton.controlledThrowForce = false;

        ControlledThrowForceButton.automaticThrowForce = true;
        ControlledThrowForceButton.controlledThrowForce = false;
    }

    public void ControlledThrowForce()
    {
        MouseAndSpawnManager.controlledThrowForce = true;
        MouseAndSpawnManager.automaticThrowForce = false;

        Dart.controlledThrowForce = true;
        Dart.automaticThrowForce = false;

        AutomaticThrowForceButton.controlledThrowForce = true;
        AutomaticThrowForceButton.automaticThrowForce = false;

        ControlledThrowForceButton.controlledThrowForce = true;
        ControlledThrowForceButton.automaticThrowForce = false;
    }
}

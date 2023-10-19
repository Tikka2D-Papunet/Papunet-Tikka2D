using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MenuControl : MonoBehaviour
{
    //public Button[] buttonsList;
    public List<Button> buttonsList = new List<Button>();
    int selectedButtonIndex = 0;
    public Button listen;
    public Button guide;
    public Button again;
    public Button exit;

    private void Start()
    {
        //listen = FindObjectOfType<ListenButton>();
        Button[] foundButtons = FindObjectsOfType<Button>();
        for(int i = 0; i < foundButtons.Length; i++)
        {
            buttonsList.Add(foundButtons[i]);
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            //buttons[selectedButtonIndex].onClick.Invoke();
            buttonsList[selectedButtonIndex].onClick.Invoke();
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            //selectedButtonIndex = (selectedButtonIndex + 1) % buttons.Length;
            //selectedButtonIndex++;
            /*if(selectedButtonIndex >= buttons.Length)
            {
                selectedButtonIndex = 0;
            }*/
            selectedButtonIndex = (selectedButtonIndex + 1) % buttonsList.Count;
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

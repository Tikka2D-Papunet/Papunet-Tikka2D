using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuControl : MonoBehaviour
{
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
        MouseAndDartManager.automaticThrowForce = true;
        MouseAndDartManager.controlledThrowForce = false;
        Dart.automaticThrowForce = true;
        Dart.controlledThrowForce = false;
        AutomaticThrowForceButton.automaticThrowForce = true;
        AutomaticThrowForceButton.controlledThrowForce = false;
        ControlledThrowForceButton.automaticThrowForce = true;
        ControlledThrowForceButton.controlledThrowForce = false;
    }
    public void ControlledThrowForce()
    {
        MouseAndDartManager.controlledThrowForce = true;
        MouseAndDartManager.automaticThrowForce = false;
        Dart.controlledThrowForce = true;
        Dart.automaticThrowForce = false;
        AutomaticThrowForceButton.controlledThrowForce = true;
        AutomaticThrowForceButton.automaticThrowForce = false;
        ControlledThrowForceButton.controlledThrowForce = true;
        ControlledThrowForceButton.automaticThrowForce = false;
    }
}
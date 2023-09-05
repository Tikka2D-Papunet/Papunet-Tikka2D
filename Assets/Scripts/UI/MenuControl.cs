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
    }

    public void LoadAutomaticMouseTargeting()
    {
        Crosshair.automaticMouseTargeting = true;
        Crosshair.controlMouseTargeting = false;

        FollowCursor.automaticMouseTargeting = true;
        FollowCursor.controlMouseTargeting = false;

        Rotate.automaticMouseTargeting = true;
        Rotate.controlMouseTargeting = false;
    }

    public void AutomaticThrowForce()
    {
        MouseAndSpawnManager.automaticThrowForce = true;
        MouseAndSpawnManager.controlledThrowForce = false;

        Dart.automaticThrowForce = true;
        Dart.controlledThrowForce = false;
    }

    public void ControlledThrowForce()
    {
        MouseAndSpawnManager.controlledThrowForce = true;
        MouseAndSpawnManager.automaticThrowForce = false;

        Dart.controlledThrowForce = true;
        Dart.automaticThrowForce = false;
    }
}

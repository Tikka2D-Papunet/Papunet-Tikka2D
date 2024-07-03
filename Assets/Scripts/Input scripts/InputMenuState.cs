using UnityEngine;
public class InputMenuState : InputState
{
    private InputManager manager;
    public InputMenuState(InputManager inputManager)
    {
        this.manager = inputManager;
    }
    public void UpdateState()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            manager.NavigateToNextButton();
    }
    public void EnterMenuState()
    {
    }
    public void EnterGameState()
    {
    }
}
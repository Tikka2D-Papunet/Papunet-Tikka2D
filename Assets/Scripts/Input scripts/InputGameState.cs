using UnityEngine;
public class InputGameState : InputState
{
    private InputManager manager;
    public InputGameState(InputManager inputManager)
    {
        this.manager = inputManager;
    }
    public void UpdateState()
    {
        if(manager.isEndingMenuOpen)
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
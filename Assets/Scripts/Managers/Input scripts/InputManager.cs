using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
public class InputManager : MonoBehaviour
{
    [HideInInspector] public InputState currentInputState;
    [HideInInspector] public InputMenuState inputMenuState;
    [HideInInspector] public InputGameState inputGameState;
    public Button[] buttons;
    private int currentButtonIndex = 0;
    public bool isEndingMenuOpen;
    public bool canThrow = true;
    private void Awake()
    {
        inputMenuState = new InputMenuState(this);
        inputGameState = new InputGameState(this);
        currentInputState = inputMenuState;
    }
    private void Start()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        if (sceneName == "MainMenu")
        {
            SelectFirstButton();
            currentInputState = inputMenuState;
        }
        else if (sceneName == "Dart")
            currentInputState = inputGameState;
    }
    private void Update()
    {
        currentInputState.UpdateState();
    }
    public void SelectFirstButton()
    {
        EventSystem.current.SetSelectedGameObject(buttons[0].gameObject);
    }
    public void NavigateToNextButton()
    {
        currentButtonIndex++;
        if (currentButtonIndex >= buttons.Length)
            currentButtonIndex = 0;
        EventSystem.current.SetSelectedGameObject(buttons[currentButtonIndex].gameObject);
    }
}
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class InputManager : MonoBehaviour
{
    [HideInInspector] public InputState currentInputState;
    [HideInInspector] public InputMenuState inputMenuState;
    [HideInInspector] public InputGameState inputGameState;
    public Button[] buttons;
    public Button[] guideButtons;
    private int currentButtonIndex = 0;
    public bool isEndingMenuOpen;
    public bool canThrow = true;
    [SerializeField] GuideButton guideButton;
    public bool keyboardInput;
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
        guideButton.GetComponent<GuideButton>();
    }
    private void Update()
    {
        currentInputState.UpdateState();
    }
    public void SelectFirstButton()
    {
        EventSystem.current.SetSelectedGameObject(buttons[0].gameObject);
    }
    public void SelectSecondGuideButton()
    {
        EventSystem.current.SetSelectedGameObject(guideButtons[1].gameObject);
        keyboardInput = true;
    }
    public void NavigateToNextButton()
    {
        if(!guideButton.guideScreenOpen)
        {
            currentButtonIndex++;
            if (currentButtonIndex >= buttons.Length)
                currentButtonIndex = 0;
            EventSystem.current.SetSelectedGameObject(buttons[currentButtonIndex].gameObject);
        }
        else
        {
            currentButtonIndex++;
            if (currentButtonIndex >= guideButtons.Length)
                currentButtonIndex = 0;
            EventSystem.current.SetSelectedGameObject(guideButtons[currentButtonIndex].gameObject);
        }
    }
}
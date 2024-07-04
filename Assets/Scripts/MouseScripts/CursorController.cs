using UnityEngine;
//using UnityEngine.UIElements;
public class CursorController : MonoBehaviour
{
    CursorControls controls;
    Camera mainCamera;
    public Texture2D cursorOriginal;
    public Texture2D cursorHover;
    private void Awake()
    {
        controls = new CursorControls();
        ChangeCursor(cursorOriginal);
        Cursor.lockState = CursorLockMode.Confined;
        mainCamera = Camera.main;
    }
    private void OnEnable()
    {
        controls.Enable();
    }
    private void OnDisable()
    {
        controls.Disable();
    }
    public void ChangeCursor(Texture2D cursorType)
    {
        //Vector2 hotspot = new Vector2(cursorType.width / 2, cursorType.height / 2);
        Cursor.SetCursor(cursorType, Vector2.zero, CursorMode.Auto);
    }
    private void Start()
    {
        controls.Mouse.Click.started += _ => StartedClick();
        controls.Mouse.Click.performed += _ => EndedClick();
    }
    void StartedClick()
    {

    }
    void EndedClick()
    {
        DetectObject();
    }
    public void DetectObject()
    {
        Ray ray = mainCamera.ScreenPointToRay(controls.Mouse.Position.ReadValue<Vector2>());
        RaycastHit2D hits2D = Physics2D.GetRayIntersection(ray);
        if (hits2D.collider != null)
        {
            if (hits2D.collider.gameObject.CompareTag("ListenButton"))
            {

            }
            else
            {

            }
            Debug.Log("Hit 2D collider: " + hits2D.collider.tag);
        }
    }
}
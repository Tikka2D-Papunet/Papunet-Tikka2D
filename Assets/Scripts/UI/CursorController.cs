using UnityEngine;
public class CursorController : MonoBehaviour
{
    CursorControls controls;
    Camera mainCamera;
    private void Awake()
    {
        controls = new CursorControls();
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
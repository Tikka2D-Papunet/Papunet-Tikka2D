using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Dart : MonoBehaviour
{
    [HideInInspector] public Rigidbody2D rb2d;
    public bool throwed = false;
    public Camera cam;
    public Transform castPoint;
    GameObject crosshair;
    [SerializeField] SpriteRenderer sprite;
    public GameObject childObject;
    [HideInInspector] public SpriteRenderer childSprite;
    public GameObject childObjectAnimator;
    [HideInInspector] public Animator childAnim;
    [SerializeField] public GameObject childShadow;
    [HideInInspector] public SpriteRenderer shadowSprite;
    public Transform GetChildObjectTransform()
    {
        return castPoint;
    }
    private void Awake()
    {
        cam = FindObjectOfType<Camera>();
        crosshair = GameObject.FindGameObjectWithTag("Crosshair");
    }
    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.bodyType = RigidbodyType2D.Kinematic;
        childSprite = childObject.GetComponent<SpriteRenderer>();
        childAnim = childObjectAnimator.GetComponent<Animator>();
        shadowSprite = childShadow.GetComponent<SpriteRenderer>();
    }
    public void Update()
    {
        if (!throwed)
        {
            Vector2 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(crosshair.transform.position.x + 3.4f, crosshair.transform.position.y - 0.75f,
                transform.position.z);
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
    void DestroyDart()
    {
        childSprite.enabled = false;
        shadowSprite.enabled = false;
    }
}
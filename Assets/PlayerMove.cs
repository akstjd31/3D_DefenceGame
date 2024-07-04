using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{

    private PlayerAction playerAction;
    private Rigidbody rb;

    ///////////////////////////////////
    ///// Move
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    Vector2 inputVector;
    Vector3 moveVector;

    ///////////////////////////////////
    ///// Floor check
    public LayerMask groundLayer;
    [SerializeField] private bool isGrounded;

    ///////////////////////////////////
    ///// Look
    public Transform firstPersonTransform;
    [SerializeField] private GameObject cameraObj;
    [SerializeField] private Vector3 defaultPosition;
    [SerializeField] private Vector3 defaultRotation;

    [SerializeField] private bool isFirstPerson = false;

    private void Awake()
    {
        playerAction = new PlayerAction();

        playerAction.Player.Move.started += OnMovement;
        playerAction.Player.Move.performed += OnMovement;
        playerAction.Player.Move.canceled += OnMovement;

        playerAction.Player.Jump.started += OnJump;

        playerAction.Player.Look.started += HandleLook;

        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        cameraObj = this.GetComponentInChildren<Camera>().gameObject;
        defaultPosition = cameraObj.transform.position;
        defaultRotation = cameraObj.transform.localEulerAngles;
    }

    void Update()
    {
        transform.Translate(moveVector.normalized * Time.deltaTime * moveSpeed);
        CheckGroundStatus();
    }

    public void OnMovement(InputAction.CallbackContext value)
    {
        inputVector = value.ReadValue<Vector2>();
        moveVector = new Vector3(inputVector.x, 0f, inputVector.y);
    }

    public void OnJump(InputAction.CallbackContext value)
    {
        if (isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    public void HandleLook(InputAction.CallbackContext value)
    {
        isFirstPerson = !isFirstPerson;

        if (cameraObj != null)
        {
            cameraObj.GetComponent<Transform>().position = isFirstPerson ? firstPersonTransform.position : defaultPosition;
            cameraObj.GetComponent<Transform>().eulerAngles = isFirstPerson ? Vector3.zero : defaultRotation;
                
        }
    }

    // Default : Enable
    private void OnEnable()
    {
        playerAction.Player.Enable();
    }

    private void OnDisable()
    {
        playerAction.Player.Disable();
    }

    private void CheckGroundStatus()
    {
        // Raycast to check if the player is grounded
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 1.1f, groundLayer);
    }
}
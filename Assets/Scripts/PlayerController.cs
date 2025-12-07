using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public enum ShootType
{
    ServeTopSpin,
    ServeSlice,
    TopSpin,
    Flat,
    Slice
};

public enum PlayerState
{
    Movement,
    Aiming
}

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    //[SerializeField] float gravity = -9.8f; 

    private CharacterController characterController;
    public Vector2 moveInput;
    private Vector2 velocity;

    ShotManagement shotManagement;
    Shot currentShot; 
    public static PlayerController instance;
    public Player player;

    //PowerChargeInputSystem
    [Header("Charge Settings")]
    public float maxCharge = 100f;
    public float chargeRate = 50f;
    public float minChargeToActivate = 10f;

    private float currentCharge = 0f;
    private bool isCharging = false;

    private Rigidbody rb;

    //Serving
    public bool MovementLocked { get; private set; } = false;
    public bool serveMovedDisabled = true;
    public bool canMoveForward = false;

    //Anim
    [SerializeField] private Animator anim;

    //Player Movement Switch
    public PlayerState currentState = PlayerState.Movement;
    public Vector3 AimDirection { get; private set; }


    void Awake()
    {
        characterController = GetComponent<CharacterController>();
        //currentShot = shotManagement.topspin;
        if (instance == null) instance = this;
        rb = GetComponent<Rigidbody>();
    }
    public void LockMovement(bool lockMovement)
    {
        MovementLocked = lockMovement;
    }


    void Update()
    {
        if (currentState == PlayerState.Movement)
        {
            Vector3 m = new Vector3(moveInput.x, 0, moveInput.y);
            characterController.Move(m * speed * Time.deltaTime);
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();

        if (currentState == PlayerState.Movement)
        {
            anim.SetFloat("MoveX", moveInput.x);
            anim.SetFloat("MoveY", moveInput.y);
            anim.SetFloat("Speed", moveInput.magnitude);
        }
        else
        {
            AimDirection = new Vector3(moveInput.x, 0, moveInput.y);
        }
    }

    private void FixedUpdate()
    {
        if (currentState == PlayerState.Movement)
        {
            Vector3 movement = MovementLocked
            ? new Vector3(moveInput.x, 0f, 0f) * speed
            : new Vector3(moveInput.x, 0f, moveInput.y) * speed;
        rb.linearVelocity = movement;
        }
        else
        {
            rb.linearVelocity = Vector3.zero;
        }
    }


    public void Shoot(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            //Debug.Log($"Stroke");
            //player.TopspinStroke();
            ShootType shootType = ShootType.TopSpin;
            player.Shoot(shootType);
            //BallController.Instance?.AddForceToBall(); 
        }
    }

    //public void Flat(InputAction.CallbackContext context)
    //{
    //    Debug.Log($"Stroke");
    //    //BallController.Instance?.FlatStroke();
    //}

}

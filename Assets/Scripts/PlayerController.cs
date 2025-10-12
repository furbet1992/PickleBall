using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem; 

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    //[SerializeField] float gravity = -9.8f; 

    private CharacterController characterController;
    private Vector2 moveInput;
    private Vector2 velocity;

    ShotManagement shotManagement;
    Shot currentShot; 
    public static PlayerController instance;
    public Player player; 

    void Awake()
    {
        player.GetComponent<Player>(); 
        characterController = GetComponent<CharacterController>();
        //currentShot = shotManagement.topspin;
        if (instance == null) instance = this; 
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
       // Debug.Log($"Move Input: {moveInput}"); 
    }


    public void Shoot(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log($"Stroke");
            player.TopspinStroke(); 
            //BallController.Instance?.AddForceToBall(); 
        }
    }

    //public void Flat(InputAction.CallbackContext context)
    //{
    //    Debug.Log($"Stroke");
    //    //BallController.Instance?.FlatStroke();
    //}


    // Update is called once per frame
    void Update()
    {
        Vector3 m = new Vector3(moveInput.x, 0, moveInput.y);
        characterController.Move(m * speed *Time.deltaTime);
    }
}

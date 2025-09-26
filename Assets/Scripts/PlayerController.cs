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



    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
        Debug.Log($"Move Input: {moveInput}"); 
    }

    public void Shoot(InputAction.CallbackContext context)
    {
        Debug.Log($"Stroke");
    }


    // Update is called once per frame
    void Update()
    {
        Vector3 m = new Vector3(moveInput.x, 0, moveInput.y);
        characterController.Move(m * speed *Time.deltaTime);
    }
}

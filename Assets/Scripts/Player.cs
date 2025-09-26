using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public float speed;
    public Transform aimTarget;
    float force = 15f;
    bool hitting;

    PlayerControls controls; 
    //public InputActionReference move;

    Animator animator;
    public Transform ball;

    ShotManagement sM;
    Shot currentShot;

    Vector3 aimTargetInitialPosition;

    [SerializeField] Transform serveRight;
    [SerializeField] Transform serveLeft;

    bool servedRight = true;

    Vector2 moveDirection;


    //private CharacterController characterController;
    //private Vector2 moveInput;
    //private Vector2 velocity;




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        sM = GetComponent<ShotManagement>();
        currentShot = sM.topspin;
        aimTargetInitialPosition = aimTarget.position;
        //characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 m = new Vector3(moveInput.x, 0, moveInput.y);
        //characterController.Move(m * speed * Time.deltaTime);

        //Topspin
        if (Input.GetKeyDown(KeyCode.F))
        {
            hitting = true;
            currentShot = sM.topspin;

        }
        else if (Input.GetKeyUp(KeyCode.F))
        {
            hitting = false;
        }
        //Flat
        if (Input.GetKeyDown(KeyCode.E))
        {
            hitting = true;
            currentShot = sM.flat;

        }
        else if (Input.GetKeyUp(KeyCode.E))
        {
            hitting = false;
        }
        //UnderArmServe
        if (Input.GetKeyDown(KeyCode.R))
        {
            hitting = true;
            currentShot = sM.UnderArmServe;
            GetComponent<BoxCollider>().enabled = false;

        }
        else if (Input.GetKeyUp(KeyCode.R))
        {
            hitting = false;
            GetComponent<BoxCollider>().enabled = true;
            ball.transform.position = transform.position + new Vector3(0.2f, 1, 0);
            Vector3 dir = aimTarget.position - transform.position;
            ball.GetComponent<Rigidbody>().linearVelocity = dir.normalized * currentShot.hitForce + new Vector3(0, currentShot.upForce, 0);
        }
        //Topspin
        if (Input.GetKeyDown(KeyCode.Q))
        {
            hitting = true;
            currentShot = sM.SpinServe;
            GetComponent<BoxCollider>().enabled = false;

        }
        else if (Input.GetKeyUp(KeyCode.Q))
        {
            hitting = false;
            GetComponent<BoxCollider>().enabled = true;
            ball.transform.position = transform.position + new Vector3(0.2f, 1, 0);
            Vector3 dir = aimTarget.position - transform.position;
            ball.GetComponent<Rigidbody>().linearVelocity = dir.normalized * currentShot.hitForce + new Vector3(0, currentShot.upForce, 0);
        }

        //if (hitting)
        //{
        //    aimTarget.Translate(new Vector3(m.x, 0, m.y) * speed * Time.deltaTime);
        //}

        //if ((m.x != 0 || m.y != 0) && !hitting)
        //{
        //    transform.Translate(new Vector3(m.x, 0, m.y) * speed * Time.deltaTime);
        //}
    }


    //public void OnMove(InputAction.CallbackContext context)
    //{
    //    moveInput = context.ReadValue<Vector2>();
    //    Debug.Log($"Move Input: {moveInput}");
    //}

    //public void Shoot(InputAction.CallbackContext context)
    //{
    //    Debug.Log($"Stroke");
    //}

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            Vector3 dir = aimTarget.position - transform.position;
            other.GetComponent<Rigidbody>().linearVelocity = dir.normalized * currentShot.hitForce + new Vector3(0, currentShot.upForce, 0);


            //Vector3 ballDir = ball.position - transform.position;
            //if (ballDir.x <= 0)
            //{
            //    animator.Play("Hitting");
            //    Debug.Log("hit");
            //}
            //else
            //{
            //    animator.Play("Backhand");
            //}
            ball.GetComponent<Ball>().hitter = "player"; 
            aimTarget.transform.position = aimTargetInitialPosition;
        }
    }

    public void Reset()
    {
        if (serveRight)

            transform.position = serveLeft.position;
        else
            transform.position = serveRight.position;
        servedRight = !servedRight; 
    }
}

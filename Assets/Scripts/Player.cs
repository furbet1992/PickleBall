using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
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

    public BallController b;
    public bool HasServed { get; private set; }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        sM = GetComponent<ShotManagement>();
        currentShot = sM.topspin;
        aimTargetInitialPosition = aimTarget.position;
        //b =  GetComponent<BallController>();


    }

    // Update is called once per frame
    void Update()
    {
        if (b.canApplyForce == true)
        {
            TopspinStroke();
        }
    }
        //Vector3 m = new Vector3(moveInput.x, 0, moveInput.y);
        //characterController.Move(m * speed * Time.deltaTime);

        //Topspin
        //TopspinShot();
        //if (Input.GetKeyDown(KeyCode.F))
        //{
        //    hitting = true;
        //    currentShot = sM.topspin;

        //}
        //else if (Input.GetKeyUp(KeyCode.F))
        //{
        //    hitting = false;
        //}
        ////Flat
        //if (Input.GetKeyDown(KeyCode.E))
        //{
        //    hitting = true;
        //    currentShot = sM.flat;

        //}
        //else if (Input.GetKeyUp(KeyCode.E))
        //{
        //    hitting = false;
        //}
        public void ServeFirst()
        {
            //Activate this Button, Start Charging for Power
            if (Input.GetKeyDown(KeyCode.R))
            {
                //hitting = true;
                currentShot = sM.UnderArmServe;
               // ball.transform.position = transform.position + new Vector3(0.2f, 2, 0);
               // Vector3 dir = aimTarget.position - transform.position;

            Debug.Log("CanServe"); 

            }
            //Provide a force with the value stored from above on Release
            else if (Input.GetKeyUp(KeyCode.R))
            {
                //hitting = false;       
                ball.GetComponent<Rigidbody>().linearVelocity = transform.forward + new Vector3(0, currentShot.upForce, 0);
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
        }
    

//public void TopspinShot()
//{
//    hitting = true;
//    currentShot = sM.topspin;
//}


            public void TopspinStroke()
            {
                Vector3 dir = aimTarget.position - transform.position;
                b.GetComponent<Rigidbody>().linearVelocity = dir.normalized * currentShot.hitForce + new Vector3(0, currentShot.upForce, 0);
                //rb.AddForce(Vector3.up * forceStrength, ForceMode.Impulse);
                Debug.Log("Topspin!");

            }
}






//private void OnTriggerEnter(Collider other)
//{
//    if (other.CompareTag("Ball"))
//    {
//        Vector3 dir = aimTarget.position - transform.position;
//        other.GetComponent<Rigidbody>().linearVelocity = dir.normalized * currentShot.hitForce + new Vector3(0, currentShot.upForce, 0);


//        //Vector3 ballDir = ball.position - transform.position;
//        //if (ballDir.x <= 0)
//        {
//            //    animator.Play("Hitting");
//            //    Debug.Log("hit");
//            //}
//            //else
//            //{
//            //    animator.Play("Backhand");
//            //}
//            ball.GetComponent<Ball>().hitter = "player";
//        aimTarget.transform.position = aimTargetInitialPosition;
//    }
//}

//public void Reset()
//{
//    if (serveRight)

//        transform.position = serveLeft.position;
//    else
//        transform.position = serveRight.position;
//    servedRight = !servedRight; 


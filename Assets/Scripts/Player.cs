using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    public Transform aimTarget;
    float force = 15f;
    bool hitting;

    PlayerControls controls; 
    //public InputActionReference move;

    Animator animator;
    public Transform ball;
    public GameObject ballObject;

    ShotManagement sM;
    Shot currentShot;

    Vector3 aimTargetInitialPosition;

    [SerializeField] Transform serveRight;
    [SerializeField] Transform serveLeft;

    AI ai; 

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
        Debug.Log($"Scene Start - HitForce: {sM.UnderArmServe.hitForce}, UpForce: {sM.UnderArmServe.upForce}");

    }
    public void ServeFirst()
        {
        //Activate this Button, Start Charging for Power
       
        if (Input.GetKeyDown(KeyCode.R))
        {
            //hitting = true;
            HasServed = true;
            Vector3 dir = aimTarget.position - transform.position;
            GameObject spawnBall = Instantiate(ballObject, transform.position + new Vector3(0.2f, 2f, 0), transform.rotation);
            Rigidbody rb = spawnBall.GetComponent<Rigidbody>();

            if(rb != null)
            {
                currentShot = sM.UnderArmServe;
                rb.linearVelocity = dir.normalized * currentShot.hitForce + new Vector3(0, currentShot.upForce, 0);
                Debug.Log(currentShot); 
                Debug.Log($"HitForce: {currentShot.hitForce},{currentShot.upForce}, Direction: {dir}");
                //ball.transform.position = transform.position + new Vector3(0.2f, 5f, 0);
            }
            else
            {
                Debug.LogError("Spawned ball has no Rigid"); 
            }

        }
    }
    
    public void TopspinStroke()
    {
        if(b.canApplyForce == true)
        {
            Vector3 dir = aimTarget.position - transform.position;
            b.GetComponent<Rigidbody>().linearVelocity = dir.normalized * currentShot.hitForce + new Vector3(0, currentShot.upForce, 0);
            //rb.AddForce(Vector3.up * forceStrength, ForceMode.Impulse);
            Debug.Log("Topspin!");
        }
        else 
        {
        Debug.Log("No Ball interaction"); 
        }
    }

    public void FlatStroke()
    {
        if (b.canApplyForce == true)
        {
            Vector3 dir = aimTarget.position - transform.position;
            b.GetComponent<Rigidbody>().linearVelocity = dir.normalized * currentShot.hitForce + new Vector3(0, currentShot.upForce, 0);
            //rb.AddForce(Vector3.up * forceStrength, ForceMode.Impulse);
            Debug.Log("Topspin!");
        }
        else
        {
            Debug.Log("No Ball interaction");
        }
    }
}




//public void TopspinShot()
//{
//    hitting = true;
//    currentShot = sM.topspin;
//}



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

//Provide a force with the value stored from above on Release
//else if (Input.GetKeyUp(KeyCode.R))
//{
//    //hitting = false;
//    Debug.Log("CanServe"); 
//    Vector3 dir = aimTarget.position - transform.position;
//    ball.GetComponent<Rigidbody>().linearVelocity = dir.normalized * currentShot.hitForce + new Vector3(0, currentShot.upForce, 0);
//}
//Topspin
//if (Input.GetKeyDown(KeyCode.Q))
//{
//    hitting = true;
//    currentShot = sM.SpinServe;
//    GetComponent<BoxCollider>().enabled = false;

//}
//else if (Input.GetKeyUp(KeyCode.Q))
//{
//    hitting = false;
//    GetComponent<BoxCollider>().enabled = true;
//    ball.transform.position = transform.position + new Vector3(0.2f, 1, 0);
//    Vector3 dir = aimTarget.position - transform.position;
//    ball.GetComponent<Rigidbody>().linearVelocity = dir.normalized * currentShot.hitForce + new Vector3(0, currentShot.upForce, 0);
//}
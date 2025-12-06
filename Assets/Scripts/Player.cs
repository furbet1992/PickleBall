using UnityEngine;
using UnityEngine.Assertions;

public class Player : MonoBehaviour
{
    public Transform aimTarget;
    float force = 15f;
    bool hitting;

    PlayerControls controls;
    //public InputActionReference move;

    Animator animator;
    //private Transform ball;
    public GameObject ballObject;

    ShotManagement sM;
    Shot currentShot;

    Vector3 aimTargetInitialPosition;

    AI ai;

    bool servedRight = true;

    Vector2 moveDirection;

    private BallController ballController;

    public ChargeBar chargeBar;

    //Serving
    public bool CanServe { get; set; } = false;
    public bool HasServed { get; private set; }
    //public bool MovementLocked { get; set; } = false;

    public Transform rightServePos;
    private Transform leftServePos;
    private Rigidbody rb;

    private PickleGameManager pickleGameManager;
    public string gameManagerTag;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        sM = GetComponent<ShotManagement>();
        chargeBar.GetComponent<ChargeBar>();
        GameObject pickleGameManagerObj = GameObject.FindGameObjectWithTag(gameManagerTag);
        if(pickleGameManagerObj)
        {
            pickleGameManager = pickleGameManagerObj.GetComponent<PickleGameManager>();
            Assert.IsNotNull(pickleGameManager);
        }
        else
        {
            Assert.IsTrue(false);
        }

        currentShot = sM.topspin;
        aimTargetInitialPosition = aimTarget.position;
        //b =  GetComponent<BallController>();
        Debug.Log($"Scene Start - HitForce: {sM.UnderArmServe.hitForce}, UpForce: {sM.UnderArmServe.upForce}");

    }

    public void Shoot(ShootType shootType)
    {
        pickleGameManager?.Shoot(shootType);
    }

    public void ServeFirst()
    {
        //Activate this Button, Start Charging for Power

        //if (Input.GetKeyDown(KeyCode.R))
        {
            //hitting = true;
            HasServed = true;
            Vector3 dir = aimTarget.position - transform.position;
            GameObject spawnBall = Instantiate(ballObject, transform.position + new Vector3(0.2f, 2f, 0), transform.rotation);
            spawnBall.SetActive(true);
            Rigidbody rb = spawnBall.GetComponent<Rigidbody>();
            ballController = spawnBall.GetComponent<BallController>();
            if (rb != null)
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

    public void MoveToRightServePosition()
    {
        if (rightServePos != null)
        {
            transform.position = rightServePos.position;
            transform.rotation = rightServePos.rotation;
            Debug.Log($"{name} moved to right serve position");
        }
        else
        {
            Debug.LogWarning($"{name} has no rightServePos assigned!");
        }
    }

    public void MoveToLeftServePosition()
    {
        if (leftServePos != null)
        {
            transform.position = leftServePos.position;
            transform.rotation = leftServePos.rotation;
            // Debug.Log($"{name} moved to left serve position");
        }
        else
        {
            //Debug.LogWarning($"{name} has no leftServePos assigned!");
        }
    }

    //Need to get the power 

    public void TopspinStroke()
    {
        if (ballController.canApplyForce == true)
        {
            Vector3 dir = aimTarget.position - transform.position;
            ballController.GetComponent<Rigidbody>().linearVelocity = dir.normalized * 15.0f + new Vector3(0, 10, 0); 
                //currentShot.hitForce + new Vector3(0, currentShot.upForce, 0);
            chargeBar.StartCharging();
            //rb.AddForce(Vector3.up * forceStrength, ForceMode.Impulse);
            Debug.Log("Topspin!");
        }
        else
        {
            Debug.Log(
                "No Ball interaction");
        }
    }

    public void FlatStroke()
    {
        if (ballController.canApplyForce == true)
        {
            Vector3 dir = aimTarget.position - transform.position;
            ballController.GetComponent<Rigidbody>().linearVelocity = dir.normalized * currentShot.hitForce + new Vector3(0, currentShot.upForce, 0);
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
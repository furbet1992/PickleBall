using UnityEngine;

public class BallController : MonoBehaviour
{
   public static BallController Instance;

    private Rigidbody rb;
    Shot currentShot;
    public ShotManagement shotManagement; 
    public bool canApplyForce = false;
    
   // [SerializeField] private float forceStrength = 10f;
    [SerializeField] private Transform aimTarget;


    public static bool serverWon; 
    public static bool pointOver; 

    public static bool serveLanded = false;
    public static bool inServeBox = false;
    public static bool pointEnded = false;

    private void Awake()
    {
        Instance = this;
        rb = GetComponent<Rigidbody>();
        currentShot = shotManagement.topspin;
    }

    private void OnTriggerEnter(Collider other)
    {
        // When the ball hits something, we check what it is.
        if (other.CompareTag("ServeBox"))
        {
            serveLanded = true;
            inServeBox = true;
            Debug.Log("Serve landed inside the serve box!");
        }
        else if (other.CompareTag("Out"))
        {
            serveLanded = true;
            inServeBox = false;
            Debug.Log("Serve landed out of bounds!");
        }
    
        if (other.CompareTag("Player")) // tag your collider
        {
            Debug.Log("hit player"); 
            canApplyForce = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canApplyForce = false;
        }
    }
}

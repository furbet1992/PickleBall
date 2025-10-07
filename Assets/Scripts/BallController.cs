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

    private void Awake()
    {
        Instance = this;
        rb = GetComponent<Rigidbody>();
        currentShot = shotManagement.topspin;
    }

    private void OnTriggerEnter(Collider other)
    {
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

    //public void AddForceToBall()
    //{
    //    if (canApplyForce)
    //    {
    //        Vector3 dir = aimTarget.position - transform.position; 
    //        rb.linearVelocity = dir.normalized * currentShot.hitForce + new Vector3(0, currentShot.upForce, 0);
    //        //rb.AddForce(Vector3.up * forceStrength, ForceMode.Impulse);
    //        Debug.Log("Topspin!");
    //    }
    //}
    //public void FlatStroke()
    //{
    //    if (canApplyForce)
    //    {
    //        currentShot = shotManagement.flat;
    //        Vector3 dir = aimTarget.position - transform.position;
    //        rb.linearVelocity = dir.normalized * currentShot.hitForce + new Vector3(0, currentShot.upForce, 0);
    //        //rb.AddForce(Vector3.up * forceStrength, ForceMode.Impulse);
    //        Debug.Log("Flat!");
    //    }
    //}
}

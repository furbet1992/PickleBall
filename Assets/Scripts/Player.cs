using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 1f;
    public Transform aimTarget;
    float force = 15f;
    bool hitting;

    Animator animator;
    public Transform ball;

    ShotManagement sM;
    Shot currentShot;

    Vector3 aimTargetInitialPosition;

    [SerializeField] Transform serveRight;
    [SerializeField] Transform serveLeft;

    bool servedRight = true; 


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        sM = GetComponent<ShotManagement>();
        currentShot = sM.topspin;
        aimTargetInitialPosition = aimTarget.position;
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

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

        if (hitting)
        {
            aimTarget.Translate(new Vector3(h, 0, v) * speed * Time.deltaTime);
        }

        if ((h != 0 || v != 0) && !hitting)
        {
            transform.Translate(new Vector3(h, 0, v) * speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            Vector3 dir = aimTarget.position - transform.position;
            other.GetComponent<Rigidbody>().linearVelocity = dir.normalized * currentShot.hitForce + new Vector3(0, currentShot.upForce, 0);


            Vector3 ballDir = ball.position - transform.position;
            if (ballDir.x <= 0)
            {
                animator.Play("Hitting");
                Debug.Log("hit");
            }
            else
            {
                animator.Play("Backhand");
            }
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

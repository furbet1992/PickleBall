using TMPro;
using UnityEngine;

public class AI : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    float speed = 30;
    Animator animator;
    public Transform ball;
    //public string balls = "Ball"; 
    //public Transform hitTarget;

    Vector3 targetPosition;
    [SerializeField] float force = 11f;
    [SerializeField] float upForce = 8f;
    public Transform[] targets; 

    ShotManagement shotManagement;
    Shot shots;

    void Start()
    {
        targetPosition = transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();    
    }

    void Move()
    {
        GameObject ballInstance = GameObject.FindGameObjectWithTag("Ball");
        if (ballInstance)
        {
            targetPosition.x = ballInstance.transform.position.x;        //ball.position.x;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        }
    }

    Vector3 PickTarget()
    {
        int randomValue = Random.Range(0, targets.Length);
        return targets[randomValue].position; 
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            Vector3 dir = PickTarget() - transform.position;
            other.GetComponent<Rigidbody>().linearVelocity = dir.normalized * force + new Vector3(0, upForce, 0);
            ball.GetComponent<Ball>().hitter = "AI";

            //Vector3 ballDir = ball.position - transform.position;
            //if (ballDir.x >= 0)
            //{
            //    animator.Play("Hitting");
            //    Debug.Log("hit");
            //}
            //else
            //{
            //    animator.Play("Backhand");
            //}
        }
    }
}

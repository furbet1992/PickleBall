using UnityEngine;

public class Player : MonoBehaviour
{
    public  float speed = 1f;
    public Transform aimTarget;
    float force = 10f; 
    bool hitting; 




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal"); 
        float v = Input.GetAxisRaw("Vertical");


        if (Input.GetKeyDown(KeyCode.F))
        {
            hitting = true;

        }else if (Input.GetKeyUp(KeyCode.F))
        {
            hitting = false;
        }

        if (hitting)
        {
            aimTarget.Translate(new Vector3(h, 0, v) * speed * Time.deltaTime); 
        }

        if(( h != 0 || v!= 0) && !hitting)
        {
            transform.Translate ( new Vector3 (h, 0, v) * speed * Time.deltaTime );
        }      
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            Vector3 dir = aimTarget.position - transform.position;
            other.GetComponent<Rigidbody>().linearVelocity = dir.normalized * force + new Vector3(0,5,0);
        }
    }
}

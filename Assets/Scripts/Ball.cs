using System.Runtime.CompilerServices;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public string hitter; 
    Vector3 initialPos;
    public ScoreBoard board;


    //double bounce
    public float doubleBounceTimeThreshold = 0.5f; 
    private float lastBounceTime = -Mathf.Infinity;
    [SerializeField] int bounceCount = 0; 



    void Start()
    {
        initialPos = transform.position;
        board.GetComponent<ScoreBoard>(); 
    }

    private void Update()
    {
        if (bounceCount >= 2)
        {
            if (hitter == "Player")
            {
                Debug.Log("player hit it- 2nd bounce");
                board.PlayerWinScoring();
            }
            else if (hitter == "AI")
            {
                board.AIWinScoring();
                Debug.Log("AI hit it - 2nd bounce");
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            if (Time.time - lastBounceTime < doubleBounceTimeThreshold)
            {
                bounceCount++;
                Debug.Log($"Double bounce detected! Total bounces in quick succession: {bounceCount}");
                // You can add specific logic here for a double bounce,
                // e.g., increasing a score, playing a sound, etc.
            }
            else
            {
                // Reset bounce count if the time since the last bounce is too long
                bounceCount = 1;
            }

            lastBounceTime = Time.time; // Update the time of the last bounce
        }
    
        if (collision.transform.CompareTag("Wall"))
        {
           GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
           GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

          // GameObject.Find("Player").GetComponent<Player>().Reset(); 
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Out") || other.CompareTag("Net"))
        {
            if(hitter == "Player")
            {
              Debug.Log("player hit it");
                board.PlayerWinScoring(); 
            } else if(hitter == "AI")
            {
                board.AIWinScoring();
                Debug.Log("AI hit it");
            }
        }
    }
}

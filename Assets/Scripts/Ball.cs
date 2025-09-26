using System.Runtime.CompilerServices;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public string hitter; 
    Vector3 initialPos;
    public ScoreBoard board;
    void Start()
    {
        initialPos = transform.position;
        board.GetComponent<ScoreBoard>(); 
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Wall"))
        {
           GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
           GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

           GameObject.Find("Player").GetComponent<Player>().Reset(); 
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

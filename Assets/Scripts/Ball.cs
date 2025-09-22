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

           GameObject.Find("player").GetComponent<Player>().Reset(); 
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Out"))
        {
            if(hitter == "Player")
            {
                board.AIScore++; 
            } else if(hitter == "AI")
            {
                board.playerScore++;
            }
        }
    }

}

using UnityEngine;

public class ScoreBoard : MonoBehaviour
{
    public int playerScore;
    public int AIScore; 

    void Start()
    {
     playerScore = 0;
     AIScore = 0;
}

    public void PlayerWinScoring()
    {
        playerScore++; 
    }   
    public void AIWinScoring()
    {
        AIScore++; 
    }




}

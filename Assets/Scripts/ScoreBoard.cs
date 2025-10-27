using UnityEngine;

public class ScoreBoard : MonoBehaviour
{
    public int player1Score;
    public int player2Score;

    public bool isPlayer1Serving = true;
    public bool serveOnRightSide = true;

    public void AddPointToServer()
    {
        if (isPlayer1Serving)
            player1Score++;
        else
            player2Score++;

        // Alternate serving side each successful serve win
        serveOnRightSide = !serveOnRightSide;

        if (player1Score >= 11 || player2Score >= 11)
        {
            if (Mathf.Abs(player1Score - player2Score) >= 2)
            {
                Debug.Log($"Game Over! {(player1Score > player2Score ? "Player 1" : "Player 2")} wins!");
            }
        }
    }
    public void SwitchServer()
    {
        isPlayer1Serving = !isPlayer1Serving;
        serveOnRightSide = true; // Always start new serve from right side
    }
    private void CheckForGameOver()
    {
        int winningScore = 11;
        int difference = Mathf.Abs(player1Score - player2Score);

        if ((player1Score >= winningScore || player2Score >= winningScore) && difference >= 2)
        {
            string winner = player1Score > player2Score ? "Player 1" : "Player 2";
            Debug.Log($"{winner} wins the game!");
            // You can trigger a GameOverState here later
        }
    }
    public string GetScoreText()
    {
        return $"P1: {player1Score} | P2: {player2Score}";
    }
    public void ResetGame()
    {
        player1Score = 0;
        player2Score = 0;
        isPlayer1Serving = true;
        serveOnRightSide = true;
    }
}










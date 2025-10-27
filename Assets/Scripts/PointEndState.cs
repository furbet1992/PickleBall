using UnityEngine;

    public class PointEndState : PickleState
    {
        public override void EnterState(PickleGameManager manager)
        {
        var scoreManager = manager.scoreManager;

        // Example: determine winner
        bool serverWon = BallController.serverWon; // you'll set this flag after the rally

        if (serverWon)
        {
            // ? Server gets a point and serves again from the opposite side
            scoreManager.AddPointToServer();
            Debug.Log("Server won the point!");

            // Go back to serve start for the same player (but other side)
            manager.ChangeState(manager.serveStartState);
        }
        else
        {
            scoreManager.SwitchServer();
            Debug.Log("Receiver won — serve changes!");

            manager.ChangeState(manager.serveStartState);
        }

        Debug.Log(scoreManager.GetScoreText());
    }

        public override void UpdateState(PickleGameManager manager)
        {
            // Wait a short delay before updating score
            manager.ChangeState(manager.scoreUpdateState);
        }

        public override void ExitState(PickleGameManager manager) { }
    }


using UnityEngine;

public class ScoreUpdateState : PickleState
{
    public override void Shoot(PickleGameManager manager, ShootType shootType)
    {
        UnityEngine.Debug.Log("ScoreUpdate shoot");
    }

    public override void EnterState(PickleGameManager manager)
    {
        Debug.Log("Updating score...");
        // Add point to winner
        // Check if game or match is over
    }

    public override void UpdateState(PickleGameManager manager)
    {
        //if (ScoreSystem.MatchOver)
        //    manager.ChangeState(manager.gameOverState);
        //else
        //    manager.ChangeState(manager.serveStartState);
    }

    public override void ExitState(PickleGameManager manager) { }
}
using UnityEngine;

public class GameOverState : PickleState
{
    public override void EnterState(PickleGameManager manager)
    {
        Debug.Log("Game over! Displaying results...");
        // Show winner, enable replay/menu UI
    }

    public override void UpdateState(PickleGameManager manager) { }

    public override void ExitState(PickleGameManager manager) { }
}
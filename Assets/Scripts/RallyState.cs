using UnityEngine;

public class RallyState : PickleState
{
    public override void EnterState(PickleGameManager manager)
    {
        Debug.Log("Rally started — play anywhere!");
        // Enable full court bounds
    }

    public override void UpdateState(PickleGameManager manager)
    {
        // Check ball out, double bounce, net hit, etc.
        //if (BallController.pointEnded)
        //{
        //    manager.ChangeState(manager.pointEndState);
        //}
    }

    public override void ExitState(PickleGameManager manager)
    {
        // Cleanup effects, stop sounds, etc.
    }
}
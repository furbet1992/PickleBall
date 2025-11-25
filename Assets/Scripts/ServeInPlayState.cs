using UnityEngine;
public class ServeInPlayState : PickleState
{
    private bool serveResultChecked = false;

    public override void Shoot(PickleGameManager manager, ShootType shootType)
    {
        UnityEngine.Debug.Log("Serve in play shoot");
    }

    public override void EnterState(PickleGameManager manager)
    {
        serveResultChecked = false;
        Debug.Log("Serve in play — waiting for result");
        UnityEngine.Debug.Log("ServeInPlay Enter");
    }

    public override void UpdateState(PickleGameManager manager)
    {
        // This should be triggered by your BallController
        if (!serveResultChecked && BallController.serveLanded)
        {
            serveResultChecked = true;
            if (BallController.inServeBox)
            {
                //manager.player1
                manager.ChangeState(manager.rallyState);
                Debug.Log("Proceed to Rally");
            }
            else
            {
                manager.ChangeState(manager.pointEndState);
            }
        }
    }
    public override void ExitState(PickleGameManager manager) { }
}


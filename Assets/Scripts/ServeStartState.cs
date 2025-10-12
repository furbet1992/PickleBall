using UnityEngine;

public class ServeStartState : PickleState

{
    public override void EnterState(PickleGameManager manager)
    {
        Debug.Log("Player ready to serve");
        // Enable serve input, serve UI prompt
    }

    public override void UpdateState(PickleGameManager manager)
    {
        manager.player.ServeFirst();
        //if (manager.player.HasServed)
        //{
        //    manager.ChangeState(manager.serveInPlayState);
        //}

        //// Wait for player to press serve key/button
        //if (Input.GetKeyDown(KeyCode.Space)) // Example serve input
        //{
        //    //Vector3 dir = aimTarget.position - transform.position;
        //    // Trigger serve animation here
        //    manager.ChangeState(manager.serveInPlayState);
        //}
    }

    public override void ExitState(PickleGameManager manager)
    {
        // Hide serve UI or disable serve controls
    }
}
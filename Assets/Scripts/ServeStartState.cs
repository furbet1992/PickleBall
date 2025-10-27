using UnityEngine;
using UnityEngine.SceneManagement;
//using UnityEngine.SceneManagement;

public class ServeStartState : PickleState

{
    private PickleGameManager gameManager;
    private Player player;



    public void StartServe(PickleGameManager gm, Player p)
    {
        gameManager = gm;
        player = p;
    }
    public override void EnterState(PickleGameManager manager)
    {
        player.MovementLocked = true;
        if (gameManager.scoreManager.serveOnRightSide)
            player.MoveToRightServePosition();
        else
            player.MoveToLeftServePosition();

        player.CanServe = true;
        Debug.Log("Player ready to serve.");
    }

    public override void UpdateState(PickleGameManager manager)
    {
        manager.player.ServeFirst();

        if (manager.player.HasServed)
        {
            manager.player1.serveMovedDisabled = false;
            manager.ChangeState(manager.serveInPlayState);
        }

        if (manager.scoreManager.serveOnRightSide)
            manager.player.MoveToRightServePosition();
        else
            manager.player.MoveToLeftServePosition();
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
        player.MovementLocked = false;
        player.CanServe = false;
        // Hide serve UI or disable serve controls
    }
}
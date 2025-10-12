using UnityEngine;

    public class PointEndState : PickleState
    {
        public override void EnterState(PickleGameManager manager)
        {
            Debug.Log("Point ended!");
            // Determine winner of the rally
            // Maybe slow down time, show who won the point
        }

        public override void UpdateState(PickleGameManager manager)
        {
            // Wait a short delay before updating score
            manager.ChangeState(manager.scoreUpdateState);
        }

        public override void ExitState(PickleGameManager manager) { }
    }


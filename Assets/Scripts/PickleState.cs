using UnityEngine;

    public abstract class PickleState
    {
        public abstract void EnterState(PickleGameManager manager);
        public abstract void UpdateState(PickleGameManager manager);
        public abstract void ExitState(PickleGameManager manager);
    }

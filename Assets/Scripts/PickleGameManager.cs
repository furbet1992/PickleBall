using UnityEngine;

public class PickleGameManager : MonoBehaviour
{
    public PickleState currentState;
    public Player player;
    public PlayerController player1;
    public PlayerController player2;

    public ScoreBoard scoreManager; 

    // Each state as separate class instances
    public ServeStartState serveStartState = new ServeStartState();
    public ServeInPlayState serveInPlayState = new ServeInPlayState();
    public RallyState rallyState = new RallyState();
    public PointEndState pointEndState = new PointEndState();
    public ScoreUpdateState scoreUpdateState = new ScoreUpdateState();
    public GameOverState gameOverState = new GameOverState();

    void Start()
    {
        scoreManager = GetComponent<ScoreBoard>();
        ChangeState(serveStartState);
    }

    void Update()
    {
        currentState?.UpdateState(this);
    }

    public void ChangeState(PickleState newState)
    {
        currentState?.ExitState(this);
        currentState = newState;
        currentState.EnterState(this);
        //Debug.Log($"State changed to: {newState.GetType().Name}");
    }
}
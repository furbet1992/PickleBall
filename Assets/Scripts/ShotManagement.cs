using UnityEngine;


[System.Serializable]
public class Shot
{
    public float upForce;
    public float hitForce; 
}


public class ShotManagement : MonoBehaviour
{
    public Shot topspin;
    public Shot flat; 
    public Shot UnderArmServe; 
    public Shot SpinServe; 
}


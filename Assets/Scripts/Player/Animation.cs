using UnityEngine;

public class Animation : MonoBehaviour
{
    public Animator anim;
    public bool canRun = false; 


    void Start()
    {
        anim = GetComponent<Animator>();  
    }

    // Update is called once per frame
    void Update()
    {
        if (canRun)
        {
            MovingAnim(); 
        }
    }

    void MovingAnim()
    {
       //anim.set
    }




}


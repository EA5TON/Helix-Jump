using Unity.VisualScripting;
using UnityEngine;

public class Ball: MonoBehaviour
{
    public float Rebound;
    public Rigidbody Rigidbody;
    public Platform Current_Platform;
    public Game Game;

    private AudioSource Audio_Source;

    //------------------------------------------------------------------------------------------------------------------------
    private void Start ()
    {
        Audio_Source = GetComponent <AudioSource> ();
    }
    //------------------------------------------------------------------------------------------------------------------------
    public void Reach_Finish ()
    {
        Game.On_Play_Finish ();
        Rigidbody.velocity = Vector3.zero;
    }
    //------------------------------------------------------------------------------------------------------------------------
    public void Bounce ()
    {
        Rigidbody.velocity = new Vector3 (0, Rebound, 0);
    }
    //------------------------------------------------------------------------------------------------------------------------
    public void Die ()
    {
        Game.On_Player_Died ();
        Rigidbody.velocity = Vector3.zero;
    }
    //------------------------------------------------------------------------------------------------------------------------
    private void OnCollisionEnter (Collision collision)
    {
        Audio_Source.Play ();
    }
    //------------------------------------------------------------------------------------------------------------------------
}
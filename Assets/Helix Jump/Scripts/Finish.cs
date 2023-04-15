using UnityEngine;

public class Finish: MonoBehaviour
{
    private AudioSource Audio_Source;

    //------------------------------------------------------------------------------------------------------------------------
    private void Start ()
    {
        Audio_Source = GetComponent <AudioSource> ();
    }
    //------------------------------------------------------------------------------------------------------------------------
    private void OnCollisionEnter (Collision collision)
    {
        if (! collision.collider.TryGetComponent (out Ball ball))
            return;

        ball.Reach_Finish ();
    }
    //------------------------------------------------------------------------------------------------------------------------
    private void OnTriggerEnter (Collider other)
    {
        Audio_Source.Play ();
    }
    //------------------------------------------------------------------------------------------------------------------------
}
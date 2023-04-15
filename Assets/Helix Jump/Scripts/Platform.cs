using UnityEngine;

public class Platform: MonoBehaviour
{
    private AudioSource Audio_Source;

    //------------------------------------------------------------------------------------------------------------------------
    private void Start ()
    {
        Audio_Source = GetComponent <AudioSource> ();
    }
    //------------------------------------------------------------------------------------------------------------------------
    private void OnTriggerEnter (Collider other)
    {
        if (other.TryGetComponent (out Ball ball))
            ball.Current_Platform = this;

        Game.Singleton.Scors (1);
    }
    //------------------------------------------------------------------------------------------------------------------------
    private void OnTriggerExit (Collider other)
    {
        Audio_Source.Play ();
    }
    //------------------------------------------------------------------------------------------------------------------------
}
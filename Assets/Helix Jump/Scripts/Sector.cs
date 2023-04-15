using UnityEngine;

public class Sector: MonoBehaviour
{
    public bool Live = true;
    public Material Live_Sector;
    public Material Death_Sector;

    //------------------------------------------------------------------------------------------------------------------------
    private void Awake ()
    {
        Update_Material ();
    }
    //------------------------------------------------------------------------------------------------------------------------
    private void Update_Material ()
    {
        Renderer sector_render = GetComponent <Renderer> ();
        sector_render.sharedMaterial = Live ? Live_Sector : Death_Sector;
    }
    //------------------------------------------------------------------------------------------------------------------------
    private void OnCollisionEnter (Collision collision)
    {
        if (! collision.collider.TryGetComponent (out Ball ball))
            return;

        Vector3 normal = -collision.contacts [0].normal.normalized;

        float dot = Vector3.Dot (normal, Vector3.up);
        if (dot < 0.5)
            return;

        if (Live)
            ball.Bounce ();
        else
            ball.Die ();
    }
    //------------------------------------------------------------------------------------------------------------------------
    private void OnValidate ()
    {
        Update_Material ();
    }
    //------------------------------------------------------------------------------------------------------------------------
}
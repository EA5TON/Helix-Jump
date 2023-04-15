using UnityEngine;

public class Controls: MonoBehaviour
{
    public Transform Level;
    public float Speed_Rotate;
    
    private Vector3 Prev_Mouse_Pos;

    //------------------------------------------------------------------------------------------------------------------------
    void Update ()
    {
        if (Input.GetMouseButton (0))
        {
            Vector3 del = Input.mousePosition - Prev_Mouse_Pos;
            Level.Rotate (0, -del.x * Speed_Rotate, 0);
        }

        Prev_Mouse_Pos = Input.mousePosition;
    }
    //------------------------------------------------------------------------------------------------------------------------
}
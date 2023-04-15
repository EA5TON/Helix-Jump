using UnityEngine;

public class Camera_Follow: MonoBehaviour
{
    public Ball Ball;
    public Vector3 Offset;
    //private float Offset;
    public float Camera_Movement_Speed;

    //public void Awake ()
    //{
    //    Offset = transform.position.y - Ball.transform.position.y;
    //}

    //------------------------------------------------------------------------------------------------------------------------
    public void Update ()
    {
        if (Ball.Current_Platform == null)
            return;

        Vector3 target_position = Ball.Current_Platform.transform.position + Offset;
        transform.position = Vector3.MoveTowards (transform.position, target_position, Camera_Movement_Speed * Time.deltaTime);

        //Vector3 cam_pos = transform.position;
        //cam_pos.y = Ball.transform.position.y + Offset;
        //transform.position = cam_pos;
    }
    //------------------------------------------------------------------------------------------------------------------------
}
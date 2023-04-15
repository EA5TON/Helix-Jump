using UnityEngine;
using UnityEngine.UI;

public class Progress_Bar: MonoBehaviour
{
    public Ball Ball;
    public Text Score;
    public Text Best_Score;
    public Transform Finish_Platform;
    public Slider Slider;
    public float Permissible_Distance = 1f;

    private float start_y_pos;
    private float min_y_pos;
    //------------------------------------------------------------------------------------------------------------------------
    private void Start ()
    {
        start_y_pos = Ball.transform.position.y;
    }
    //------------------------------------------------------------------------------------------------------------------------
    private void Update ()
    {
        min_y_pos = Mathf.Min (min_y_pos, Ball.transform.position.y);
        float end_y_pos = Finish_Platform.position.y;
        float t = Mathf.InverseLerp (start_y_pos, end_y_pos + Permissible_Distance, min_y_pos);
        Slider.value = t;

        Score.text = "Score: " + Game.Singleton.Score;
        Best_Score.text = "Best score: " + Game.Singleton.Best_Score;
    }
    //------------------------------------------------------------------------------------------------------------------------
}
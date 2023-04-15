using UnityEngine;
using UnityEngine.UI;

public class Level_Number: MonoBehaviour
{
    public Text Level;
    public Game Game;

    //------------------------------------------------------------------------------------------------------------------------
    public void Start ()
    {
        Level.text = "Level: " + (Game.Index_Level + 1).ToString ();
    }
    //------------------------------------------------------------------------------------------------------------------------
}
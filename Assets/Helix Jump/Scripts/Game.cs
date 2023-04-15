using UnityEngine;
using UnityEngine.SceneManagement;

public class Game: MonoBehaviour
{
    public Controls Controls;
    public int Score;
    public int Best_Score;
    public static Game Singleton;

    private const string Level_Key = "Level_Index";

    //------------------------------------------------------------------------------------------------------------------------
    public enum EGame_State
    {
        EGS_Play,
        EGS_Lose,
        EGS_Win
    }
    //------------------------------------------------------------------------------------------------------------------------
    public EGame_State Current_Game_State
    {
        get; private set;
    }
    //------------------------------------------------------------------------------------------------------------------------
    public void Awake ()
    {
        if (Singleton == null)
            Singleton = this;
        else if (Singleton != this)
            Destroy (gameObject);

        Best_Score = PlayerPrefs.GetInt ("Best_Score");
    }
    //------------------------------------------------------------------------------------------------------------------------
    public void On_Player_Died ()
    {
        if (Current_Game_State != EGame_State.EGS_Play)
            return;

        Current_Game_State = EGame_State.EGS_Lose;
        Controls.enabled = false;
        Invoke ("Reload_Level", 1);
    }
    //------------------------------------------------------------------------------------------------------------------------
    public void On_Play_Finish ()
    {
        if (Current_Game_State != EGame_State.EGS_Play)
            return;

        Current_Game_State = EGame_State.EGS_Win;
        Controls.enabled = false;
        Index_Level++;
        Invoke ("Load_New_Level", 2);
    }
    //------------------------------------------------------------------------------------------------------------------------
    public int Index_Level
    {
        get => PlayerPrefs.GetInt (Level_Key, 0);

        private set
        {
            PlayerPrefs.SetInt (Level_Key, value);
            PlayerPrefs.Save ();
        }
    }
    //------------------------------------------------------------------------------------------------------------------------
    private void Reload_Level ()
    {
        SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
    }
    //------------------------------------------------------------------------------------------------------------------------
    private void Load_New_Level ()
    {
        SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);

        if (SceneManager.GetActiveScene ().buildIndex >= 4)
            SceneManager.LoadScene (0);
    }
    //------------------------------------------------------------------------------------------------------------------------
    public void Scors (int add_score)
    {
        Score += add_score;

        if (Score > Best_Score)
            Best_Score = Score;
        else if (Best_Score >= Score)
            return;

        PlayerPrefs.SetInt ("Best_Score", Score);
        PlayerPrefs.SetInt ("Score", Score);
    }
    //------------------------------------------------------------------------------------------------------------------------
}
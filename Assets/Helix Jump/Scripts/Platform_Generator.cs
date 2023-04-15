using UnityEngine;
using Random = System.Random;

public class Platform_Generator: MonoBehaviour
{    
    public GameObject [] Platform_Prefabs;
    public GameObject Start_Platform;

    public Transform Platform_Win;
    public Transform Cylinder_Root;

    public Game Game;

    public int Min_Platforms, Max_Platforms;
    public float Distance_Between_Platform;
    public float Cylinder_Scale = 0.1f;

    //------------------------------------------------------------------------------------------------------------------------
    private void Awake ()
    {
        int i;
        int index_level = Game.Index_Level;
        Random rand = new (index_level);
        int platforms = Rand_Range (rand, Min_Platforms, Max_Platforms + 1);

        for (i = 0; i < platforms; i++)
        {
            int index_prefabs = Rand_Range (rand, 0, Platform_Prefabs.Length);
            GameObject platform_prefabs = i ==  0 ? Start_Platform : Platform_Prefabs [index_prefabs];
            GameObject platform = Instantiate (platform_prefabs, transform);
            platform.transform.localPosition = Calculate_Platform_Position (i);

            if (i > 0)
                platform.transform.localRotation = Quaternion.Euler (0, Random_Range (rand, 0, 360f), 0);
        }

        Platform_Win.localPosition = Calculate_Platform_Position (platforms);
        Cylinder_Root.localScale = new (1, platforms * Distance_Between_Platform + Cylinder_Scale, 1);
    }
    //------------------------------------------------------------------------------------------------------------------------
    private int Rand_Range (Random rand, int min, int max_exc)
    {
        int number = rand.Next (min, max_exc);
        int lenght = max_exc - min;
        number %= lenght;

        return min + number;
    }
    //------------------------------------------------------------------------------------------------------------------------
    private float Random_Range (Random rand, float min, float max)
    {
        float t = (float) rand.NextDouble ();

        return Mathf.Lerp (min, max, t);
    }
    //------------------------------------------------------------------------------------------------------------------------
    private Vector3 Calculate_Platform_Position (int index_platform)
    {
        return new (0, -Distance_Between_Platform * index_platform, 0);
    }
    //------------------------------------------------------------------------------------------------------------------------
}
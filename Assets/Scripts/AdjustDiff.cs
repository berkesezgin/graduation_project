using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjustDiff : MonoBehaviour
{
    public void hard()
    {
        PlayerPrefs.SetInt("diff", 1);
        PlayerPrefs.Save();

        
    }

    public void easy()
    {
        PlayerPrefs.SetInt("diff", 0);
        PlayerPrefs.Save();


    }

    public void Start()
    {
        Debug.Log(PlayerPrefs.GetInt("diff"));
    }
}

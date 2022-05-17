using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    public static string PreviousLevel;
    Scene prevscene;
    private void getscene()
    {
        prevscene = SceneManager.GetActiveScene();
        if(prevscene.name != "GameOver")
        {
            PreviousLevel = prevscene.name;
        }
        
    }

    private void Start()
    {
        getscene();
        Debug.Log(Level.PreviousLevel);  // use this in any level to get the last level.
    }
}

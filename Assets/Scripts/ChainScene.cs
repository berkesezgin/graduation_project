using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChainScene : MonoBehaviour
{
    
    public void MoveToScene()
    {

        if (Level.PreviousLevel == "level1")
        {
            SceneManager.LoadScene("level2", LoadSceneMode.Single);
        }
        if (Level.PreviousLevel == "level2")
        {
            SceneManager.LoadScene("level3", LoadSceneMode.Single);
        }
        if (Level.PreviousLevel == "level3")
        {
            SceneManager.LoadScene("Menu", LoadSceneMode.Single);
        }
    }
    public void RepeatScene()
    {
        if (Level.PreviousLevel == "level1")
        {
            SceneManager.LoadScene("level1", LoadSceneMode.Single);
        }
        if (Level.PreviousLevel == "level2")
        {
            SceneManager.LoadScene("level2", LoadSceneMode.Single);
        }
        if (Level.PreviousLevel == "level3")
        {
            SceneManager.LoadScene("Level3", LoadSceneMode.Single);
        }
    }
}

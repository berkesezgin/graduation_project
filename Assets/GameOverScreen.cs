using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
    public string finalTime; //Final Time which is taken from Game Control script.
    public static string showFinalTime; //Final Time as static string in order to display it on screen.

    public static string child_username = "child1"; //Username of the child normally will be taken from Game Control.
    public static string status; //Status taken from Game Control given according to the Final Time.

    public static string difficulty_string;


    private void Start()
    {
        showFinalTime = GameController.showFinalTime;
        Debug.Log("Showing Final Time: " + showFinalTime);

        Text txtTime = transform.Find("Time").GetComponent<Text>();
        txtTime.text = showFinalTime;

        Text txtUsername = transform.Find("Username").GetComponent<Text>();
        txtUsername.text = child_username;

        status = GameController.status;
        Debug.Log("Your status is: " + status);

        Text txtStatus = transform.Find("Status").GetComponent<Text>();
        txtStatus.text = status;

        if (PlayerPrefs.GetInt("diff") == 1)
        {
            difficulty_string = "hard";
        }
        else if (PlayerPrefs.GetInt("diff") == 0)
        {
            difficulty_string = "easy";
        }
        else if (!(PlayerPrefs.GetInt("diff") == 1 && PlayerPrefs.GetInt("diff") == 0))
        {
            difficulty_string = "easy";
        }

        Text txtDifficulty = transform.Find("Difficulty").GetComponent<Text>();
        txtDifficulty.text = "Mode: " + difficulty_string;

    }
}

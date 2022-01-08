using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalTime : MonoBehaviour
{
    public static string showFinalTime;
    public string report_number;
    public string child_username;

    private void Start()
    {
        showFinalTime = GameController.showFinalTime;
        Debug.Log("Showing Final Time: " + showFinalTime);

        Text txt = transform.Find("Time").GetComponent<Text>();
        txt.text = showFinalTime;


        

    }
}

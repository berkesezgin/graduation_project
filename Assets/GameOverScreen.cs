using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Text;

public class GameOverScreen : MonoBehaviour
{
    public string finalTime; //Final Time which is taken from Game Control script.
    public static string showFinalTime; //Final Time as static string in order to display it on screen.
    public static string child_username = "child1"; //Username of the child normally will be taken from Game Control.
    public static int report_number_int;
    public static string report_number;
    public static string status; //Status taken from Game Control given according to the Final Time.
    public static string difficulty_string;
    private PatientData _patientData;


    private void Start()
    {
        report_number_int = report_number_int+1;
        report_number = report_number_int.ToString();
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
            difficulty_string = "Hard";
        }
        else if (PlayerPrefs.GetInt("diff") == 0)
        {
            difficulty_string = "Easy";
        }
        else if (!(PlayerPrefs.GetInt("diff") == 1 && PlayerPrefs.GetInt("diff") == 0))
        {
            difficulty_string = "Easy";
        }

        Text txtDifficulty = transform.Find("Difficulty").GetComponent<Text>();
        txtDifficulty.text = "Mode: " + difficulty_string;

        _patientData = new PatientData();
        _patientData.pname = child_username;
        _patientData.report_no = report_number;
        _patientData.status = status;
        _patientData.time = showFinalTime;
        _patientData.difficulty = difficulty_string;

        StartCoroutine(Upload(_patientData.Stringify(), result => {
            Debug.Log(result);
        }));

    }

    IEnumerator Upload(string profile, System.Action<bool> callback = null)
    {
        using (UnityWebRequest request = new UnityWebRequest("http://127.0.0.1:8000/send_patient_data", "POST"))
        {
            request.SetRequestHeader("Content-Type", "application/json");
            byte[] bodyRaw = Encoding.UTF8.GetBytes(profile);
            request.uploadHandler = new UploadHandlerRaw(bodyRaw);
            request.downloadHandler = new DownloadHandlerBuffer();
            yield return request.SendWebRequest();
            if (request.isNetworkError || request.isHttpError)
            {
                Debug.Log(request.error);
                if(callback != null)
                {
                    callback.Invoke(false);
                }
            }
            else
            {
                if(callback != null)
                {
                    callback.Invoke(request.downloadHandler.text != "{}");
                }
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Text;

public class reportShowScript : MonoBehaviour
{
    
    public string finalTime; //Final Time which is taken from Game Control script.
    public static string showFinalTime; //Final Time as static string in order to display it on screen.

    public static string report_number; // Report Number needs to be generated in this script. But still static at this point!!!

    public static string child_username = "child1"; //Username of the child normally will be taken from Game Control.
    public static string status; //Status taken from Game Control given according to the Final Time.

    public static string difficulty_string;
    private ReportData _reportData;

    private CreateNumberData _createNumberData;

    // Start is called before the first frame update
    private void Start()
    {

        report_number = sendReportNumber.report_number; // Where you will change the report number!!!(MongoDB)
        Debug.Log("Show report number: " + report_number);

        Text txtReport = transform.Find("ReportNumber").GetComponent<Text>(); //Printing report number as text
        txtReport.text = "Report: " + report_number;

        showFinalTime = GameController.showFinalTime; // Where you will change the report number
        Debug.Log("Showing Final Time: " + showFinalTime);

        Text txtTime = transform.Find("TimeText").GetComponent<Text>(); //Printing the time as text
        txtTime.text = showFinalTime;

        Text txtUsername = transform.Find("Username").GetComponent<Text>(); //Printing the username as text
        txtUsername.text = "Username: " + child_username;

        status = GameController.status; // Where you will change the report number!!!(MongoDB)
        Debug.Log("Your status is: " + status);

        Text txtStatus = transform.Find("Status").GetComponent<Text>(); //Printing the status as text
        txtStatus.text = "Status: " + status;

        Text txtDifficulty = transform.Find("Difficulty").GetComponent<Text>();
        txtDifficulty.text = "Difficulty: " + difficulty_string;

        _createNumberData = new CreateNumberData();
        _createNumberData.report_no = report_number;

        StartCoroutine(Upload(_createNumberData.Stringify(), result => {
            Debug.Log("upload" + result);
        }));

    }
    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Upload(string profile, System.Action<bool> callback = null)
    {
        using (UnityWebRequest request = new UnityWebRequest("http://127.0.0.1:8000//request_patient_data", "POST"))
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

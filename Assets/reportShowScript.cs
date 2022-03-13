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


    // Start is called before the first frame update
    private void Start()
    {

        _reportData = new ReportData();
    
        report_number = sendReportNumber.report_no; // Where you will change the report number!!!(MongoDB)
        Debug.Log("Show report number: " + report_number);

        StartCoroutine(Download(report_number, result => {
            Debug.Log("Burada " + result.report_no);

            Text txtReport = transform.Find("ReportNumber").GetComponent<Text>(); //Printing report number as text
        txtReport.text = "Report: " + result.report_no;

        showFinalTime = GameController.showFinalTime; // Where you will change the report number
        Debug.Log("Showing Final Time: " + result.time);

        Text txtTime = transform.Find("TimeText").GetComponent<Text>(); //Printing the time as text
        txtTime.text = showFinalTime;

        Text txtUsername = transform.Find("Username").GetComponent<Text>(); //Printing the username as text
        txtUsername.text = "Username: " + result.pname;

        status = GameController.status; // Where you will change the report number!!!(MongoDB)
        Debug.Log("Your status is: " + result.status);

        Text txtStatus = transform.Find("Status").GetComponent<Text>(); //Printing the status as text
        txtStatus.text = "Status: " + result.status;

        Text txtDifficulty = transform.Find("Difficulty").GetComponent<Text>();
        txtDifficulty.text = "Difficulty: " + result.difficulty;
        }));


        



    }
    // Update is called once per frame
    void Update()
    {
        
    }

    

IEnumerator Download(string report_number, System.Action<ReportData> callback = null)
{
    using (UnityWebRequest request = UnityWebRequest.Get("http://localhost:8000/patient_report?reportInput=" + report_number))
    {
        yield return request.SendWebRequest();

        if (request.isNetworkError || request.isHttpError)
        {
            Debug.Log(request.error);
            if (callback != null)
            {
                callback.Invoke(null);
            }
        }
        else
        {
            if (callback != null)
            {
                callback.Invoke(ReportData.Parse(request.downloadHandler.text));
            }
        }
    }
}
}

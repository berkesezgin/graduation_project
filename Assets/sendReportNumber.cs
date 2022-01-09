using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class sendReportNumber : MonoBehaviour
{

    public static string report_number;
    public TMP_InputField report_number_inputField;

    public void setName()
    {
        report_number = report_number_inputField.text;
        Debug.Log("Report Number: " + report_number);
    }

}

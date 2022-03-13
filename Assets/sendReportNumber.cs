using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class sendReportNumber : MonoBehaviour
{

    public static string report_no;
    public TMP_InputField report_number_inputField;

    public void setName()
    {
        report_no = report_number_inputField.text;
        Debug.Log("Report Number: " + report_no);
    }

}

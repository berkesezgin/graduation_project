using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReportData 
{
    public string report_no;
    public string pname;
    public string difficulty;
    public string time;
    public string status;



        // 'public' variables here ...
    public string Stringify()
    {
        return JsonUtility.ToJson(this);
    }
    public static ReportData Parse(string json)
    {
        return JsonUtility.FromJson<ReportData>(json);
    }
}

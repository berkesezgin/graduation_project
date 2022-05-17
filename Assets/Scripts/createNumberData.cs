using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateNumberData
{
    public string report_no;

        // 'public' variables here ...
    public string Stringify()
    {
        return JsonUtility.ToJson(this);
    }
    public static CreateNumberData Parse(string json)
    {
        return JsonUtility.FromJson<CreateNumberData>(json);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginMessage 
{
    public string message;

    public string Stringify()
    {
        return JsonUtility.ToJson(this);
    }
    public static LoginMessage Parse(string json)
    {
        return JsonUtility.FromJson<LoginMessage>(json);
    }
}


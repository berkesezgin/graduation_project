using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignupMessage 
{
    public string message;

    public string Stringify()
    {
        return JsonUtility.ToJson(this);
    }
    public static SignupMessage Parse(string json)
    {
        return JsonUtility.FromJson<SignupMessage>(json);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class sendChildUsername : MonoBehaviour
{

    string child_username;
    public TMP_InputField child_username_inputField;

    public void setName()
    {
        child_username = child_username_inputField.text;
        Debug.Log("Child's username: " + child_username);
    }

}

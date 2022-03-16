using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class signupChildUsername : MonoBehaviour
{

    public static string signup_child_username;
    public TMP_InputField child_signup_username_inputField;

    public void setName()
    {
        //Berke bu fonksiyon signup olduğu için mongoDB'de girilen isim daha önceden var mı yok mu onu check etmeli, sonrasında eğer yoksa yeni bir user yaratmalı, eğer varsa this username already exists tarzı bir output vermeli.


        signup_child_username = child_signup_username_inputField.text;
        Debug.Log("Child Signup Username: " + signup_child_username);
    }

}
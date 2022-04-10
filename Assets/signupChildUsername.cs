using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class signupChildUsername : MonoBehaviour
{

    public static string signup_child_username;
    public TMP_InputField child_signup_username_inputField;

    [SerializeField] private GameObject ChildLoginMenu = null;
    [SerializeField] private GameObject ChildSignupMenu = null;

    public void setName()
    {
        

        signup_child_username = child_signup_username_inputField.text;
        Debug.Log("Child Signup Username: " + signup_child_username);

        if (signup_child_username == "berkay")
        {
            TextMeshProUGUI placeholder = (TextMeshProUGUI)child_signup_username_inputField.placeholder;
            placeholder.text = "The User already exists!";
        }
        else
        {
            
            //Berke bu fonksiyon signup olduğu için mongoDB'de girilen isim daha önceden var mı yok mu onu check etmeli, sonrasında eğer yoksa yeni bir user yaratmalı, eğer varsa this username already exists tarzı bir output vermeli.
            
            Debug.Log(signup_child_username + " Succesfully signed up!");
            ChildSignupMenu.SetActive(false);
            ChildLoginMenu.SetActive(true);
        }
        child_signup_username_inputField.text = "";
    }

}
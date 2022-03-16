using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class loginChildUsername : MonoBehaviour
{

    public static string login_child_username;
    public TMP_InputField child_login_username_inputField;

    public void setName()
    {
        //Berke bu fonksiyon login olduğu için mongoDB'de girilen isim daha önceden var mı yok mu onu check etmeli, sonrasında eğer varsa play screenine devam edebilir, eğer yoksa username doesn't exist tarzı bir output vermeli.


        login_child_username = child_login_username_inputField.text;
        Debug.Log("Child Login Username: " + login_child_username);
    }

}
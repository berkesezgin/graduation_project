using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class loginChildUsername : MonoBehaviour
{
    public static string login_child_username;
    public TMP_InputField child_login_username_inputField;

    [SerializeField] private GameObject ChildMenu = null;
    [SerializeField] private GameObject ChildLoginMenu = null;
    public void setName()
    {
        
        login_child_username = child_login_username_inputField.text;
        Debug.Log("Child Login Username: " + login_child_username);

        if (login_child_username != "berkay")
        {
            TextMeshProUGUI placeholder = (TextMeshProUGUI)child_login_username_inputField.placeholder;
            placeholder.text = "The Username doesn't exist!";
        }
        else
        {

            //Berke bu fonksiyon login olduğu için mongoDB'de girilen isim daha önceden var mı yok mu onu check etmeli, sonrasında eğer varsa play screenine devam edebilir, eğer yoksa username doesn't exist tarzı bir output vermeli.
            
            Debug.Log(login_child_username + " Succesfully Logged in!");
            ChildLoginMenu.SetActive(false);
            ChildMenu.SetActive(true);
        }
        child_login_username_inputField.text = "";
    }

}
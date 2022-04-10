using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Text;
using TMPro;


public class loginChildUsername : MonoBehaviour
{
    public static string login_child_username;
    public TMP_InputField child_login_username_inputField;

    private LoginMessage _loginMessage;
    public static string login_message_text;

    [SerializeField] private GameObject ChildMenu = null;
    [SerializeField] private GameObject ChildLoginMenu = null;
    public void setName()
    {

        _loginMessage = new LoginMessage();
        
        login_child_username = child_login_username_inputField.text;
        Debug.Log("Child Login Username: " + login_child_username);



        StartCoroutine(Download(login_child_username, result => {
        Debug.Log("Message: " + result.message);

        if (result.message == "False")
        {
            TextMeshProUGUI placeholder = (TextMeshProUGUI)child_login_username_inputField.placeholder;
            placeholder.text = "The Username doesn't exist!";

            ChildLoginMenu.SetActive(true);
        }
        else
        {
            //Berke bu fonksiyon login olduğu için mongoDB'de girilen isim daha önceden var mı yok mu onu check etmeli, sonrasında eğer varsa play screenine devam edebilir, eğer yoksa username doesn't exist tarzı bir output vermeli.
            
            Debug.Log(login_child_username + " Succesfully Logged in!");
            ChildLoginMenu.SetActive(false);
            ChildMenu.SetActive(true);
        }
        child_login_username_inputField.text = "";

        }));
    }

IEnumerator Download(string login_child_username, System.Action<LoginMessage> callback = null)
{
    using (UnityWebRequest request = UnityWebRequest.Get("http://localhost:8000/login_patient?pname=" + login_child_username))
    {
        yield return request.SendWebRequest();

        if (request.isNetworkError || request.isHttpError)
        {
            Debug.Log(request.error);
            if (callback != null)
            {
                callback.Invoke(null);
            }
        }
        else
        {
            if (callback != null)
            {
                callback.Invoke(LoginMessage.Parse(request.downloadHandler.text));
            }
        }
    }
}




}
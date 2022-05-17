using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Text;
using TMPro;

public class signupChildUsername : MonoBehaviour
{

    public static string signup_child_username;
    public TMP_InputField child_signup_username_inputField;
    private SignupMessage _signupMessage;
    public static string signup_message_text;

    [SerializeField] private GameObject ChildLoginMenu = null;
    [SerializeField] private GameObject ChildSignupMenu = null;

    public void setName()
    {
        
        _signupMessage = new SignupMessage();

        signup_child_username = child_signup_username_inputField.text;
        Debug.Log("Child Signup Username: " + signup_child_username);

        StartCoroutine(Download(signup_child_username, result => {
        Debug.Log("Message: " + result.message);

        if (result.message == "True")
        {
            TextMeshProUGUI placeholder = (TextMeshProUGUI)child_signup_username_inputField.placeholder;
            placeholder.text = "The User already exists!";

            ChildSignupMenu.SetActive(true);
        }
        else
        {
            
            Debug.Log(signup_child_username + " Succesfully signed up!");
            ChildSignupMenu.SetActive(false);
            ChildLoginMenu.SetActive(true);
        }
        child_signup_username_inputField.text = "";

        }));
    }

IEnumerator Download(string signup_child_username, System.Action<SignupMessage> callback = null)
{
    using (UnityWebRequest request = UnityWebRequest.Get("http://localhost:8000/signup_patient?pname=" + signup_child_username))
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
                callback.Invoke(SignupMessage.Parse(request.downloadHandler.text));
            }
        }
    }
}
}
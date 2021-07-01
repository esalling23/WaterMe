using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class AuthMenu : MonoBehaviour
{
    // Form support
    [SerializeField]
    GameObject emailInput;
    [SerializeField]
    GameObject passwordInput;
    [SerializeField]
    GameObject passwordConfInput;

    // Hide/show support
    [SerializeField]
    GameObject signUpText;
    [SerializeField]
    GameObject signInText;

    MenuName currentMenu;
    // Sign In Data
    [Serializable]
    private struct SignInData
    {
        public string email;
        public string password;
    }

    // Sign Up Data adds password_confirmation
    [Serializable]
    private struct SignUpData
    {
        public string email;
        public string password;
        public string password_confirmation;
    }

    // API Url support
    string developmentUrl = "http://localhost:8000";
    // string productionUrl = "https://temp.com";

    void Start()
    {
        currentMenu = MenuName.SignUp;
    }

    public void HandleDisplaySignUpForm()
    {
        currentMenu = MenuName.SignUp;
        passwordConfInput.SetActive(true);
        signUpText.SetActive(true);

        signInText.SetActive(false);
    }

    public void HandleDisplaySignInForm()
    {
        currentMenu = MenuName.SignIn;
        passwordConfInput.SetActive(false);
        signUpText.SetActive(false);

        signInText.SetActive(true);
    }

    public void SubmitAuthForm()
    {
        string email = emailInput.GetComponent<InputField>().text;
        string password = passwordInput.GetComponent<InputField>().text;

        if (currentMenu == MenuName.SignUp)
        {
            string passwordConfirmation = passwordConfInput.GetComponent<InputField>().text;
            // Sign up conditions
            SignUpData formData = new SignUpData { email=email, password=password, password_confirmation=passwordConfirmation };
            string json = JsonUtility.ToJson(formData);
            StartCoroutine(MakePostRequest("/sign-up/", json));
        }
        else if (currentMenu == MenuName.SignIn)
        {
            // Sign In conditions
            SignUpData formData = new SignUpData { email=email, password=password };
            string json = JsonUtility.ToJson(formData);
            StartCoroutine(MakePostRequest("/sign-up/", json));
        }
    }

    IEnumerator MakePostRequest(string endpoint, string jsonData)
    {

        UnityWebRequest request = new UnityWebRequest(developmentUrl + endpoint, "POST");
        byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(jsonData);
        request.uploadHandler = (UploadHandler)new UploadHandlerRaw(jsonToSend);
        request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");

        yield return request.SendWebRequest();

        Debug.Log("Status Code: " + request.responseCode);

        if (request.result == UnityWebRequest.Result.ConnectionError)
        {
            Debug.Log("Error while sending: " + request.error);
        }
        else
        {
            Debug.Log(request.result);
            Debug.Log(request.error);
        }

    }
}

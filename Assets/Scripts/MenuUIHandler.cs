using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    [SerializeField] TMP_InputField userNameInputField;
    private string userName;


    public void StartButton()
    {
        userName = userNameInputField.text;
        if (userName == "")
        {
            userName = "Anonymous";
        }
        DataManager.Instance.userName = userName;
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}

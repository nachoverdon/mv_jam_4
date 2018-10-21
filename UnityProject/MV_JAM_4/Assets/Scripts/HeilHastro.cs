using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HeilHastro : MonoBehaviour {

    void OnEnable()
    {
        Application.logMessageReceived += LogCallback;
    }

    //Called when there is an exception
    void LogCallback(string condition, string stackTrace, LogType type)
    {
        if (type == LogType.Error || type == LogType.Exception)
            SceneManager.LoadScene("HiddenLevel");
    }

    void OnDisable()
    {
        Application.logMessageReceived -= LogCallback;
    }
}

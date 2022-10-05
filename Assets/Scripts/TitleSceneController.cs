using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleSceneController : MonoBehaviour
{
    public void OnStartBtnPressed()
    {
        SceneManager.LoadScene("Level_1");
    }

    public void OnExitBtnPressed()
    {
        Application.Quit();
        
    }
}

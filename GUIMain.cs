using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GUIMain : MonoBehaviour
{
    private void Start()
    {
        if(CrossControl.fileName == null)
        {
            CrossControl.fileName = "test";
        }
        
    }
    public void StartSim()
    {
        SceneManager.LoadScene(2);
    }
    public void ConfigScene()
    {
        SceneManager.LoadScene(1);
    }
    public void ExitApp()
    {
        Application.Quit();
    }
}

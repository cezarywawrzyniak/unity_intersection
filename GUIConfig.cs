using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GUIConfig : MonoBehaviour
{
    public Button readButton;
    public Button controlButton;
    public InputField inputFile;

    public ColorBlock cbRed;
    public ColorBlock cbGreen;
    public void Start()
    {
        if (CrossControl.automaticRead == true)
        {
            readButton.colors = cbGreen;
        }
        else if (CrossControl.automaticRead == false)
        {
            readButton.colors = cbRed;
        }
        if (CrossControl.automaticControl == true)
        {
            controlButton.colors = cbGreen;
        }
        else if (CrossControl.automaticControl == false)
        {
            controlButton.colors = cbRed;
        }
    }
    public void MenuScene()
    {
        SceneManager.LoadScene(0);
    }
    public void AutoRead()
    {
        CrossControl.automaticRead = !CrossControl.automaticRead;
        if (CrossControl.automaticRead == true)
        {
            readButton.colors = cbGreen;
        }
        else if (CrossControl.automaticRead == false)
        {
            readButton.colors = cbRed;
        }
    }
    public void AutoControl()
    {
        CrossControl.automaticControl = !CrossControl.automaticControl;
        if (CrossControl.automaticControl == true)
        {
            controlButton.colors = cbGreen;
        }
        else if (CrossControl.automaticControl == false)
        {
            controlButton.colors = cbRed;
        }
    }

    public void ReadLocationInput()
    {
        CrossControl.fileName = inputFile.text;
        
    }

}

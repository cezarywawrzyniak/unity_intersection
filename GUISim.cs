using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GUISim : MonoBehaviour
{
    public GameObject readButtonObject;
    public GameObject WS;
    public GameObject WR;
    public GameObject ES;
    public GameObject EL;
    public GameObject SR;
    public GameObject SL;
    public GameObject SW;
    public GameObject SE;
    public GameObject ESouth;
    public GameObject EN;

    public GameObject crossing;

    private CrossControl crossControlScript;


    void Start()
    {
        crossControlScript = crossing.GetComponent<CrossControl>();

        if(!CrossControl.automaticRead)
        {
            readButtonObject.SetActive(true);
        }
        else if (CrossControl.automaticRead)
        {
            readButtonObject.SetActive(false);
        }

        if (!CrossControl.automaticControl)
        {
            WS.SetActive(true);
            WR.SetActive(true);
            ES.SetActive(true);
            EL.SetActive(true);
            SR.SetActive(true);
            SL.SetActive(true);
            SW.SetActive(true);
            SE.SetActive(true);
            ESouth.SetActive(true);
            EN.SetActive(true);
        }
        else if (CrossControl.automaticControl)
        {
            WS.SetActive(false);
            WR.SetActive(false);
            ES.SetActive(false);
            EL.SetActive(false);
            SR.SetActive(false);
            SL.SetActive(false);
            SW.SetActive(false);
            SE.SetActive(false);
            ESouth.SetActive(false);
            EN.SetActive(false);
        }
    }

    public void ReadButton()
    {
        crossControlScript.read = true;
    }
    public void WestStraight()
    {
        crossControlScript.westStraight = !crossControlScript.westStraight;
    }
    public void WestRight()
    {
        crossControlScript.westRight = !crossControlScript.westRight;
    }
    public void EastStraight()
    {
        crossControlScript.eastStraight = !crossControlScript.eastStraight;
    }
    public void EastLeft()
    {
        crossControlScript.eastLeft = !crossControlScript.eastLeft;
    }
    public void SouthRight()
    {
        crossControlScript.southRight = !crossControlScript.southRight;
    }
    public void SouthLeft()
    {
        crossControlScript.southLeft = !crossControlScript.southLeft;
    }
    public void SouthWest()
    {
        crossControlScript.southWest = !crossControlScript.southWest;
    }
    public void SouthEast()
    {
        crossControlScript.southEast = !crossControlScript.southEast;
    }
    public void EastSouth()
    {
        crossControlScript.eastSouth = !crossControlScript.eastSouth;
    }
    public void EastNorth()
    {
        crossControlScript.eastNorth = !crossControlScript.eastNorth;
    }

}

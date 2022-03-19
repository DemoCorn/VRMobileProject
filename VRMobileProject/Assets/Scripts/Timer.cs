using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public int timeS, timeM;
    public Text TimeDisplay;
    public GameObject winDiaplayObj;
    public Text winDiaplay;
    public GameObject[] obj;
    private GameObject[] Enemys;
    // Start is called before the first frame update
    void Start()
    {
        winDiaplay = winDiaplayObj.GetComponent<Text>();
        TimeDisplay.text = timeM.ToString() + ":" + timeS.ToString();
        winDiaplayObj.SetActive(false);
        StartCoroutine(Time());
    }
    private IEnumerator Time()
    {
        yield return new WaitForSeconds(1);
        timeS--;
        if(timeS < 0)
        {
            timeM--;
            timeS = 59;
        }
        TimeDisplay.text = timeM.ToString() + ":" + timeS.ToString();
        if (timeM <= 0 && timeS <= 0)
        {
            endGame(true);
        }
        else
        {
            StartCoroutine(Time());
        }
    }
    public void endGame(bool isWin)
    {
        if(isWin == true)
        {
            winDiaplay.text = "You Win";
        }
        else if(isWin == false)
        {
            winDiaplay.text = "You Lose";
        }
        Enemys = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject item in Enemys)
        {
            Destroy(item);
        }
        foreach (GameObject item in obj)
        {
            Destroy(item);
        }
        winDiaplayObj.SetActive(true);
        StopAllCoroutines();
    }
}
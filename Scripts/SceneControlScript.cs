using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneControlScript : MonoBehaviour
{
    public GameObject player;
    public GameObject timeText;
    public int timeCounter = 120;
    public bool counterOn = false;

   

    void Start()
    {
        //timeText.GetComponent<Text>().text = timeCounter + "s";
    }

    // Update is called once per frame
    void Update()
    {
        if (counterOn == false && timeCounter > 0)
        {
            StartCoroutine(Timer());
        }
        if (timeCounter == 0) GameOver();
        if (player = null) GameOver();

        
    }

    IEnumerator Timer()
    {
        counterOn = true;
        yield return new WaitForSeconds(1);
        timeCounter -= 1;
        counterOn = false;
        if (timeCounter < 100 && timeCounter > 10)
        {
            timeText.GetComponent<Text>().text = "0" + timeCounter + "s";
        }
        else if (timeCounter < 10)
        {
            timeText.GetComponent<Text>().text = "00" + timeCounter + "s";
        }
        else 
        {
            timeText.GetComponent<Text>().text =  timeCounter + "s";
        }
        counterOn = false;
    }

    public void GameOver()
    {
        SceneManager.LoadScene(2);
        /*if(timeCounter == 0 || player == null)
         {
         }*/
    }

    public void Credits()
    {
        SceneManager.LoadScene(3);
    }
    /*public void Restart()
    {
        gameOverUI.SetActive(false);
        SceneManager.LoadScene(1);
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
    }*/
}

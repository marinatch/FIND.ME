using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerScript : MonoBehaviour
{
   
   
    public GameObject timeText;
    public int secondsLeft = 30;
    public bool counterOn = false;

    public GameObject player;

    public int levelToLoad = 1;

    public float timeToWait;
    public GameObject gameOverText;


    /*public float WinGameWait;
    public GameObject WinGameText;
    public float WinGameCounter = 0.0f;*/

    // Start is called before the first frame update
    void Start()
    {
        timeText.GetComponent<Text>().text = "00:" + secondsLeft;

        gameOverText.SetActive(false);
        //StartCoroutine(TimeReduce());
    }

    // Update is called once per frame
    void Update()
    {
        GameOverControl();
        //UpdateInterface();
        WinGame();

        if (counterOn == false && secondsLeft > 0)
        {
            StartCoroutine(TimeReduce());
            if (player != null && secondsLeft <= 0) WinGame();
        }
    }

    IEnumerator TimeReduce()
    {
        counterOn = true;
        yield return new WaitForSeconds(1);
        secondsLeft -= 1;
        if (secondsLeft < 10)
        {
            timeText.GetComponent<Text>().text = "00:0" + secondsLeft;
        }
        else
        {
            timeText.GetComponent<Text>().text = "00:" + secondsLeft;
        }
        counterOn = false;
    }

    private void GameOverControl()
    {
        //si mi nave ha sido destruida, pongo en marcha el contador y al llegar a 2 vuelvo al menu
        if (player == null)
        {
            gameOverText.SetActive(true);
            //StartCoroutine(LoadLevel(0));
        }
    }

    private void WinGame()
    {
        
    }

   /* void UpdateInterface()
    {
        scoreText.text = "Score:" + currentScore;
        hiScoreText.text = "HiScore:" + hiScore;
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        //repreduce la animación
        transition.SetTrigger("Start");

        //Espera unos segundos
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelIndex);
    }*/
}


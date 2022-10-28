using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreenScript : MonoBehaviour
{
    public void Menu()
    {
        print("Menue...");
        SceneManager.LoadScene(0);
        //SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }

    public void Restart()
    {
        //SgameIsOver = false;
        print("Restart...");
        SceneManager.LoadScene(1);
    }
}

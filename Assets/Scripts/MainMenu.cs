using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    public void LoadGame()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene("House");

    }

    public void Option()
    {
        SceneManager.LoadScene("House");
    }

    public void EndGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public void NewGame()
    {
        SceneManager.LoadScene("House");
    }

    public void Quit()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }

    public void Continue()
    {
        // ajouter la logique du jeu
        Debug.Log("CONTINUE!");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    public GameObject wristUI;
    public SceneTransitionManager transitionManager;

    public bool activeWristUI = true;

    void Start()
    {
        DisplayWristUI();
    }

    public void pauseButtonPressed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            DisplayWristUI();
        }
    }

    public void DisplayWristUI()
    {
        if (activeWristUI)
        {
            wristUI.SetActive(false);
            activeWristUI = false;
            Time.timeScale = 1;
        } 
        else if (!activeWristUI)
        {
            wristUI.SetActive(true);
            activeWristUI = true;
            Time.timeScale = 0;
        }
    }

    public void Continue()
    {
        // ajouter la logique du jeu
        DisplayWristUI();
        Debug.Log("CONTINUE!");
    }

    public void RestartGame()
    {
        transitionManager.GoToSceneAsync(1);
        DisplayWristUI();
    }

    public void Exit()
    {
        Debug.Log("QUIT!");
        transitionManager.GoToSceneAsync(0);
        DisplayWristUI();
    }

    
}

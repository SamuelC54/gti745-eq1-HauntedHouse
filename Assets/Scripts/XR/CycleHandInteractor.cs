using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CycleHandInteractor : MonoBehaviour
{
    public GameObject directInteractor;
    public GameObject rayInteractor;
    public bool isRayInteractor = false;

    public void swapButtonPressed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            SwapInteractor();
        }
    }

    public void SwapInteractor()
    {
        isRayInteractor = !isRayInteractor;

        if (isRayInteractor)
        {
            directInteractor.SetActive(false);
            rayInteractor.SetActive(true);
        }
        else
        {
            rayInteractor.SetActive(false);
            directInteractor.SetActive(true);
        }
    }
}

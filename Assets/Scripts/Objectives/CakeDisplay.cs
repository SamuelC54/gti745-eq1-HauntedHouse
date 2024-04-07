using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CakeDisplay : MonoBehaviour
{
    public BakingPuzzle puzzle;
    XRSocketTagInteractor displaySocket;

    void Start()
    {
        displaySocket = transform.GetComponentInChildren<XRSocketTagInteractor>();  
    }

    public void ValiddateCake()
    {
        IXRSelectInteractable cake = displaySocket.GetOldestInteractableSelected();

        if (puzzle.cake.name == cake.transform.gameObject.name)
        {
            puzzle.validateCake();
        }
    }
}

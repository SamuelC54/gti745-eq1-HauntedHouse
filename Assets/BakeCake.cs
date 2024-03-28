using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class BakeCake : MonoBehaviour
{
    public XRSocketTagInteractor ovenSocket;
    public GameObject bakedCake;

    public void Bake()
    {
        IXRSelectInteractable tray = ovenSocket.GetOldestInteractableSelected();
        ovenSocket.interactionManager.CancelInteractableSelection(tray);
        tray.transform.gameObject.SetActive(false);

        ovenSocket.gameObject.SetActive(false);
        bakedCake.SetActive(true);
        ovenSocket.gameObject.SetActive(true);


    }
}

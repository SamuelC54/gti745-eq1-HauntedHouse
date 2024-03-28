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
        GameObject tray = ovenSocket.GetOldestInteractableSelected().transform.gameObject;
        Debug.Log(tray.name);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class BakeCake : MonoBehaviour
{
    public XRSocketTagInteractor ovenSocket;
    public GameObject cakeTray;

    public void Bake()
    {
        IXRSelectInteractable tray = ovenSocket.GetOldestInteractableSelected();
        ovenSocket.interactionManager.CancelInteractableSelection(tray);

        for (int i = 0; i < tray.transform.childCount; i++)
        {
            tray.transform.GetChild(i).gameObject.SetActive(false);
        }

        tray.transform.parent.gameObject.SetActive(false);

        StartCoroutine(SpawnCake());
    }

    IEnumerator SpawnCake()
    {
        GameObject cake = cakeTray.transform.GetChild(0).gameObject;
        
        yield return new WaitForSeconds(2);

        cakeTray.SetActive(true);

        yield return new WaitForSeconds(2);

        cake.SetActive(true);
    }
}

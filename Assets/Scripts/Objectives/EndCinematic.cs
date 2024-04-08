using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class EndCinematic : MonoBehaviour
{
    public GameObject cakeDisplay;
    public GameObject ghost;

    public GameObject key;

    GameObject cake;
    GhostScript ghostControl;

    public bool trigger;

    // Start is called before the first frame update
    void Start()
    {
        cake = cakeDisplay.GetComponentInChildren<XRSocketTagInteractor>()
            .GetOldestInteractableSelected().transform.gameObject;

        ghostControl = ghost.GetComponent<GhostScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if(trigger)
        {
            StartCoroutine(Cinematic());
            trigger = false;
        }
    }

    IEnumerator Cinematic()
    {
        Transform cakePosition = cake.transform;

        Debug.Log("Cequnce started!");
        ghost.SetActive(true);
        yield return new WaitForSeconds(2);

        ghostControl.TriggerAnimation(GhostScript.GhostAnimations.SURPRISE);
        yield return new WaitForSeconds(2);

        ghostControl.TriggerAnimation(GhostScript.GhostAnimations.ACTION);
        cake.SetActive(false);
        yield return new WaitForSeconds(1);

        ghostControl.TriggerAnimation(GhostScript.GhostAnimations.ACTION);
        key.SetActive(true);
        yield return new WaitForSeconds(2);

        ghostControl.TriggerAnimation(GhostScript.GhostAnimations.ASCEND);
    }
}

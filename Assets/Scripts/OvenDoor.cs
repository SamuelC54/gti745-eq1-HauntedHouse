using System.Collections;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class OvenDoorControl : MonoBehaviour
{
    public GameObject ovenTray;
    public bool isOpen = false;
    Animator doorAnimator;
    Animator trayAnimator;

    void Start()
    {
        doorAnimator = GetComponent<Animator>();
        trayAnimator = ovenTray.GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            isOpen = !isOpen;
            doorAnimator.SetBool("isOpen", isOpen);
        }
    }

    public void ChangeState()
    {
        isOpen = !isOpen;
        doorAnimator.SetBool("isOpen", isOpen);
        trayAnimator.SetBool("isOpen", isOpen);
    }


}

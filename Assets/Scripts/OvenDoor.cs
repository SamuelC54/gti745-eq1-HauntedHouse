using System.Collections;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class OvenDoorControl : MonoBehaviour
{
    public GameObject ovenTray;
    public bool isOpen = false;
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            isOpen = !isOpen;
            animator.SetBool("isOpen", isOpen);
        }
    }

    public void ChangeState()
    {
        StartCoroutine(OpenOven());
    }

    IEnumerator OpenOven()
    {
        isOpen = !isOpen;
        animator.SetBool("isOpen", isOpen);

        yield return new WaitUntil(() => animator.GetCurrentAnimatorStateInfo(0).normalizedTime <= 1.0f);

        ovenTray.GetComponent<TrayMove>().ChangeState();
        
    }

}

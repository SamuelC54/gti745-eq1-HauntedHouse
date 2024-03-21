using UnityEngine;

public class OvenDoorControl : MonoBehaviour
{
    Animator animator;
    bool isOpen = false;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O)) // Change 'O' to your preferred key
        {
            isOpen = !isOpen;
            animator.SetBool("isOpen", isOpen);
        }
    }
}

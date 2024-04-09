using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeKey : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        EscapeDoor door = collision.gameObject.GetComponent<EscapeDoor>();

        if(door != null)
        {
            door.Unlock(gameObject);
        }
    }
}

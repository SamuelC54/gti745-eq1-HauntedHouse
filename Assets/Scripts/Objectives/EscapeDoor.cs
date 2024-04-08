using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeDoor : MonoBehaviour
{
    public EscapePhase phase;

    private void OnCollisionEnter(Collision collision)
    {
            phase.TryEcape(collision.gameObject);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeDoor : MonoBehaviour
{
    public EscapePhase phase;

    public void Unlock(GameObject key)
    {
        phase.TryEcape(key);
    }

}

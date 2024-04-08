using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapePhase : Puzzle
{
     
    public void TryEcape(GameObject key)
    {
        if(key.tag == "Key")
        {
            base.StepCompleted();
        }
    }
    
}

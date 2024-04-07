using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandlesPuzzle : Puzzle
{
    public int ghostAge;

    public void validateAge(int age)
    {
        if(age == ghostAge)
        {
            base.StepCompleted();
            return;
        }
    }
}




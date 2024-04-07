using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameSteps;

public abstract class Puzzle : MonoBehaviour
{
    public GameSteps story;
    public bool isCompleted;

    public virtual void StepCompleted() {
        if (!isCompleted)
        {
            isCompleted = true;
            story.advanceStory();
        }
    }

}

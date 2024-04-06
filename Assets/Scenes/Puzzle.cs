using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameSteps;

public abstract class Puzzle : MonoBehaviour
{
    public GameSteps story;

    public virtual void StepCompleted() {
        story.advanceStory();
    }

}

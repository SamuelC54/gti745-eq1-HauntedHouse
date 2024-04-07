using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class GameSteps : MonoBehaviour
{
    PlayableDirector director;
    public List<Step> steps;
    public int currStep = 0;

    // Start is called before the first frame update
    void Start()
    {
        director = GetComponent<PlayableDirector>();
    }

    public void PlayStep(int index)
    {
        if (index >= steps.Count)
            return;

        Step step = steps[index];

        if(!step.hasStarted)
        {
            step.hasStarted = true;

            director.Stop();
            director.time = step.time;
            director.Play();
        }
    }

    public void advanceStory()
    {
        PlayStep(currStep + 1);
        currStep++;
    }

    [System.Serializable]
    public class Step
    {
        public string name;
        public float time;
        public bool hasStarted = false;
    }


}

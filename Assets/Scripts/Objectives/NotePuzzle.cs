using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameSteps;

public class NotePuzzle : Puzzle
{
    public List<GameObject> notes;
    public List<bool> foundFlags = new List<bool>();

    private void Start()
    {
        for (int i = 0; i < notes.Count; i++) foundFlags.Add(false);
    }

    public void CollectNote(GameObject cNote)
    {

        foundFlags[notes.IndexOf(cNote)] = true;

        if (allFound())
        {
            base.StepCompleted();
        }
    }


    private bool allFound()
    {
        foreach (bool item in foundFlags)
        {
            if(!item)
            {
                return false;
            }
        }

        return true;
    }
}

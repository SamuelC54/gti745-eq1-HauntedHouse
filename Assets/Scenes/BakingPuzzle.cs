using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BakingPuzzle : Puzzle
{
    public List<GameObject> ingridients;
    public GameObject cakeTray;
    public GameObject cake;
    public GameObject charredIngredient;

    public List<string> getIngridientNames()
    {
        List<string> ingNames = new List<string>();

        foreach (GameObject ing in ingridients)
        {
            ingNames.Add(ing.name);
        }

        return ingNames;
    }

    public void validateCake()
    {
        base.StepCompleted();
    }
}

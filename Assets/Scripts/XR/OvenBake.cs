using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class OvenBake : MonoBehaviour
{
    public BakingPuzzle puzzle;
    public CandlesPuzzle nextPuzzle;
    public XRSocketTagInteractor ovenSocket;

    public bool baking = false;

    public void Bake()
    {
        baking = !baking;

        IXRSelectInteractable bakingTray = ovenSocket.GetOldestInteractableSelected();
        bool recipeCorrect = true;

        for (int i = 0; i < bakingTray.transform.childCount - 1; i++)
        {
            XRSocketTagInteractor ingSocket = bakingTray.transform.GetChild(i).GetComponent<XRSocketTagInteractor>();
            IXRSelectInteractable ingredient = ingSocket.GetOldestInteractableSelected();

            if (!puzzle.getIngridientNames().Contains(ingredient.transform.name))
            {
                recipeCorrect = false;
                break;
            }
        }

        if (recipeCorrect)
        {
            StartCoroutine(BakeCake(bakingTray));
        }
        else
        {
            StartCoroutine(BakingFailed(bakingTray));
        }
    }

    IEnumerator BakingFailed(IXRSelectInteractable bakingTray)
    {

        for (int i = 0; i < bakingTray.transform.childCount - 1; i++)
        {
            XRSocketTagInteractor ingSocket = bakingTray.transform.GetChild(i).GetComponent<XRSocketTagInteractor>();
            IXRSelectInteractable ingredient = ingSocket.GetOldestInteractableSelected();

            ingSocket.interactionManager.SelectExit(ingSocket, ingredient);
            Destroy(ingredient.transform.gameObject);

            Instantiate(puzzle.charredIngredient, ingSocket.transform.position, ingSocket.transform.rotation);

            yield return new WaitForSeconds(1);
        }

        baking = !baking;
    }

    IEnumerator BakeCake(IXRSelectInteractable bakingTray)
    {
        for (int i = 0; i < bakingTray.transform.childCount - 1; i++)
        {
            XRSocketTagInteractor ingSocket = bakingTray.transform.GetChild(i).GetComponent<XRSocketTagInteractor>();
            IXRSelectInteractable ingredient = ingSocket.GetOldestInteractableSelected();

            ingSocket.interactionManager.SelectExit(ingSocket, ingredient);
            Destroy(ingredient.transform.gameObject);
        }

        yield return new WaitForSeconds(1);

        Destroy(bakingTray.transform.gameObject);

        yield return new WaitForSeconds(1);
        Transform tray = Instantiate(puzzle.cakeTray, ovenSocket.transform.position, ovenSocket.transform.rotation).transform.GetChild(0);

        yield return new WaitForSeconds(1);
        GameObject cake = Instantiate(puzzle.cake, tray.position, tray.rotation);
        cake.name = puzzle.cake.name;
        cake.GetComponent<BirthdayCake>().puzzle = nextPuzzle;

        baking = !baking;
    }

}

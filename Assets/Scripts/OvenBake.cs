using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class OvenBake : MonoBehaviour
{
    public XRSocketTagInteractor ovenSocket;
    public GameObject cakeTray;
    public GameObject cake;
    public GameObject charredIngredient;
    public List<string> acceptedIngridients;

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

            if (!acceptedIngridients.Contains(ingredient.transform.name))
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

            Instantiate(charredIngredient, ingSocket.transform.position, ingSocket.transform.rotation);

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
        Transform tray = Instantiate(cakeTray, ovenSocket.transform.position, ovenSocket.transform.rotation).transform.GetChild(0);

        yield return new WaitForSeconds(1);
        Instantiate(cake, tray.position, tray.rotation);

        baking = !baking;
    }

}
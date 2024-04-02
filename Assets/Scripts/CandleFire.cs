using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class candleLight : MonoBehaviour
{
    public GameObject isLight;
    void Start()
    {
        isLight.SetActive(true);
    }

    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            isLight.SetActive(!isLight.activeSelf);
        }

    }
}

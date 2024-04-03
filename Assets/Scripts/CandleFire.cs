using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class candleLight : MonoBehaviour
{
    public GameObject isLight;
    public bool on = false;

    void Start()
    {
        
    }

    void Update()
    {

    }

    public void ChangeState()
    {
        isLight.SetActive(true);
    }
}

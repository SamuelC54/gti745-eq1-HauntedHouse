using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class BirthdayCake : MonoBehaviour
{
    public CandlesPuzzle puzzle;
    public List<XRSocketTagInteractor> candleSockets = new List<XRSocketTagInteractor>();
    public int numOfCandles = 0;

    void Start()
    {
        registerSockets();
    }

    public void candleAdded()
    {
        numOfCandles++;
        
    }

    public void candleRemoved()
    {
        numOfCandles--;
    }

    public void verifyCandleNumber()
    {
        numOfCandles = 0;
        int numLitCandles = 0;

        foreach(var socket in candleSockets)
        {
            if(socket.hasSelection)
            {
                numOfCandles++;
                var candle = socket.GetOldestInteractableSelected();
                if(candle.transform.GetComponent<CandleFire>().on)
                {
                    numLitCandles++;
                }
            }

        }

        if (numLitCandles == numOfCandles)
        { 
            puzzle.validateAge(numLitCandles);
        }
    }

    private void registerSockets()
    {
        var cPositions = transform.GetChild(0);

        if(cPositions.name == "CandlePositions")
        {
            for (int i = 0; i < cPositions.childCount; i++)
            {
                var socket = cPositions.GetChild(i).GetComponent<XRSocketTagInteractor>();
                if(socket != null)
                {
                    candleSockets.Add(socket);
                }

            }
        }
    }
}

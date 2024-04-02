using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CakeCandlesScript : MonoBehaviour
{
    public Transform[] candlePositions;
    private GameObject[] candles; 
    private int nextCandleIndex = 0;

    void Start()
    {
        candles = new GameObject[candlePositions.Length];
        for (int i = 0; i < candlePositions.Length; i++)
        {
            candles[i] = candlePositions[i].gameObject;
            candles[i].SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Candle") && nextCandleIndex < candles.Length)
        {
            PlaceCandle();
        }
    }

    private void PlaceCandle()
    {
        GameObject candle = candles[nextCandleIndex];
        candle.SetActive(true);
        candle.transform.position = candlePositions[nextCandleIndex].position;
        candle.transform.rotation = candlePositions[nextCandleIndex].rotation;

        nextCandleIndex++;
    }
}

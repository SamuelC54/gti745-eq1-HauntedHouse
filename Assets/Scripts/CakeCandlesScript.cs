using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddCandles : MonoBehaviour
{
    public Transform[] candlePositions;
    private int nextCandleIndex = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Candle") && nextCandleIndex < candlePositions.Length)
        {
            PlaceCandle(other.transform);
        }
    }

    private void PlaceCandle(Transform candle)
    {
        // Move the candle to the next position
        candle.position = candlePositions[nextCandleIndex].position;
        candle.rotation = candlePositions[nextCandleIndex].rotation;

        // Optional: Disable physics on the candle
        Rigidbody candleRigidbody = candle.GetComponent<Rigidbody>();
        if (candleRigidbody != null)
        {
            candleRigidbody.isKinematic = true;
        }

        // Increment the index for the next candle
        nextCandleIndex++;
    }
}

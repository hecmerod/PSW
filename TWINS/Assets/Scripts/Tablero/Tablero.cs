using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tablero : MonoBehaviour
{
    private Properties properties;

    public Vector3[] positionCards;

    void Awake()
    {
        properties = GameObject.FindObjectOfType<Properties>();

        foreach (Vector3 positionCard in positionCards) {

            Vector3 fixedPosition = new Vector3(positionCard.x, 0.005f, positionCard.z);
            GameObject.Instantiate(properties.Card, fixedPosition, Quaternion.identity);
        }
    }

    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DDTamaño : MonoBehaviour
{

    public void HandleInputData(int value)
    {
        if (value == 0)
        {
            GameProperties.tamaño = "pequeño";
        }
        if (value == 1)
        {
            GameProperties.tamaño = "grande";
        }
    }
}

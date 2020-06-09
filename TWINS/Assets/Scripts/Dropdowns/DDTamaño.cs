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
            GameProperties.getInstance().tamaño = "pequeño";
        }
        if (value == 1)
        {
            GameProperties.getInstance().tamaño = "mediano";
        }
        if (value == 2)
        {
            GameProperties.getInstance().tamaño = "grande";
        }
    }
}

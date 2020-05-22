using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DDBaraja : MonoBehaviour
{

    public void HandleInputData(int value)
    {
        if (value == 0)
        {
            GameProperties.baraja = "animal";
        }
        if (value == 1)
        {
            GameProperties.baraja = "profesion";
        }
        if (value == 2)
        {
            GameProperties.baraja = "bandera";
        }
        if (value == 3) {
            GameProperties.baraja = "personalizada";
        }
    }
}
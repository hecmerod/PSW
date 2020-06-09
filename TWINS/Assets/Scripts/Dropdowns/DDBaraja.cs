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
            GameProperties.getInstance().baraja = "animal";
        }
        if (value == 1)
        {
            GameProperties.getInstance().baraja = "profesion";
        }
        if (value == 2)
        {
            GameProperties.getInstance().baraja = "bandera";
        }
        if (value == 3) {
            GameProperties.getInstance().baraja = "personalizada";
        }
    }
}
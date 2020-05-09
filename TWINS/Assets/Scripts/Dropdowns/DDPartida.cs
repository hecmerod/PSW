using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DDPartida : MonoBehaviour
{

    public void HandleInputData(int value)
    {
        if (value == 0)
        {
            GameProperties.tipoPartida = "PartidaEstandar";
        }
        if (value == 1)
        {
            GameProperties.tipoPartida = "PartidaPorCategoria";
        }
        if (value == 2)
        {
            GameProperties.tipoPartida = "PartidaPorCarta";
        }
    }
}
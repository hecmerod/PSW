using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Victoria : IAnimacionStrategy
{

    public void MostrarAnimacion(float tiempo, GameObject animacionVictoria, Text miTiempo)
    {
        animacionVictoria.SetActive(true);
        miTiempo.text = ((int)tiempo).ToString();
    }
}

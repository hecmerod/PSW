using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Derrota : IAnimacionStrategy
{

    public void MostrarAnimacion(float tiempo, GameObject animacionDerrota, Text miTiempo)
    {
        animacionDerrota.SetActive(true);
        miTiempo.text = ((int)tiempo).ToString();
    }
}

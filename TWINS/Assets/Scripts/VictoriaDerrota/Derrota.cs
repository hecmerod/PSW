using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Derrota : IAnimacion
{

    public void MostrarAnimacion(float tiempo, GameObject miCanvas, GameObject animacionDerrota, Text miTiempo)
    {
        miCanvas.SetActive(true);
        animacionDerrota.SetActive(true);
        miTiempo.text = ((int)tiempo).ToString();
    }
}

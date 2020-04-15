using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Victoria : IAnimacionStrategy
{
    public GameObject animacionVictoria;
    private Text miTiempo;
    public Victoria(GameObject animacionVictoria, Text miTiempo)
    {
        this.animacionVictoria = animacionVictoria;
        this.miTiempo = miTiempo;
    }

    public override void MostrarAnimacion(int tiempoJugado)
    {
        animacionVictoria.SetActive(true);
        miTiempo.text = tiempoJugado.ToString();
    }
}

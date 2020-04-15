using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Derrota : IAnimacionStrategy
{
    public GameObject animacionDerrota;
    private Text miTiempo;
    public Derrota(GameObject animacionDerrota, Text miTiempo)
    {
        this.animacionDerrota = animacionDerrota;
        this.miTiempo = miTiempo;
    }

    public override void MostrarAnimacion(int tiempoJugado)
    {
        animacionDerrota.SetActive(true);
        miTiempo.text = tiempoJugado.ToString();
    }

}

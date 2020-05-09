using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContextoPuntuacion : MonoBehaviour
{
    private IPuntuacion tipoPuntuacion;

    public IPuntuacion TipoPuntuacion
    {
        get { return tipoPuntuacion; }
        set { this.tipoPuntuacion = value; }
    }
    public int SumarPuntos()
    {
        return this.tipoPuntuacion.SumarPuntos();
    }

    public int RestarPuntos()
    {
        return this.tipoPuntuacion.RestarPuntos();
    }
    internal void HaVueltoACero()
    {
        this.tipoPuntuacion.HaVueltoACero();
    }
    public void ResetearPuntuacion()
    {
        this.tipoPuntuacion.ResetearPuntuacion();
    }
}

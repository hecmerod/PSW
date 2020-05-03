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

    public int GetFallosInicial()
    {
        return this.tipoPuntuacion.GetFallosInicial();
    }

    public int SumarPuntos()
    {
        return this.tipoPuntuacion.SumarPuntos();
    }

    public int RestarPuntos()
    {
        return this.tipoPuntuacion.RestarPuntos();
    }
    public int Fallo()
    {
        return this.tipoPuntuacion.Fallo();
    }
    public void HaAcertado()
    {
        this.tipoPuntuacion.HaAcertado();
    }
}

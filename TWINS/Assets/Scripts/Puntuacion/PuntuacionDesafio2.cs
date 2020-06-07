using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuntuacionDesafio2 : IPuntuacion
{
    int puntuacion = 0;
    int fallosIniciales = 7;
    int fallosTotales;
    int aciertosTotales;
    bool haAcertado = false;
    public override int SumarPuntos()
    {
        haAcertado = true;
        puntuacion += 10;
        return puntuacion;
    }
    public override int RestarPuntos()
    {
        if (puntuacion != 0)
        {
            puntuacion = -1;
        }
        else
        {
            HaVueltoACero();
            fallosIniciales--;
        }
        if (fallosIniciales == 0)
        {
            puntuacion = -1;
        }
        return puntuacion;
    }
    public override void HaVueltoACero()
    {
        if (haAcertado)
        {
            fallosIniciales = 7;
            haAcertado = false;
        }
    }
    public override void ResetearPuntuacion()
    {
        puntuacion = 0;
        fallosIniciales = 7;
        haAcertado = false;
    }
    public int PuntosFinales(int a, int ft, int fi)
    {
        return a * 10 - (ft - fi) * 2;
    }
}

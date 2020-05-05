using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuntuacionDificil : IPuntuacion
{

    int puntuacion = 0;
    int fallosIniciales = 7;
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
            puntuacion -= 2;
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
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuntuacionMultijugador : IPuntuacion
{

    int puntuacion1 = 0;
    int puntuacion2 = 0;
    int fallosIniciales = 1000;
    int turno = 1;
    bool haAcertado = false;
    public override int SumarPuntos()
    {
        haAcertado = true;
        if (turno == 1)
        {
            puntuacion1 += 10;
            turno = 2;
            return puntuacion1;
        }
        else
        {
            puntuacion2 += 10;
            turno = 1;
            return puntuacion2;
        }
    }
    public override int RestarPuntos()
    {
        if (turno == 1)
        {
            puntuacion1 -= 2;
            if(puntuacion1 < 0)
            {
                puntuacion1 = 0;
            }
            return puntuacion1;
        }
        else
        {
            puntuacion2 -= 2;
            if(puntuacion2 < 0)
            {
                puntuacion2 = 0;
            }
            return puntuacion2;
        }
    }
    public override void HaVueltoACero()
    {
        if (haAcertado)
        {
            fallosIniciales = 1000;
            haAcertado = false;
        }
    }
    public override void ResetearPuntuacion()
    {
        puntuacion1 = 0;
        puntuacion2 = 0;
        fallosIniciales = 1000;
        haAcertado = false;
    }
}

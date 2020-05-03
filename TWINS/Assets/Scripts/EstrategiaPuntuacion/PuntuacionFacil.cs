using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuntuacionFacil : IPuntuacion
{
    int puntuacion = 0;
    int fallosIniciales = 3;
    bool haAcertado = false;
    public override int GetFallosInicial()
    {
        return fallosIniciales;
    }

    public override int SumarPuntos()
    {
        haAcertado = true;
        puntuacion += 10;
        return puntuacion;
    }

    public override int RestarPuntos()
    {
        if (haAcertado)
        {
            puntuacion -= 2;
        }
        return puntuacion;
    }
    public override int Fallo()
    {
        if (!haAcertado)
        {
            fallosIniciales--;
        }
        return fallosIniciales;
    }
    public override bool HaAcertado()
    {
        return haAcertado;
    }
}

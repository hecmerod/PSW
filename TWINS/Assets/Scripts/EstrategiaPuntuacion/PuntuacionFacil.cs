using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuntuacionFacil : IPuntuacion
{
    int puntuacion = 0;
    int fallosIniciales = 3;
    public override int GetFallosInicial()
    {
        return fallosIniciales;
    }

    public override int SumarPuntos()
    {
        puntuacion += 10;
        return puntuacion;
    }

    public override int RestarPuntos()
    {
        puntuacion -= 2;
        return puntuacion;
    }
}

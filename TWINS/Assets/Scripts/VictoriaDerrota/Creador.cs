using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creador
{
    public static IAnimacionStrategy CrearAnimacion(Animacion a)
    {
        switch (a)
        {
            case Animacion.Vic: return new Victoria();
            case Animacion.Der: return new Derrota();
            default: return null;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreadorBaraja
{
    public static Baraja CrearBaraja(string tematica, Tablero tablero)
    {
        switch (tematica)
        {
            default: return new BarajaAnimales(tablero);
        }
    }
}

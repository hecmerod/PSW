using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreadorBaraja
{
    public static Baraja CrearBaraja(string tematica, Tablero tablero)
    {
        switch (tematica)
        {
            case "animal": return new BarajaAnimales(tablero);
            case "profesion": return new BarajaProfesiones(tablero);
            case "bandera": return new BarajaBanderas(tablero);
            default: return new BarajaAnimales(tablero);
        }
    }
}

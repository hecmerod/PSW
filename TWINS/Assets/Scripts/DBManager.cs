using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DBManager
{
    public static string username;
    public static int puntuacionTotal;
    public static int puntuacionMax;
    public static int partidasJugadas;
    public static int partidasGanadas;
    public static int nivel;

    public static bool LoggedIn { get { return username != null; } }
    public static void LogOut() { username = null; }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ElegirBarajaAPArtida : MonoBehaviour
{
    public static string tematica = "animal";
    public void Animal()
    {
        tematica = "animal";
        SceneManager.LoadScene("PartidaEstandar");
    }

    public void Profesion()
    {
        tematica = "profesion";
        SceneManager.LoadScene("PartidaEstandar");
    }

    public void Bandera()
    {
        tematica = "bandera";
        SceneManager.LoadScene("PartidaEstandar");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DesafioBoton : MonoBehaviour
{
    public GameObject gameObjectDesafio1;
    public GameObject gameObjectDesafio2;
    public GameObject gameObjectDesafio3;
    public GameObject volver;
    public GameObject panel1, panel2, panel3;


    public void NoPressed()
    {
        gameObjectDesafio1.SetActive(true);
        gameObjectDesafio2.SetActive(true);
        gameObjectDesafio3.SetActive(true);
        volver.SetActive(true);
        if (panel1.activeSelf)
        {
            panel1.SetActive(false);
        }
        else if (panel2.activeSelf)
        {
            panel2.SetActive(false);
        }
        else if (panel3.activeSelf)
        {
            panel3.SetActive(false);
        }
    }

    public void CargarPartidaEstandar()
    {
        SceneManager.LoadScene("PartidaEstandar");
    }

    public void CargarPartidaPorCarta()
    {
        SceneManager.LoadScene("PartidaPorCarta");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesafioBoton : MonoBehaviour
{
    public GameObject desafio1;
    public GameObject desafio2;
    public GameObject desafio3;
    public GameObject volver;
    public GameObject descripcion1;
    public GameObject descripcion2;
    public GameObject descripcion3;
    public GameObject panel;
    public void NoPressed()
    {
        desafio1.SetActive(true);
        desafio2.SetActive(true);
        desafio3.SetActive(true);
        volver.SetActive(true);
        panel.SetActive(false);
        if (descripcion1.activeSelf)
        {
            descripcion1.SetActive(false);
        }
        else if (descripcion2.activeSelf)
        {
            descripcion2.SetActive(false);
        }
        else if (descripcion3.activeSelf)
        {
            descripcion3.SetActive(false);
        }
    }
}

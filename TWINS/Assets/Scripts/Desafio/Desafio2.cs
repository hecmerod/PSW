using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Desafio2 : MonoBehaviour
{
    public int desafio;
    public Vector3[] cardsPosition;
    public Vector3 positionTablero;
    public Vector3 cronoPosition;
    public Vector3 puntuacionPosition;
    public string baraja;
    public IPuntuacion puntuacion;
    public bool ganado;
    private GameObject marco;
    public GameObject panel;
    public GameObject desafio1;
    public GameObject desafio2;
    public GameObject desafio3;
    public GameObject volver;

    private void Awake()
    {
        marco = this.gameObject.transform.GetChild(0).gameObject;
    }
    private void OnMouseDown()
    {
        GameProperties.getInstance().SetProperties(desafio, cardsPosition, positionTablero, cronoPosition, puntuacionPosition, new PuntuacionDesafio2(), baraja, false);
        GameProperties.getInstance().tamaño = "pequeño";
        GameProperties.getInstance().time = 60;
        GameProperties.getInstance().tipoPartida = "PartidaEstandar";
        panel.SetActive(true);
        desafio1.SetActive(false);
        desafio2.SetActive(false);
        desafio3.SetActive(false);
        volver.SetActive(false);
    }
    private void OnMouseEnter()
    {
        marco.SetActive(true);
    }
    void OnMouseExit()
    {
        marco.SetActive(false);
    }
}

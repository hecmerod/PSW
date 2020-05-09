using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Desafio : MonoBehaviour
{
    public int desafio;
    public Vector3[] cardsPosition;
    public Vector3 positionTablero;
    public Vector3 cronoPosition;
    public Vector3 puntuacionPosition;
    public IPuntuacion puntuacion;
    private Renderer renderer;
    private GameObject marco;

    private void Awake()
    {
        marco = this.gameObject.transform.GetChild(0).gameObject;
        renderer = GetComponent<Renderer>();
    }
    private void OnMouseDown()
    {

        GameProperties.SetProperties(desafio, cardsPosition, positionTablero, cronoPosition, puntuacionPosition, new PuntuacionFacil(), "animales");

        SceneManager.LoadScene("PartidaEstandar");
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


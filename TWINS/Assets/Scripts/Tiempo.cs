using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Tiempo : MonoBehaviour
{
    private GameObject canvas;
    public bool comenzarTiempo = false, partidaTerminada = false;
    public Text miTiempo, textContador, puntuacion, textPuntuacion;
    public float time = 60, timePlayed = 0, contador;
    Partida partida;
    public void Awake()
    {
        LoadSetting();
        time = GameProperties.time;
        contador = time;
        textContador.text = "Tiempo: " + time;
    }
    public void Update()
    {
      Timer();
    }
    public void LoadSetting()
    {
        canvas = GameObject.Find("Canvas");
        miTiempo = canvas.transform.GetComponentsInChildren<Text>()[3];
        textContador = canvas.transform.GetComponentsInChildren<Text>()[0];
        textPuntuacion = canvas.transform.GetComponentsInChildren<Text>()[2];

        textContador.transform.localPosition = GameProperties.cronoPosition;

    }
    public void Timer()
    {
        if (comenzarTiempo)
        {
            timePlayed += Time.deltaTime;
            contador -= Time.deltaTime;
            textContador.text = "Tiempo: " + (int)contador;
        }
        if(timePlayed >= time)
        {
            miTiempo.text = "Tiempo: " + (int)time;
            if(partida.puntos < 0) { partida.puntos = 0; }
            textPuntuacion.text = "Puntuación: " + partida.puntos;
        }
        if (partidaTerminada)
        {
            miTiempo.text = "Tiempo: " + (int)timePlayed;
            if(partida.puntos < 0) { partida.puntos = 0; }
            textPuntuacion.text = "Puntuación: " + partida.puntos;
        }
    }

    public void InicializarPartida(Partida partida)
    {
        this.partida = partida;
    }
}

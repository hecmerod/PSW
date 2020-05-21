using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Tiempo : MonoBehaviour
{
    private GameObject miTiempo;
    public bool comenzarTiempo = false, partidaTerminada = false;
    public Text textContador, puntuacion, textPuntuacion, textTiempo;
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
        miTiempo = GameObject.Find("Canvas/Tiempo");
        textTiempo = miTiempo.GetComponent<Text>();
        textContador = GameObject.Find("Canvas/TiempoRestante").GetComponent<Text>();

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
            comenzarTiempo = false;
            textTiempo.text = "Tiempo: " + (int)time;
            if(partida.puntos < 0) { partida.puntos = 0; }
        }
        if (partidaTerminada)
        {
            textTiempo.text = "Tiempo: " + (int)timePlayed;
            if(partida.puntos < 0) { partida.puntos = 0; }
        }
    }

    public void InicializarPartida(Partida partida)
    {
        this.partida = partida;
    }
}

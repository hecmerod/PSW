using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public abstract class Partida : MonoBehaviour
{
    public AudioSource fuenteAudio;


    protected GameObject gameObjectCard, gameObjectTablero, animacionDerrota, animacionVictoria;
    public GameObject gameObjectTiempo; //pasar por codigo
    protected IPuntuacion puntuacionFacil, puntuacionNormal, puntuacionDificil;
    protected ContextoPuntuacion contexto = new ContextoPuntuacion();
    public int puntos, desafiosDesbloqueados = 0;
    private GameObject canvas;
    protected Tablero tablero;
    protected Card turnedCard, turnedCard2;
    public bool startedTimer = false;
    protected string tematica;
    public Text textPuntuacion, puntuacion;
    protected Tiempo tiempo;
    protected int turno = 0, pairsFound = 0, numCardsTurned = 0, trios = 0;
    protected int puntos1, puntos2;
    protected GameObject categoria, gameObjectTurno, puntuacion1, puntuacion2;
    Vector3 posicionContador = Vector3.zero;
    Vector3 posicionPuntuacion = Vector3.zero;
    protected Vector3[] positionCards = new Vector3[0];
    protected Vector3 positionTablero = Vector3.zero;

    private DBPartida dBPartida;

    public void Awake() {
        CargarRecursos();
        LoadSettings();
        InstanciarAnimacion();
        music();
        
    }

    public void LoadSettings() {
        dBPartida = GameObject.FindObjectOfType<DBPartida>();

        GameProperties.PresetSettings(GameProperties.tamaño);

        canvas = GameObject.Find("Canvas");
        fuenteAudio = GameObject.Find("SonidoFondo").GetComponent<AudioSource>();
        categoria = GameObject.Find("Canvas/categoria");
        gameObjectTurno = GameObject.Find("Canvas/Turno");
        puntuacion1 = GameObject.Find("Canvas/Puntuacion1");
        puntuacion2 = GameObject.Find("Canvas/Puntuacion2");

        puntuacion = canvas.transform.GetComponentsInChildren<Text>()[1];
        textPuntuacion = canvas.transform.GetComponentsInChildren<Text>()[5];
        tiempo = GameObject.FindObjectOfType<Tiempo>();

        tiempo.InicializarPartida(this);

        positionCards =           GameProperties.cardsPositions;
        contexto.TipoPuntuacion = GameProperties.puntuacion;
        positionTablero =         GameProperties.positionTablero;
        tematica =                GameProperties.baraja;
        posicionContador =        GameProperties.cronoPosition;
        posicionPuntuacion =      GameProperties.posicionPuntuacion;

        puntuacion.transform.localPosition = posicionPuntuacion;
        puntuacion.text = "Puntuación: 0";

        /*textContador.transform.localPosition = posicionContador;
        contador = time;
        textContador.text = "Tiempo: " + time.ToString();*/

    }

    public void Update() {
        music();

        if(tiempo.timePlayed > tiempo.time)
        {
            IsLost();
        }
    }
    protected void music()
    {
        if (MenuPausa.Pausado)
        {
            fuenteAudio.Pause();
        }
        else
        {
            if (!fuenteAudio.isPlaying) { fuenteAudio.Play(); }
        }
    }

    /*public void Timer() {
        if (startedTimer)
        {
            timePlayed += Time.deltaTime;
            contador -= Time.deltaTime;
            textContador.text = "Tiempo: " + ((int)contador).ToString();
        }
        if (timePlayed >= time)
        {
            UpdaterData();
            CallSaveData();
            IsLost();
        }
        
    }*/

    public void IsLost() {
        //startedTimer = false;
        numCardsTurned = 3;
        tiempo.partidaTerminada = true;
        tiempo.comenzarTiempo = false;
        textPuntuacion.text = "Puntuación: " + puntos;
        animacionDerrota.SetActive(true);
        contexto.ResetearPuntuacion();
        fuenteAudio.Stop();
        DBManager.UpdaterData(puntos);
        dBPartida.CallSaveData();
    }

    protected void IsWon() {
        if (pairsFound == tablero.PositionCards.Length / 2) {
            categoria.SetActive(false);
            numCardsTurned = 2;
            //startedTimer = false;
            tiempo.partidaTerminada = true;
            tiempo.comenzarTiempo = false;
            textPuntuacion.text = "Puntuación: " + puntos;
            animacionVictoria.SetActive(true);
            contexto.ResetearPuntuacion();
            fuenteAudio.Stop();

            DBManager.partidasGanadas++;
            DBManager.UpdaterData(puntos);
            if (DBManager.nivel == GameProperties.level && !GameProperties.vNiño) DBManager.nivel++;
            if (DBManager.nivelniños == GameProperties.level && GameProperties.vNiño) DBManager.nivelniños++;

            dBPartida.CallSaveData();
        }
    }
    protected void TriosWon()
    {
        if (pairsFound == tablero.PositionCards.Length / 3)
        {
            numCardsTurned = 3;
            //startedTimer = false;
            tiempo.partidaTerminada = true;
            tiempo.comenzarTiempo = false;
            textPuntuacion.text = "Puntuación: " + puntos;
            animacionVictoria.SetActive(true);
            contexto.ResetearPuntuacion();
            fuenteAudio.Stop();

            DBManager.partidasGanadas++;
            DBManager.UpdaterData(puntos);
            if (DBManager.nivel == GameProperties.level) DBManager.nivel++;

            dBPartida.CallSaveData();
        }
    }
    protected void MultijugadorWon()
    {
        if(pairsFound == tablero.PositionCards.Length / 2)
        {
            numCardsTurned = 3;
            tiempo.partidaTerminada = true;
            tiempo.comenzarTiempo = false;
            if (puntos1 > puntos2)
            {
                textPuntuacion.text = "Jugador 1: " + puntos1;
            }
            else
            {
                textPuntuacion.text = "Jugador 2: " + puntos2;
            }
            animacionVictoria.SetActive(true);
            contexto.ResetearPuntuacion();
            fuenteAudio.Stop();

            DBManager.partidasGanadas++;
            DBManager.UpdaterData(puntos);
            if (DBManager.nivel == GameProperties.level) DBManager.nivel++;

            dBPartida.CallSaveData();
        }
    }

    protected void InstanciarAnimacion()
    {
        Vector3 positionAnimacion = new Vector3(0, 0, 0);

        animacionDerrota = GameObject.Instantiate(animacionDerrota, positionAnimacion, Quaternion.identity);
        animacionVictoria = GameObject.Instantiate(animacionVictoria, positionAnimacion, Quaternion.identity);

        animacionDerrota.transform.parent = canvas.transform;
        animacionVictoria.transform.parent = canvas.transform;

        animacionDerrota.transform.SetSiblingIndex(2);
        animacionVictoria.transform.SetSiblingIndex(3);

        animacionDerrota.transform.localPosition = positionAnimacion;
        animacionVictoria.transform.localPosition = positionAnimacion;
    }

    protected void CargarRecursos()
    {
        gameObjectCard = Resources.Load("Prefabs/Card") as GameObject;
        gameObjectTablero = Resources.Load("Prefabs/Tablero") as GameObject;
        animacionDerrota = Resources.Load("Prefabs/AnimacionDerrota") as GameObject;
        animacionVictoria = Resources.Load("Prefabs/AnimacionVictoria") as GameObject;
    }

    abstract public void CheckPair(int n);
    abstract protected void SetTableroValues();

    public GameObject Card { get => gameObjectCard; set => gameObjectCard = value; }
    public GameObject Tablero { get => gameObjectTablero; set => gameObjectTablero = value; }

    public int NumCardsTurned { get => numCardsTurned; set => numCardsTurned = value; }
    public string Tematica { get => tematica; set => tematica = value; }
}

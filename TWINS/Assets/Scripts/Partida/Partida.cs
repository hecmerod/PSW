using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public abstract class Partida : MonoBehaviour
{
    AudioSource fuenteAudio;


    protected GameObject gameObjectCard, gameObjectTablero, animacionDerrota, animacionVictoria;
    public GameObject gameObjectTiempo; //pasar por codigo
    protected IPuntuacion puntuacionFacil, puntuacionNormal, puntuacionDificil;
    protected ContextoPuntuacion contexto = new ContextoPuntuacion();
    public int puntos, desafiosDesbloqueados = 0;
    private GameObject canvas;
    protected Tablero tablero;
    protected Card turnedCard;
    public bool startedTimer = false;
    protected string tematica;
    public Text textPuntuacion, puntuacion;
    protected Tiempo tiempo;
    protected int turno = 0, pairsFound = 0, numCardsTurned = 0;
    protected GameObject categoria;

    Vector3 posicionContador = Vector3.zero;
    Vector3 posicionPuntuacion = Vector3.zero;
    protected Vector3[] positionCards = new Vector3[0];
    protected Vector3 positionTablero = Vector3.zero;

    public void Awake() {
        CargarRecursos();
        LoadSettings();
        InstanciarAnimacion();   
        
    }

    public void LoadSettings() {
        GameProperties.PresetSettings(GameProperties.tamaño);
        canvas = GameObject.Find("Canvas");
        puntuacion = canvas.transform.GetComponentsInChildren<Text>()[1];
        textPuntuacion = canvas.transform.GetComponentsInChildren<Text>()[2];
        tiempo = GameObject.FindObjectOfType<Tiempo>();
        tiempo.InicializarPartida(this);

        positionCards = GameProperties.cardsPositions;
        contexto.TipoPuntuacion = GameProperties.puntuacion;
        positionTablero = GameProperties.positionTablero;

        tematica = GameProperties.baraja;

        posicionContador = GameProperties.cronoPosition;
        posicionPuntuacion = GameProperties.posicionPuntuacion;
        puntuacion.transform.localPosition = posicionPuntuacion;
        puntuacion.text = "Puntuación: 0";

        /*textContador.transform.localPosition = posicionContador;
        contador = time;
        textContador.text = "Tiempo: " + time.ToString();*/

        fuenteAudio = GameObject.Find("SonidoFondo").GetComponent<AudioSource>();

        categoria = GameObject.Find("Canvas/categoria");
    }

    public void CallSaveData()
    {
        if (DBManager.LoggedIn)
        {
            StartCoroutine(SavePlayerData());
        }
    }
    public void UpdaterData()
    {
        if (DBManager.LoggedIn)
        {
            DBManager.partidasJugadas++;
            DBManager.puntuacionTotal+= puntos;
        }
    }
    IEnumerator SavePlayerData()
    {
        WWWForm form = new WWWForm();
        form.AddField("name", DBManager.username);
        form.AddField("score", DBManager.puntuacionTotal);
        //form.AddField("maxscore", DBManager.puntuacionMax);
        form.AddField("gamesplayed", DBManager.partidasJugadas);
        form.AddField("gameswon", DBManager.partidasGanadas);
        form.AddField("nivel", DBManager.nivel);
        WWW www = new WWW("https://twinsproject2.000webhostapp.com/savedata.php", form);
        yield return www;
        if(www.text == "0") {
            Debug.Log("Data saved");
        }
        else {
            Debug.Log("Algo ha pasao");
        }

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
            fuenteAudio.volume = 0.1f;
            if(MenuPausa.checkerReiniciar || MenuPausa.checkerSalir)
            {
                fuenteAudio.volume = 0.0f;
            }
        }else fuenteAudio.volume = 0.256f;
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
        numCardsTurned = 2;
        tiempo.partidaTerminada = true;
        tiempo.comenzarTiempo = false;
        animacionDerrota.SetActive(true);
        contexto.ResetearPuntuacion();
        fuenteAudio.Stop();
        UpdaterData();
        CallSaveData();
    }

    protected void IsWon() {
        if (pairsFound == tablero.PositionCards.Length / 2) {
            categoria.SetActive(false);
            numCardsTurned = 2;
            //startedTimer = false;
            tiempo.partidaTerminada = true;
            tiempo.comenzarTiempo = false;
            animacionVictoria.SetActive(true);
            contexto.ResetearPuntuacion();
            fuenteAudio.Stop();
            DBManager.partidasGanadas++;
            UpdaterData();
            if (nextLevel()) DBManager.nivel++;
            CallSaveData();
        }
    }

    private bool nextLevel() {
        return DBManager.nivel == GameProperties.level;
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

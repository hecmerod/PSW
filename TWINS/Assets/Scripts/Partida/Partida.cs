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
    public Text miTiempo, textContador, puntuacion; //pasar por codigo

    protected Tablero tablero;
    protected Card turnedCard;

    protected string tamaño, tematica;

    protected int turno = 0, pairsFound = 0, numCardsTurned = 0;

    protected bool startedTimer = false;
    protected float time, timePlayed = 0, contador;
    Vector3 posicionContador = Vector3.zero;
    Vector3 posicionPuntuacion = Vector3.zero;

    protected void Start()
    {

    }

    protected void Awake() {
        CargarRecursos();
        InstanciarAnimacion();
        tematica = ElegirBarajaAPArtida.tematica;
        tamaño = "pequeño";
        if (tamaño.Equals("pequeño"))
        {
            time = 60f;
            posicionContador = new Vector3(-118f, 140f, 0);
            posicionPuntuacion = new Vector3(-106, 87, 0);
        }
        else
        {
            time = 160f;
            posicionContador = new Vector3(-170f, 233.7f, 0);
            posicionPuntuacion = new Vector3(-23, 233.7f, 0);
        }
        puntuacion.transform.localPosition = posicionPuntuacion;
        puntuacion.text = "Puntuación: 0";

        textContador.transform.localPosition = posicionContador;
        contador = time;
        textContador.text = "Tiempo: " + time.ToString();
    }
    public void CallSaveData()
    {
        StartCoroutine(SavePlayerData());
    }
    public void UpdaterData()
    {
        if (DBManager.LoggedIn)
        {
            // Actualizar puntuacion cuando averigue como coño va
            DBManager.partidasJugadas++;
            DBManager.partidasGanadas++;
            DBManager.puntuacionTotal++;
            //if la puntuacion > max se updatea etc etc
        }
    }
    IEnumerator SavePlayerData()
    {
        WWWForm form = new WWWForm();
        form.AddField("name", DBManager.username);
        form.AddField("totalscore", DBManager.puntuacionTotal);
        //form.AddField("maxscore", DBManager.puntuacionMax);
        form.AddField("gamesplayed", DBManager.partidasJugadas);
        form.AddField("gameswon", DBManager.partidasGanadas);
        //form.AddField("nivel", DBManager.nivel);
        WWW www = new WWW("https://twinsproject2.000webhostapp.com/savedata.php", form);
        yield return www;
        if(www.text == "0")
        {
            Debug.Log("Data saved");
        }
        else
        {
            Debug.Log("Algo ha pasao");
        }

    }
    protected void Update() {
        Timer();
        music();

    }
    protected void music()
    {
        fuenteAudio = GetComponent<AudioSource>();
        if (MenuPausa.Pausado)
        {
            fuenteAudio.volume = 0.1f;
            if(MenuPausa.checkerReiniciar || MenuPausa.checkerSalir)
            {
                fuenteAudio.volume = 0.0f;
            }
        }else fuenteAudio.volume = 0.256f;
    }

    public void Timer() {
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
        
    }

    public void IsLost() {
        startedTimer = false;
        animacionDerrota.SetActive(true);
        UpdaterData();
        CallSaveData();
        TerminarPartida();
    }

    protected void IsWon() {
        if (pairsFound == tablero.PositionCards.Length / 2) {
            startedTimer = false;
            animacionVictoria.SetActive(true);
            DBManager.partidasGanadas++;
            UpdaterData();
            CallSaveData();
            TerminarPartida();
        }
    }

    protected void TerminarPartida()
    {
        gameObjectTiempo.SetActive(true);
        miTiempo.text = ((int)timePlayed).ToString();
        fuenteAudio = GetComponent<AudioSource>();
        fuenteAudio.Stop();
        numCardsTurned = 2;
    }
    protected void InstanciarAnimacion()
    {
        Vector3 positionAnimacion = new Vector3(220, 137, 0);
        animacionDerrota = GameObject.Instantiate(animacionDerrota, positionAnimacion, Quaternion.identity);
        animacionVictoria = GameObject.Instantiate(animacionVictoria, positionAnimacion, Quaternion.identity);
    }

    protected void CargarRecursos()
    {
        gameObjectCard = Resources.Load("Prefabs/Card") as GameObject;
        gameObjectTablero = Resources.Load("Prefabs/Tablero") as GameObject;
        animacionDerrota = Resources.Load("Prefabs/Derrota") as GameObject;
        animacionVictoria = Resources.Load("Prefabs/Victoria") as GameObject;
    }

    abstract public void CheckPair(int n);
    abstract protected void SetTableroValues();

    public GameObject Card { get => gameObjectCard; set => gameObjectCard = value; }
    public GameObject Tablero { get => gameObjectTablero; set => gameObjectTablero = value; }

    public int NumCardsTurned { get => numCardsTurned; set => numCardsTurned = value; }
    public string Tematica { get => tematica; set => tematica = value; }
}

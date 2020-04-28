using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
public abstract class Partida : MonoBehaviour
{
    AudioSource fuenteAudio;

    protected GameObject gameObjectCard, gameObjectTablero, animacionDerrota, animacionVictoria;
    public GameObject gameObjectTiempo; //pasar por codigo
    public Text miTiempo, textContador; //pasar por codigo

    protected Tablero tablero;
    protected Card turnedCard;

    protected string tamaño, tematica;

    protected int turno = 0, pairsFound = 0, numCardsTurned = 0;

    protected bool startedTimer = false;
    protected float time, timePlayed = 0, contador;
    Vector3 posicionContador = Vector3.zero;

    protected void Start()
    {

    }
    protected void Awake() {
        CargarRecursos();
        InstanciarAnimacion();
        tematica = ElegirBarajaAPArtida.tematica;
        tamaño = "grande";
        if (tamaño.Equals("pequeño"))
        {
            time = 60f;
            posicionContador = new Vector3(250.7f, 200.7f, 0);
        }
        else
        {
            time = 160f;
            posicionContador = new Vector3(220.7f, 242.7f, 0);
        }
        textContador.transform.position = posicionContador;
        contador = time;
        textContador.text = "Tiempo: " + time.ToString();
    }

    protected void Update() {
        Timer();
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
            IsLost();
        }
    }

    public void IsLost() {
        startedTimer = false;
        animacionDerrota.SetActive(true);
        TerminarPartida();
    }

    protected void IsWon() {
        if (pairsFound == tablero.PositionCards.Length / 2) {
            startedTimer = false;
            animacionVictoria.SetActive(true);
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

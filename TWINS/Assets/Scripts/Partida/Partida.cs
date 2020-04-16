using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
public abstract class Partida : MonoBehaviour
{
    AudioSource fuenteAudio;

    protected GameObject gameObjectCard, gameObjectTablero, animacionDerrota, animacionVictoria;
    //protected Transform labelTiempo;
    //protected Text miTiempo;

    protected Tablero tablero;
    protected Card turnedCard;

    protected string tamaño, tematica;

    protected int turno = 0, pairsFound = 0, numCardsTurned = 0;

    protected bool startedTimer = false;
    protected float time = 1000, timePlayed = 0;

    protected void Awake() {
        CargarRecursos();
        IniciarAnimacion();
        tematica = ElegirBarajaAPArtida.tematica;
        tamaño = "grande";
    }

    protected void Update() {
        Timer();
    }

    public void Timer() {
        if (startedTimer) {
            timePlayed += Time.deltaTime;
            isLost();
        }
    }

    public void isLost() {
        if (timePlayed >= time) {
            startedTimer = false;
            animacionDerrota.SetActive(true);
            //miTiempo.text = ((int)time).ToString();
            fuenteAudio = GetComponent<AudioSource>();
            fuenteAudio.Stop();

        }
    }

    protected void isWon() {
        if (pairsFound == tablero.PositionCards.Length / 2) {
            startedTimer = false;
            animacionVictoria.SetActive(true);
            //miTiempo.text = ((int)timePlayed).ToString();
            fuenteAudio = GetComponent<AudioSource>();
            fuenteAudio.Stop();
        }
    }
    protected void IniciarAnimacion()
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

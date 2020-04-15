using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
public abstract class Partida : MonoBehaviour
{
    AudioSource fuenteAudio;

    [SerializeField] private GameObject animacionDerrota, animacionVictoria; //ESTO HAY QUE HACERLO POR CÓDIGO
    protected GameObject gameObjectCard, gameObjectTablero;

    [SerializeField] private Text miTiempoDer, miTiempoVic; //ESTO HAY QUE HACERLO POR CÓDIGO

    protected Tablero tablero;
    protected Card turnedCard;

    protected string tamaño, tematica;

    protected int turno = 0, pairsFound = 0, numCardsTurned = 0;

    protected bool startedTimer = false;
    protected float time = 1, timePlayed = 0;

    protected void Awake() {
        gameObjectCard = Resources.Load("Prefabs/Card") as GameObject;
        gameObjectTablero = Resources.Load("Prefabs/Tablero") as GameObject;

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
            miTiempoDer.text = ((int)time).ToString();
            fuenteAudio = GetComponent<AudioSource>();
            fuenteAudio.Stop();

        }
    }

    protected void isWon() {
        if (pairsFound == tablero.PositionCards.Length / 2) {
            startedTimer = false;
            animacionVictoria.SetActive(true);
            miTiempoVic.text = ((int)timePlayed).ToString();
            fuenteAudio = GetComponent<AudioSource>();
            fuenteAudio.Stop();
        }
    }

    abstract public void CheckPair(int n);
    abstract protected void SetTableroValues();

    public GameObject Card { get => gameObjectCard; set => gameObjectCard = value; }
    public GameObject Tablero { get => gameObjectTablero; set => gameObjectTablero = value; }

    public int NumCardsTurned { get => numCardsTurned; set => numCardsTurned = value; }
    public string Tematica { get => tematica; set => tematica = value; }
}

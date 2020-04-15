using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
public abstract class Partida : MonoBehaviour
{
    IAnimacionStrategy animacion;

    [SerializeField] private GameObject animacionDerrota, animacionVictoria; //ESTO HAY QUE HACERLO POR CÓDIGO
    protected GameObject gameObjectCard, gameObjectTablero;

    [SerializeField] private Text miTiempoDer, miTiempoVic; //ESTO HAY QUE HACERLO POR CÓDIGO

    protected Tablero tablero;
    protected Card turnedCard;

    protected string tematica, tamaño;

    protected int turno = 0, pairsFound = 0, numCardsTurned = 0;

    protected bool startedTimer = false;
    protected float time = 1000, timePlayed = 0;

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
            animacion = Creador.CrearAnimacion(Animacion.Der);
            animacion.MostrarAnimacion(time, animacionDerrota, miTiempoDer);
        }
    }

    protected void isWon() {
        if (pairsFound == tablero.PositionCards.Length / 2) {
            animacion = Creador.CrearAnimacion(Animacion.Vic);
            animacion.MostrarAnimacion(timePlayed, animacionVictoria, miTiempoVic);
        }
    }

    abstract public void CheckPair(int n);
    abstract protected void SetTableroValues();

    public GameObject Card { get => gameObjectCard; set => gameObjectCard = value; }
    public int NumCardsTurned { get => numCardsTurned; set => numCardsTurned = value; }
}

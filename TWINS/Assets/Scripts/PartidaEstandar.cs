using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class PartidaEstandar : Partida
{
    [SerializeField] private GameObject gameObjectCard;
    [SerializeField] private GameObject gameObjectTablero;
    [SerializeField] private GameObject animacionVictoria;
    [SerializeField] private GameObject animacionDerrota;
    [SerializeField] private Text miTiempoVic;
    [SerializeField] private Text miTiempoDer;


    private bool startedTimer = false;

    private int turno = 0;
    private Tablero tablero;
    string tematica;


    private int pairsFound = 0;
    private Card turnedCard;

    private int numCardsTurned = 0;

    private float time = 100;
    private float timePlayed = 0;

    IAnimacionStrategy animacion;

    public override void Awake()
    {
        this.tematica = ElegirBarajaAPArtida.tematica;
        Vector3[] positionCards = new Vector3[12];
        positionCards[0] = new Vector3(11, 0, 8.75f); positionCards[1] = new Vector3(10.355f, 0, 7.25f);
        positionCards[2] = new Vector3(11.625f, 0, 7.25f); positionCards[3] = new Vector3(9.75f, 0, 5.75f);
        positionCards[4] = new Vector3(11, 0, 5.75f); positionCards[5] = new Vector3(12.25f, 0, 5.75f);
        positionCards[6] = new Vector3(9.75f, 0, 4.25f); positionCards[7] = new Vector3(11, 0, 4.25f);
        positionCards[8] = new Vector3(12.25f, 0, 4.25f); positionCards[9] = new Vector3(10.355f, 0, 2.75f);
        positionCards[10] = new Vector3(11.625f, 0, 2.75f); positionCards[11] = new Vector3(11, 0, 1.25f);
        
        tablero = new Tablero(this, positionCards,tematica);
    }

    public override void Update()
    {
        if (startedTimer)
        {
            timePlayed += Time.deltaTime;
            if(timePlayed >= time)
            {
                animacion = Creador.CrearAnimacion(Animacion.Der);
                animacion.MostrarAnimacion(time, animacionDerrota, miTiempoDer);
            }
        }
    }
    async public override void CheckPair(int n)
    {
        if (!startedTimer) { startedTimer = true; }

        Card card = tablero.Baraja.GetCard(n);

        if (turnedCard is null) {
            turnedCard = card;
        }
        else if (turnedCard.IsPair(card)) {
            await Task.Delay(500);

            turnedCard = null;
            pairsFound++;      
            
            if (pairsFound == 6)
            {
                animacion = Creador.CrearAnimacion(Animacion.Vic);
                animacion.MostrarAnimacion(timePlayed, animacionVictoria, miTiempoVic);
            }
            turno++;
            numCardsTurned = 0;
        }
        else {
            await Task.Delay(800);
            turnedCard.TurnCard(); card.TurnCard();
            numCardsTurned = 0;
            turnedCard = null;            
            turno++;
        }
    }

    public GameObject Card { get => gameObjectCard; set => gameObjectCard = value; }
    public GameObject Tablero { get => gameObjectTablero; set => gameObjectTablero = value; }
    public int NumCardsTurned { get => numCardsTurned; set => numCardsTurned = value; }

}

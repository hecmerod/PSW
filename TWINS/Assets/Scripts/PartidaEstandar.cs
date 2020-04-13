using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class PartidaEstandar : MonoBehaviour
{
    [SerializeField] private GameObject gameObjectCard;
    [SerializeField] private GameObject gameObjectTablero;
    [SerializeField] private GameObject miCanvas;
    [SerializeField] private GameObject animacionVictoria;
    [SerializeField] private GameObject animacionDerrota;
    [SerializeField] private Text miTiempo;


    private bool startedTimer = false;

    private int turno = 0;
    private Tablero tablero;


    private int pairsFound = 0;
    private Card turnedCard;

    private int numCardsTurned = 0;

    private float time = 1000;
    private float timePlayed;

    void Awake()
    {        
        Vector3[] positionCards = new Vector3[12];
        positionCards[0] = new Vector3(11, 0, 8.75f); positionCards[1] = new Vector3(10.355f, 0, 7.25f);
        positionCards[2] = new Vector3(11.625f, 0, 7.25f); positionCards[3] = new Vector3(9.75f, 0, 5.75f);
        positionCards[4] = new Vector3(11, 0, 5.75f); positionCards[5] = new Vector3(12.25f, 0, 5.75f);
        positionCards[6] = new Vector3(9.75f, 0, 4.25f); positionCards[7] = new Vector3(11, 0, 4.25f);
        positionCards[8] = new Vector3(12.25f, 0, 4.25f); positionCards[9] = new Vector3(10.355f, 0, 2.75f);
        positionCards[10] = new Vector3(11.625f, 0, 2.75f); positionCards[11] = new Vector3(11, 0, 1.25f);

        tablero = new Tablero(this, positionCards);
    }

    void Update()
    {
        
    }

    async public void CheckPair(int n)
    {
        if (!startedTimer) { startedTimer = true; StartCoroutine(Temp()); timePlayed = Time.time; }

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
                Win();
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

    public void Win() {
        timePlayed = Time.time - timePlayed;
        animacionVictoria.SetActive(true);
        miTiempo.text = ((int)timePlayed).ToString();
        miCanvas.SetActive(true);
        Debug.Log("Has ganado en " + (int) time + " segundos, en el turno " + turno); 
    }

    public void Lost() {
        miCanvas.SetActive(true);
        animacionDerrota.SetActive(true);
        miTiempo.text = ((int)time).ToString();
        Debug.Log("He perdido " + (int)time + " segundos, en el turno " + turno);
    }


    public GameObject Card { get => gameObjectCard; set => gameObjectCard = value; }
    public GameObject Tablero { get => gameObjectTablero; set => gameObjectTablero = value; }
    public int NumCardsTurned { get => numCardsTurned; set => numCardsTurned = value; }

    IEnumerator Temp() {
        yield return new WaitForSeconds(time);
        Lost();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartidaEstandar : MonoBehaviour
{
    [SerializeField] private GameObject gameObjectCard;
    [SerializeField] private GameObject gameObjectTablero;

    private float time;
    private bool startedTimer = false;

    private int turno = 0;
    private Tablero tablero;


    private int pairsFound = 0;
    private Card turnedCard;

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

    public void CheckPair(int n)
    {
        if (!startedTimer) { startedTimer = true; time = Time.time; }

        Card card = tablero.Baraja.GetCard(n);

        if (turnedCard is null)
        {
            turnedCard = card;
        }
        else if (turnedCard.IsPair(card))
        {
            turnedCard = null;
            pairsFound++;
            if (pairsFound == 6) Win();
            turno++;
        }
        else
        {
            turnedCard.TurnCard(); card.TurnCard();
            turnedCard = null;
            turno++;
        }
    }

    public void Win() {
        time = Time.time - time;
        Debug.Log("Has ganado en " + (int) time + " segundos, en el turno " + turno); 
    }

    public GameObject Card { get => gameObjectCard; set => gameObjectCard = value; }
    public GameObject Tablero { get => gameObjectTablero; set => gameObjectTablero = value; }
}

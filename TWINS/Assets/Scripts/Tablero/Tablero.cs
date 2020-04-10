using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tablero : MonoBehaviour
{
    private Properties properties;

    [SerializeField] private Vector3[] positionCards;

    private Card turnedCard;
    private Baraja baraja;
    private ArrayList cards = new ArrayList();

    private void Awake()
    {
        properties = GameObject.FindObjectOfType<Properties>();
        baraja = new Baraja(positionCards.Length, this.GetComponent<Tablero>());
    }

    private void update() { }

    //ESTE METODO PASARLO A PARTIDA ESTANDAR
    //public bool isWon = false;
    private int turno = 0;

    public void CheckPair(int n) {
        Card card = baraja.GetCard(n);

        if (turnedCard is null) {
            Debug.Log(turno + " - 1ra");
            turnedCard = card;
            
        } else if (turnedCard.IsPair(card)) {
            //FALTA HACER
            Debug.Log(turno + "- 2da");
            turnedCard = null;
            turno++; // a borrar
        } else {
            turnedCard.TurnCard(); card.TurnCard();
            turnedCard = null;
            Debug.Log("Borrar");
            turno++; // a borrar

        }
    }
    //Hasta aquí

    public Vector3[] PositionCards { get => positionCards; set => positionCards = value; }
    public Properties Properties { get => properties; set => properties = value; }
}

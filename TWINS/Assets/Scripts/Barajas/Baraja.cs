using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Baraja
{
    protected int pairs;

    protected ArrayList cards = new ArrayList();
    protected Tablero tablero;
    protected Partida partida;

    protected int[] pairsCounter;

    protected Baraja(Tablero tablero)
    {
        pairs = tablero.PositionCards.Length / 2;
        pairsCounter = new int[pairs];
        for (int i = 0; i < pairs; i++) pairsCounter[i] = 0;

        this.partida = GameObject.FindObjectOfType<PartidaEstandar>();
        this.tablero = tablero;
        CreateCards();
    }

    protected void CreateCards()
    {
        GameObject auxCard;

        int i = 1;
        foreach (Vector3 positionCard in tablero.PositionCards)
        {
            Vector3 fixedPosition = new Vector3(positionCard.x, 0.005f, positionCard.z);

            auxCard = GameObject.Instantiate(partida.Card, fixedPosition, Quaternion.identity);
            auxCard.name = "Carta" + i++;
            auxCard.transform.SetParent(partida.Tablero.transform, true);

            Card card = auxCard.GetComponent<Card>();
            SetCardValues(card);
            cards.Add(card);
        }
    }
    public Card GetCard(int n)
    {
        return (Card)cards[n];
    }
    public abstract void SetCardValues(Card card);
}

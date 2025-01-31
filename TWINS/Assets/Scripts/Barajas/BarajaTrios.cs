﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarajaTrios : MonoBehaviour
{
    protected int numTrios;

    protected ArrayList cards = new ArrayList();
    protected Tablero tablero;
    protected Partida partida;

    protected int[] trioCounter;

    public BarajaTrios(Tablero tablero)
    {
        numTrios = tablero.PositionCards.Length / 3;
        trioCounter = new int[numTrios];
        for (int i = 0; i < numTrios; i++) trioCounter[i] = 0;

        this.partida = GameObject.FindObjectOfType<FactoryPartida>().Partida;
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

    protected void SetCardValues(Card card)
    {
        card.Number = cards.Count;
        card.Partida = partida;

        int randomNumber;
        do randomNumber = Random.Range(0, numTrios);
        while (trioCounter[randomNumber] == 3);
        trioCounter[randomNumber]++;

        card.PairNumber = randomNumber;
        if (partida.Tematica == "animal")
        {
            card.Cara.material = Resources.Load<Material>("Barajas/Animales_Baraja/Materials/" + randomNumber);
        }
        else if (partida.Tematica == "profesion")
        {
            card.Cara.material = Resources.Load<Material>("Barajas/Profesiones_Baraja/Materials/" + randomNumber);
        }
        else if (partida.Tematica == "bandera")
        {
            card.Cara.material = Resources.Load<Material>("Barajas/Banderas_Baraja/Materials/" + randomNumber);
        }
        card.Dorso.material = Resources.Load<Material>("Barajas/Dorsos/Materials/DORSO_ROJO");
    }
    public Card GetCard(int n)
    {
        return (Card)cards[n];
    }
}

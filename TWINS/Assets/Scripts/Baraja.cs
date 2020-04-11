using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baraja
{
    private int pairs;
    
    private ArrayList cards = new ArrayList();
    private Tablero tablero;
    private PartidaEstandar partida;

    private int[] pairsCounter;

    public Baraja(PartidaEstandar Partida, Tablero tablero) {
        pairs = tablero.PositionCards.Length / 2;
        pairsCounter = new int[pairs]; 
        for (int i = 0; i < pairs; i++) {
            pairsCounter[i] = 0;
        }

        this.partida = GameObject.FindObjectOfType<PartidaEstandar>();
        this.tablero = tablero;
        CreateCards();
    }

    public void CreateCards() {
        foreach (Vector3 positionCard in tablero.PositionCards)
        {
            Vector3 fixedPosition = new Vector3(positionCard.x, 0.005f, positionCard.z);

            Card card = GameObject.Instantiate(partida.Card, fixedPosition,
                                               Quaternion.identity).GetComponent<Card>();
            SetCardValues(card);
            cards.Add(card);
        }
    }

    public void SetCardValues(Card card) {
        card.Number = cards.Count;
        card.Partida = partida;

        int randomNumber;
        do randomNumber = Random.Range(0, pairs);
        while (pairsCounter[randomNumber] == 2);
        pairsCounter[randomNumber]++;

        card.PairNumber = randomNumber;
        card.Cara.material = Resources.Load<Material>("Animales_Baraja/Materials/" + randomNumber);
    }

    public Card GetCard(int n) {
        return (Card) cards[n];
    }
}

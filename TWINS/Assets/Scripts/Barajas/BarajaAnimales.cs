using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarajaAnimales : Baraja
{
    private int pairs;

    private ArrayList cards = new ArrayList();
    private Tablero tablero;
    private Partida partida;

    private int[] pairsCounter;

    public BarajaAnimales(Tablero tablero)
    {
        pairs = tablero.PositionCards.Length / 2;
        pairsCounter = new int[pairs];
        for (int i = 0; i < pairs; i++) pairsCounter[i] = 0;

        this.partida = GameObject.FindObjectOfType<PartidaEstandar>();
        this.tablero = tablero;
        CreateCards();
    }

    public override void CreateCards()
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

    public override void SetCardValues(Card card)
    {
        card.Number = cards.Count;
        card.Partida = partida;

        int randomNumber;
        do randomNumber = Random.Range(0, pairs);
        while (pairsCounter[randomNumber] == 2);
        pairsCounter[randomNumber]++;

        card.PairNumber = randomNumber;
        card.Cara.material = Resources.Load<Material>("Barajas/Animales_Baraja/Materials/" + randomNumber);
        card.Dorso.material = Resources.Load<Material>("Barajas/Dorsos/Materials/DORSO_ROJO");
    }

    public override Card GetCard(int n) {
        return (Card)cards[n];
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baraja : MonoBehaviour
{
    protected int pairs;

    protected ArrayList cards = new ArrayList();
    protected Tablero tablero;
    protected Partida partida;
    protected int cartasAEncontrar;
    public GameObject[] cartas;
    protected int[] pairsCounter;


    public Baraja(Tablero tablero)
    {
        if (GameProperties.trios)
        {
            cartasAEncontrar = 3;
        }
        else
        {
            cartasAEncontrar = 2;
        }
        pairs = tablero.PositionCards.Length / cartasAEncontrar;
        pairsCounter = new int[pairs];
        for (int i = 0; i < pairs; i++) pairsCounter[i] = 0;

        this.partida = GameObject.FindObjectOfType<FactoryPartida>().Partida;
        this.tablero = tablero;
        CreateCards();
    }

    protected void CreateCards()
    {
        GameObject auxCard;
        cartas = new GameObject[tablero.PositionCards.Length];

        int i = 1;
        foreach (Vector3 positionCard in tablero.PositionCards)
        {
            Vector3 fixedPosition = new Vector3(positionCard.x, 0.005f, positionCard.z);

            auxCard = GameObject.Instantiate(partida.Card, fixedPosition, Quaternion.identity);
            cartas[i - 1] = auxCard;
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
        do randomNumber = Random.Range(0, pairs);
        while (pairsCounter[randomNumber] == cartasAEncontrar);
        pairsCounter[randomNumber]++;

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
        else if (partida.Tematica == "personalizada") {
            card.Cara.material = Resources.Load<Material>("Barajas/Personalizada_Baraja/Materials/" + Personalizada.sprites[randomNumber]);
        }
        card.Dorso.material = Resources.Load<Material>("Barajas/Dorsos/Materials/DORSO_ROJO");
    }
    public Card GetCard(int n)
    {
        return (Card)cards[n];
    }


    protected GameObject[] Cartas { get => cartas; set => cartas = value; }

}

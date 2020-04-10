using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tablero : MonoBehaviour
{
    private Properties properties;

    public Vector3[] positionCards;

    //public bool isWon = false;

    private Card turnedCard;

    private ArrayList cards = new ArrayList();

    private void Awake()
    {
        properties = GameObject.FindObjectOfType<Properties>();

        InstantiateCards();
    }

    private void update() { }

    private void InstantiateCards() {
        int i = 0;

        foreach (Vector3 positionCard in positionCards)
        {

            Vector3 fixedPosition = new Vector3(positionCard.x, 0.005f, positionCard.z);

            GameObject card = GameObject.Instantiate(properties.Card, fixedPosition, Quaternion.identity);

            Card cardScript = card.GetComponent<Card>();
            cardScript.Number = i;
            cardScript.Tablero = this;
            cardScript.PairNumber = 0;
            cards.Add(cardScript);

            i++;
        }
    }

    private int turno = 0; //a borrar
    public void CheckPair(int number) {
        Card card = (Card)cards[number];

        if (turnedCard is null) {
            turnedCard = card;
            Debug.Log(turno + "- 1ra");
        } else if (turnedCard.IsPair(card)) {
            //FALTA HACER
            Debug.Log(turno + "- 2da");
            turnedCard = null;
            turno++; // a borrar
        } else {
            turnedCard = null;
            turnedCard.TurnCard(); card.TurnCard();
            turno++; // a borrar
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class PartidaPorCarta : Partida
{
    //public int parejasPosibles = tablero.PositionCards.Length / 2;
    Boolean[] ids;
    public Sprite carta;
    public Image imagen;
    public Card card;
    public GameObject auxCard;
    public int RandomNumber;
    public int numParejas;

    public void Start()
    {
        SetTableroValues();
        InitializeMainCard();
    }

    private void InitializeMainCard() {
        imagen.sprite = carta;
        auxCard = GameObject.Instantiate(gameObjectCard, new Vector3(5.36f, 2.38f, 2.69f), Quaternion.Euler(180, 180, 0));
        auxCard.GetComponent<Rigidbody>().useGravity = false;
        card = auxCard.GetComponent<Card>();
        card.Cara.material = Resources.Load<Material>("Barajas/Animales_Baraja/Materials/" + elegirObjetivo());
        card.Dorso.material = Resources.Load<Material>("Barajas/Dorsos/Materials/DORSO_ROJO");
    }

    protected override void SetTableroValues() {

        


        gameObjectTablero = GameObject.Instantiate(gameObjectTablero, positionTablero, Quaternion.identity);
        gameObjectTablero.name = "Tablero";

        tablero = gameObjectTablero.GetComponent<Tablero>();

        tablero.InitializeValues(this, positionCards);

        numParejas = positionCards.Length / 2;

        ids = new Boolean[numParejas];
    }

    async public override void CheckPair(int n)
    {
        if (!startedTimer) { startedTimer = true; }

        Card card = tablero.Baraja.GetCard(n);

        if (turnedCard is null)
        {
            turnedCard = card;
            /*if (card.PairNumber != RandomNumber)
            {
                numCardsTurned = 0;
                await Task.Delay(200);
                turnedCard.TurnCard();
                turnedCard = null;
                turno++;
            }*/
        }
        else if (turnedCard.IsPair(card) && card.PairNumber == RandomNumber)
        {
            await Task.Delay(500);

            turnedCard = null;
            pairsFound++;
            puntos = contexto.SumarPuntos();
            puntuacion.text = "Puntuación: " + puntos.ToString();

            IsWon();
            if (pairsFound != numParejas)
            {
                elegirObjetivo();
            }

            turno++;
            numCardsTurned = 0;
        }
        else
        {
            await Task.Delay(200);
            turnedCard.TurnCard(); card.TurnCard();
            numCardsTurned = 0;
            turnedCard = null;
            turno++;
            puntos = contexto.RestarPuntos();
            if (puntos < 0)
            {
                IsLost();
            }
            puntuacion.text = "Puntuación: " + puntos.ToString();
        }
    }

    public void cambiarCarta(int indice)
    {
        card.Cara.material = Resources.Load<Material>("Barajas/Animales_Baraja/Materials/" + indice);
    }

    public int elegirObjetivo()
    {
        int indice;
        do
        {
            indice = Random.Range(0, ids.Length);
        } while (ids[indice]);
        ids[indice] = true;
        cambiarCarta(indice);
        RandomNumber = indice;
        return indice;
    }
}

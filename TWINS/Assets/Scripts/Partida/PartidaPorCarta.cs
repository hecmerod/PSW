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
        imagen.sprite = carta;
        auxCard = GameObject.Instantiate(gameObjectCard, new Vector3(6.06f, 5.18f, 2.69f), Quaternion.Euler(200, 180, 0));
        auxCard.GetComponent<Rigidbody>().useGravity = false;
        card = auxCard.GetComponent<Card>();
        card.Cara.material = Resources.Load<Material>("Barajas/Animales_Baraja/Materials/" + elegirObjetivo());
        card.Dorso.material = Resources.Load<Material>("Barajas/Dorsos/Materials/DORSO_ROJO");
    }

    protected override void SetTableroValues()
    { //ESTO HAY QUE AUTOMATIZARLO

        Vector3[] positionCards = new Vector3[0];
        Vector3 positionTablero = Vector3.zero;

        switch (tamaño)
        {
            case "pequeño":
                positionCards = new Vector3[12];
                positionTablero = new Vector3(7.5f, 0, 5);

                positionCards[0] = new Vector3(11, 0, 8.75f); positionCards[1] = new Vector3(10.355f, 0, 7.25f);
                positionCards[2] = new Vector3(11.625f, 0, 7.25f); positionCards[3] = new Vector3(9.75f, 0, 5.75f);
                positionCards[4] = new Vector3(11, 0, 5.75f); positionCards[5] = new Vector3(12.25f, 0, 5.75f);
                positionCards[6] = new Vector3(9.75f, 0, 4.25f); positionCards[7] = new Vector3(11, 0, 4.25f);
                positionCards[8] = new Vector3(12.25f, 0, 4.25f); positionCards[9] = new Vector3(10.355f, 0, 2.75f);
                positionCards[10] = new Vector3(11.625f, 0, 2.75f); positionCards[11] = new Vector3(11, 0, 1.25f);
                break;

            case "mediano":
                positionTablero = new Vector3();
                break;
            case "grande":
                positionCards = new Vector3[32];
                positionTablero = new Vector3(7.5f, 0, 5);

                positionCards[0] = new Vector3(2.5f, 0, 2.5f); positionCards[1] = new Vector3(3.929f, 0, 2.5f);
                positionCards[2] = new Vector3(5.3575f, 0, 2.5f); positionCards[3] = new Vector3(6.786f, 0, 2.5f);
                positionCards[4] = new Vector3(8.2145f, 0, 2.5f); positionCards[5] = new Vector3(9.643f, 0, 2.5f);
                positionCards[6] = new Vector3(11.0715f, 0, 2.5f); positionCards[7] = new Vector3(12.5f, 0, 2.5f);

                positionCards[8] = new Vector3(2.5f, 0, 4.166667f); positionCards[9] = new Vector3(3.929f, 0, 4.166667f);
                positionCards[10] = new Vector3(5.3575f, 0, 4.166667f); positionCards[11] = new Vector3(6.786f, 0, 4.166667f);
                positionCards[12] = new Vector3(8.2145f, 0, 4.166667f); positionCards[13] = new Vector3(9.643f, 0, 4.166667f);
                positionCards[14] = new Vector3(11.0715f, 0, 4.166667f); positionCards[15] = new Vector3(12.5f, 0, 4.166667f);

                positionCards[16] = new Vector3(2.5f, 0, 5.8333f); positionCards[17] = new Vector3(3.929f, 0, 5.8333f);
                positionCards[18] = new Vector3(5.3575f, 0, 5.8333f); positionCards[19] = new Vector3(6.786f, 0, 5.8333f);
                positionCards[20] = new Vector3(8.2145f, 0, 5.8333f); positionCards[21] = new Vector3(9.643f, 0, 5.8333f);
                positionCards[22] = new Vector3(11.0715f, 0, 5.8333f); positionCards[23] = new Vector3(12.5f, 0, 5.8333f);

                positionCards[24] = new Vector3(2.5f, 0, 7.5f); positionCards[25] = new Vector3(3.929f, 0, 7.5f);
                positionCards[26] = new Vector3(5.3575f, 0, 7.5f); positionCards[27] = new Vector3(6.786f, 0, 7.5f);
                positionCards[28] = new Vector3(8.2145f, 0, 7.5f); positionCards[29] = new Vector3(9.643f, 0, 7.5f);
                positionCards[30] = new Vector3(11.0715f, 0, 7.5f); positionCards[31] = new Vector3(12.5f, 0, 7.5f);
                break;
            default: //A BORRAR
                positionCards = new Vector3[12];
                positionTablero = new Vector3(7.5f, 0, 5);

                positionCards[0] = new Vector3(11, 0, 8.75f); positionCards[1] = new Vector3(10.355f, 0, 7.25f);
                positionCards[2] = new Vector3(11.625f, 0, 7.25f); positionCards[3] = new Vector3(9.75f, 0, 5.75f);
                positionCards[4] = new Vector3(11, 0, 5.75f); positionCards[5] = new Vector3(12.25f, 0, 5.75f);
                positionCards[6] = new Vector3(9.75f, 0, 4.25f); positionCards[7] = new Vector3(11, 0, 4.25f);
                positionCards[8] = new Vector3(12.25f, 0, 4.25f); positionCards[9] = new Vector3(10.355f, 0, 2.75f);
                positionCards[10] = new Vector3(11.625f, 0, 2.75f); positionCards[11] = new Vector3(11, 0, 1.25f);
                break;
        }


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
            if (card.PairNumber != RandomNumber)
            {
                numCardsTurned = 0;
                await Task.Delay(200);
                turnedCard.TurnCard();
                turnedCard = null;
                turno++;
            }
        }
        else if (turnedCard.IsPair(card))
        {
            await Task.Delay(500);

            turnedCard = null;
            pairsFound++;

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

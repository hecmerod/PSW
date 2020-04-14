using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class PartidaEstandar : Partida
{   
    public void Start()
    {
        SetTableroValues();
    }

    protected override void SetTableroValues() { //ESTO HAY QUE AUTOMATIZARLO

        Vector3[] positionCards = new Vector3[12]; 

        positionCards[0] = new Vector3(11, 0, 8.75f); positionCards[1] = new Vector3(10.355f, 0, 7.25f);
        positionCards[2] = new Vector3(11.625f, 0, 7.25f); positionCards[3] = new Vector3(9.75f, 0, 5.75f);
        positionCards[4] = new Vector3(11, 0, 5.75f); positionCards[5] = new Vector3(12.25f, 0, 5.75f);
        positionCards[6] = new Vector3(9.75f, 0, 4.25f); positionCards[7] = new Vector3(11, 0, 4.25f);
        positionCards[8] = new Vector3(12.25f, 0, 4.25f); positionCards[9] = new Vector3(10.355f, 0, 2.75f);
        positionCards[10] = new Vector3(11.625f, 0, 2.75f); positionCards[11] = new Vector3(11, 0, 1.25f);

        tablero = GameObject.Instantiate(gameObjectTablero, new Vector3(7.5f, 0, 5), Quaternion.identity)
                            .GetComponent<Tablero>();
        tablero.InitializeValues(this, positionCards, tematica);
    }

    async public override void CheckPair(int n)
    {
        if (!startedTimer) { startedTimer = true; }

        Card card = tablero.Baraja.GetCard(n);

        if (turnedCard is null)
        {
            turnedCard = card;
        }
        else if (turnedCard.IsPair(card))
        {
            await Task.Delay(500);

            turnedCard = null;
            pairsFound++;

            isWon(6);

            turno++;
            numCardsTurned = 0;
        }
        else
        {
            await Task.Delay(800);
            turnedCard.TurnCard(); card.TurnCard();
            numCardsTurned = 0;
            turnedCard = null;
            turno++;
        }
    }
}

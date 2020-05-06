using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class PartidaEstandar : Partida
{
    
    public void Start() {
        SetTableroValues();
    }


    private Vector3[] positionCards = new Vector3[0];
    private Vector3 positionTablero = Vector3.zero;    

    protected override void SetTableroValues() { //ESTO HAY QUE AUTOMATIZARLO

        

        levelProperties = GameObject.FindObjectOfType<LevelProperties>();
        if (levelProperties == null) SwitchSize();
        else {
            positionCards = levelProperties.CardsPositions;
            contexto.TipoPuntuacion = levelProperties.PuntuacionFacil;
            positionTablero = new Vector3(7.5f, 0, 5);
        }
            


        gameObjectTablero = GameObject.Instantiate(gameObjectTablero, positionTablero, Quaternion.identity);
        gameObjectTablero.name = "Tablero";

        tablero = gameObjectTablero.GetComponent<Tablero>();

        tablero.InitializeValues(this, positionCards);
    }
    private void SwitchSize() {
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

                puntuacionFacil = new PuntuacionFacil();
                contexto.TipoPuntuacion = puntuacionFacil;
                break;

            /*case "mediano":
                positionTablero = new Vector3();
                puntuacionNormal = new PuntuacionNormal();
                contexto.TipoPuntuacion = puntuacionNormal;
                break;*/
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

                puntuacionDificil = new PuntuacionDificil();
                contexto.TipoPuntuacion = puntuacionDificil;
                break;

            default:
                positionCards = new Vector3[12];
                positionTablero = new Vector3(7.5f, 0, 5);
                puntuacionFacil = new PuntuacionFacil();
                contexto.TipoPuntuacion = puntuacionFacil;

                positionCards[0] = new Vector3(11, 0, 8.75f); positionCards[1] = new Vector3(10.355f, 0, 7.25f);
                positionCards[2] = new Vector3(11.625f, 0, 7.25f); positionCards[3] = new Vector3(9.75f, 0, 5.75f);
                positionCards[4] = new Vector3(11, 0, 5.75f); positionCards[5] = new Vector3(12.25f, 0, 5.75f);
                positionCards[6] = new Vector3(9.75f, 0, 4.25f); positionCards[7] = new Vector3(11, 0, 4.25f);
                positionCards[8] = new Vector3(12.25f, 0, 4.25f); positionCards[9] = new Vector3(10.355f, 0, 2.75f);
                positionCards[10] = new Vector3(11.625f, 0, 2.75f); positionCards[11] = new Vector3(11, 0, 1.25f);
                break;
        }
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
            puntos = contexto.SumarPuntos();
            puntuacion.text = "Puntuación: " + puntos.ToString();

            IsWon();

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
            if(puntos < 0)
            {
                IsLost();
            }
            puntuacion.text = "Puntuación: " + puntos.ToString();
        }
    }
}

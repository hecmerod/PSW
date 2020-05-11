using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class PartidaEstandar : Partida
{
    AudioSource parejaCorrecta;
    GameObject camara;

    public void Start() {
        SetTableroValues();
        camara = GameObject.Find("Main Camera");
        parejaCorrecta = camara.GetComponent<AudioSource>();
    }

    protected override void SetTableroValues() {       

        gameObjectTablero = GameObject.Instantiate(gameObjectTablero, positionTablero, Quaternion.identity);
        gameObjectTablero.name = "Tablero";

        tablero = gameObjectTablero.GetComponent<Tablero>();

        tablero.InitializeValues(this, positionCards);
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
            parejaCorrecta.Play();

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

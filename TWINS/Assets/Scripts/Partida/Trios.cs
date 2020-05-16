using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class Trios : Partida
{
    AudioSource parejaCorrecta;
    GameObject camara;

    public void Start()
    {
        SetTableroValues();
        camara = GameObject.Find("Main Camera");
        parejaCorrecta = camara.GetComponent<AudioSource>();
        categoria.SetActive(false);
    }

    protected override void SetTableroValues()
    {

        gameObjectTablero = GameObject.Instantiate(gameObjectTablero, positionTablero, Quaternion.identity);
        gameObjectTablero.name = "Tablero";

        tablero = gameObjectTablero.GetComponent<Tablero>();

        tablero.InitializeValues(this, positionCards);
    }

    async public override void CheckPair(int n)
    {
        if (!startedTimer) { startedTimer = true; tiempo.comenzarTiempo = true; }

        Card card = tablero.Baraja.GetCard(n);

        if (turnedCard is null)
        {
            turnedCard = card;
            numCardsTurned = 1;
            trios = 1;
        }
        else if (turnedCard.IsPair(card))
        {
            numCardsTurned++;
            trios++;
            if(trios == 3 && numCardsTurned == 3)
            {
                parejaCorrecta.Play();
                await Task.Delay(500);
                turnedCard = null;
                pairsFound++;
                puntos = contexto.SumarPuntos();
                puntuacion.text = "Puntuación: " + puntos.ToString();

                TriosWon();
                numCardsTurned = 0;
            }
            else
            {
                numCardsTurned++;
                trios++;
            }
            /*parejaCorrecta.Play();

            await Task.Delay(500);


            turnedCard = null;
            pairsFound++;
            puntos = contexto.SumarPuntos();
            puntuacion.text = "Puntuación: " + puntos.ToString();

            IsWon();

            turno++;
            numCardsTurned = 0;*/
        }
        else
        {
            numCardsTurned++;
            if(numCardsTurned == 3)
            {
                await Task.Delay(200);
                numCardsTurned = 0;
                trios = 0;
                puntos = contexto.RestarPuntos();
                if (puntos < 0)
                {
                    IsLost();
                }
                puntuacion.text = "Puntuación: " + puntos.ToString();
            }
            /*await Task.Delay(200);
            turnedCard.TurnCard(); card.TurnCard();
            numCardsTurned = 0;
            turnedCard = null;
            turno++;
            puntos = contexto.RestarPuntos();
            if (puntos < 0)
            {
                IsLost();
            }
            puntuacion.text = "Puntuación: " + puntos.ToString();*/
        }
    }
}
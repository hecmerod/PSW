using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class MultijugadorLocal : Partida
{
    AudioSource parejaCorrecta;
    GameObject camara;
    //public int puntos1, puntos2;
    Text textTurno, textPuntuacion1, textPuntuacion2;
    int turnoJugador = 1;

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
        gameObjectTurno.SetActive(true);
        puntuacion1.SetActive(true);
        puntuacion2.SetActive(true);

        textPuntuacion1 = puntuacion1.GetComponent<Text>();
        textPuntuacion2 = puntuacion2.GetComponent<Text>();

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
        }
        else if (turnedCard.IsPair(card))
        {
            parejaCorrecta.Play();

            await Task.Delay(500);


            turnedCard = null;
            pairsFound++;
            if (turno == 1)
            {
                puntos1 = contexto.SumarPuntos();
                textPuntuacion1.text = "Puntuación: " + puntos1.ToString();
                turno = 2;
            }
            else
            {
                puntos2 = contexto.SumarPuntos();
                textPuntuacion2.text = "Puntuación: " + puntos2.ToString();
                turno = 1;
            }

            MultijugadorWon();

            numCardsTurned = 0;
        }
        else
        {
            await Task.Delay(200);
            turnedCard.TurnCard(); card.TurnCard();
            numCardsTurned = 0;
            turnedCard = null;
            if (turno == 1)
            {
                puntos1 = contexto.RestarPuntos();
                textPuntuacion1.text = "Putuación: " + puntos1.ToString();
                turno = 2;
            }
            else
            {
                puntos2 = contexto.RestarPuntos();
                textPuntuacion2.text = "Puntuación: " + puntos2.ToString();
                turno = 1;
            }
            /*if (puntos < 0)
            {
                IsLost();
            }*/
        }
    }
}


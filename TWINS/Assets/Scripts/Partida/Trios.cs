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
        }
        else if (turnedCard2 is null)
        {
            turnedCard2 = card;
        }
        else if (turnedCard.IsPair(card) && turnedCard2.IsPair(card))
        {
            parejaCorrecta.Play();
            await Task.Delay(500);
            turnedCard = null; turnedCard2 = null;
            pairsFound++;
            puntos = contexto.SumarPuntos();
            puntuacion.text = "Puntuación: " + puntos.ToString();

            IsWon();
            numCardsTurned = 0;
            trios = 0;
        }
        else
        {
            await Task.Delay(200);
            turnedCard2.TurnCard(); turnedCard.TurnCard(); card.TurnCard();
            numCardsTurned = 0;
            turnedCard = null; turnedCard2 = null;
            trios = 0;
            puntos = contexto.RestarPuntos();
            if (puntos < 0)
            {
                IsLost();
            }
            puntuacion.text = "Puntuación: " + puntos.ToString();
        }
    }

    new private void IsWon()
    {
        if (pairsFound == tablero.PositionCards.Length / 3)
        {
            numCardsTurned = 3;
            tiempo.partidaTerminada = true;
            tiempo.comenzarTiempo = false;
            textPuntuacion.text = "Puntuación: " + puntos;
            animacionVictoria.SetActive(true);
            contexto.ResetearPuntuacion();
            fuenteAudio.Stop();

            DBManager.partidasGanadas++;
            DBManager.UpdaterData(puntos);
            if (DBManager.nivel == GameProperties.level) DBManager.nivel++;

            base.dBPartida.CallSaveData();
        }
    }
}
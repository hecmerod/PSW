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
    Text textPuntuacion1, textPuntuacion2;
    int turnoJugador = 1;
    Color32 color;

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
        if (!puntuacion1.activeSelf && !puntuacion2.activeSelf)
        {
            puntuacion1.SetActive(true);
            puntuacion2.SetActive(true);
        }
        puntuacion.text = "";
        color = new Color32(189,48,66,255);

        textPuntuacion1 = puntuacion1.GetComponent<Text>();
        textPuntuacion1.text = "Jugador 1: 0";
        textPuntuacion2 = puntuacion2.GetComponent<Text>();
        textPuntuacion2.text = "Jugador 2: 0";
        textPuntuacion1.color = Color.blue;

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
            if (turnoJugador == 1)
            {
                puntos1 = contexto.SumarPuntos();
                textPuntuacion1.text = "Jugador 1: " + puntos1.ToString();
                textPuntuacion1.color = color;
                turnoJugador = 2;
                textPuntuacion2.color = Color.blue;
            }
            else
            {
                puntos2 = contexto.SumarPuntos();
                textPuntuacion2.text = "Jugador 2: " + puntos2.ToString();
                textPuntuacion2.color = color;
                turnoJugador = 1;
                textPuntuacion1.color = Color.blue;
            }

            IsWon();

            numCardsTurned = 0;
        }
        else
        {
            await Task.Delay(200);
            turnedCard.TurnCard(); card.TurnCard();
            numCardsTurned = 0;
            turnedCard = null;
            if (turnoJugador == 1)
            {
                puntos1 = contexto.RestarPuntos();
                textPuntuacion1.text = "Jugador 1: " + puntos1.ToString();
                textPuntuacion1.color = color;
                turnoJugador = 2;
                textPuntuacion2.color = Color.blue;
            }
            else
            {
                puntos2 = contexto.RestarPuntos();
                textPuntuacion2.text = "Jugador 2: " + puntos2.ToString();
                textPuntuacion2.color = color;
                turnoJugador = 1;
                textPuntuacion1.color = Color.blue;
            }
        }
    }

    new private void IsWon()
    {
        if (pairsFound == tablero.PositionCards.Length / 2)
        {
            numCardsTurned = 3;
            tiempo.partidaTerminada = true;
            tiempo.comenzarTiempo = false;
            if (puntos1 > puntos2)
            {
                textPuntuacion.text = "Jugador 1: " + puntos1;
            }
            else
            {
                textPuntuacion.text = "Jugador 2: " + puntos2;
            }
            animacionVictoria.SetActive(true);
            contexto.ResetearPuntuacion();
            fuenteAudio.Stop();

            DBManager.getInstance().partidasGanadas++;
            DBManager.getInstance().UpdaterData(puntos);
            if (DBManager.getInstance().nivel == GameProperties.level) DBManager.getInstance().nivel++;

            dBPartida.CallSaveData();
        }
    }
}


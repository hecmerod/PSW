using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class Dinamica : Partida
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
            if (puntos < 0)
            {
                IsLost();
            }
            //moverCartas();
            puntuacion.text = "Puntuación: " + puntos.ToString();
        }
    }

    //NO BORRAR
    /*public void moverCartas()
    {
        foreach (int i in GameProperties.cardsPositions)
        {
            if (GameProperties.cardsPositions[i].transform.position.x = 12.5f)
            {
                GameProperties.cardsPositions[i] = new Vector(6.786f, GameProperties.cardsPositions[i].transform.position.y, GameProperties.cardsPositions[i].transform.position.z);
            }
            else
            {
                GameProperties.cardsPositions[i] = new Vector(GameProperties.cardsPositions[i].transform.position.x + 1.4285f, GameProperties.cardsPositions[i].transform.position.y, GameProperties.cardsPositions[i].transform.position.z);
            }
        }
        //GameProperties.cardsPositions[0] = new Vector3(); GameProperties.cardsPositions[1] = new Vector3(); GameProperties.cardsPositions[2] = new Vector3(); GameProperties.cardsPositions[3] = new Vector3(); GameProperties.cardsPositions[4] = new Vector3();
        //GameProperties.cardsPositions[5] = new Vector3(); GameProperties.cardsPositions[6] = new Vector3(); GameProperties.cardsPositions[7] = new Vector3(); GameProperties.cardsPositions[8] = new Vector3(); GameProperties.cardsPositions[9] = new Vector3();
        //GameProperties.cardsPositions[10] = new Vector3(); GameProperties.cardsPositions[11] = new Vector3(); GameProperties.cardsPositions[12] = new Vector3(); GameProperties.cardsPositions[13] = new Vector3(); GameProperties.cardsPositions[14] = new Vector3(); 
        //GameProperties.cardsPositions[15] = new Vector3(); GameProperties.cardsPositions[16] = new Vector3(); GameProperties.cardsPositions[17] = new Vector3(); GameProperties.cardsPositions[18] = new Vector3(); GameProperties.cardsPositions[19] = new Vector3();
    }*/
}

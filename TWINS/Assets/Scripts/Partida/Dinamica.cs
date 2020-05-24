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
    GameObject[] cartasDinamicas;

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
        if (!startedTimer) { 
            startedTimer = true; 
            tiempo.comenzarTiempo = true;
            cartasDinamicas = this.tablero.Baraja.cartas;
        }

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
            moverCartas();
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

    //NO BORRAR
    async public void moverCartas()
    {
        Vector3[] posicionesCartas = new Vector3[GameProperties.cardsPositions.Length];
        for (int i = 0; i < GameProperties.cardsPositions.Length; i++)
        {
            posicionesCartas[i] = cartasDinamicas[i].transform.position;
            if (cartasDinamicas[i].transform.position.x >= 12.4f)
            {
                cartasDinamicas[i].GetComponent<Rigidbody>().AddForce(new Vector3(0, 1, 0) * 176);
                cartasDinamicas[i].GetComponent<Rigidbody>().AddForce(new Vector3(-1, 0, 0) * 385);
            }
            else
            {
                cartasDinamicas[i].GetComponent<Rigidbody>().AddForce(new Vector3(1, 0, 0) * 295);
            }
        }
        await Task.Delay(875);

        for (int i = 0; i < GameProperties.cardsPositions.Length; i++)
        {

            if (posicionesCartas[i].x >= 12.4f)
            {
                cartasDinamicas[i].transform.position = new Vector3(6.786f, posicionesCartas[i].y, posicionesCartas[i].z);
            }
            else
            {
                cartasDinamicas[i].transform.position = new Vector3(posicionesCartas[i].x + 1.4285f, posicionesCartas[i].y, posicionesCartas[i].z);
            }
        }
    }

    
}

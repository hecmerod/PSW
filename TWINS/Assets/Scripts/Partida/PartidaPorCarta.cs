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

    AudioSource parejaCorrecta;
    GameObject camara;

    public void Start()
    {
        SetTableroValues();
        InitializeMainCard(); 
        camara = GameObject.Find("Main Camera");
        parejaCorrecta = camara.GetComponent<AudioSource>();
    }

    private void InitializeMainCard() {
        imagen.sprite = carta;
        if (GameProperties.tamaño == "grande")
        {
            auxCard = GameObject.Instantiate(gameObjectCard, new Vector3(1.75f, 1, 3), Quaternion.Euler(180, 180, 0));
        }
        else
        {
            auxCard = GameObject.Instantiate(gameObjectCard, new Vector3(5, 1, 3), Quaternion.Euler(180, 180, 0));
        }
        auxCard.GetComponent<Rigidbody>().useGravity = false;
        card = auxCard.GetComponent<Card>();
        card.Cara.material = Resources.Load<Material>("Barajas/"+  ElegirCartaObjetivo()  + "/Materials/" + elegirObjetivo());
        card.Dorso.material = Resources.Load<Material>("Barajas/Dorsos/Materials/DORSO_ROJO");
    }

    private string ElegirCartaObjetivo()
    {
        string res = "";
        switch (GameProperties.baraja)
        {
            case "animal":
                res = "Animales_Baraja";
                break;
            case "profesion":
                res = "Profesiones_Baraja";
                break;
            case "bandera":
                res = "Banderas_Baraja";
                break;
        }
        return res;
    }

    protected override void SetTableroValues() {

        


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
            /*if (card.PairNumber != RandomNumber)
            {
                numCardsTurned = 0;
                await Task.Delay(200);
                turnedCard.TurnCard();
                turnedCard = null;
                turno++;
            }*/
        }
        else if (turnedCard.IsPair(card) && card.PairNumber == RandomNumber)
        {
            
            parejaCorrecta.Play();

            await Task.Delay(500);

            turnedCard = null;
            pairsFound++;
            puntos = contexto.SumarPuntos();
            puntuacion.text = "Puntuación: " + puntos.ToString();

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
            puntos = contexto.RestarPuntos();
            if (puntos < 0)
            {
                IsLost();
            }
            puntuacion.text = "Puntuación: " + puntos.ToString();
        }
    }

    public void cambiarCarta(int indice)
    {
        card.Cara.material = Resources.Load<Material>("Barajas/" + ElegirCartaObjetivo() +"/Materials/" + indice);
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

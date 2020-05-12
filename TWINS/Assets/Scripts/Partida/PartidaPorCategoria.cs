using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class PartidaPorCategoria : Partida
{
    List<String> categorias = new List<String>(); //{ "domesticos", "sabana", "bosque" };
    private Text categoria;
    private String aux = null;
    private int pairsCategoria2;
    private int pairsCategoria4;
    //IPuntuacion puntuacionFacil, puntuacionNormal, puntuacionDificil;
    //private ContextoPuntuacion contexto = new ContextoPuntuacion();

    AudioSource parejaCorrecta;
    GameObject camara;

    public void Start()
    {
        SetTableroValues();
        iniciarCategoria();
        categoria = base.categoria.GetComponent<Text>();
        categoria.text = elegirCategoria();
        pairsCategoria2 = 0;
        pairsCategoria4 = 0;
        camara = GameObject.Find("Main Camera");
        parejaCorrecta = camara.GetComponent<AudioSource>();

    }
    public void iniciarCategoria()
    {
        List<String> c1 = new List<String> { "domesticos", "sabana", "bosque" };
        List<String> c2 = new List<String> { "domesticos", "sabana", "pradera", "bosque" };
        switch (GameProperties.tamaño)
        {
            case "pequeño":
                categorias.AddRange(c1);
                break;
            case "grande":
                categorias.AddRange(c2);
                break;
        }
    }
    protected override void SetTableroValues() {
        //RectTransform categoriapos = categoria.GetComponent<RectTransform>();

        gameObjectTablero = GameObject.Instantiate(gameObjectTablero, positionTablero, Quaternion.identity);
        gameObjectTablero.name = "Tablero";

        tablero = gameObjectTablero.GetComponent<Tablero>();

        tablero.InitializeValues(this, positionCards);
    }
    public String elegirCategoria()
    {
        int indice = Random.Range(0, categorias.Count);
        String cat = categorias[indice];
        if(categorias.Count > 1) { categorias.RemoveAt(indice); }
        return cat;
    }
    public void enCategoria()
    {
        switch (GameProperties.tamaño) {
            case "pequeño":
                if (pairsCategoria2 == 2)
                {
                    categoria.text = elegirCategoria();
                    pairsCategoria2 = 0;
                }
                break;
            case "grande":
                if(pairsCategoria4 == 4)
                {
                    categoria.text = elegirCategoria();
                    pairsCategoria4 = 0;
                }
                break;
        }
    }
    public Boolean esCategoria(Card carta)
    {
        aux = categoria.text;
        if (GameProperties.tamaño == "pequeño")
        {
            switch (aux)
            {
                case string aux when aux == "bosque":
                    return carta.PairNumber == 3 || carta.PairNumber == 0;
                    break;
                case string aux when aux == "domesticos":
                    return carta.PairNumber == 1 || carta.PairNumber == 4;
                    break;
                case string aux when aux == "sabana":
                    return carta.PairNumber == 5 || carta.PairNumber == 2;
                    break;
                default:
                    return false;
                    break;
            }
        }
        else
        {
            switch (aux)
            {
                case string aux when aux == "domesticos":
                    return carta.PairNumber == 1 || carta.PairNumber == 4 || carta.PairNumber == 10 || carta.PairNumber == 15;
                    break;
                case string aux when aux == "pradera":
                    return carta.PairNumber == 12 || carta.PairNumber == 13 || carta.PairNumber == 0 || carta.PairNumber == 11;
                    break;
                case string aux when aux == "sabana":
                    return carta.PairNumber == 6 || carta.PairNumber == 2 || carta.PairNumber == 5 || carta.PairNumber == 8;
                    break;
                case string aux when aux == "bosque":
                    return carta.PairNumber == 6 || carta.PairNumber == 2 || carta.PairNumber == 5 || carta.PairNumber == 8;
                    break;
                default:
                    return false;
                    break;
            }
        }
    }


    async public override void CheckPair(int n)
    {
        if (!startedTimer) { 
            startedTimer = true; 
            tiempo.comenzarTiempo = true; 
        }

        Card card = tablero.Baraja.GetCard(n);

        if (turnedCard is null)
        {
            turnedCard = card;
        }
        else if (turnedCard.IsPair(card) && esCategoria(card) == true)
        {
            parejaCorrecta.Play();

            await Task.Delay(500);

            turnedCard = null;
            pairsFound++;
            puntos = contexto.SumarPuntos();
            puntuacion.text = "Puntuación: " + puntos.ToString();

            IsWon();
            pairsCategoria2++;
            pairsCategoria4++;
            enCategoria();

            turno++;
            numCardsTurned = 0;
        }
        else
        {
            await Task.Delay(500);
            turnedCard.TurnCard(); card.TurnCard();
            numCardsTurned = 0;
            turnedCard = null;
            turno++;
            puntos = contexto.RestarPuntos();
            if(puntos < 0)
            {
                base.categoria.SetActive(false);
                IsLost();
            }
            puntuacion.text = "Puntuación: " + puntos.ToString();
        }
    }
}
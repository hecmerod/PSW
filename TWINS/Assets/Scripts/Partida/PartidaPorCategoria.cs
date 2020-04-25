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
    Text categoria;
    public String aux = null;
    public int pairsCategoria2;
    public int pairsCategoria4;
    public void Start()
    {
        SetTableroValues();
        categoria = GameObject.Find("Canvas/categoria").GetComponent<Text>();
        iniciarCategoria();
        categoria.text = elegirCategoria();
        pairsCategoria2 = 0;
        pairsCategoria4 = 0;
}
    public void iniciarCategoria()
    {
        List<String> c1 = new List<String> { "domesticos", "sabana", "bosque" };
        List<String> c2 = new List<String> { "domesticos", "sabana", "pradera", "bosque" };
        switch (tamaño)
        {
            case "pequeño":
                categorias.AddRange(c1);
                break;
            case "grande":
                categorias.AddRange(c2);
                break;
        }
    }
    protected override void SetTableroValues()
    { //ESTO HAY QUE AUTOMATIZARLO

        Vector3[] positionCards = new Vector3[0];
        Vector3 positionTablero = Vector3.zero;
        //RectTransform categoriapos = categoria.GetComponent<RectTransform>();


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
                //categoriapos.anchoredPosition = new Vector3(0, 0, 0);
                break;

            case "mediano":
                positionTablero = new Vector3();
                break;
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
                break;
            default: //A BORRAR
                positionCards = new Vector3[12];
                positionTablero = new Vector3(7.5f, 0, 5);

                positionCards[0] = new Vector3(11, 0, 8.75f); positionCards[1] = new Vector3(10.355f, 0, 7.25f);
                positionCards[2] = new Vector3(11.625f, 0, 7.25f); positionCards[3] = new Vector3(9.75f, 0, 5.75f);
                positionCards[4] = new Vector3(11, 0, 5.75f); positionCards[5] = new Vector3(12.25f, 0, 5.75f);
                positionCards[6] = new Vector3(9.75f, 0, 4.25f); positionCards[7] = new Vector3(11, 0, 4.25f);
                positionCards[8] = new Vector3(12.25f, 0, 4.25f); positionCards[9] = new Vector3(10.355f, 0, 2.75f);
                positionCards[10] = new Vector3(11.625f, 0, 2.75f); positionCards[11] = new Vector3(11, 0, 1.25f);
                break;
        }


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
        switch (tamaño) {
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
        if (tamaño == "pequeño")
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
        if (!startedTimer) { startedTimer = true; }

        Card card = tablero.Baraja.GetCard(n);

        if (turnedCard is null)
        {
            turnedCard = card;
        }
        else if (turnedCard.IsPair(card) && esCategoria(card) == true)
        {
            await Task.Delay(500);

            turnedCard = null;
            pairsFound++;


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
        }
    }
}
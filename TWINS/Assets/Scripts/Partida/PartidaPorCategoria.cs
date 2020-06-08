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
    IIteratorCategoria iterator;
    //IPuntuacion puntuacionFacil, puntuacionNormal, puntuacionDificil;
    //private ContextoPuntuacion contexto = new ContextoPuntuacion();

    AudioSource parejaCorrecta;
    GameObject camara;

    public void Start()
    {
        categoria = base.categoria.GetComponent<Text>();
        SetTableroValues();
        iniciarCategoria();        
        categoria.text = elegirCategoria();
        if (puntuacion1.activeSelf && puntuacion2.activeSelf)
        {
            puntuacion1.SetActive(false);
            puntuacion2.SetActive(false);
        }
        pairsCategoria2 = 0;
        pairsCategoria4 = 0;
        camara = GameObject.Find("Main Camera");
        parejaCorrecta = camara.GetComponent<AudioSource>();

    }
    public void iniciarCategoria()
    {
        //Por banderas pequeño -> Español(andorra,argentina (2,8)) Arabes(Argelia,arabiasaudita(4,3)) Frios(alemania,canada(1,0))
        //Por banderas mediano -> Arabes(Argelia,arabiasaudita(4,3)) EuropaCentro(Belgica,alemania(7,1)) Nieve(canada,andorra(2,0)) Selva(Bolivia,Brasil((8,9)) Planos(Argentina,australia(5,6))
        //Banderas grandes  -> Arabes(argelia, arabiasaudita, y 2 mas) Europeos(losdeuropa) EuropaLatina Española y paises grandes(Brasil, australia, china, Canada)
        List<String> c1 = new List<String> { "domesticos", "sabana", "bosque" };
        List<String> c2 = new List<String> { "domesticos", "sabana", "salvaje", "bosque", "arbol" };
        List<String> c3 = new List<String> { "domesticos", "sabana", "pradera", "bosque" };
        List<String> c4 = new List<String> { "hispanohablantes", "arabes", "frios" };
        List<String> c5 = new List<String> { "arabes", "europa centro", "nieve", "selva", "planos" };
        List<String> c6 = new List<String> { "arabes", "europeos", "latino español", "grandes" };
        List<String> c7 = new List<String> { "seguridad pública", "alimentación", "profesores"};
        List<String> c8 = new List<String> { "seguridad pública", "alimentación", "profesores", "ingenieros", "noticias" };
        List<String> c9 = new List<String> { "seguridad pública", "alimentación", "profesores", "ingenieros" };
        switch (GameProperties.baraja) {
            case "animal":
                switch (GameProperties.tamaño)
                {
                    case "pequeño":
                        categorias.AddRange(c1);
                        break;
                    case "mediano":
                        categorias.AddRange(c2);
                        break;
                    case "grande":
                        categorias.AddRange(c3);
                        categoria.gameObject.transform.localPosition = new Vector3(250, 237.3f, 0);
                        break;
                }
                break;
            case "bandera":
                switch (GameProperties.tamaño)
                {
                    case "pequeño":
                        categorias.AddRange(c4);
                        break;
                    case "mediano":
                        categorias.AddRange(c5);
                        break;
                    case "grande":
                        categorias.AddRange(c6);
                        categoria.gameObject.transform.localPosition = new Vector3(250, 237.3f, 0);
                        break;
                }
                break;
            case "profesion":
                switch (GameProperties.tamaño)
                {
                    case "pequeño":
                        categorias.AddRange(c7);
                        break;
                    case "mediano":
                        categorias.AddRange(c8);
                        break;
                    case "grande":
                        categorias.AddRange(c9);
                        categoria.gameObject.transform.localPosition = new Vector3(250, 237.3f, 0);
                        break;
                }
                break;
        }
        iterator = ObtenerIterator();
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
        return iterator.Aleatorio();
    }
    public void enCategoria()
    {
        switch (GameProperties.tamaño) 
        {
            case "pequeño":
                if (pairsCategoria2 == 2)
                {
                    categoria.text = elegirCategoria();
                    pairsCategoria2 = 0;
                }
                break;
            case "mediano":
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
        switch (GameProperties.baraja)
        {
            case "animal":
                switch (GameProperties.tamaño)
                {
                    case "pequeño":
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
                        break;
                    case "mediano":
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
                            case string aux when aux == "salvaje":
                                return carta.PairNumber == 6 || carta.PairNumber == 8;
                                break;
                            case string aux when aux == "arbol":
                                return carta.PairNumber == 7 || carta.PairNumber == 9;
                                break;
                            default:
                                return false;
                                break;
                        }
                        break;
                    case "grande":
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
                            case string aux when aux == "grandes":
                                return carta.PairNumber == 3 || carta.PairNumber == 7 || carta.PairNumber == 9 || carta.PairNumber == 14;
                                break;
                            default:
                                return false;
                                break;
                        }
                        break;
                    default:
                        return false;
                        break;
                }
            break;
            case "bandera":
                switch (GameProperties.tamaño)
                {
                    case "pequeño":
                        switch (aux)
                        {
                            case string aux when aux == "hispanohablantes":
                                return carta.PairNumber == 2 || carta.PairNumber == 5;
                                break;
                            case string aux when aux == "arabes":
                                return carta.PairNumber == 4 || carta.PairNumber == 3;
                                break;
                            case string aux when aux == "frios":
                                return carta.PairNumber == 1 || carta.PairNumber == 0;
                                break;
                            default:
                                return false;
                                break;
                        }
                        break;
                    case "mediano":
                        switch (aux)
                        {
                            case string aux when aux == "arabes":
                                return carta.PairNumber == 4 || carta.PairNumber == 3;
                                break;
                            case string aux when aux == "europa centro":
                                return carta.PairNumber == 7 || carta.PairNumber == 1;
                                break;
                            case string aux when aux == "nieve":
                                return carta.PairNumber == 2 || carta.PairNumber == 0;
                                break;
                            case string aux when aux == "selva":
                                return carta.PairNumber == 8 || carta.PairNumber == 9;
                                break;
                            case string aux when aux == "planos":
                                return carta.PairNumber == 5 || carta.PairNumber == 6;
                                break;
                            default:
                                return false;
                                break;
                        }
                        break;
                    case "grande":
                        switch (aux)
                        {
                            case string aux when aux == "arabes":
                                return carta.PairNumber == 4 || carta.PairNumber == 3 || carta.PairNumber == 14 || carta.PairNumber == 15;
                                break;
                            case string aux when aux == "europeos":
                                return carta.PairNumber == 1 || carta.PairNumber == 2 || carta.PairNumber == 7 || carta.PairNumber == 13;
                                break;
                            case string aux when aux == "latino español":
                                return carta.PairNumber == 5 || carta.PairNumber == 8 || carta.PairNumber == 10 || carta.PairNumber == 12;
                                break;
                            case string aux when aux == "grandes":
                                return carta.PairNumber == 9 || carta.PairNumber == 11 || carta.PairNumber == 6 || carta.PairNumber == 0;
                                break;
                            default:
                                return false;
                                break;
                        }
                        break;
                    default:
                        return false;
                        break;
                }
            case "profesion":
                switch (GameProperties.tamaño)
                {
                    case "pequeño":
                        switch (aux)
                        {
                            case string aux when aux == "seguridad pública":
                                return carta.PairNumber == 0 || carta.PairNumber == 1;
                                break;
                            case string aux when aux == "alimentación":
                                return carta.PairNumber == 2 || carta.PairNumber == 3;
                                break;
                            case string aux when aux == "profesores":
                                return carta.PairNumber == 4 || carta.PairNumber == 5;
                                break;
                            default:
                                return false;
                                break;
                        }
                        break;
                    case "mediano":
                        switch (aux)
                        {
                            case string aux when aux == "seguridad pública":
                                return carta.PairNumber == 0 || carta.PairNumber == 1;
                                break;
                            case string aux when aux == "alimentación":
                                return carta.PairNumber == 2 || carta.PairNumber == 3;
                                break;
                            case string aux when aux == "profesores":
                                return carta.PairNumber == 4 || carta.PairNumber == 5;
                                break;
                            case string aux when aux == "ingenieros":
                                return carta.PairNumber == 6 || carta.PairNumber == 8;
                                break;
                            case string aux when aux == "noticias":
                                return carta.PairNumber == 7 || carta.PairNumber == 9;
                                break;
                            default:
                                return false;
                                break;
                        }
                        break;
                    case "grande":
                        switch (aux)
                        {
                            case string aux when aux == "seguridad pública":
                                return carta.PairNumber == 0 || carta.PairNumber == 1 || carta.PairNumber == 7 || carta.PairNumber == 13;
                                break;
                            case string aux when aux == "alimentación":
                                return carta.PairNumber == 2 || carta.PairNumber == 3 || carta.PairNumber == 11 || carta.PairNumber == 15;
                                break;
                            case string aux when aux == "profesores":
                                return carta.PairNumber == 4 || carta.PairNumber == 5 || carta.PairNumber == 14 || carta.PairNumber == 9;
                                break;
                            case string aux when aux == "ingenieros":
                                return carta.PairNumber == 6 || carta.PairNumber == 8 || carta.PairNumber == 10 || carta.PairNumber == 12;
                            default:
                                return false;
                                break;
                        }
                        break;
                    default:
                        return false;
                        break;
                }
                break;
                default:
                   return false;
                   break;

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

    public IIteratorCategoria ObtenerIterator()
    {
        return new IteratorCategoria(categorias);
    }
}
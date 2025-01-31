﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameProperties
{
    public Vector3 positionTablero;
    public Vector3 cronoPosition;
    public Vector3 posicionPuntuacion;
    public float time;
    public Vector3[] cardsPositions;
    public IPuntuacion puntuacion;
    public int level;
    public bool isLevel = false;
    public bool vNiño = false;
    public string baraja = "animal";
    public string tamaño = "pequeño";
    public string tipoPartida = "PartidaEstandar";
    public int desafios = 0;
    public bool trios = false;
    public bool dinamico = false;

    private static GameProperties instance = new GameProperties();
    public static GameProperties getInstance()
    {
        return instance;
    }

    public void SetProperties(int lv, Vector3[] posCard, Vector3 posTablero, Vector3 posCrono, Vector3 posPuntuacion,
                                     IPuntuacion pnt , string brja, bool vNiño) {
        cardsPositions = posCard; level = lv; puntuacion = pnt;
        cronoPosition = posCrono; posicionPuntuacion = posPuntuacion; 
        positionTablero = posTablero; baraja = brja; time = 60f;
        isLevel = true; GameProperties.getInstance().vNiño = vNiño;
    }   

    public void PresetSettings(string tamaño) {
        if (isLevel) return;
        GameProperties.getInstance().tamaño = tamaño;
        GameProperties.getInstance().level = -1;

        switch (tamaño)
        {
            case "pequeño":
                cardsPositions = new Vector3[12];
                positionTablero = new Vector3(7.5f, 0, 5);

                cardsPositions[0] = new Vector3(11, 0, 8.75f); cardsPositions[1] = new Vector3(10.355f, 0, 7.25f);
                cardsPositions[2] = new Vector3(11.625f, 0, 7.25f); cardsPositions[3] = new Vector3(9.75f, 0, 5.75f);
                cardsPositions[4] = new Vector3(11, 0, 5.75f); cardsPositions[5] = new Vector3(12.25f, 0, 5.75f);
                cardsPositions[6] = new Vector3(9.75f, 0, 4.25f); cardsPositions[7] = new Vector3(11, 0, 4.25f);
                cardsPositions[8] = new Vector3(12.25f, 0, 4.25f); cardsPositions[9] = new Vector3(10.355f, 0, 2.75f);
                cardsPositions[10] = new Vector3(11.625f, 0, 2.75f); cardsPositions[11] = new Vector3(11, 0, 1.25f);

                time = 60f;
                cronoPosition = new Vector3(-118f, 140f, 0);
                posicionPuntuacion = new Vector3(-106, 87, 0);
                puntuacion = new PuntuacionFacil();
                break;

            case "mediano":
                cardsPositions = new Vector3[20];
                positionTablero = new Vector3(7.5f, 0, 5);

                cardsPositions[0] = new Vector3(8.2145f, 0, 4.166667f); cardsPositions[1] = new Vector3(9.643f, 0, 4.166667f);
                cardsPositions[2] = new Vector3(11.0715f, 0, 4.166667f); cardsPositions[3] = new Vector3(12.5f, 0, 4.166667f);

                cardsPositions[4] = new Vector3(8.2145f, 0, 2.5f); cardsPositions[5] = new Vector3(9.643f, 0, 2.5f);
                cardsPositions[6] = new Vector3(11.0715f, 0, 2.5f); cardsPositions[7] = new Vector3(12.5f, 0, 2.5f);
                cardsPositions[8] = new Vector3(8.2145f, 0, 5.8333f); cardsPositions[9] = new Vector3(9.643f, 0, 5.8333f);
                cardsPositions[10] = new Vector3(11.0715f, 0, 5.8333f); cardsPositions[11] = new Vector3(12.5f, 0, 5.8333f);

                cardsPositions[12] = new Vector3(6.786f, 0, 2.5f); cardsPositions[13] = new Vector3(6.786f, 0, 4.166667f);
                cardsPositions[14] = new Vector3(6.786f, 0, 5.8333f); cardsPositions[15] = new Vector3(6.786f, 0, 7.5f);
                cardsPositions[16] = new Vector3(8.2145f, 0, 7.5f); cardsPositions[17] = new Vector3(9.643f, 0, 7.5f);
                cardsPositions[18] = new Vector3(11.0715f, 0, 7.5f); cardsPositions[19] = new Vector3(12.5f, 0, 7.5f);

                time = 90f;
                cronoPosition = new Vector3(-118f, 140f, 0);
                posicionPuntuacion = new Vector3(-106, 87, 0);
                puntuacion = new PuntuacionNormal();
                break;

            case "grande":
                cardsPositions = new Vector3[32];
                positionTablero = new Vector3(7.5f, 0, 5);

                cardsPositions[0] = new Vector3(2.5f, 0, 2.5f); cardsPositions[1] = new Vector3(3.929f, 0, 2.5f);
                cardsPositions[2] = new Vector3(5.3575f, 0, 2.5f); cardsPositions[3] = new Vector3(6.786f, 0, 2.5f);
                cardsPositions[4] = new Vector3(8.2145f, 0, 2.5f); cardsPositions[5] = new Vector3(9.643f, 0, 2.5f);
                cardsPositions[6] = new Vector3(11.0715f, 0, 2.5f); cardsPositions[7] = new Vector3(12.5f, 0, 2.5f);

                cardsPositions[8] = new Vector3(2.5f, 0, 4.166667f); cardsPositions[9] = new Vector3(3.929f, 0, 4.166667f);
                cardsPositions[10] = new Vector3(5.3575f, 0, 4.166667f); cardsPositions[11] = new Vector3(6.786f, 0, 4.166667f);
                cardsPositions[12] = new Vector3(8.2145f, 0, 4.166667f); cardsPositions[13] = new Vector3(9.643f, 0, 4.166667f);
                cardsPositions[14] = new Vector3(11.0715f, 0, 4.166667f); cardsPositions[15] = new Vector3(12.5f, 0, 4.166667f);

                cardsPositions[16] = new Vector3(2.5f, 0, 5.8333f); cardsPositions[17] = new Vector3(3.929f, 0, 5.8333f);
                cardsPositions[18] = new Vector3(5.3575f, 0, 5.8333f); cardsPositions[19] = new Vector3(6.786f, 0, 5.8333f);
                cardsPositions[20] = new Vector3(8.2145f, 0, 5.8333f); cardsPositions[21] = new Vector3(9.643f, 0, 5.8333f);
                cardsPositions[22] = new Vector3(11.0715f, 0, 5.8333f); cardsPositions[23] = new Vector3(12.5f, 0, 5.8333f);

                cardsPositions[24] = new Vector3(2.5f, 0, 7.5f); cardsPositions[25] = new Vector3(3.929f, 0, 7.5f);
                cardsPositions[26] = new Vector3(5.3575f, 0, 7.5f); cardsPositions[27] = new Vector3(6.786f, 0, 7.5f);
                cardsPositions[28] = new Vector3(8.2145f, 0, 7.5f); cardsPositions[29] = new Vector3(9.643f, 0, 7.5f);
                cardsPositions[30] = new Vector3(11.0715f, 0, 7.5f); cardsPositions[31] = new Vector3(12.5f, 0, 7.5f);
                puntuacion = new PuntuacionDificil();
                time = 160f;
                cronoPosition = new Vector3(-130f, 233.7f, 0);
                posicionPuntuacion = new Vector3(57, 233.7f, 0);
                break;

            case "multLocal":
                cardsPositions = new Vector3[32];
                positionTablero = new Vector3(7.5f, 0, 5);

                cardsPositions[0] = new Vector3(2.5f, 0, 2.5f); cardsPositions[1] = new Vector3(3.929f, 0, 2.5f);
                cardsPositions[2] = new Vector3(5.3575f, 0, 2.5f); cardsPositions[3] = new Vector3(6.786f, 0, 2.5f);
                cardsPositions[4] = new Vector3(8.2145f, 0, 2.5f); cardsPositions[5] = new Vector3(9.643f, 0, 2.5f);
                cardsPositions[6] = new Vector3(11.0715f, 0, 2.5f); cardsPositions[7] = new Vector3(12.5f, 0, 2.5f);

                cardsPositions[8] = new Vector3(2.5f, 0, 4.166667f); cardsPositions[9] = new Vector3(3.929f, 0, 4.166667f);
                cardsPositions[10] = new Vector3(5.3575f, 0, 4.166667f); cardsPositions[11] = new Vector3(6.786f, 0, 4.166667f);
                cardsPositions[12] = new Vector3(8.2145f, 0, 4.166667f); cardsPositions[13] = new Vector3(9.643f, 0, 4.166667f);
                cardsPositions[14] = new Vector3(11.0715f, 0, 4.166667f); cardsPositions[15] = new Vector3(12.5f, 0, 4.166667f);

                cardsPositions[16] = new Vector3(2.5f, 0, 5.8333f); cardsPositions[17] = new Vector3(3.929f, 0, 5.8333f);
                cardsPositions[18] = new Vector3(5.3575f, 0, 5.8333f); cardsPositions[19] = new Vector3(6.786f, 0, 5.8333f);
                cardsPositions[20] = new Vector3(8.2145f, 0, 5.8333f); cardsPositions[21] = new Vector3(9.643f, 0, 5.8333f);
                cardsPositions[22] = new Vector3(11.0715f, 0, 5.8333f); cardsPositions[23] = new Vector3(12.5f, 0, 5.8333f);

                cardsPositions[24] = new Vector3(2.5f, 0, 7.5f); cardsPositions[25] = new Vector3(3.929f, 0, 7.5f);
                cardsPositions[26] = new Vector3(5.3575f, 0, 7.5f); cardsPositions[27] = new Vector3(6.786f, 0, 7.5f);
                cardsPositions[28] = new Vector3(8.2145f, 0, 7.5f); cardsPositions[29] = new Vector3(9.643f, 0, 7.5f);
                cardsPositions[30] = new Vector3(11.0715f, 0, 7.5f); cardsPositions[31] = new Vector3(12.5f, 0, 7.5f);

                time = 120f;
                cronoPosition = new Vector3(90, 227.3f, 0);
                posicionPuntuacion = new Vector3(-106, 87, 0);
                puntuacion = new PuntuacionMultijugador();
                break;

            case "trios":
                cardsPositions = new Vector3[18];
                positionTablero = new Vector3(7.5f, 0, 5);

                cardsPositions[0] = new Vector3(8.2145f, 0, 3.5f); cardsPositions[1] = new Vector3(9.643f, 0, 3.5f);
                cardsPositions[2] = new Vector3(11.0715f, 0, 3.5f); cardsPositions[3] = new Vector3(12.5f, 0, 3.5f);

                cardsPositions[4] = new Vector3(8.2145f, 0, 5.166667f); cardsPositions[5] = new Vector3(9.643f, 0, 5.166667f);
                cardsPositions[6] = new Vector3(11.0715f, 0, 5.166667f); cardsPositions[7] = new Vector3(12.5f, 0, 5.166667f);

                cardsPositions[8] = new Vector3(8.2145f, 0, 6.8333f); cardsPositions[9] = new Vector3(9.643f, 0, 6.8333f);
                cardsPositions[10] = new Vector3(11.0715f, 0, 6.8333f); cardsPositions[11] = new Vector3(12.5f, 0, 6.8333f);

                cardsPositions[12] = new Vector3(8.2145f, 0, 8.5f); cardsPositions[13] = new Vector3(9.643f, 0, 8.5f);
                cardsPositions[14] = new Vector3(11.0715f, 0, 8.5f); cardsPositions[15] = new Vector3(12.5f, 0, 8.5f);

                cardsPositions[16] = new Vector3(9.643f, 0, 1.9f); cardsPositions[17] = new Vector3(11.0715f, 0, 1.9f);
                time = 60f;
                cronoPosition = new Vector3(-118f, 140f, 0);
                posicionPuntuacion = new Vector3(-106, 87, 0);
                puntuacion = new PuntuacionNormal();
                break;

            case "dinamico":
                cardsPositions = new Vector3[20];
                positionTablero = new Vector3(7.5f, 0, 5);

                cardsPositions[0] = new Vector3(8.2145f, 0, 4.166667f); cardsPositions[1] = new Vector3(9.643f, 0, 4.166667f);
                cardsPositions[2] = new Vector3(11.0715f, 0, 4.166667f); cardsPositions[3] = new Vector3(12.5f, 0, 4.166667f);

                cardsPositions[4] = new Vector3(8.2145f, 0, 2.5f); cardsPositions[5] = new Vector3(9.643f, 0, 2.5f);
                cardsPositions[6] = new Vector3(11.0715f, 0, 2.5f); cardsPositions[7] = new Vector3(12.5f, 0, 2.5f);
                cardsPositions[8] = new Vector3(8.2145f, 0, 5.8333f); cardsPositions[9] = new Vector3(9.643f, 0, 5.8333f);
                cardsPositions[10] = new Vector3(11.0715f, 0, 5.8333f); cardsPositions[11] = new Vector3(12.5f, 0, 5.8333f);

                cardsPositions[12] = new Vector3(6.786f, 0, 2.5f); cardsPositions[13] = new Vector3(6.786f, 0, 4.166667f);
                cardsPositions[14] = new Vector3(6.786f, 0, 5.8333f); cardsPositions[15] = new Vector3(6.786f, 0, 7.5f);
                cardsPositions[16] = new Vector3(8.2145f, 0, 7.5f); cardsPositions[17] = new Vector3(9.643f, 0, 7.5f);
                cardsPositions[18] = new Vector3(11.0715f, 0, 7.5f); cardsPositions[19] = new Vector3(12.5f, 0, 7.5f);

                time = 135f;
                cronoPosition = new Vector3(-118f, 140f, 0);
                posicionPuntuacion = new Vector3(-106, 87, 0);
                puntuacion = new PuntuacionDinamica();
                break;
        }
    }

    public void Reset() {
        baraja = "animal";
        tamaño = "pequeño";
        tipoPartida = "PartidaEstandar";
        isLevel = false;
        vNiño = false;
    }

    public int DesafioPasado()
    {
        return desafios++;
    }
}

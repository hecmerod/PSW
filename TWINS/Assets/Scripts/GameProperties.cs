using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameProperties
{
    public static Vector3 positionTablero;
    public static Vector3 cronoPosition;
    public static Vector3 posicionPuntuacion;
    public static float time;
    public static Vector3[] cardsPositions;
    public static IPuntuacion puntuacion;
    public static int level;
    public static string baraja;
    public static string tamaño;
    public static bool reload;

    public static void SetProperties(int lv, Vector3[] posCard, Vector3 posTablero, Vector3 posCrono,
                                     PuntuacionFacil pntFacil) {
        cardsPositions = posCard; level = lv; puntuacion = pntFacil;
        cronoPosition = posCrono; positionTablero = posTablero;
    }   

    public static void PresetSettings(string tamaño)
    {
        GameProperties.tamaño = tamaño;
        GameProperties.level = -1;

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

            /*case "mediano":
                positionTablero = new Vector3();
                puntuacionNormal = new PuntuacionNormal();
                contexto.TipoPuntuacion = puntuacionNormal;
                break;*/
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
                cronoPosition = new Vector3(-170f, 233.7f, 0);
                posicionPuntuacion = new Vector3(-23, 233.7f, 0);
                break;
        }
    }
}

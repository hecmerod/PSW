using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elegidas : MonoBehaviour
{
    public GameObject[] posiciones;
    private bool[] posOcupadas = new bool[15];

    public GameObject ReturnPos() {
        for (int i = 0; i < 15; i++) {
            if (!posOcupadas[i]) {
                posOcupadas[i] = true;
                return posiciones[i];
            }
        }
        return null;
    }

    public void LiberatePos(GameObject pos) {
        int i = 0;
        while (pos != posiciones[i]) i++;

        posOcupadas[i] = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elegidas : MonoBehaviour
{
    public Vector3[] posiciones = new Vector3[15];
    private bool[] posOcupadas = new bool[15];



    public Vector3 ReturnPos() {
        for (int i = 0; i < 15; i++) {
            if (!posOcupadas[i]) {
                posOcupadas[i] = true;
                return posiciones[i];
            }
        }
        return Vector3.zero;
    }

    public void LiberatePos(Vector3 pos) {
        int i = 0;
        while (!(posiciones[i].x == pos.x && posiciones[i].z == pos.z)) i++;

        posOcupadas[i] = false;
    }
}

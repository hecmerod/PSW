using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tablero : MonoBehaviour
{
    private Vector3[] positionCards;

    private GameObject marco;

    private Baraja baraja;
    private ArrayList cards = new ArrayList();
    private PartidaEstandar partida;

    public void InitializeValues(PartidaEstandar partida, Vector3[] positionCards) {
        this.partida = partida;
        this.positionCards = positionCards;
    }
    public void Start() {
        baraja = CreadorBaraja.CrearBaraja(partida.Tematica, this);
        marco = Resources.Load("Prefabs/Marco") as GameObject;
        InstantiateMarcos();
    }

    public void InstantiateMarcos() {
        GameObject auxMarco;
        int i = 1;
        foreach (Vector3 position in positionCards) {
            auxMarco = GameObject.Instantiate(marco, position, Quaternion.identity);
            auxMarco.transform.SetParent(partida.Tablero.transform, true);
            auxMarco.name = "Marco" + i++;
        }
    }

    public Vector3[] PositionCards { get => positionCards; set => positionCards = value; }
    public Baraja Baraja { get => baraja; set => baraja = value; }
}

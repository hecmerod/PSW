using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tablero : MonoBehaviour
{
    private Vector3[] positionCards;

    private GameObject marco;

    private Baraja baraja;
    private ArrayList cards = new ArrayList();
    private Partida partida;

    public void InitializeValues(Partida partida, Vector3[] positionCards) {
        this.partida = partida;
        this.positionCards = positionCards;
    }
    public void Start() {
        baraja = new Baraja(this, partida.Tematica);
        marco = Resources.Load("Prefabs/Marco") as GameObject;
    }

    public Vector3[] PositionCards { get => positionCards; set => positionCards = value; }
    public Baraja Baraja { get => baraja; set => baraja = value; }
}

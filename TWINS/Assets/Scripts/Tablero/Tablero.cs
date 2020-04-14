using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tablero : MonoBehaviour
{
    [SerializeField] private Vector3[] positionCards;

    
    private Baraja baraja;
    private ArrayList cards = new ArrayList();
    private PartidaEstandar partida;
    private string tematica;

    public void InitializeValues(PartidaEstandar partida, Vector3[] positionCards, string tematica) {
        this.partida = partida;
        this.positionCards = positionCards;
        this.tematica = tematica;
    }
    public void Start() {
        baraja = CreadorBaraja.CrearBaraja(tematica, this);
    }

    public Vector3[] PositionCards { get => positionCards; set => positionCards = value; }
    public Baraja Baraja { get => baraja; set => baraja = value; }
}

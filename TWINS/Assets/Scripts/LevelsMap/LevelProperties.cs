using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelProperties : MonoBehaviour
{
    private Vector3[] cardsPositions;
    private PuntuacionFacil puntuacionFacil;
    private int level;

    private void Awake() { DontDestroyOnLoad(this); }

    public void SetProperties(int level, Vector3[] cardsPositions, PuntuacionFacil puntuacionFacil) {
        //contador
        this.cardsPositions = cardsPositions; this.puntuacionFacil = puntuacionFacil;
        this.Level = level;
    }

    public Vector3[] CardsPositions { get => cardsPositions; set => cardsPositions = value; }
    public PuntuacionFacil PuntuacionFacil { get => puntuacionFacil; set => puntuacionFacil = value; }
    public int Level { get => level; set => level = value; }
}

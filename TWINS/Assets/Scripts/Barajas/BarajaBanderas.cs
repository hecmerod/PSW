using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarajaBanderas : Baraja
{
    public BarajaBanderas(Tablero tablero) : base(tablero)
    {

    }

    public override void SetCardValues(Card card)
    {
        card.Number = cards.Count;
        card.Partida = partida;

        int randomNumber;
        do randomNumber = Random.Range(0, pairs);
        while (pairsCounter[randomNumber] == 2);
        pairsCounter[randomNumber]++;

        card.PairNumber = randomNumber;
        card.Cara.material = Resources.Load<Material>("Barajas/Banderas_Baraja/Materials/" + randomNumber);
        card.Dorso.material = Resources.Load<Material>("Barajas/Dorsos/Materials/DORSO_ROJO");
    }
}

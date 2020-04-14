using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Baraja
{
    public abstract void CreateCards();

    public abstract void SetCardValues(Card card);
    public abstract Card GetCard(int n);
}

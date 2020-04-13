using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Partida : MonoBehaviour
{
    public abstract void Awake();
    public abstract void Update();
    public abstract void CheckPair(int n);
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IPuntuacion : MonoBehaviour
{
    public abstract int SumarPuntos();
    public abstract int RestarPuntos();
    public abstract void HaVueltoACero();

}

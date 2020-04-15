using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class IAnimacionStrategy : MonoBehaviour
{
    public abstract void MostrarAnimacion(int tiempoJugado);
}

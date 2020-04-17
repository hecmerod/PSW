using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tiempo : MonoBehaviour
{
    private static Text miTexto;

    void Start()
    {
        miTexto = GetComponent<Text>();
    }

    public static void SetTiempo(float tiempo)
    {
        miTexto.text = ((int)tiempo).ToString();
    }
}

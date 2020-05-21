using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Ranking : MonoBehaviour
{
    public Text Jugador1Puntos;
    public Text Jugador1;
    public Text Jugador2Puntos;
    public Text Jugador2;
    public Text Jugador3Puntos;
    public Text Jugador3;

    private int first, second, third;
    public void Start()
    {
        cargarMaximos();
    }
    public void cargarMaximos()
    {
        first = second = third = -50;
        for(int i = 0; i < DBManager.scores.Length; i++)
        {
            if (DBManager.scores[i] > first)
            {
                third = second;
                second = first;
                first = DBManager.scores[i];
            }
            else if (DBManager.scores[i] > 0)
            {
                third = second;
                second = DBManager.scores[i];
            }
            else if(DBManager.scores[i] > third)
            {
                third = DBManager.scores[i];
            }
        }
        Jugador1Puntos.text = first.ToString();
        Jugador2Puntos.text = second.ToString();
        Jugador3Puntos.text = third.ToString();
        Debug.Log(first);
        Debug.Log(second);
        Debug.Log(third);
    }
}

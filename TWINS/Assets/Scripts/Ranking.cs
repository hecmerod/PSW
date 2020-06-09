using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;

public class Ranking : MonoBehaviour
{
    public Text Jugador1Puntos;
    public Text Jugador1;
    public Text Jugador2Puntos;
    public Text Jugador2;
    public Text Jugador3Puntos;
    public Text Jugador3;

    public static int first, second, third;
    public void Start()
    {
        cargarMaximos();
        StartCoroutine(DBManager.getInstance().LoadTopNombres());
        cargarNombres();
    }
    private void cargarMaximos()
    {
        first = second = third = -50;
        for(int i = 0; i < DBManager.getInstance().scores.Length; i++)
        {
            if (DBManager.getInstance().scores[i] > first)
            {
                third = second;
                second = first;
                first = DBManager.getInstance().scores[i];
            }
            else if (DBManager.getInstance().scores[i] > 0)
            {
                third = second;
                second = DBManager.getInstance().scores[i];
            }
            else if(DBManager.getInstance().scores[i] > third)
            {
                third = DBManager.getInstance().scores[i];
            }
        }
        Jugador1Puntos.text = first.ToString();
        Jugador2Puntos.text = second.ToString();
        Jugador3Puntos.text = third.ToString();
    }
    async private void cargarNombres()
    {
        await Task.Delay(200);
        Jugador1.text = DBManager.getInstance().topNames[0];
        Jugador2.text = DBManager.getInstance().topNames[1];
        Jugador3.text = DBManager.getInstance().topNames[2];
    }
    public void volver()
    {
        SceneManager.LoadScene("PantallaInicio");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public static class DBManager
{
    public static string username;
    public static int puntuacionTotal;
    public static int puntuacionMax;
    public static int partidasJugadas;
    public static int partidasGanadas;
    public static int nivel;

    public static PantallaInicio pantallaInicio;

    public static bool LoggedIn { get { return username != null; } }
    public static void LogOut() { username = null; }

    public static IEnumerator LoginIn()
    {
        WWWForm form = new WWWForm();
        form.AddField("name", pantallaInicio.LoginNombre.text);
        form.AddField("password", pantallaInicio.LoginContrasenya.text);
        WWW www = new WWW("https://twinsproject2.000webhostapp.com/login.php", form);
        yield return www;
        if (www.text[0] == '0')
        {
            DBManager.username = pantallaInicio.LoginNombre.text;
            string[] webResults = www.text.Split('\t');
            DBManager.puntuacionTotal = int.Parse(webResults[1]);
            DBManager.partidasJugadas = int.Parse(webResults[2]);
            DBManager.partidasGanadas = int.Parse(webResults[3]);
            DBManager.nivel = int.Parse(webResults[4]);
            SceneManager.LoadScene("PantallaInicio");

            /*Debug.Log("Partidas jugadas: " + DBManager.partidasJugadas);
            Debug.Log("Partidas ganadas: " + DBManager.partidasGanadas);
            Debug.Log("score: " + DBManager.puntuacionTotal);
            Debug.Log("nivel: " + DBManager.nivel);*/
        }
        else
        {
            Debug.Log("User login failed. Error #" + www.text);
        }
    }
    public static IEnumerator Registerment()
    {
        WWWForm form = new WWWForm();
        form.AddField("name", pantallaInicio.RegisterNombre.text);
        form.AddField("password", pantallaInicio.RegisterContrasenya.text);
        WWW www = new WWW("https://twinsproject2.000webhostapp.com/register.php", form);
        yield return www;
        if (www.text == "0")
        {
            Debug.Log("Usuer created succesfully.");
            SceneManager.LoadScene("PantallaInicio");
        }
        else
        {
            Debug.Log("User creation failed. Error #" + www.text);
        }

    }
    public static IEnumerator SavePlayerData() {
        if (LoggedIn) {
            WWWForm form = new WWWForm();
            form.AddField("name", DBManager.username);
            form.AddField("score", DBManager.puntuacionTotal);
            //form.AddField("maxscore", DBManager.puntuacionMax);
            form.AddField("gamesplayed", DBManager.partidasJugadas);
            form.AddField("gameswon", DBManager.partidasGanadas);
            form.AddField("nivel", DBManager.nivel);
            WWW www = new WWW("https://twinsproject2.000webhostapp.com/savedata.php", form);
            yield return www;
            if (www.text == "0")
            {
                Debug.Log("Data saved");
            }
            else
            {
                Debug.Log("Algo ha pasao");
            }
        }
    }
    public static void UpdaterData(int puntos)
    {
        if (DBManager.LoggedIn)
        {
            DBManager.partidasJugadas++;
            DBManager.puntuacionTotal +=  puntos;
        }
    }
}

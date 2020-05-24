﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public static class DBManager
{
    public static string username;
    public static int puntuacionTotal;
    public static int partidasJugadas;
    public static int partidasGanadas;
    public static int nivel;
    public static int nivelniños;
    public static int[] scores = new int[1000];
    public static string[] topNames = new string[3];

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
            DBManager.nivelniños = int.Parse(webResults[5]);
            SceneManager.LoadScene("PantallaInicio");

            /*Debug.Log("Partidas jugadas: " + DBManager.partidasJugadas);
            Debug.Log("Partidas ganadas: " + DBManager.partidasGanadas);
            Debug.Log("score: " + DBManager.puntuacionTotal);
            Debug.Log("nivel: " + DBManager.nivel);*/
            Debug.Log("nivelniños" + nivelniños);
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
            form.AddField("nivelniños", DBManager.nivelniños);
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
    public static IEnumerator LoadScoresData()
    {
        WWWForm form = new WWWForm();
        WWW www = new WWW("https://twinsproject2.000webhostapp.com/loadranking.php", form);
        yield return www;
        string[] webResults = www.text.Split('\t');
        for(int i = 0; i < webResults.Length; i++)
        {
            scores[i] = int.Parse(webResults[i]);
            //Debug.Log(scores[i]);
        }
        //Debug.Log("Data succesfully loaded");
    }
    public static IEnumerator LoadTopNombres()
    {
        WWWForm form = new WWWForm();
        form.AddField("primero", Ranking.first);
        form.AddField("segundo", Ranking.second);
        form.AddField("tercero", Ranking.third);
        WWW www = new WWW("https://twinsproject2.000webhostapp.com/loadnombresranking.php", form);
        yield return www;
        string[] webResults = www.text.Split('\t');
        topNames[0] = webResults[0];
        topNames[1] = webResults[1];
        topNames[2] = webResults[2];
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

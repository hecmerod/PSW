using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class DBManager
{
    public string username;
    public int puntuacionTotal;
    public int partidasJugadas;
    public int partidasGanadas;
    public int nivel;
    public int nivelniños;
    public int[] scores = new int[1000];
    public string[] topNames = new string[3];

    public PantallaInicio pantallaInicio;

    public  bool LoggedIn { get { return username != null; } }
    public  void LogOut() { username = null; }

    private static DBManager instance = new DBManager();
    public static DBManager getInstance()
    {
        return instance;
    }

    public IEnumerator LoginIn()
    {
        WWWForm form = new WWWForm();
        form.AddField("name", pantallaInicio.LoginNombre.text);
        form.AddField("password", pantallaInicio.LoginContrasenya.text);
        WWW www = new WWW("https://twinsproject2.000webhostapp.com/login.php", form);
        yield return www;
        if (www.text[0] == '0')
        {
            DBManager.getInstance().username = pantallaInicio.LoginNombre.text;
            string[] webResults = www.text.Split('\t');
            DBManager.getInstance().puntuacionTotal = int.Parse(webResults[1]);
            DBManager.getInstance().partidasJugadas = int.Parse(webResults[2]);
            DBManager.getInstance().partidasGanadas = int.Parse(webResults[3]);
            DBManager.getInstance().nivel = int.Parse(webResults[4]);
            DBManager.getInstance().nivelniños = int.Parse(webResults[5]);
            SceneManager.LoadScene("PantallaInicio");
        }
        else
        {
            Debug.Log("User login failed. Error #" + www.text);
        }
    }
    public IEnumerator Registerment()
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
    public IEnumerator SavePlayerData() {
        if (LoggedIn) {
            WWWForm form = new WWWForm();
            form.AddField("name", DBManager.getInstance().username);
            form.AddField("score", DBManager.getInstance().puntuacionTotal);
            form.AddField("nivelniños", DBManager.getInstance().nivelniños);
            form.AddField("gamesplayed", DBManager.getInstance().partidasJugadas);
            form.AddField("gameswon", DBManager.getInstance().partidasGanadas);
            form.AddField("nivel", DBManager.getInstance().nivel);
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
    public IEnumerator LoadScoresData()
    {
        WWWForm form = new WWWForm();
        WWW www = new WWW("https://twinsproject2.000webhostapp.com/loadranking.php", form);
        yield return www;
        string[] webResults = www.text.Split('\t');
        for(int i = 0; i < webResults.Length; i++)
        {
            scores[i] = int.Parse(webResults[i]); 
        }
    }
    public IEnumerator LoadTopNombres()
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
    public void UpdaterData(int puntos)
    {
        if (DBManager.getInstance().LoggedIn)
        {
            DBManager.getInstance().partidasJugadas++;
            DBManager.getInstance().puntuacionTotal +=  puntos;
        }
    }
    
}

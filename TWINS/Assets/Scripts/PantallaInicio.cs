using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PantallaInicio : MonoBehaviour
{
    public GameObject Login;
    public GameObject Register;
    public InputField LoginContrasenya;
    public InputField LoginNombre;
    public InputField RegisterNombre;
    public InputField RegisterContrasenya;
    public InputField RegisterContrasenya2;
    public Button registrarBoton;
    public Button iniciarBoton;
    public Button nivelBoton;
    public Text jugadorLogeado;

    public void Start()
    {
        if (DBManager.LoggedIn) { jugadorLogeado.text = "Player: " + DBManager.username; }
    }
    public void CallRegister()
    {
        StartCoroutine(Registerment());
    }
    public void CallLogin()
    {
        StartCoroutine(LoginIn());
    }

    IEnumerator Registerment()
    {
        WWWForm form = new WWWForm();
        form.AddField("name", RegisterNombre.text);
        form.AddField("password", RegisterContrasenya.text);
        WWW www = new WWW("https://twinsproject2.000webhostapp.com/register.php", form);
        yield return www;
        if (www.text == "0")
        {
            Debug.Log("Usuer created succesfully.");
            UnityEngine.SceneManagement.SceneManager.LoadScene("PantallaInicio");
        }
        else
        {
            Debug.Log("User creation failed. Error #" + www.text);
        }
        
    }
    IEnumerator LoginIn()
    {
        WWWForm form = new WWWForm();
        form.AddField("name", LoginNombre.text);
        form.AddField("password", LoginContrasenya.text);
        WWW www = new WWW("https://twinsproject2.000webhostapp.com/login.php", form);
        yield return www;
        if(www.text[0] == '0')
        {
            DBManager.username = LoginNombre.text;
            string[] webResults = www.text.Split('\t');
            DBManager.puntuacionTotal = int.Parse(webResults[1]);
            DBManager.partidasJugadas = int.Parse(webResults[2]);
            DBManager.partidasGanadas = int.Parse(webResults[3]);
            DBManager.nivel = int.Parse(webResults[4]);
            UnityEngine.SceneManagement.SceneManager.LoadScene("PantallaInicio");
            Debug.Log("Partidas jugadas: " + DBManager.partidasJugadas);
            Debug.Log("Partidas ganadas: " + DBManager.partidasGanadas);
            Debug.Log("score: " + DBManager.puntuacionTotal);
            Debug.Log("nivel: " + DBManager.nivel);
        }
        else
        {
            Debug.Log("User login failed. Error #" + www.text);
        }
    }
    public void VerifyInputs()
    {
        registrarBoton.interactable = (RegisterNombre.text.Length >= 5 && RegisterContrasenya.text.Length >= 5);
        iniciarBoton.interactable = (LoginNombre.text.Length >= 5 && LoginContrasenya.text.Length >= 5);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Login.SetActive(false);
            Register.SetActive(false);
        }
    }
    public void Ingreso()
    {
        if (Login.activeSelf || Register.activeSelf)
        {
            Login.SetActive(false);
            Register.SetActive(false);
        }
        else
        {
            Login.SetActive(true);
        }
    }
    public void Registro()
    {
        if (Login.activeSelf)
        {
            Register.SetActive(true);
            Login.SetActive(false);
        }
        else
        {

        }
    }
    public void Inicio()
    {
        if (Register.activeSelf)
        {
            Login.SetActive(true);
            Register.SetActive(false);
        }
        else
        {

        }
    }
    public void partidaEstandar()
    {
        SceneManager.LoadScene("PartidaEstandar");
    }
    public void niveles()
    {
        SceneManager.LoadScene("LevelsMap");
    }
}

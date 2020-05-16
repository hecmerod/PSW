using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class PantallaInicio : MonoBehaviour
{
    public GameObject Login;
    public GameObject Register;
    public GameObject caracteristicas;
    public Dropdown partidaSel;
    public Dropdown tableroSel;
    public Dropdown barajaSel;
    public InputField LoginContrasenya;
    public InputField LoginNombre;
    public InputField RegisterNombre;
    public InputField RegisterContrasenya;
    public InputField RegisterContrasenya2;
    public Button registrarBoton;
    public Button iniciarBoton;
    public Button nivelBoton;
    public Button perfilButon;
    public Button cerrarsesionBoton;
    public Text jugadorLogeado;

    private void Awake()
    {
        DBManager.pantallaInicio = this;
        UserLogged();
    }
    private void UserLogged() {
        if (!DBManager.LoggedIn)
        {
            jugadorLogeado.text = "Usuario no logeado";
            perfilButon.interactable = false;
            cerrarsesionBoton.interactable = false;
        }
        else
        {
            jugadorLogeado.text = "Player: " + DBManager.username;
            perfilButon.interactable = true;
            cerrarsesionBoton.interactable = true;
        }
    }
    public void CallRegister()
    {
        StartCoroutine(DBManager.Registerment());
    }
    public void CallLogin()
    {
        StartCoroutine(DBManager.LoginIn());
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
            caracteristicas.SetActive(false);
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
    }
    public void Inicio()
    {
        if (Register.activeSelf)
        {
            Login.SetActive(true);
            Register.SetActive(false);
        }
    }
    public void comenzarPartida()
    {
        GameProperties.PresetSettings(GameProperties.tamaño);

        SceneManager.LoadScene("Partida");
    }
    public void niveles()
    {
        if (DBManager.LoggedIn)
            SceneManager.LoadScene("LevelsMap");
        else Debug.Log("no estás loggeado"); //HACERLO EN PANTALLA
    }
    public void perfilBoton()
    {
        SceneManager.LoadScene("PantallaPerfil");
    }

    public void salir()
    {
        //UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
    public void Desafio()
    {
        if (DBManager.LoggedIn)
        {
            SceneManager.LoadScene("Desafios");
        }
        else { Debug.Log("No estás logeado"); }
    }

    public void seleccionarBaraja()
    {
        SceneManager.LoadScene("ElegirBaraja");
    }

    public void MostrarCaracteristicas()
    {
        caracteristicas.SetActive(true);
    }
    public void cerrarSesion()
    {
        DBManager.LogOut();
        SceneManager.LoadScene("PantallaInicio");
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using System.Threading.Tasks;

public class PantallaInicio : MonoBehaviour
{
    public GameObject Login;
    public GameObject Register;
    public GameObject caracteristicas;
    public GameObject otrosModos;
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
        DBManager.getInstance().pantallaInicio = this;
        UserLogged();
    }
    private void UserLogged() {
        if (!DBManager.getInstance().LoggedIn)
        {
            jugadorLogeado.text = "Usuario no logeado";
            perfilButon.interactable = false;
            cerrarsesionBoton.interactable = false;
        }
        else
        {
            jugadorLogeado.text = "Player: " + DBManager.getInstance().username;
            perfilButon.interactable = true;
            cerrarsesionBoton.interactable = true;
        }
    }
    public void CallRegister()
    {
        StartCoroutine(DBManager.getInstance().Registerment());
    }
    public void CallLogin()
    {
        StartCoroutine(DBManager.getInstance().LoginIn());
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
        GameProperties.getInstance().trios = false;
        GameProperties.getInstance().PresetSettings(GameProperties.getInstance().tamaño);

        SceneManager.LoadScene("Partida");
    }
    public void niveles()
    {
        if (DBManager.getInstance().LoggedIn)
        {
            GameProperties.getInstance().trios = false;
            SceneManager.LoadScene("LevelsMap");
        }
        else Debug.Log("no estás loggeado");
    }
    public void perfilBoton()
    {
        SceneManager.LoadScene("PantallaPerfil");
    }

    public void salir()
    {
        Application.Quit();
    }
    public void Desafio()
    {
        if (DBManager.getInstance().LoggedIn)
        {
            GameProperties.getInstance().trios = false;
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
        DBManager.getInstance().LogOut();
        SceneManager.LoadScene("PantallaInicio");
    }
    public void JugarTrios()
    {
        GameProperties.getInstance().trios = true;
        GameProperties.getInstance().PresetSettings("trios");
        GameProperties.getInstance().tipoPartida = "Trios";
        SceneManager.LoadScene("Partida");
    }

    public void MultiLocal()
    {
        GameProperties.getInstance().trios = false;
        GameProperties.getInstance().PresetSettings("multLocal");
        GameProperties.getInstance().tipoPartida = "MultiLocal";
        SceneManager.LoadScene("Partida");
    }
    public void tableroDinamico()
    {
        GameProperties.getInstance().dinamico = true;
        GameProperties.getInstance().PresetSettings("dinamico");
        GameProperties.getInstance().tipoPartida = "Dinamica";
        SceneManager.LoadScene("Partida");
    }
    async public void cargarRanking()
    {
        StartCoroutine(DBManager.getInstance().LoadScoresData());
        await Task.Delay(1000);
        SceneManager.LoadScene("Ranking");
    }
    public void CrearBaraja() { SceneManager.LoadScene("CrearBaraja"); }

    public void gamemodes()
    {
        otrosModos.SetActive(true);
    }

    public void salirOtrosModos()
    {
        otrosModos.SetActive(false);
    }
}


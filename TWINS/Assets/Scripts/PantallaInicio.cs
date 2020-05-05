using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    public void CallRegister()
    {
        StartCoroutine(Registerment());
    }

    IEnumerator Registerment()
    {
        WWWForm form = new WWWForm();
        form.AddField("name", RegisterNombre.text);
        form.AddField("password", RegisterContrasenya.text);
        WWW www = new WWW("http://localhost/sqlconnect/register.php", form);
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
    public void VerifyInputs()
    {
        registrarBoton.interactable = (RegisterNombre.text.Length >= 5 && RegisterContrasenya.text.Length >= 5);
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
}

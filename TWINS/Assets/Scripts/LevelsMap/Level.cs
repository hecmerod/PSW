using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    void Update()
    {
        
    }

    private void onMouseDown() {
        //cargar partidaEstandar
        SceneManager.LoadScene("PartidaEstandar", LoadSceneMode.Additive);

    }

    private void onDisable()
    {

    }

    private void OnMouseEnter()
    {
        transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
    }
    void OnMouseExit() { transform.localScale = Vector3.one; }
}

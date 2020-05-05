using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    public Vector3[] cardsPosition;

    private LevelProperties levelProperties;
    private int level;

    private void Start() {
        levelProperties = GameObject.FindObjectOfType<LevelProperties>();
    }

    private void OnMouseDown() {
        levelProperties.SetProperties(level, cardsPosition, new PuntuacionFacil());

        SceneManager.LoadScene("PartidaEstandar");        
    }

    private void OnMouseEnter()
    {
        transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
    }
    void OnMouseExit() { transform.localScale = Vector3.one; }
}

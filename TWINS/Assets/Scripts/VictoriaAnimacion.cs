using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VictoriaAnimacion : MonoBehaviour
{
    public GameObject animacionAActivar;
    public Text miTiempo;
    private static float time;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        animacionAActivar.SetActive(true);
    }

}

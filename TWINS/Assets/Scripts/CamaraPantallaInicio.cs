using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraPantallaInicio : MonoBehaviour
{
    [SerializeField] private GameObject cube;
    void Update()
    {
        gameObject.transform.LookAt(cube.transform);
        transform.Translate(Vector3.right * 2 * Time.deltaTime);
    }
}

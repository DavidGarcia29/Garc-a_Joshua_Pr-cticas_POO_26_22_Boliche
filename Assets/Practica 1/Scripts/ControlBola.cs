using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ControlBola : MonoBehaviour
{
    public Transform CamaraPrincipal;

    public Rigidbody rb;

    //Variable para apuntar
    public float velocidadDeApuntado = 5f;
    public float limiteIzquierdo= -2f;
    public float limiteDerecho = 2f;

    public float fuerzaDeLanzamiento = 1000f;

    private bool haSidoLanzada = false;

    void Update()
    {
        if (haSidoLanzada == false)
        {
            Apuntar();
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Lanzar();  
            }
        }
    }

    void Apuntar()
    {
        float inputHorizontal = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.right * inputHorizontal * velocidadDeApuntado * Time.deltaTime);

        Vector3 posicionActual = transform.position;
        posicionActual.x = Mathf.Clamp(posicionActual.x, limiteIzquierdo, limiteDerecho);
        transform.position = posicionActual;
    }

    void Lanzar()
    {
        haSidoLanzada = true;
        rb.AddForce(Vector3.forward * fuerzaDeLanzamiento);

        if(CamaraPrincipal != null)
        {
            CamaraPrincipal.SetParent(transform);
        }
    }
}

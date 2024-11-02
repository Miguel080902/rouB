using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pupila : MonoBehaviour
{
    private Vector2 posicionInicial;
    private Vector2 posicionActual;
    private bool siguiendoInput = false;
    private Vector2 destino;
    public float velocidadMovimiento = 5.0f; // Ajusta la velocidad de movimiento
    public float radioMovimiento = 2.0f; // Define el radio de movimiento aquí

    void Start()
    {
        posicionInicial = transform.position;
        posicionActual = posicionInicial;
        destino = posicionInicial;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            siguiendoInput = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            siguiendoInput = false;
            destino = posicionInicial; // Al soltar el mouse, la pupila vuelve a su posición inicial
        }

        if (siguiendoInput)
        {
            Vector3 inputPos = Input.mousePosition;
            inputPos.z = 10; // Ajusta la distancia Z según tu cámara

            Vector3 dedoPos = Camera.main.ScreenToWorldPoint(inputPos);
            dedoPos.z = 0;

            Vector3 direccion = dedoPos - (Vector3)posicionInicial;
            float distancia = direccion.magnitude;

            if (distancia <= radioMovimiento)
            {
                destino = dedoPos;
            }
            else
            {
                // Limita la pupila al radio del ojo
                Vector2 direccionNormalizada = direccion.normalized;
                destino = (Vector2)posicionInicial + direccionNormalizada * radioMovimiento;
            }
        }

        // Aplica una interpolación lineal suave para mover la pupila de la posición actual a la posición de destino
        posicionActual = Vector2.Lerp(posicionActual, destino, velocidadMovimiento * Time.deltaTime);
        transform.position = posicionActual;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Comida : MonoBehaviour
{
    private Vector3 posicionInicial;
    public bool siendoArrastrada = false;
    public bool comible = false;
    public string nombre;
    public SpriteRenderer spr;
    public Sprite imagen;
    public Personaje personaje; // Referencia al personaje en el inspector
    public float cantidadHambreAumento = 10f; // Cantidad de aumento de hambre al comer
    public int cantidad = 1;

    private void Start()
    {
        posicionInicial = transform.position;
        personaje = GameObject.Find("ROU").GetComponent<Personaje>();
    }
    void OnMouseDown()
    {
        siendoArrastrada = true;
    }

    void OnMouseDrag()
    {
        if (siendoArrastrada)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
            transform.position = mousePos;
        }
    }
    public void Comido()
    {
            cantidad--;
    }
    void OnMouseUp()
    {
        siendoArrastrada = false;
        if (personaje != null && comible )
        {
            personaje.AumentarHambre(cantidadHambreAumento);
            Comido();
        }   

        transform.position = posicionInicial;  
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            comible = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            comible = false;
        }
    }
}

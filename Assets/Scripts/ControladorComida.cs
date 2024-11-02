using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ControladorComida : MonoBehaviour
{
    public TMP_Text nombreComidaText;
    public TMP_Text cantidadComidaText;
    
    public Button botonSiguiente;
    public Button botonAnterior;
    public Comida comidaEnPantalla;
    public List<Comida> listaDeComidas = new List<Comida>();
    private int comidaActualIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        // Configura los botones para cambiar de comida
        botonSiguiente.onClick.AddListener(SeleccionarSiguienteComida);
        botonAnterior.onClick.AddListener(SeleccionarComidaAnterior);

        // Muestra la comida actual
        ActualizarUI();
    }
   
    void ActualizarUI()
    {
        if (comidaActualIndex >= 0 && comidaActualIndex < listaDeComidas.Count)
        {
            Comida comidaActual = listaDeComidas[comidaActualIndex];
            nombreComidaText.text = comidaActual.nombre;
            cantidadComidaText.text = "x" + comidaActual.cantidad.ToString();
            comidaEnPantalla.spr.sprite = comidaActual.imagen;
            
        }
        else
        {
            nombreComidaText.text = "Sin comida";
            cantidadComidaText.text = "x0";
        }
    }

    void SeleccionarSiguienteComida()
    {
        if (listaDeComidas.Count > 0)
        {
            comidaActualIndex = (comidaActualIndex + 1) % listaDeComidas.Count;
            ActualizarUI();
        }
    }

    void SeleccionarComidaAnterior()
    {
        if (listaDeComidas.Count > 0)
        {
            comidaActualIndex = (comidaActualIndex - 1 + listaDeComidas.Count) % listaDeComidas.Count;
            ActualizarUI();
        }
    }

    public void AgregarComida(Comida nuevaComida)
    {
        // Busca si ya existe una comida con el mismo nombre en la lista
        foreach (Comida comida in listaDeComidas)
        {
            if (comida.nombre == nuevaComida.nombre)
            {
                // Si ya existe, aumenta la cantidad en lugar de agregarla
                comida.cantidad += nuevaComida.cantidad;
                ActualizarUI(); // Actualiza la UI
                return;
            }
        }

        // Si no existe una comida con el mismo nombre, agrégala a la lista
        listaDeComidas.Add(nuevaComida);
        ActualizarUI(); // Actualiza la UI
    }
}

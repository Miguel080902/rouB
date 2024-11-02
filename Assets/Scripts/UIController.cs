using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIController : MonoBehaviour
{
    public Image saludFill;
    public Image diversionFill;
    public Image energiaFill;
    public Image hambreFill;

    public Color verde;
    public Color amarillo;
    public Color rojo;

    public Personaje personaje; // Aseg�rate de asignar la referencia al Personaje en el inspector

    private void Update()
    {
        // Actualizar las im�genes de llenado y colores de acuerdo a las estad�sticas
        ActualizarUI();
    }

    void ActualizarUI()
    {
        // Actualizar la imagen de llenado y color de salud
        saludFill.fillAmount = personaje.salud / 100f;
        saludFill.color = Color.Lerp(rojo, verde, saludFill.fillAmount);

        diversionFill.fillAmount = personaje.diversi�n / 100f;
        diversionFill.color = Color.Lerp(rojo, verde, diversionFill.fillAmount);

        energiaFill.fillAmount = personaje.energ�a / 100f;
        energiaFill.color = Color.Lerp(rojo, verde, energiaFill.fillAmount);

        hambreFill.fillAmount = personaje.hambre / 100f;
        hambreFill.color = Color.Lerp(rojo, verde, hambreFill.fillAmount);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personaje : MonoBehaviour
{
    public Animator animador;
    // Estad�sticas del personaje
    public float salud = 100f;
    public float diversi�n = 100f;
    public float energ�a = 100f;
    public float hambre = 100f;

    // Ajusta la velocidad a la que disminuyen las estad�sticas
    public float velocidadDecremento = 1.0f;

    private bool acariciando = false;
    private float tiempoUltimaAcariciada;
    public float tiempoParaAumentarDiversi�n = 5f;
    void Update()
    {
        // Decrementar las estad�sticas con el tiempo
        DecrementarEstadisticas();

        if (acariciando && Time.time - tiempoUltimaAcariciada >= tiempoParaAumentarDiversi�n)
        {
            AumentarDiversi�n(10f); // Aumenta la diversi�n en 10 unidades (ajusta seg�n tus necesidades)
            tiempoUltimaAcariciada = Time.time;
        }
    }

    void DecrementarEstadisticas()
    {
        // Reducci�n gradual de las estad�sticas con el tiempo
        salud -= velocidadDecremento * Time.deltaTime*1.5f;
        diversi�n -= velocidadDecremento * Time.deltaTime * 3;
        energ�a -= velocidadDecremento * Time.deltaTime*2;
        hambre -= velocidadDecremento * Time.deltaTime*4;

        // Aseg�rate de que las estad�sticas no bajen por debajo de 0
        salud = Mathf.Max(0f, salud);
        diversi�n = Mathf.Max(0f, diversi�n);
        energ�a = Mathf.Max(0f, energ�a);
        hambre = Mathf.Max(0f, hambre);

        // Aqu� puedes agregar l�gica adicional en funci�n de las estad�sticas
        // Por ejemplo, cambiar la apariencia del personaje o su animaci�n seg�n el estado de las estad�sticas.
    }
    public void AumentarSalud(float aumentoSalud)
    {
        salud += aumentoSalud;
        salud = Mathf.Clamp(salud, 0f, 100f);
    }

    // M�todo para aumentar el hambre
    public void AumentarHambre(float aumentoHambre)
    {
        hambre += aumentoHambre;
        hambre = Mathf.Clamp(hambre, 0f, 100f);
    }

    // M�todo para aumentar la diversi�n
    public void AumentarDiversi�n(float aumentoDiversi�n)
    {
        diversi�n += aumentoDiversi�n;
        diversi�n = Mathf.Clamp(diversi�n, 0f, 100f);
    }

    // M�todo para aumentar la energ�a
    public void AumentarEnerg�a(float aumentoEnerg�a)
    {
        energ�a += aumentoEnerg�a;
        energ�a = Mathf.Clamp(energ�a, 0f, 100f);
    }

    // M�todo para iniciar la animaci�n de caricia
    public void IniciarAcariciar()
    {
        acariciando = true;
        tiempoUltimaAcariciada = Time.time;
        animador.SetBool("Caricia",acariciando); // Activa la animaci�n de caricia
    }

    // M�todo para detener la animaci�n de caricia
    public void DetenerAcariciar()
    {
        acariciando = false;
        animador.SetBool("Caricia", acariciando); // Activa una animaci�n de finalizaci�n de caricia si es necesario
    }

    // Resto de tus m�todos...

    void OnMouseDown()
    {
        // Llama al m�todo para iniciar la animaci�n de caricia
        IniciarAcariciar();
    }

    void OnMouseUp()
    {
        // Llama al m�todo para detener la animaci�n de caricia
        DetenerAcariciar();
    }
}

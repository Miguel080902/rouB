using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personaje : MonoBehaviour
{
    public Animator animador;
    // Estadísticas del personaje
    public float salud = 100f;
    public float diversión = 100f;
    public float energía = 100f;
    public float hambre = 100f;

    // Ajusta la velocidad a la que disminuyen las estadísticas
    public float velocidadDecremento = 1.0f;

    private bool acariciando = false;
    private float tiempoUltimaAcariciada;
    public float tiempoParaAumentarDiversión = 5f;
    void Update()
    {
        // Decrementar las estadísticas con el tiempo
        DecrementarEstadisticas();

        if (acariciando && Time.time - tiempoUltimaAcariciada >= tiempoParaAumentarDiversión)
        {
            AumentarDiversión(10f); // Aumenta la diversión en 10 unidades (ajusta según tus necesidades)
            tiempoUltimaAcariciada = Time.time;
        }
    }

    void DecrementarEstadisticas()
    {
        // Reducción gradual de las estadísticas con el tiempo
        salud -= velocidadDecremento * Time.deltaTime*1.5f;
        diversión -= velocidadDecremento * Time.deltaTime * 3;
        energía -= velocidadDecremento * Time.deltaTime*2;
        hambre -= velocidadDecremento * Time.deltaTime*4;

        // Asegúrate de que las estadísticas no bajen por debajo de 0
        salud = Mathf.Max(0f, salud);
        diversión = Mathf.Max(0f, diversión);
        energía = Mathf.Max(0f, energía);
        hambre = Mathf.Max(0f, hambre);

        // Aquí puedes agregar lógica adicional en función de las estadísticas
        // Por ejemplo, cambiar la apariencia del personaje o su animación según el estado de las estadísticas.
    }
    public void AumentarSalud(float aumentoSalud)
    {
        salud += aumentoSalud;
        salud = Mathf.Clamp(salud, 0f, 100f);
    }

    // Método para aumentar el hambre
    public void AumentarHambre(float aumentoHambre)
    {
        hambre += aumentoHambre;
        hambre = Mathf.Clamp(hambre, 0f, 100f);
    }

    // Método para aumentar la diversión
    public void AumentarDiversión(float aumentoDiversión)
    {
        diversión += aumentoDiversión;
        diversión = Mathf.Clamp(diversión, 0f, 100f);
    }

    // Método para aumentar la energía
    public void AumentarEnergía(float aumentoEnergía)
    {
        energía += aumentoEnergía;
        energía = Mathf.Clamp(energía, 0f, 100f);
    }

    // Método para iniciar la animación de caricia
    public void IniciarAcariciar()
    {
        acariciando = true;
        tiempoUltimaAcariciada = Time.time;
        animador.SetBool("Caricia",acariciando); // Activa la animación de caricia
    }

    // Método para detener la animación de caricia
    public void DetenerAcariciar()
    {
        acariciando = false;
        animador.SetBool("Caricia", acariciando); // Activa una animación de finalización de caricia si es necesario
    }

    // Resto de tus métodos...

    void OnMouseDown()
    {
        // Llama al método para iniciar la animación de caricia
        IniciarAcariciar();
    }

    void OnMouseUp()
    {
        // Llama al método para detener la animación de caricia
        DetenerAcariciar();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Victoria : MonoBehaviour
{
    // Nombre de la escena a la que quieres ir (ej: "Menu" o "Victoria")
    public string nombreEscenaDestino = "Menu";

    private void OnTriggerEnter(Collider other)
    {
        // Comprobamos si lo que tocó la bandera es el Jugador
        if (other.CompareTag("Player"))
        {
            Debug.Log("¡Ganaste! Volviendo al menú...");
            SceneManager.LoadScene(nombreEscenaDestino);
        }
       
    }
}
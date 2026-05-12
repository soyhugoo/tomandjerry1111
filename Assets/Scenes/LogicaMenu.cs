using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Importante para cambiar de escena
public class LogicaMenu : MonoBehaviour
{
    public void Jugar()
    {
        // "Game" debe ser el nombre exacto de tu escena de juego
        SceneManager.LoadScene("Game");
    }

    public void Salir()
    {
        Debug.Log("Saliendo del juego...");
        Application.Quit(); // Esto cierra el juego cuando esté exportado
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 


public class Muerte : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Importante: "Player" con P mayúscula
        if (other.CompareTag("Player"))
        {
            // Carga la escena actual para reiniciar
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}


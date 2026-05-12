using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    public Animator animator; 
    [Header("Ajustes de Movimiento")]
    public float velocidad = 5f;
    public float fuerzaSalto = 7f;

    [Header("Configuración de Pausa")]
    public GameObject objetoPausa; // <- Arrastra tu PanelPausa aquí en el Inspector

    private Rigidbody rb;
    private bool puedeSaltar = true;
    private bool estaPausado = false;

    void Start()
    {
        // Obtenemos el componente Rigidbody al empezar
        rb = GetComponent<Rigidbody>();

        // Nos aseguramos de que el juego empiece sin pausa
        Time.timeScale = 1f;
    }

    void Update()
    {
        // 1. Detectar la tecla de pausa (P)
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (estaPausado) Reanudar();
            else Pausar();
        }

        // 2. Solo permitir movimiento si NO está pausado
        if (!estaPausado)
        {
            MoverJugador();
        }
    }

    void MoverJugador()
    {
        // Movimiento Horizontal (A/D o Flechas)
        float movH = Input.GetAxis("Horizontal");
        rb.velocity = new Vector3(movH * velocidad, rb.velocity.y, 0);
        if (movH > 0)
        {
            animator.SetBool("corriendo", true);
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if (movH < 0)
        {
            animator.SetBool("corriendo", true);
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else animator.SetBool("corriendo", false);
        // Salto (Espacio)
        if (Input.GetButtonDown("Jump") && puedeSaltar)
        {
            rb.AddForce(Vector3.up * fuerzaSalto, ForceMode.Impulse);
            puedeSaltar = false;
        }
    }

    public void Pausar()
    {
        estaPausado = true;
        if (objetoPausa != null) objetoPausa.SetActive(true);
        Time.timeScale = 0f; // Congela el juego
    }

    public void Reanudar()
    {
        estaPausado = false;
        if (objetoPausa != null) objetoPausa.SetActive(false);
        Time.timeScale = 1f; // Devuelve el tiempo a la normalidad
    }

    // Detectar si estamos tocando el suelo para volver a saltar
    private void OnCollisionEnter(Collision collision)
    {
        // Asegúrate de que el suelo tenga el Tag "suelo" (en minúsculas como aquí)
        if (collision.gameObject.CompareTag("suelo"))
        {
            puedeSaltar = true;
        }
    }
   
    public void VolverAlMenu()
    {
        Time.timeScale = 1f; // ¡IMPORTANTE! Si no reinicias el tiempo, el menú irá lento o se congelará
        SceneManager.LoadScene("Menu"); // Pon aquí el nombre exacto de tu escena de menú
    }
}
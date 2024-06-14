using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Interfaz : MonoBehaviour, IObserver
{
    public TMP_Text puntuacion;
    private int rehenesSalvados;
    private bool juegoFinalizado = false;

    void Start()
    {
        GameObject[] rehenes = GameObject.FindGameObjectsWithTag("Rehen");
        foreach (GameObject rehen in rehenes)
        {
            rehen.GetComponent<ISubject>().AddObserver(this);
        }

        GameObject jugador = GameObject.FindGameObjectWithTag("Player");
        if (jugador != null)
        {
            jugador.GetComponent<ISubject>().AddObserver(this);
        }
        else
        {
            Debug.LogWarning("No se encontró ningún objeto con la etiqueta 'Player'.");
        }
    }

    void Update()
    {
        if (!juegoFinalizado)
        {
            Juego();
        }
    }

    private void Ganar()
    {
        puntuacion.text = "Rehenes salvados: 10";
        Debug.Log("¡Juego ganado!");
    }

    private void SalvarRehen()
    {
        rehenesSalvados++;
        puntuacion.text = "Rehenes salvados: " + rehenesSalvados.ToString() + "/10";
        Debug.Log("Rehenes salvados: " + rehenesSalvados);
    }

    private void Juego()
    {
        if (rehenesSalvados == 10)
        {
            juegoFinalizado = true;
            Ganar();
        }
    }

    public void UpdateState(int id)
    {
        Debug.Log("Interfaz recibio UpdateState con id: " + id);
        if (id == 0)
        {
            SalvarRehen();
        }
        else
        {
            Ganar();
        }
    }
}
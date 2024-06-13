using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Interfaz : MonoBehaviour, IObserver
{
    public TMP_Text puntuacion;
    private int rehenesSalvados;

    private bool juegoFinalizado = false;

    [SerializeField]
    private AudioSource _reproductor;
    [SerializeField]
    private AudioClip _clipAudio;


    // Start is called before the first frame update
    void Start()
    {
        GameObject rehen = GameObject.FindGameObjectWithTag("Rehen");
        rehen.GetComponent<ISubject>().AddObserver(gameObject.GetComponent<IObserver>());

        GameObject jugador = GameObject.FindGameObjectWithTag("Jugador");
        jugador.GetComponent<ISubject>().AddObserver(gameObject.GetComponent<IObserver>());


    }

    // Update is called once per frame
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
    }

    private void SalvarRehen()
    {
        rehenesSalvados++;
        puntuacion.text = "Rehenes salvados: " + puntuacion.ToString() + "/10";

    }

    private void Juego()
    {
        if (rehenesSalvados == 10)
        {
            juegoFinalizado = true;
        }
    }

    public void UpdateState(int id)
    {
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
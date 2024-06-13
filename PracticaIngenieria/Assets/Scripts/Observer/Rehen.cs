using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rehen : MonoBehaviour, IObserver, ISubject,IInteractuable
{
    public int numRehenesSalvados = 0;
    private List<IObserver> observadores = new List<IObserver>();


    private void Start()
    {
        observadores = new List<IObserver>();
        // Se añade como observador del sujeto jugador
        GameObject jugador = GameObject.FindGameObjectWithTag("Jugador");
        jugador.GetComponent<ISubject>().AddObserver(gameObject.GetComponent<IObserver>());

    }

    private void Update()
    {
        Comprobar();
    }

    private void SalvarRehen()
    {
        numRehenesSalvados++;
    }

    private void Comprobar()
    {
        if (numRehenesSalvados == 10)
        {
            Destroy(gameObject, 0.1f);
            NotifyObservers();
        }
    }

    public void UpdateState(int id)
    {
        SalvarRehen();
    }

    public void AddObserver(IObserver o)
    {
        observadores.Add(o);
    }

    public void RemoveObserver(IObserver o)
    {
        observadores.Remove(o);
    }

    public void NotifyObservers()
    {
        foreach (IObserver o in observadores)
        {
            o.UpdateState(1);
        }
    }
    public void Interactuar()
    {

    }
}

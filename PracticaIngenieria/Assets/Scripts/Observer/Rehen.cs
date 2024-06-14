using System.Collections.Generic;
using UnityEngine;

public class Rehen : MonoBehaviour, IObserver, ISubject
{
    public int numRehenesSalvados = 0;
    private List<IObserver> observadores = new List<IObserver>();
    private bool salvado = false;

    private void Start()
    {
        // Se añade como observador del sujeto jugador
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

    private void Update()
    {
        Comprobar();
    }

    private void SalvarRehen()
    {
        if (!salvado)
        {
            salvado = true;
            numRehenesSalvados++;
            gameObject.SetActive(false);
            NotifyObservers();
        }
    }

    private void Comprobar()
    {
        if (numRehenesSalvados == 10)
        {
            foreach (IObserver o in observadores)
            {
                o.UpdateState(1);
            }
        }
    }

    public void UpdateState(int id)
    {
        Debug.Log("Rehen actualizando estado con id: " + id);
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
            o.UpdateState(0);
        }
    }
}
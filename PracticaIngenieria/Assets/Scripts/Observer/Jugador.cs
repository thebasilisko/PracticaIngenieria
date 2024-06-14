using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Jugador : MonoBehaviour, ISubject
{
    private List<IObserver> observadores = new List<IObserver>();
    private IObserver rehenActual;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.Instance.pauseMenuUI)
        {
            Controles();
        }
    }

    private void Controles()
    {
        if (Input.GetKeyDown(KeyCode.E)&&rehenActual!=null)
        {
            NotifyObservers();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Rehen"))
        {
            rehenActual = other.gameObject.GetComponent<IObserver>();
            AddObserver(rehenActual);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Rehen"))
        {
            RemoveObserver(rehenActual);
            rehenActual = null;
        }
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
        foreach (IObserver observer in observadores)
        {
            observer.UpdateState(0);
        }
    }
}

using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour, ISubject
{
    private List<IObserver> observadores = new List<IObserver>();
    private IObserver rehenActual;

    void Start()
    {
        // Inicialización adicional si es necesaria
    }

    void Update()
    {
        if (!GameManager.Instance.pauseMenuUI)
        {
            Controles();
        }
    }

    private void Controles()
    {
        if (Input.GetKeyDown(KeyCode.E) && rehenActual != null)
        {
            Debug.Log("Tecla E pulsada y rehenActual no es nulo. Notificando observador actual.");
            NotifyObserver(rehenActual);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Rehen"))
        {
            Debug.Log("Rehen detectado en OnTriggerEnter.");
            rehenActual = other.gameObject.GetComponent<IObserver>();
            AddObserver(rehenActual);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Rehen"))
        {
            Debug.Log("Rehen saliendo del área de colisión en OnTriggerExit.");
            RemoveObserver(rehenActual);
            rehenActual = null;
        }
    }

    public void AddObserver(IObserver o)
    {
        if (!observadores.Contains(o))
        {
            observadores.Add(o);
        }
    }

    public void RemoveObserver(IObserver o)
    {
        if (observadores.Contains(o))
        {
            observadores.Remove(o);
        }
    }

    public void NotifyObservers()
    {
        foreach (IObserver observer in observadores)
        {
            observer.UpdateState(0);
        }
    }

    public void NotifyObserver(IObserver observer)
    {
        if (observer != null)
        {
            observer.UpdateState(0);
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private IMovible jugador;
    private IMovible camara;
    private IInteractuable puertas;
    private IInteractuable rehenes;
    private List<IMovible> movibles = new List<IMovible>();
    private List<IInteractuable> interactuables = new List<IInteractuable>();
    private CommandManager commandManager;

    private void Awake()
    {
        // Asignación de variables
        commandManager = new CommandManager();
        jugador = GameObject.FindWithTag("Jugador").GetComponent<Jugador>();
        movibles.Add(jugador);
        camara = GameObject.FindWithTag("MainCamera").GetComponent<Camara>();
        movibles.Add(camara);
        rehenes = GameObject.FindWithTag("Rehen").GetComponent<Rehen>();
        interactuables.Add(rehenes);
        puertas = GameObject.FindWithTag("Puerta").GetComponent<Puerta>();
        interactuables.Add(puertas);
    }


    // Update is called once per frame
    void Update()
    {
        // Esta clase se encarga de recoger las entradas del usuario, para mandar ejecutar las acciones a CommandManager

        if ((jugador.enMovimiento() && Input.anyKey))
        {
            return;
        }
        if (Input.GetKey(KeyCode.W))
        {
            ICommand comando = new MovAlante(movibles);
            commandManager.EjecutarComando(comando);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            ICommand comando = new MovAtras(movibles);
            commandManager.EjecutarComando(comando);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            ICommand comando = new MovIzq(movibles);
            commandManager.EjecutarComando(comando);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            ICommand comando = new MovDer(movibles);
            commandManager.EjecutarComando(comando);
        }
        else if (Input.GetKey(KeyCode.E))
        {
            ICommand comando = new Interactuar(interactuables);
            commandManager.EjecutarComando(comando);
        }
        else if (Input.GetMouseButtonDown(0))
        {
            ICommand comando = new Disparar(movibles);
            commandManager.EjecutarComando(comando);
        }

    }
}

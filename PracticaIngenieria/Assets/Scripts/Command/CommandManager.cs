using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandManager : MonoBehaviour
{
    public List<ICommand> comandosEjecutados = new List<ICommand>();
    private int ultimoComandoEjecutado = 0;

    public void EjecutarComando(ICommand comando)
    {
        comando.Execute();
        comandosEjecutados.Add(comando);
        ultimoComandoEjecutado = comandosEjecutados.Count - 1;
    }
}

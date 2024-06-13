using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovAtras : ICommand
{
    private List<IMovible> movibles;

    public MovAtras(List<IMovible> list)
    {
        movibles = list;
    }

    public void Execute()
    {
        foreach (IMovible obj in movibles)
        {
            obj.Mover(Vector3.back);
        }
    }

    public void Undo()
    {
        foreach (IMovible obj in movibles)
        {
            obj.Mover(Vector3.forward);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparar : ICommand
{
    private List<IMovible> movibles;

    public Disparar(List<IMovible> list)
    {
        movibles = list;
    }

    public void Execute()
    {
        foreach (IMovible obj in movibles)
        {
            obj.Disparar();
        }
    }

    public void Undo()
    {
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovAlante : ICommand
{
    private List<IMovible> movibles;

    public MovAlante(List<IMovible> list)
    {
        movibles = list;
    }

    public void Execute()
    {
        foreach (IMovible obj in movibles)
        {
            obj.Mover(Vector3.forward);
        }
    }

    public void Undo()
    {
        foreach (IMovible obj in movibles)
        {
            obj.Mover(Vector3.back);
        }
    }
}

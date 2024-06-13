using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovIzq : ICommand
{
    private List<IMovible> movibles;

    public MovIzq(List<IMovible> list)
    {
        movibles = list;
    }

    public void Execute()
    {
        foreach (IMovible obj in movibles)
        {
            obj.Mover(Vector3.left);
        }
    }

    public void Undo()
    {
        foreach (IMovible obj in movibles)
        {
            obj.Mover(Vector3.right);
        }
    }
}

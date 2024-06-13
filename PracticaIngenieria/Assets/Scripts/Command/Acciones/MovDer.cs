using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovDer : ICommand
{
    private List<IMovible> movibles;

    public MovDer(List<IMovible> list)
    {
        movibles = list;
    }

    public void Execute()
    {
        foreach (IMovible obj in movibles)
        {
            obj.Mover(Vector3.right);
        }
    }

    public void Undo()
    {
        foreach (IMovible obj in movibles)
        {
            obj.Mover(Vector3.left);
        }
    }
}

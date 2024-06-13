using System.Collections.Generic;
using UnityEngine;

public class Interactuar : ICommand
{
    private List<IInteractuable> interactuables;

    public Interactuar(List<IInteractuable> list)
    {
        interactuables = list;
    }

    public void Execute()
    {
        foreach (IInteractuable obj in interactuables)
        {
            obj.Interactuar();
        }
    }

    public void Undo()
    {
    }
}

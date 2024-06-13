using UnityEngine;

public interface IMovible
{
    public void Mover(Vector3 direccion);
    public bool enMovimiento();
    public void Disparar();
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour, IMovible
{
    public float _velocidad;
    public bool _enMovimiento;
    private Vector3 _destino;
    private Vector3 _direccionDestino;

    public bool enMovimiento()
    {
        return _enMovimiento;
    }

    public void Mover(Vector3 direccion)
    {
        if (!_enMovimiento)
        {
            _direccionDestino = new Vector3(direccion.x * transform.right.x, 0, direccion.z * transform.forward.z).normalized;
            _destino = transform.position + _direccionDestino * 1.05f;
            _enMovimiento = true;
        }
    }
    public void Disparar()
    {

    }
    public void Interactuar()
    {

    }
    private void FixedUpdate()
    {
        if (_enMovimiento)
        {
            transform.position += _direccionDestino * _velocidad * Time.fixedDeltaTime;
        }
        if (Vector3.Distance(transform.position, _destino) <= 0.05f)
        {
            transform.position = _destino;
            _enMovimiento = false;
        }
    }

}

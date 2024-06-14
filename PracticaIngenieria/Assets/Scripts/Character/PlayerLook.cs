using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public Camera cam;
    public float xRotation = 0f;

    public float xSensitivity = 60f;
    public float ySensitivity = 60f;

    void Update()
    {
        // Obtener la entrada del rat�n
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        // Llamar al m�todo ProcessLook con la entrada del rat�n
        ProcessLook(new Vector2(mouseX, mouseY));
    }

    public void ProcessLook(Vector2 input)
    {
        float mouseX = input.x;
        float mouseY = input.y;

        // Calculo rotaci�n mirar arriba y abajo
        xRotation -= (mouseY * Time.deltaTime) * ySensitivity;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f); // Establecer valores m�nimos y m�ximos de la rotaci�n
        // Aplicar la rotaci�n a la transformaci�n de la c�mara
        cam.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);

        // Calculo rotaci�n derecha e izq
        transform.Rotate(Vector3.up * (mouseX * Time.deltaTime) * xSensitivity);
    }
}

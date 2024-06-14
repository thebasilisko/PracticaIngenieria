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
        // Obtener la entrada del ratón
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        // Llamar al método ProcessLook con la entrada del ratón
        ProcessLook(new Vector2(mouseX, mouseY));
    }

    public void ProcessLook(Vector2 input)
    {
        float mouseX = input.x;
        float mouseY = input.y;

        // Calculo rotación mirar arriba y abajo
        xRotation -= (mouseY * Time.deltaTime) * ySensitivity;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f); // Establecer valores mínimos y máximos de la rotación
        // Aplicar la rotación a la transformación de la cámara
        cam.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);

        // Calculo rotación derecha e izq
        transform.Rotate(Vector3.up * (mouseX * Time.deltaTime) * xSensitivity);
    }
}

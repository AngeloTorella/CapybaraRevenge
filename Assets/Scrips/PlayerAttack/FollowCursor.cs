using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCursor : MonoBehaviour
{
    [SerializeField] private Camera cam; // Referencia a la cámara
    [SerializeField] private float rotationSpeed = 8f; // Velocidad de rotación

    // Update is called once per frame
    void Update()
    {
        // Convertir la posición del cursor del espacio de pantalla al espacio del mundo
        Vector3 cursorPosition = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, cam.nearClipPlane));

        // Calcular la dirección hacia el cursor 
        Vector3 direction = cursorPosition - transform.position;

        // Calcular el ángulo en grados que apunta hacia la dirección
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Crear una rotación con el ángulo alrededor del eje Z
        Quaternion toRotation = Quaternion.Euler(0, 0, angle);

        // Interpolar suavemente entre la rotación actual y la rotación objetivo
        transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
    }
}
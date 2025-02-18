using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraBehaviour : MonoBehaviour
{
    public Transform player; // Referencia al jugador
    public Vector3 offset;   // Offset para ajustar la posici�n de la c�mara respecto al jugador
    public float smoothSpeed = 0.125f; // Velocidad de interpolaci�n de la c�mara

    void LateUpdate()
    {
        if (player != null)
        {
            Vector3 desiredPosition = player.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
    }
}

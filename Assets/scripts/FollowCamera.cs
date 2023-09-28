using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform target; // O transform do personagem que a c�mera seguir�
    public float smoothSpeed = 0.125f; // A suavidade do movimento da c�mera
    public Vector3 offset; // A dist�ncia entre a c�mera e o personagem

    void LateUpdate()
    {
        if (target != null)
        {
            // Calcula a posi��o desejada da c�mera
            Vector3 desiredPosition = target.position + offset;

            // Suaviza o movimento da c�mera usando a fun��o Lerp
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

            // Define a posi��o da c�mera para a posi��o suavizada
            transform.position = smoothedPosition;
        }
    }
}
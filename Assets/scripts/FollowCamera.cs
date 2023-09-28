using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform target; // O transform do personagem que a câmera seguirá
    public float smoothSpeed = 0.125f; // A suavidade do movimento da câmera
    public Vector3 offset; // A distância entre a câmera e o personagem

    void LateUpdate()
    {
        if (target != null)
        {
            // Calcula a posição desejada da câmera
            Vector3 desiredPosition = target.position + offset;

            // Suaviza o movimento da câmera usando a função Lerp
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

            // Define a posição da câmera para a posição suavizada
            transform.position = smoothedPosition;
        }
    }
}
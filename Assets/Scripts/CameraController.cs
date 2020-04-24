using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    void LateUpdate()
    {
        Vector2 newPosition = player.position;
        transform.position = newPosition;
    }
}


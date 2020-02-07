using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [NonSerialized]
    public static PlayerController instance;

    // Player movement speed
    public float Speed = 1f;
    private void Start()
    {
        instance = this;
    }

    public void FixedUpdate()
    {
        // Movement
        transform.position += Time.fixedDeltaTime * Speed * new Vector3(Input.GetAxis("Horizontal"),0f,Input.GetAxis("Vertical"));
    }
}

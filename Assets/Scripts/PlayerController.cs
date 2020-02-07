using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [NonSerialized]
    public static PlayerController instance;

    private CharacterController character;

    // Player movement speed
    public float Speed = 1f;
    private void Start()
    {
        instance = this;
        character = GetComponent<CharacterController>();
    }

    public void FixedUpdate()
    {
        // Movement
        character.Move(Time.fixedDeltaTime * Speed * new Vector3(Input.GetAxis("Horizontal"),0f,Input.GetAxis("Vertical")).normalized);
    }
}
